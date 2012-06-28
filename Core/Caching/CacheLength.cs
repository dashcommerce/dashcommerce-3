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
using MettleSystems.dashCommerce.Store;

namespace MettleSystems.dashCommerce.Core.Caching {
  public static class CacheLength {

    #region Constants

    private const int SHORT_CACHE_TIME = 120; // 2 minutes
    private const int NORMAL_CACHE_TIME = 300; // 5 minutes
    private const int LONG_CACHE_TIME = 1500; // 25 minutes

    public const string SHORT_CACHE = "SHORT_CACHE_TIME";
    public const string NORMAL_CACHE = "NORMAL_CACHE_TIME";
    public const string DEFAULT_CACHE = NORMAL_CACHE;
    public const string LONG_CACHE = "LONG_CACHE_TIME";

    #endregion

    #region Member Variables

    #endregion

    #region Properties

    /// <summary>
    /// Gets the get default cache time.
    /// </summary>
    /// <value>The get default cache time.</value>
    public static int GetDefaultCacheTime {
      get {
        return GetCacheLengthByKey(DEFAULT_CACHE);
      }
    }
    /// <summary>
    /// Gets the get default cache time.
    /// </summary>
    /// <value>The get default cache time.</value>
    public static int GetNormalCacheTime {
      get {
        return GetCacheLengthByKey(NORMAL_CACHE);
      }
    }

    /// <summary>
    /// Gets the get ten minutes cache time.
    /// </summary>
    /// <value>The get ten minutes cache time.</value>
    public static int GetShortCacheTime {
      get {
        return GetCacheLengthByKey(SHORT_CACHE);
      }
    }
    /// <summary>
    /// Gets the get long cache time.
    /// </summary>
    /// <value>The get long cache time.</value>
    public static int GetLongCacheTime {
      get {
        return GetCacheLengthByKey(LONG_CACHE);
      }
    }

    #endregion

    #region Methods

    #region Public Static
    /// <summary>
    /// Gets the cache length by key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns></returns>
    public static int GetCacheLengthByKey(string key) {
      SiteSettings cacheServiceSetting = CacheManager<string, int>.GetInstance().GetSiteSettings;

      if(cacheServiceSetting != null) {
        switch(key) {
          case SHORT_CACHE:
            return cacheServiceSetting.ShortCacheSeconds;
          case NORMAL_CACHE:
            return cacheServiceSetting.NormalCacheSeconds;
          case LONG_CACHE:
            return cacheServiceSetting.LongCacheSeconds;
          default:
            break;
        }
      }
      else {//if it is missing the configuration (we have to have this to use the site)
        switch(key) {
          case SHORT_CACHE:
            return SHORT_CACHE_TIME;
          case NORMAL_CACHE:
            return NORMAL_CACHE_TIME;
          case LONG_CACHE:
            return LONG_CACHE_TIME;
          default:
            break;
        }
      }

      return NORMAL_CACHE_TIME;
    }

    #endregion

    #endregion
  }
}