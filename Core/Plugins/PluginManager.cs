using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.Util;
using MettleSystems.dashCommerce.Core.Plugins;

[assembly: PreApplicationStartMethod(typeof(PluginManager), "Initialize")]
namespace MettleSystems.dashCommerce.Core.Plugins {

  public class PluginManager {

    private static readonly ReaderWriterLockSlim Locker = new ReaderWriterLockSlim();
    private static DirectoryInfo _shadowCopyFolder;
    private static bool? _isFullTrust;
    private static DirectoryInfo _pluginFolder;
    private static PluginManagerShadowCopyType _shadowCopyType;
    public const string CUSTOM_PLUGINS = "CustomPlugins";
    private static string _pluginsHash;
    public static IEnumerable<PluginDefinition> ReferencedPlugins { get; private set; }


    public static void Initialize() {
      using (new WriteLockDisposable(Locker)) {
        var pluginPath = HostingEnvironment.MapPath("~/App_Plugins");
        _pluginFolder = new DirectoryInfo(pluginPath);

        //Default to the bin directory
        _shadowCopyFolder = new DirectoryInfo(HostingEnvironment.MapPath("~/bin"));

        if (_shadowCopyType == PluginManagerShadowCopyType.OverrideDefaultFolder) {
          var shadowCopyPath = HostingEnvironment.MapPath("~/App_Plugins/bin");
          _shadowCopyFolder = new DirectoryInfo(shadowCopyPath);
        }
        else if (IsFullTrust() && _shadowCopyType == PluginManagerShadowCopyType.UseDynamicFolder) {
          _shadowCopyFolder = new DirectoryInfo(AppDomain.CurrentDomain.DynamicDirectory);
        }

        var referencedPlugins = new List<PluginDefinition>();
        var pluginFiles = Enumerable.Empty<FileInfo>();

        try {
          Directory.CreateDirectory(_pluginFolder.FullName);
          if (_shadowCopyType != PluginManagerShadowCopyType.UseDynamicFolder) {
            Directory.CreateDirectory(_shadowCopyFolder.FullName);
          }
          Directory.CreateDirectory(Path.Combine(_pluginFolder.FullName, CUSTOM_PLUGINS));

          pluginFiles = _pluginFolder.GetFiles("*.dll", SearchOption.AllDirectories)
            .ToArray()
            .Where(x => x.Directory.Parent != null)
            .ToList();
        }
        catch (Exception ex) {
          Logger.LogException("Failed to load plugins.", ex, Logger.LogMessageType.Error);
        }

        try {
          //Detect if there are any changes to plugins and perform any cleanup if in full trust using the dynamic folder
          if (DetectAndCleanStalePlugins(pluginFiles, _shadowCopyFolder)) {
            //if plugins changes have been detected, then shadow copy and re-save the cache files


            //shadow copy files
            referencedPlugins
                .AddRange(pluginFiles.Select(plug =>
                    new PluginDefinition(plug,
                        GetPackageFolderFromPluginDll(plug),
                        PerformFileDeployAndRegistration(plug, true),
                        plug.Directory.Parent.Name == "Core")));

            //save our plugin hash value
            WriteCachePluginsHash(pluginFiles);
            //save our plugins list
            WriteCachePluginsList(pluginFiles);

            var codeBase = typeof(PluginManager).Assembly.CodeBase;
            var uri = new Uri(codeBase);
            var path = uri.LocalPath;
            var binFolder = Path.GetDirectoryName(path);

            if (_shadowCopyFolder.FullName.InvariantEquals(binFolder)) {
            }
          }
          else {

            referencedPlugins
                .AddRange(pluginFiles.Select(plug =>
                    new PluginDefinition(plug,
                        GetPackageFolderFromPluginDll(plug),
                        PerformFileDeployAndRegistration(plug, false),
                        plug.Directory.Parent.Name == "Core")));
          }
        }
        catch (UnauthorizedAccessException) {
          //throw the exception if its UnauthorizedAccessException as this will 
          //be because we cannot copy to the shadow copy folder, or update the dashCommerce plugin hash/list files.
          throw;
        }
        catch (Exception ex) {
          var fail = new ApplicationException("Could not initialise plugin folder", ex);
        }

        ReferencedPlugins = referencedPlugins;

      }
    }


    private static void WriteCachePluginsList(IEnumerable<FileInfo> plugins) {
      var sb = new StringBuilder();
      foreach (var f in plugins) {
        sb.AppendLine(f.Name);
      }

      var dir = Directory.CreateDirectory(Path.Combine(_pluginFolder.FullName, "Cache"));
      File.WriteAllText(Path.Combine(dir.FullName, "dashCommerce-plugins.list"), sb.ToString(), Encoding.UTF8);

      //Now, write this file to the shadow copy folder for information purposes. For example, if it is default (~/bin) 
      //then at least people will have a file to reference to look at what has been shadow copied vs what is part
      //of their project.

      File.WriteAllText(Path.Combine(_shadowCopyFolder.FullName, "dashCommerce-plugins-list.txt"),
          "This file lists all of the dashCommerce plugin DLL files that have been shadow copied to this folder.\r\n"
          + sb.ToString(),
          Encoding.UTF8);
    }

    private static Assembly PerformFileDeployAndRegistration(FileInfo plug, bool performShadowCopy) {
      if (plug.Directory.Parent == null)
        throw new InvalidOperationException("The plugin directory for the " + plug.Name +
                                            " file exists in a folder outside of the allowed dashCommerce folder heirarchy");

      FileInfo shadowCopiedPlug;

      Assembly shadowCopiedAssembly;
      if (!IsFullTrust()) {
        shadowCopiedPlug = InitializeMediumTrust(plug, _shadowCopyFolder, performShadowCopy);
        shadowCopiedAssembly = Assembly.Load(AssemblyName.GetAssemblyName(shadowCopiedPlug.FullName));
      }
      else {
        shadowCopiedPlug = InitializeFullTrust(plug, _shadowCopyFolder, performShadowCopy);
        shadowCopiedAssembly = Assembly.Load(AssemblyName.GetAssemblyName(shadowCopiedPlug.FullName));
        if (_shadowCopyType == PluginManagerShadowCopyType.UseDynamicFolder) {
          //add the reference to the build manager if copying to CodeGen
          BuildManager.AddReferencedAssembly(shadowCopiedAssembly);
        }
      }

      return shadowCopiedAssembly;
    }

    private static FileInfo InitializeFullTrust(FileInfo plug, DirectoryInfo shadowCopyPlugFolder, bool performShadowCopy) {
      var shadowCopiedPlug = new FileInfo(Path.Combine(shadowCopyPlugFolder.FullName, plug.Name));
      //if instructed to not perform the copy, just return the path to where it is supposed to be
      if (!performShadowCopy && shadowCopiedPlug.Exists)
        return shadowCopiedPlug;


      try {
        File.Copy(plug.FullName, shadowCopiedPlug.FullName, true);
      }
      catch (UnauthorizedAccessException) {
        throw new UnauthorizedAccessException(string.Format("Access to the path '{0}' is denied, ensure that read, write and modify permissions are allowed.", shadowCopiedPlug.Directory.FullName));
      }
      catch (IOException) {
        //this occurs when the files are locked,
        //for some reason devenv locks plugin files some times and for another crazy reason you are allowed to rename them
        //which releases the lock, so that it what we are doing here, once it's renamed, we can re-shadow copy


        try {
          //If all else fails during the cleanup and we cannot copy over so we need to rename with a GUID
          var dotDeleteFile = GetNewDotDeleteName(shadowCopiedPlug);
          File.Move(shadowCopiedPlug.FullName, dotDeleteFile);
        }
        catch (UnauthorizedAccessException) {
          throw new UnauthorizedAccessException(string.Format("Access to the path '{0}' is denied, ensure that read, write and modify permissions are allowed.", shadowCopiedPlug.Directory.FullName));
        }
        catch (IOException) {
          throw;
        }
        //ok, we've made it this far, now retry the shadow copy
        File.Copy(plug.FullName, shadowCopiedPlug.FullName, true);
      }
      return shadowCopiedPlug;
    }

    private static FileInfo InitializeMediumTrust(FileInfo plug, DirectoryInfo shadowCopyPlugFolder, bool performShadowCopy) {
      var shouldCopy = true;
      var shadowCopiedPlug = new FileInfo(Path.Combine(shadowCopyPlugFolder.FullName, plug.Name));
      //if instructed to not perform the copy, just return the path to where it is supposed to be
      if (!performShadowCopy && shadowCopiedPlug.Exists)
        return shadowCopiedPlug;


      //check if a shadow copied file already exists and if it does, check if its updated, if not don't copy
      if (shadowCopiedPlug.Exists) {
        if (shadowCopiedPlug.CreationTimeUtc.Ticks == plug.CreationTimeUtc.Ticks) {
          shouldCopy = false;
        }
      }

      if (shouldCopy) {
        try {
          File.Copy(plug.FullName, shadowCopiedPlug.FullName, true);
        }
        catch (UnauthorizedAccessException) {
          throw new UnauthorizedAccessException(string.Format("Access to the path '{0}' is denied, ensure that read, write and modify permissions are allowed.", shadowCopiedPlug.Directory.FullName));
        }
        catch (IOException) {
          //this occurs when the files are locked,
          //for some reason devenv locks plugin files some times and for another crazy reason you are allowed to rename them
          //which releases the lock, so that it what we are doing here, once it's renamed, we can re-shadow copy
          try {
            var dotDeleteFile = GetNewDotDeleteName(shadowCopiedPlug);
            File.Move(shadowCopiedPlug.FullName, dotDeleteFile);
          }
          catch (UnauthorizedAccessException) {
            throw new UnauthorizedAccessException(string.Format("Access to the path '{0}' is denied, ensure that read, write and modify permissions are allowed.", shadowCopiedPlug.Directory.FullName));
          }
          catch (IOException) {
            throw;
          }
          try {
            //ok, we've made it this far, now retry the shadow copy
            File.Copy(plug.FullName, shadowCopiedPlug.FullName, true);
          }
          catch (UnauthorizedAccessException) {
            throw new UnauthorizedAccessException(string.Format("Access to the path '{0}' is denied, ensure that read, write and modify permissions are allowed.", shadowCopiedPlug.Directory.FullName));
          }
        }
      }

      return shadowCopiedPlug;
    }

    private static string GetPackageFolderFromPluginDll(FileInfo pluginDll) {
      if (!IsPackageLibFolder(pluginDll.Directory)) {
        throw new DirectoryNotFoundException("The file specified does not exist in the lib folder for a package");
      }
      //we know this folder structure is correct now so return the directory. parent  \bin\..\{PackageName}
      return pluginDll.Directory.Parent.FullName;
    }

    private static bool IsPackageLibFolder(DirectoryInfo folder) {
      if (folder.Name != "lib") return false;
      if (folder.Parent == null) return false;
      return IsPackagePluginFolder(folder.Parent) || (folder.Parent != null && folder.Parent.Name == "Core");
    }

    private static long GetCachePluginsHash() {
      var filePath = Path.Combine(_pluginFolder.FullName, "Cache", "dashCommerce-plugins.hash");
      if (!File.Exists(filePath))
        return 0;
      var hash = File.ReadAllText(filePath, Encoding.UTF8);
      return ConvertPluginsHash(hash);
    }

    internal static bool IsPackagePluginFolder(DirectoryInfo folder) {
      if (folder.Parent == null) return false;
      if (folder.Parent.Name != CUSTOM_PLUGINS) return false;
      return true;
      //return PackageFolderNameHasId(folder.Parent.Name);
    }

    internal static IEnumerable<FileInfo> GetCachePluginsList(DirectoryInfo pluginFolder) {
      var filePath = Path.Combine(pluginFolder.FullName, "Cache", "dashCommerce-plugins.list");
      if (!File.Exists(filePath))
        return new List<FileInfo>();
      var list = new List<FileInfo>();
      var listFile = File.ReadAllText(filePath, Encoding.UTF8);
      var sr = new StringReader(listFile);
      while (true) {
        var f = sr.ReadLine();
        if (f != null && !f.IsNullOrWhiteSpace()) {
          list.Add(new FileInfo(f));
        }
        else {
          break;
        }
      }
      return list;
    }

    internal static long ConvertPluginsHash(string val) {
      long outVal;
      if (Int64.TryParse(val, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out outVal)) {
        return outVal;
      }
      return 0;
    }

    internal static bool CleanupPlugin(FileInfo f) {
      //this is a special case, people may have been usign the CodeGen folder before so we need to cleanup those
      //files too even if we are no longer using it
      if (IsFullTrust() && _shadowCopyType != PluginManagerShadowCopyType.UseDynamicFolder) {
        CleanupDotDeletePluginFiles(new FileInfo(Path.Combine(AppDomain.CurrentDomain.DynamicDirectory, f.Name + ".delete")));
      }

      if (CleanupDotDeletePluginFiles(new FileInfo(f.FullName + ".delete")))
        return true;

      try {
        f.Delete();
        return true;
      }
      catch { }

      //if the file doesn't delete, then create the .delete file for it, hopefully the BuildManager will clean up next time
      var newName = GetNewDotDeleteName(f);

      try {
        File.Move(f.FullName, newName);
      }
      catch (UnauthorizedAccessException) {
        throw new UnauthorizedAccessException(string.Format("Access to the path '{0}' is denied, ensure that read, write and modify permissions are allowed.", Path.GetDirectoryName(newName)));
      }
      catch (IOException) {
        throw;
      }

      //make it an empty file
      try {
        (new StreamWriter(newName)).Close();
      }
      catch { }

      return false;
    }

    private static string GetNewDotDeleteName(FileInfo pluginFile) {
      if (pluginFile.Extension.ToUpper() != ".DLL")
        throw new NotSupportedException("This method only supports DLL files");

      var dotDelete = pluginFile.FullName + ".delete";
      try {
        if (File.Exists(dotDelete))
          File.Delete(dotDelete);
      }
      catch {
        //cannot delete, so we will need to use a GUID
        dotDelete = pluginFile.FullName + Guid.NewGuid().ToString("N") + ".delete";
      }
      return dotDelete;
    }

    internal static bool CleanupDotDeletePluginFiles(FileInfo f) {
      if (f.Extension != ".delete")
        return false;

      var baseFileName = Path.GetDirectoryName(f.FullName) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(f.FullName);
      //NOTE: this is to remove our old GUID named files... we shouldn't have any of these buts sometimes things are just locked
      var base64Files = f.Directory.GetFiles(Path.GetFileName(baseFileName) + "???????????????????????????????????" + ".delete").ToList();
      Func<string, bool> delFile = x => {
            if (x.IsNullOrWhiteSpace())
              return true;
            if (File.Exists(x)) {
              try {
                File.Delete(x);
              }
              catch {
                return false;
              }
            }
            return true;
          };
      //always try deleting old guid named files
      foreach (var x in base64Files)
        delFile(x.FullName);
      //try to delete the .dll file
      if (!delFile(baseFileName))
        return false;

      try {
        //now try to remove the .delete file
        f.Delete();
      }
      catch { }

      return true;
    }

    private static bool DetectAndCleanStalePlugins(IEnumerable<FileInfo> plugins, DirectoryInfo shadowCopyFolder) {
      //NOTE: One other sure fire way to ensure everything is cleaned up is to 'bump' the global.asax file
      // however this will cause a 2nd AppDomain restart, though it will ensure the BuildManager does all the work
      // to cleanup all files in the CodeGen folder.

      //check if anything has been changed, or if we are in debug mode then always perform cleanup
      if (ConvertPluginsHash(GetPluginsHash(plugins)) != GetCachePluginsHash()) {

        //we need to combine the old plugins list with the new ones and clean them out from the shadow copy folder 
        var combinedList = plugins.Concat(GetCachePluginsList(_pluginFolder))
            .Select(x => new FileInfo(Path.Combine(shadowCopyFolder.FullName, x.Name)))
            .DistinctBy(x => x.FullName)
            .ToArray();
        foreach (var f in combinedList) {
          //if that fails, then we will try to remove it the hard way by renaming it to .delete if it doesn't delete nicely
          CleanupPlugin(f);
        }
        return true;
      }

      //no plugin changes found
      return false;
    }

    private static void WriteCachePluginsHash(IEnumerable<FileInfo> plugins) {
      var dir = Directory.CreateDirectory(Path.Combine(_pluginFolder.FullName, "Cache"));
      File.WriteAllText(Path.Combine(dir.FullName, "dashCommerce-plugins.hash"), GetPluginsHash(plugins), Encoding.UTF8);
    }

    internal static string GetPluginsHash(IEnumerable<FileInfo> plugins, bool generateNew = false) {
      if (generateNew || _pluginsHash.IsNullOrWhiteSpace()) {
        var hashCombiner = new HashCodeCombiner();
        //add each unique folder to the hash
        foreach (var i in plugins.Select(x => x.Directory).DistinctBy(x => x.FullName)) {
          hashCombiner.AddFolder(i);
        }
        _pluginsHash = hashCombiner.GetCombinedHashCode();
      }
      return _pluginsHash;
    }

    private static bool IsFullTrust() {
      if (!_isFullTrust.HasValue) {
        _isFullTrust = CoreUtility.GetCurrentTrustLevel() == AspNetHostingPermissionLevel.Unrestricted;
      }
      return _isFullTrust.Value;
    }

  }

  public enum PluginManagerShadowCopyType {
    /// <summary>
    /// Uses the ~/bin folder
    /// </summary>
    Default,

    /// <summary>
    /// Uses the CodeGen folder, only works in Full Trust
    /// </summary>
    UseDynamicFolder,

    /// <summary>
    /// Uses the specified folder in config
    /// </summary>
    OverrideDefaultFolder
  }

}
