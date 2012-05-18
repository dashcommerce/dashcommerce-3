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

using MettleSystems.dashCommerce.Localization;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin.controls.overview {
  public partial class providers : System.Web.UI.UserControl {
  
    #region Member Variables
  
    string view = string.Empty;
    
    #endregion
    
    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      view = Utility.GetParameter("view");
      
      string label = string.Empty;
      switch(view) {
        case "pc":
          label = LocalizationUtility.GetText("lblPaymentName");
          hlGeneralSettings.NavigateUrl = "~/admin/paymentsettings.aspx";
          hlConfigureProviders.NavigateUrl = "~/admin/paymentconfiguration.aspx";
          hlManageProviders.NavigateUrl = "~/admin/paymentprovidermanagement.aspx";
          break;
        case "tc":
          label = LocalizationUtility.GetText("lblTaxName");
          hlGeneralSettings.NavigateUrl = "~/admin/taxsettings.aspx";
          hlConfigureProviders.NavigateUrl = "~/admin/taxconfiguration.aspx";
          hlManageProviders.NavigateUrl = "~/admin/taxprovidermanagement.aspx";
          break;
        case "sc":
          label = LocalizationUtility.GetText("lblShippingName");
          hlGeneralSettings.NavigateUrl = "~/admin/shippingsettings.aspx";
          hlConfigureProviders.NavigateUrl = "~/admin/shippingconfiguration.aspx";
          hlManageProviders.NavigateUrl = "~/admin/shippingprovidermanagement.aspx";
          break;
        default:
          label = LocalizationUtility.GetText("lblPaymentName");
          hlGeneralSettings.NavigateUrl = "~/admin/paymentsettings.aspx";
          hlConfigureProviders.NavigateUrl = "~/admin/paymentconfiguration.aspx";
          hlManageProviders.NavigateUrl = "~/admin/paymentprovidermanagement.aspx";
          break;
      }
      SetProvidersProperties(label);
    }
    
    #endregion

    #region Methods
    
    #region Private
    
    /// <summary>
    /// Sets the providers properties.
    /// </summary>
    /// <param name="label">The label.</param>
    private void SetProvidersProperties(string label) {
      pnlConfiguration.GroupingText = string.Format(LocalizationUtility.GetText("pnlConfiguration"), label);
      hlGeneralSettings.Text = string.Format(LocalizationUtility.GetText("hlGeneralSettings"), label);
      lblGeneralSettingsDescription.Text = string.Format(LocalizationUtility.GetText("lblGeneralSettingsDescription"), label.ToLower(), label);
      hlConfigureProviders.Text = string.Format(LocalizationUtility.GetText("hlConfigureProviders"), label);
      lblConfigureProvidersDescription.Text = string.Format(LocalizationUtility.GetText("lblConfigureProvidersDescription"), label.ToLower(), label);
      hlManageProviders.Text = string.Format(LocalizationUtility.GetText("hlManageProviders"), label);
      lblManageProvidersDescription.Text = string.Format(LocalizationUtility.GetText("lblManageProvidersDescription"), label.ToLower(), label);
    }
    
    #endregion
    
    #endregion
    
  }
}