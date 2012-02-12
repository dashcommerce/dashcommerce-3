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
using MettleSystems.dashCommerce.Controls;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store.Services;
using MettleSystems.dashCommerce.Store.Services.PaymentService;
using MettleSystems.dashCommerce.Store.Web.Controls;

namespace MettleSystems.dashCommerce.Web.admin.controls.configuration.paymentproviders {
  public partial class paypalacceleratedboarding : PaymentConfigurationControl {

    #region Member Variables

    ProviderSettings payPalProConfigurationSettings = null;
    PaymentServiceSettings paymentServiceSettings;

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e) {
      paymentServiceSettings = PaymentService.FetchConfiguredPaymentProviders();
      if (paymentServiceSettings != null) {
        foreach (ProviderSettings providerSettings in paymentServiceSettings.ProviderSettingsCollection) {
          if (providerSettings.Name == typeof(PayPalProPaymentProvider).Name) {
            payPalProConfigurationSettings = providerSettings;
            break;
          }
        }
        if (!Page.IsPostBack) {
          if (payPalProConfigurationSettings != null) {
            bool isLive = false;
            bool isParsed = bool.TryParse(payPalProConfigurationSettings.Parameters[PayPalProPaymentProvider.ISLIVE],
                                          out isLive);
            if (isLive) {
              rbProductionMode.Checked = true;
            }
            else {
              rbSandboxMode.Checked = true;
            }

            if (!string.IsNullOrEmpty(payPalProConfigurationSettings.Parameters[PayPalProPaymentProvider.BUSINESS_EMAIL])) {
              txtEmailAddress.Text = payPalProConfigurationSettings.Parameters[PayPalProPaymentProvider.BUSINESS_EMAIL];
              txtApiUserName.Text = txtApiPassword.Text = txtSignature.Text = string.Empty;
              txtEmailAddress.Enabled = rfvEmailAddress.Enabled = true;
              pnlPayPalApiCredentials.Enabled = false;
              txtApiUserName.Enabled = txtApiPassword.Enabled = txtSignature.Enabled = false;
              rfvApiUserName.Enabled = rfvApiPassword.Enabled = rfvApiSignature.Enabled = false;
              rbEmailAddress.Checked = true;
            }
            else {
              txtApiUserName.Text = payPalProConfigurationSettings.Parameters[PayPalProPaymentProvider.API_USERNAME];
              txtApiPassword.Text = payPalProConfigurationSettings.Parameters[PayPalProPaymentProvider.API_PASSWORD];
              txtSignature.Text = payPalProConfigurationSettings.Parameters[PayPalProPaymentProvider.SIGNATURE];
              txtEmailAddress.Text = string.Empty;
              txtEmailAddress.Enabled = rfvEmailAddress.Enabled = false;
              pnlPayPalApiCredentials.Enabled = true;
              txtApiUserName.Enabled = txtApiPassword.Enabled = txtSignature.Enabled = true;
              rfvApiUserName.Enabled = rfvApiPassword.Enabled = rfvApiSignature.Enabled = true;
              rbAPICredentials.Checked = true;
            }
          }
        }
      }
      else {
        paymentServiceSettings = new PaymentServiceSettings();
        if (!Page.IsPostBack) {
          rbProductionMode.Checked = true;
          rbEmailAddress.Checked = true;
        }
      }
    }

    protected void btnSave_Click(object sender, EventArgs e) {
      try {
        bool isProductionMode = rbProductionMode.Checked;
        bool isApiMode = rbAPICredentials.Checked;
        //MasterPage.MessageCenter.DisplayInformationMessage("Is Production Mode: " + isProductionMode.ToString() + "<br/>Is Api Mode: " + isApiMode.ToString());
        //paymentServiceSettings = PaymentService.FetchConfiguredPaymentProviders();
        if (payPalProConfigurationSettings == null) {
          payPalProConfigurationSettings = new ProviderSettings(typeof(PayPalProPaymentProvider).Name, typeof(PayPalProPaymentProvider).AssemblyQualifiedName);
          paymentServiceSettings.ProviderSettingsCollection.Add(payPalProConfigurationSettings);
        }
        payPalProConfigurationSettings.Parameters.Clear();
        //IMPORTANT: These need to be added in the order they are expected by the constructor used by
        //Activator.CreateInstance in PaymentService
        payPalProConfigurationSettings.Parameters.Add(PayPalProPaymentProvider.API_USERNAME, txtApiUserName.Text.Trim());
        payPalProConfigurationSettings.Parameters.Add(PayPalProPaymentProvider.API_PASSWORD, txtApiPassword.Text.Trim());
        payPalProConfigurationSettings.Parameters.Add(PayPalProPaymentProvider.SIGNATURE, txtSignature.Text.Trim());
        string businessEmail = isApiMode ? string.Empty : txtEmailAddress.Text.Trim();
        payPalProConfigurationSettings.Parameters.Add(PayPalProPaymentProvider.BUSINESS_EMAIL, businessEmail);
        payPalProConfigurationSettings.Parameters.Add(PayPalProPaymentProvider.ISLIVE, isProductionMode.ToString());
        int id = base.Save(paymentServiceSettings, WebUtility.GetUserName());
        if (id > 0) {
          MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblPaymentConfigurationSaved"));
        }
        else {
          MasterPage.MessageCenter.DisplayFailureMessage(LocalizationUtility.GetText("lblPaymentConfigurationNotSaved"));
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(paypalacceleratedboarding).Name + ".btnSave_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    protected void ModeChecked_Changed(object sender, EventArgs e) {
      RadioButton rb = sender as RadioButton;
      if (rb != null) {
        rb.Checked = true;
      }
    }

    protected void ApiChecked_Changed(object sender, EventArgs e) {
      RadioButton rb = sender as RadioButton;
      if (rb != null) {
        rb.Checked = true;
        if (rb.ID == "rbEmailAddress") {
          txtApiUserName.Text = txtApiPassword.Text = txtSignature.Text = string.Empty;
          txtEmailAddress.Enabled = rfvEmailAddress.Enabled = true;
          pnlPayPalApiCredentials.Enabled = false;
          txtApiUserName.Enabled = txtApiPassword.Enabled = txtSignature.Enabled = false;
          rfvApiUserName.Enabled = rfvApiPassword.Enabled = rfvApiSignature.Enabled = false;
        }
        else {
          txtEmailAddress.Text = string.Empty;
          txtEmailAddress.Enabled = rfvEmailAddress.Enabled = false;
          pnlPayPalApiCredentials.Enabled = true;
          txtApiUserName.Enabled = txtApiPassword.Enabled = txtSignature.Enabled = true;
          rfvApiUserName.Enabled = rfvApiPassword.Enabled = rfvApiSignature.Enabled = true;
        }
      }
    }

    #endregion
  }
}