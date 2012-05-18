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