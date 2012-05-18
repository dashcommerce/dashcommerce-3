#region dashCommerce License
/*
dashCommerce® is Copyright © 2008-2012 Mettle Systems LLC. All Rights Reserved.


dashCommerce, and the dashCommerce logo are registered trademarks of Mettle Systems LLC. Mettle Systems LLC logos and trademarks may not be used without prior written consent.

dashCommerce is licensed under the following license. If you do not accept the terms, please discontinue the use of dashCommerce and uninstall dashCommerce. 

Your license to the dashCommerce source and/or binaries is governed by the Reciprocal Public License 1.5 (RPL1.5) license as described here: 

http://www.opensource.org/licenses/rpl1.5.txt 

If you do not wish to release the source of software you build using dashCommerce, you may purchase a site license, which will allow you to deploy dashCommerce for use in 1 web store defined as using 1 URL. You may purchase a site license here: 

http://www.dashcommerce.org/license.html 
*/
#endregion
using System.Collections;
using System.Globalization;

namespace MettleSystems.dashCommerce.Core.Globalization {
  
  public class CultureComparer : IComparer {

    #region IComparer Members

    /// <summary>
    /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
    /// </summary>
    /// <param name="x">The first object to compare.</param>
    /// <param name="y">The second object to compare.</param>
    /// <returns>
    /// Value Condition Less than zero x is less than y. Zero x equals y. Greater than zero x is greater than y.
    /// </returns>
    /// <exception cref="T:System.ArgumentException">Neither x nor y implements the <see cref="T:System.IComparable"></see> interface.-or- x and y are of different types and neither one can handle comparisons with the other. </exception>
    public int Compare(object x, object y) {
      Validator.ValidateObjectType(x, typeof(CultureInfo));
      Validator.ValidateObjectType(y, typeof(CultureInfo));

      CultureInfo a = x as CultureInfo;
      CultureInfo b = y as CultureInfo;

      return a.DisplayName.CompareTo(b.DisplayName);
    }

    #endregion
    
  }
}
