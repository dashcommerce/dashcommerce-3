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
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Web.Controls;

namespace MettleSystems.dashCommerce.Web.controls.navigation {
  public partial class favoriteproducts : SiteControl {

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        LoadFavoriteProducts();
      }
      catch (Exception ex) {
        Logger.Error(typeof(favoriteproducts).Name + "Page_Load", ex);
      }
    }

    #endregion

    #region Methods

    #region Protected

    /// <summary>
    /// Gets the product URL.
    /// </summary>
    /// <param name="productId">The product id.</param>
    /// <param name="productName">Name of the product.</param>
    /// <returns></returns>
    protected string GetProductUrl(string productId, string productName) {
      return RewriteService.BuildProductUrl(productId, productName);
    }

    #endregion

    #region Private

    /// <summary>
    /// Loads the favorite products.
    /// </summary>
    private void LoadFavoriteProducts() {
      if (base.MasterPage.SiteSettings.CollectBrowsingProduct) {
        DataSet ds = new ProductController().FetchFavoriteProducts(WebUtility.GetUserName());
        if (ds.Tables[0].Rows.Count > 0) {
          rptrFavoriteProducts.DataSource = ds;
          rptrFavoriteProducts.DataBind();
        }
      }
    }

    #endregion

    #endregion

  }
}
