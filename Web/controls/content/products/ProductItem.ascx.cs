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