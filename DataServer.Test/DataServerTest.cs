using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using StructureMap;
using MettleSystems.DataServer;
using MettleSystems.MultiTenant.Core.Models.Entities;

namespace MettleSystems.DataServer.Test {
  [TestClass]
  public class DataServerTest {

    [TestInitialize]
    public void TestInitialize() {
      ObjectFactory.Initialize(c => c.AddRegistry(new DataServerTestRegistry()));
    }

    [TestMethod]
    public void System_IDataServerTest() {
      ObjectFactory.GetInstance<IDataService<DatabaseConfiguration>>();
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
    }
  }
}
