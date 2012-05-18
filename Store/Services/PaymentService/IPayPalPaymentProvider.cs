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
