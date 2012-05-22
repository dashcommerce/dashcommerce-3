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
using System.Web.UI.WebControls;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Services.CouponService;
using MettleSystems.dashCommerce.Store.Services.PaymentService;
using MettleSystems.dashCommerce.Store.Services.ShippingService;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web {
  public partial class checkout : MettleSystems.dashCommerce.Store.Web.SitePage {

    #region Constants

    private const string PAYPAL_PAYER_ID = "PayPalPayerId";
    private const string PAYPAL_TOKEN = "PayPalToken";

    #endregion

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
      if (Master.SiteSettings.LoginRequirement == LoginRequirement.Checkout) {
        if (!User.Identity.IsAuthenticated) {
          Response.Redirect("login.aspx?ReturnUrl=/checkout.aspx", true);
        }
      }

      PaymentService paymentService = new PaymentService();
      if (paymentService.PaymentServiceSettings.DefaultProvider == "PayPalStandardPaymentProvider") {
        Response.Redirect("~/paypalcheckout.aspx", true);
      }

      //Keep these here - the Accordion ViewState is funky and requires things to be set early
      Label lblBillingInformation = acCheckout.Panes[0].FindControl("lblBillingInformation") as Label;
      Label lblShippingInformation = acCheckout.Panes[1].FindControl("lblShippingInformation") as Label;
      Label lblShippingMethod = acCheckout.Panes[2].FindControl("lblShippingMethod") as Label;
      Label lblCouponInformation = acCheckout.Panes[3].FindControl("lblCouponInformation") as Label;
      Label lblPaymentInformation = acCheckout.Panes[4].FindControl("lblPaymentInformation") as Label;
      Label lblOrderReview = acCheckout.Panes[5].FindControl("lblOrderReview") as Label;

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

      //Keep these here - the Accordion ViewState is funky and requires things to be set early
      order = new OrderController().FetchOrder(WebUtility.GetUserName());

      #region PayPal Express Checkout Logic

      if (!string.IsNullOrEmpty(order.PaymentMethod)) {
        if (order.PaymentMethod == "PayPal") {
          string token = Utility.GetParameter("token");
          if (!string.IsNullOrEmpty(token)) {
            pnlCreditCardInformation.Visible = false;
            pnlCreditCardInfo.Visible = false;
            lblCreditCardType.Text = order.PaymentMethod;
            ddlCreditCardType.SelectedValue = "4";
            ddlCreditCardType.Enabled = false;
            PayPalPayer payPalPayer = OrderController.GetExpressCheckout(token);
            if (order.BillingAddress == null) {//Then they are coming in from the cart.aspx ExpressCheckout button
              //copy the PayPalPayer ShippingAddress and then flag it as a BillingAddress
              Address billingAddress = new Address(payPalPayer.ShippingAddress);
              billingAddress.AddressType = AddressType.BillingAddress;
              Address duplicateBillingAddress = WebProfile.Current.AddressCollection.Find(
                addressToFind =>
                addressToFind.ToString() == billingAddress.ToString() &&
                addressToFind.AddressType == AddressType.BillingAddress);
              if (duplicateBillingAddress == null) {
                WebProfile.Current.AddressCollection.Add(billingAddress);
                WebProfile.Current.Save();
              }
              order.BillToAddress = payPalPayer.ShippingAddress.ToXml();
            }
            if (!payPalPayer.ShippingAddress.Equals(order.ShippingAddress)) {
              Address shippingAddress = new Address(payPalPayer.ShippingAddress);
              shippingAddress.AddressType = AddressType.ShippingAddress;
              Address duplicateShippingAddress = WebProfile.Current.AddressCollection.Find(
                  addressToFind => 
                  addressToFind.ToString() == shippingAddress.ToString() &&
                  addressToFind.AddressType == AddressType.ShippingAddress);
              if (duplicateShippingAddress == null) {
                WebProfile.Current.AddressCollection.Add(shippingAddress);
                WebProfile.Current.Save();
              }
              order.ShipToAddress = payPalPayer.ShippingAddress.ToXml();
            }
            if (order.ExtendedProperties.ContainsKey(PAYPAL_PAYER_ID)) {
              order.ExtendedProperties.Remove(PAYPAL_PAYER_ID);
            }
            if (order.ExtendedProperties.ContainsKey(PAYPAL_TOKEN)) {
              order.ExtendedProperties.Remove(PAYPAL_TOKEN);
            }
            order.ExtendedProperties.Add(PAYPAL_PAYER_ID, payPalPayer.PayPalPayerId);
            order.ExtendedProperties.Add(PAYPAL_TOKEN, payPalPayer.PayPalToken);
            order.AdditionalProperties = order.ExtendedProperties.ToXml();
            order.Save(WebUtility.GetUserName());
            OrderController.CalculateTax(WebUtility.GetUserName());
            order = new OrderController().FetchOrder(WebUtility.GetUserName());
          }
        }
      }

      #endregion

      if (!Page.IsPostBack) {
        SetBillingAddressDisplay();

        SetShippingAddressDisplay();

        SetShippingMethodDisplay();

        SetCouponDisplay();

        SetPaymentMethodDisplay(-1, order.CreditCardNumber, DateTime.MinValue);
      }
      base.OnInit(e);
    }

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      Page.Title = string.Format(WebUtility.MainTitleTemplate, Master.SiteSettings.SiteName, LocalizationUtility.GetText("titleCheckout"));
      SetCheckoutProperties();
      if (!shippingService.ShippingServiceSettings.UseShipping) {
        chkUseForShipping.Visible = false;
      }
      if (!Page.IsPostBack) {
        LoadStartAndExpirationYearDropDown();
        LoadStartAndExpirationMonthDropDown();
      }
      //Set these early, so they can be overridden - they aren't used in production
      #if DEBUG
      if (!Page.IsPostBack) {
        if (order.PaymentMethod != "PayPal") {
          ddlCreditCardType.SelectedValue = "1";
          txtCreditCardNumber.Text = "4978368392614864";
          txtCreditCardSecurityNumber.Text = "027";
          int selectedMonth = (DateTime.Now.Month + 1);
          ddlCreditCardExpirationMonth.SelectedValue = selectedMonth.ToString();
          int selectedYear = (DateTime.Now.Year + 1);
          ddlCreditCardExpirationYear.SelectedValue = selectedYear.ToString();
        }
      }
      #endif
      if (Master.SiteSettings.RequireSsl) {
        WebUtility.EnsureSsl();
      }
      if (order.OrderItemCollection.Count <= 0) {
        Response.Redirect("~/cart.aspx", true);
      }

      orderSummary.Order = order;
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
      if (!billingAddress.NewAddressPanel.Visible) { //From the ddl
        Guid selectedAddress = new Guid(billingAddress.AddressList.SelectedValue);
        address = WebProfile.Current.AddressCollection.Find(
          addressToFind =>
          addressToFind.AddressId == selectedAddress && addressToFind.AddressType == AddressType.BillingAddress);
      }
      else {
        if (!string.IsNullOrEmpty(billingAddress.AddressId)) { //They are editing an existing address
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
        if (itsInThere == null) {//then add it
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
        if (!string.IsNullOrEmpty(shippingAddress.AddressId)) { //They are editing an existing address
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
    }

    /// <summary>
    /// Handles the Click event of the btnShippingMethod control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnShippingMethod_Click(object sender, EventArgs e) {
      if (rblShippingOptions.Items.Count > 0) {
        decimal shippingAmount;
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
    }

    /// <summary>
    /// Handles the Click event of the btnCoupon control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnCoupon_Click(object sender, EventArgs e) {
      if (!string.IsNullOrEmpty(txtCouponCode.Text)) {
        //apply the coupon
        CouponService couponService = new CouponService();
        couponService.ApplyCoupon(txtCouponCode.Text, order);
        //set the display
        lblCouponInformationDisplay.Text = StoreUtility.GetFormattedAmount(order.DiscountAmount, true);
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
    }

    /// <summary>
    /// Handles the Click event of the btnPaymentMethod control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnPaymentMethod_Click(object sender, EventArgs e) {
      //Loadup the cpe and validate the CC if possible
      int creditCardType;
      string maskedCreditCardNumber = string.Empty;
      DateTime expirationDate = DateTime.MinValue;
      int.TryParse(ddlCreditCardType.SelectedValue, out creditCardType);
      CreditCardType cardType = (CreditCardType)Enum.Parse(typeof(CreditCardType), ddlCreditCardType.SelectedValue);
      order.PaymentMethod = Enum.GetName(typeof(CreditCardType), creditCardType);
      order.Save(WebUtility.GetUserName());

      if (cardType == CreditCardType.PayPal) {
        if (Page.Request["token"] == null) {
          pnlCreditCardInfo.Visible = false;
          string returnUrl = Utility.GetSiteRoot() + "/checkout.aspx";
          string cancelUrl = Utility.GetSiteRoot() + "/default.aspx";
          string url = OrderController.SetExpressCheckout(order, returnUrl, cancelUrl, false);
          Response.Redirect(url, true);
        }
      }
      else {
        #if RELEASE
        if(!WebUtility.IsValidCardType(txtCreditCardNumber.Text.Trim(), cardType)) {
          throw new InvalidOperationException("Credit card number does not validate.");
        }
        #endif
        int creditCardLength = txtCreditCardNumber.Text.Trim().Length;
        if (creditCardLength > 4) {
          for (int i = 1; i <= creditCardLength - 4; i++) {
            maskedCreditCardNumber += "X";
          }
          maskedCreditCardNumber += txtCreditCardNumber.Text.Trim().Substring(creditCardLength - 4, 4);
        }
        int month, year;
        int.TryParse(ddlCreditCardExpirationYear.SelectedValue, out year);
        int.TryParse(ddlCreditCardExpirationMonth.SelectedValue, out month);
        expirationDate = new DateTime(year, month, DateTime.DaysInMonth(year, month));
        if (!shippingService.ShippingServiceSettings.UseShipping && !hasCoupons) {
          //Then we get thru without calculating tax.
          //re-calculate the tax
          OrderController.CalculateTax(WebUtility.GetUserName());
          //reload the order
          orderSummary.Order = new OrderController().FetchOrder(WebUtility.GetUserName());
          orderSummary.LoadOrder();
        }
      }
      SetPaymentMethodDisplay(creditCardType, maskedCreditCardNumber, expirationDate);
      acCheckout.SelectedIndex = acCheckout.SelectedIndex + 1;
      this.btnProcessOrder.Enabled = true;
    }

    /// <summary>
    /// Handles the Click event of the btnProcessOrder control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnProcessOrder_Click(object sender, EventArgs e) {
      try {
        Transaction transaction;
        order.CreditCardType = (CreditCardType)Enum.Parse(typeof(CreditCardType), ddlCreditCardType.SelectedValue);
        if (order.CreditCardType == CreditCardType.PayPal) {
          transaction = OrderController.DoExpressCheckout(order, false, WebUtility.GetUserName());
        }
        else {
          order.CreditCardNumber = txtCreditCardNumber.Text;
          order.CreditCardSecurityNumber = txtCreditCardSecurityNumber.Text;
          order.CreditCardExpirationMonth = int.Parse(ddlCreditCardExpirationMonth.SelectedValue);
          order.CreditCardExpirationYear = int.Parse(ddlCreditCardExpirationYear.SelectedValue);
          int startMonth, startYear;
          Int32.TryParse(ddlDebitCardStartMonth.SelectedValue, out startMonth);
          Int32.TryParse(ddlDebitCardStartYear.SelectedValue, out startYear);
          order.CreditCardStartMonth = startMonth;
          order.CreditCardStartYear = startYear;
          order.CreditCardIssueNumber = txtDebitCardIssueNumber.Text.Length > 0 ? txtDebitCardIssueNumber.Text : string.Empty;

          transaction = OrderController.Charge(order, WebUtility.GetUserName());
        }
        Response.Redirect(string.Format("~/receipt.aspx?tid={0}", transaction.TransactionId), true);
      }
      catch (PaymentServiceException pex) {
        Logger.Error(pex.Message, pex, Logger.LogMessageType.Information);
        lblError.Text = pex.Message;
        imgError.Visible = true;
        btnProcessOrder.Enabled = true;
      }
      catch (Exception ex) {
        Logger.Error(typeof(checkout).Name, ex);
        throw;
      }
    }

    /// <summary>
    /// Gets the formatted amount.
    /// </summary>
    /// <param name="pricePaid">The price paid.</param>
    /// <returns></returns>
    protected string GetFormattedAmount(string pricePaid) {
      return StoreUtility.GetFormattedAmount(pricePaid, true);
    }

    /// <summary>
    /// Toggles the credit card info.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void toggleCreditCardInfo(object sender, EventArgs e) {
      if (ddlCreditCardType.SelectedValue == "4") {
        pnlCreditCardInformation.Visible = false;
      }
      else if (ddlCreditCardType.SelectedValue == "5" || ddlCreditCardType.SelectedValue == "6") {
        pnlCreditCardInformation.Visible = true;
        pnlDebitCardInformation.Visible = true; //UK Debit Card
      }
      else {
        pnlCreditCardInformation.Visible = true;
        pnlDebitCardInformation.Visible = false;
      }
    }

    #endregion

    #region Private Methods

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
    /// Sets the payment method display.
    /// </summary>
    private void SetPaymentMethodDisplay(int creditCardType, string maskedCreditCardNumber, DateTime expirationDate) {
      if (!string.IsNullOrEmpty(order.PaymentMethod)) {
        if (creditCardType > -1) {
          lblCreditCardType.Text = Enum.GetName(typeof (CreditCardType), creditCardType);
        }
        if (creditCardType != (int) CreditCardType.PayPal) {
          if (!string.IsNullOrEmpty(maskedCreditCardNumber)) {
            lblMaskedCreditCardNumber.Text = maskedCreditCardNumber;
          }
          if (expirationDate != DateTime.MinValue) {
            lblCreditCardExpirationDate.Text = StoreUtility.GetFormattedDate(expirationDate);
          }
        }
        cpePaymentInformationDisplay.Collapsed = false;
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
    /// Loads the start and expiration month drop down.
    /// </summary>
    private void LoadStartAndExpirationMonthDropDown() {
      if (ddlCreditCardExpirationMonth != null && ddlDebitCardStartMonth != null) {
        for (int i = 1; i <= 12; i++) {
          ddlCreditCardExpirationMonth.Items.Add(new ListItem(i.ToString(), i.ToString()));
          ddlDebitCardStartMonth.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
      }
    }

    /// <summary>
    /// Loads the start and expiration year drop down.
    /// </summary>
    private void LoadStartAndExpirationYearDropDown() {
      if (ddlCreditCardExpirationYear != null & ddlDebitCardStartYear != null) {
        for (int i = DateTime.UtcNow.Year; i < DateTime.UtcNow.Year + 6; i++) {
          ddlCreditCardExpirationYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
        for (int i = DateTime.UtcNow.Year - 6; i < DateTime.UtcNow.Year + 1; i++) {
          ddlDebitCardStartYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
      }
    }

    /// <summary>
    /// Sets the checkout properties.
    /// </summary>
    private void SetCheckoutProperties() {
      btnBillingAddress.Text = btnShippingAddress.Text = btnShippingMethod.Text = btnPaymentMethod.Text = btnCoupon.Text = LocalizationUtility.GetText("lblContinue");
    }

    #endregion

  }
}
