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