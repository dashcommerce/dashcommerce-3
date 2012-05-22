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

namespace MettleSystems.dashCommerce.Store.Services.PaymentService.PayPal {
  public partial class PayPalServiceUtility {
  
    #region Methods
    
    #region Public

    /// <summary>
    /// Gets the direct payment corrective action.
    /// </summary>
    /// <param name="errorCode">The error code.</param>
    /// <returns></returns>
    public static string GetDirectPaymentCorrectiveAction(string errorCode) {
      if (string.IsNullOrEmpty(errorCode)) {
        throw new ArgumentException("Argument cannot be null or empty string", "errorCode");
      }
      //TODO: CMC - Make this a db lookup?
      string resourceKey = string.Format("DPAPI{0}", errorCode);
      return errorCode;
    }

    /// <summary>
    /// Gets the pay pal version number.
    /// </summary>
    /// <value>The pay pal version number.</value>
    // This is located in PayPalSvc.wsdl (ex: ns:version="3.2")
    // If you update the WSDL, then you'll want to check this number 
    public static string PayPalVersionNumber {
      get {
        //return "3.3"; 
        return "89.0";
      }
    }

    /// <summary>
    /// Gets the pay pal service endpoint. Defined at https://www.paypal.com/IntegrationCenter/ic_api-reference.html
    /// </summary>
    /// <param name="useSandbox">if set to <c>true</c> [use sandbox].</param>
    /// <param name="useSOAP">if set to <c>true</c> [use SOAP].</param>
    /// <param name="useSignature">if set to <c>true</c> [use signature].</param>
    /// <returns></returns>
    public static string GetPayPalServiceEndpoint(bool isPayPalPro, bool useSandbox, bool useSOAP, bool useSignature) {
      string endPoint = string.Empty;
      if(!isPayPalPro) { //PayPal Standard
        if(useSandbox) {
          endPoint = "https://www.paypal.com/cgi-bin/webscr";
        }
        else {
          endPoint = "https://www.sandbox.paypal.com/cgi-bin/webscr";
        }
      }
      else { //PayPal Pro
        if (!useSandbox) { //SANDBOX
          //Signature vs. Certificate does not matter in the Sandbox.
          if (useSOAP) {
            endPoint = "https://api.sandbox.paypal.com/2.0/";
          }
          else {
            endPoint = "https://api.sandbox.paypal.com/nvp";
          }
        }
        else { //PRODUCTION
          if (useSOAP) { //SOAP API
            if (useSignature) {
              endPoint = "https://api-3t.paypal.com/2.0/";
            }
            else { //Certificate
              endPoint = "https://api.paypal.com/2.0/";
            }
          }
          else { //Name-Value Pair API
            if (useSignature) {
              endPoint = "https://api-3t.paypal.com/nvp";
            }
            else { //Certificate
              endPoint = "https://api.paypal.com/nvp";
            }
          }
        }
      }
      return endPoint;
    }

    /// <summary>
    /// Gets the express checkout URL.
    /// </summary>
    /// <param name="isLive">if set to <c>true</c> [is live].</param>
    /// <param name="token">The token.</param>
    /// <returns></returns>
    public static string GetExpressCheckoutUrl(bool isLive, string token) {
      string url = string.Empty;
      if(isLive) {
        url = string.Format("https://www.paypal.com/cgi-bin/webscr?cmd=_express-checkout&token={0}", token);
      }
      else {
        url = string.Format("https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_express-checkout&token={0}", token);
      }
      return url;
    }
    
    #endregion
    
    #endregion
    
  }
}
