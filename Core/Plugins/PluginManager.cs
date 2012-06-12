using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using MettleSystems.dashCommerce.Core.Plugins;

[assembly: PreApplicationStartMethod(typeof(PluginManager), "Initialize")]
namespace MettleSystems.dashCommerce.Core.Plugins {
  
  public class PluginManager {

    private static readonly ReaderWriterLockSlim Locker = new ReaderWriterLockSlim();
    private static DirectoryInfo shadowCopyFolder;
    private static bool? isFullTrust;
    private static DirectoryInfo pluginFolder;

    public static void Initialize() {
      using (new WriteLockDisposable(Locker)) {
        var pluginPath = HostingEnvironment.MapPath("~/App_Plugins");
        pluginFolder = new DirectoryInfo(pluginPath);

        /* 
         * 
         * may need to add in shadowcopy stuff here
         * 
         */

        var pluginFiles = Enumerable.Empty<FileInfo>();
        try {
          pluginFiles = pluginFolder.GetFiles("*.dll", SearchOption.AllDirectories)
            .ToArray()
            .Where(x => x.Directory.Parent != null)
            .ToList();

          Console.WriteLine(pluginFiles.ToString());
          
        }
        catch (Exception ex) {
          Logger.LogException("Failed to load plugin", ex, Logger.LogMessageType.Error);
        }

      }
    }

  }
}
