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
using System.Web.UI;
using System.Web.UI.WebControls;

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Web.Controls;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin {
  public partial class coupons : MettleSystems.dashCommerce.Store.Web.AdminPage {

    #region Member Variables

    private int couponId = 0;

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        couponId = Utility.GetIntParameter("couponId");
        SetCouponProperites();
        if (!Page.IsPostBack) {
          LoadCouponProviders();
        }
        LoadCoupons();
        LoadCouponProviderControl();
      }
      catch (Exception ex) {
        Logger.Error(typeof(coupons).Name + ".Page_Load", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Deletes the coupon.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridCommandEventArgs"/> instance containing the event data.</param>
    protected void Delete_Coupon(object sender, DataGridCommandEventArgs e) {
      try {
        int couponId = (int)dgCoupons.DataKeys[e.Item.ItemIndex];
        Coupon.Delete(couponId);
        LoadCoupons();
        Master.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblRemoveCoupon"));
      }
      catch (Exception ex) {
        Logger.Error(typeof(coupons).Name + ".Delete_Coupon", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnCreateNew control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnCreateNew_Click(object sender, EventArgs e) {
      try {
        LoadCouponProviderControl();
      }
      catch (Exception ex) {
        Logger.Error(typeof(coupons).Name + ".btnCreateNew_Click", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the ItemDataBound event of the dgCoupons control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.DataGridItemEventArgs"/> instance containing the event data.</param>
    void dgCoupons_ItemDataBound(object sender, DataGridItemEventArgs e) {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        LinkButton deleteButton = e.Item.Cells[4].Controls[0] as LinkButton;
        if (deleteButton != null) {
          deleteButton.Attributes.Add("onclick", "return confirm(\"" + LocalizationUtility.GetText("lblConfirmDelete") + "\");return false;");
        }
      }
    }


    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Sets the coupon properites.
    /// </summary>
    private void SetCouponProperites() {
      Page.Title = LocalizationUtility.GetText("titleProductCoupons");
    }

    /// <summary>
    /// Loads the coupons.
    /// </summary>
    private void LoadCoupons() {
      CouponCollection couponCollection = new CouponController().FetchAll();
      if(couponCollection.Count == 0) {
        Master.MessageCenter.DisplayInformationMessage(LocalizationUtility.GetText("lblNoCouponsConfigured"));
        dgCoupons.Visible = false;
      }
      else {
        dgCoupons.DataSource = couponCollection;
        dgCoupons.ItemDataBound += dgCoupons_ItemDataBound;
        HyperLinkColumn hlEditColumn = dgCoupons.Columns[0] as HyperLinkColumn;
        if(hlEditColumn != null) {
          hlEditColumn.Text = LocalizationUtility.GetText("lblEdit");
          hlEditColumn.DataNavigateUrlFormatString = "~/admin/coupons.aspx?couponId={0}";
        }
        dgCoupons.Columns[0].HeaderText = LocalizationUtility.GetText("hdrEdit");
        dgCoupons.Columns[1].HeaderText = LocalizationUtility.GetText("hdrCouponCode");
        dgCoupons.Columns[2].HeaderText = LocalizationUtility.GetText("hdrExpirationDate");
        dgCoupons.Columns[3].HeaderText = LocalizationUtility.GetText("hdrType");
        dgCoupons.Columns[4].HeaderText = LocalizationUtility.GetText("hdrDelete");
        
        ButtonColumn btnColumn = dgCoupons.Columns[4] as ButtonColumn;
        if(btnColumn != null) {
          btnColumn.Text = LocalizationUtility.GetText("lblDelete");
        }
        dgCoupons.DataBind();
      }
    }

    /// <summary>
    /// Loads the coupon providers.
    /// </summary>
    private void LoadCouponProviders() {
      ProviderCollection providerCollection = new ProviderController().FetchByProviderType(ProviderType.CouponProvider);
      ddlProviders.DataSource = providerCollection;
      ddlProviders.DataTextField = "Name";
      ddlProviders.DataValueField = "ProviderId";
      ddlProviders.DataBind();
    }

    /// <summary>
    /// Loads the coupon provider control.
    /// </summary>
    private void LoadCouponProviderControl() {
      ProviderCollection providerCollection =
        new ProviderController().FetchByID(ddlProviders.SelectedValue);
      CouponConfigurationControl couponConfigurationControl = Page.LoadControl(providerCollection[0].ConfigurationControlPath) as CouponConfigurationControl;
      couponConfigurationControl.Provider = providerCollection[0];
      pnlConfiguration.Controls.Clear();
      pnlConfiguration.Controls.Add(couponConfigurationControl);
    }

    #endregion

    #endregion

  }
}
