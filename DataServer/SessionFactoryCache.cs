using System;

using MettleSystems.DataServer.Context;
using MettleSystems.dashCommerce.Core.Caching;
using StructureMap;
using NHibernate;
using System.Web.Caching;

namespace MettleSystems.DataServer {

  internal class SessionFactoryCache {

    readonly IDataContext _dataContext;
    readonly ICacheService _cacheService;

       internal SessionFactoryCache() {
      _dataContext = null;
      _cacheService = ObjectFactory.GetInstance<ICacheService>();
    }

    internal SessionFactoryCache(IDataContext dataContext) {
      _dataContext = dataContext;
      _cacheService = ObjectFactory.GetInstance<ICacheService>();
    }

    internal ISessionFactory GetSessionFactory() {
      ISessionFactory sessionFactory = null;
      string cacheKey = GetCacheKey();
      //TODO: CMC - Add to cache
      //ISessionFactory sessionFactory = _cacheService.Get(cacheKey) as ISessionFactory;
      if (sessionFactory == null) {
        SessionFactory _sessionFactory = new SessionFactory(_dataContext);
        sessionFactory = _sessionFactory.GetSessionFactory();
        //TODO: CMC - Add to cache
        //_cacheService.Insert(cacheKey, sessionFactory, 604800, CacheItemPriority.High);
      }
      return sessionFactory;
    }

    private string GetCacheKey() {
      string cacheKey = "System";
      if (_dataContext != null) {
        if (!string.IsNullOrEmpty(_dataContext.CachePrefix) && !string.IsNullOrEmpty(_dataContext.Name)) {
          cacheKey = string.Format("{0}::{1}::{2}", _dataContext.CachePrefix, _dataContext.ApplicationId, _dataContext.Name);
        }
      }
      return cacheKey;
    }
  }
}
