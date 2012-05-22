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
using MettleSystems.dashCommerce.Store.Web.Controls;
using SubSonic;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin.controls.product {
  public partial class attributes : AdminControl {
  
    #region Member Variables

    int productId = 0;
    string view = string.Empty;
    Product product;
    
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
        if(view == "a") {
          SetAttributesProperties();
          product = new Product(productId);
          if(!Page.IsPostBack) {
            if(!product.IsEnabled) {
              LoadAssociatedAttributes();
              LoadAvailableAttributes();
            }
            else {
              attributeTable.Visible = false;
              pnlAttributesLocked.Visible = true;
              LoadAttributesLocked();
            }
          }
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(attributes).Name + ".Page_Load", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the ItemReorder event of the Items control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Items_ItemReorder(object sender, EventArgs e) {
      try {
        ImageButton theButton = sender as ImageButton;
        Query query = new Query(ProductAttributeMap.Schema).
          WHERE(ProductAttributeMap.Columns.ProductId, Comparison.Equals, productId).
          ORDER_BY(ProductAttributeMap.Columns.SortOrder);
        ProductAttributeMapCollection productAttributeMapCollection = new ProductAttributeMapController().FetchByQuery(query);
        if(productAttributeMapCollection != null) {
          int attributeId = 0;
          int.TryParse(theButton.CommandArgument.ToString(), out attributeId);
          if(attributeId > 0) {
            ProductAttributeMap productAttributeMapMoved = productAttributeMapCollection.Find(delegate(ProductAttributeMap productAttributeMap) {
              return productAttributeMap.AttributeId == attributeId;
            });
            int index = productAttributeMapCollection.IndexOf(productAttributeMapMoved);
            productAttributeMapCollection.RemoveAt(index);
            if(theButton.CommandName.ToLower() == "up") {
              productAttributeMapCollection.Insert(index - 1, productAttributeMapMoved);
            }
            else if(theButton.CommandName.ToLower() == "down") {
              productAttributeMapCollection.Insert(index + 1, productAttributeMapMoved);
            }
            int i = 1;
            foreach(ProductAttributeMap productAttributeMap in productAttributeMapCollection) {
              productAttributeMap.SortOrder = i++;
            }
            productAttributeMapCollection.SaveAll(WebUtility.GetUserName());
            LoadAssociatedAttributes();
          }
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(attributes).Name + ".Items_ItemReorder", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the lbAdd control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.CommandEventArgs"/> instance containing the event data.</param>
    protected void lbAdd_Click(object sender, CommandEventArgs e) {
      try {
        int attributeId = 0;
        int.TryParse(e.CommandArgument.ToString(), out attributeId);
        if(attributeId > 0) {
          Where where = new Where();
          where.ColumnName = ProductAttributeMap.Columns.ProductId;
          where.DbType = DbType.Int32;
          where.ParameterValue = productId;
          Query query = new Query(ProductAttributeMap.Schema);
          object strSortOrder = query.GetMax(ProductAttributeMap.Columns.SortOrder, where);
          int maxSortOrder = 0;
          int.TryParse(strSortOrder.ToString(), out maxSortOrder);
          ProductAttributeMap map = new ProductAttributeMap();
          map.AttributeId = attributeId;
          map.ProductId = productId;
          map.SortOrder = maxSortOrder + 1;
          map.Save(WebUtility.GetUserName());
          Store.Caching.ProductCache.RemoveAssociatedAttributeCollectionFromCache(productId);
          LoadAvailableAttributes();
          LoadAssociatedAttributes();
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(attributes).Name + ".lbAdd_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the IsRequired control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void IsRequired_Click(object sender, EventArgs e) {
      try {
        CheckBox checkbox = sender as CheckBox;
        if(checkbox != null) {
          DataGridItem row = checkbox.NamingContainer as DataGridItem;
          int attributeId = 0;
          if(row != null) {
            int.TryParse(dgAssociatedAttributes.DataKeys[row.ItemIndex].ToString(), out attributeId);
          }
          Query query = new Query(ProductAttributeMap.Schema).AddWhere(ProductAttributeMap.Columns.AttributeId, Comparison.Equals, attributeId).AddWhere(ProductAttributeMap.Columns.ProductId, Comparison.Equals, productId);
          ProductAttributeMapCollection productAttributeMapCollection = new ProductAttributeMapController().FetchByQuery(query);
          if(productAttributeMapCollection.Count > 0) {
            if(checkbox.Checked) {
              productAttributeMapCollection[0].IsRequired = true;
            }
            else {
              productAttributeMapCollection[0].IsRequired = false;
            }
            productAttributeMapCollection[0].Save(WebUtility.GetUserName());
            Store.Caching.ProductCache.RemoveAssociatedAttributeCollectionFromCache(productId);
          }
          LoadAssociatedAttributes();
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(attributes).Name + ".IsRequired_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
      
    }

    /// <summary>
    /// Handles the Click event of the lbDelete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.CommandEventArgs"/> instance containing the event data.</param>
    protected void lbDelete_Click(object sender, CommandEventArgs e) {
      try {
        int attributeId = 0;
        int.TryParse(e.CommandArgument.ToString(), out attributeId);
        if(attributeId > 0) {
          Query query = new Query(ProductAttributeMap.Schema).WHERE(ProductAttributeMap.Columns.AttributeId, attributeId).AND(ProductAttributeMap.Columns.ProductId, productId);
          query.QueryType = QueryType.Delete;
          query.Execute();
          Store.Caching.ProductCache.RemoveAssociatedAttributeCollectionFromCache(productId);
          LoadAvailableAttributes();
          LoadAssociatedAttributes();
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(attributes).Name + ".lbDelete_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the ItemDataBound event of the dgAssociatedAttributes control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridItemEventArgs"/> instance containing the event data.</param>
    void dgAssociatedAttributes_ItemDataBound(object sender, DataGridItemEventArgs e) {
      if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        LinkButton deleteButton = e.Item.Cells[1].FindControl("lbDelete") as LinkButton;
        if(deleteButton != null) {
          deleteButton.Text = LocalizationUtility.GetText("lblDelete");
          deleteButton.Attributes.Add("onclick", "return confirm(\"" + LocalizationUtility.GetText("lblConfirmDelete") + "\");return false;");
        }
      }
    }

    /// <summary>
    /// Handles the ItemDataBound event of the dgAvailableAttributes control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridItemEventArgs"/> instance containing the event data.</param>
    void dgAvailableAttributes_ItemDataBound(object sender, DataGridItemEventArgs e) {
      if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        LinkButton addButton = e.Item.Cells[0].FindControl("lbAdd") as LinkButton;
        if(addButton != null) {
          addButton.Text = LocalizationUtility.GetText("lblAdd");
        }
      }
    }    
    
    #endregion
    
    #region Methods
    
    #region Private

    /// <summary>
    /// Loads the available attributes.
    /// </summary>
    private void LoadAvailableAttributes() {
      Store.AttributeCollection attributeCollection = new Store.ProductController().FetchAvailableAttributesByProductId(productId);
      dgAvailableAttributes.DataSource = attributeCollection;
      dgAvailableAttributes.ItemDataBound += new DataGridItemEventHandler(dgAvailableAttributes_ItemDataBound);
      dgAvailableAttributes.Columns[0].HeaderText = LocalizationUtility.GetText("hdrAdd");
      dgAvailableAttributes.Columns[1].HeaderText = LocalizationUtility.GetText("hdrName");
      dgAvailableAttributes.DataBind();
    }

    /// <summary>
    /// Loads the associated attributes.
    /// </summary>
    private void LoadAssociatedAttributes() {
      Store.AssociatedAttributeCollection associatedAttributeCollection = new Store.ProductController().FetchAssociatedAttributesByProductId(productId);
      dgAssociatedAttributes.DataSource = associatedAttributeCollection;
      dgAssociatedAttributes.ItemDataBound += new DataGridItemEventHandler(dgAssociatedAttributes_ItemDataBound);
      dgAssociatedAttributes.Columns[0].HeaderText = LocalizationUtility.GetText("hdrSortOrder");
      dgAssociatedAttributes.Columns[1].HeaderText = LocalizationUtility.GetText("hdrName");
      dgAssociatedAttributes.Columns[2].HeaderText = LocalizationUtility.GetText("hdrIsRequired");
      dgAssociatedAttributes.Columns[3].HeaderText = LocalizationUtility.GetText("hdrDelete");
      dgAssociatedAttributes.DataBind();
      if(associatedAttributeCollection.Count > 0) {
        ImageButton lbUp = dgAssociatedAttributes.Items[0].Cells[1].FindControl("lbUp") as ImageButton;
        if(lbUp != null) {
          lbUp.Visible = false;
        }
        ImageButton lbDown = dgAssociatedAttributes.Items[dgAssociatedAttributes.Items.Count - 1].Cells[1].FindControl("lbDown") as ImageButton;
        if(lbDown != null) {
          lbDown.Visible = false;
        }
      }
    }

    /// <summary>
    /// Loads the attributes locked.
    /// </summary>
    private void LoadAttributesLocked() {
      Store.AssociatedAttributeCollection associatedAttributeCollection = new Store.ProductController().FetchAssociatedAttributesByProductId(productId);
      dgAttributesLocked.DataSource = associatedAttributeCollection;
      dgAttributesLocked.Columns[0].HeaderText = LocalizationUtility.GetText("hdrSortOrder");
      dgAttributesLocked.Columns[1].HeaderText = LocalizationUtility.GetText("hdrName");
      dgAttributesLocked.Columns[2].HeaderText = LocalizationUtility.GetText("hdrIsRequired");
      dgAttributesLocked.DataBind();
    }

    /// <summary>
    /// Sets the attributes properties.
    /// </summary>
    private void SetAttributesProperties() {
      this.Page.Title = LocalizationUtility.GetText("titleProductEditAttributes");
    }
    
    #endregion
    
    #endregion    

  }
}
