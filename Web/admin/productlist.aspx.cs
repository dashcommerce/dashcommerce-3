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
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;

namespace MettleSystems.dashCommerce.Web.admin {
  public partial class productlist : MettleSystems.dashCommerce.Store.Web.AdminPage {
  
    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        if (!Page.IsPostBack) {
          LoadCategories();
          LoadProducts();
          SetProductListProperties();
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(productlist).Name + ".Page_Load", ex);
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
        LoadProducts();
      }
      catch (Exception ex) {
        Logger.Error(typeof(productlist).Name + ".btnSearch_Click", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the dgProduct control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridPageChangedEventArgs"/> instance containing the event data.</param>
    protected void dgProduct_PageIndexChanging(object sender, DataGridPageChangedEventArgs e) {
      LoadProducts();
      dgProducts.CurrentPageIndex = e.NewPageIndex;
      dgProducts.DataBind();
    }

    /// <summary>
    /// Handles the ItemDataBound event of the dgProducts control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridItemEventArgs"/> instance containing the event data.</param>
    void dgProducts_ItemDataBound(object sender, DataGridItemEventArgs e) {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        HyperLink editLink = e.Item.Cells[2].FindControl("hlEditLink") as HyperLink;
        if (editLink != null) {
          editLink.Text = LocalizationUtility.GetText("hlEditLink");
        }
      }
    }

    #endregion
    
    #region Methods
    
    #region Protected

    /// <summary>
    /// Formats the edit URL.
    /// </summary>
    /// <param name="productId">The product id.</param>
    /// <returns></returns>
    protected string FormatEditUrl(string productId) {
      return string.Format("productedit.aspx?view=g&productId={0}", productId);
    }
    
    #endregion
    
    #region Private

    /// <summary>
    /// Loads the categories.
    /// </summary>
    private void LoadCategories() {
      DataSet ds = new CategoryController().FetchCategoryList();
      LoadParentCategoryDropDown(ds);
    }

    /// <summary>
    /// Loads the parent category drop down.
    /// </summary>
    /// <param name="ds">The ds.</param>
    private void LoadParentCategoryDropDown(DataSet ds) {
      ddlParentCategory.Items.Clear();
      DataRow[] rootNodes = ds.Tables["Menu"].Select("ParentId = 0");
      FillNodes(rootNodes, 1);
      ddlParentCategory.Items.Insert(0, new ListItem(LocalizationUtility.GetText("lblRoot"), "0"));
    }

    /// <summary>
    /// Fills the nodes.
    /// </summary>
    /// <param name="nodes">The nodes.</param>
    /// <param name="level">The level.</param>
    private void FillNodes(DataRow[] nodes, int level) {
      DataRow[] childNodes;
      int oldLevel = level;
      string name = string.Empty;
      for(int i = 0;i <= nodes.GetUpperBound(0);i++) {
        for(int j = 0;j < level;j++) {
          name += "-";
        }
        name += nodes[i]["Name"].ToString();
        ddlParentCategory.Items.Add(new ListItem(name, nodes[i]["CategoryId"].ToString()));
        name = string.Empty;
        childNodes = nodes[i].GetChildRows("ParentChild");
        if(childNodes.GetUpperBound(0) >= 0) {
          level = level + 1;
          FillNodes(childNodes, level);
        }
        level = oldLevel;
      }
    }

    /// <summary>
    /// Loads the products.
    /// </summary>
    private void LoadProducts() {
      ProductCollection productCollection;
      if(ddlParentCategory.SelectedValue == "0") {
        productCollection = new ProductController().FetchAll();
      }
      else {
        int categoryId = 0;
        int.TryParse(ddlParentCategory.SelectedValue, out categoryId);
        productCollection = new ProductController().FetchAllProductsByCategoryId(categoryId);
      }
      lblNumberOfTotalProducts.Text = productCollection.Count.ToString();
      dgProducts.CurrentPageIndex = 0;
      dgProducts.DataSource = productCollection;
      dgProducts.ItemDataBound += new DataGridItemEventHandler(dgProducts_ItemDataBound);
      dgProducts.Columns[0].HeaderText = LocalizationUtility.GetText("hdrEdit");
      dgProducts.Columns[1].HeaderText = LocalizationUtility.GetText("hdrSku");
      dgProducts.Columns[2].HeaderText = LocalizationUtility.GetText("hdrName");
      dgProducts.Columns[3].HeaderText = LocalizationUtility.GetText("hdrIsEnabled");
      dgProducts.Columns[4].HeaderText = LocalizationUtility.GetText("hdrIsDeleted");
      dgProducts.DataBind();
    }

    /// <summary>
    /// Sets the product list properties.
    /// </summary>
    private void SetProductListProperties() {
      this.Title = LocalizationUtility.GetText("titleProductListing");
    }

    #endregion
    
    #endregion

  }
}
