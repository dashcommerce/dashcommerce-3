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
using System.Collections;
using System.Web.Caching;

namespace MettleSystems.dashCommerce.Core.Caching.Providers {
  public interface ICacheProvider {

    /// <summary>
    /// Gets the <see cref="System.Object"/> with the specified key.
    /// </summary>
    /// <value></value>
    object this[string key] {
      get;
    }

    /// <summary>
    /// Gets the specified item key.
    /// </summary>
    /// <param name="itemKey">The item key.</param>
    /// <returns></returns>
    object Get(string itemKey);

    /// <summary>
    /// Clears the cache.
    /// </summary>
    void ClearCache();

    /// <summary>
    /// Removes the specified item key.
    /// </summary>
    /// <param name="itemKey">The item key.</param>
    void Remove(string itemKey);

    /// <summary>
    /// Inserts the specified value into the cache with the keyString as its Key.
    /// </summary>
    /// <param name="keyString">The key string.</param>
    /// <param name="value">The value.</param>
    /// <param name="cacheDurationInSeconds">The cache duration in seconds.</param>
    /// <param name="priority">The priority.</param>
    void Insert(string keyString, object value, int cacheDurationInSeconds, CacheItemPriority priority);

    /// <summary>
    /// Gets the enumerator.
    /// </summary>
    /// <returns></returns>
    IDictionaryEnumerator GetEnumerator();

    /// <summary>
    /// Gets the amount of items in the cache.
    /// </summary>
    /// <returns></returns>
    int GetCount();

  }
}