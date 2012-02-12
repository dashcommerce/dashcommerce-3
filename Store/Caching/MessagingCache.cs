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
      CacheHelper.RemoveCacheObject<MailSettings>(CACHE_MAILSETTINGS);
    }

    /// <summary>
    /// Gets a MostPopularProducts.
    /// </summary>
    /// <returns></returns>
    public static MailSettings GetMailSettings() {
      return CacheHelper.CacheObject<MailSettings>(delegate { return MailSettings.Load(); }, CACHE_MAILSETTINGS, CacheLength.GetDefaultCacheTime, CacheItemPriority.Default);
    }

    #endregion
  }   
}