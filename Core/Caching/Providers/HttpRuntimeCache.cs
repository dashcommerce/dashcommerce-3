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
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;

namespace MettleSystems.dashCommerce.Core.Caching.Providers {

  /// <summary>
  /// Uses the HttpRuntime.Cache
  /// </summary>
  public class HttpRuntimeCache : ICacheProvider {

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