#region Copyright / License

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
using System.Data;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MettleSystems.dashCommerce.Store.Services;
using MettleSystems.dashCommerce.Store.Services.PaymentService;
using MettleSystems.dashCommerce.Store.Web.Controls;


namespace MettleSystems.dashCommerce.Web.admin.controls.configuration.paymentproviders {

  public partial class authorizenetconfiguration : PaymentConfigurationControl {

    #region Member Variables

    ProviderSettings authorizeNetConfigurationSettings = null;
    PaymentServiceSettings paymentServiceSettings;

    #endregion

    #region Page Events
    
    protected void Page_Load(object sender, EventArgs e) {
      try {
        SetAuthorizeNetConfigurationProperties();
        paymentServiceSettings = PaymentService.FetchConfiguredPaymentProviders();
        if(paymentServiceSettings != null) {
          foreach(ProviderSettings providerSettings in paymentServiceSettings.ProviderSettingsCollection) {
            if(providerSettings.Name == typeof(AuthorizeNetPaymentProvider).Name) {
              authorizeNetConfigurationSettings = providerSettings;
            }
          }
          if (authorizeNetConfigurationSettings != null) {
            txtApiUserName.Text = authorizeNetConfigurationSettings.Parameters[AuthorizeNetPaymentProvider.API_USERNAME];
            txtApiTransactionKey.Text = authorizeNetConfigurationSettings.Parameters[AuthorizeNetPaymentProvider.API_TRANSACTION_KEY];
            bool isInTestMode = true;
            bool isParsed = bool.TryParse(authorizeNetConfigurationSettings.Parameters[AuthorizeNetPaymentProvider.IS_IN_TEST_MODE], out isInTestMode);
            chkIsInTestMode.Checked = isInTestMode;
            bool isLive = false;
            isParsed = bool.TryParse(authorizeNetConfigurationSettings.Parameters[AuthorizeNetPaymentProvider.ISLIVE], out isLive);
            chkIsLive.Checked = isLive;
          }
        }
        else {
          paymentServiceSettings = new PaymentServiceSettings();
        }
      }
      catch(Exception ex) {
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    protected void btnSave_Click(object sender, EventArgs e) {
      try {
        if (authorizeNetConfigurationSettings == null) {
          authorizeNetConfigurationSettings = new ProviderSettings(typeof(AuthorizeNetPaymentProvider).Name, typeof(AuthorizeNetPaymentProvider).AssemblyQualifiedName);
          paymentServiceSettings.ProviderSettingsCollection.Add(authorizeNetConfigurationSettings);
        }
        authorizeNetConfigurationSettings.Parameters.Clear();
        //IMPORTANT: These need to be added in the order they are expected by the constructor used by
        //Activator.CreateInstance in PaymentService
        authorizeNetConfigurationSettings.Parameters.Add(AuthorizeNetPaymentProvider.API_USERNAME, txtApiUserName.Text.Trim());
        authorizeNetConfigurationSettings.Parameters.Add(AuthorizeNetPaymentProvider.API_TRANSACTION_KEY, txtApiTransactionKey.Text.Trim());
        authorizeNetConfigurationSettings.Parameters.Add(AuthorizeNetPaymentProvider.IS_IN_TEST_MODE, chkIsInTestMode.Checked.ToString());
        authorizeNetConfigurationSettings.Parameters.Add(AuthorizeNetPaymentProvider.ISLIVE, chkIsLive.Checked.ToString());
        int id = base.Save(paymentServiceSettings, WebUtility.GetUserName());
        if (id > 0) {
          MasterPage.MessageCenter.DisplaySuccessMessage("Payment Configuration Saved");
        }
        else {
          MasterPage.MessageCenter.DisplayFailureMessage("Payment Configuration Not Saved");
        }
      }
      catch (Exception ex) {
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }
    
    
    private void SetAuthorizeNetConfigurationProperties() {
      ltDescription.Text = HttpUtility.HtmlDecode(base.Provider.Description);
      pnlSettings.GroupingText = "Authorize.NET Configuration";
      lblApiTransactionKey.Text = "API Transaction Key:";
      lblApiUserName.Text = "API UserName:";
      lblDescriptionTitle.Text = "Authorize.NET";
      lblIsInTestMode.Text = "Is In Test Mode:";
      lblIsLive.Text = "Is Live:";
      btnSave.Text = "Save";
    }
    
    #endregion
  }
}