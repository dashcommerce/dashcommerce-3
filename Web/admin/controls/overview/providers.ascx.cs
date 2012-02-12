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