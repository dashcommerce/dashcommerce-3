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

using MettleSystems.dashCommerce.Content;
using MettleSystems.dashCommerce.Content.Caching;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using SubSonic;

namespace MettleSystems.dashCommerce.Web.admin {
  public partial class contentedit : MettleSystems.dashCommerce.Store.Web.AdminPage {

    #region Member Variables

    DataSet ds;
    int _selectedPageId = -1;

    #endregion

    #region Page Events

    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Init"></see> event to initialize the page.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected override void OnInit(EventArgs e) {
      Session["FCKeditor:UserFilesPath"] = @"~/repository/content/";
      base.OnInit(e);
    }

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        SetContentEditProperties();
        btnDelete.Visible = false;
        //http://aspalliance.com/822
        if(!Page.IsPostBack) {
          GetPageDataSet();
          LoadTreeView(ds);
          LoadChildren(0);
          LoadParentPageDropDown(ds);
          LoadTemplates();
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(contentedit).Name + ".Page_Load", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Selected event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Selected(object sender, EventArgs e) {
      try {
        int pageId = -1;
        int.TryParse(tvPages.SelectedNode.Value, out pageId);
        _selectedPageId = pageId;
        if(pageId > -1) {
          Content.Page page = new Content.Page(pageId);
          lblPageId.Text = page.PageId.ToString();
          ddlParentPage.SelectedValue = page.ParentId.ToString();
          txtTitle.Text = page.Title;
          txtMenuTitle.Text = page.MenuTitle;
          txtKeywords.Text = page.Keywords;
          txtDescription.Text = page.Description;
          ddlPageTemplate.SelectedValue = (page.TemplateId != 0) ? page.TemplateId.ToString() : "1";
          //if not kids, then set the delete button
          int childCount = new Query(Content.Page.Schema).WHERE(Content.Page.Columns.ParentId, Comparison.Equals, pageId).GetCount(Content.Page.Columns.ParentId);
          int pagecount = new Query(Content.Page.Schema).WHERE(Content.Page.Columns.ParentId, Comparison.Equals, 0).GetCount(Content.Page.Columns.PageId);
          if (childCount <= 0 && pagecount > 1) {
              btnDelete.Visible = true;
          }
          //Load up the reorder
          if(childCount > 0) {
            LoadChildren(pageId);
          }
          //Load up the regions
          if(page.PageId > 0) { //not the root node
            pnlRegions.Visible = true;
            LoadRegions(pageId);
            hlAddRegion.NavigateUrl = string.Format("~/admin/region.aspx?pageId={0}&regionId=-1", pageId);
          }
          else {
            pnlRegions.Visible = false;
          }
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(contentedit).Name + ".Page_Selected", ex);
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
        int pageId = 0;
        int.TryParse(lblPageId.Text, out pageId);
        if(pageId > 0) {
          Content.Page page = new Content.Page(pageId);
          int pageToLoadChildren = page.ParentId;
          Content.Page.Delete(pageId);
          PageCache.RemovePageByID(pageId);//Clear the Item from the cache.
          PageMenuCache.RefreshMenuPageCollection();
          GetPageDataSet();
          LoadTreeView(ds);
          LoadChildren(pageToLoadChildren);
          LoadParentPageDropDown(ds);
          btnDelete.Visible = false;
          Reset();
          Master.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblPageDeleted"));
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(contentedit).Name + ".btnDelete_Click", ex);
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
        Logger.Error(typeof(contentedit).Name + ".btnReset_Click", ex);
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
        Content.Page page;
        int parentId = 0;
        int pageId = 0;
        int.TryParse(lblPageId.Text, out pageId);
        if(pageId > 0) {
          page = new Content.Page(pageId);
        }
        else {
          page = new Content.Page();
          page.PageGuid = Guid.NewGuid();
        }
        int.TryParse(ddlParentPage.SelectedValue, out parentId);
        //if(parentId != page.PageId) {//add it to the end of the new parent category
          object sortOrder = new Query(Content.Page.Schema).WHERE(Content.Page.Columns.ParentId, Comparison.Equals, parentId).GetMax(Content.Page.Columns.SortOrder);
          page.SortOrder = string.IsNullOrEmpty(sortOrder.ToString()) ? 1 : (int)sortOrder + 1;
        //}
        page.ParentId = parentId;
        page.Title = txtTitle.Text;
        page.MenuTitle = txtMenuTitle.Text;
        page.Keywords = txtKeywords.Text;
        page.Description = txtDescription.Text;
        int templateId = 1; //default to 3 column
        int.TryParse(ddlPageTemplate.SelectedValue, out templateId);
        page.TemplateId = templateId;
        //page.Content = HttpUtility.HtmlEncode(txtContent.Value);
        page.Save(WebUtility.GetUserName());
        //Remove from cache will make it reload on the next request.
        PageCache.RemovePageByID(pageId);
        PageMenuCache.RefreshMenuPageCollection();
        Reset();
        GetPageDataSet();
        LoadTreeView(ds);
        LoadChildren(page.ParentId);
        LoadParentPageDropDown(ds);
        Master.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblPageSaved"));
      }
      catch(Exception ex) {
        Logger.Error(typeof(contentedit).Name + ".btnSave_Click", ex);
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
        int pageId = -1;
        ImageButton theButton = sender as ImageButton;
        bool isParsed = int.TryParse(theButton.CommandArgument.ToString(), out pageId);
        if(isParsed) {
          Content.Page selectedPage = new Content.Page(pageId);
          Query query = new Query(Content.Page.Schema).
            WHERE(Content.Page.Columns.ParentId, Comparison.Equals, selectedPage.ParentId).
            ORDER_BY(Content.Page.Columns.SortOrder);
          PageCollection pageCollection = new PageController().FetchByQuery(query);
          if(pageCollection != null) {
            Content.Page pageMoved = pageCollection.Find(delegate(Content.Page page) {
              return page.PageId == pageId;
            });
            int index = pageCollection.IndexOf(pageMoved);
            pageCollection.RemoveAt(index);
            if(theButton.CommandName.ToLower() == "up") {
              pageCollection.Insert(index - 1, pageMoved);
            }
            else if(theButton.CommandName.ToLower() == "down") {
              pageCollection.Insert(index + 1, pageMoved);
            }
            int i = 1;
            foreach (Content.Page page in pageCollection) {
              page.SortOrder = i++;
            }
            pageCollection.SaveAll(WebUtility.GetUserName());
            GetPageDataSet();
            LoadTreeView(ds);
            LoadChildren(selectedPage.ParentId);
            LoadParentPageDropDown(ds);
          }
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(contentedit).Name + ".Items_ItemReorder", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }
    
    protected void Regions_ItemReorder(object sender, EventArgs e) {}

    /// <summary>
    /// Handles the Click event of the lbDelete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.CommandEventArgs"/> instance containing the event data.</param>
    protected void lbDelete_Click(object sender, CommandEventArgs e) {
      int regionId = 0;
      int.TryParse(e.CommandArgument.ToString(), out regionId);
      int pageId = 0;
      int.TryParse(lblPageId.Text, out pageId);
      if(regionId > 0) {
        Query query = new Query(PageRegionMap.Schema).
          AddWhere(PageRegionMap.Columns.RegionId, Comparison.Equals, regionId).
          AddWhere(PageRegionMap.Columns.PageId, Comparison.Equals, pageId);
        query.QueryType = QueryType.Delete;
        query.Execute(); 
        Region.Delete(regionId);
        LoadRegions(pageId);
      }
    }


    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Loads the children.
    /// </summary>
    /// <param name="pageId">The page id.</param>
    private void LoadChildren(int pageId) {
      PageCollection pageCollection = new PageCollection().
        Where(Content.Page.Columns.ParentId, Comparison.Equals, pageId).
        OrderByAsc(Content.Page.Columns.SortOrder).
        Load();
      if(pageCollection.Count > 0) {
        dgChildren.DataSource = pageCollection;
        dgChildren.Columns[0].HeaderText = LocalizationUtility.GetText("hdrMove");
        dgChildren.Columns[1].HeaderText = LocalizationUtility.GetText("hdrTitle");
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
    /// Gets the page data set.
    /// </summary>
    private void GetPageDataSet() {
      ds = new Content.PageController().FetchPageList();
      //Add the root node
      ds.Tables[0].Rows.Add("0", null, null, LocalizationUtility.GetText("lblRoot"), LocalizationUtility.GetText("lblRoot"), null, null, 0, 1, null, null, null, null);
    }

    /// <summary>
    /// Loads the tree view.
    /// </summary>
    /// <param name="ds">The ds.</param>
    private void LoadTreeView(DataSet ds) {
      tvPages.Nodes.Clear();
      xmlDataSource.EnableCaching = false;
      xmlDataSource.Data = ds.GetXml();
    }

    /// <summary>
    /// Loads the parent page drop down.
    /// </summary>
    /// <param name="ds">The ds.</param>
    private void LoadParentPageDropDown(DataSet ds) {
      ddlParentPage.Items.Clear();
      DataRow[] rootNodes = ds.Tables["Menu"].Select("ParentId = 0");
      FillNodes(rootNodes, 1);
      ddlParentPage.Items.Insert(0, new ListItem(LocalizationUtility.GetText("lblRoot"), "0"));
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
        name += nodes[i]["MenuTitle"].ToString();
        ddlParentPage.Items.Add(new ListItem(name, nodes[i]["PageId"].ToString()));
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
    /// Loads the templates.
    /// </summary>
    private void LoadTemplates() {
      TemplateCollection templateCollection = new TemplateController().FetchAll();
      ddlPageTemplate.DataSource = templateCollection;
      ddlPageTemplate.DataTextField = "Name";
      ddlPageTemplate.DataValueField = "TemplateId";
      ddlPageTemplate.DataBind();
    }

    /// <summary>
    /// Loads the regions.
    /// </summary>
    /// <param name="pageId">The page id.</param>
    private void LoadRegions(int pageId) {
      RegionCollection regionCollection = new RegionController().FetchRegionsByPageId(pageId);
      if(regionCollection.Count > 0) {
        dgRegions.DataSource = regionCollection;
        dgRegions.ItemDataBound += new DataGridItemEventHandler(dgRegions_ItemDataBound);
        //dgRegions.Columns[0].HeaderText = LocalizationUtility.GetText("hdrMove");
        dgRegions.Columns[0].HeaderText = LocalizationUtility.GetText("hdrEditRegion");
        dgRegions.Columns[1].HeaderText = LocalizationUtility.GetText("hdrTemplateRegion");
        dgRegions.Columns[2].HeaderText = LocalizationUtility.GetText("hdrTitle");
        dgRegions.Columns[3].HeaderText = LocalizationUtility.GetText("hdrSortOrder");
        dgRegions.Columns[4].HeaderText = LocalizationUtility.GetText("hdrEdit");
        dgRegions.Columns[5].HeaderText = LocalizationUtility.GetText("hdrDelete");
        dgRegions.DataBind();
      } else {
        dgRegions.DataSource = null;
        dgRegions.DataBind();    
      }
    }

    /// <summary>
    /// Handles the ItemDataBound event of the dgRegions control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridItemEventArgs"/> instance containing the event data.</param>
    void dgRegions_ItemDataBound(object sender, DataGridItemEventArgs e) {
      if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        Region region = e.Item.DataItem as Region;
        HyperLink editRegionLink = e.Item.FindControl("hlEditRegion") as HyperLink;
        if(editRegionLink != null && region != null) {
          editRegionLink.NavigateUrl = string.Format("~/admin/region.aspx?pageId={0}&regionId={1}", _selectedPageId, region.RegionId);
          editRegionLink.Text = LocalizationUtility.GetText("lblEditRegion");
        }
        HyperLink editLink = e.Item.FindControl("hlEdit") as HyperLink;
        if(editLink != null && region != null) {
          editLink.NavigateUrl = string.Format("~/admin/provider.aspx?pageId={0}&regionId={1}&providerId={2}", _selectedPageId, region.RegionId, region.ProviderId);
          editLink.Text = LocalizationUtility.GetText("lblEdit");
        }
        LinkButton deleteButton = e.Item.FindControl("lbDelete") as LinkButton;
        if(deleteButton != null && region != null) {
          deleteButton.Text = LocalizationUtility.GetText("lblDelete");
          deleteButton.Attributes.Add("onclick", "return confirm(\"" + LocalizationUtility.GetText("lblConfirmDelete") + "\");return false;");
        }
      }
    }


    /// <summary>
    /// Resets this instance.
    /// </summary>
    private void Reset() {
      lblPageId.Text = string.Empty;
      ddlParentPage.SelectedIndex = 0;
      txtTitle.Text = string.Empty;
      txtMenuTitle.Text = string.Empty;
      txtKeywords.Text = string.Empty;
      txtDescription.Text = string.Empty;
      //txtContent.Value = string.Empty;
    }

    /// <summary>
    /// Sets the content edit properties.
    /// </summary>
    private void SetContentEditProperties() {
      this.Title = LocalizationUtility.GetText("titleContentManagement");
    }

    #endregion

    #endregion

  }
}
