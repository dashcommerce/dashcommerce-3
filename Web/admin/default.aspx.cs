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
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Core.Caching;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using SubSonic;

namespace MettleSystems.dashCommerce.Web.admin {
  public partial class _default : MettleSystems.dashCommerce.Store.Web.AdminPage {

    #region Page Events

    /// <summary>
    /// Handles the PreRender event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_PreRender(object sender, EventArgs e) {
      upDisplay.ProgressTemplate = new UpdatingProgressTemplate();
    }    

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        SetDefaulProperties();
        SiteSettings siteSettings = SiteSettingCache.GetSiteSettings(); ;
        if (siteSettings.CollectSearchTerms) {
          LoadSearchTerms();
        }
        if (!string.IsNullOrEmpty(siteSettings.NewsFeedUrl)) {
          news.NewsFeedUrl = siteSettings.NewsFeedUrl;
        }
        else {
          string newsFeedUrl = ConfigurationManager.AppSettings["defaultNewsFeedUrl"];
          if(!string.IsNullOrEmpty(newsFeedUrl)){
            if (news != null) {//it's not caching
              news.NewsFeedUrl = newsFeedUrl;
            }
          }
        }
        if(!Page.IsPostBack) {
          LoadToDo();
          LoadOrders();
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(_default).Name + ".Page_Load", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnAdd control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnAdd_Click(object sender, EventArgs e) {
      if(!string.IsNullOrEmpty(txtToDo.Text)) {
        ToDo toDo = new ToDo();
        toDo.ToDoX = txtToDo.Text;
        toDo.Save(WebUtility.GetUserName());
        LoadToDo();
        txtToDo.Text = string.Empty;
      }
    }

    /// <summary>
    /// Handles the Click event of the lbDelete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.CommandEventArgs"/> instance containing the event data.</param>
    protected void lbDelete_Click(object sender, CommandEventArgs e) {
      int toDoId = 0;
      int.TryParse(e.CommandArgument.ToString(), out toDoId);
      if(toDoId > 0) {
        ToDo.Delete(toDoId);
        LoadToDo();
      }
    }

    /// <summary>
    /// Handles the ItemDataBound event of the dgToDo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridItemEventArgs"/> instance containing the event data.</param>
    void dgToDo_ItemDataBound(object sender, DataGridItemEventArgs e) {
      if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        LinkButton lbDelete = e.Item.Cells[1].FindControl("lbDelete") as LinkButton;
        if(lbDelete != null) {
          lbDelete.Text = LocalizationUtility.GetText("lblDelete");
          lbDelete.Attributes.Add("onclick", "return confirm(\"" + LocalizationUtility.GetText("lblConfirmDelete") + "\");return false;");
        }
      }
    }

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

    #region Methods

    #region Private

    /// <summary>
    /// Loads the orders.
    /// </summary>
    private void LoadOrders() {
      Query query = new Query(Order.Schema).AddWhere(Order.Columns.OrderStatusDescriptorId, Comparison.Equals, (int)OrderStatus.ReceivedPaymentProcessingOrder);
      OrderCollection orderCollection = new OrderController().FetchByQuery(query);
      orderCollection.Sort(Order.Columns.ModifiedOn, false);
      BindOrderCollection(orderCollection);
    }

    /// <summary>
    /// Binds the order collection.
    /// </summary>
    /// <param name="orderCollection">The order collection.</param>
    private void BindOrderCollection(OrderCollection orderCollection) {
      if (orderCollection.Count > 0) {
        dgOrders.DataSource = orderCollection;
        dgOrders.ItemDataBound += new DataGridItemEventHandler(dgOrders_ItemDataBound);
        dgOrders.Columns[0].HeaderText = LocalizationUtility.GetText("hdrEdit");
        dgOrders.Columns[1].HeaderText = LocalizationUtility.GetText("hdrOrderNumber");
        dgOrders.Columns[2].HeaderText = LocalizationUtility.GetText("hdrStatus");
        dgOrders.Columns[3].HeaderText = LocalizationUtility.GetText("hdrTotal");
        dgOrders.Columns[3].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
        dgOrders.Columns[4].HeaderText = LocalizationUtility.GetText("hdrLastModified");
        dgOrders.Columns[4].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
        dgOrders.DataBind();
      }
    }

    /// <summary>
    /// Handles the ItemDataBound event of the dgOrders control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridItemEventArgs"/> instance containing the event data.</param>
    void dgOrders_ItemDataBound(object sender, DataGridItemEventArgs e) {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        HyperLink editLink = e.Item.Cells[0].FindControl("hlEditLink") as HyperLink;
        if (editLink != null) {
          editLink.Text = LocalizationUtility.GetText("hlEditLink");
        }
      }
    }

    /// <summary>
    /// Loads the search terms.
    /// </summary>
    private void LoadSearchTerms() {
      pnlSearchTerms.Visible = true;
      DataSet ds = new BrowsingLogController().FetchBrowsingLogSearchTerms();
      dgSearchTerms.DataSource = ds;
      dgSearchTerms.Columns[0].HeaderText = LocalizationUtility.GetText("hdrSearchTerm");
      dgSearchTerms.Columns[1].HeaderText = LocalizationUtility.GetText("hdrCount");
      dgSearchTerms.DataBind();
    }

    /// <summary>
    /// Loads to do.
    /// </summary>
    private void LoadToDo() {
      ToDoCollection toDoCollection = new ToDoController().FetchAll();
      dgToDo.DataSource = toDoCollection;
      dgToDo.ItemDataBound += new DataGridItemEventHandler(dgToDo_ItemDataBound);
      dgToDo.Columns[0].HeaderText = LocalizationUtility.GetText("hdrTodo");
      dgToDo.Columns[1].HeaderText = LocalizationUtility.GetText("hdrDelete");
      dgToDo.DataBind();
    }

    /// <summary>
    /// Sets the defaul properties.
    /// </summary>
    private void SetDefaulProperties() {
      this.Title = LocalizationUtility.GetText("titleDashBoard");
    }

    #endregion

    #endregion

  }
}
