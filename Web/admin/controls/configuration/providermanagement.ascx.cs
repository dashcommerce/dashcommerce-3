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
using MettleSystems.dashCommerce.Store.Web.Controls;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin.controls.configuration {
  public partial class providermanagement : AdminControl {
    
    #region Constants
    
    private const string CONTENT_PATH = @"~/repository/content/";
    
    #endregion
  
    #region Member Variables

    private int providerId = 0;
    private Provider provider = null;
    private ProviderType _providerType;
    
    #endregion
    
    #region Page Events

    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Init"></see> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> object that contains the event data.</param>
    protected override void OnInit(EventArgs e) {
      Session["FCKeditor:UserFilesPath"] = CONTENT_PATH;
      base.OnInit(e);
    }

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        SetProviderManagementProperties();
        providerId = Utility.GetIntParameter("providerId");
        if (providerId > 0) {
          provider = new ProviderController().FetchByID(providerId)[0];
        }
        else {
          provider = new Provider();
        }
        SetProviderManagementLabel();
        if (!Page.IsPostBack) {
          SetProviderList();
          txtName.Text = provider.Name;
          txtDescription.Value = HttpUtility.HtmlDecode(provider.Description);
          txtConfigurationControlPath.Text = provider.ConfigurationControlPath;
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(providermanagement).Name + ".Page_Load", ex);
        MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Provider event of the Delete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridCommandEventArgs"/> instance containing the event data.</param>
    protected void Delete_Provider(object sender, DataGridCommandEventArgs e) {
      try {
        int providerId = (int)dgProviders.DataKeys[e.Item.ItemIndex];
        Provider.Delete(providerId);
        SetProviderList();
        base.MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblRemoveProvider"));
      }
      catch(Exception ex) {
        Logger.Error(typeof(providermanagement).Name + ".Delete_Provider", ex);
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
        provider.ProviderTypeId = (int)this.ProviderType;
        provider.Name = txtName.Text;
        provider.Description = HttpUtility.HtmlEncode(txtDescription.Value);
        provider.ConfigurationControlPath = txtConfigurationControlPath.Text;
        if(provider.ProviderId == 0) {
          provider.CreatedDate = DateTime.UtcNow;
          provider.ModifiedDate = DateTime.UtcNow;
        }
        else {
          provider.ModifiedDate = DateTime.UtcNow;
        }
        provider.Save(WebUtility.GetUserName());
        SetProviderList();
        base.MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblProviderSaved"));
      }
      catch(Exception ex) {
        Logger.Error(typeof(providermanagement).Name + ".btnSave_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }    

    /// <summary>
    /// Handles the ItemDataBound event of the dgProviders control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridItemEventArgs"/> instance containing the event data.</param>
    void dgProviders_ItemDataBound(object sender, DataGridItemEventArgs e) {
      if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        LinkButton deleteButton = e.Item.Cells[3].Controls[0] as LinkButton;
        if(deleteButton != null) {
          deleteButton.Attributes.Add("onclick", "return confirm(\"" + LocalizationUtility.GetText("lblConfirmDelete") + "\");return false;");
        }
      }
    }    

    #endregion
    
    #region Methods
    
    #region Private 

    /// <summary>
    /// Sets the provider list.
    /// </summary>
    private void SetProviderList() {
      ProviderCollection providerCollection = new ProviderController().
        FetchByProviderType(this.ProviderType);
      if(providerCollection.Count > 0) {
        pnlProviderList.Visible = true;
        dgProviders.DataSource = providerCollection;
        dgProviders.ItemDataBound += new DataGridItemEventHandler(dgProviders_ItemDataBound);
        dgProviders.Columns[0].HeaderText = LocalizationUtility.GetText("hdrEdit");
        dgProviders.Columns[1].HeaderText = LocalizationUtility.GetText("hdrName");
        dgProviders.Columns[2].HeaderText = LocalizationUtility.GetText("hdrConfigurationControlPath");
        dgProviders.Columns[3].HeaderText = LocalizationUtility.GetText("hdrDelete");

        HyperLinkColumn hlEditColumn = dgProviders.Columns[0] as HyperLinkColumn;
        if(hlEditColumn != null) {
          hlEditColumn.Text = LocalizationUtility.GetText("lblEdit");
          switch(this.ProviderType) {
            case ProviderType.PaymentProvider:
              hlEditColumn.DataNavigateUrlFormatString = "~/admin/paymentprovidermanagement.aspx?providerId={0}";
              break;
            case ProviderType.ShippingProvider:
              hlEditColumn.DataNavigateUrlFormatString = "~/admin/shippingprovidermanagement.aspx?providerId={0}";
              break;
            case ProviderType.TaxProvider:
              hlEditColumn.DataNavigateUrlFormatString = "~/admin/taxprovidermanagement.aspx?providerId={0}";
              break;
            case ProviderType.CouponProvider:
              hlEditColumn.DataNavigateUrlFormatString = "~/admin/couponprovidermanagement.aspx?providerId={0}";
              break;
          }
        }
        ButtonColumn btnColumn = dgProviders.Columns[3] as ButtonColumn;
        if(btnColumn != null) {
          btnColumn.Text = LocalizationUtility.GetText("lblDelete");
        }
        dgProviders.DataBind();
      }
      else {
        pnlProviderList.Visible = false;
        base.MasterPage.MessageCenter.DisplayInformationMessage(SetNoProvidersLabel());
      }
    }

    /// <summary>
    /// Sets the no providers label.
    /// </summary>
    /// <returns></returns>
    private string SetNoProvidersLabel() {
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
        case ProviderType.CouponProvider:
          message = LocalizationUtility.GetText("lblNoCouponProvidersInstalled");
          break;
      }
      return message;
    }

    /// <summary>
    /// Sets the provider management properties.
    /// </summary>
    private void SetProviderManagementProperties() {
      pnlSettings.GroupingText = LocalizationUtility.GetText("pnlProviderDetails");
    }
    
    /// <summary>
    /// Sets the provider management label.
    /// </summary>
    private void SetProviderManagementLabel() {
      switch (this.ProviderType) {
        case ProviderType.PaymentProvider:
          lblProviderManagement.Text = LocalizationUtility.GetText("lblPaymentProviderManagement");
          break;
        case ProviderType.ShippingProvider:
          lblProviderManagement.Text = LocalizationUtility.GetText("lblShippingProviderManagement");
          break;
        case ProviderType.TaxProvider:
          lblProviderManagement.Text = LocalizationUtility.GetText("lblTaxProviderManagement");
          break;
        case ProviderType.CouponProvider:
          lblProviderManagement.Text = LocalizationUtility.GetText("lblCouponProviderManagement");
          break;
      }
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