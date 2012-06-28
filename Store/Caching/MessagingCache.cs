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

namespace MettleSystems.dashCommerce.Store.Caching {
  public class MessagingCache {

    #region Constants

    private const string CACHE_MAILSETTINGS = "MailSettingsCache";

    #endregion

    #region Public

    /// <summary>
    /// Removes the MostPopularProducts from the cache.
    /// </summary>
    public static void RemoveMailSettings() {
      CacheService.RemoveCacheObject<MailSettings>(CACHE_MAILSETTINGS);
    }

    /// <summary>
    /// Gets a MostPopularProducts.
    /// </summary>
    /// <returns></returns>
    public static MailSettings GetMailSettings() {
      return CacheService.CacheObject<MailSettings>(delegate { return MailSettings.Load(); }, CACHE_MAILSETTINGS, CacheLength.GetDefaultCacheTime, CacheItemPriority.Default);
    }

    #endregion
  }   
}