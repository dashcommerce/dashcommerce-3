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
