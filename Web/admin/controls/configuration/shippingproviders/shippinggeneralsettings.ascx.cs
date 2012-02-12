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
using System.Web.UI;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Core.Caching;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Services.ShippingService;
using MettleSystems.dashCommerce.Store.Web.Controls;

namespace MettleSystems.dashCommerce.Web.admin.controls.configuration.shippingproviders {
  public partial class shippinggeneralsettings : ShippingConfigurationControl {

    #region Member Variables
    
    ShippingServiceSettings shippingServiceSettings;
    
    #endregion
    
    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        SetShippingGeneralSettingsProperties();
        shippingServiceSettings = ShippingService.FetchConfiguredShippingProviders();
        if(shippingServiceSettings == null) {
          shippingServiceSettings = new ShippingServiceSettings();
        }
        if(!Page.IsPostBack) {
          LoadCountries();
          chkUseShipping.Checked = shippingServiceSettings.UseShipping;
          txtShipFromZip.Text = shippingServiceSettings.ShipFromZip;
          ddlShipFromCountry.SelectedValue = shippingServiceSettings.ShipFromCountryCode;
          txtShippingBuffer.Text = StoreUtility.GetFormattedAmount(shippingServiceSettings.ShippingBuffer, false);
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(shippinggeneralsettings).Name + ".Page_Load", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e) {
      try {
        shippingServiceSettings.UseShipping = chkUseShipping.Checked;
        shippingServiceSettings.ShipFromZip = txtShipFromZip.Text.Trim();
        shippingServiceSettings.ShipFromCountryCode = ddlShipFromCountry.SelectedValue;
        decimal buffer = 0.00M;
        decimal.TryParse(txtShippingBuffer.Text.Trim(), out buffer);
        shippingServiceSettings.ShippingBuffer = buffer;
        int id = base.Save(shippingServiceSettings, WebUtility.GetUserName());
        if(id > 0) {
          MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblShippingSettingsSaved"));
        }
        else {
          MasterPage.MessageCenter.DisplayFailureMessage(LocalizationUtility.GetText("lblShippingSettingsNotSaved"));
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(shippinggeneralsettings).Name + ".btnSave_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }     
    }
    
    #endregion
    
    #region Methods
    
    #region Private

    /// <summary>
    /// Loads the countries.
    /// </summary>
    private void LoadCountries() {
      CountryCollection countryCollection = new CountryController().FetchAll().OrderByAsc("Name");
      ddlShipFromCountry.DataSource = countryCollection;
      ddlShipFromCountry.DataValueField = "Code";
      ddlShipFromCountry.DataTextField = "Name";
      ddlShipFromCountry.DataBind();
    }

    /// <summary>
    /// Sets the shipping general settings properties.
    /// </summary>
    private void SetShippingGeneralSettingsProperties() {
      lblShippingBufferCurrencySymbol.Text = SiteSettingCache.GetSiteSettings().CurrencySymbol;
    }
    
    #endregion
    
    #endregion
    
  }
}
