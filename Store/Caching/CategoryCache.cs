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
      CacheHelper.RemoveCacheObject<string>(CACHE_CATEGORY);
    }

    /// <summary>
    /// Removes the Category Info from the cache.
    /// This will make that the Category should reinsert itself on the next page request
    /// </summary>
    /// <param name="categoryID">The categoryID.</param>
    public static void RemoveCategoryInfoFromCache(int categoryID) {
      CacheHelper.RemoveCacheObject<Category>(string.Format(CACHE_CATEGORY_BYID, categoryID));
    }

    /// <summary>
    /// Refreshes the category breadcrumbs from the cache
    /// </summary>
    public static void RefreshCategoryBreadCrumbs(int categoryId) {
      CacheHelper.RemoveCacheObject<DataSet>(string.Format(CACHE_CATEGORY_CRUMBS, categoryId));         
    }

    /// <summary>
    /// Refreshes the associated product categories from the cache
    /// </summary>
    public static void RefreshProductAssociatedCategories(int productId) {
      CacheHelper.RemoveCacheObject<CategoryCollection>(string.Format(CACHE_CATEGORY_PRODUCT_CRUMBS, productId));
    }

    /// <summary>
    /// Refreshes the associated product categories from the cache
    /// </summary>
    public static void RefreshAllCategories() {
      CacheHelper.RemoveCacheObject<CategoryCollection>(CACHE_CATEGORYCOLLECTION);
    }

    #endregion

    #region Public

    /// <summary>
    /// Gets the page menu.
    /// </summary>
    /// <returns></returns>
    public static string GetCategoryMenu() {
      return CacheHelper.CacheObject<string>(delegate { return new CategoryController().FetchCategoryList().GetXml(); },
          CACHE_CATEGORY, CacheLength.GetLongCacheTime, CacheItemPriority.High);
    }

    /// <summary>
    /// Gets the category info.
    /// </summary>
    /// <param name="categoryID">The category ID.</param>
    /// <returns></returns>
    public static Category GetCategoryInfo(int categoryID) {
      return CacheHelper.CacheObject<Category>(delegate { return new Category(categoryID); },
          string.Format(CACHE_CATEGORY_BYID, categoryID), CacheLength.GetDefaultCacheTime, CacheItemPriority.BelowNormal);
    }

    /// <summary>
    /// Gets the category bedcrumbs.
    /// </summary>
    /// <param name="categoryID">The category ID.</param>
    /// <returns></returns>
    public static DataSet FetchCategoryBreadCrumbs(int categoryID) {
      return CacheHelper.CacheObject<DataSet>(delegate { return new CategoryController().FetchCategoryBreadCrumbs(categoryID); },
          string.Format(CACHE_CATEGORY_CRUMBS, categoryID), CacheLength.GetDefaultCacheTime, CacheItemPriority.Normal);
    }

    /// <summary>
    /// Gets the categories for that product id.
    /// </summary>
    /// <param name="productID">The product ID.</param>
    /// <returns></returns>
    public static CategoryCollection FetchAssociatedCategoriesByProductId(int productID) {
      return CacheHelper.CacheObject<CategoryCollection>(delegate { return new ProductController().FetchAssociatedCategoriesByProductId(productID); },
          string.Format(CACHE_CATEGORY_PRODUCT_CRUMBS, productID), CacheLength.GetDefaultCacheTime, CacheItemPriority.BelowNormal);
    }

    /// <summary>
    /// Gets all the site categores
    /// </summary>
    public static CategoryCollection AllCategories() {
      return CacheHelper.CacheObject<CategoryCollection>(delegate { return new CategoryController().FetchAll(); }, CACHE_CATEGORYCOLLECTION, CacheLength.GetDefaultCacheTime, CacheItemPriority.Normal);
    }

    #endregion

    #endregion

  }
}
