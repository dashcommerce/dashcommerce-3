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
using System.Web.UI.WebControls;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Caching;
using MettleSystems.dashCommerce.Store.Services.MessageService;

namespace MettleSystems.dashCommerce.Web {
  public partial class passwordrecover : MettleSystems.dashCommerce.Store.Web.SitePage {

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      SetPasswordRecoverControlProperties();
      MailSettings mailSettings = MessagingCache.GetMailSettings();
      MailDefinition mailDefinition = prPasswordRecover.MailDefinition;
      mailDefinition.From = mailSettings.From;
    }

    /// <summary>
    /// Handles the SendingMail event of the prPasswordRecover control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.MailMessageEventArgs"/> instance containing the event data.</param>
    protected void prPasswordRecover_SendingMail(object sender, MailMessageEventArgs e) {
      try {
        MessageService messageService = new MessageService();
        messageService.Send(e.Message);
        e.Cancel = true;
      }
      catch(Exception ex) {
        Logger.Error("prPasswordRecover_SendingMail " + e.Message.To[0].Address , ex);
      }
    }

    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Sets the password recover control properties.
    /// </summary>
    private void SetPasswordRecoverControlProperties() {
      prPasswordRecover.UserNameTitleText = LocalizationUtility.GetText("prPasswordRecoverUserNameTitleText");
      prPasswordRecover.UserNameInstructionText = LocalizationUtility.GetText("prPasswordRecoverUserNameInstructionText");
      prPasswordRecover.UserNameLabelText = LocalizationUtility.GetText("prPasswordRecoverUserNameLabelText");
      prPasswordRecover.UserNameFailureText = LocalizationUtility.GetText("prPasswordRecoverUserNameFailureText");
      prPasswordRecover.QuestionTitleText = LocalizationUtility.GetText("prPasswordRecoverQuestionTitleText");
      prPasswordRecover.QuestionInstructionText = LocalizationUtility.GetText("prPasswordRecoverQuestionInstructionText");
      prPasswordRecover.QuestionLabelText = LocalizationUtility.GetText("prPasswordRecoverQuestionLabelText");
      prPasswordRecover.QuestionFailureText = LocalizationUtility.GetText("prPasswordRecoverQuestionFailureText");
      prPasswordRecover.AnswerLabelText = LocalizationUtility.GetText("prPasswordRecoverAnswerLabelText");
      prPasswordRecover.SubmitButtonText = LocalizationUtility.GetText("prPasswordRecoverSubmitButtonText");
      prPasswordRecover.SuccessText = LocalizationUtility.GetText("prPasswordRecoverSuccessText");
    }

    #endregion

    #endregion

  }
}
