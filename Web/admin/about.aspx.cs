#region dashCommerce License
/*
dashCommerce® is Copyright © 2008-2012 Mettle Systems LLC. All Rights Reserved.


dashCommerce, and the dashCommerce logo are registered trademarks of Mettle Systems LLC. Mettle Systems LLC logos and trademarks may not be used without prior written consent.

dashCommerce is licensed under the following license. If you do not accept the terms, please discontinue the use of dashCommerce and uninstall dashCommerce. 

Your license to the dashCommerce source and/or binaries is governed by the Reciprocal Public License 1.5 (RPL1.5) license as described here: 

http://www.opensource.org/licenses/rpl1.5.txt 

If you do not wish to release the source of software you build using dashCommerce, you may purchase a site license, which will allow you to deploy dashCommerce for use in 1 web store defined as using 1 URL. You may purchase a site license here: 

http://www.dashcommerce.org/license.html 
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
