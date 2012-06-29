using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;

namespace MettleSystems.Framework.Core.Caching.Providers {

  /// <summary>
  /// Uses the HttpRuntime.Cache
  /// </summary>
  public class HttpRuntimeCacheProvider : ICacheProvider {

    #region ICache Members

    /// <summary>
    /// Gets the <see cref="System.Object"/> with the specified key.
    /// </summary>
    /// <value></value>
    public object this[string key] {
      get {
        return HttpRuntime.Cache[key];
      }
    }

    /// <summary>
    /// Gets the specified item key.
    /// </summary>
    /// <param name="itemKey">The item key.</param>
    /// <returns></returns>
    public object Get(string itemKey) {
      return HttpRuntime.Cache.Get(itemKey);
    }

    /// <summary>
    /// Clears the cache.
    /// </summary>
    public void ClearCache() {
      //HttpRuntime.Close();//IntelliSense says "Removes all items from the cache." but it does a lot more then that.
      //So this is the way to go
      System.Collections.IDictionaryEnumerator itemsInCache = GetEnumerator();
      IList<string> keysInCache = new List<string>();
      while (itemsInCache.MoveNext()) {
        keysInCache.Add(itemsInCache.Key.ToString());
      }
      foreach (string items in keysInCache) {
        Remove(items);
      }    
    }

    /// <summary>
    /// Removes the specified item key.
    /// </summary>
    /// <param name="itemKey">The item key.</param>
    public void Remove(string itemKey) {
      HttpRuntime.Cache.Remove(itemKey);
    }

    /// <summary>
    /// Inserts the specified key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <param name="cacheDurationInSeconds">The cache duration in seconds.</param>
    /// <param name="priority">The priority.</param>
    public void Insert(string key, object value, int cacheDurationInSeconds, CacheItemPriority priority) {
      HttpRuntime.Cache.Insert(key, value, null, DateTime.Now.AddSeconds(cacheDurationInSeconds), Cache.NoSlidingExpiration, priority, null);
    }

    /// <summary>
    /// Gets the enumerator.
    /// </summary>
    /// <returns></returns>
    public System.Collections.IDictionaryEnumerator GetEnumerator() {
      return HttpRuntime.Cache.GetEnumerator();
    }

    /// <summary>
    /// Gets the amount of items in the cache.
    /// </summary>
    /// <returns></returns>
    public int GetCount() {
        return HttpRuntime.Cache.Count;
    }

    #endregion

  }
}