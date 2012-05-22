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

namespace MettleSystems.dashCommerce.Store.Services.TaxService {
  public class RegionCodeTaxProvider : ITaxProvider {

    #region Constants

    public const string DEFAULT_RATE = "DefaultRate";

    #endregion

    #region Member Variables

    private decimal _defaultTaxRate;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="T:RegionCodeTaxProvider"/> class.
    /// </summary>
    private RegionCodeTaxProvider() {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:RegionCodeTaxProvider"/> class.
    /// </summary>
    /// <param name="defaultTaxRate">The default tax rate.</param>
    public RegionCodeTaxProvider(string defaultTaxRate) {
      decimal taxRate = 0.00M;
      decimal.TryParse(defaultTaxRate, out taxRate);
      _defaultTaxRate = taxRate;
    }

    #endregion

    #region ITaxProvider Members

    /// <summary>
    /// Gets the tax rate.
    /// </summary>
    /// <param name="order"></param>
    public void GetTaxRate(Order order) {
      string postalCode = order.ShippingAddress == null ? order.BillingAddress.PostalCode : order.ShippingAddress.PostalCode;
      RegionCodeTaxRate regionCodeTaxRate = new RegionCodeTaxRate(RegionCodeTaxRate.Columns.RegionCode, postalCode);
      foreach(OrderItem orderItem in order.OrderItemCollection) {
        if(regionCodeTaxRate.RegionCodeTaxRateId > 0) {
          orderItem.ItemTax = (orderItem.PricePaid - orderItem.DiscountAmount) * regionCodeTaxRate.Rate;
        }
        else {
          orderItem.ItemTax = (orderItem.PricePaid - orderItem.DiscountAmount) * _defaultTaxRate;
        }
      }
    }

    public bool IsProductLevelTaxProvider {
      get {
        return false;
      }
    }

    public decimal GetTaxRate(Product product) {
      throw new NotImplementedException();
    }
    #endregion

  }
}
