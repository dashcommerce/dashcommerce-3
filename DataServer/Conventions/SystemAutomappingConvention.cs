using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate;
using FluentNHibernate.Automapping;

namespace MettleSystems.DataServer.Conventions {

  internal class SystemAutomappingConvention : DefaultAutomappingConfiguration {

    public override bool IsId(Member member) {
      return member.Name == member.DeclaringType.Name + "Id";
    }

    public override bool ShouldMap(Type type) {
      bool shouldMap = false;
      //if (type.IsClass && !type.IsAbstract && type.Namespace.EndsWith("Models.Entities") && !typeof(IAuditor).IsAssignableFrom(type)) {
      if (type.IsClass && !type.IsAbstract && type.Namespace.EndsWith("Models.Entities")) {
        shouldMap = true;
      }
      return shouldMap;
    }
  }
}
