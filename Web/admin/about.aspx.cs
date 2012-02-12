#region dashCommerce License
/*
The MIT License

Copyright (c) 2008 - 2010 Mettle Systems LLC, P.O. Box 181192 Cleveland Heights, Ohio 44118, United States

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
#endregion
using System;
using System.IO;
using System.Reflection;

using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store.Web;
using System.Security.Permissions;

namespace MettleSystems.dashCommerce.Web.admin {
  public partial class about : AdminPage {

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      lblVersion.Text = string.Format(LocalizationUtility.GetText("lblVersionNumber"), System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
      txtLicenseAgreement.Text = File.ReadAllText(Server.MapPath("~/license.txt"));
      this.Title = LocalizationUtility.GetText("titleAbout");
      BindAssemblies();
    }


    #endregion 

    #region Methods

    #region Private

    /// <summary>
    /// Gets the application assemblies.
    /// </summary>
    /// <returns></returns>
    private Assembly[] GetApplicationAssemblies() {
      string[] files = Directory.GetFiles(Server.MapPath("~/bin"), "*.dll");
      Assembly[] assemblies = new Assembly[files.Length];
      for (int i = 0; i < files.Length; i++) {
        assemblies[i] = Assembly.ReflectionOnlyLoadFrom(files[i]);
      }
      return assemblies;
    }

    private void BindAssemblies() {
      try {
        Assembly[] assemblies = GetApplicationAssemblies();
        dgAssemblies.DataSource = assemblies;
        dgAssemblies.Columns[0].HeaderText = LocalizationUtility.GetText("lblAssemblies");
        dgAssemblies.DataBind();
      }
      catch (TargetInvocationException) {
        //swallow it - probably running in Medium Trust
        lblAssembliesTitle.Visible = false;
        dgAssemblies.Visible = false;
      }
      catch (Exception) {
        //nuthin' to see here, move along.
        lblAssembliesTitle.Visible = false;
        dgAssemblies.Visible = false;
      }
    }


    #endregion

    #endregion

  }
}
