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
