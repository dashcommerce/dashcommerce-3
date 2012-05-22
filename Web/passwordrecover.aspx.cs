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
