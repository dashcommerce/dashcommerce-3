using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using NHibernate.Criterion;

namespace MettleSystems.DataServer {

  public interface IDataService<T> {

    T Find(object id);
    T Find(Expression<Func<T, bool>> criteria);
    IList<T> FindAll();
    IList<T> FindAll(Expression<Func<T, bool>> criteria);
    void Save(T item);
    void Delete(object obj);
    void Delete(T item);
    void Dispose();

  }

}
