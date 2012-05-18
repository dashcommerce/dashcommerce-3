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
using System.Web;
using System.Web.UI.WebControls;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Services;
using MettleSystems.dashCommerce.Store.Services.TaxService;
using MettleSystems.dashCommerce.Store.Web.Controls;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin.controls.configuration.taxproviders {
  public partial class vattaxconfiguration : TaxConfigurationControl {

    #region Member Variables

    private string view;
    private ProviderSettings vatTaxConfigurationSettings;
    private TaxServiceSettings taxServiceSettings;

    #endregion

    protected void Page_Load(object sender, EventArgs e) {
      try {
        SetVatConfigurationProperties();
        taxServiceSettings = TaxService.FetchConfiguredTaxProviders();
        if (taxServiceSettings != null) {
          foreach (ProviderSettings providerSettings in taxServiceSettings.ProviderSettingsCollection) {
            if (providerSettings.Name == typeof(VatTaxProvider).Name) {
              vatTaxConfigurationSettings = providerSettings;
            }
          }
          //if (vatTaxConfigurationSettings != null) {
          //  txtDefaultRate.Text = vatTaxConfigurationSettings.Parameters[VatTaxProvider.DEFAULT_RATE];
          //}
        }
        else {
          taxServiceSettings = new TaxServiceSettings();
        }
        view = Utility.GetParameter("view");
        switch (view) {
          case "c":
            pnlVatTaxConfiguration.Visible = true;
            pnlVatTaxData.Visible = false;
            break;
          case "d":
            LoadVatTaxRates();
            pnlVatTaxData.Visible = true;
            pnlVatTaxConfiguration.Visible = false;
            break;
          default:
            pnlVatTaxConfiguration.Visible = true;
            pnlVatTaxData.Visible = false;
            break;
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(vattaxconfiguration).Name + ".Page_Load", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    protected void dgVatTax_Delete(object sender, CommandEventArgs e) {
      try {
        int vatTaxRateId = 0;
        int.TryParse(e.CommandArgument.ToString(), out vatTaxRateId);
        bool deleted = new VatTaxRateController().Delete(vatTaxRateId);
        LoadVatTaxRates();
        base.MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblRateDeleted"));
      }
      catch (Exception ex) {
        Logger.Error(typeof(vattaxconfiguration).Name + ".dgVatTax_Delete", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }

    }

    protected void btnSave_Click(object sender, EventArgs e) {

      try {
        if (vatTaxConfigurationSettings == null) {
          vatTaxConfigurationSettings = new ProviderSettings(typeof(VatTaxProvider).Name, typeof(VatTaxProvider).AssemblyQualifiedName);
          taxServiceSettings.ProviderSettingsCollection.Add(vatTaxConfigurationSettings);
        }
        vatTaxConfigurationSettings.Parameters.Clear();
        //IMPORTANT: These need to be added in the order they are expected by the constructor used by
        //Activator.CreateInstance in PaymentService
        //vatTaxConfigurationSettings.Parameters.Add(RegionCodeTaxProvider.DEFAULT_RATE, txtDefaultRate.Text.Trim());
        int id = base.Save(taxServiceSettings, WebUtility.GetUserName());
        if (id > 0) {
          MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblTaxConfigurationSaved"));
        }
        else {
          MasterPage.MessageCenter.DisplayFailureMessage(LocalizationUtility.GetText("lblTaxConfigurationNotSaved"));
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(vattaxconfiguration).Name + ".btnSave_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }

    }

    protected void btnAdd_Click(object sender, EventArgs e) {
      try {
        VatTaxRate vatTaxRate = new VatTaxRate();
        vatTaxRate.Name = txtName.Text.Trim();
        decimal rate = 0.00M;
        decimal.TryParse(txtRate.Text.Trim(), out rate);
        vatTaxRate.Rate = rate;
        vatTaxRate.Save();
        LoadVatTaxRates();
        txtName.Text = string.Empty;
        txtRate.Text = string.Empty;
        base.MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblRateAdded"));
      }
      catch (Exception ex) {
        Logger.Error(typeof(vattaxconfiguration).Name + ".btnAdd_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }

    }


    void dgVatTax_ItemDataBound(object sender, DataGridItemEventArgs e) {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        LinkButton deleteButton = e.Item.Cells[2].FindControl("lbDelete") as LinkButton;
        if (deleteButton != null) {
          deleteButton.Text = LocalizationUtility.GetText("lblDelete");
          deleteButton.Attributes.Add("onclick", "return confirm(\"" + LocalizationUtility.GetText("lblConfirmDelete") + "\");return false;");
        }
      }
    }    



    private void LoadVatTaxRates() {
      VatTaxRateCollection vatTaxRateCollection = new VatTaxRateController().FetchAll();
      if (vatTaxRateCollection.Count > 0) {
        pnlAvailableVatTax.Visible = true;
        dgVatTax.DataSource = vatTaxRateCollection;
        dgVatTax.ItemDataBound += new DataGridItemEventHandler(dgVatTax_ItemDataBound);
        dgVatTax.Columns[0].HeaderText = LocalizationUtility.GetText("hdrName");
        dgVatTax.Columns[1].HeaderText = LocalizationUtility.GetText("hdrRate");
        dgVatTax.Columns[2].HeaderText = LocalizationUtility.GetText("lblDelete");
        dgVatTax.DataBind();
      }
      else {
        pnlAvailableVatTax.Visible = false;
      }
    }

    /// <summary>
    /// Sets the pay pal standard configuration properties.
    /// </summary>
    private void SetVatConfigurationProperties() {
      ltDescription.Text = HttpUtility.HtmlDecode(base.Provider.Description);
      pnlVatTaxConfiguration.GroupingText = LocalizationUtility.GetText("pnlVatTaxConfiguration");
      lblDescriptionTitle.Text = LocalizationUtility.GetText("lblVatDescriptionTitle");
    }

  }
}