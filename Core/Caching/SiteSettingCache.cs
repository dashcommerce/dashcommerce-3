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
      CacheHelper.RemoveCacheObject<SiteSettings>(CACHE_DC_SITE_SETTINGS);
    }

    /// <summary>
    /// Gets the site settings.
    /// </summary>
    /// <returns></returns>
    public static SiteSettings GetSiteSettings() {
      //There should be some caching here even if the site has disabled caching. (there are to many calls to SiteSettings)
      return CacheHelper.CacheObject<SiteSettings>(delegate {
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
