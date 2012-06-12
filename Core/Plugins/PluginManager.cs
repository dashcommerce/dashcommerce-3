using System;
using System.Collections.Generic;
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
