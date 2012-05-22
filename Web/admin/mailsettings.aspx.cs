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
using System.Net.Mail;
using System.Web.UI;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Core.Configuration;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Caching;

namespace MettleSystems.dashCommerce.Web.admin {
  public partial class mailconfiguration : MettleSystems.dashCommerce.Store.Web.AdminPage {

    #region Member Variables

    private MailSettings mailSettings;

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        SetMailSettingsProperties();
        mailSettings = MailSettings.Load();
        if (!Page.IsPostBack) {
          if (mailSettings != null) {
            txtFrom.Text = mailSettings.From;
            txtHost.Text = mailSettings.Host;
            chkRequireAuthentication.Checked = mailSettings.RequireAuthentication;
            txtUserName.Text = mailSettings.UserName;
            txtPassword.Text = mailSettings.Password;
            chkRequireSsl.Checked = mailSettings.RequireSsl;
            txtPort.Text = mailSettings.Port.ToString();
          }
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(mailconfiguration).Name + ".Page_Load", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e) {
      try {
        if (mailSettings == null) {
          mailSettings = new MailSettings();
        }
        mailSettings.From = txtFrom.Text.Trim();
        mailSettings.Host = txtHost.Text.Trim();
        mailSettings.RequireAuthentication = chkRequireAuthentication.Checked;
        mailSettings.UserName = txtUserName.Text.Trim();
        mailSettings.Password = txtPassword.Text.Trim();
        int port = 25;
        bool isParsed = int.TryParse(txtPort.Text.Trim(), out port);
        mailSettings.Port = (isParsed) ? port : 25;
        mailSettings.RequireSsl = chkRequireSsl.Checked;

        DatabaseConfigurationProvider databaseConfigurationProvider = new DatabaseConfigurationProvider();
        int id = databaseConfigurationProvider.SaveConfiguration(MailSettings.SECTION_NAME, mailSettings, WebUtility.GetUserName());
        MessagingCache.RemoveMailSettings();
        if (id > 0) {
          Master.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblMailSettingsSaved"));
        }
        else {
          Master.MessageCenter.DisplayFailureMessage(LocalizationUtility.GetText("lblMailSettingsNotSaved"));
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(mailconfiguration).Name + ".btnSave_Click", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Send a test email and reports if sucessfull
    /// </summary>
    protected void btnTestSmtp_Click(object sender, EventArgs e) {
      try {
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(txtFrom.Text.Trim());
        mail.To.Add(txtFrom.Text.Trim());
        mail.Subject = "Test mail from " + txtFrom.Text.Trim();
        mail.Body = "Success";
        SmtpClient smtp = new SmtpClient(txtHost.Text.Trim());
        smtp.Credentials = new System.Net.NetworkCredential(txtUserName.Text.Trim(), txtPassword.Text.Trim());
        smtp.EnableSsl = chkRequireSsl.Checked;
        int port = 25;
        bool isParsed = int.TryParse(txtPort.Text.Trim(), out port);
        smtp.Port = (isParsed) ? port : 25;
        smtp.Send(mail);
        Master.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblMailSettingsTestSucessfull"));
      } catch {
        Master.MessageCenter.DisplayCriticalMessage(LocalizationUtility.GetText("lblMailSettingsTestFailed"));
      }
    }

    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Sets the mail settings properties.
    /// </summary>
    private void SetMailSettingsProperties() {
      this.Title = LocalizationUtility.GetText("titleMailSettings");
    }

    #endregion

    #endregion

  }
}
