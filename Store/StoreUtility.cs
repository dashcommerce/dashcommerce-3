#region dashCommerce License
/*
The MIT License

Copyright (c) 2008 - 2010 Mettle Systems LLC, P.O. Box 181192 Cleveland Heights, Ohio 44118, United States

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
#endregion
using System;
using System.Globalization;
using MettleSystems.dashCommerce.Core.Caching;

namespace MettleSystems.dashCommerce.Store {
  public class StoreUtility {
  
    #region Methods
    
    #region Public

    /// <summary>
    /// Gets the formatted amount.
    /// </summary>
    /// <param name="amount">The amount.</param>
    /// <param name="formatWithCurrencySymbol">if set to <c>true</c> [format with currency symbol].</param>
    /// <returns></returns>
    public static string GetFormattedAmount(decimal amount, bool formatWithCurrencySymbol) {
      SiteSettings siteSettings = SiteSettingCache.GetSiteSettings();
      CultureInfo cultureInfo = new CultureInfo(siteSettings.Language);
      if(formatWithCurrencySymbol) {
        return string.Format("{0} {1}", siteSettings.CurrencySymbol, decimal.Round(amount, cultureInfo.NumberFormat.CurrencyDecimalDigits).ToString(cultureInfo));
      }
      else {
        return decimal.Round(amount, cultureInfo.NumberFormat.CurrencyDecimalDigits).ToString(cultureInfo);
      }
    }

    /// <summary>
    /// Gets the formatted amount.
    /// </summary>
    /// <param name="amount">The amount.</param>
    /// <param name="formatWithCurrencySymbol">if set to <c>true</c> [format with currency symbol].</param>
    /// <returns></returns>
    public static string GetFormattedAmount(string amount, bool formatWithCurrencySymbol) {
      decimal parsedAmount = 0;
      parsedAmount = decimal.Parse(amount);
      return GetFormattedAmount(parsedAmount, formatWithCurrencySymbol);
    }

    /// <summary>
    /// Gets the formatted date.
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns></returns>
    public static string GetFormattedDate(DateTime date) {
      SiteSettings siteSettings = SiteSettingCache.GetSiteSettings();
      CultureInfo cultureInfo = new CultureInfo(siteSettings.Language);
      return date.ToString("D", cultureInfo);
    }

    #endregion
    
    #endregion

  }
}
