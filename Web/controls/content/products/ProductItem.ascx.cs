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
using System.IO;
using System.Web.UI.WebControls;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Web;
using MettleSystems.dashCommerce.Store.Web.Controls;

namespace MettleSystems.dashCommerce.Web.controls.content.products {
  public partial class ProductItem : dashCommerceUserControl {
    protected void Page_Load(object sender, EventArgs e) {
      LoadItem();
    }

    #region Member Variables

    private Product currentProduct;

    #endregion

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
    /// Loads the item.
    /// </summary>
    void LoadItem() {
      if (CurrentProduct == null)
        return;
      HyperLink imageLink = hlImageLink;
      dashCommerceMasterPage masterPage = DashCommerceMasterPage;
      if (imageLink != null) {
        if (!string.IsNullOrEmpty(CurrentProduct.DefaultImagePath)) {
          bool defaultImageExists = File.Exists(Server.MapPath(CurrentProduct.DefaultImagePath));
          if (masterPage.SiteSettings.GenerateThumbs) {
            string thumbnail = CurrentProduct.DefaultImagePath.Replace("product/", string.Format("product/thumbs/{0}x{1}_", masterPage.SiteSettings.ThumbSmallWidth, masterPage.SiteSettings.ThumbSmallHeight));
            if (!File.Exists(Server.MapPath(thumbnail))) {
              if (defaultImageExists) {
                //Thumbnails don't exist so lets generate them...
                string fileName = CurrentProduct.DefaultImagePath.Substring(CurrentProduct.DefaultImagePath.LastIndexOf("/") + 1);
                using (FileStream fs = File.Open(Server.MapPath(CurrentProduct.DefaultImagePath), FileMode.Open, FileAccess.Read, FileShare.None)) {
                  ImageProcess.ResizeAndSave(fs, fileName, Server.MapPath(@"~/repository/product/thumbs/"), masterPage.SiteSettings.ThumbSmallWidth, masterPage.SiteSettings.ThumbSmallHeight);
                }
              }
            }
            imageLink.ImageUrl = thumbnail;
          }
          else if (defaultImageExists) {
            imageLink.ImageUrl = CurrentProduct.DefaultImagePath;
          }
        }
      }

      if (masterPage != null) {
        if (masterPage.SiteSettings.DisplayRetailPrice) {
          if (lblRetailPrice != null) {
            lblRetailPrice.Text = StoreUtility.GetFormattedAmount(CurrentProduct.RetailPrice, true);
          }
        }
        else {
          lblRetailPrice.Visible = false;
        }
      }
      if (lblOurPrice != null) {
        lblOurPrice.Text = StoreUtility.GetFormattedAmount(CurrentProduct.OurPrice, true);
      }
      if (ajaxRating != null && masterPage.SiteSettings.DisplayRatings) {
        ajaxRating.GroupingText = LocalizationUtility.GetText("lblAverageRating");
        ajaxRating.CurrentRating = CurrentProduct.Rating;
      }
      else {
        ajaxRating.Visible = false;
      }
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the current product.
    /// </summary>
    /// <value>The current product.</value>
    public Product CurrentProduct {
      get {
        return currentProduct;
      }
      set {
        currentProduct = value;
      }
    }

    #endregion
  }
}