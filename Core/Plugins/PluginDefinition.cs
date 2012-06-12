using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MettleSystems.dashCommerce.Core.Plugins {

  public class PluginDefinition {
    public PluginDefinition(
        FileInfo originalAssembly,
        string packageFolderPath,
        Assembly shadowCopied,
        bool isCorePlugin) {
      ReferencedAssembly = shadowCopied;
      IsCorePlugin = isCorePlugin;
      OriginalAssemblyFile = originalAssembly;
      PackageFolderPath = packageFolderPath;
    }

    /// <summary>
    /// The assembly that has been shadow copied that is active in the application
    /// </summary>
    public Assembly ReferencedAssembly { get; internal set; }

    /// <summary>
    /// True if the plugin is a core plugin
    /// </summary>
    public bool IsCorePlugin { get; private set; }

    /// <summary>
    /// The package folder name
    /// </summary>
    public string PackageName {
      get {
        return Path.GetFileName(PackageFolderPath);
      }
    }

    /// <summary>
    /// The original assembly file that a shadow copy was made from it
    /// </summary>
    public FileInfo OriginalAssemblyFile { get; private set; }

    public string PackageFolderPath { get; private set; }

  }
}
