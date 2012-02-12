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
