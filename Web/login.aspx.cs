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
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using MettleSystems.dashCommerce.Localization;

namespace MettleSystems.dashCommerce.Web {
  public partial class login : MettleSystems.dashCommerce.Store.Web.SitePage {

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      Button btnLogin = llogin.FindControl("LoginButton") as Button;
      if (btnLogin != null)
        Page.Form.DefaultButton = btnLogin.UniqueID;

      SetLoginControlProperties();
    }

    #endregion

    #region Methods

    #region Protected

    /// <summary>
    /// Sets the cookie.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void SetCookie(object sender, EventArgs e) {
      if (Membership.ValidateUser(llogin.UserName, llogin.Password)) {
        FormsAuthentication.SetAuthCookie(llogin.UserName, ((CheckBox)llogin.FindControl("RememberMe")).Checked);
      }
    }

    #endregion

    #region Private

    /// <summary>
    /// Sets the login control properties.
    /// </summary>
    private void SetLoginControlProperties() {
      this.Title = string.Format(WebUtility.MainTitleTemplate, Master.SiteSettings.SiteName, LocalizationUtility.GetText("titleLogin"));
      llogin.UserNameLabelText = LocalizationUtility.GetText("lloginUserNameLabelText");
      llogin.PasswordLabelText = LocalizationUtility.GetText("lloginPasswordLabelText");
      llogin.TitleText = LocalizationUtility.GetText("lloginTitleText");
      llogin.PasswordRecoveryText = LocalizationUtility.GetText("lloginPasswordRecoveryText");
      llogin.CreateUserText = LocalizationUtility.GetText("lloginCreateUserText");
    }

    #endregion

    #endregion

  }
}
