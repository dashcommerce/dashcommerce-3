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

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Core.Caching;
using MettleSystems.dashCommerce.Core.Configuration;
using MettleSystems.dashCommerce.Store.Services;
using MettleSystems.dashCommerce.Store.Services.PaymentService;

namespace MettleSystems.dashCommerce.Web.admin {
  public partial class paymentserviceconfiguration : MettleSystems.dashCommerce.Store.Web.AdminPage {

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e) {
      try {
        PaymentServiceSettings paymentServiceSettings = new PaymentServiceSettings();
        ProviderSettings settings = new ProviderSettings();
        settings.Name = typeof(PayPalProPaymentProvider).Name;
        settings.Type = typeof(PayPalProPaymentProvider).AssemblyQualifiedName;
        settings.Parameters.Add("ApiUserName", "username");
        settings.Parameters.Add("ApiPassword", "password");
        settings.Parameters.Add("Signature", "signature");
        settings.Parameters.Add("IsLive", "false");
        paymentServiceSettings.ProviderSettingsCollection.Add(settings);
        DatabaseConfigurationProvider config = new DatabaseConfigurationProvider();
        config.SaveConfiguration(PaymentServiceSettings.SECTION_NAME, paymentServiceSettings, WebUtility.GetUserName());
        SiteSettingCache.RemoveSiteSettingsFromCache();
      }
      catch (Exception ex) {
        Logger.Error(typeof(paymentserviceconfiguration).Name + ".Page_Load", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    #endregion

  }
}
