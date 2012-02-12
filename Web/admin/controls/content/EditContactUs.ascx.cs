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
using MettleSystems.dashCommerce.Content;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Core.Caching;
using MettleSystems.dashCommerce.Core.Configuration;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Caching;
using MettleSystems.dashCommerce.Store.Web;

namespace MettleSystems.dashCommerce.Web.admin.controls.content {
  public partial class EditContactUs : ProviderControl {
    MailSettings mailSettings = MessagingCache.GetMailSettings();

    protected void Page_Load(object sender, EventArgs e) {
      txtEmail.Text = mailSettings.Contact;

      
      
      
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e) {
      try {
        mailSettings.Contact = txtEmail.Text.Trim();

        DatabaseConfigurationProvider databaseConfigurationProvider = new DatabaseConfigurationProvider();
        int id = databaseConfigurationProvider.SaveConfiguration(MailSettings.SECTION_NAME, mailSettings, WebUtility.GetUserName());
        SiteSettingCache.RemoveSiteSettingsFromCache();
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

    #region Properties

    /// <summary>
    /// Gets the master page.
    /// </summary>
    /// <value>The master page.</value>
    public AdminMasterPage Master {
      get {
        return this.Page.Master as AdminMasterPage;
      }
    }

    #endregion
  }
}