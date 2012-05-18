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
using System.Web.Caching;
using MettleSystems.dashCommerce.Core.Caching.Manager;

namespace MettleSystems.dashCommerce.Content.Caching {
  public class PageCache {

    #region Constants

    private const string CACHE_PAGE_ITEM = "PageCollection_ItemID_{0}";

    #endregion

    #region Methods

    #region Public

    /// <summary>
    /// Removes the page by ID.
    /// This will force a reinsert to the cache on the next request.
    /// </summary>
    /// <param name="pageId">The page ID.</param>
    public static void RemovePageByID(int pageId) {
      CacheHelper.RemoveCacheObject<Page>(MakePageItemKey(pageId));
    }

    /// <summary>
    /// Gets the page by ID.
    /// </summary>
    /// <param name="pageId">The page ID.</param>
    /// <returns></returns>
    public static Page GetPageByID(int pageId) {
      return CacheHelper.CacheObject<Page>(delegate {
        Page pageItem = new Page(pageId);
        return !pageItem.IsNew ? pageItem : null;
      }, MakePageItemKey(pageId), CacheLength.GetDefaultCacheTime, CacheItemPriority.BelowNormal);
    }

    /// <summary>
    /// Gets the page by ID.
    /// </summary>
    /// <returns></returns>
    public static Page GetDefaultPage() {
      return CacheHelper.CacheObject<Page>(delegate {
        Page pageItem = new PageController().FetchDefaultPage();
        if(pageItem != null) {
          return !pageItem.IsNew ? pageItem : null;
        }
        else {
          return null;
        }
      }, string.Format(CACHE_PAGE_ITEM, "Default"), CacheLength.GetDefaultCacheTime, CacheItemPriority.BelowNormal);
    }

    /// <summary>
    /// Makes the page item key.
    /// </summary>
    /// <param name="pageId">The page id.</param>
    /// <returns></returns>
    private static string MakePageItemKey(int pageId) {
      return string.Format(CACHE_PAGE_ITEM, pageId);
    }

    #endregion

    #endregion

  }
}
