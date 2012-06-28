using System;
using System.Web.Caching;

namespace MettleSystems.dashCommerce.Core.Caching {

  public delegate T AddToCacheAction<T>();

  public interface ICacheService {
    
    T CacheObject<T>(AddToCacheAction<T> addToCache, string cacheKey);

    T CacheObject<T>(AddToCacheAction<T> addToCache, string cacheKey, int cacheDurationInSeconds);

    T CacheObject<T>(AddToCacheAction<T> addToCache, string cacheKey, int cacheDurationInSeconds, CacheItemPriority priority);

    T Get<T>(string cacheKey);

    void RemoveCacheObject<T>(string cacheKey);

    void RemoveAllCacheObjectStartWith(string keyStartsWith);

    void RemoveAllCacheObjectByPattern(string regxPattern);

    void RemoveAll(System.Predicate<string> match);

    int GetAmountOfItemsInCache { get; }

  }
}
