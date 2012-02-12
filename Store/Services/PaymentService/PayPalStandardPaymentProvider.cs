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

namespace MettleSystems.dashCommerce.Store.Services.PaymentService {
  public class PayPalStandardPaymentProvider : IPayPalPaymentProvider {

    #region Constants

    public const string ISLIVE = "IsLive";
    public const string BUSINESS_EMAIL = "BusinessEmail";
    public const string PDTID = "PdtId";

    #region Argument Constants
    
    private const string ARG_ISLIVE = "isLive";
    private const string ARG_BUSINESS_EMAIL = "businessEmail";
    private const string ARG_PDTID = "pdtId";

    #endregion

    #endregion

    #region Member Variables

    private PayPal.PayPalService _payPalService;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="T:PayPalStandardPaymentProvider"/> class.
    /// </summary>
    private PayPalStandardPaymentProvider() {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:PayPalStandardPaymentProvider"/> class.
    /// </summary>
    /// <param name="isLive">The is live.</param>
    /// <param name="businessEmail">The business email.</param>
    /// <param name="pdtId">The PDT id.</param>
    public PayPalStandardPaymentProvider(string isLive, string businessEmail, string pdtId) {
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(isLive, ARG_ISLIVE);
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(businessEmail, ARG_BUSINESS_EMAIL);
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(pdtId, ARG_PDTID);

      bool IsLive = false;
      bool.TryParse(isLive, out IsLive);
      _payPalService = new PayPal.PayPalService(IsLive, businessEmail, pdtId);
    }

    #endregion

    #region IPayPalPaymentProvider Members

    /// <summary>
    /// Authorizes the specified order.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <returns></returns>
    public Transaction Authorize(Order order) {
      throw new Exception("The method or operation is not implemented.");
    }

    /// <summary>
    /// Charges the specified order.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <returns></returns>
    public Transaction Charge(Order order) {
      throw new Exception("The method or operation is not implemented.");
    }

    /// <summary>
    /// Refunds the specified transaction.
    /// </summary>
    /// <param name="transaction">The transaction.</param>
    /// <returns></returns>
    public Transaction Refund(Transaction transaction, Order order) {
      throw new Exception("The method or operation is not implemented.");
    }

    /// <summary>
    /// Creates the cart URL.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <param name="returnUrl"></param>
    /// <param name="cancelUrl"></param>
    /// <returns></returns>
    public string CreateCartUrl(Order order, string returnUrl, string cancelUrl, string notifyUrl) {
      string url = _payPalService.CreateCartUrl(order, returnUrl, cancelUrl, notifyUrl);
      return url;
    }

    /// <summary>
    /// Synchronizes the specified args.
    /// </summary>
    /// <param name="args">The args.</param>
    /// <returns></returns>
    public string Synchronize(params object[] args) {
      string response = _payPalService.Synchronize(args[0].ToString());
      return response;
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
      throw new NotImplementedException("This method has not been implemented.");
    }

    /// <summary>
    /// Gets the express checkout details.
    /// </summary>
    /// <param name="token">The token.</param>
    /// <returns></returns>
    public PayPalPayer GetExpressCheckoutDetails(string token) {
      throw new NotImplementedException("This method has not been implemented.");
    }

    /// <summary>
    /// Does the express checkout.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <param name="authorizeOnly">if set to <c>true</c> [authorize only].</param>
    /// <returns></returns>
    public Transaction DoExpressCheckout(Order order, bool authorizeOnly) {
      throw new NotImplementedException("This method has not been implemented.");
    }

    #endregion
    
  }
}
