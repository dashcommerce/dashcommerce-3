using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using MettleSystems.DataServer.Context;

namespace MettleSystems.DataServer {

  internal class Repository<T> : IRepository<T>, IDisposable where T : class {

    #region Member Variables

    private ISessionFactory _sessionFactory;
    private ISession _session = null;

    #endregion

    #region Constructors

    public Repository(IDataContext dataContext) {
      _sessionFactory = new SessionFactoryCache(dataContext).GetSessionFactory();
      _session = _sessionFactory.OpenSession();
      //TODO: CMC - Fix the CultureId parameter.
      //_session.EnableFilter("CultureFilter").SetParameter("CultureId", 1);
    }

    #endregion

    #region IRepository<T> Members

    public T Find(object id) {
      T obj = default(T);
      using (var transaction = _session.BeginTransaction()) {
        obj = _session.Get<T>(id);
        transaction.Commit();
      }
      return obj;
    }

    public T Find(Expression<Func<T, bool>> criteria) {
      T item = default(T);
      using (var transaction = _session.BeginTransaction()) {
        item = _session
            .QueryOver<T>()
            .Where(criteria)
            .SingleOrDefault();
        transaction.Commit();
      }
      return item;
    }

    public IList<T> FindAll() {
      IList<T> list = new List<T>(); 
      using (var transaction = _session.BeginTransaction()) {
       list = _session
            .CreateCriteria<T>()
            .List<T>();
       transaction.Commit();
      }
      return list;
    }

    public IList<T> FindAll(Expression<Func<T, bool>> criteria) {
      IList<T> list = new List<T>();
      using (var transaction = _session.BeginTransaction()) {
        list = _session
            .QueryOver<T>()
            .Where(criteria)
            .List();
        transaction.Commit();
      }
      return list;
    }

    public void Save(T item) {
      using (var transaction = _session.BeginTransaction()) {
        _session.SaveOrUpdate(item);
        transaction.Commit();
      }
    }

    public void Delete(object id) {
      Delete(Find(id));
    }

    public void Delete(T item) {
      using (var transaction = _session.BeginTransaction()) {
        _session.Delete(item);
        transaction.Commit();
      }
    }



    #endregion

    #region IDisposable Members

    private bool _hasDisposed;

    public void Dispose() {
      if (!_hasDisposed) {
        Dispose(true);
        GC.SuppressFinalize(this);
      }

    }

    protected virtual void Dispose(bool isDisposing) {
      if (_hasDisposed) return;
      if (isDisposing) {
        //Free Managed Resources
        if (_session != null) {
          if (_session.IsOpen) {
            _session.Close();
          }
          _session = null;
        }
      }

      //TODO: Free Unmanaged Resource

      _hasDisposed = true;
    }


    ~Repository() {
      Dispose(false);
    }


    #endregion


  }
}
