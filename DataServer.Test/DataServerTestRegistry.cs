using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using FluentNHibernate.Conventions;
using MettleSystems.DataServer.Context;
using MettleSystems.Framework.Core.Caching;
using MettleSystems.Framework.Core.Caching.Providers;
using StructureMap.Configuration.DSL;

namespace MettleSystems.DataServer.Test
{
    public class DataServerTestRegistry : Registry
    {

        public DataServerTestRegistry() {
            For(typeof(IDataService<>)).Use(typeof(DataService<>));
            For<IDataContext>().Use<DataContext>();
            For<ICacheService>().Use<CacheService>();
            For<ICacheProvider>().Use<HttpRuntimeCacheProvider>();
            Scan(x =>
            {
              x.AssembliesFromPath(@".", assembly => assembly.GetName().Name.StartsWith("MettleSystems.MultiTenant.Core"));
                //x.AddAllTypesOf<IClassConvention>();
            });

        }
    }
}
