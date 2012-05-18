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
  public partial class favoritecategories : SiteControl {

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        LoadFavoriteCategories();
      }
      catch (Exception ex) {
        Logger.Error(typeof(favoritecategories).Name + "Page_Load", ex);
      }
    }

    #endregion

    #region Methods

    #region Protected

    /// <summary>
    /// Gets the catalog URL.
    /// </summary>
    /// <param name="categoryId">The category id.</param>
    /// <param name="categoryName">Name of the category.</param>
    /// <returns></returns>
    protected string GetCatalogUrl(string categoryId, string categoryName) {
      return RewriteService.BuildCatalogUrl(categoryId, categoryName);
    }

    #endregion

    #region Private

    /// <summary>
    /// Loads the favorite categories.
    /// </summary>
    private void LoadFavoriteCategories() {
      if (base.MasterPage.SiteSettings.CollectBrowsingCategory) {
        DataSet ds = new CategoryController().FetchFavoriteCategories(WebUtility.GetUserName());
        if (ds.Tables[0].Rows.Count > 0) {
          rptrFavoriteCategories.DataSource = ds;
          rptrFavoriteCategories.DataBind();
        }
      }
    }

    #endregion

    #endregion

  }
}
