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
using System.Text;

using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store.Web.Controls;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.controls {
  public partial class ServerSidePaging : dashCommerceUserControl {

    #region Constants

    private const string PAGING_BUTTON_TEMPLATE = "<a href=\"{0}\" class=\"pageLink\">{1}</a>&nbsp;&nbsp;";

    #endregion

    #region Member Variables

    private int itemCount = 0;
    private int pageIndex = 0;
    private int pageSize = 0;

    private int categoryId = 0;
    private string searchTerms = string.Empty;
    private string currentQueryString = string.Empty;
    private string pagingTitle; //for URL Rewrite

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      categoryId = Utility.GetIntParameter("cid");
      searchTerms = Utility.GetParameter("searchTerms");
      currentQueryString = GetCurrentQueryStringWithoutCatalogId();
      int startNumber = 0;
      int endNumber = 0;
      bool isSearchPage = !string.IsNullOrEmpty(searchTerms);

      startNumber = ItemCount == 0 ? 0 : ((PageIndex * PageSize) + 1);
      endNumber = ((PageIndex + 1) * PageSize);
      if (endNumber > ItemCount) {
        endNumber = ItemCount;
      }
      lblShowingTotals.Text = string.Format(LocalizationUtility.GetText("lblShowingTotals"), startNumber, endNumber, ItemCount);
      pageLinks.InnerHtml = "";
      for (int i = 0; i < ItemCount; i++) {
        if (PageIndex == i) {
          pageLinks.InnerHtml += (i + 1) + "&nbsp;&nbsp;";
        }
        else {
          pageLinks.InnerHtml += string.Format(PAGING_BUTTON_TEMPLATE, isSearchPage ? ResolveUrl(GetSearchPagedUrl(searchTerms, i)) : ResolveUrl(GetCatalogPagedUrl(categoryId, i)), i + 1);
        }
      }
      hlPrevious.Visible = PageIndex != 0;
      if (hlPrevious.Visible) {
        hlPrevious.NavigateUrl = isSearchPage ? GetSearchPagedUrl(searchTerms, (PageIndex - 1)) : GetCatalogPagedUrl(categoryId, (PageIndex - 1));
      }
      hlNext.Visible = PageIndex != endNumber;
      if (hlNext.Visible) {
        hlNext.NavigateUrl = isSearchPage ? GetSearchPagedUrl(searchTerms, (PageIndex + 1)) : GetCatalogPagedUrl(categoryId, (PageIndex + 1));
      }
    }

    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Gets the search paged URL.
    /// </summary>
    /// <param name="searchText">The search text.</param>
    /// <param name="pageNumber">The page number.</param>
    /// <returns></returns>
    private string GetSearchPagedUrl(string searchText, int pageNumber) {
      return string.Format("~/search.aspx?searchTerms={0}&p={1}", searchText, pageNumber);
    }

    /// <summary>
    /// Gets the catalog paged URL.
    /// </summary>
    /// <param name="catagoryId">The catagory id.</param>
    /// <param name="pageNumber">The page number.</param>
    /// <returns></returns>
    private string GetCatalogPagedUrl(int catagoryId, int pageNumber) {
      string finalQueryString;
      if (pageNumber == 0)
        finalQueryString = currentQueryString;
      else {
        finalQueryString = string.Concat(currentQueryString, (currentQueryString.Length > 0) ? "&" : "", "p=", pageNumber.ToString());
      }
      return RewriteService.BuildCatalogUrl(catagoryId.ToString(), PagingTitle, finalQueryString);
    }

    /// <summary>
    /// Gets the current query string without catalog id.
    /// </summary>
    /// <returns></returns>
    private string GetCurrentQueryStringWithoutCatalogId() {
      StringBuilder queryString = new StringBuilder();
      string currentKey = "";
      for (int i = 0; i < Request.QueryString.Count; i++) {
        currentKey = Request.QueryString.GetKey(i);
        if (currentKey == "cid" || currentKey == "p")
          continue;
        queryString.Append(string.Format("{0}={1}", Request.QueryString.GetKey(i), Request.QueryString.Get(i)));
        queryString.Append("&");
      }
      string retQS = queryString.ToString();
      return retQS.EndsWith("&") ? retQS.Remove(retQS.Length - 1) : retQS;
    }

    #endregion

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the item count.
    /// </summary>
    /// <value>The item count.</value>
    public int ItemCount {
      get { return itemCount; }
      set { itemCount = value; }
    }

    /// <summary>
    /// Gets or sets the size of the page.
    /// </summary>
    /// <value>The size of the page.</value>
    public int PageSize {
      get { return pageSize; }
      set { pageSize = value; }
    }

    /// <summary>
    /// Gets or sets the index of the page.
    /// </summary>
    /// <value>The index of the page.</value>
    public int PageIndex {
      get { return pageIndex; }
      set { pageIndex = value; }
    }

    /// <summary>
    /// Gets or sets the paging title.
    /// This is used for the URL Rewrite feature.
    /// </summary>
    /// <value>The paging title.</value>
    public string PagingTitle {
      get {
        if (string.IsNullOrEmpty(pagingTitle))
          return "-";
        return pagingTitle;
      }
      set { pagingTitle = value; }
    }

    #endregion

  }
}
