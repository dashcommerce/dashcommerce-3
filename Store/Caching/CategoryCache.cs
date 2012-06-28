#region dashCommerce License
/*
dashCommerce� is Copyright � 2008-2012 Mettle Systems LLC. All Rights Reserved.


dashCommerce, and the dashCommerce logo are registered trademarks of Mettle Systems LLC. Mettle Systems LLC logos and trademarks may not be used without prior written consent.

dashCommerce is licensed under the following license. If you do not accept the terms, please discontinue the use of dashCommerce and uninstall dashCommerce. 

Your license to the dashCommerce source and/or binaries is governed by the Reciprocal Public License 1.5 (RPL1.5) license as described here: 

http://www.opensource.org/licenses/rpl1.5.txt 

If you do not wish to release the source of software you build using dashCommerce, you may purchase a site license, which will allow you to deploy dashCommerce for use in 1 web store defined as using 1 URL. You may purchase a site license here: 

http://www.dashcommerce.org/license.html 
*/
#endregion

using System.Data;
using System.Web.Caching;
using MettleSystems.dashCommerce.Core.Caching.Manager;

namespace MettleSystems.dashCommerce.Store.Caching {
  public class CategoryCache {

    #region Constants

    private const string CACHE_CATEGORY = "CategoryController_CategoryMenu";
    private const string CACHE_CATEGORY_BYID = "CategoryController_ById_{0}";
    private const string CACHE_CATEGORY_CRUMBS = "CategoryController_Crumbs_{0}";
    private const string CACHE_CATEGORY_PRODUCT_CRUMBS = "CategoryController_ProductCrumbs_{0}";
    private const string CACHE_CATEGORYCOLLECTION = "CategoryCollection";

    #endregion

    #region Methods

    #region Refresh Cache

    /// <summary>
    /// Refreshes the menu page collection in the cache.
    /// This will make that the menu should reinsert itself on the next page request
    /// </summary>
    public static void RefreshCategoryMenuCollection() {
      CacheService.RemoveCacheObject<string>(CACHE_CATEGORY);
    }

    /// <summary>
    /// Removes the Category Info from the cache.
    /// This will make that the Category should reinsert itself on the next page request
    /// </summary>
    /// <param name="categoryID">The categoryID.</param>
    public static void RemoveCategoryInfoFromCache(int categoryID) {
      CacheService.RemoveCacheObject<Category>(string.Format(CACHE_CATEGORY_BYID, categoryID));
    }

    /// <summary>
    /// Refreshes the category breadcrumbs from the cache
    /// </summary>
    public static void RefreshCategoryBreadCrumbs(int categoryId) {
      CacheService.RemoveCacheObject<DataSet>(string.Format(CACHE_CATEGORY_CRUMBS, categoryId));         
    }

    /// <summary>
    /// Refreshes the associated product categories from the cache
    /// </summary>
    public static void RefreshProductAssociatedCategories(int productId) {
      CacheService.RemoveCacheObject<CategoryCollection>(string.Format(CACHE_CATEGORY_PRODUCT_CRUMBS, productId));
    }

    /// <summary>
    /// Refreshes the associated product categories from the cache
    /// </summary>
    public static void RefreshAllCategories() {
      CacheService.RemoveCacheObject<CategoryCollection>(CACHE_CATEGORYCOLLECTION);
    }

    #endregion

    #region Public

    /// <summary>
    /// Gets the page menu.
    /// </summary>
    /// <returns></returns>
    public static string GetCategoryMenu() {
      return CacheService.CacheObject<string>(delegate { return new CategoryController().FetchCategoryList().GetXml(); },
          CACHE_CATEGORY, CacheLength.GetLongCacheTime, CacheItemPriority.High);
    }

    /// <summary>
    /// Gets the category info.
    /// </summary>
    /// <param name="categoryID">The category ID.</param>
    /// <returns></returns>
    public static Category GetCategoryInfo(int categoryID) {
      return CacheService.CacheObject<Category>(delegate { return new Category(categoryID); },
          string.Format(CACHE_CATEGORY_BYID, categoryID), CacheLength.GetDefaultCacheTime, CacheItemPriority.BelowNormal);
    }

    /// <summary>
    /// Gets the category bedcrumbs.
    /// </summary>
    /// <param name="categoryID">The category ID.</param>
    /// <returns></returns>
    public static DataSet FetchCategoryBreadCrumbs(int categoryID) {
      return CacheService.CacheObject<DataSet>(delegate { return new CategoryController().FetchCategoryBreadCrumbs(categoryID); },
          string.Format(CACHE_CATEGORY_CRUMBS, categoryID), CacheLength.GetDefaultCacheTime, CacheItemPriority.Normal);
    }

    /// <summary>
    /// Gets the categories for that product id.
    /// </summary>
    /// <param name="productID">The product ID.</param>
    /// <returns></returns>
    public static CategoryCollection FetchAssociatedCategoriesByProductId(int productID) {
      return CacheService.CacheObject<CategoryCollection>(delegate { return new ProductController().FetchAssociatedCategoriesByProductId(productID); },
          string.Format(CACHE_CATEGORY_PRODUCT_CRUMBS, productID), CacheLength.GetDefaultCacheTime, CacheItemPriority.BelowNormal);
    }

    /// <summary>
    /// Gets all the site categores
    /// </summary>
    public static CategoryCollection AllCategories() {
      return CacheService.CacheObject<CategoryCollection>(delegate { return new CategoryController().FetchAll(); }, CACHE_CATEGORYCOLLECTION, CacheLength.GetDefaultCacheTime, CacheItemPriority.Normal);
    }

    #endregion

    #endregion

  }
}
