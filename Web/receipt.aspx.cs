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
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web {
  public partial class receipt : MettleSystems.dashCommerce.Store.Web.SitePage {

    #region Member Variables

    private int transactionId = 0;
    private int orderId = 0;

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        transactionId = Utility.GetIntParameter("tid");
        orderId = Utility.GetIntParameter("oid");
        if (transactionId > 0) {
          Transaction transaction = new Transaction(transactionId);
          Order order = new OrderController().FetchOrder(transaction.OrderId, WebUtility.GetUserName());
          if (order.OrderId > 0) {
            lblReceipt.Text = order.ToHtml();
          }
        }
        if (orderId > 0) {
          Order order = new OrderController().FetchOrder(orderId, WebUtility.GetUserName());
          if (order.OrderId > 0) {
            lblReceipt.Text = order.ToHtml();
          }
        }
        this.Title = string.Format(WebUtility.MainTitleTemplate, Master.SiteSettings.SiteName, LocalizationUtility.GetText("lblReceipt"));
      }
      catch (Exception ex) {
        Logger.Error(typeof(receipt).Name + ".Page_Load", ex);
        throw;
      }
    }

    #endregion

  }
}
