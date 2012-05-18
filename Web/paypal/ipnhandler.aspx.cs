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
using System.Web;

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Store;


namespace MettleSystems.dashCommerce.Web.paypal {
  public partial class ipnhandler : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {
      //Log this so we can investigate if something goofy happens
      Logger.Information(string.Format("{0}::{1}", "REQUEST", Request.Form.ToString()));

      //Per PayPal Order Management / Integration Guide Pg.25
      //we have to validate the price, transactionId, etc.
      string transactionId = Request.Form["txn_id"].ToString();
      string orderId = Request.Form["custom"].ToString();
      string amount = Request.Form["mc_gross"].ToString();
      decimal parsedAmount = 0.00M;
      bool isParsed = decimal.TryParse(amount, out parsedAmount);
      string paymentStatus = Request.Form["payment_status"].ToString();
      string receiverEmail = Request.Form["receiver_email"].ToString();


      if (transactionId.IndexOf(",") > -1) {
        transactionId = transactionId.Substring(0, transactionId.IndexOf(",", 0));
        transactionId = HttpUtility.UrlDecode(transactionId);
      }
      if (orderId.IndexOf(",") > -1) {
        orderId = orderId.Substring(0, orderId.IndexOf(",", 0));
        orderId = HttpUtility.UrlDecode(orderId);
      }
      byte[] buffer = Request.BinaryRead(HttpContext.Current.Request.ContentLength);
      string formValues = System.Text.Encoding.ASCII.GetString(buffer);
      //string formValues = Request.Form.ToString();
      string response = Verify(formValues);
      if (response.StartsWith("VERIFIED")) {
        OrderController orderController = new OrderController();
        Guid orderGuid = new Guid(orderId);
        Order order = orderController.FetchOrder(orderGuid);
        if (order.OrderId > 0) {
          //check the payment_status is Completed
          //check that txn_id has not been previously processed
          //check that receiver_email is your Primary PayPal email
          //check that payment_amount/payment_currency are correct

          //TODO: CMC: Need to update the PayPalProConfiguration with preferred business email

          if ((paymentStatus.ToUpper().Equals("COMPLETED") && (order.OrderStatusDescriptorId == (int)OrderStatus.NotProcessed) && (order.Total == parsedAmount))) {
            Transaction transaction = OrderController.CommitStandardTransaction(order, transactionId, decimal.Parse(amount));
            Logger.Information(string.Format("{0}::{1}", "IPN", order.OrderNumber));
            //Send response 200
            Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            Response.Flush();
            Response.End();
          }
        }
      }
      else {
        Logger.Information(string.Format("{0}::{1}", "RESPONSE", HttpUtility.HtmlEncode(response)));
      }
    }

    private string Verify(string formValues) {
      string response = OrderController.Verify(formValues);
      return response;
    }
  }
}
