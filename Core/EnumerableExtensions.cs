using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MettleSystems.dashCommerce.Core {
  public static class EnumerableExtensions {

    /// <summary>The distinct by.</summary>
    /// <param name="source">The source.</param>
    /// <param name="keySelector">The key selector.</param>
    /// <typeparam name="TSource">Source type</typeparam>
    /// <typeparam name="TKey">Key type</typeparam>
    /// <returns>the unique list</returns>
    public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        where TKey : IEquatable<TKey> {
      return source.Distinct(DeferredEqualityComparer<TSource>.CompareMember(keySelector));
    }
  }
}
