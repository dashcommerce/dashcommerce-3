using System;


namespace MettleSystems.DataServer.Context {
  public partial interface IDataContext {

    #region IDataContext Members

    string Name {
      get;
      set;
    }

    int ApplicationId {
      get;
      set;
    }

    string CachePrefix {
      get;
      set;
    }

    object CultureId {
      get;
      set;
    }
    #endregion
  }
}
