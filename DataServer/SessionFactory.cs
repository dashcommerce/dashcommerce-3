using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MettleSystems.DataServer.Context;
using MettleSystems.DataServer.Conventions;
using MettleSystems.MultiTenant.Core.Models.Entities;
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
              .Add(AutoMap.AssemblyOf<Application>(new SystemAutomappingConfiguration()));
          
          }).BuildSessionFactory();
        //TODO: Need to add NHibernate Validation
      }
      else { 
        //need to spin up the db for the tenant
        //do the lookup and build up the _sessionFactory
        SessionFactoryCache sessionFactoryCache = new SessionFactoryCache(null);
        ISessionFactory systemSessionFactory = sessionFactoryCache.GetSessionFactory();
        //TODO: CMC - Use IDataServer for this?
        var databaseConfiguration =
          systemSessionFactory.OpenSession().CreateQuery(
            string.Format("from DatabaseConfiguration where ApplicationId = {0} and Name = '{1}' and CacheRegionPrefix = '{2}'",
                          _dataContext.ApplicationId, _dataContext.Name, _dataContext.CachePrefix)).UniqueResult() as DatabaseConfiguration;
        if (databaseConfiguration == null) {
          //TODO: Put this into localizable location
          throw new InvalidOperationException("No database with that data context has been found.");
        }
        List<Assembly> assemblyList = GetAssemblies();
        return Fluently.Configure()
          .Database(GetApplicationPersistenceConfigurer(databaseConfiguration))
          .Mappings(mappings => {
            foreach (Assembly assembly in assemblyList) {
              mappings.AutoMappings.Add(AutoMap.Assemblies(new SystemAutomappingConfiguration(), assemblyList.ToArray()));
            }
          }).BuildSessionFactory();


      }
    }

    private List<Assembly> GetAssemblies() {
      string[] files = Directory.GetFiles(".", "*.dll");
      var assemblies = new List<Assembly>(files.Length);
      for (int i = 0; i < files.Length; i++) {
        if (files[i].StartsWith(@".\MettleSystems") && !files[i].Contains("MettleSystems.DataServer") && !files[i].Contains("MettleSystems.MultiTenant.Core")) {
          assemblies.Add(Assembly.LoadFile(Path.GetFullPath(files[i])));
        }
      }
      return assemblies;
    }

    private IPersistenceConfigurer GetApplicationPersistenceConfigurer(DatabaseConfiguration databaseConfiguration) {
      IPersistenceConfigurer persistenceConfigurer = null;
      switch (databaseConfiguration.ConnectionDriver) { 
        case "NHibernate.Driver.SqlClientDriver":
          //TODO: May need to select which MsSqlConfiguration
          persistenceConfigurer = MsSqlConfiguration.MsSql2008.ConnectionString(MsSqlConnectionStringBuilder(databaseConfiguration));
          break;
        default:
          persistenceConfigurer = MsSqlConfiguration.MsSql2008.ConnectionString(MsSqlConnectionStringBuilder(databaseConfiguration));
          break;
      }
      return persistenceConfigurer;
    }

    private string MsSqlConnectionStringBuilder(DatabaseConfiguration databaseConfiguration) {
      //TODO: Need to decrypt these values
      return string.Format("Server={0};Initial Catalog={1};User Id={2};Password={3};", databaseConfiguration.Server, databaseConfiguration.InitialCatalog, databaseConfiguration.UserId, databaseConfiguration.Password);
    }

    private IPersistenceConfigurer GetSystemPersistenceConfigurer() {
      var databaseType = ConfigurationManager.AppSettings["databaseType"];
      IPersistenceConfigurer persistenceConfigurer = null;
      //TODO: Put the rest of these in here
      switch (databaseType) { 
        case "MSSQL2008":
          persistenceConfigurer = MsSqlConfiguration.MsSql2008.ConnectionString(connectionString => connectionString.FromConnectionStringWithKey("DataServer.System"));
          break;
        case "ORACLE":
          persistenceConfigurer = OracleDataClientConfiguration.Oracle10.ConnectionString(connectionString => connectionString.FromConnectionStringWithKey("DataServer.System"));
          break;
        default:
          persistenceConfigurer = MsSqlConfiguration.MsSql2008.ConnectionString(connectionString => connectionString.FromConnectionStringWithKey("DataServer.System"));
          break;
      }
      
      return persistenceConfigurer;

    }
  }
}
