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
using System.Web;
using System.Web.UI;

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store.Services;
using MettleSystems.dashCommerce.Store.Services.PaymentService;
using MettleSystems.dashCommerce.Store.Web.Controls;

namespace MettleSystems.dashCommerce.Web.admin.controls.configuration.paymentproviders {
  public partial class paypalproconfiguration : PaymentConfigurationControl {

    #region Member Variables
    
    ProviderSettings payPalProConfigurationSettings = null;
    PaymentServiceSettings paymentServiceSettings;
    
    #endregion
    
    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        SetPayPalProConfigurationProperties();
        paymentServiceSettings = PaymentService.FetchConfiguredPaymentProviders();
        if(paymentServiceSettings != null) {
          foreach(ProviderSettings providerSettings in paymentServiceSettings.ProviderSettingsCollection) {
            if(providerSettings.Name == typeof(PayPalProPaymentProvider).Name) {
              payPalProConfigurationSettings = providerSettings;
              break;
            }
          }
          if(payPalProConfigurationSettings != null) {
            txtApiUserName.Text = payPalProConfigurationSettings.Parameters[PayPalProPaymentProvider.API_USERNAME];
            txtApiPassword.Text = payPalProConfigurationSettings.Parameters[PayPalProPaymentProvider.API_PASSWORD];
            txtSignature.Text = payPalProConfigurationSettings.Parameters[PayPalProPaymentProvider.SIGNATURE];
            bool isLive = false;
            bool isParsed = bool.TryParse(payPalProConfigurationSettings.Parameters[PayPalProPaymentProvider.ISLIVE], out isLive);
            chkIsLive.Checked = isLive;
          }
        }
        else {
          paymentServiceSettings = new PaymentServiceSettings();
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(paypalproconfiguration).Name + ".Page_Load", ex);
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
        //payPalProConfigurationSettings.Parameters.Add(PayPalProPaymentProvider.BUSINESS_EMAIL, string.Empty);
        payPalProConfigurationSettings.Parameters.Add(PayPalProPaymentProvider.ISLIVE, chkIsLive.Checked.ToString());
        int id = base.Save(paymentServiceSettings, WebUtility.GetUserName());
        if (id > 0) {
          MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblPaymentConfigurationSaved"));
        }
        else {
          MasterPage.MessageCenter.DisplayFailureMessage(LocalizationUtility.GetText("lblPaymentConfigurationNotSaved"));
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(paypalproconfiguration).Name + ".btnSave_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }     
    }
    
    #endregion
    
    #region Methods
    
    #region Private

    /// <summary>
    /// Sets the pay pal pro configuration properties.
    /// </summary>
    private void SetPayPalProConfigurationProperties() {
      ltDescription.Text = HttpUtility.HtmlDecode(base.Provider.Description);
      pnlSettings.GroupingText = LocalizationUtility.GetText("pnlPayPalProConfiguration");
      lblDescriptionTitle.Text = LocalizationUtility.GetText("lblPayPalProDescriptionTitle");
    }
    
    #endregion
    
    #endregion
    
  }
}