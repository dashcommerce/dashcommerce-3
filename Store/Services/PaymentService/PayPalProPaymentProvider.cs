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
