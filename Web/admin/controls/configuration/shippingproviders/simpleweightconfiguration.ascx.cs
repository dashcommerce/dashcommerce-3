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
using System.Web.UI.WebControls;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Services;
using MettleSystems.dashCommerce.Store.Services.ShippingService;
using MettleSystems.dashCommerce.Store.Web.Controls;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin.controls.configuration.shippingproviders {

  public partial class simpleweightconfiguration : ShippingConfigurationControl {

    #region Member Variables

    private string view;
    private ProviderSettings simpleWeightConfigurationSettings;
    private ShippingServiceSettings shippingServiceSettings;


    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        SetSimpleWeightConfigurationProperties();
        shippingServiceSettings = ShippingService.FetchConfiguredShippingProviders();
        if(shippingServiceSettings != null) {
          foreach(ProviderSettings providerSettings in shippingServiceSettings.ProviderSettingsCollection) {
            if(providerSettings.Name == typeof(SimpleWeightShippingProvider).Name) {
              simpleWeightConfigurationSettings = providerSettings;
            }
          }
        }
        else {
          shippingServiceSettings = new ShippingServiceSettings();
        }
        view = Utility.GetParameter("view");
        switch(view) {
          case "c":
            pnlConfiguration.Visible = true;
            pnlData.Visible = false;
            break;
          case "d":
            LoadSimpleShippingWeightRates();
            pnlData.Visible = true;
            pnlConfiguration.Visible = false;
            break;
          default:
            pnlConfiguration.Visible = true;
            pnlData.Visible = false;
            break;
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(simpleweightconfiguration).Name + ".Page_Load", ex);
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
        if(simpleWeightConfigurationSettings == null) {
          simpleWeightConfigurationSettings = new ProviderSettings(typeof(SimpleWeightShippingProvider).Name, typeof(SimpleWeightShippingProvider).AssemblyQualifiedName);
          shippingServiceSettings.ProviderSettingsCollection.Add(simpleWeightConfigurationSettings);
        }
        int id = base.Save(shippingServiceSettings, WebUtility.GetUserName());
        if(id > 0) {
          MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblShippingConfigurationSaved"));
        }
        else {
          MasterPage.MessageCenter.DisplayFailureMessage(LocalizationUtility.GetText("lblShippingConfigurationNotSaved"));
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(simpleweightconfiguration).Name + ".btnSave_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Delete event of the dgSimpleWeight control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.CommandEventArgs"/> instance containing the event data.</param>
    protected void dgSimpleWeight_Delete(object sender, CommandEventArgs e) {
      try {
        int shippingRateId = 0;
        int.TryParse(e.CommandArgument.ToString(), out shippingRateId);
        bool deleted = new SimpleWeightShippingRateController().Delete(shippingRateId);
        LoadSimpleShippingWeightRates();
        base.MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblServiceDeleted"));
      }
      catch(Exception ex) {
        Logger.Error(typeof(simpleweightconfiguration).Name + ".dgSimpleWeight_Delete", ex);
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
        SimpleWeightShippingRate simpleWeightShippingRate = new SimpleWeightShippingRate();
        simpleWeightShippingRate.Service = txtService.Text.Trim();
        decimal amountPerUnit = 0.00M;
        decimal.TryParse(txtAmountPerUnit.Text.Trim(), out amountPerUnit);
        simpleWeightShippingRate.AmountPerUnit = amountPerUnit;
        simpleWeightShippingRate.Save();
        LoadSimpleShippingWeightRates();
        txtService.Text = string.Empty;
        txtAmountPerUnit.Text = string.Empty;
        base.MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblServiceAdded"));
      }
      catch(Exception ex) {
        Logger.Error(typeof(simpleweightconfiguration).Name + ".btnAdd_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the PageIndexChanged event of the dgSimpleWeight control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridPageChangedEventArgs"/> instance containing the event data.</param>
    protected void dgSimpleWeight_PageIndexChanged(object sender, DataGridPageChangedEventArgs e) {
      dgSimpleWeight.CurrentPageIndex = e.NewPageIndex;
      dgSimpleWeight.DataBind();
    }

    /// <summary>
    /// Handles the ItemDataBound event of the dgSimpleWeight control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridItemEventArgs"/> instance containing the event data.</param>
    void dgSimpleWeight_ItemDataBound(object sender, DataGridItemEventArgs e) {
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
    /// Sets the simple weight configuration properties.
    /// </summary>
    private void SetSimpleWeightConfigurationProperties() {
      ltDescription.Text = HttpUtility.HtmlDecode(base.Provider.Description);
      lblDescriptionTitle.Text = LocalizationUtility.GetText("lblSimpleWeightShippingProviderTitle");
    }

    /// <summary>
    /// Loads the simple shipping weight rates.
    /// </summary>
    private void LoadSimpleShippingWeightRates() {
      SimpleWeightShippingRateCollection simpleWeightShippingRateCollection = new SimpleWeightShippingRateController().FetchAll();
      if(simpleWeightShippingRateCollection.Count > 0) {
        pnlAvailableServices.Visible = true;
        dgSimpleWeight.DataSource = simpleWeightShippingRateCollection;
        dgSimpleWeight.ItemDataBound += new DataGridItemEventHandler(dgSimpleWeight_ItemDataBound);
        dgSimpleWeight.Columns[0].HeaderText = LocalizationUtility.GetText("hdrService");
        dgSimpleWeight.Columns[1].HeaderText = LocalizationUtility.GetText("hdrAmountPerUnit");
        dgSimpleWeight.Columns[2].HeaderText = LocalizationUtility.GetText("lblDelete");
        dgSimpleWeight.DataBind();
      }
      else {
        pnlAvailableServices.Visible = false;
      }
    }

    #endregion

    #endregion
    
  }
}