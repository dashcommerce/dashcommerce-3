using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using StructureMap;
using MettleSystems.DataServer;
using MettleSystems.DataServer.Context;
using MettleSystems.MultiTenant.Core.Models.Entities;

namespace MettleSystems.DataServer.Test {
  [TestClass]
  public class DataServerTest {

    private IDataService<DatabaseConfiguration> systemDataService;

    [TestInitialize]
    public void TestInitialize() {
      ObjectFactory.Initialize(c => c.AddRegistry(new DataServerTestRegistry()));
      systemDataService = ObjectFactory.GetInstance<IDataService<DatabaseConfiguration>>();


    }

    [TestCleanup]
    public void TestCleanup() { 
      //dataService.
    }

    [TestMethod]
    public void System_IDataServerTest() {
      
      var databaseConfiguration = new DatabaseConfiguration {
        ApplicationId = 1,
        CacheRegionPrefix = "test",
        CacheProvider = "test",
        ConnectionDriver = "test",
        Dialect = "test",
        InitialCatalog = "test",
        Name = "test",
        Password = "test",
        Server = "test",
        UserId = "test"
      };
      
      Assert.IsTrue(databaseConfiguration.IsValid());
      systemDataService.Save(databaseConfiguration);
      Assert.IsTrue(databaseConfiguration.DatabaseConfigurationId > 0);
      systemDataService.Delete(databaseConfiguration);
    }

    [TestMethod]
    public void Application_IDataServerTest() {
      var databaseConfiguration = systemDataService.Find(p => p.Name == "dashCommerce");
      Assert.IsTrue(databaseConfiguration != null);
    }
  }
}
