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
