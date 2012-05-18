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
using System.Web.UI;
using System.Web.UI.WebControls;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Services;
using MettleSystems.dashCommerce.Store.Services.TaxService;
using MettleSystems.dashCommerce.Store.Web.Controls;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin.controls.configuration.taxproviders {
  public partial class regioncodeconfiguration : TaxConfigurationControl {

    #region Member Variables

    private string view;
    private ProviderSettings regionCodeConfigurationSettings;
    private TaxServiceSettings taxServiceSettings;

    #endregion
    
    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        SetRegionCodeConfigurationProperties();
        taxServiceSettings = TaxService.FetchConfiguredTaxProviders();
        if(taxServiceSettings != null) {
          foreach(ProviderSettings providerSettings in taxServiceSettings.ProviderSettingsCollection) {
            if(providerSettings.Name == typeof(RegionCodeTaxProvider).Name) {
              regionCodeConfigurationSettings = providerSettings;
            }
          }
          if(regionCodeConfigurationSettings != null) {
            txtDefaultRate.Text = regionCodeConfigurationSettings.Parameters[RegionCodeTaxProvider.DEFAULT_RATE];
          }
        }
        else {
          taxServiceSettings = new TaxServiceSettings();
        }
        view = Utility.GetParameter("view");
        switch(view) {
          case "c":
            pnlRegionCodeConfiguration.Visible = true;
            pnlRegionCodeData.Visible = false;
            break;
          case "d":
            LoadRegionCodeRates();
            pnlRegionCodeData.Visible = true;
            pnlRegionCodeConfiguration.Visible = false;
            break;
          default:
            pnlRegionCodeConfiguration.Visible = true;
            pnlRegionCodeData.Visible = false;
            break;
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(regioncodeconfiguration).Name + ".Page_Load", ex);
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
        if(regionCodeConfigurationSettings == null) {
          regionCodeConfigurationSettings = new ProviderSettings(typeof(RegionCodeTaxProvider).Name, typeof(RegionCodeTaxProvider).AssemblyQualifiedName);
          taxServiceSettings.ProviderSettingsCollection.Add(regionCodeConfigurationSettings);
        }
        regionCodeConfigurationSettings.Parameters.Clear();
        //IMPORTANT: These need to be added in the order they are expected by the constructor used by
        //Activator.CreateInstance in PaymentService
        regionCodeConfigurationSettings.Parameters.Add(RegionCodeTaxProvider.DEFAULT_RATE, txtDefaultRate.Text.Trim());
        int id = base.Save(taxServiceSettings, WebUtility.GetUserName());
        if(id > 0) {
          MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblTaxConfigurationSaved"));
        }
        else {
          MasterPage.MessageCenter.DisplayFailureMessage(LocalizationUtility.GetText("lblTaxConfigurationNotSaved"));
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(regioncodeconfiguration).Name + ".btnSave_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Delete event of the dgRegionCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.CommandEventArgs"/> instance containing the event data.</param>
    protected void dgRegionCode_Delete(object sender, CommandEventArgs e) {
      try {
        int rateId = 0;
        int.TryParse(e.CommandArgument.ToString(), out rateId);
        bool deleted = new RegionCodeTaxRateController().Delete(rateId);
        LoadRegionCodeRates();
        base.MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblRateDeleted"));
      }
      catch(Exception ex) {
        Logger.Error(typeof(regioncodeconfiguration).Name + ".dgRegionCode_Delete", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnAdd control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnAdd_Click(object sender, EventArgs e) {
      try {
        RegionCodeTaxRate regionCodeTaxRate = new RegionCodeTaxRate();
        regionCodeTaxRate.RegionCode = txtRegionCode.Text.Trim();
        decimal rate = 0.00M;
        decimal.TryParse(txtRate.Text.Trim(), out rate);
        regionCodeTaxRate.Rate = rate;
        regionCodeTaxRate.Save();
        LoadRegionCodeRates();
        txtRegionCode.Text = string.Empty;
        txtRate.Text = string.Empty;
        base.MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblRateAdded"));
      }
      catch(Exception ex) {
        Logger.Error(typeof(regioncodeconfiguration).Name + ".btnAdd_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the ItemDataBound event of the dgRegionCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridItemEventArgs"/> instance containing the event data.</param>
    void dgRegionCode_ItemDataBound(object sender, DataGridItemEventArgs e) {
      if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        LinkButton deleteButton = e.Item.Cells[2].FindControl("lbDelete") as LinkButton;
        if(deleteButton != null) {
          deleteButton.Text = LocalizationUtility.GetText("lblDelete");
          deleteButton.Attributes.Add("onclick", "return confirm(\"" + LocalizationUtility.GetText("lblConfirmDelete") + "\");return false;");
        }
      }
    }    

    #endregion
    
    #region Methods
    
    #region Private

    /// <summary>
    /// Sets the region code configuration properties.
    /// </summary>
    private void SetRegionCodeConfigurationProperties() {
      ltDescription.Text = HttpUtility.HtmlDecode(base.Provider.Description);
      lblDescriptionTitle.Text = LocalizationUtility.GetText("lblRegionCodeDecriptionTitle");
    }

    /// <summary>
    /// Loads the region code rates.
    /// </summary>
    private void LoadRegionCodeRates() {
      RegionCodeTaxRateCollection regionCodeTaxRateCollection = new RegionCodeTaxRateController().FetchAll();
      if(regionCodeTaxRateCollection.Count > 0) {
        pnlAvailableRegionCodes.Visible = true;
        dgRegionCode.DataSource = regionCodeTaxRateCollection;
        dgRegionCode.ItemDataBound += new DataGridItemEventHandler(dgRegionCode_ItemDataBound);
        dgRegionCode.Columns[0].HeaderText = LocalizationUtility.GetText("hdrRegionCode");
        dgRegionCode.Columns[1].HeaderText = LocalizationUtility.GetText("hdrRate");
        dgRegionCode.Columns[2].HeaderText = LocalizationUtility.GetText("lblDelete");
        dgRegionCode.DataBind();
      }
      else {
        pnlAvailableRegionCodes.Visible = false;
      }
    }

    #endregion
    
    #endregion

  }
}