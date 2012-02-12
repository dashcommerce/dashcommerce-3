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
