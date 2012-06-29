using System;
using System.Collections.Generic;
using System.Linq;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using MettleSystems.DataServer.Context;

namespace MettleSystems.DataServer {
  
  internal class Repository<T> : IRepository<T>, IDisposable {

    #region Member Variables

    private ISessionFactory _sessionFactory;
    private ISession _session = null;
    private ITransaction _transaction = null;

    #endregion

    #region Constructors

    public Repository(IDataContext dataContext) {
      //_sessionFactory = new Configuration().Configure().BuildSessionFactory();
      _sessionFactory = new SessionFactoryCache(dataContext).GetSessionFactory();
      _session = _sessionFactory.OpenSession();
      //TODO: CMC - Fix the CultureId parameter.
      //_session.EnableFilter("CultureFilter").SetParameter("CultureId", 1);
      //_transaction = null;
    }

    #endregion

    #region IRepository<T> Members
    //#region IRepository Members 
   
    //public object Get(object id) {
    //  try {
    //    _transaction = _session.BeginTransaction();
    //    object obj = _session.Get(id);
    //    _transaction.Commit();
    //    _transaction = null;
    //    return obj;
    //  }
    //  catch {
    //  }
    //}

    public T Get(object id) {
      try {
        T obj = default(T);
        _transaction = _session.BeginTransaction();
        obj = _session.Get<T>(id);
        _transaction.Commit();
        _transaction = null;
        return obj;
      }
      catch {
        if (_transaction != null) {
          _transaction.Rollback();
        }
        throw;
      }
    }

    public T Load(object id) {
      try {

        //TODO: CMC - This doesn't work, so what's the dillio?

        //T obj = default(T);
        //using (_session = _sessionFactory.OpenSession()) {
        //  using (_transaction = _session.BeginTransaction()) {
        //    obj = _session.Load<T>(id);
        //    _transaction.Commit();
        //    _transaction = null;
        //  }
        //}
        //return obj;

        T obj = default(T);
        _transaction = _session.BeginTransaction();
        obj = _session.Load<T>(id);
        _transaction.Commit();
        _transaction = null;
        return obj;
      }
      catch {
        if (_transaction != null) {
          _transaction.Rollback();
        }
        throw;
      }
    }

    public void Save(object obj) {
      try {
        //using (_session = _sessionFactory.OpenSession()) {
        //  using (_transaction = _session.BeginTransaction()) {
        _transaction = _session.BeginTransaction();
        _session.Save(obj);
        _transaction.Commit();
        _transaction = null;
        //  }
        //}
      }
      catch {
        if (_transaction != null) {
          _transaction.Rollback();
        }
        throw;
      }
    }

    public IList<T> FindAll(DetachedCriteria criteria) {
      throw new NotImplementedException();
    }

    public T LoadByName(string name) {
      T obj = default(T);
      _transaction = _session.BeginTransaction();
      obj = _session.CreateCriteria(typeof(T)).Add(Expression.Eq("Name", name)).UniqueResult<T>();
      _transaction.Commit();
      _transaction = null;
      return obj;
    }


    public IQueryable<T> Find() {
      throw new NotImplementedException();
    }

    public IQueryable<T> Find(int id) {
      throw new NotImplementedException();
    }

    public IQueryable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> expression) {
      throw new NotImplementedException();
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
			if(_hasDisposed) return;
			if (isDisposing) {
				//Free Managed Resources
        if (_transaction != null) {
          _transaction.Rollback();
          _transaction = null;
        }
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
