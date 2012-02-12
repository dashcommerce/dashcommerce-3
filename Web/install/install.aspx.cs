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
