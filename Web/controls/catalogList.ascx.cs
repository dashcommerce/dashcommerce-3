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
using System.Web.UI.WebControls;

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Services.TaxService;
//using MettleSystems.dashCommerce.Store.Services.CurrencyService;

namespace MettleSystems.dashCommerce.Web.controls {
  public partial class catalogList : System.Web.UI.UserControl {
  
    #region Member Variables

    private PagedDataSource _pagedDataSource;
    private ProductCollection _productCollection;

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        if (this.PagedDataSource != null) {
          dlCatalog.DataSource = this.PagedDataSource;
        }
        else {
          if (this.ProductCollection != null) {
            dlCatalog.DataSource = this.ProductCollection;
          }
        }
        dlCatalog.ItemDataBound += new DataListItemEventHandler(dlCatalog_ItemDataBound);
        dlCatalog.DataBind();
        
      }
      catch (Exception ex) {
        Logger.Error(typeof(catalogList).Name + ".Page_Load", ex);
      }
    }

    #endregion
    
    #region Methods
    
    #region Protected

    /// <summary>
    /// Gets the navigate URL.
    /// </summary>
    /// <param name="productId">The product id.</param>
    /// <param name="productName">Name of the product.</param>
    /// <returns></returns>
    protected string GetNavigateUrl(string productId, string productName) {
        return RewriteService.BuildProductUrl(productId, productName);
    }
    
    #endregion
    
    #region Private

    /// <summary>
    /// Handles the ItemDataBound event of the dlCatalog control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataListItemEventArgs"/> instance containing the event data.</param>
    void dlCatalog_ItemDataBound (object sender, DataListItemEventArgs e) {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        Product product = e.Item.DataItem as Product;
        if (product == null)
          return;
        HyperLink imageLink = e.Item.FindControl("hlImageLink") as HyperLink;
        site masterPage = this.Page.Master as site;
        if (imageLink != null && !string.IsNullOrEmpty(product.DefaultImagePath)) {
          imageLink.ImageUrl = ImageProcess.GetProductThumbnailUrl(product.DefaultImagePath);
        }

        Label retailPrice = e.Item.FindControl("lblRetailPrice") as Label;
        if (masterPage != null) {
          if (masterPage.SiteSettings.DisplayRetailPrice && product.RetailPrice != 0) {
            if (retailPrice != null) {
              retailPrice.Text = StoreUtility.GetFormattedAmount(product.RetailPrice, true);
            }
          }
          else {
            retailPrice.Visible = false;
          }
        }
        Label ourPrice = e.Item.FindControl("lblOurPrice") as Label;
        if (ourPrice != null) {
          ourPrice.Text = StoreUtility.GetFormattedAmount(product.DisplayPrice, true);
        }
        if(masterPage.SiteSettings.AddTaxToPrice && TaxService.GetDefaultTaxProvider().IsProductLevelTaxProvider) {
          Label taxApplied = e.Item.FindControl("lblTaxApplied") as Label;
          if(taxApplied != null) {
            taxApplied.Visible = true;
          }
        }
        AjaxControlToolkit.Rating ajaxRating = e.Item.FindControl("ajaxRating") as AjaxControlToolkit.Rating;
        if (ajaxRating != null && masterPage.SiteSettings.DisplayRatings) {
          ajaxRating.GroupingText = LocalizationUtility.GetText("lblAverageRating");
          ajaxRating.CurrentRating = product.Rating;
        }
        else {
          ajaxRating.Visible = false;
        }
      }
    }
    
    #endregion
    
    #endregion
    
    #region Properties

    /// <summary>
    /// Gets or sets the paged data source.
    /// </summary>
    /// <value>The paged data source.</value>
    public PagedDataSource PagedDataSource {
      get {
        return _pagedDataSource;
      }
      set {
        _pagedDataSource = value;
      }
    }

    /// <summary>
    /// Gets or sets the product collection.
    /// </summary>
    /// <value>The product collection.</value>
    public ProductCollection ProductCollection {
      get {
        return _productCollection;
      }
      set {
        _productCollection = value;
      }
    }    
    
    #endregion

  }
}
