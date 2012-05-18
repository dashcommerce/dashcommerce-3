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
using SubSonic;

namespace MettleSystems.dashCommerce.Web.admin {
  public partial class categoryedit : MettleSystems.dashCommerce.Store.Web.AdminPage {

    #region Member Variables

    DataSet ds;

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        SetCategoryEditProperties();
        btnDelete.Visible = false;
        //http://aspalliance.com/822
        if(!Page.IsPostBack) {
          GetCategoryDataSet();
          LoadTreeView(ds);
          LoadChildren(0);
          LoadParentCategoryDropDown(ds);
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(categoryedit).Name + ".Page_Load", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Selected event of the Category control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Category_Selected(object sender, EventArgs e) {
      try {
        int categoryId = -1;
        int.TryParse(tvCategory.SelectedNode.Value, out categoryId);
        if(categoryId > -1) {
          Category category = new Category(categoryId);
          lblCategoryId.Text = category.CategoryId.ToString();
          ddlParentCategory.SelectedValue = category.ParentId.ToString();
          txtName.Text = category.Name;
          txtImageFile.Text = category.ImageFile;
          txtDescription.Text = category.Description;
          //if no kids, then set the delete button
          int childCount = new Query(Category.Schema).WHERE(Category.Columns.ParentId, Comparison.Equals, categoryId).GetCount(Category.Columns.ParentId);
          if(childCount <= 0) {
            btnDelete.Visible = true;
          }
          //Load up the reorder
          if(childCount > 0) {
            LoadChildren(categoryId);
          }
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(categoryedit).Name + ".Category_Selected", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnDelete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnDelete_Click(object sender, EventArgs e) {
      try {
        int categoryId = 0;
        int.TryParse(lblCategoryId.Text, out categoryId);
        if(categoryId > 0) {
          Category category = new Category(categoryId);
          int categoryToLoadChildren = category.CategoryId;
          Category.Delete(categoryId);
          RefreshCache(categoryId);
          GetCategoryDataSet();
          LoadTreeView(ds);
          LoadChildren(categoryToLoadChildren);
          LoadParentCategoryDropDown(ds);
          btnDelete.Visible = false;
          Reset();
          Master.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblProductCategoryDeleted"));
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(categoryedit).Name + ".btnDelete_Click", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnReset control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnReset_Click(object sender, EventArgs e) {
      try {
        Reset();
      }
      catch(Exception ex) {
        Logger.Error(typeof(categoryedit).Name + ".btnReset_Click", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e) {
      try {
        Category category;
        int parentId = 0;
        int categoryId = 0;
        int.TryParse(lblCategoryId.Text, out categoryId);
        if(categoryId > 0) {
          category = new Category(categoryId);
        }
        else {
          category = new Category();
          category.CategoryGuid = Guid.NewGuid();
        }
        category.Name = txtName.Text.Trim();
        int.TryParse(ddlParentCategory.SelectedValue, out parentId);
        //if((category.CategoryId == 0 || category.ParentId != parentId) && parentId != category.CategoryId) {//add it to the end of the new parent category
          object sortOrder = new Query(Category.Schema).WHERE(Category.Columns.ParentId, Comparison.Equals, parentId).GetMax(Category.Columns.SortOrder);
          category.SortOrder = string.IsNullOrEmpty(sortOrder.ToString()) ? 1 : (int)sortOrder + 1;
        //}
        category.ParentId = parentId;
        category.ImageFile = txtImageFile.Text.Trim();
        category.Description = txtDescription.Text.Trim();
        category.Save(WebUtility.GetUserName());
        RefreshCache(categoryId);
        Reset();
        GetCategoryDataSet();
        LoadTreeView(ds);
        LoadChildren(category.ParentId);
        LoadParentCategoryDropDown(ds);
        Master.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblProductCategorySaved"));
      }
      catch(Exception ex) {
        Logger.Error(typeof(categoryedit).Name + ".btnSave_Click", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the ItemReorder event of the Items control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Items_ItemReorder(object sender, EventArgs e) {
      try {
        int categoryId = -1;
        ImageButton theButton = sender as ImageButton;
        bool isParsed = int.TryParse(theButton.CommandArgument.ToString(), out categoryId);
        if(isParsed) {
          Category selectedCategory = new Category(categoryId);
          Query query = new Query(Category.Schema).
            WHERE(Category.Columns.ParentId, Comparison.Equals, selectedCategory.ParentId).
            ORDER_BY(Category.Columns.SortOrder);
          CategoryCollection categoryCollection = new CategoryController().FetchByQuery(query);
          if(categoryCollection != null) {
            Category categoryMoved = categoryCollection.Find(delegate(Category category) {
              return category.CategoryId == categoryId;
            });
            int index = categoryCollection.IndexOf(categoryMoved);
            categoryCollection.RemoveAt(index);
            if(theButton.CommandName.ToLower() == "up") {
              categoryCollection.Insert(index - 1, categoryMoved);
            }
            else if(theButton.CommandName.ToLower() == "down") {
              categoryCollection.Insert(index + 1, categoryMoved);
            }
            int i = 1;
            foreach(Category category in categoryCollection) {
              category.SortOrder = i++;
            }
            RefreshCache(categoryId);
            categoryCollection.SaveAll(WebUtility.GetUserName());
            GetCategoryDataSet();
            LoadTreeView(ds);
            LoadChildren(selectedCategory.ParentId);
            LoadParentCategoryDropDown(ds);
          }
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(categoryedit).Name + ".Items_ItemReorder", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }    

    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Loads the children.
    /// </summary>
    /// <param name="categoryId">The category id.</param>
    private void LoadChildren(int categoryId) {
      CategoryCollection categoryCollection = new CategoryCollection().
        Where(Category.Columns.ParentId, Comparison.Equals, categoryId).
        OrderByAsc(Category.Columns.SortOrder).
        Load();
      if(categoryCollection.Count > 0) {
        dgChildren.DataSource = categoryCollection;
        dgChildren.Columns[0].HeaderText = LocalizationUtility.GetText("hdrMove");
        dgChildren.Columns[1].HeaderText = LocalizationUtility.GetText("hdrName");
        dgChildren.Columns[2].HeaderText = LocalizationUtility.GetText("hdrSortOrder");
        dgChildren.DataBind();
        ImageButton lbUp = dgChildren.Items[0].Cells[1].FindControl("lbUp") as ImageButton;
        if(lbUp != null) {
          lbUp.Visible = false;
        }
        ImageButton lbDown = dgChildren.Items[dgChildren.Items.Count - 1].Cells[1].FindControl("lbDown") as ImageButton;
        if(lbDown != null) {
          lbDown.Visible = false;
        }
      }
    }

    /// <summary>
    /// Gets the category data set.
    /// </summary>
    private void GetCategoryDataSet() {
      ds = new CategoryController().FetchCategoryList();
      //Add the root node
      ds.Tables[0].Rows.Add("0", null, null, LocalizationUtility.GetText("lblRoot"), null, LocalizationUtility.GetText("lblRoot"), 0, null, null, null, null);
    }

    /// <summary>
    /// Loads the tree view.
    /// </summary>
    /// <param name="ds">The ds.</param>
    private void LoadTreeView(DataSet ds) {
      tvCategory.Nodes.Clear();
      xmlDataSource.EnableCaching = false;
      xmlDataSource.Data = ds.GetXml();
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
      for(int i = 0; i <= nodes.GetUpperBound(0); i++) {
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
    /// Resets this instance.
    /// </summary>
    private void Reset() {
      lblCategoryId.Text = string.Empty;
      ddlParentCategory.SelectedIndex = 0;
      txtName.Text = string.Empty;
      txtImageFile.Text = string.Empty;
      txtDescription.Text = string.Empty;
    }

    /// <summary>
    /// Refresh the Cache.
    /// </summary>
    /// <param name="categoryId"></param>
    private static void RefreshCache(int categoryId) {
      Store.Caching.CategoryCache.RefreshCategoryMenuCollection();//Refresh the menu cache.
      Store.Caching.CategoryCache.RemoveCategoryInfoFromCache(categoryId);//Remove the Category from the cache.
      Store.Caching.CategoryCache.RefreshCategoryBreadCrumbs(categoryId); //refresh the breadcrumbs
      Store.Caching.CategoryCache.RefreshAllCategories(); //refresh all teh site category cache
    }

    /// <summary>
    /// Sets the category edit properties.
    /// </summary>
    private void SetCategoryEditProperties() {
      hlImageSelector.NavigateUrl = string.Format("~/admin/imageselector.aspx?view=c&controlId={0}", txtImageFile.ClientID);
      this.Title = LocalizationUtility.GetText("titleProductCategories");
    }

    #endregion

    #endregion

  }
}
