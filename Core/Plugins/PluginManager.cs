using System;
using System.Threading;
using System.Web;

using MettleSystems.dashCommerce.Core.Plugins;

[assembly: PreApplicationStartMethod(typeof(PluginManager), "Initialize")]
namespace MettleSystems.dashCommerce.Core.Plugins {
  
  public class PluginManager {

    private static readonly ReaderWriterLockSlim Locker = new ReaderWriterLockSlim();

    public static void Initialize() {
      using (new WriteLockDisposable(Locker)) { 
        
      }
    }

  }
}
