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
        return "63.0";
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
