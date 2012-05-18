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
