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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MettleSystems.dashCommerce.Store;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web {
  public partial class search : MettleSystems.dashCommerce.Store.Web.SitePage {

    #region Member Variables

    private PagedDataSource pagedDataSource = new PagedDataSource();
    private string searchTerms = string.Empty;

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e) {
      searchTerms = HttpUtility.UrlDecode(Utility.GetParameter("searchTerms"));
      string p = Utility.GetParameter("p");

      if (!string.IsNullOrEmpty(searchTerms)) {
        if (string.IsNullOrEmpty(p)) {
          if (Master.SiteSettings.CollectSearchTerms) {
            BrowsingLogController.LogBrowsingInfo(searchTerms, BrowsingBehaviour.Search, Request.Url.ToString().PadRight(255).Substring(0, 254).Trim(), WebUtility.SessionId(), WebUtility.GetUserName());
          }
        }
        LoadProducts();
      }
      Page.Title = string.Format(WebUtility.MainTitleTemplate, Master.SiteSettings.SiteName, searchTerms);
    }

    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Loads the products.
    /// </summary>
    private void LoadProducts() {
      pagedDataSource.AllowPaging = true;
      pagedDataSource.PageSize = Master.SiteSettings.CatalogItems;
      int currentPageIndex = 0;
      int.TryParse(Utility.GetParameter("p"), out currentPageIndex);
      pagedDataSource.CurrentPageIndex = currentPageIndex;

      pagedDataSource.DataSource = new ProductController().SearchProducts(searchTerms);

      topPager.PagedDataSource = pagedDataSource;
      bottomPager.PagedDataSource = pagedDataSource;
      catalogList.PagedDataSource = pagedDataSource;
    }

    #endregion

    #endregion

  }
}
