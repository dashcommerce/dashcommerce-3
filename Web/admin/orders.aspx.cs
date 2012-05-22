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
