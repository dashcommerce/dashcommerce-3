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
