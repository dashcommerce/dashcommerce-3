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
using MettleSystems.dashCommerce.Store;

namespace MettleSystems.dashCommerce.Core.Caching {
  public class SiteSettingCache {

    #region Constants

    private const string CACHE_DC_SITE_SETTINGS = "dashCommerce_SiteSettings";

    #endregion

    #region Methods

    #region Public

    /// <summary>
    /// Removes the site settings from cache.
    /// </summary>
    public static void RemoveSiteSettingsFromCache() {
      CacheService.RemoveCacheObject<SiteSettings>(CACHE_DC_SITE_SETTINGS);
    }

    /// <summary>
    /// Gets the site settings.
    /// </summary>
    /// <returns></returns>
    public static SiteSettings GetSiteSettings() {
      //There should be some caching here even if the site has disabled caching. (there are to many calls to SiteSettings)
      return CacheService.CacheObject<SiteSettings>(delegate {
        SiteSettings siteSettings = SiteSettings.Load();
        if (siteSettings == null) {
          siteSettings = new SiteSettings();
        }
        return siteSettings;
      }
            , CACHE_DC_SITE_SETTINGS, CacheLength.GetLongCacheTime, CacheItemPriority.AboveNormal);
    }

    #endregion

    #endregion

  }
}
