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
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Web.Controls;
using SubSonic;
using SubSonic.Utilities;


namespace MettleSystems.dashCommerce.Web.admin.controls.product {
  public partial class sku : AdminControl {

    #region Member Variables

    private int productId = 0;
    private string view = string.Empty;
    private Product product;
    private AssociatedAttributeCollection associatedAttributeCollection;
    private List<string> skus = new List<string>();
    
    #endregion
    
    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load (object sender, EventArgs e) {
      try {
        productId = Utility.GetIntParameter("productId");
        view = Utility.GetParameter("view");
        if (view.Equals("s")) {
          SetSkuProperties();
          product = new Product(productId);
          associatedAttributeCollection = new ProductController().FetchAssociatedAttributesByProductId(productId);
          if(!Page.IsPostBack) {
            chkAllowNegativeInventories.Checked = product.AllowNegativeInventories;
            SkuCollection skuCollection = LoadSkuCollection(productId);
            if (skuCollection.Count > 0) {
              pnlSkuList.Visible = false;
            }
            else {
              pnlSkuInventory.Visible = false;
              string tempSku = product.BaseSku;
              if (associatedAttributeCollection.Count > 0) {
                CreateSkus(associatedAttributeCollection[0], 0, tempSku);
                lblTotalSkuCount.Text = skus.Count.ToString();
              }
              else {
                skus.Add(tempSku);
                lblTotalSkuCount.Text = skus.Count.ToString();
              }
              skus.TrimExcess();
              dlSkus.DataSource = skus;
              dlSkus.DataBind();
            }
          }
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(sku).Name + ".Page_Load", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }
    
    /// <summary>
    /// Handles the Click event of the btnSaveInventory control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnSaveInventory_Click (object sender, EventArgs e) {
      try {
        int inventory = 0;
        TextBox textBox;
        int skuId = 0;
        foreach (DataGridItem item in dgSkuInventory.Items) {
          textBox = item.FindControl("txtInventory") as TextBox;
          int.TryParse(textBox.Text, out inventory);
          int.TryParse(dgSkuInventory.DataKeys[item.ItemIndex].ToString(), out skuId);
          if (skuId > 0) {
            Sku sku = new Sku(skuId);
            sku.Inventory = inventory;
            sku.Save(WebUtility.GetUserName());
            skuId = 0;
          }
        }
        product.AllowNegativeInventories = chkAllowNegativeInventories.Checked;
        product.Save(WebUtility.GetUserName());
        Store.Caching.ProductCache.RemoveProductFromCache(productId);
        base.MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblInventoriesSaved"));
      }
      catch(Exception ex) {
        Logger.Error(typeof(sku).Name + ".btnSaveInventory_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click (object sender, EventArgs e) {
      try {
        SkuCollection skuCollection = new SkuCollection();
        Sku sku;
        if (associatedAttributeCollection != null && associatedAttributeCollection.Count > 0)
            CreateSkus(associatedAttributeCollection[0], 0, product.BaseSku);
        else
            skus.Add(product.BaseSku);
        for(int i = 0;i < skus.Count;i++) {
          sku = new Sku();
          sku.ProductId = productId;
          sku.SkuX = skus[i];
          skuCollection.Add(sku);
        }
        skuCollection.SaveAll(WebUtility.GetUserName());
        product.IsEnabled = true;
        product.Save(WebUtility.GetUserName());
        Store.Caching.ProductCache.RemoveProductFromCache(productId);
        SkuCollection savedSkuCollection = LoadSkuCollection(productId);
        if(savedSkuCollection.Count > 0) {
          pnlSkuList.Visible = false;
          pnlSkuInventory.Visible = true;
        }
        base.MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblAttributesSaved"));
      }
      catch (Exception ex) {
        Logger.Error(typeof(sku).Name + ".btnSave_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }
    
    #endregion
    
    #region Methods
    
    #region Private

    /// <summary>
    /// Sets the sku properties.
    /// </summary>
    private void SetSkuProperties () {
      this.Page.Title = LocalizationUtility.GetText("titleProductEditSku");
    }

    /// <summary>
    /// Creates the skus.
    /// </summary>
    /// <param name="associatedAttribute">The associated attribute.</param>
    /// <param name="level">The level.</param>
    /// <param name="tempSku">The temp sku.</param>
    private void CreateSkus (AssociatedAttribute associatedAttribute, int level, string tempSku) {
      int oldLevel = level;
      string oldSku = tempSku;
      for (int i = 0;i < associatedAttribute.AttributeItemCollection.Count;i++) {
        tempSku += "-" + associatedAttribute.AttributeItemCollection[i].SkuSuffix;
        level += 1;
        if (level < associatedAttributeCollection.Count) {
          CreateSkus(associatedAttributeCollection[level], level, tempSku);
        }
        if (level == associatedAttributeCollection.Count) {
          skus.Add(tempSku);
        }
        tempSku = oldSku;
        level = oldLevel;
      }
    }

    /// <summary>
    /// Loads the sku collection.
    /// </summary>
    /// <param name="productId">The product id.</param>
    /// <returns></returns>
    private SkuCollection LoadSkuCollection(int productId) {
      SkuCollection skuCollection = new SkuCollection().Where(Sku.Columns.ProductId, Comparison.Equals, productId).Load();
      dgSkuInventory.DataSource = skuCollection;
      dgSkuInventory.Columns[0].HeaderText = LocalizationUtility.GetText("hdrSku");
      dgSkuInventory.Columns[1].HeaderText = LocalizationUtility.GetText("hdrInventory");
      dgSkuInventory.DataBind();
      return skuCollection;
    }
    
    #endregion
    
    #endregion

  }
}
