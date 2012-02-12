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

namespace MettleSystems.dashCommerce.Store.Services.PaymentService {

  public interface IPayPalPaymentProvider : IPaymentProvider {

    #region PayPal Standard

    /// <summary>
    /// Creates the cart URL.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <returns></returns>
    string CreateCartUrl(Order order, string returnUrl, string cancelUrl, string notifyUrl);

    /// <summary>
    /// Synchronizes the specified args.
    /// </summary>
    /// <param name="args">The args.</param>
    /// <returns></returns>
    string Synchronize(params object[] args);

    #endregion

    #region PayPal Express

    /// <summary>
    /// Sets the express checkout.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <param name="returnUrl">The return URL.</param>
    /// <param name="cancelUrl">The cancel URL.</param>
    /// <param name="authorizeOnly">if set to <c>true</c> [authorize only].</param>
    /// <returns></returns>
    string SetExpressCheckout(Order order, string returnUrl, string cancelUrl, bool authorizeOnly);

    /// <summary>
    /// Gets the express checkout details.
    /// </summary>
    /// <param name="token">The token.</param>
    /// <returns></returns>
    PayPalPayer GetExpressCheckoutDetails(string token);

    /// <summary>
    /// Does the express checkout.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <param name="authorizeOnly">if set to <c>true</c> [authorize only].</param>
    /// <returns></returns>
    Transaction DoExpressCheckout(Order order, bool authorizeOnly);

    #endregion

  }
}
