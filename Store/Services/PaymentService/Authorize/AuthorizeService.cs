#region Copyright / License

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
using System.Text;
using System.Web;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Store;

namespace MettleSystems.dashCommerce.Store.Services.PaymentService.AuthorizeNET {

  public class AuthorizeService {

    #region Constants

    private static readonly string AUTHORIZENET = "AuthorizeNet";

    #endregion

    #region Member Variables

    private string apiUserName;
    private string apiTransactionKey;
    private bool isInTestMode;
    private bool isLive;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="T:AuthorizeService"/> class.
    /// </summary>
    private AuthorizeService() {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:AuthorizeService"/> class.
    /// </summary>
    /// <param name="apiUserName">Name of the API user.</param>
    /// <param name="apiTransactionKey">The API transaction key.</param>
    /// <param name="isLive">if set to <c>true</c> [is live].</param>
    public AuthorizeService(string apiUserName, string apiTransactionKey, bool isInTestMode, bool isLive) {
      this.ApiUserName = apiUserName;
      this.ApiTransactionKey = apiTransactionKey;
      this.IsInTestMode = isInTestMode;
      this.IsLive = isLive;
    }

    #endregion

    #region Methods

    #region Internal

    /// <summary>
    /// Charges the specified order.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <returns></returns>
    internal Transaction Charge(Order order) {

      /*
       * Minimum Requirements
       * x_version
       * x_login
       * x_tran_key
       * x_type
       * x_amount
       * x_card_num
       * x_exp_date
       * x_trans_id**
       * x_auth_code**
       */
      
      StringBuilder sb = new StringBuilder();
      string postData = string.Empty;
      Currency currency = new Currency();

      #region Order Info

      #region Best Practice Fields

      GetBestPracticeFields(sb, AuthorizeNetTransactionType.AUTH_CAPTURE);

      #endregion

      sb.AppendFormat("&x_customer_ip={0}", HttpUtility.UrlEncode(order.IPAddress));
      sb.AppendFormat("&x_invoice_num={0}", HttpUtility.UrlEncode(order.OrderNumber));
      sb.AppendFormat("&x_amount={0}", HttpUtility.UrlEncode(GetFormattedAmount(currency, order.Total).ToString()));
      sb.AppendFormat("&x_freight={0}", HttpUtility.UrlEncode(GetFormattedAmount(currency, order.ShippingAmount).ToString()));
      sb.AppendFormat("&x_tax={0}", HttpUtility.UrlEncode(GetFormattedAmount(currency, order.TaxTotal).ToString()));

      #endregion

      #region Billing Info
      if (order.BillingAddress != null) {
        sb.AppendFormat("&x_email={0}", HttpUtility.UrlEncode(order.BillingAddress.Email));
        sb.AppendFormat("&x_phone={0}", HttpUtility.UrlEncode(order.BillingAddress.Phone));
        sb.AppendFormat("&x_first_name={0}", HttpUtility.UrlEncode(order.BillingAddress.FirstName));
        sb.AppendFormat("&x_last_name={0}", HttpUtility.UrlEncode(order.BillingAddress.LastName));
        sb.AppendFormat("&x_address={0}", HttpUtility.UrlEncode(order.BillingAddress.Address1));
        sb.AppendFormat("&x_city={0}", HttpUtility.UrlEncode(order.BillingAddress.City));
        sb.AppendFormat("&x_state={0}", HttpUtility.UrlEncode(order.BillingAddress.StateOrRegion));
        sb.AppendFormat("&x_zip={0}", HttpUtility.UrlEncode(order.BillingAddress.PostalCode));
        sb.AppendFormat("&x_country={0}", HttpUtility.UrlEncode(order.BillingAddress.Country));
      }

      #endregion

      #region Shipping Info

      if (order.ShippingAddress != null) {
        sb.AppendFormat("&x_ship_to_first_name={0}", HttpUtility.UrlEncode(order.ShippingAddress.FirstName));
        sb.AppendFormat("&x_ship_to_last_name={0}", HttpUtility.UrlEncode(order.ShippingAddress.LastName));
        sb.AppendFormat("&x_ship_to_address={0}", HttpUtility.UrlEncode(order.ShippingAddress.Address1));
        sb.AppendFormat("&x_ship_to_city={0}", HttpUtility.UrlEncode(order.ShippingAddress.City));
        sb.AppendFormat("&x_ship_to_state={0}", HttpUtility.UrlEncode(order.ShippingAddress.StateOrRegion));
        sb.AppendFormat("&x_ship_to_zip={0}", HttpUtility.UrlEncode(order.ShippingAddress.PostalCode));
        sb.AppendFormat("&x_ship_to_country={0}", HttpUtility.UrlEncode(order.ShippingAddress.Country));
      }

      #endregion

      #region Line Items

      AppendLineItems(order, sb, currency);

      #endregion

      #region Credit Card Info

      //x_exp_date
      //x_card_num
      //x_card_code

      string expDate = string.Empty;
      if (order.CreditCardExpirationMonth < 10) {
        expDate = "0" + order.CreditCardExpirationMonth.ToString();
      }
      else {
        expDate = order.CreditCardExpirationMonth.ToString();
      }
      if (order.CreditCardExpirationYear > 99) {
        expDate += order.CreditCardExpirationYear.ToString().Substring(2, 2);
      }
      else {
        expDate += order.CreditCardExpirationYear.ToString();
      }
      sb.AppendFormat("&x_exp_date={0}", HttpUtility.UrlEncode(expDate));
      sb.AppendFormat("&x_card_num={0}", HttpUtility.UrlEncode(order.CreditCardNumber));
      sb.AppendFormat("&x_card_code={0}", HttpUtility.UrlEncode(order.CreditCardSecurityNumber));
      //If the charge fails the first time thru, then we will have some data populated, so we need to try to remove it first
      if (order.ExtendedProperties.Contains("Validator")) {
        order.ExtendedProperties.Remove("Validator");
      }
      if (order.ExtendedProperties.Contains("ExpDate")) {
        order.ExtendedProperties.Remove("ExpDate");
      }
      //now, add them back in
      order.ExtendedProperties.Add("Validator", order.CreditCardNumber.ToString().Substring((order.CreditCardNumber.Length-4)));
      order.ExtendedProperties.Add("ExpDate", expDate);
      order.AdditionalProperties = order.ExtendedProperties.ToXml();
      order.Save("System");

      #endregion

      #region Charge It

      //postData = HttpUtility.UrlEncode(sb.ToString());
      postData = sb.ToString();
      string response = CoreUtility.SendRequestByPost(AuthorizeServiceUtility.GetAuthorizeServiceEndpoint(this.IsLive), postData);

      #endregion

      #region Check it and Build up the Transaction

      string[] output = response.Split('|');

      int counter = 1;//Start @ 1 to keep in sync with docs
      System.Collections.Hashtable vars = new System.Collections.Hashtable();

      foreach (string var in output) {
        vars.Add(counter, var);
        counter += 1;
      }

      Transaction transaction = null;
      string responseCode = vars[1].ToString();
      if ((responseCode == "2") || (responseCode == "3")) {
        throw new AuthorizeNetServiceException(vars[4].ToString());
      }
      else {
        transaction = new Transaction();
        transaction.OrderId = order.OrderId;
        transaction.TransactionTypeDescriptorId = (int)TransactionType.Charge;
        transaction.PaymentMethod = order.CreditCardType.ToString();
        transaction.GatewayName = AUTHORIZENET;
        transaction.GatewayResponse = vars[1].ToString();
        transaction.GatewayTransactionId = vars[7].ToString();
        transaction.AVSCode = vars[6].ToString();
        transaction.CVV2Code = vars[39].ToString();
        decimal grossAmount = 0.00M;
        bool isParsed = decimal.TryParse(vars[10].ToString(), out grossAmount);
        transaction.GrossAmount = grossAmount;
        transaction.TransactionDate = DateTime.Now;
        transaction.Save("System");
      }

      #endregion
      return transaction;
    }


    /// <summary>
    /// Refunds the specified order.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <returns></returns>
    internal Transaction Refund(Transaction transaction, Order order) {
      StringBuilder sb = new StringBuilder();
      string postData = string.Empty;
      Currency currency = new Currency();

      #region Best Practice Fields

      GetBestPracticeFields(sb, AuthorizeNetTransactionType.CREDIT);

      #endregion

      #region Refund Fields

      sb.AppendFormat("&x_trans_id={0}", HttpUtility.UrlEncode(transaction.GatewayTransactionId));
      //We need to get the parent order because it has the ExtendedProperty we need.
      //TODO: CMC - If we keep the full info, it needs to be encrypted.
      Order parentOrder = new Order(transaction.OrderId);
      sb.AppendFormat("&x_card_num={0}", HttpUtility.UrlEncode(parentOrder.ExtendedProperties["Validator"].ToString()));   //.Substring((parentOrder.ExtendedProperties["AuthorizeNetRefundValidator"].ToString().Length - 4))));
      sb.AppendFormat("&x_exp_date={0}", HttpUtility.UrlEncode(parentOrder.ExtendedProperties["ExpDate"].ToString()));
      //sb.AppendFormat("&x_card_code={0}", HttpUtility.UrlEncode(parentOrder.ExtendedProperties["SecNum"].ToString()));
      sb.AppendFormat("&x_amount={0}", HttpUtility.UrlEncode(GetFormattedAmount(currency, order.Total).ToString()));

      #endregion

      #region Line Items

      AppendLineItems(order, sb, currency);
      //foreach (OrderItem orderItem in order.OrderItemCollection) {
      //  //Sku, Name, Description, Quantity, Unit Price, Taxable 
      //  sb.AppendFormat("&x_line_item={0}<|>{1}<|>{2}<|>{3}<|>{4}<|>{5}", HttpUtility.UrlEncode(orderItem.Sku), HttpUtility.UrlEncode(orderItem.Name), HttpUtility.UrlEncode(orderItem.Attributes), HttpUtility.UrlEncode(orderItem.Quantity.ToString()), HttpUtility.UrlEncode(GetFormattedAmount(currency, orderItem.PricePaid).ToString()), HttpUtility.UrlEncode("TRUE"));
      //}

      #endregion

      #region Refund it

      postData = sb.ToString();
      string response = CoreUtility.SendRequestByPost(AuthorizeServiceUtility.GetAuthorizeServiceEndpoint(this.IsLive), postData);

      #endregion

      #region Check it and Build up the Transaction

      string[] output = response.Split('|');

      int counter = 1;//Start @ 1 to keep in sync with docs
      System.Collections.Hashtable vars = new System.Collections.Hashtable();

      foreach (string var in output) {
        vars.Add(counter, var);
        counter += 1;
      }

      Transaction refundTransaction = null;
      string responseCode = vars[1].ToString();
      if ((responseCode == "2") || (responseCode == "3")) {
        throw new AuthorizeNetServiceException(vars[4].ToString());// + " :: " + postData);
      }
      else {
        refundTransaction = new Transaction();
        refundTransaction.OrderId = transaction.OrderId;
        refundTransaction.TransactionTypeDescriptorId = (int)TransactionType.Refund;
        refundTransaction.PaymentMethod = transaction.PaymentMethod;
        refundTransaction.GatewayName = AUTHORIZENET;
        refundTransaction.GatewayResponse = vars[1].ToString();
        refundTransaction.GatewayTransactionId = vars[7].ToString();
        refundTransaction.AVSCode = vars[6].ToString();
        refundTransaction.CVV2Code = vars[39].ToString();
        decimal grossAmount = 0.00M;
        bool isParsed = decimal.TryParse(vars[10].ToString(), out grossAmount);
        refundTransaction.GrossAmount = grossAmount;
        refundTransaction.TransactionDate = DateTime.Now;
      }

      #endregion

      return refundTransaction;
    }

    #endregion

    #region Private

    private void GetBestPracticeFields(StringBuilder sb, AuthorizeNetTransactionType authorizeNetTransactionType) {
      sb.AppendFormat("x_version={0}", HttpUtility.UrlEncode(AuthorizeServiceUtility.AuthorizeNetVersionNumber));
      sb.AppendFormat("&x_delim_data={0}", HttpUtility.UrlEncode("TRUE"));
      sb.AppendFormat("&x_delim_char={0}", HttpUtility.UrlEncode("|"));
      sb.AppendFormat("&x_relay_response={0}", HttpUtility.UrlEncode("FALSE"));
      sb.AppendFormat("&x_type={0}", HttpUtility.UrlEncode(authorizeNetTransactionType.ToString()));
      bool testRequest = this.IsInTestMode;
      sb.AppendFormat("&x_test_request={0}", HttpUtility.UrlEncode(testRequest.ToString().ToUpper()));
      sb.AppendFormat("&x_login={0}", HttpUtility.UrlEncode(this.ApiUserName));
      sb.AppendFormat("&x_tran_key={0}", HttpUtility.UrlEncode(this.ApiTransactionKey));
    }

    /// <summary>
    /// Appends the line items.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <param name="sb">The sb.</param>
    private static void AppendLineItems(Order order, StringBuilder sb, Currency currency) {
      string sku = string.Empty;
      string name = string.Empty;
      string description = string.Empty;
      foreach (OrderItem orderItem in order.OrderItemCollection) {
        //Sku, Name, Description, Quantity, Unit Price, Taxable 
        if (!string.IsNullOrEmpty(orderItem.Sku)) {
          sku = orderItem.Sku.Length < 31 ? orderItem.Sku : orderItem.Sku.Substring(0, 30);
        }
        if (!string.IsNullOrEmpty(orderItem.Name)) {
          name = orderItem.Name.Length < 31 ? orderItem.Name : orderItem.Name.Substring(0, 30);
        }
        if (!string.IsNullOrEmpty(orderItem.Attributes)) {
          description = orderItem.Attributes.Length < 255 ? orderItem.Attributes : orderItem.Attributes.Substring(0, 254);
        }
        sb.AppendFormat("&x_line_item={0}<|>{1}<|>{2}<|>{3}<|>{4}<|>{5}", HttpUtility.UrlEncode(sku), HttpUtility.UrlEncode(name), HttpUtility.UrlEncode(description), HttpUtility.UrlEncode(orderItem.Quantity.ToString()), HttpUtility.UrlEncode(GetFormattedAmount(currency, orderItem.PricePaid).ToString()), HttpUtility.UrlEncode("TRUE"));
      }
    }


    /// <summary>
    /// Gets the order total.
    /// </summary>
    /// <param name="currency">The currency.</param>
    /// <param name="order">The order.</param>
    /// <returns></returns>
    private static decimal GetFormattedAmount(Currency currency, decimal amount) {
      return decimal.Round(amount, currency.CurrencyDecimals);
    }

    #endregion

    #endregion

    #region Properties

    public string ApiUserName {
      get {
        return apiUserName;
      }
      set {
        apiUserName = value;
      }
    }

    public string ApiTransactionKey {
      get {
        return apiTransactionKey;
      }
      set {
        apiTransactionKey = value;
      }
    }

    public bool IsInTestMode {
      get {
        return isInTestMode;
      }
      set {
        isInTestMode = value;
      }
    }

    public bool IsLive {
      get {
        return isLive;
      }
      set {
        isLive = value;
      }
    }

    #endregion

  }
}
