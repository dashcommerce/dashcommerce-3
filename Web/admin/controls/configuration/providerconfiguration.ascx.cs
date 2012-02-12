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
using System.Web.UI.WebControls;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Services.PaymentService;
using MettleSystems.dashCommerce.Store.Web.Controls;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin.controls.configuration {
  public partial class providerconfiguration : AdminControl {

    #region Constants

    private const string PROVIDER_ID = "ProviderId";
    private const string NAME = "Name";

    #endregion

    #region Member Variables

    private ProviderType _providerType;
    private string defaultProviderName = string.Empty;
    private int providerId = Utility.GetIntParameter("providerId");
    private string providerName = Utility.GetParameter("providerName");
    private ProviderCollection providerCollection;

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        if (this.ProviderType == ProviderType.PaymentProvider) {
          PaymentServiceSettings paymentServiceSettings = PaymentService.FetchConfiguredPaymentProviders();
          if (paymentServiceSettings == null && providerId == 0) {//they haven't selected a provider yet.
            Response.Redirect("~/admin/paymentselection.aspx", true);
          }
        }
        providerCollection = new ProviderController().FetchByProviderType(ProviderType);
        if (!Page.IsPostBack) {
          SetProviderConfiguration();
        }
        SetConfigurationControl();
        SetProviderConfigurationProperties();
      }
      catch(Exception ex) {
        Logger.Error(typeof(providerconfiguration).Name + ".Page_Load", ex);
        MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnSetProvider control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnSetProvider_Click(object sender, EventArgs e) {
      Response.Redirect(string.Format(WebUtility.ScrubUrl() + "?providerId={0}", ddlProviders.SelectedValue), true);
    }

    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Sets the provider configuration.
    /// </summary>
    private void SetProviderConfiguration() {
      if(providerCollection.Count > 0) {
        ddlProviders.DataSource = providerCollection;
        ddlProviders.DataValueField = PROVIDER_ID;
        ddlProviders.DataTextField = NAME;
        ddlProviders.DataBind();
        //if there is a provider selected, then set it as such
        if (providerId > 0) {
          ListItem selected = ddlProviders.Items.FindByValue(providerId.ToString());
          if (selected != null) {
            selected.Selected = true;
          }
        }
        else if (!string.IsNullOrEmpty(providerName)) {
           ListItem selected = ddlProviders.Items.FindByText(providerName);
            if (selected != null) {
              selected.Selected = true;
            }
        }
        else {
          //if there is a defaultProvider, then set it as the selected one.
          if (!string.IsNullOrEmpty(defaultProviderName)) {
            ListItem listItem = ddlProviders.Items.FindByText(defaultProviderName);
            if (listItem != null) {
              listItem.Selected = true;
            }
          }
        }
      }
      else {
        pnlInstalledProviders.Visible = false;
        ddlProviders.Visible = false;
        btnSetProvider.Visible = false;
        MasterPage.MessageCenter.DisplayFailureMessage(SetNoProvidersInstalledMessage());
      }
    }

    /// <summary>
    /// Sets the no providers installed message.
    /// </summary>
    /// <returns></returns>
    private string SetNoProvidersInstalledMessage() {
      string message = string.Empty;
      switch(this.ProviderType) {
        case ProviderType.PaymentProvider:
          message = LocalizationUtility.GetText("lblNoPaymentProvidersInstalled");
          break;
        case ProviderType.ShippingProvider:
          message = LocalizationUtility.GetText("lblNoShippingProvidersInstalled");
          break;
        case ProviderType.TaxProvider:
          message = LocalizationUtility.GetText("lblNoTaxProvidersInstalled");
          break;
      }
      return message;
    }

    /// <summary>
    /// Sets the configuration control.
    /// </summary>
    private void SetConfigurationControl() {
      Provider provider;
      if (string.IsNullOrEmpty(providerName))
        provider = providerCollection.Find(delegate(Provider p) { return p.ProviderId.ToString() == ddlProviders.SelectedValue; });
      else
        provider = providerCollection.Find(delegate(Provider p) { return p.Name == providerName; });   

      switch(this.ProviderType) {
        case ProviderType.PaymentProvider:
          LoadPaymentProviderConfigurationControl(provider);
          break;
        case ProviderType.ShippingProvider:
          LoadShippingProviderConfigurationControl(provider);
          break;
        case ProviderType.TaxProvider:
          LoadTaxProviderConfigurationControl(provider);
          break;
      }
    }

    /// <summary>
    /// Sets the provider configuration properties.
    /// </summary>
    private void SetProviderConfigurationProperties() {
      btnSetProvider.Text = LocalizationUtility.GetText("btnSetProvider");

      switch(this.ProviderType) {
        case ProviderType.PaymentProvider:
          lblConfiguration.Text = LocalizationUtility.GetText("lblPaymentConfiguration");
          lblInstalledProviders.Text = LocalizationUtility.GetText("lblInstalledPaymentProviders");
          pnlInstalledProviders.GroupingText = LocalizationUtility.GetText("pnlPaymentProviders");
          break;
        case ProviderType.ShippingProvider:
          lblConfiguration.Text = LocalizationUtility.GetText("lblShippingConfiguration");
          lblInstalledProviders.Text = LocalizationUtility.GetText("lblInstalledShippingProviders");
          pnlInstalledProviders.GroupingText = LocalizationUtility.GetText("pnlShippingProviders");
          break;
        case ProviderType.TaxProvider:
          lblConfiguration.Text = LocalizationUtility.GetText("lblTaxConfiguration");
          lblInstalledProviders.Text = LocalizationUtility.GetText("lblInstalledTaxProviders");
          pnlInstalledProviders.GroupingText = LocalizationUtility.GetText("pnlTaxProviders");
          break;
      }
    }

    /// <summary>
    /// Loads the payment provider configuration control.
    /// </summary>
    private void LoadPaymentProviderConfigurationControl(Provider provider) {
      if(ddlProviders.Items.Count > 0) {
        PaymentConfigurationControl paymentConfigurationControl = Page.LoadControl(provider.ConfigurationControlPath) as PaymentConfigurationControl;
        if (paymentConfigurationControl != null) {
          paymentConfigurationControl.ID = "ctl" + ddlProviders.SelectedValue;
          paymentConfigurationControl.Provider = provider;
          pnlConfiguration.Controls.Clear();
          pnlConfiguration.Controls.Add(paymentConfigurationControl);
          if (provider.Name != "PayPalProPaymentProvider" && provider.Name != "PayPalStandardPaymentProvider") {
            PaymentConfigurationControl payPalExpressConfigurationControl =
              Page.LoadControl("~/admin/controls/configuration/paymentproviders/paypalacceleratedboarding.ascx") as
              PaymentConfigurationControl;
            pnlConfiguration.Controls.Add(payPalExpressConfigurationControl);
          }
        }
      }
    }

    /// <summary>
    /// Loads the shipping provider configuration control.
    /// </summary>
    private void LoadShippingProviderConfigurationControl(Provider provider) {
      if(ddlProviders.Items.Count > 0) {
        ShippingConfigurationControl shippingConfigurationControl = Page.LoadControl(provider.ConfigurationControlPath) as ShippingConfigurationControl;
        if (shippingConfigurationControl != null) {
          shippingConfigurationControl.ID = "ctl" + ddlProviders.SelectedValue;
          shippingConfigurationControl.Provider = provider;
          pnlConfiguration.Controls.Clear();
          pnlConfiguration.Controls.Add(shippingConfigurationControl);
        }
      }
    }

    /// <summary>
    /// Loads the tax provider configuration control.
    /// </summary>
    private void LoadTaxProviderConfigurationControl(Provider provider) {
      if(ddlProviders.Items.Count > 0) {
        TaxConfigurationControl taxConfigurationControl = Page.LoadControl(provider.ConfigurationControlPath) as TaxConfigurationControl;
        if (taxConfigurationControl != null) {
          taxConfigurationControl.ID = "ctl" + ddlProviders.SelectedValue;
          taxConfigurationControl.Provider = provider;
          pnlConfiguration.Controls.Clear();
           pnlConfiguration.Controls.Add(taxConfigurationControl);
        }
      }
    }

    #endregion

    #endregion

    #region Properties

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