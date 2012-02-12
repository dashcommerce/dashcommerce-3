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
