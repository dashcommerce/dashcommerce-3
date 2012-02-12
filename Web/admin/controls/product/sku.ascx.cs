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
