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
using MettleSystems.dashCommerce.Store.Web.Controls;
using SubSonic;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin.controls.product {
  public partial class crosssells : AdminControl {
  
    #region Member Variables

    private int productId = 0;
    private string view = string.Empty;
    CrossSellCollection crossSellCollection;
    
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
        if(view == "cs") {
          SetCrossSellProperties();
          if(!Page.IsPostBack) {
            LoadProducts();
          }
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(crosssells).Name + ".Page_Load", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Clicked event of the crossSell control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void crossSell_Clicked(object sender, EventArgs e) {
      try {
        CheckBox checkbox = sender as CheckBox;
        if(checkbox != null) {
          DataGridItem row = checkbox.NamingContainer as DataGridItem;
          int crossProductId = 0;
          if(row != null) {
            int.TryParse(dgCrossSells.DataKeys[row.ItemIndex].ToString(), out crossProductId);
          }
          if(checkbox.Checked) {
            CrossSell crossSell = new CrossSell();
            crossSell.ProductId = productId;
            crossSell.CrossProductId = crossProductId;
            crossSell.Save();
            Store.Caching.ProductCache.RemoveCrossSellCollectionFromCache(productId);
            LoadProducts();
            base.MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblCrossSellSaved"));
          }
          else {
            Query query = new Query(CrossSell.Schema).WHERE(CrossSell.Columns.ProductId, productId).AND(CrossSell.Columns.CrossProductId, crossProductId);
            query.QueryType = QueryType.Delete;
            query.Execute();
            Store.Caching.ProductCache.RemoveCrossSellCollectionFromCache(productId);
            LoadProducts();
            base.MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblCrossSellDeleted"));
          }
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(crosssells).Name + ".crossSell_Clicked", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the ItemDataBound event of the dgCrossSells control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridItemEventArgs"/> instance containing the event data.</param>
    void dgCrossSells_ItemDataBound(object sender, DataGridItemEventArgs e) {
      if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        foreach(CrossSell crossSell in crossSellCollection) {
          if(crossSell.CrossProductId.ToString() == dgCrossSells.DataKeys[e.Item.ItemIndex].ToString()) {
            CheckBox checkBox = e.Item.Cells[0].FindControl("chkCrossSell") as CheckBox;
            if(checkBox != null) {
              checkBox.Checked = true;
            }
          }
        }
      }
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the dgCrossSells control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridPageChangedEventArgs"/> instance containing the event data.</param>
    protected void dgCrossSells_PageIndexChanging(object sender, DataGridPageChangedEventArgs e) {
      LoadProducts();
      dgCrossSells.CurrentPageIndex = e.NewPageIndex;
      dgCrossSells.DataBind();
    }

    #endregion

    #region Methods
    
    #region Private

    /// <summary>
    /// Sets the cross sell properties.
    /// </summary>
    private void SetCrossSellProperties() {
      this.Page.Title = LocalizationUtility.GetText("titleProductEditCrossSells");    
    }

    /// <summary>
    /// Loads the products.
    /// </summary>
    private void LoadProducts() {
      crossSellCollection = new CrossSellController().FetchByID(productId);
      Query query = new Query(Product.Schema).WHERE(Product.Columns.ProductId, Comparison.NotEquals, productId);
      ProductCollection productCollection = new ProductController().FetchByQuery(query);
      if(productCollection.Count > 0) {
        dgCrossSells.DataSource = productCollection;
        dgCrossSells.ItemDataBound += new DataGridItemEventHandler(dgCrossSells_ItemDataBound);
        dgCrossSells.Columns[0].HeaderText = LocalizationUtility.GetText("hdrAddRemove");
        dgCrossSells.Columns[1].HeaderText = LocalizationUtility.GetText("hdrName");
        dgCrossSells.DataBind();
      }
    }
    
    #endregion
    
    #endregion
    
  }
}
