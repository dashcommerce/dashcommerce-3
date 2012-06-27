using System;


namespace MettleSystems.DataServer.Context {
  partial interface IDataContext {

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
