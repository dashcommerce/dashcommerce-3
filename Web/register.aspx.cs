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

using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;

namespace MettleSystems.dashCommerce.Web {
  public partial class register : MettleSystems.dashCommerce.Store.Web.SitePage {

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      SetRegisterControlProperties();
      int orderItemCount = new OrderController().GetItemCountInOrder(WebUtility.GetUserName());
      if (orderItemCount > 0) {
        lblBeforeRegisterUserName.Text = WebUtility.GetUserName();
      }
    }

    /// <summary>
    /// Createds the user.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void CreatedUser(object sender, EventArgs e) {
      Roles.AddUserToRole(cuwRegister.UserName, "Registered User");
      if (!string.IsNullOrEmpty(lblBeforeRegisterUserName.Text)) {
        OrderController.MigrateCart(lblBeforeRegisterUserName.Text, cuwRegister.UserName);
      }
    }

    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Sets the register control properties.
    /// </summary>
    private void SetRegisterControlProperties() {
      this.Title = string.Format(WebUtility.MainTitleTemplate, Master.SiteSettings.SiteName, LocalizationUtility.GetText("titleRegister"));
      cuwRegister.UserNameLabelText = LocalizationUtility.GetText("cuwRegisterUserNameLabelText");
      cuwRegister.PasswordLabelText = LocalizationUtility.GetText("cuwRegisterPasswordLabelText");
      cuwRegister.ConfirmPasswordLabelText = LocalizationUtility.GetText("cuwRegisterConfirmPasswordLabelText");
      cuwRegister.EmailLabelText = LocalizationUtility.GetText("cuwRegisterEmailLabelText");
      cuwRegister.QuestionLabelText = LocalizationUtility.GetText("cuwRegisterQuestionLabelText");
      cuwRegister.AnswerLabelText = LocalizationUtility.GetText("cuwRegisterAnswerLabelText");
      cuwRegister.CreateUserButtonText = LocalizationUtility.GetText("cuwRegisterCreateUserButtonText");
      cuwRegister.CompleteSuccessText = LocalizationUtility.GetText("cuwRegisterCompleteSuccessText");
      cuwRegister.FinishCompleteButtonText = LocalizationUtility.GetText("cuwRegisterFinishCompleteButtonText");
      cuwRegister.CreateUserStep.Title = LocalizationUtility.GetText("cuwRegisterCreateUserStepTitle");
      cuwRegister.CompleteStep.Title = LocalizationUtility.GetText("cuwRegisterCompleteStepTitle");
    }

    #endregion

    #endregion

  }
}
