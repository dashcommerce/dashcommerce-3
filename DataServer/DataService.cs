using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using NHibernate.Criterion;
using MettleSystems.DataServer.Context;
//TODO: Probably need to change this a custom configuration
#if DEBUG
using HibernatingRhinos.Profiler.Appender.NHibernate;
#endif

namespace MettleSystems.DataServer {

  /// <summary>
  /// Data Server performs all of the database operations.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class DataService<T> : IDataService<T>, IDisposable {

    #region Member Variables

    IRepository<T> _repository;

    #endregion

    #region Constructors

    public DataService(IDataContext dataContext) {
      //TODO: Probably need to change this to a custom configuration
      #if DEBUG
      NHibernateProfiler.Initialize();
      #endif
      _repository = new Repository<T>(dataContext);
    }

    #endregion

    #region Methods

    public T Get(object id) {
      return _repository.Get(id);
    }

    public T Load(object id) {
      return _repository.Load(id);
    }

    public void Save(object obj) {
      _repository.Save(obj);
    }

    public IList<T> FindAll(DetachedCriteria criteria) {
      return _repository.FindAll(criteria);
    }

    public T LoadByName(string name) {
      return _repository.LoadByName(name);
    }

    public IQueryable<T> Find() {
      return _repository.Find();
    }

    public IQueryable<T> Find(int id) {
      return _repository.Find(id);
    }

    public IQueryable<T> Find(Expression<Func<T, bool>> expression) {
      return _repository.Find(expression);
    }


    #endregion

    #region IDisposable Members

    private bool _hasDisposed;

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose() {
      if (!_hasDisposed) {
        Dispose(true);
        GC.SuppressFinalize(this);
      }

    }

    /// <summary>
    /// Releases unmanaged and - optionally - managed resources
    /// </summary>
    /// <param name="isDisposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
    protected virtual void Dispose(bool isDisposing) {
      if (_hasDisposed)
        return;
      if (isDisposing) {
        //TODO: CMC - Free Managed Resources
        _repository.Dispose();
      }

      //TODO: CMC - Free Unmanaged Resource

      _hasDisposed = true;
    }

    /// <summary>
    /// Releases unmanaged resources and performs other cleanup operations before the
    /// <see cref="DataServer&lt;T&gt;"/> is reclaimed by garbage collection.
    /// </summary>
    ~DataService() {
      Dispose(false);
    }

    #endregion

  }
}