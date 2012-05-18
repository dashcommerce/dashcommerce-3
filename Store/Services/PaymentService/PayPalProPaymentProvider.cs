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

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Core.Caching;

namespace MettleSystems.dashCommerce.Store.Services.PaymentService {

  [Serializable()]
  public class PayPalProPaymentProvider : IPayPalPaymentProvider {

    #region Constants

    public const string API_USERNAME = "ApiUserName";
    public const string API_PASSWORD = "ApiPassword";
    public const string SIGNATURE = "Signature";
    public const string ISLIVE = "IsLive";
    public const string BUSINESS_EMAIL = "BusinessEmail";

    #endregion

    #region Member Variables

    private PayPal.PayPalService _payPalService;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="T:PayPalProPaymentProvider"/> class.
    /// </summary>
    private PayPalProPaymentProvider() {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:PayPalProPaymentProvider"/> class.
    /// </summary>
    /// <param name="apiUserName">The API username.</param>
    /// <param name="apiPassword">The API password.</param>
    /// <param name="signature">The API signature.</param>
    /// <param name="isLive">Defines if using live transactions.</param>
    public PayPalProPaymentProvider(string apiUserName, string apiPassword, string signature, string isLive) {
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(apiUserName, API_USERNAME);
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(apiPassword, API_PASSWORD);
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(signature, SIGNATURE);
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(isLive, ISLIVE);

      bool IsLive = false; //default to the sandbox
      bool isParsed = bool.TryParse(isLive, out IsLive);
      SiteSettings siteSettings = SiteSettingCache.GetSiteSettings();
      _payPalService = new PayPal.PayPalService(IsLive, apiUserName, apiPassword, signature, null, siteSettings.CurrencyCode);
    }

    public PayPalProPaymentProvider(string apiUserName, string apiPassword, string signature, string businessEmail, string isLive) {
      //Validator.ValidateStringArgumentIsNotNullOrEmptyString(apiUserName, API_USERNAME);
      //Validator.ValidateStringArgumentIsNotNullOrEmptyString(apiPassword, API_PASSWORD);
      //Validator.ValidateStringArgumentIsNotNullOrEmptyString(signature, SIGNATURE);
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(isLive, ISLIVE);

      bool IsLive = false; //default to the sandbox
      bool isParsed = bool.TryParse(isLive, out IsLive);
      SiteSettings siteSettings = SiteSettingCache.GetSiteSettings();
      _payPalService = new PayPal.PayPalService(IsLive, apiUserName, apiPassword, signature, businessEmail, siteSettings.CurrencyCode);
    }

    #endregion

    #region IPayPalPaymentProvider Members

    /// <summary>
    /// Authorizes the specified order.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <returns></returns>
    public Transaction Authorize(Order order) {
      Transaction transaction = _payPalService.DoDirectPayment(order, true);
      return transaction;
    }

    /// <summary>
    /// Charges the specified order.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <returns></returns>
    public Transaction Charge(Order order) {
      Transaction transaction = _payPalService.DoDirectPayment(order, false);
      return transaction;
    }

    /// <summary>
    /// Refunds the specified transaction.
    /// </summary>
    /// <param name="transaction">The transaction.</param>
    /// <returns></returns>
    public Transaction Refund(Transaction transaction, Order order) {
      Transaction refundTransaction = _payPalService.Refund(transaction, order);
      return refundTransaction;
    }

    /// <summary>
    /// Creates the cart URL.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <param name="returnUrl"></param>
    /// <param name="cancelUrl"></param>
    /// <returns></returns>
    public string CreateCartUrl(Order order, string returnUrl, string cancelUrl, string notifyUrl) {
      throw new NotImplementedException("This method has not been implemented.");
    }

    /// <summary>
    /// Synchronizes the specified args.
    /// </summary>
    /// <param name="args">The args.</param>
    /// <returns></returns>
    public string Synchronize(params object[] args) {
      throw new NotImplementedException("This method has not been implemented.");
    }

    /// <summary>
    /// Sets the express checkout.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <param name="returnUrl">The return URL.</param>
    /// <param name="cancelUrl">The cancel URL.</param>
    /// <param name="authorizeOnly">if set to <c>true</c> [authorize only].</param>
    /// <returns></returns>
    public string SetExpressCheckout(Order order, string returnUrl, string cancelUrl, bool authorizeOnly) {
      string url = _payPalService.SetExpressCheckout(order, returnUrl, cancelUrl, authorizeOnly);
      return url;
    }

    /// <summary>
    /// Gets the express checkout details.
    /// </summary>
    /// <param name="token">The token.</param>
    /// <returns></returns>
    public PayPalPayer GetExpressCheckoutDetails(string token) {
      PayPalPayer payPalPayer = _payPalService.GetExpressCheckoutDetails(token);
      return payPalPayer;
    }

    /// <summary>
    /// Does the express checkout.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <param name="authorizeOnly">if set to <c>true</c> [authorize only].</param>
    /// <returns></returns>
    public Transaction DoExpressCheckout(Order order, bool authorizeOnly) {
      Transaction transaction = _payPalService.DoExpressCheckout(order, authorizeOnly);
      return transaction;
    }

    #endregion
 
  }
}
