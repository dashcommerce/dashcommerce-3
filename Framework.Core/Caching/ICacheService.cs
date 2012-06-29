
using System.Collections;
using System.Web.Caching;

namespace MettleSystems.Framework.Core.Caching {

  public interface ICacheService {

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