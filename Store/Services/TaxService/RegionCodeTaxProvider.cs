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
