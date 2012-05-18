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
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Web.Controls;
using SubSonic;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin.controls.configuration.paymentproviders {
  public partial class paymentselection : AdminControl {

    private const string URL = "~/admin/paymentselection.aspx?step={0}";

    private int _step;
    private int _withPayPal;

    protected void Page_Load(object sender, EventArgs e) {
      _step = Utility.GetIntParameter("step");
      _withPayPal = Utility.GetIntParameter("withPayPal");
      LoadPaymentSelectionProperties();
      if (!Page.IsPostBack) {
        switch (_step) {
          default:
            pnlCardProcessing.Visible = true;
            break;
          case 1:
            if (_withPayPal == 1) {
              pnlAcceptCreditCardsWithPayPal.Visible = true;
              LoadPayPalUrls();
            }
            if (_withPayPal == -1) {
              pnlAcceptCreditCardsWithoutPayPal.Visible = true;
            }
            break;
        }
      }
    }


    //protected virtual void btnPrevious_Click(object sender, EventArgs e) {
    //  try {
    //    Response.Redirect(string.Format(URL, _step - 1), true);
    //  }
    //  catch (Exception ex) {
    //    MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
    //  }
    //}


    protected void btnNext_Click(object sender, EventArgs e) {
      try {
        string url;
        if (rbCreditCardsWithPayPal.Checked) {
          url = URL + "&withPayPal=1";
        }
        else {
          url = URL + "&withPayPal=-1";
        }
        Response.Redirect(string.Format(url, _step + 1), true);
      }
      catch (System.Threading.ThreadAbortException) {
        //swallow it
      }
      catch (Exception ex) {
        MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    protected void btnNext1_Click(object sender, EventArgs e) {
      try {
        string providerId = (rbAllInOne.Checked) ? rblAllInOne.SelectedValue : rblExisting.SelectedValue;
        Response.Redirect(string.Format("~/admin/paymentconfiguration.aspx?providerId={0}", providerId, true));
      }
      catch (System.Threading.ThreadAbortException) {
        //swallow it
      }
      catch (Exception ex) {
        MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    protected void btnPrevious1_Click(object sender, EventArgs e) {
      try {
        Response.Redirect(string.Format(URL, _step - 1), true);
      }
      catch (System.Threading.ThreadAbortException) {
        //swallow it
      }
      catch (Exception ex) {
        MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }


    protected void radiobutton_CheckedChanged(object sender, EventArgs e) {
      RadioButton radioButton = sender as RadioButton;
      if (radioButton != null) {
        radioButton.Checked = true;
      }
    }

    protected void acceptCreditCards_CheckedChanged(object sender, EventArgs e) {
      RadioButton radioButton = sender as RadioButton;
      if (radioButton != null) {
        radioButton.Checked = true;
        switch (radioButton.ID) {
          case "rbAllInOne":
            LoadAllInOnePaymentsList();
            break;
          case "rbExisting":
            LoadExistingPaymentsList();
            break;
        }
      }
    }


    private void LoadPayPalUrls() {
      string url = "~/admin/paymentconfiguration.aspx?providerId={0}";
      Query query = new Query(Provider.Schema)
        .WHERE("Name", "PayPalProPaymentProvider");
      ProviderCollection paypalProProvider = new ProviderController().FetchByQuery(query);
      if(paypalProProvider.Count == 1) {
        hlPayPalPro.NavigateUrl = string.Format(url,
                                                paypalProProvider[0].ProviderId);
      }
      Query query1 = new Query(Provider.Schema)
        .WHERE("Name", "PayPalStandardPaymentProvider");
      ProviderCollection paypalStandardProvider = new ProviderController().FetchByQuery(query1);
      if(paypalStandardProvider.Count == 1) {
        hlPayPalWebsitePaymentsStandard.NavigateUrl = string.Format(url,
                                                paypalStandardProvider[0].ProviderId);
      }
    }

    private void LoadAllInOnePaymentsList() {
      rblExisting.Items.Clear();
      Query query = new Query(Provider.Schema)
        .WHERE("Name", "PayPalProPaymentProvider")
        .OR("Name", "PayPalStandardPaymentProvider");
      ProviderCollection allInOne = new ProviderController().FetchByQuery(query);
      if (allInOne.Count > 0) {
        string name;
        foreach (Provider provider in allInOne) {
          name = provider.Name == "PayPalProPaymentProvider"
                   ? "PayPal Website Payments Pro"
                   : "PayPal Website Payments Standard";
          rblAllInOne.Items.Add(new ListItem(name, provider.ProviderId.ToString()));
        }
      }
    }


    private void LoadExistingPaymentsList() {
      rblAllInOne.Items.Clear();
      Query query = new Query(Provider.Schema)
        .WHERE("ProviderTypeId", ProviderType.PaymentProvider)
        .AddWhere("Name", Comparison.NotEquals, "PayPalProPaymentProvider")
        .AddWhere("Name", Comparison.NotEquals, "PayPalStandardPaymentProvider");
      ProviderCollection allInOne = new ProviderController().FetchByQuery(query);
      if (allInOne.Count > 0) {
        string name;
        foreach (Provider provider in allInOne) {
          rblExisting.Items.Add(new ListItem(provider.Name, provider.ProviderId.ToString()));
        }
      }
    }

    private void LoadPaymentSelectionProperties() {
      btnNext1.Text = Localization.LocalizationUtility.GetText("btnNext");
    }

  }
}