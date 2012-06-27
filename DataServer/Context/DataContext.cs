using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MettleSystems.DataServer.Context {
  public class DataContext : IDataContext {

    #region IDataContext Members

    public string Name {
      get;
      set;
    }

    public int ApplicationId {
      get;
      set;
    }

    public string CachePrefix {
      get;
      set;
    }

    public object CultureId {
      get;
      set;
    }
    #endregion
  }
}
