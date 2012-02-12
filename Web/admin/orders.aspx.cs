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
using System.Web.UI;
using System.Web.UI.WebControls;

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using SubSonic;

namespace MettleSystems.dashCommerce.Web.admin {
  public partial class orders : MettleSystems.dashCommerce.Store.Web.AdminPage {

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        SetOrdersProperties();
        LoadOrders();
      }
      catch (Exception ex) {
        Logger.Error(typeof(orders).Name + ".Page_Load", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnSearch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnSearch_Click(object sender, EventArgs e) {
      try {
        if (!string.IsNullOrEmpty(txtOrderNumber.Text)) {
          string likeClause = string.Format("{0}%", txtOrderNumber.Text.Trim());
          Query query = new Query(Order.Schema).AddWhere(Order.Columns.OrderNumber, Comparison.Like, likeClause);
          OrderCollection orderCollection = new OrderController().FetchByQuery(query);
          BindOrderCollection(orderCollection);
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(orders).Name + ".btnSearch_Click", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the ItemDataBound event of the dgOrders control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridItemEventArgs"/> instance containing the event data.</param>
    void dgOrders_ItemDataBound(object sender, DataGridItemEventArgs e) {
      if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        HyperLink editLink = e.Item.Cells[0].FindControl("hlEditLink") as HyperLink;
        if(editLink != null) {
          editLink.Text = LocalizationUtility.GetText("hlEditLink");
        }
      }
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the dgOrders control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridPageChangedEventArgs"/> instance containing the event data.</param>
    protected void dgOrders_PageIndexChanging(object sender, DataGridPageChangedEventArgs e) {
      dgOrders.CurrentPageIndex = e.NewPageIndex;
      dgOrders.DataBind();
    }

    #endregion

    #region Methods

    #region Protected

    /// <summary>
    /// Gets the formatted amount.
    /// </summary>
    /// <param name="total">The total.</param>
    /// <returns></returns>
    protected string GetFormattedAmount(string total) {
      return StoreUtility.GetFormattedAmount(total, true);
    }

    /// <summary>
    /// Formats the edit URL.
    /// </summary>
    /// <param name="orderId">The order id.</param>
    /// <returns></returns>
    protected string FormatEditUrl(string orderId) {
      return string.Format("orderedit.aspx?view=r&orderId={0}", orderId);
    }

    #endregion

    #region Private

    /// <summary>
    /// Sets the orders properties.
    /// </summary>
    private void SetOrdersProperties() {
      Page.Title = LocalizationUtility.GetText("titleSalesOrderSearch");
    }

    /// <summary>
    /// Loads the orders.
    /// </summary>
    private void LoadOrders() {
      Query query = new Query(Order.Schema).AddWhere(Order.Columns.OrderStatusDescriptorId, Comparison.NotEquals, (int)OrderStatus.NotProcessed);
      OrderCollection orderCollection = new OrderController().FetchByQuery(query);
      orderCollection.Sort(Order.Columns.ModifiedOn, false);
      BindOrderCollection(orderCollection);
    }

    /// <summary>
    /// Binds the order collection.
    /// </summary>
    /// <param name="orderCollection">The order collection.</param>
    private void BindOrderCollection(OrderCollection orderCollection) {
      dgOrders.DataSource = orderCollection;
      dgOrders.ItemDataBound += new DataGridItemEventHandler(dgOrders_ItemDataBound);
      dgOrders.Columns[0].HeaderText = LocalizationUtility.GetText("hdrEdit");
      dgOrders.Columns[1].HeaderText = LocalizationUtility.GetText("hdrOrderNumber");
      dgOrders.Columns[2].HeaderText = LocalizationUtility.GetText("hdrStatus");
      dgOrders.Columns[3].HeaderText = LocalizationUtility.GetText("hdrTotal");
      dgOrders.Columns[4].HeaderText = LocalizationUtility.GetText("hdrLastModified");
      dgOrders.DataBind();
    }

    #endregion

    #endregion

  }
}
