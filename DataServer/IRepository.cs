using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate.Criterion;

namespace MettleSystems.DataServer {
  interface IRepository<T> {
  //interface IRepository {
    //object Get(object id);
    //object Load(object id);
    //IList<object> FindAll(DetachedCriteria criteria);
    void Save(object obj);
    void Dispose();

    T Get(object id);
    T Load(object id);
    IList<T> FindAll(DetachedCriteria criteria);
    T LoadByName(string name);

    IQueryable<T> Find();
    IQueryable<T> Find(int id);
    IQueryable<T> Find(Expression<Func<T, bool>> expression);
  }
}
