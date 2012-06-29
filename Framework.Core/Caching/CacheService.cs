using System;

using System.Web.Caching;
using System.Collections.Generic;

namespace MettleSystems.Framework.Core.Caching.Providers {

  public class CacheService : ICacheService {

    ICacheProvider _cacheProvider;

    public CacheService(ICacheProvider cacheProvider) {
      _cacheProvider = cacheProvider;
    }

    public ICacheProvider CacheProvider {
      get {
        return _cacheProvider;
      }
    }


    #region ICacheService Members

    public object this[string key] {
      get {
        throw new NotImplementedException();
      }
    }

    public object Get(string itemKey) {
      return this.CacheProvider.Get(itemKey);
    }

    public void ClearCache() {
      this.CacheProvider.ClearCache();
    }

    public void Remove(string itemKey) {
      this.CacheProvider.Remove(itemKey);
    }

    public void Insert(string keyString, object value, int cacheDurationInSeconds, CacheItemPriority priority) {
      this.CacheProvider.Insert(keyString, value, cacheDurationInSeconds, priority);
    }

    public System.Collections.IDictionaryEnumerator GetEnumerator() {
      return this.CacheProvider.GetEnumerator();
    }

    public int GetCount() {
      return this.CacheProvider.GetCount();
    }

    #endregion
  }
}
