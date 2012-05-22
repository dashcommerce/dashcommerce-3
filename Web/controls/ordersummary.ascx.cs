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
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Services.ShippingService;
using MettleSystems.dashCommerce.Store.Web;

namespace MettleSystems.dashCommerce.Web.controls {
  public partial class ordersummary : System.Web.UI.UserControl {

    #region Member Variables

    private Order _order;
    private bool _isEditable = false;

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      if (this.Order != null) {
        LoadOrder();
        GetShippingRates();
      }
    }

    /// <summary>
    /// Handles the Click event of the lbDelete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.CommandEventArgs"/> instance containing the event data.</param>
    protected void lbDelete_Click(object sender, CommandEventArgs e) {
      int orderItemId = 0;
      int.TryParse(e.CommandArgument.ToString(), out orderItemId);
      if (orderItemId > 0) {
        Order modifiedOrder = new OrderController().FetchOrder(WebUtility.GetUserName());
        new OrderController().RemoveItem(modifiedOrder.OrderId, orderItemId, WebUtility.GetUserName());
        if (modifiedOrder.OrderItemCollection.Count == 0) {
          Order.Delete(modifiedOrder.OrderId);
        }
      }
      Response.Redirect("~/cart.aspx", true);
    }

    /// <summary>
    /// Handles the ItemDataBound event of the rptrCart control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.RepeaterItemEventArgs"/> instance containing the event data.</param>
    void rptrCart_ItemDataBound(object sender, RepeaterItemEventArgs e) {
      OrderItem orderItem = e.Item.DataItem as OrderItem;
      Product product = new Product(orderItem.ProductId);
      TextBox quantityTextBox = e.Item.FindControl("txtQuantity") as TextBox;
      DropDownList quantityDropDownList = e.Item.FindControl("ddlQuantity") as DropDownList;
      FilteredTextBoxExtender filteredTextBoxExtender = e.Item.FindControl("ftbeQuantity") as FilteredTextBoxExtender;
      if (quantityTextBox != null) {
        if(this.IsEditable) {
          if(product.AllowNegativeInventories) {
            quantityDropDownList.Visible = false;
            quantityTextBox.Text = orderItem.Quantity.ToString();
          }
          else {
            quantityTextBox.Visible = false;
            filteredTextBoxExtender.Enabled = false;
            Sku sku = new Sku("Sku", orderItem.Sku);
            for(int i = 1;i <= sku.Inventory;i++) {
              quantityDropDownList.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            //Inventory may have changed, so try to set it, but we may have to reset it
            if(quantityDropDownList.Items.FindByValue(orderItem.Quantity.ToString()) != null) {
              quantityDropDownList.SelectedValue = orderItem.Quantity.ToString();
            }
            else {
              quantityDropDownList.SelectedIndex = 0;
            }
          }
        }
        else {
          quantityDropDownList.Visible = false;
          quantityTextBox.Text = orderItem.Quantity.ToString();
          quantityTextBox.CssClass = "readOnly";
          quantityTextBox.ReadOnly = true;
        }
      }
    }

    protected void ddlShipping_SelectedIndexChanged(object sender, EventArgs e) {
      lblShippingAmount.Text = StoreUtility.GetFormattedAmount(decimal.Parse(ddlShipping.SelectedValue), true);

      string subTotal = lblSubTotalAmount.Text.Replace(',', '.');      
      subTotal = Regex.Replace(subTotal, @"[^\d\.]", "");

      string shipping = lblShippingAmount.Text.Replace(',', '.');
      shipping = Regex.Replace(shipping, @"[^\d\.]", "");

      lblTotalAmount.Text = StoreUtility.GetFormattedAmount(decimal.Parse(subTotal) + decimal.Parse(shipping), true);
    }

    #endregion

    #region Methods

    #region Public

    /// <summary>
    /// Loads the order.
    /// </summary>
    public void LoadOrder () {
      rptrCart.DataSource = this.Order.OrderItemCollection;
      rptrCart.ItemDataBound += new RepeaterItemEventHandler(rptrCart_ItemDataBound);
      rptrCart.DataBind();

      lblSubTotalAmount.Text = StoreUtility.GetFormattedAmount(this.Order.SubTotal, true);

      if (this.Order.DiscountAmount > 0) {
        lblCouponAmount.Text = "-" + StoreUtility.GetFormattedAmount(this.Order.DiscountAmount, true);
      }
      else {
        lblCouponAmount.Text = StoreUtility.GetFormattedAmount(this.Order.DiscountAmount, true);
      }

      lblTaxAmount.Text = StoreUtility.GetFormattedAmount(this.Order.TaxTotal, true);

      lblShippingAmount.Text = StoreUtility.GetFormattedAmount(this.Order.ShippingAmount, true);

      lblTotalAmount.Text = StoreUtility.GetFormattedAmount(this.Order.Total, true);
    }

    #endregion

    #region Protected

    /// <summary>
    /// Gets the formatted amount.
    /// </summary>
    /// <param name="pricePaid">The price paid.</param>
    /// <returns></returns>
    protected string GetFormattedAmount (string pricePaid) {
      return StoreUtility.GetFormattedAmount(pricePaid, true);
    }

    /// <summary>
    /// Gets the delete text.
    /// </summary>
    /// <returns></returns>
    protected string GetDeleteText () {
      return LocalizationUtility.GetText("lblDelete");
    }

    #endregion

    #region Private

    /// <summary>
    /// Gets the shipping rates.
    /// </summary>
    private void GetShippingRates() {
      if (!ThisPage.SiteSettings.DisplayShippingOnCart || this.Order.ShippingAmount > 0 || Request.Url.AbsolutePath.Contains("checkout.aspx")) {
        lblShippingAmount.Text = StoreUtility.GetFormattedAmount(this.Order.ShippingAmount, true);
        lblTotalAmount.Text = StoreUtility.GetFormattedAmount(this.Order.Total, true);
      }
      else {
        // Get Shipping Options
        ShippingOptionCollection shippingOptionCollection = OrderController.FetchShippingOptions(this.Order);
        if (shippingOptionCollection.Count > 0) {
          if (shippingOptionCollection.Count > 1) {
            ddlShipping.Visible = true;
            foreach (ShippingOption shippingOption in shippingOptionCollection) {
              ddlShipping.Items.Add(new ListItem(shippingOption.Service, shippingOption.Rate.ToString()));
            }
          }
          lblShippingAmount.Text = StoreUtility.GetFormattedAmount(shippingOptionCollection[0].Rate.ToString(), true);
          lblTotalAmount.Text = StoreUtility.GetFormattedAmount(this.Order.Total + shippingOptionCollection[0].Rate, true);
        }
        else {
          lblShippingAmount.Text = StoreUtility.GetFormattedAmount(this.Order.ShippingAmount, true);
          lblTotalAmount.Text = StoreUtility.GetFormattedAmount(this.Order.Total, true);
        }
      }
    }


    #endregion

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the order.
    /// </summary>
    /// <value>The order.</value>
    public Order Order {
      get {
        return _order;
      }
      set {
        _order = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is editable.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is editable; otherwise, <c>false</c>.
    /// </value>
    public bool IsEditable {
      get {
        return _isEditable;
      }
      set {
        _isEditable = value;
      }
    }

    /// <summary>
    /// Gets the repeater.
    /// </summary>
    /// <value>The repeater.</value>
    public Repeater Repeater {
      get {
        return rptrCart;
      }
    }

    /// <summary>
    /// Gets this page.
    /// </summary>
    /// <value>The this page.</value>
    public SitePage ThisPage {
      get {
        return this.Page as SitePage;
      }
    }

    #endregion
  }
}