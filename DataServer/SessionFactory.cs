using System;
using System.Reflection;
using System.Web.Configuration;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MettleSystems.DataServer.Context;
using MettleSystems.DataServer.Conventions;
using NHibernate;

namespace MettleSystems.DataServer {
  internal class SessionFactory {

    private readonly IDataContext _dataContext;

    public SessionFactory(IDataContext dataContext) {
      _dataContext = dataContext;
    }

    public ISessionFactory GetSessionFactory() {
      if (_dataContext == null || _dataContext.ApplicationId == 0) {
        return Fluently.Configure()
          .Database(GetSystemPersistenceConfigurer())
          .Mappings(mappings => { 
            mappings
              .AutoMappings
              .Add(new AutoPersistenceModel(
                new SystemAutomappingConvention())
                .AddEntityAssembly(Assembly.LoadWithPartialName("MettleSystems.MultiTenant.Core")));
          
          }).BuildSessionFactory();
      }
      else { 
      
      }

      return null;

    }

    private IPersistenceConfigurer GetSystemPersistenceConfigurer() {
      var webConfiguration = WebConfigurationManager.OpenWebConfiguration("~");
      string databaseType = webConfiguration.AppSettings.Settings["databaseType"].Value;
      IPersistenceConfigurer persistenceConfigurer = null; ;
      switch (databaseType) { 
        case "MSSQL2008":
          persistenceConfigurer = MsSqlConfiguration.MsSql2008.ConnectionString(connectionString => connectionString.FromConnectionStringWithKey("DataServer.System"));
          break;
        case "ORACLE":
          persistenceConfigurer = OracleDataClientConfiguration.Oracle10.ConnectionString(connectionString => connectionString.FromConnectionStringWithKey("DataServer.System"));
          break;
      }
      
      return persistenceConfigurer;

    }
  }
}
