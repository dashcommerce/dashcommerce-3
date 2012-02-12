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
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Web.Controls;
using SubSonic;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin.controls.product {
  public partial class categories : AdminControl {

    #region Member Variables

    int productId = 0;
    string view = string.Empty;
    DataSet ds;

    #endregion

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
        productId = Utility.GetIntParameter("productId");
        view = Utility.GetParameter("view");
        if(view == "c") {
          SetCategoriesProperties();
          if(!Page.IsPostBack) {
            ds = new Query(Category.Schema).ExecuteDataSet();
            LoadTreeView(ds);
            LoadCategories();
          }
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(categories).Name + ".Page_Load", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Category event of the Add control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Add_Category(object sender, EventArgs e) {
      try {
        int categoryId = 0;
        int.TryParse(tvCategory.SelectedNode.Value, out categoryId);
        ProductCategoryMap map = new ProductCategoryMap();
        map.CategoryId = categoryId;
        map.ProductId = productId;
        map.Save(WebUtility.GetUserName());
        Store.Caching.ProductCache.RemoveProductsByCategoryIdFromCache(categoryId);
        Store.Caching.CategoryCache.RefreshProductAssociatedCategories(productId);
        LoadCategories();
      }
      catch(Exception ex) {
        Logger.Error(typeof(categories).Name + ".Add_Category", ex);
        throw ex;
      }
    }

    /// <summary>
    /// Handles the Click event of the lbDelete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.CommandEventArgs"/> instance containing the event data.</param>
    protected void lbDelete_Click(object sender, CommandEventArgs e) {
      try {
        int categoryId = 0;
        bool isParsed = int.TryParse(e.CommandArgument.ToString(), out categoryId);
        if(isParsed) {
          Query query = new Query(ProductCategoryMap.Schema).WHERE(ProductCategoryMap.Columns.CategoryId, categoryId).AND(ProductCategoryMap.Columns.ProductId, productId);
          query.QueryType = QueryType.Delete;
          query.Execute();
          Store.Caching.ProductCache.RemoveProductsByCategoryIdFromCache(categoryId);
          Store.Caching.CategoryCache.RefreshProductAssociatedCategories(productId);
          LoadCategories();
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(categories).Name + ".lbDelete_Click", ex);
        throw ex;
      }
    }

    /// <summary>
    /// Handles the ItemDataBound event of the dgProductCategories control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridItemEventArgs"/> instance containing the event data.</param>
    private void dgProductCategories_ItemDataBound(object sender, DataGridItemEventArgs e) {
      if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        LinkButton deleteButton = e.Item.Cells[1].FindControl("lbDelete") as LinkButton;
        if(deleteButton != null) {
          deleteButton.Text = LocalizationUtility.GetText("lblDelete");
          deleteButton.Attributes.Add("onclick", "return confirm(\"" + LocalizationUtility.GetText("lblConfirmDelete") + "\");return false;");
        }
      }
    }

    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Loads the tree view.
    /// </summary>
    /// <param name="ds">The ds.</param>
    private void LoadTreeView(DataSet ds) {
      tvCategory.Nodes.Clear();
      ds.DataSetName = "Menus";
      ds.Tables[0].TableName = "Menu";
      DataRelation relation = new DataRelation("ParentChild", ds.Tables["Menu"].Columns["CategoryId"], ds.Tables["Menu"].Columns["ParentId"], false);
      relation.Nested = true;
      ds.Relations.Add(relation);
      xmlDataSource.EnableCaching = false;
      xmlDataSource.Data = ds.GetXml();
    }

    /// <summary>
    /// Loads the categories.
    /// </summary>
    private void LoadCategories() {
      CategoryCollection categoryCollection = new ProductController().FetchAssociatedCategoriesByProductId(productId);
      dgProductCategories.DataSource = categoryCollection;
      dgProductCategories.Columns[0].HeaderText = LocalizationUtility.GetText("lblCategory");
      dgProductCategories.Columns[1].HeaderText = LocalizationUtility.GetText("lblDelete");
      dgProductCategories.ItemDataBound += new DataGridItemEventHandler(dgProductCategories_ItemDataBound);
      dgProductCategories.DataBind();
    }

    /// <summary>
    /// Sets the categories properties.
    /// </summary>
    private void SetCategoriesProperties() {
      this.Page.Title = LocalizationUtility.GetText("titleProductEditCategories");
    }

    #endregion

    #endregion

  }
}
