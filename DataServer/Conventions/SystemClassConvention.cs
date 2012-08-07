using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace MettleSystems.DataServer.Conventions {
  public class SystemClassConvention : IClassConvention {
    public void Apply(IClassInstance instance) {
      instance.Table("system_" + instance.TableName.Replace("`", string.Empty));
    }
  }
}
