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
using System.Web.UI;

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.install {
  public partial class install : System.Web.UI.Page {

    #region Member Variables

    private int step = 0;

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the PreInit event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_PreInit(object sender, EventArgs e) {
      //set the theme for the install
      this.Page.Theme = "dashCommerce";
    }

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        step = Utility.GetIntParameter("step");
        Control installControl = null;
        switch(step) {
          case 0:
            installControl = Page.LoadControl("~/install/controls/welcome.ascx");
            Page.Title = LocalizationUtility.GetText("titleInstallWelcome");
            break;
          case 1:
            installControl = Page.LoadControl("~/install/controls/license.ascx");
            Page.Title = LocalizationUtility.GetText("titleInstallLicense");
            break;
          case 2:
            installControl = Page.LoadControl("~/install/controls/database.ascx");
            Page.Title = LocalizationUtility.GetText("titleInstallDatabase");
            break;
          //case 3:
          //  installControl = Page.LoadControl("~/install/controls/connectionstring.ascx");
          //  Page.Title = LocalizationUtility.GetText("titleInstallConnectionString");            
          //  break;
          case 3:
            installControl = Page.LoadControl("~/install/controls/versioncheck.ascx");
            Page.Title = LocalizationUtility.GetText("titleInstallVersionCheck");
            break;
          case 4:
            installControl = Page.LoadControl("~/install/controls/membership.ascx");
            Page.Title = LocalizationUtility.GetText("titleInstallAdministrator");            
            break;
          case 5:
            installControl = Page.LoadControl("~/install/controls/permissions.ascx");
            Page.Title = LocalizationUtility.GetText("titleInstallPermissions");
            break;
          case 6:
            installControl = Page.LoadControl("~/install/controls/complete.ascx");
            Page.Title = LocalizationUtility.GetText("titleInstallComplete");            
            break;
        }

        pnlInstall.Controls.Clear();
        pnlInstall.Controls.Add(installControl);
      }
      catch(Exception ex) {
        Logger.Error(typeof(install).Name + ".Page_Load", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }

    }

    #endregion


  }
}
