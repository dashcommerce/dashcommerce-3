using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MettleSystems.dashCommerce.Core {
  public static class StringExtensions {

    public static bool IsNullOrWhiteSpace(this string str) {
      return (str == null) || (str.Trim().Length == 0);
    }

    public static bool InvariantEquals(this string compare, string compareTo) {
      return String.Equals(compare, compareTo, StringComparison.InvariantCultureIgnoreCase);
    }
  }
}
