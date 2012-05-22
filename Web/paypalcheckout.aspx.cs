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
using System.Linq;
using System.Web.UI.WebControls;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Services.CouponService;
using MettleSystems.dashCommerce.Store.Services.ShippingService;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web {
  public partial class paypalcheckout : MettleSystems.dashCommerce.Store.Web.SitePage {

    #region Member Variables

    private Order order;
    protected bool hasCoupons = true;
    protected ShippingService shippingService;
    private CouponCollection couponCollection;

    #endregion

    #region Page Events

    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Init"></see> event to initialize the page.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected override void OnInit(EventArgs e) {
      Label lblBillingInformation = acCheckout.Panes[0].FindControl("lblBillingInformation") as Label;
      Label lblShippingInformation = acCheckout.Panes[1].FindControl("lblShippingInformation") as Label;
      Label lblShippingMethod = acCheckout.Panes[2].FindControl("lblShippingMethod") as Label;
      Label lblCouponInformation = acCheckout.Panes[3].FindControl("lblCouponInformation") as Label;
      Label lblOrderReview = acCheckout.Panes[4].FindControl("lblOrderReview") as Label;


      //See if there are any coupons in the system
      //If not, then don't display the coupon stuff
      couponCollection = new CouponController().FetchAll();
      if (couponCollection.Count == 0) {
        hasCoupons = false;
        acpCoupon.Visible = false;
        pnlCouponInformationDisplayTitle.Visible = false;
        pnlCouponInformationDisplay.Visible = false;
      }

      shippingService = new ShippingService();
      if (!shippingService.ShippingServiceSettings.UseShipping) {
        acCheckout.Panes[1].Visible = false;
        acCheckout.Panes[2].Visible = false;
        pnlShippingAddressDisplayTitle.Visible = false;
        pnlShippingAddressDisplay.Visible = false;
        pnlShippingMethodDisplayTitle.Visible = false;
        pnlShippingMethodDisplay.Visible = false;
      }

      order = new OrderController().FetchOrder(WebUtility.GetUserName());

      if (!Page.IsPostBack) {
        SetBillingAddressDisplay();

        SetShippingAddressDisplay();

        SetShippingMethodDisplay();

        SetCouponDisplay();
      }

      base.OnInit(e);
    }

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      if (order.OrderItemCollection == null || order.OrderItemCollection.Count <= 0) {
        Response.Redirect("~/cart.aspx", true);
      }
      Page.Title = string.Format(WebUtility.MainTitleTemplate, Master.SiteSettings.SiteName, LocalizationUtility.GetText("titleCheckout"));
      SetCheckoutProperties();
      if (!shippingService.ShippingServiceSettings.UseShipping) {
        chkUseForShipping.Visible = false;
      }

      orderSummary.Order = order;
      SetProcessOrderEnablement();
    }

    private void SetProcessOrderEnablement() {
      var visiblePaneCount = acCheckout.Panes.Count(panes => panes.Visible);
      if (acCheckout.SelectedIndex == (visiblePaneCount - 1)) {
        btnProcessOrder.Enabled = true;
      }
    }

    /// <summary>
    /// Handles the PreRender event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_PreRender(object sender, EventArgs e) {
      upDisplay.ProgressTemplate = new OrderProgressTemplate();
    }

    /// <summary>
    /// Handles the Click event of the btnBillingAddress control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnBillingAddress_Click(object sender, EventArgs e) {
      //First, get the BillingAddress squared away
      Address address = new Address();
      if (!billingAddress.NewAddressPanel.Visible) {
        //From the ddl
        Guid selectedAddress = new Guid(billingAddress.AddressList.SelectedValue);
        address = WebProfile.Current.AddressCollection.Find(
          addressToFind =>
          addressToFind.AddressId == selectedAddress && addressToFind.AddressType == AddressType.BillingAddress);
      }
      else {
        if (!string.IsNullOrEmpty(billingAddress.AddressId)) {
          //They are editing an existing address
          Guid selectedAddress = new Guid(billingAddress.AddressId);
          address = WebProfile.Current.AddressCollection.Find(
            addressToFind =>
            addressToFind.AddressId == selectedAddress && addressToFind.AddressType == AddressType.BillingAddress);
          if (address.AddressId != Guid.Empty) {
            //go ahead and remove it - we are just going to add it with the updated info
            WebProfile.Current.AddressCollection.Remove(address);
          }
        }
        address.FirstName = billingAddress.FirstName;
        address.LastName = billingAddress.LastName;
        address.Phone = billingAddress.Phone;
        address.Email = billingAddress.Email;
        address.Address1 = billingAddress.Address1;
        address.Address2 = billingAddress.Address2;
        address.City = billingAddress.City;
        address.StateOrRegion = billingAddress.StateOrRegion;
        address.PostalCode = billingAddress.PostalCode;
        address.Country = billingAddress.Country;
        address.UserName = WebUtility.GetUserName();
        address.AddressType = AddressType.BillingAddress;
        WebProfile.Current.AddressCollection.Add(address);
        WebProfile.Current.Save();
        //set the id so we can get it to determine if it's an edit or not
        billingAddress.AddressId = address.AddressId.ToString();
      }

      order.BillToAddress = address.ToXml();
      order.Save(WebUtility.GetUserName());

      SetBillingAddressDisplay();

      //Second, check to see if we are using it for shipping as well
      if (chkUseForShipping.Checked) {
        if (billingAddress.NewAddressPanel.Visible) {
          shippingAddress.NewAddressPanel.Visible = true;
          //copy over the info
          shippingAddress.AddressId = billingAddress.AddressId;
          shippingAddress.FirstName = billingAddress.FirstName;
          shippingAddress.LastName = billingAddress.LastName;
          shippingAddress.Phone = billingAddress.Phone;
          shippingAddress.Email = billingAddress.Email;
          shippingAddress.Address1 = billingAddress.Address1;
          shippingAddress.Address2 = billingAddress.Address2;
          shippingAddress.City = billingAddress.City;
          shippingAddress.StateOrRegion = billingAddress.StateOrRegion;
          shippingAddress.PostalCode = billingAddress.PostalCode;
          shippingAddress.Country = billingAddress.Country;
        }
        //We need to see if its already in there as a ShippingAddress and if not, add it

        //First, look it up to see if it's already in the Shipping Address list

        //We keep the ID the same, just changing the AddressType, so search based on ID 
        //is ok because the lists are sorted by AddressType when loaded
        ListItem itsInThere = shippingAddress.AddressList.Items.FindByValue(address.AddressId.ToString());
        if (itsInThere == null) {
          //then add it
          Address shipAddress = new Address(address);
          shipAddress.AddressType = AddressType.ShippingAddress;
          WebProfile.Current.AddressCollection.Add(shipAddress);
          WebProfile.Current.Save();
          //now, reload the addresses
          shippingAddress.LoadAddresses();
        }
        //set the shipping address as selected
        shippingAddress.AddressList.ClearSelection();
        shippingAddress.AddressList.Items.FindByValue(address.AddressId.ToString()).Selected = true;

        //set the order shipping address
        order.ShippingAmount = 0;
        order.ShipToAddress = address.ToXml();
        order.Save(WebUtility.GetUserName());

        SetShippingAddressDisplay();
      }
      SetProcessOrderEnablement();
    }

    /// <summary>
    /// Handles the Click event of the btnShippingAddress control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnShippingAddress_Click(object sender, EventArgs e) {
      Address address = new Address();
      if (!shippingAddress.NewAddressPanel.Visible) {
        Guid selectedAddress = new Guid(shippingAddress.AddressList.SelectedValue);
        address = WebProfile.Current.AddressCollection.Find(
          addressToFind =>
          addressToFind.AddressId == selectedAddress && addressToFind.AddressType == AddressType.ShippingAddress);
      }
      else {
        if (!string.IsNullOrEmpty(shippingAddress.AddressId)) {
          //They are editing an existing address
          Guid selectedAddress = new Guid(shippingAddress.AddressId);
          address = WebProfile.Current.AddressCollection.Find(
            addressToFind =>
            addressToFind.AddressId == selectedAddress && addressToFind.AddressType == AddressType.ShippingAddress);
          if (address.AddressId != Guid.Empty) {
            //go ahead and remove it - we are just going to add it with the updated info
            WebProfile.Current.AddressCollection.Remove(address);
          }
        }
        address.FirstName = shippingAddress.FirstName;
        address.LastName = shippingAddress.LastName;
        address.Phone = shippingAddress.Phone;
        address.Email = shippingAddress.Email;
        address.Address1 = shippingAddress.Address1;
        address.Address2 = shippingAddress.Address2;
        address.City = shippingAddress.City;
        address.StateOrRegion = shippingAddress.StateOrRegion;
        address.PostalCode = shippingAddress.PostalCode;
        address.Country = shippingAddress.Country;
        address.UserName = WebUtility.GetUserName();
        address.AddressType = AddressType.ShippingAddress;
        WebProfile.Current.AddressCollection.Add(address);
        WebProfile.Current.Save();
        //set the id so we can get it to determine if it's an edit or not
        shippingAddress.AddressId = address.AddressId.ToString();
      }
      order.ShippingAmount = 0;
      order.ShipToAddress = address.ToXml();
      order.Save(WebUtility.GetUserName());
      SetShippingAddressDisplay();
      SetProcessOrderEnablement();
    }

    /// <summary>
    /// Handles the Click event of the btnShippingMethod control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnShippingMethod_Click(object sender, EventArgs e) {
      if (rblShippingOptions.Items.Count > 0) {
        decimal shippingAmount = 0;
        decimal.TryParse(rblShippingOptions.SelectedValue, out shippingAmount);
        OrderController.SetShipping(WebUtility.GetUserName(), shippingAmount, rblShippingOptions.SelectedItem.Text);
        OrderController.CalculateTax(WebUtility.GetUserName());
        lblShippingMethodDisplay.Text = rblShippingOptions.SelectedItem.Text;
        if (hasCoupons) {
          SetCouponDisplay();
          acCheckout.SelectedIndex = acCheckout.SelectedIndex + 1;
        }
        else {
          acCheckout.SelectedIndex = acCheckout.SelectedIndex + 1;
        }
      }
      else {
        Logger.Information("No Shipping Options");
      }
      //reload the order
      orderSummary.Order = new OrderController().FetchOrder(WebUtility.GetUserName());
      orderSummary.LoadOrder();
      SetProcessOrderEnablement();
    }

    /// <summary>
    /// Handles the Click event of the btnCoupon control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnCoupon_Click(object sender, EventArgs e) {
      if (!string.IsNullOrEmpty(txtCouponCode.Text)) {
        CouponService couponService = new CouponService();
        couponService.ApplyCoupon(txtCouponCode.Text, order);
        lblCouponInformationDisplay.Text = StoreUtility.GetFormattedAmount(order.DiscountAmount, true);
        ReloadOrder();
      }
      else {
        foreach (OrderItem orderItem in order.OrderItemCollection) {
          orderItem.DiscountAmount = 0.00M;
          orderItem.Save("CouponService");
        }
        lblCouponInformationDisplay.Text = StoreUtility.GetFormattedAmount(0.00M, true);
      }
      //re-calculate the tax
      OrderController.CalculateTax(WebUtility.GetUserName());
      //reload the order
      orderSummary.Order = new OrderController().FetchOrder(WebUtility.GetUserName());
      orderSummary.LoadOrder();
      acCheckout.SelectedIndex = acCheckout.SelectedIndex + 1;
      SetProcessOrderEnablement();
    }

    /// <summary>
    /// Handles the Click event of the btnProcessOrder control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnProcessOrder_Click(object sender, EventArgs e) {
      order.IPAddress = Request.UserHostAddress == "::1" || Request.UserHostAddress == "127.0.0.1" ? "127.0.0.1" : Request.UserHostAddress;
      order.Save(WebUtility.GetUserName());

      string returnUrl = Utility.GetSiteRoot() + "/paypal/pdthandler.aspx";
      string cancelUrl = Utility.GetSiteRoot() + "/paypalcheckout.aspx";
      string notifyUrl = Utility.GetSiteRoot() + "/paypal/ipnhandler.aspx";

      string url = OrderController.CreateCartUrl(order, returnUrl, cancelUrl, notifyUrl);
      if (!string.IsNullOrEmpty(url)) {
        Response.Redirect(url, true);
      }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Reloads the order.
    /// </summary>
    private void ReloadOrder() {
      order = new OrderController().FetchOrder(WebUtility.GetUserName());
      orderSummary.Order = order;
      orderSummary.LoadOrder();
    }

    /// <summary>
    /// Sets the bill to address display.
    /// </summary>
    private void SetBillingAddressDisplay() {
      if (!string.IsNullOrEmpty(order.BillToAddress)) {
        billingAddressDisplay.Address = order.BillingAddress;
        billingAddressDisplay.DisplayAddress();
        billingAddress.SelectedAddress = order.BillingAddress.AddressId.ToString();
        cpeBillingAddressDisplay.Collapsed = false;
        acCheckout.SelectedIndex = acCheckout.SelectedIndex + 1;
      }
    }

    /// <summary>
    /// Sets the ship to address display.
    /// </summary>
    private void SetShippingAddressDisplay() {
      if (!string.IsNullOrEmpty(order.ShipToAddress) && shippingService.ShippingServiceSettings.UseShipping) {
        shippingAddressDisplay.Address = order.ShippingAddress;
        shippingAddressDisplay.DisplayAddress();
        shippingAddress.SelectedAddress = order.ShippingAddress.AddressId.ToString();
        cpeShippingAddressDisplay.Collapsed = false;
        acCheckout.SelectedIndex = acCheckout.SelectedIndex + 1;
        GetShippingRates();
      }
    }

    /// <summary>
    /// Sets the shipping method display.
    /// </summary>
    private void SetShippingMethodDisplay() {
      if (!string.IsNullOrEmpty(order.ShippingMethod) && shippingService.ShippingServiceSettings.UseShipping) {
        lblShippingMethodDisplay.Text = order.ShippingMethod;
        cpeShippingMethodDisplay.Collapsed = false;
        acCheckout.SelectedIndex = acCheckout.SelectedIndex + 1;
      }
    }

    /// <summary>
    /// Sets the coupon display.
    /// </summary>
    private void SetCouponDisplay() {
      if (order.DiscountAmount > 0) {
        lblCouponInformationDisplay.Text = StoreUtility.GetFormattedAmount(order.DiscountAmount, true);
        cpeCouponInformationDisplay.Collapsed = false;
        //acCheckout.SelectedIndex = acCheckout.SelectedIndex + 1; //Dont advance this because they may have adjusted the cart.
      }
    }

    /// <summary>
    /// Gets the shipping rates.
    /// </summary>
    private void GetShippingRates() {
      ShippingOptionCollection shippingOptionCollection = OrderController.FetchShippingOptions(WebUtility.GetUserName());
      rblShippingOptions.Items.Clear();
      ListItem listItem;
      foreach (ShippingOption shippingOption in shippingOptionCollection) {
        listItem = new ListItem(string.Format("{0}: {1}", shippingOption.Service, StoreUtility.GetFormattedAmount(shippingOption.Rate, true)), shippingOption.Rate.ToString());
        rblShippingOptions.Items.Add(listItem);
      }
      if (rblShippingOptions.Items.Count > 0) {
        rblShippingOptions.SelectedIndex = 0;
      }
      if (order.ShippingAmount > 0) {
        ListItem selectedItem = rblShippingOptions.Items.FindByValue(order.ShippingAmount.ToString());
        if (selectedItem != null) {
          selectedItem.Selected = true;
        }
      }
    }

    /// <summary>
    /// Sets the checkout properties.
    /// </summary>
    private void SetCheckoutProperties() {
      btnBillingAddress.Text = btnShippingAddress.Text = btnShippingMethod.Text = btnCoupon.Text = LocalizationUtility.GetText("lblContinue");
    }

    #endregion

  }
}
