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
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Web.controls.catalog;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web {
  public partial class catalog : MettleSystems.dashCommerce.Store.Web.SitePage {

    #region Member Variables

    private int categoryId = 0;
    private int manufacturerId = 0;
    private decimal priceStart = 0;
    private decimal priceEnd = 0;
    private PagedDataSource pagedDataSource = new PagedDataSource();
    DataSet breadCrumbs;
    private Category category;

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      categoryId = Utility.GetIntParameter("cid");
      manufacturerId = Utility.GetIntParameter("mid");
      decimal.TryParse(Utility.GetParameter("ps"), out priceStart);
      decimal.TryParse(Utility.GetParameter("pe"), out priceEnd);

      LogStatistics();
      LoadCategoryInfo();
      LoadBreadCrumbs();
      LoadPageTitle();
      LoadProducts();
      LoadWidgets();
      SetSeoInformation();
    }

    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Loads the catalog widgets.
    /// </summary>
    private void LoadWidgets() {
      if (Master.SiteSettings.DisplayNarrowCategory) {
        narrowcategory narrowCategoryWidget = (narrowcategory)Page.LoadControl("controls/catalog/narrowcategory.ascx");
        narrowCategoryWidget.Category = category;
        phRightSideWidgets.Controls.Add(narrowCategoryWidget);
      }

      if (Master.SiteSettings.DisplaySortBy) {
        sorting sortingWidget = (sorting)Page.LoadControl("controls/catalog/sorting.ascx");
        sortingWidget.Category = category;
        sortingWidget.ProductCollection = pagedDataSource.DataSource as ProductCollection;
        phRightSideWidgets.Controls.Add(sortingWidget);
      }

      if (Master.SiteSettings.DisplayNarrowByManufacturer) {
        narrowmanufacturer narrowManufacturerWidget = (narrowmanufacturer)Page.LoadControl("controls/catalog/narrowmanufacturer.ascx");
        narrowManufacturerWidget.Category = category;
        phRightSideWidgets.Controls.Add(narrowManufacturerWidget);
      }

      if (Master.SiteSettings.DisplayNarrowByPrice) {
        narrowprice narrowPriceWidget = (narrowprice)Page.LoadControl("controls/catalog/narrowprice.ascx");
        narrowPriceWidget.Category = category;
        phRightSideWidgets.Controls.Add(narrowPriceWidget);
      }
    }

    /// <summary>
    /// Sets the seo information.
    /// </summary>
    private void SetSeoInformation() {
      string name = category.Name;
      AddKeyWord(name);
      base.SetPageDescription(name);
    }

    /// <summary>
    /// Logs the statistics.
    /// </summary>
    private void LogStatistics() {
      if (Master.SiteSettings.CollectBrowsingCategory) {
        BrowsingLogController.LogBrowsingInfo(categoryId, BrowsingBehaviour.Browsing_Category, Request.Url.ToString().PadRight(255).Substring(0, 254).Trim(), WebUtility.SessionId(), WebUtility.GetUserName());
      }
    }

    /// <summary>
    /// Loads the category info.
    /// </summary>
    private void LoadCategoryInfo() {
      category = Store.Caching.CategoryCache.GetCategoryInfo(categoryId);
      if (!string.IsNullOrEmpty(category.ImageFile)) {
        if (File.Exists(Server.MapPath(category.ImageFile))) {
          hlCategory.ImageUrl = category.ImageFile;
          hlCategory.NavigateUrl = Request.Url.ToString();
        }
      }
    }

    /// <summary>
    /// Loads the page title.
    /// </summary>
    private void LoadPageTitle() {
      string pageTitle = string.Empty;
      foreach (DataRow dr in breadCrumbs.Tables[0].Rows) {
        if (string.IsNullOrEmpty(pageTitle.Trim()))
          pageTitle = dr["Name"].ToString();
        else
          pageTitle += string.Format(" :: {0}", dr["Name"]);
      }
      if (manufacturerId > 0) {
        Manufacturer manufacturer = new Manufacturer(manufacturerId);
        pageTitle += string.Format(" :: {0}", manufacturer.Name);
      }
      if (priceStart >= 0 && priceEnd > 0) {
        pageTitle += string.Format(" :: {0} - {1}", StoreUtility.GetFormattedAmount(priceStart, true), StoreUtility.GetFormattedAmount(priceEnd, true));
      }
      Page.Title = string.Format(WebUtility.MainTitleTemplate, Master.SiteSettings.SiteName, pageTitle);
    }

    /// <summary>
    /// Loads the bread crumbs.
    /// </summary>
    private void LoadBreadCrumbs() {
      breadCrumbs = Store.Caching.CategoryCache.FetchCategoryBreadCrumbs(categoryId);
      xmlDataSource.EnableCaching = false;
      RewriteService.AddRewriteNameSpaceForXslt(xmlDataSource);
      xmlDataSource.Data = breadCrumbs.GetXml();
    }

    /// <summary>
    /// Loads the products.
    /// </summary>
    private void LoadProducts() {
      pagedDataSource.AllowPaging = true;
      pagedDataSource.PageSize = Master.SiteSettings.CatalogItems;
      int currentPageIndex = 0;
      int.TryParse(Utility.GetParameter("p"), out currentPageIndex);
      pagedDataSource.CurrentPageIndex = currentPageIndex;

      if (manufacturerId > 0) {
        pagedDataSource.DataSource = Store.Caching.ProductCache.GetProductsByCategoryIdManufacture(categoryId, manufacturerId);
      }
      else if (priceStart >= 0 && priceEnd > 0) {
        pagedDataSource.DataSource = Store.Caching.ProductCache.GetProductsByCategoryIdPriceRange(categoryId, priceStart, priceEnd);
      }
      else {
        pagedDataSource.DataSource = Store.Caching.ProductCache.GetProductsByCategoryId(categoryId);
      }

      topPager.PagingTitle = category.Name;
      bottomPager.PagingTitle = category.Name;
      topPager.PagedDataSource = pagedDataSource;
      bottomPager.PagedDataSource = pagedDataSource;
      catalogList.PagedDataSource = pagedDataSource;
    }

    #endregion

    #endregion

  }
}
