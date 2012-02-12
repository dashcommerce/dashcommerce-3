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
using System.Text;
using System.Web.UI.WebControls;

using MettleSystems.dashCommerce.Localization;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.controls {
  public partial class paging : System.Web.UI.UserControl
  {

    #region Constants

    private const string PAGING_BUTTON_TEMPLATE = "<a href=\"{0}\" class=\"pageLink\">{1}</a>&nbsp;&nbsp;";

    #endregion

    #region Member Variables

    private PagedDataSource _pagedDataSource;
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

      startNumber = PagedDataSource.DataSourceCount == 0 ? 0 : ((PagedDataSource.CurrentPageIndex * PagedDataSource.PageSize) + 1);
      endNumber = ((PagedDataSource.CurrentPageIndex + 1) * PagedDataSource.PageSize);
      if (endNumber > PagedDataSource.DataSourceCount) {
        endNumber = PagedDataSource.DataSourceCount;
      }
      lblShowingTotals.Text = string.Format(LocalizationUtility.GetText("lblShowingTotals"), startNumber, endNumber, PagedDataSource.DataSourceCount);
      pageLinks.InnerHtml = "";
      for (int i = 0; i < PagedDataSource.PageCount; i++) {
        if (PagedDataSource.CurrentPageIndex == i) {
          pageLinks.InnerHtml += (i + 1) + "&nbsp;&nbsp;";
        }
        else {
          pageLinks.InnerHtml += string.Format(PAGING_BUTTON_TEMPLATE, isSearchPage ? ResolveUrl(GetSearchPagedUrl(searchTerms, i)) : ResolveUrl(GetCatalogPagedUrl(categoryId, i)), i + 1);
        }
      }
      hlPrevious.Visible = !PagedDataSource.IsFirstPage;
      if (hlPrevious.Visible) {
        hlPrevious.NavigateUrl = isSearchPage ? GetSearchPagedUrl(searchTerms, (PagedDataSource.CurrentPageIndex - 1)) : GetCatalogPagedUrl(categoryId, (PagedDataSource.CurrentPageIndex - 1));
      }
      hlNext.Visible = !PagedDataSource.IsLastPage;
      if (hlNext.Visible) {
        hlNext.NavigateUrl = isSearchPage ? GetSearchPagedUrl(searchTerms, (PagedDataSource.CurrentPageIndex + 1)) : GetCatalogPagedUrl(categoryId, (PagedDataSource.CurrentPageIndex + 1));
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
        for (int i = 0; i < Request.QueryString.Count; i++)
        {
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
