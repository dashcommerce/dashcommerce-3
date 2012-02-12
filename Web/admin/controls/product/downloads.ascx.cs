using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Core.IO;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Web.Controls;
using SubSonic;
using SubSonic.Utilities;


namespace MettleSystems.dashCommerce.Web.admin.controls.product {
  public partial class downloads : AdminControl {
    #region Member Variables

    int productId = 0;
    string view = string.Empty;

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        productId = Utility.GetIntParameter("productId");
        view = Utility.GetParameter("view");
        if (view == "dl") {
          if (!Page.IsPostBack) {
            LoadAvailableDownloads();
            LoadAssociatedDownloads();
          }
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(downloads).Name + ".Page_Load", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(LocalizationUtility.GetCriticalMessageText(ex.Message));
      }
    }

    /// <summary>
    /// Handles the Category event of the Add control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void lbAdd_Click(object sender, CommandEventArgs e) {
      try {
        int artifactId = 0;
        int.TryParse(e.CommandArgument.ToString(), out artifactId);
        ProductDownloadMap map = new ProductDownloadMap();
        map.DownloadId = artifactId;
        map.ProductId = productId;
        map.Save(WebUtility.GetUserName());
        LoadAvailableDownloads();
        LoadAssociatedDownloads();
      }
      catch (Exception ex) {
        Logger.Error(typeof(downloads).Name + ".Add_Category", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(LocalizationUtility.GetCriticalMessageText(ex.Message));
      }
    }

    /// <summary>
    /// Handles the Click event of the lbDelete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.CommandEventArgs"/> instance containing the event data.</param>
    protected void lbDelete_Click(object sender, CommandEventArgs e) {
      try {
        int artifactId = 0;
        bool isParsed = int.TryParse(e.CommandArgument.ToString(), out artifactId);
        if (isParsed) {
          Query query = new Query(ProductDownloadMap.Schema).WHERE(ProductDownloadMap.Columns.DownloadId, artifactId).AND(ProductDownloadMap.Columns.ProductId, productId);
          query.QueryType = QueryType.Delete;
          query.Execute();
          LoadAvailableDownloads();
          LoadAssociatedDownloads();
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(downloads).Name + ".lbDelete_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(LocalizationUtility.GetCriticalMessageText(ex.Message));
      }
    }

    /// <summary>
    /// Handles the ItemDataBound event of the dgProductCategories control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridItemEventArgs"/> instance containing the event data.</param>
    private void dgProductDownloads_ItemDataBound(object sender, DataGridItemEventArgs e) {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        LinkButton deleteButton = e.Item.Cells[1].FindControl("lbDelete") as LinkButton;
        if (deleteButton != null) {
          deleteButton.Text = LocalizationUtility.GetText("lblDelete");
          deleteButton.Attributes.Add("onclick", "return confirm(\"" + LocalizationUtility.GetText("lblConfirmDelete") + "\");return false;");
        }
        e.Item.Attributes.Add("onmouseover", "this.className = \"over\";");
        e.Item.Attributes.Add("onmouseout", "this.className = this.className.replace(\"over\", \"\");");
      }
    }

    #endregion

    #region Methods

    #region Private

    private void LoadAvailableDownloads() {
      DownloadCollection artifactCollection = new ProductController().FetchAvailableDownloadsByProductId(productId);
      dgDownloads.DataSource = artifactCollection;
      dgDownloads.ItemDataBound += new DataGridItemEventHandler(dgDownloads_ItemDataBound);
      dgDownloads.Columns[0].HeaderText = LocalizationUtility.GetText("hdrTitle");
      dgDownloads.Columns[1].HeaderText = LocalizationUtility.GetText("hdrPath");
      dgDownloads.Columns[2].HeaderText = LocalizationUtility.GetText("hdrAdd");
      dgDownloads.DataBind();
    }

    void dgDownloads_ItemDataBound(object sender, DataGridItemEventArgs e) {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        LinkButton addButton = e.Item.Cells[1].FindControl("lbAdd") as LinkButton;
        if (addButton != null) {
          addButton.Text = LocalizationUtility.GetText("lblAdd");
        }
      }
    }

    /// <summary>
    /// Loads the categories.
    /// </summary>
    private void LoadAssociatedDownloads() {
      DownloadCollection artifactCollection = new ProductController().FetchAssociatedDownloadsByProductId(productId);
      dgProductDownloads.DataSource = artifactCollection;
      dgProductDownloads.ItemDataBound += new DataGridItemEventHandler(dgProductDownloads_ItemDataBound);
      dgProductDownloads.Columns[0].HeaderText = LocalizationUtility.GetText("hdrTitle");
      dgProductDownloads.Columns[1].HeaderText = LocalizationUtility.GetText("lblDelete");
      dgProductDownloads.DataBind();
    }


    #endregion

    #endregion
  }
}