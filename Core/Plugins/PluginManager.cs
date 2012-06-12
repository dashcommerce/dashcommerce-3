using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using System.Web.Util;
using MettleSystems.dashCommerce.Core.Plugins;

[assembly: PreApplicationStartMethod(typeof(PluginManager), "Initialize")]
namespace MettleSystems.dashCommerce.Core.Plugins {

  public class PluginManager {

    private static readonly ReaderWriterLockSlim Locker = new ReaderWriterLockSlim();
    private static DirectoryInfo shadowCopyFolder;
    private static bool? isFullTrust;
    private static DirectoryInfo pluginFolder;
    private static PluginManagerShadowCopyType pluginManagerShadowCopyType;
    public const string CUSTOM_PLUGINS = "CustomPlugins";
    private static string _pluginsHash;

    public static void Initialize() {
      using (new WriteLockDisposable(Locker)) {
        var pluginPath = HostingEnvironment.MapPath("~/App_Plugins");
        pluginFolder = new DirectoryInfo(pluginPath);

        //Default to the bin directory
        shadowCopyFolder = new DirectoryInfo(HostingEnvironment.MapPath("~/bin"));

        if (pluginManagerShadowCopyType == PluginManagerShadowCopyType.OverrideDefaultFolder) {
          var shadowCopyPath = HostingEnvironment.MapPath("~/App_Plugins/bin");
          shadowCopyFolder = new DirectoryInfo(shadowCopyPath);
        }
        else if (IsFullTrust() && pluginManagerShadowCopyType == PluginManagerShadowCopyType.UseDynamicFolder) {
          shadowCopyFolder = new DirectoryInfo(AppDomain.CurrentDomain.DynamicDirectory);
        }

        var pluginFiles = Enumerable.Empty<FileInfo>();

        try {
          Directory.CreateDirectory(pluginFolder.FullName);
          if (pluginManagerShadowCopyType != PluginManagerShadowCopyType.UseDynamicFolder) {
            Directory.CreateDirectory(shadowCopyFolder.FullName);
          }
          Directory.CreateDirectory(Path.Combine(pluginFolder.FullName, CUSTOM_PLUGINS));

          pluginFiles = pluginFolder.GetFiles("*.dll", SearchOption.AllDirectories)
            .ToArray()
            .Where(x => x.Directory.Parent != null)
            .ToList();


        }
        catch (Exception ex) {
          Logger.LogException("Failed to load plugins.", ex, Logger.LogMessageType.Error);
        }

      }
    }

    private static long GetCachePluginsHash() {
      var filePath = Path.Combine(pluginFolder.FullName, "Cache", "dashCommerce-plugins.hash");
      if (!File.Exists(filePath))
        return 0;
      var hash = File.ReadAllText(filePath, Encoding.UTF8);
      return ConvertPluginsHash(hash);
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
      //LogHelper.TraceIfEnabled<PluginManager>("Cleaning up stale plugin " + f.FullName);

      //this is a special case, people may have been usign the CodeGen folder before so we need to cleanup those
      //files too even if we are no longer using it
      if (IsFullTrust() && pluginManagerShadowCopyType != PluginManagerShadowCopyType.UseDynamicFolder) {
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
       // LogHelper.TraceIfEnabled<PluginManager>(f.FullName + " rename failed, cannot remove stale plugin");
        throw;
      }

      //make it an empty file
      try {
        (new StreamWriter(newName)).Close();
      }
      catch { }

      //LogHelper.TraceIfEnabled<PluginManager>("Stale plugin " + f.FullName + " failed to cleanup successfully, a .delete file has been created for it");
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
        //LogHelper.TraceIfEnabled<PluginManager>("Cannot remove file " + dotDelete + " it is locked, renaming to .delete file with GUID");
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
        //LogHelper.TraceIfEnabled<PluginManager>("Plugin changes detected in hash");

        //we need to combine the old plugins list with the new ones and clean them out from the shadow copy folder 
        var combinedList = plugins.Concat(GetCachePluginsList(pluginFolder))
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
      var dir = Directory.CreateDirectory(Path.Combine(pluginFolder.FullName, "Cache"));
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
      if (!isFullTrust.HasValue) {
        isFullTrust = CoreUtility.GetCurrentTrustLevel() == AspNetHostingPermissionLevel.Unrestricted;
      }
      return isFullTrust.Value;
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
