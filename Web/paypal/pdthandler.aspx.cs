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
  public partial class pdthandler : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {
      try {
        //Log the querystring in case we have to investigate
        Logger.Information(Request.QueryString.ToString());

        string transactionId = Request.QueryString["tx"];
        string orderId = Request.QueryString["cm"];

        if (transactionId.IndexOf(",") > -1) {
          transactionId = transactionId.Substring(0, transactionId.IndexOf(",", 0));
          transactionId = HttpUtility.UrlDecode(transactionId);
        }
        else {
          transactionId = HttpUtility.UrlDecode(transactionId);
        }
        if (orderId.IndexOf(",") > -1) {
          orderId = orderId.Substring(0, orderId.IndexOf(",", 0));
          orderId = HttpUtility.UrlDecode(orderId);
        }
        else {
          orderId = HttpUtility.UrlDecode(orderId);
        }

        string response = Synchronize(transactionId);
        if (response.StartsWith("SUCCESS")) {
          string grossAmt = GetPDTValue(response, "mc_gross");
          decimal grossAmount = 0;
          decimal.TryParse(grossAmt, out grossAmount);
          OrderController orderController = new OrderController();
          Guid orderGuid = new Guid(orderId);
          Order order = orderController.FetchOrder(orderGuid);
          if (order.OrderId > 0) {
            Transaction transaction = null;
            if (order.OrderStatusDescriptorId == (int)OrderStatus.NotProcessed) {//then it hasn't been pinged by the ipn service
              transaction = OrderController.CommitStandardTransaction(order, transactionId, grossAmount);
              Logger.Information(string.Format("{0}::{1}", "PDT", order.OrderNumber));
            }
            else {//it has been pinged by the ipn service, so just grab the transaction
              transaction = new Transaction(Transaction.Columns.OrderId, order.OrderId);
            }
            Response.Redirect(string.Format("~/receipt.aspx?tid={0}", transaction.TransactionId), true);
          }
        }
      }
      catch (System.Threading.ThreadAbortException) {
        throw;
      }
      catch (Exception ex) {
        Logger.Error(typeof(pdthandler).Name, ex);
      }
    }

    private string GetPDTValue(string pdt, string key) {
      string[] keys = pdt.Split('\n');
      string thisVal = "";
      string thisKey = "";
      foreach (string s in keys) {
        string[] bits = s.Split('=');
        if (bits.Length > 1) {
          thisVal = bits[1];
          thisKey = bits[0];
          if (thisKey.ToLower().Equals(key))
            break;
        }
      }
      return thisVal;
    }

    private string Synchronize(string transactionId) {
      string response = OrderController.Synchronize(transactionId);
      return response;
    }
  }
}
