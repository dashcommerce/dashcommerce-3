
namespace MettleSystems.Framework.Core.Caching.Providers {

  public class NullCacheProvider : ICacheProvider {

    #region ICacheProvider Members

    public object this[string key] {
      get {
        return null;
      }
    }

    public object Get(string itemKey) {
      return null;
    }

    public void ClearCache() {
    }

    public void Remove(string itemKey) {
    }

    public void Insert(string keyString, object value, int cacheDurationInSeconds, System.Web.Caching.CacheItemPriority priority) {
    }

    public System.Collections.IDictionaryEnumerator GetEnumerator() {
      return new System.Collections.Hashtable().GetEnumerator();
    }

    public int GetCount() {
        return 0;
    }

    #endregion

  }
}