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
using System.Web.UI;
using System.Web.UI.WebControls;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Services;
using MettleSystems.dashCommerce.Store.Services.PaymentService;
using MettleSystems.dashCommerce.Store.Services.ShippingService;
using MettleSystems.dashCommerce.Store.Services.TaxService;
using MettleSystems.dashCommerce.Store.Web.Controls;

namespace MettleSystems.dashCommerce.Web.admin.controls.configuration {
  public partial class providersettings : AdminControl {

    #region Member Variables

    private ProviderType _providerType;
    private string defaultProviderName = string.Empty;

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        SetProviderSettingsProperties();
        if(!Page.IsPostBack) {
          SetConfiguredProviders();
        }
      }
      catch(Exception ex) {
        pnlConfiguredProviders.Visible = false;
        Logger.Error(typeof(providersettings).Name + ".Page_Load", ex);
        MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnSetDefaultProvider control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnSetDefaultProvider_Click(object sender, EventArgs e) {
      try {
        switch(this.ProviderType) {
          case ProviderType.PaymentProvider:
            SetDefaultPaymentProvider();
            break;
          case ProviderType.ShippingProvider:
            SetDefaultShippingProvider();
            break;
          case ProviderType.TaxProvider:
            SetDefaultTaxProvider();
            break;
        }
        SetConfiguredProviders();
      }
      catch(Exception ex) {
        Logger.Error(typeof(providersettings).Name + ".btnSetDefaultProvider_Click", ex);
        MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnRemoveProvider control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnRemoveProvider_Click(object sender, EventArgs e) {
      try {
        switch(this.ProviderType) {
          case ProviderType.PaymentProvider:
            RemovePaymentProvider();
            break;
          case ProviderType.ShippingProvider:
            RemoveShippingProvider();
            break;
          case ProviderType.TaxProvider:
            RemoveTaxProvider();
            break;
        }
        SetConfiguredProviders();
      }
      catch(Exception ex) {
        try {
          SetConfiguredProviders();
        }
        catch(Exception exe) {
          Logger.Error(typeof(providersettings).Name + ".btnRemoveProvider_Click", exe);
        }
        Logger.Error(typeof(providersettings).Name + ".btnRemoveProvider_Click", ex);
        MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Sets the provider settings properties.
    /// </summary>
    private void SetProviderSettingsProperties() {
      
      
      
      switch(this.ProviderType) {
        case ProviderType.PaymentProvider:
          pnlConfiguredProviders.GroupingText = LocalizationUtility.GetText("pnlConfiguredPaymentProviders");
          lblProviderSettings.Text = LocalizationUtility.GetText("lblGeneralPaymentSettings");
          break;
        case ProviderType.ShippingProvider:
          pnlConfiguredProviders.GroupingText = LocalizationUtility.GetText("pnlConfiguredShippingProviders");
          lblProviderSettings.Text = LocalizationUtility.GetText("lblGeneralShippingSettings");
          break;
        case ProviderType.TaxProvider:
          pnlConfiguredProviders.GroupingText = LocalizationUtility.GetText("pnlConfiguredTaxProviders");
          lblProviderSettings.Text = LocalizationUtility.GetText("lblGeneralTaxSettings");
          break;
      }
    }

    /// <summary>
    /// Sets the configured providers.
    /// </summary>
    private void SetConfiguredProviders() {
      switch(this.ProviderType) {
        case ProviderType.PaymentProvider:
          LoadConfiguredPaymentProviders();
          break;
        case ProviderType.ShippingProvider:
          dcShippingGeneralSettings.Visible = true;
          LoadConfiguredShippingProviders();
          break;
        case ProviderType.TaxProvider:
          LoadConfiguredTaxProviders();
          break;
      }
      if(rblConfiguredProviders.Items.Count == 0) {
        pnlConfiguredProviders.Visible = false;
        MasterPage.MessageCenter.DisplayInformationMessage(SetNoProvidersConfiguredMessage());
      }
    }

    /// <summary>
    /// Sets the no providers configured message.
    /// </summary>
    /// <returns></returns>
    private string SetNoProvidersConfiguredMessage() {
      string message = string.Empty;
      switch(this.ProviderType) {
        case ProviderType.PaymentProvider:
          message = LocalizationUtility.GetText("lblNoPaymentProvidersConfigured");
          break;
        case ProviderType.ShippingProvider:
          message = LocalizationUtility.GetText("lblNoShippingProvidersConfigured");
          break;
        case ProviderType.TaxProvider:
          message = LocalizationUtility.GetText("lblNoTaxProvidersConfigured");
          break;
      }
      return message;
    }

    /// <summary>
    /// Loads the configured payment providers.
    /// </summary>
    private void LoadConfiguredPaymentProviders() {
      PaymentServiceSettings paymentServiceSettings = PaymentService.FetchConfiguredPaymentProviders();
      rblConfiguredProviders.Items.Clear();
      if(paymentServiceSettings != null) {
        foreach(ProviderSettings providerSettings in paymentServiceSettings.ProviderSettingsCollection) {
          rblConfiguredProviders.Items.Add(new ListItem(providerSettings.Name, providerSettings.Name));
        }
        if(!string.IsNullOrEmpty(paymentServiceSettings.DefaultProvider)) {
          rblConfiguredProviders.SelectedValue = paymentServiceSettings.DefaultProvider;
          rblConfiguredProviders.SelectedItem.Attributes.Add("class", "defaultProvider");
          defaultProviderName = paymentServiceSettings.DefaultProvider;
        }
      }
    }

    /// <summary>
    /// Loads the configured tax providers.
    /// </summary>
    private void LoadConfiguredShippingProviders() {
      ShippingServiceSettings shippingServiceSettings = ShippingService.FetchConfiguredShippingProviders();
      rblConfiguredProviders.Items.Clear();
      if(shippingServiceSettings != null) {
        foreach(ProviderSettings providerSettings in shippingServiceSettings.ProviderSettingsCollection) {
          rblConfiguredProviders.Items.Add(new ListItem(providerSettings.Name, providerSettings.Name));
        }
        if(!string.IsNullOrEmpty(shippingServiceSettings.DefaultProvider)) {
          rblConfiguredProviders.SelectedValue = shippingServiceSettings.DefaultProvider;
          rblConfiguredProviders.SelectedItem.Attributes.Add("class", "defaultProvider");
          defaultProviderName = shippingServiceSettings.DefaultProvider;
        }
      }
    }

    /// <summary>
    /// Loads the configured shipping providers.
    /// </summary>
    private void LoadConfiguredTaxProviders() {
      TaxServiceSettings taxServiceSettings = TaxService.FetchConfiguredTaxProviders();
      rblConfiguredProviders.Items.Clear();
      if(taxServiceSettings != null) {
        foreach(ProviderSettings providerSettings in taxServiceSettings.ProviderSettingsCollection) {
          rblConfiguredProviders.Items.Add(new ListItem(providerSettings.Name, providerSettings.Name));
        }
        if(!string.IsNullOrEmpty(taxServiceSettings.DefaultProvider)) {
          rblConfiguredProviders.SelectedValue = taxServiceSettings.DefaultProvider;
          rblConfiguredProviders.SelectedItem.Attributes.Add("class", "defaultProvider");
          defaultProviderName = taxServiceSettings.DefaultProvider;
        }
      }
    }

    /// <summary>
    /// Sets the default payment provider.
    /// </summary>
    private void SetDefaultPaymentProvider() {
      int id = PaymentService.SetDefaultPaymentProvider(rblConfiguredProviders.SelectedValue, WebUtility.GetUserName());
      if(id > 0) {
        MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblDefaultPaymentProviderSaved"));
      }
      else {
        MasterPage.MessageCenter.DisplayFailureMessage(LocalizationUtility.GetText("lblDefaultPaymentProviderNotSaved"));
      }
    }

    /// <summary>
    /// Sets the default shipping provider.
    /// </summary>
    private void SetDefaultShippingProvider() {
      int id = ShippingService.SetDefaultShippingProvider(rblConfiguredProviders.SelectedValue, WebUtility.GetUserName());
      if(id > 0) {
        MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblDefaultShippingProviderSaved"));
      }
      else {
        MasterPage.MessageCenter.DisplayFailureMessage(LocalizationUtility.GetText("lblDefaultShippingProviderNotSaved"));
      }
    }

    /// <summary>
    /// Sets the default tax provider.
    /// </summary>
    private void SetDefaultTaxProvider() {
      int id = TaxService.SetDefaultTaxProvider(rblConfiguredProviders.SelectedValue, WebUtility.GetUserName());
      if(id > 0) {
        MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblDefaultTaxProviderSaved"));
      }
      else {
        MasterPage.MessageCenter.DisplayFailureMessage(LocalizationUtility.GetText("lblDefaultTaxProviderNotSaved"));
      }
    }

    /// <summary>
    /// Removes the payment provider.
    /// </summary>
    private void RemovePaymentProvider() {
      PaymentService.RemovePaymentProvider(rblConfiguredProviders.SelectedValue, WebUtility.GetUserName());
      MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblRemoveProvider"));
    }

    /// <summary>
    /// Removes the shipping provider.
    /// </summary>
    private void RemoveShippingProvider() {
      ShippingService.RemoveShippingProvider(rblConfiguredProviders.SelectedValue, WebUtility.GetUserName());
      MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblRemoveProvider"));
    }

    /// <summary>
    /// Removes the tax provider.
    /// </summary>
    private void RemoveTaxProvider() {
      TaxService.RemoveTaxProvider(rblConfiguredProviders.SelectedValue, WebUtility.GetUserName());
      MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblRemoveProvider"));
    }

    #endregion

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the type of the provider.
    /// </summary>
    /// <value>The type of the provider.</value>
    public ProviderType ProviderType {
      get {
        return _providerType;
      }
      set {
        _providerType = value;
      }
    }

    #endregion
  }
}