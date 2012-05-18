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
