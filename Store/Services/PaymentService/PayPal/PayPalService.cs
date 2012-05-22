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
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Core.Caching;
using MettleSystems.dashCommerce.Store.PayPalSvc;

namespace MettleSystems.dashCommerce.Store.Services.PaymentService.PayPal {
  
  public class PayPalService {

    #region Constants

    private const string PAYPAL = "PayPal";
    private const string PAYPAL_EXPRESSCHECKOUT = "PayPalPro - ExpressCheckout";
    private const string PAYPALPRO = "PayPalPro";
    private const string LOGOURL = "https://www.dashcommerce.com/logo.gif";

    #region Argument Constants

    private const string API_USERNAME = "apiUserName";
    private const string API_PASSWORD = "apiPassword";
    private const string SIGNATURE = "signature";
    private const string DEFAULT_CURRENCY_CODE = "defaultCurrencyCode";
    private const string RETURN_URL = "returnUrl";
    private const string CANCEL_URL = "cancelUrl";
    private const string PAYPAL_PAYER_ID = "PayPalPayerId";
    private const string PAYPAL_TOKEN = "PayPalToken";

    #endregion

    #endregion

    #region Member Variables

    private PayPalAPIAASoapBinding payPalAPIAASoapBinding;
    private PayPalAPISoapBinding payPalAPISoapBinding;
    private bool isLive;
    private string apiUserName;
    private string apiPassword;
    private string signature;
    private CurrencyCodeType defaultCurrencyCode;
    private bool useExpressCheckoutCommit;
    private bool enforceSellerProtectionPolicy;
    private string headerImageUrl;
    private string businessEmail;
    private string pdtId;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="T:PayPalService"/> class.
    /// </summary>
    private PayPalService() {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:PayPalService"/> class.
    /// </summary>
    /// <param name="isLive">if set to <c>true</c> [is live].</param>
    /// <param name="businessEmail">The business email.</param>
    /// <param name="pdtId">The PDT id.</param>
    public PayPalService(bool isLive, string businessEmail, string pdtId) {
      this.isLive = isLive;
      this.businessEmail = businessEmail;
      this.pdtId = pdtId;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:PayPalService"/> class.
    /// </summary>
    /// <param name="isLive">if set to <c>true</c> [is live].</param>
    /// <param name="apiUserName">Name of the API user.</param>
    /// <param name="apiPassword">The API password.</param>
    /// <param name="signature">The signature.</param>
    /// <param name="businessEmail">The business email.</param>
    /// <param name="defaultCurrencyCode">The default currency code.</param>
    public PayPalService(bool isLive, string apiUserName, string apiPassword, string signature, string businessEmail,
      string defaultCurrencyCode) : this (isLive, apiUserName, apiPassword, signature, businessEmail, defaultCurrencyCode, false, false, null) {
      
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:PayPalService"/> class.
    /// </summary>
    /// <param name="isLive">if set to <c>true</c> [is live].</param>
    /// <param name="apiUserName">Name of the API user.</param>
    /// <param name="apiPassword">The API password.</param>
    /// <param name="signature">The signature.</param>
    /// <param name="businessEmail">The business email.</param>
    /// <param name="defaultCurrencyCode">The default currency code.</param>
    /// <param name="useExpressCheckoutCommit">if set to <c>true</c> [use express checkout commit].</param>
    /// <param name="enforceSellerProtectionPolicy">if set to <c>true</c> [enforce seller protection policy].</param>
    /// <param name="headerImageUrl">The header image URL.</param>
    public PayPalService(bool isLive, string apiUserName, string apiPassword, string signature, string businessEmail,
      string defaultCurrencyCode, bool useExpressCheckoutCommit, bool enforceSellerProtectionPolicy, 
      string headerImageUrl) {
      //Validate arguments
      if (string.IsNullOrEmpty(businessEmail)) {
        Validator.ValidateStringArgumentIsNotNullOrEmptyString(apiUserName, API_USERNAME);
        Validator.ValidateStringArgumentIsNotNullOrEmptyString(apiPassword, API_PASSWORD);
        Validator.ValidateStringArgumentIsNotNullOrEmptyString(signature, SIGNATURE);
      }
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(defaultCurrencyCode, DEFAULT_CURRENCY_CODE);
      Validator.ValidateEnumIsDefined(typeof(CurrencyCodeType), defaultCurrencyCode);

      this.isLive = isLive;
      this.apiUserName = apiUserName;
      this.apiPassword = apiPassword;
      this.signature = signature;
      this.businessEmail = businessEmail;
      this.defaultCurrencyCode = (CurrencyCodeType)Enum.Parse(typeof(CurrencyCodeType), defaultCurrencyCode);
      this.useExpressCheckoutCommit = useExpressCheckoutCommit;
      this.enforceSellerProtectionPolicy = enforceSellerProtectionPolicy;
      this.headerImageUrl = headerImageUrl;

      payPalAPIAASoapBinding = new PayPalAPIAASoapBinding();
      payPalAPIAASoapBinding.Url = PayPalServiceUtility.GetPayPalServiceEndpoint(true, IsLive, true, true);
      payPalAPIAASoapBinding.RequesterCredentials = new CustomSecurityHeaderType();
      payPalAPIAASoapBinding.RequesterCredentials.Credentials = new UserIdPasswordType();
      payPalAPIAASoapBinding.RequesterCredentials.Credentials.Username = ApiUserName;
      payPalAPIAASoapBinding.RequesterCredentials.Credentials.Password = ApiPassword;
      payPalAPIAASoapBinding.RequesterCredentials.Credentials.Signature = Signature;
      payPalAPIAASoapBinding.RequesterCredentials.Credentials.Subject = this.businessEmail;

      payPalAPISoapBinding = new PayPalAPISoapBinding();
      payPalAPISoapBinding.Url = PayPalServiceUtility.GetPayPalServiceEndpoint(true, IsLive, true, true);
      payPalAPISoapBinding.RequesterCredentials = new CustomSecurityHeaderType();
      payPalAPISoapBinding.RequesterCredentials.Credentials = new UserIdPasswordType();
      payPalAPISoapBinding.RequesterCredentials.Credentials.Username = ApiUserName;
      payPalAPISoapBinding.RequesterCredentials.Credentials.Password = ApiPassword;
      payPalAPISoapBinding.RequesterCredentials.Credentials.Signature = Signature;
      payPalAPISoapBinding.RequesterCredentials.Credentials.Subject = string.Empty;
    }

    #endregion

    #region Methods

    #region Public

    #region PayPal Standard Methods

    /// <summary>
    /// Creates the cart URL.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <param name="returnUrl">The return URL.</param>
    /// <param name="cancelUrl">The cancel URL.</param>
    /// <returns></returns>
    public string CreateCartUrl(Order order, string returnUrl, string cancelUrl, string notifyUrl) {

      string finalUrl = string.Empty;

      SiteSettings siteSettings = SiteSettingCache.GetSiteSettings();
      string url = PayPalServiceUtility.GetPayPalServiceEndpoint(false, IsLive, false, false);
      string logoUrl = string.IsNullOrEmpty(siteSettings.SiteLogo) ? LOGOURL : new Uri(cancelUrl).GetLeftPart(UriPartial.Authority) + siteSettings.SiteLogo.Replace("~", "");

      StringBuilder queryString = new StringBuilder();
      queryString.Append(string.Format("?cmd=_cart&upload=1&currency_code={0}&business={1}&bn={2}", siteSettings.CurrencyCode, this.BusinessEmail, Constants.WPS_BN_ID));
      queryString.AppendFormat("&image_url={0}",CoreUtility.MakeHttpsUrl(logoUrl));
      queryString.AppendFormat("&amount={0}", HttpUtility.UrlEncode(StoreUtility.GetFormattedAmount(order.SubTotal - order.DiscountAmount, false).Replace(',', '.')));
      queryString.AppendFormat("&tax={0}", HttpUtility.UrlEncode(StoreUtility.GetFormattedAmount(order.TaxTotal, false).Replace(',', '.')));
      queryString.AppendFormat("&shipping={0}", HttpUtility.UrlEncode(StoreUtility.GetFormattedAmount(order.ShippingAmount, false).Replace(',', '.')));
      //adding shipping_1 here because of a bug on PayPal's side. I've got emails to prove it! :)
      queryString.AppendFormat("&shipping_1={0}", HttpUtility.UrlEncode(StoreUtility.GetFormattedAmount(order.ShippingAmount, false).Replace(',', '.')));
      queryString.AppendFormat("&item_name={0}", HttpUtility.UrlEncode((string.IsNullOrEmpty(siteSettings.SiteName) ? "dashCommerce" : siteSettings.SiteName) + " " + order.OrderNumber));
      if(order.ShippingAddress != null) {
        queryString.Append("&no_shipping=1");
        queryString.AppendFormat("&first_name={0}", HttpUtility.UrlEncode(order.ShippingAddress.FirstName));
        queryString.AppendFormat("&last_name={0}", HttpUtility.UrlEncode(order.ShippingAddress.LastName));
        queryString.AppendFormat("&address1={0}", HttpUtility.UrlEncode(order.ShippingAddress.Address1));
        queryString.AppendFormat("&address2={0}", HttpUtility.UrlEncode(order.ShippingAddress.Address2));
        queryString.AppendFormat("&city={0}", HttpUtility.UrlEncode(order.ShippingAddress.City));
        queryString.AppendFormat("&state={0}", HttpUtility.UrlEncode(order.ShippingAddress.StateOrRegion));
        queryString.AppendFormat("&zip={0}", HttpUtility.UrlEncode(order.ShippingAddress.PostalCode));
      }
      //Add the individual items
      int i = 1;
      foreach(OrderItem orderItem in order.OrderItemCollection) {
        queryString.AppendFormat("&item_name_{0}={1}", i, HttpUtility.UrlEncode(orderItem.Name));
        queryString.AppendFormat("&quantity_{0}={1}", i, HttpUtility.UrlEncode(orderItem.Quantity.ToString()));
        queryString.AppendFormat("&item_number_{0}={1}", i, HttpUtility.UrlEncode(orderItem.Sku));
        queryString.AppendFormat("&amount_{0}={1}", i, HttpUtility.UrlEncode(StoreUtility.GetFormattedAmount(orderItem.ItemDiscountedPrice, false).Replace(',','.')));
        queryString.AppendFormat("&tax_{0}={1}", i, HttpUtility.UrlEncode(StoreUtility.GetFormattedAmount(orderItem.ItemTax, false).Replace(',','.')));
        i++;
      }
      
      queryString.AppendFormat("&return={0}", HttpUtility.UrlEncode(returnUrl));
      queryString.Append("&rm=2");
      queryString.AppendFormat("&cancel_return={0}", HttpUtility.UrlEncode(cancelUrl));
      queryString.AppendFormat("&notify_url={0}", HttpUtility.UrlEncode(notifyUrl));
      queryString.AppendFormat("&custom={0}", HttpUtility.UrlEncode(order.OrderGuid.ToString()));
      
      finalUrl = url + queryString.ToString();
      return finalUrl;
    }

    /// <summary>
    /// Synchronizes the specified args.
    /// </summary>
    /// <param name="content">The content.</param>
    /// <returns></returns>
    public string Synchronize(string content) {

      string response = string.Empty;
      
      if (content.EndsWith("&at=")) {
        content = content + this.PdtId;
      }
      ASCIIEncoding encoding = new ASCIIEncoding();
      byte[] buffer = encoding.GetBytes(content);
            
      string url = PayPalServiceUtility.GetPayPalServiceEndpoint(false, IsLive, false, false);
      HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
      webRequest.Method = "POST";
      webRequest.ContentType = "application/x-www-form-urlencoded";
      webRequest.ContentLength = content.Length;
      
      Stream sendStream = webRequest.GetRequestStream();
      sendStream.Write(buffer, 0, buffer.Length);
      sendStream.Close();
      
      StreamReader responseStream = new StreamReader(webRequest.GetResponse().GetResponseStream());
      response = responseStream.ReadToEnd();
      responseStream.Close();
      
      response = HttpUtility.UrlDecode(response);
      return response;     
                  
    }

    #endregion

    #region ExpressCheckout Methods

    /// <summary>
    /// Returns a token from PayPal.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <param name="returnUrl">The return URL.</param>
    /// <param name="cancelUrl">The cancel URL.</param>
    /// <param name="authorizeOnly">if set to <c>true</c> [authorize only].</param>
    /// <returns>string</returns>
    internal string SetExpressCheckout(Order order, string returnUrl, string cancelUrl, bool authorizeOnly) {
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(returnUrl, RETURN_URL);
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(cancelUrl, CANCEL_URL);
      
      string token = string.Empty;
      string url = string.Empty;

      SetExpressCheckoutReq expressCheckoutRequest = new SetExpressCheckoutReq();
      SetExpressCheckoutRequestDetailsType expressCheckoutRequestDetails = new SetExpressCheckoutRequestDetailsType();
      expressCheckoutRequest.SetExpressCheckoutRequest = new SetExpressCheckoutRequestType();
      expressCheckoutRequest.SetExpressCheckoutRequest.Version = PayPalServiceUtility.PayPalVersionNumber;

      //Set the Shipping Address
      if(order.ShippingAddress != null) {
        expressCheckoutRequestDetails.Address = new PayPalSvc.AddressType();
        expressCheckoutRequestDetails.Address.Name = order.ShippingAddress.FirstName + " " + order.ShippingAddress.LastName;
        expressCheckoutRequestDetails.Address.Street1 = order.ShippingAddress.Address1;
        expressCheckoutRequestDetails.Address.Street2 = order.ShippingAddress.Address2;
        expressCheckoutRequestDetails.Address.CityName = order.ShippingAddress.City;
        expressCheckoutRequestDetails.Address.StateOrProvince = order.ShippingAddress.StateOrRegion;
        expressCheckoutRequestDetails.Address.PostalCode = order.ShippingAddress.PostalCode;
        expressCheckoutRequestDetails.Address.Country = (CountryCodeType)Enum.Parse(typeof(CountryCodeType), order.ShippingAddress.Country);
        expressCheckoutRequestDetails.Address.CountrySpecified = true;
      }

      if(order.BillingAddress != null) {
        expressCheckoutRequestDetails.BuyerEmail = order.BillingAddress.Email;
      }
      Currency currency = new Currency();
      decimal total = GetOrderTotal(currency, order);
      expressCheckoutRequestDetails.OrderTotal = GetBasicAmount(total);
      expressCheckoutRequestDetails.ReturnURL = returnUrl;
      expressCheckoutRequestDetails.CancelURL = cancelUrl;
      if(authorizeOnly) {
        expressCheckoutRequestDetails.PaymentAction = PaymentActionCodeType.Authorization;
      }
      else {
        expressCheckoutRequestDetails.PaymentAction = PaymentActionCodeType.Sale;
      }
      expressCheckoutRequestDetails.PaymentActionSpecified = true;
      expressCheckoutRequestDetails.Custom = order.OrderNumber;
      expressCheckoutRequestDetails.InvoiceID = order.OrderNumber;
      
      expressCheckoutRequest.SetExpressCheckoutRequest.SetExpressCheckoutRequestDetails = expressCheckoutRequestDetails;
      SetExpressCheckoutResponseType expressCheckoutResponse =
        payPalAPIAASoapBinding.SetExpressCheckout(expressCheckoutRequest);

      string errorList = ValidateResponse(expressCheckoutResponse);
      //if(expressCheckoutResponse.Ack != AckCodeType.Success && expressCheckoutResponse.Ack != AckCodeType.SuccessWithWarning) {
      if(IsValidResponse(expressCheckoutResponse.Ack)) {
        if (!string.IsNullOrEmpty(errorList)) {
          throw new PayPalServiceException(errorList);
        }
      }
      
      token = expressCheckoutResponse.Token;
      url = PayPalServiceUtility.GetExpressCheckoutUrl(this.IsLive, token);
      return url;
    }

    /// <summary>
    /// Gets the express checkout details.
    /// </summary>
    /// <param name="token">The token.</param>
    /// <returns></returns>
    internal PayPalPayer GetExpressCheckoutDetails(string token) {
      PayPalPayer payPalPayer = new PayPalPayer();

      GetExpressCheckoutDetailsReq expressCheckoutRequest = new GetExpressCheckoutDetailsReq();
      GetExpressCheckoutDetailsRequestType expressCheckoutDetailsRequest = new GetExpressCheckoutDetailsRequestType();
      expressCheckoutDetailsRequest.Token = token;
      expressCheckoutDetailsRequest.Version = PayPalServiceUtility.PayPalVersionNumber;
      expressCheckoutRequest.GetExpressCheckoutDetailsRequest = expressCheckoutDetailsRequest;
      GetExpressCheckoutDetailsResponseType expressCheckoutDetailsResponse =
        payPalAPIAASoapBinding.GetExpressCheckoutDetails(expressCheckoutRequest);

      string errorList = ValidateResponse(expressCheckoutDetailsResponse);
      //if (expressCheckoutDetailsResponse.Ack != AckCodeType.Success && expressCheckoutDetailsResponse.Ack != AckCodeType.SuccessWithWarning) {
      if(IsValidResponse(expressCheckoutDetailsResponse.Ack)) {
        if (!string.IsNullOrEmpty(errorList)) {
          throw new PayPalServiceException(errorList);
        }
      }

      if (EnforceSellerProtectionPolicy) {
        if (expressCheckoutDetailsResponse.GetExpressCheckoutDetailsResponseDetails.PayerInfo.Address.AddressStatus !=
            AddressStatusCodeType.Confirmed) {
          throw new PayPalServiceException(PayPalStrings.AddressStatusException);
        }
      }

      payPalPayer.PayPalPayerId =
        expressCheckoutDetailsResponse.GetExpressCheckoutDetailsResponseDetails.PayerInfo.PayerID;
      payPalPayer.PayPalToken = expressCheckoutDetailsResponse.GetExpressCheckoutDetailsResponseDetails.Token;
      payPalPayer.ShippingAddress.AddressType = AddressType.ShippingAddress;
      payPalPayer.ShippingAddress.Email = expressCheckoutDetailsResponse.GetExpressCheckoutDetailsResponseDetails.PayerInfo.Payer;
      payPalPayer.ShippingAddress.FirstName =
        expressCheckoutDetailsResponse.GetExpressCheckoutDetailsResponseDetails.PayerInfo.PayerName.FirstName;
      payPalPayer.ShippingAddress.LastName =
        expressCheckoutDetailsResponse.GetExpressCheckoutDetailsResponseDetails.PayerInfo.PayerName.LastName;
      payPalPayer.ShippingAddress.Address1 =
        expressCheckoutDetailsResponse.GetExpressCheckoutDetailsResponseDetails.PayerInfo.Address.Street1;
      payPalPayer.ShippingAddress.Address2 =
        expressCheckoutDetailsResponse.GetExpressCheckoutDetailsResponseDetails.PayerInfo.Address.Street2;
      payPalPayer.ShippingAddress.City =
        expressCheckoutDetailsResponse.GetExpressCheckoutDetailsResponseDetails.PayerInfo.Address.CityName;
      payPalPayer.ShippingAddress.StateOrRegion =
        expressCheckoutDetailsResponse.GetExpressCheckoutDetailsResponseDetails.PayerInfo.Address.StateOrProvince;
      payPalPayer.ShippingAddress.PostalCode =
        expressCheckoutDetailsResponse.GetExpressCheckoutDetailsResponseDetails.PayerInfo.Address.PostalCode;
      if (expressCheckoutDetailsResponse.GetExpressCheckoutDetailsResponseDetails.PayerInfo.Address.CountrySpecified) {
        payPalPayer.ShippingAddress.Country =
          expressCheckoutDetailsResponse.GetExpressCheckoutDetailsResponseDetails.PayerInfo.Address.Country.ToString();
      }
      if (expressCheckoutDetailsResponse.GetExpressCheckoutDetailsResponseDetails.ContactPhone != null) {
        payPalPayer.ShippingAddress.Phone = expressCheckoutDetailsResponse.GetExpressCheckoutDetailsResponseDetails.ContactPhone;
      }
      else {
        if (expressCheckoutDetailsResponse.GetExpressCheckoutDetailsResponseDetails.PayerInfo.ContactPhone != null) {
          payPalPayer.ShippingAddress.Phone =
            expressCheckoutDetailsResponse.GetExpressCheckoutDetailsResponseDetails.PayerInfo.ContactPhone;
        }
      }

      return payPalPayer;
    }

    /// <summary>
    /// Does the express checkout.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <param name="authorizeOnly">if set to <c>true</c> [authorize only].</param>
    /// <returns></returns>
    internal Transaction DoExpressCheckout(Order order, bool authorizeOnly) {
      Transaction transaction = null;

      DoExpressCheckoutPaymentReq expressCheckoutPayment = new DoExpressCheckoutPaymentReq();
      DoExpressCheckoutPaymentRequestType expressCheckoutPaymentRequest = new DoExpressCheckoutPaymentRequestType();
      DoExpressCheckoutPaymentRequestDetailsType expressCheckoutPaymentRequestDetails = new DoExpressCheckoutPaymentRequestDetailsType();
      
      PaymentDetailsType paymentDetails = new PaymentDetailsType();
      if(authorizeOnly) {
        expressCheckoutPaymentRequestDetails.PaymentAction = PaymentActionCodeType.Authorization;
      }
      else {
        expressCheckoutPaymentRequestDetails.PaymentAction = PaymentActionCodeType.Sale;
      }

      expressCheckoutPaymentRequestDetails.Token = order.ExtendedProperties[PAYPAL_TOKEN].ToString();
      expressCheckoutPaymentRequestDetails.PayerID = order.ExtendedProperties[PAYPAL_PAYER_ID].ToString();

      expressCheckoutPaymentRequest.Version = PayPalServiceUtility.PayPalVersionNumber;

      #region Basic Payment Information

      Currency currency = new Currency();
      decimal total = GetOrderTotal(currency, order);
      //Required
      paymentDetails.OrderTotal = GetBasicAmount(total);

      //Optional (see DoDirectPayment for additional notes)
      paymentDetails.ItemTotal =
        GetBasicAmount(decimal.Round(order.SubTotal, currency.CurrencyDecimals));

      paymentDetails.ShippingTotal =
        GetBasicAmount(decimal.Round(order.ShippingAmount, currency.CurrencyDecimals));

      paymentDetails.TaxTotal =
        GetBasicAmount(decimal.Round(order.TaxTotal, currency.CurrencyDecimals));

      paymentDetails.HandlingTotal =
        GetBasicAmount(decimal.Round(order.HandlingAmount, currency.CurrencyDecimals));

      //Note: You can use this value for whatever purpose, such as an accounting tracking number
      //or additional data needed by your program.
      paymentDetails.Custom = order.OrderNumber;
      paymentDetails.ButtonSource = Constants.EC_BN_ID;

      #endregion

      #region ShipTo Address

      //Load up The ShipTo Address
      paymentDetails.ShipToAddress = new PayPalSvc.AddressType();
      paymentDetails.ShipToAddress.Name =
        order.ShippingAddress.FirstName + " " + order.ShippingAddress.LastName;
      paymentDetails.ShipToAddress.Street1 =
        order.ShippingAddress.Address1;
      paymentDetails.ShipToAddress.Street2 =
        order.ShippingAddress.Address2;
      paymentDetails.ShipToAddress.CityName =
        order.ShippingAddress.City;
      paymentDetails.ShipToAddress.StateOrProvince =
        order.ShippingAddress.StateOrRegion;
      paymentDetails.ShipToAddress.Country =
        (CountryCodeType)Enum.Parse(typeof(CountryCodeType), order.ShippingAddress.Country);
      paymentDetails.ShipToAddress.CountrySpecified = true;
      paymentDetails.ShipToAddress.PostalCode =
        order.ShippingAddress.PostalCode;

      #endregion

      #region Load Individual Items

      //Add the individual items if they are available
      //This will also add nice line item entries to the PayPal invoice - good for customers!
      OrderItemCollection orderItemCollection = order.OrderItemRecords();
      if(orderItemCollection != null) {
        if(orderItemCollection.Count > 0) {
          paymentDetails.PaymentDetailsItem = new PaymentDetailsItemType[orderItemCollection.Count];
          PaymentDetailsItemType[] paymentDetailsItems = new PaymentDetailsItemType[orderItemCollection.Count];
          PaymentDetailsItemType item = null;
          for(int i = 0;i < orderItemCollection.Count;i++) {
            item = new PaymentDetailsItemType();
            string sku = orderItemCollection[i].Sku.Trim();
            if(sku.Length > 127) {
              sku = sku.Substring(0, 126);
            }
            item.Name = orderItemCollection[i].Name;
            item.Number = sku;
            item.Amount = GetBasicAmount(decimal.Round(orderItemCollection[i].PricePaid, currency.CurrencyDecimals));
            item.Quantity = orderItemCollection[i].Quantity.ToString();
            item.Tax = GetBasicAmount(decimal.Round(orderItemCollection[i].ItemTax, currency.CurrencyDecimals));
            paymentDetailsItems[i] = item;
          }
          paymentDetails.PaymentDetailsItem = paymentDetailsItems;
        }
      }

      #endregion

      //Now load it all up
      expressCheckoutPayment.DoExpressCheckoutPaymentRequest = expressCheckoutPaymentRequest;
      expressCheckoutPayment.DoExpressCheckoutPaymentRequest.DoExpressCheckoutPaymentRequestDetails = expressCheckoutPaymentRequestDetails;
      expressCheckoutPayment.DoExpressCheckoutPaymentRequest.DoExpressCheckoutPaymentRequestDetails.PaymentDetails[0] = paymentDetails;

      #region Charge and Validation
      //Finally, send it
      DoExpressCheckoutPaymentResponseType expressCheckoutPaymentResponse =
        payPalAPIAASoapBinding.DoExpressCheckoutPayment(expressCheckoutPayment);
      //Validate the response
      string errorList = ValidateResponse(expressCheckoutPaymentResponse);
//      if(expressCheckoutPaymentResponse.Ack != AckCodeType.Success && expressCheckoutPaymentResponse.Ack != AckCodeType.SuccessWithWarning) {
      if(IsValidResponse(expressCheckoutPaymentResponse.Ack)){
        if(!string.IsNullOrEmpty(errorList)) {
          throw new PayPalServiceException(errorList);
        }
      }
      #endregion

      #region Transaction

      transaction = new Transaction();
      transaction.OrderId = order.OrderId;
      if(!authorizeOnly) {
        transaction.TransactionTypeDescriptorId = (int)TransactionType.Charge;
      }
      else {
        transaction.TransactionTypeDescriptorId = (int)TransactionType.Authorization;
      }
      transaction.PaymentMethod = order.CreditCardType.ToString();
      transaction.GatewayName = PAYPAL_EXPRESSCHECKOUT;
      string gatewayResponse = expressCheckoutPaymentResponse.Ack.ToString();
      if(expressCheckoutPaymentResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo[0].PaymentStatus == PaymentStatusCodeType.Pending) {
        gatewayResponse += "::Pending";
      }
      transaction.GatewayResponse = gatewayResponse;
      transaction.GatewayTransactionId = expressCheckoutPaymentResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo[0].TransactionID;
      transaction.GrossAmount = Convert.ToDecimal(expressCheckoutPaymentResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo[0].GrossAmount.Value);
      transaction.FeeAmount = expressCheckoutPaymentResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo[0].FeeAmount != null ? Convert.ToDecimal(
        expressCheckoutPaymentResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo[0].FeeAmount.Value) : 0M;
      transaction.TransactionDate = DateTime.Now;
      transaction.GatewayErrors = errorList;
      transaction.Save("System");

      #endregion

      return transaction;

    }

    #endregion

    #region Direct Payment Methods

    /// <summary>
    /// Does the direct payment.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <param name="authorizeOnly">if set to <c>true</c> [authorize only].</param>
    /// <returns></returns>
    internal Transaction DoDirectPayment(Order order, bool authorizeOnly) {
      Transaction transaction = null;

      DoDirectPaymentReq directPaymentReq = new DoDirectPaymentReq();
      directPaymentReq.DoDirectPaymentRequest = new DoDirectPaymentRequestType();
      directPaymentReq.DoDirectPaymentRequest.Version = PayPalServiceUtility.PayPalVersionNumber;

      DoDirectPaymentRequestDetailsType directPaymentRequestDetails = new DoDirectPaymentRequestDetailsType();
      //1st, set up the required objects / fields.
      directPaymentRequestDetails.PaymentDetails = new PaymentDetailsType();
      directPaymentRequestDetails.CreditCard = new CreditCardDetailsType();
      directPaymentRequestDetails.IPAddress = order.IPAddress;
      //Note: PaymentAction is not required, but defaults to Sale, so it makes sense to set it ASAP.
      // - PayPal_APIReference pg.45
      if (authorizeOnly) {
        directPaymentRequestDetails.PaymentAction = PaymentActionCodeType.Authorization;
      }
      else {
        directPaymentRequestDetails.PaymentAction = PaymentActionCodeType.Sale;
      }

      //2nd, populate the required objects / fields (in same order as in step 1, above)
      #region Load PaymentDetails

      Currency currency = new Currency();
      decimal total = GetOrderTotal(currency, order);
      //Required
      directPaymentRequestDetails.PaymentDetails.OrderTotal = GetBasicAmount(total);

      //Optional
      //Note: If you send these 4 items, they must sum to the OrderTotal (above) 
      // - PaymentsPro Integration Guide, March 2007, pg.42
      //Note: You must specify the ItemTotal if you specify Amount in PaymentDetailsItem
      //or if you specify values for ShippingTotal or HandlingTotal
      directPaymentRequestDetails.PaymentDetails.ItemTotal =
        GetBasicAmount(decimal.Round(order.SubTotal - order.DiscountAmount, currency.CurrencyDecimals));

      directPaymentRequestDetails.PaymentDetails.ShippingTotal =
        GetBasicAmount(decimal.Round(order.ShippingAmount, currency.CurrencyDecimals));

      directPaymentRequestDetails.PaymentDetails.TaxTotal =
        GetBasicAmount(decimal.Round(order.TaxTotal, currency.CurrencyDecimals));

      directPaymentRequestDetails.PaymentDetails.HandlingTotal =
        GetBasicAmount(decimal.Round(order.HandlingAmount, currency.CurrencyDecimals));
      //End Note

      //Note: You can use this value for whatever purpose, such as an accounting tracking number
      //or additional data needed by your program.
      directPaymentRequestDetails.PaymentDetails.Custom = order.OrderNumber;
      directPaymentRequestDetails.PaymentDetails.ButtonSource = Constants.DP_BN_ID;

      #region ShipTo Address

      //Load up The ShipTo Address
      if(order.ShippingAddress != null) {
        directPaymentRequestDetails.PaymentDetails.ShipToAddress = new PayPalSvc.AddressType();
        directPaymentRequestDetails.PaymentDetails.ShipToAddress.Name = 
          order.ShippingAddress.FirstName + " " + order.ShippingAddress.LastName;
        directPaymentRequestDetails.PaymentDetails.ShipToAddress.Street1 = 
          order.ShippingAddress.Address1;
        directPaymentRequestDetails.PaymentDetails.ShipToAddress.Street2 = 
          order.ShippingAddress.Address2;
        directPaymentRequestDetails.PaymentDetails.ShipToAddress.CityName = 
          order.ShippingAddress.City;
        directPaymentRequestDetails.PaymentDetails.ShipToAddress.StateOrProvince = 
          order.ShippingAddress.StateOrRegion;
        directPaymentRequestDetails.PaymentDetails.ShipToAddress.Country = 
          (CountryCodeType)Enum.Parse(typeof(CountryCodeType), order.ShippingAddress.Country);
        directPaymentRequestDetails.PaymentDetails.ShipToAddress.CountrySpecified = true;
        directPaymentRequestDetails.PaymentDetails.ShipToAddress.PostalCode = 
          order.ShippingAddress.PostalCode;
        }

      #endregion

      #region Load Individual Items

      //Add the individual items if they are available
      //This will also add nice line item entries to the PayPal invoice - good for customers!
      OrderItemCollection orderItemCollection = order.OrderItemCollection;
      if (orderItemCollection != null) {
        if (orderItemCollection.Count > 0) {
          directPaymentRequestDetails.PaymentDetails.PaymentDetailsItem = new PaymentDetailsItemType[orderItemCollection.Count];
          PaymentDetailsItemType[] paymentDetailsItems = new PaymentDetailsItemType[orderItemCollection.Count];
          PaymentDetailsItemType item = null;
          for(int i = 0;i < orderItemCollection.Count;i++) {
            item = new PaymentDetailsItemType();
            string sku = orderItemCollection[i].Sku.Trim();
            if (sku.Length > 127) {
              sku = sku.Substring(0, 126);
            }
            item.Name = orderItemCollection[i].Name;
            item.Number = sku;
            item.Amount = GetBasicAmount(decimal.Round(orderItemCollection[i].ItemDiscountedPrice, currency.CurrencyDecimals));
            item.Quantity = orderItemCollection[i].Quantity.ToString();
            item.Tax = GetBasicAmount(decimal.Round(orderItemCollection[i].ItemTax, currency.CurrencyDecimals));
            paymentDetailsItems[i] = item;
          }
          directPaymentRequestDetails.PaymentDetails.PaymentDetailsItem = paymentDetailsItems;
        }
      }

      #endregion

      #endregion

      #region CreditCard
      //Load up the Credit Card Payer information
      directPaymentRequestDetails.CreditCard.CardOwner = new PayerInfoType();
      directPaymentRequestDetails.CreditCard.CardOwner.Address = new PayPalSvc.AddressType();
      directPaymentRequestDetails.CreditCard.CardOwner.PayerName = new PersonNameType();
      if (order.BillingAddress == null)
        throw new ArgumentException("BillingAddress is missing " + order.PaymentMethod + " " + order.CreditCardType);
      if (order.BillingAddress.FirstName == null)
        throw new ArgumentException("BillingAddress.FirstName is missing " + order.PaymentMethod + " " + order.CreditCardType);
      directPaymentRequestDetails.CreditCard.CardOwner.PayerName.FirstName = order.BillingAddress.FirstName;
      directPaymentRequestDetails.CreditCard.CardOwner.PayerName.LastName = order.BillingAddress.LastName;
      CountryCodeType customerCountry = CountryCodeType.US;
      if (order.BillingAddress.Country != CountryCodeType.US.ToString()) {
        if (Enum.IsDefined(typeof(CountryCodeType), order.BillingAddress.Country)) {
          customerCountry = (CountryCodeType)Enum.Parse(typeof(CountryCodeType), order.BillingAddress.Country);
        }
      }
      directPaymentRequestDetails.CreditCard.CardOwner.PayerCountry = customerCountry;
      //Load up the Card Owner Address information
      directPaymentRequestDetails.CreditCard.CardOwner.Address.Country = customerCountry;
      directPaymentRequestDetails.CreditCard.CardOwner.Address.CountrySpecified = true;
      directPaymentRequestDetails.CreditCard.CardOwner.Address.Street1 = order.BillingAddress.Address1;
      directPaymentRequestDetails.CreditCard.CardOwner.Address.Street2 = order.BillingAddress.Address2;
      directPaymentRequestDetails.CreditCard.CardOwner.Address.CityName = order.BillingAddress.City;
      directPaymentRequestDetails.CreditCard.CardOwner.Address.StateOrProvince = order.BillingAddress.StateOrRegion;
      directPaymentRequestDetails.CreditCard.CardOwner.Address.PostalCode = order.BillingAddress.PostalCode;
      //Load up the Credit Card information
      directPaymentRequestDetails.CreditCard.CreditCardNumber = order.CreditCardNumber;
      CreditCardTypeType creditCardType = CreditCardTypeType.Visa;
      switch (order.CreditCardType) {
        case CreditCardType.MasterCard:
          creditCardType = CreditCardTypeType.MasterCard;
          break;
        case CreditCardType.Amex:
          creditCardType = CreditCardTypeType.Amex;
          break;
        case CreditCardType.Maestro:
          creditCardType = CreditCardTypeType.Switch;
          break;
        case CreditCardType.Solo:
          creditCardType = CreditCardTypeType.Solo;
          break;
      }
      directPaymentRequestDetails.CreditCard.CreditCardType = creditCardType;
      directPaymentRequestDetails.CreditCard.CreditCardTypeSpecified = true;
      directPaymentRequestDetails.CreditCard.IssueNumber = order.CreditCardIssueNumber;
      if (order.CreditCardStartMonth > 0) {
        directPaymentRequestDetails.CreditCard.StartMonth = order.CreditCardStartMonth;
        directPaymentRequestDetails.CreditCard.StartMonthSpecified = true;
      }
      if (order.CreditCardStartYear > 0) {
        directPaymentRequestDetails.CreditCard.StartYear = order.CreditCardStartYear;
        directPaymentRequestDetails.CreditCard.StartYearSpecified = true;
      }
      directPaymentRequestDetails.CreditCard.ExpMonth = order.CreditCardExpirationMonth;
      directPaymentRequestDetails.CreditCard.ExpMonthSpecified = true;
      directPaymentRequestDetails.CreditCard.ExpYear = order.CreditCardExpirationYear;
      directPaymentRequestDetails.CreditCard.ExpYearSpecified = true;
      directPaymentRequestDetails.CreditCard.CVV2 = order.CreditCardSecurityNumber;

      #endregion

      directPaymentReq.DoDirectPaymentRequest.DoDirectPaymentRequestDetails = directPaymentRequestDetails;

      #region Charge and Validation
      //Finally, send it
      DoDirectPaymentResponseType directPaymentResponse =
        payPalAPIAASoapBinding.DoDirectPayment(directPaymentReq);
      //Validate the response
      string errorList = ValidateResponse(directPaymentResponse);
      if (IsValidResponse(directPaymentResponse.Ack)){
        if (!string.IsNullOrEmpty(errorList)) {
          throw new PayPalServiceException(errorList);
        }
      }
      #endregion

      #region Transaction

      transaction = new Transaction();
      transaction.OrderId = order.OrderId;
      if(!authorizeOnly) {
        transaction.TransactionTypeDescriptorId = (int)TransactionType.Charge;
      }
      else {
        transaction.TransactionTypeDescriptorId = (int)TransactionType.Authorization;
      }
      transaction.PaymentMethod = order.CreditCardType.ToString();
      transaction.GatewayName = PAYPALPRO;
      transaction.GatewayResponse = directPaymentResponse.Ack.ToString();
      //These "Not Available"'s shouldn't trip off, but if PayPal is being flaky (like it is today), then this will allow the transaction to be saved.
      transaction.GatewayTransactionId = !string.IsNullOrEmpty(directPaymentResponse.TransactionID) ? directPaymentResponse.TransactionID : Strings.ResourceManager.GetString("lblNotAvailable");
      transaction.AVSCode = !string.IsNullOrEmpty(directPaymentResponse.AVSCode) ? directPaymentResponse.AVSCode : Strings.ResourceManager.GetString("lblNotAvailable");
      transaction.CVV2Code = !string.IsNullOrEmpty(directPaymentResponse.CVV2Code) ? directPaymentResponse.CVV2Code : Strings.ResourceManager.GetString("lblNotAvailable");
      if (directPaymentResponse.Amount != null) {//try to get it from PayPal
        transaction.GrossAmount = Convert.ToDecimal(directPaymentResponse.Amount.Value);
      }
      else {//but if it fails, then use the Order total
        transaction.GrossAmount = order.Total;
      }
      transaction.TransactionDate = DateTime.Now;
      transaction.GatewayErrors = errorList;
      transaction.Save("System");
      #endregion

      return transaction;
    }


    #endregion

    #region Refund Transaction Methods

    /// <summary>
    /// Refunds the specified transaction id.
    /// </summary>
    /// <param name="transactionId">The transaction id.</param>
    /// <param name="args">The args.</param>
    /// <returns></returns>
    internal Transaction Refund(Transaction transaction, Order order) {
      Transaction refundTransaction = null;

      RefundTransactionRequestType refundTransactionRequestType = new RefundTransactionRequestType();
      if(order != null ) {
        if(order.Total == transaction.GrossAmount) {
          refundTransactionRequestType.RefundType = RefundType.Full;
        }
        else {
          refundTransactionRequestType.RefundType = RefundType.Partial;
        }
      }
      else {
        refundTransactionRequestType.RefundType = RefundType.Full;
      }
      refundTransactionRequestType.RefundTypeSpecified = true;
      refundTransactionRequestType.Version = PayPalServiceUtility.PayPalVersionNumber;
      refundTransactionRequestType.TransactionID = transaction.GatewayTransactionId;
      //Note: Only specify amount in partial refund
      if(refundTransactionRequestType.RefundType == RefundType.Partial) {
        Currency currency = new Currency();
        decimal total = GetOrderTotal(currency, order);
        refundTransactionRequestType.Amount = GetBasicAmount(total);
      }
      RefundTransactionReq refundTransactionRequest = new RefundTransactionReq();
      refundTransactionRequest.RefundTransactionRequest = refundTransactionRequestType;
      
      RefundTransactionResponseType refundTransactionResponseType = payPalAPISoapBinding.RefundTransaction(refundTransactionRequest);
      string errorList = ValidateResponse(refundTransactionResponseType);
      if(refundTransactionResponseType.Ack != AckCodeType.Success || refundTransactionResponseType.Ack != AckCodeType.SuccessWithWarning) {
        if(!string.IsNullOrEmpty(errorList)) {
          throw new PayPalServiceException(errorList);
        }
      }

      refundTransaction = new Transaction();
      refundTransaction.OrderId = transaction.OrderId;
      refundTransaction.TransactionTypeDescriptorId = (int)TransactionType.Refund;
      refundTransaction.PaymentMethod = PAYPAL;
      refundTransaction.GatewayName = PAYPALPRO;
      refundTransaction.GatewayResponse = refundTransactionResponseType.Ack.ToString();
      refundTransaction.GatewayTransactionId = refundTransactionResponseType.RefundTransactionID;
      decimal grossAmount = 0.00M;
      decimal.TryParse(refundTransactionResponseType.GrossRefundAmount.Value, out grossAmount);
      refundTransaction.GrossAmount = grossAmount;
      decimal netAmount = 0.00M;
      decimal.TryParse(refundTransactionResponseType.NetRefundAmount.Value, out netAmount);
      refundTransaction.NetAmount = netAmount;
      decimal feeAmount = 0.00M;
      decimal.TryParse(refundTransactionResponseType.FeeRefundAmount.Value, out feeAmount);
      refundTransaction.FeeAmount = feeAmount;
      refundTransaction.TransactionDate = DateTime.Now;
      refundTransaction.GatewayErrors = errorList;
      return refundTransaction;
    }

    #endregion

    #endregion

    #region Private

    /// <summary>
    /// Validates the response from PayPal.
    /// </summary>
    /// <param name="abstractResponse">The abstract response.</param>
    /// <returns></returns>
    private static string ValidateResponse(AbstractResponseType abstractResponse) {
      string errorList = string.Empty;

      if (abstractResponse.Errors != null) {
        if (abstractResponse.Errors.Length > 0) {
          string errorCode = string.Empty;
          string errorParameters = string.Empty;
          string longMessage = string.Empty;
          string severityCode = string.Empty;
          string shortMessage = string.Empty;
          string correctiveAction = string.Empty;
          for (int i = 0; i < abstractResponse.Errors.Length; i++) {
            errorCode = abstractResponse.Errors[i].ErrorCode;
            if (abstractResponse.Errors[i].ErrorParameters != null) {
              if (abstractResponse.Errors[i].ErrorParameters.Length > 0) {
                for (int j = 0; j < abstractResponse.Errors[i].ErrorParameters.Length; j++) {
                  errorParameters +=
                    string.Format(ErrorParametersFormat,
                                  abstractResponse.Errors[i].ErrorParameters[j].ParamID,
                                  abstractResponse.Errors[i].ErrorParameters[j].Value)
                                  + Environment.NewLine;
                }
              }
            }
            longMessage = abstractResponse.Errors[i].LongMessage;
            severityCode = abstractResponse.Errors[i].SeverityCode.ToString();
            shortMessage = abstractResponse.Errors[i].ShortMessage;
            correctiveAction = PayPalServiceUtility.GetDirectPaymentCorrectiveAction(errorCode);
          }
          errorList +=
            string.Format(ErrorFormat, errorCode, errorParameters, longMessage, severityCode,
            shortMessage, correctiveAction) + Environment.NewLine;
        }
      }
      return errorList;
    }

    /// <summary>
    /// Converts a decimal into a BasicAmount (PayPal type).
    /// </summary>
    /// <param name="amount">The amount.</param>
    /// <returns></returns>
    private BasicAmountType GetBasicAmount(decimal amount) {
      BasicAmountType basicAmount = new BasicAmountType();
      basicAmount.Value = amount.ToString();
      basicAmount.currencyID = DefaultCurrencyCode;
      return basicAmount;
    }

    /// <summary>
    /// Gets the order total.
    /// </summary>
    /// <param name="currency">The currency.</param>
    /// <param name="order">The order.</param>
    /// <returns></returns>
    private static decimal GetOrderTotal(Currency currency, Order order) {
      return decimal.Round(order.Total, currency.CurrencyDecimals);
    }

    /// <summary>
    /// Determines whether [is valid response] [the specified ack code type].
    /// </summary>
    /// <param name="ackCodeType">Type of the ack code.</param>
    /// <returns>
    /// 	<c>true</c> if [is valid response] [the specified ack code type]; otherwise, <c>false</c>.
    /// </returns>
    private bool IsValidResponse(AckCodeType ackCodeType) {
      return ackCodeType != AckCodeType.Success && ackCodeType != AckCodeType.SuccessWithWarning;
    }


    #endregion

    #endregion

    #region Properties

    /// <summary>
    /// Gets a value indicating whether this instance is live.
    /// </summary>
    /// <value><c>true</c> if this instance is live; otherwise, <c>false</c>.</value>
    public bool IsLive {
      get {
        return isLive;
      }
    }

    /// <summary>
    /// Gets the name of the API user.
    /// </summary>
    /// <value>The name of the API user.</value>
    public string ApiUserName {
      get {
        return apiUserName;
      }
    }

    /// <summary>
    /// Gets the API password.
    /// </summary>
    /// <value>The API password.</value>
    public string ApiPassword {
      get {
        return apiPassword;
      }
    }

    /// <summary>
    /// Gets the signature.
    /// </summary>
    /// <value>The signature.</value>
    public string Signature {
      get {
        return signature;
      }
    }

    /// <summary>
    /// Gets the default currency code.
    /// </summary>
    /// <value>The default currency code.</value>
    public CurrencyCodeType DefaultCurrencyCode {
      get {
        return defaultCurrencyCode;
      }
    }

    /// <summary>
    /// Gets a value indicating whether [use express checkout commit].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [use express checkout commit]; otherwise, <c>false</c>.
    /// </value>
    public bool UseExpressCheckoutCommit {
      get {
        return useExpressCheckoutCommit;
      }
    }

    /// <summary>
    /// Gets a value indicating whether [enforce seller protection policy].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [enforce seller protection policy]; otherwise, <c>false</c>.
    /// </value>
    public bool EnforceSellerProtectionPolicy {
      get {
        return enforceSellerProtectionPolicy;
      }
    }

    /// <summary>
    /// Gets the header image URL.
    /// </summary>
    /// <value>The header image URL.</value>
    public string HeaderImageUrl {
      get {
        return headerImageUrl;
      }
    }

    /// <summary>
    /// Gets or sets the business email.
    /// </summary>
    /// <value>The business email.</value>
    public string BusinessEmail {
      get {
        return businessEmail;
      }
      set {
        businessEmail = value;
      }
    }

    /// <summary>
    /// Gets or sets the PDT id.
    /// </summary>
    /// <value>The PDT id.</value>
    public string PdtId {
      get {
        return pdtId;
      }
      set {
        pdtId = value;
      }
    }

    /// <summary>
    /// Gets the error format.
    /// </summary>
    /// <value>The error format.</value>
    private static string ErrorFormat {
      get {
        return PayPalStrings.ResponseErrorFormat;
      }
    }

    /// <summary>
    /// Gets the error parameters format.
    /// </summary>
    /// <value>The error parameters format.</value>
    private static string ErrorParametersFormat {
      get {
        return PayPalStrings.ResponseErrorParametersFormat;
      }
    }

    #endregion

  }

  public class Constants {
    public static readonly string DP_BN_ID = "mettlesystems_shoppingcart_dp_us";
    public static readonly string EC_BN_ID = "mettlesystems_shoppingcart_ec_us";
    public static readonly string WPS_BN_ID = "mettlesystems_shoppingcart_wps_us";
  }
}
