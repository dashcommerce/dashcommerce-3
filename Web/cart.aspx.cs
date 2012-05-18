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
using System.Web.UI;
using System.Web.UI.WebControls;

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Services;
using MettleSystems.dashCommerce.Store.Services.PaymentService;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web {
  public partial class cart : MettleSystems.dashCommerce.Store.Web.SitePage {

    #region Member Variables
    
    private Order order;
    
    #endregion
    
    #region Page Events


    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        Page.Title = string.Format(WebUtility.MainTitleTemplate, Master.SiteSettings.SiteName, LocalizationUtility.GetText("titleCart"));
        order = new OrderController().FetchOrder(WebUtility.GetUserName());
        PaymentServiceSettings providers = PaymentService.FetchConfiguredPaymentProviders();
        if (providers != null) {
          if (providers.DefaultProvider == "PayPalProPaymentProvider" && !(string.IsNullOrEmpty(providers.ProviderSettingsCollection["PayPalProPaymentProvider"].Parameters[PayPalProPaymentProvider.BUSINESS_EMAIL]))) {
            pnlExpressCheckout.Visible = true;
          }
        }
        if (!Page.IsPostBack) {
          bool changesMade = OrderController.NormalizeCartQuantities(order);
          if (changesMade) {
            messageCenter.Visible = true;
            messageCenter.DisplayInformationMessage(LocalizationUtility.GetText("lblCartChanged"));
          }
          if (order.OrderId > 0 && order.OrderItemCollection.Count > 0) {
            pnlNoCart.Visible = false;
            orderSummary.Order = order;
            
            lblSubTotalAmountTop.Text = StoreUtility.GetFormattedAmount(order.SubTotal, true);
            lbUpdate.Text = LocalizationUtility.GetText("lblUpdate");
          }
          else {
            pnlCart.Visible = false;
            
            ProductCollection productCollection;
            if (this.Master.SiteSettings.CollectBrowsingProduct) {
              productCollection = Store.Caching.ProductCache.GetMostPopularProducts();
            }
            else {
              productCollection = new ProductController().FetchRandomProducts();//Should we cache this?
            }
            catalogList.ProductCollection = productCollection;
          }
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(cart).Name + ".Page_Load", ex);
        throw;
      }
    }

    /// <summary>
    /// Handles the Click event of the imgPayPal control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void imgPayPal_Click(object sender, EventArgs e) {
      order.PaymentMethod = CreditCardType.PayPal.ToString();
      order.Save(WebUtility.GetUserName());
      string siteRoot = Utility.GetSiteRoot();
      string url = OrderController.SetExpressCheckout(order, siteRoot + "/checkout.aspx", siteRoot + "/default.aspx", false);
      Response.Redirect(url, true);
    }

    /// <summary>
    /// Handles the Click event of the lbUpdate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void lbUpdate_Click(object sender, EventArgs e) {

      TextBox txtQuantity;
      Label lblOrderItemId;
      Label lblName;
      DropDownList ddlQuantity;
      foreach(RepeaterItem item in orderSummary.Repeater.Items) {
        txtQuantity = item.FindControl("txtQuantity") as TextBox;
        ddlQuantity = item.FindControl("ddlQuantity") as DropDownList;
        lblOrderItemId = item.FindControl("lblOrderItemId") as Label;
        lblName = item.FindControl("lblName") as Label;
        int orderItemId = 0;
        int quantity = 0;
        if((txtQuantity != null || ddlQuantity != null) && lblOrderItemId != null) {
          int.TryParse(lblOrderItemId.Text, out orderItemId);
          if(orderItemId > 0) {
            if(!string.IsNullOrEmpty(txtQuantity.Text)) {
              int.TryParse(txtQuantity.Text, out quantity);
            }
            if(!string.IsNullOrEmpty(ddlQuantity.SelectedValue)) {
              int.TryParse(ddlQuantity.SelectedValue, out quantity);
            }
            if(quantity > 0) {
              new OrderController().AdjustQuantity(order.OrderId, orderItemId, quantity, WebUtility.GetUserName());
            }
            else {
              new OrderController().RemoveItem(order.OrderId, orderItemId, WebUtility.GetUserName());
            }
          }
        }
      }

      Order modifiedOrder = new OrderController().FetchOrder(WebUtility.GetUserName());
      if(modifiedOrder.OrderItemCollection.Count == 0) {
        Order.Delete(modifiedOrder.OrderId);
      }
      Response.Redirect("~/cart.aspx");
    }
    
    #endregion
    
    #region Methods
    
    #region Protected

    /// <summary>
    /// Gets the formatted amount.
    /// </summary>
    /// <param name="pricePaid">The price paid.</param>
    /// <returns></returns>
    protected string GetFormattedAmount(string pricePaid) {
      return StoreUtility.GetFormattedAmount(pricePaid, true);
    }
    
    #endregion
    
    #endregion
    
  }
}
