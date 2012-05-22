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
using System.Collections.Generic;
using System.Text;

namespace MettleSystems.dashCommerce.Store.Services.TaxService {

  public class VatTaxProvider : ITaxProvider {

    /// <summary>
    /// Initializes a new instance of the <see cref="VatTaxProvider"/> class.
    /// </summary>
    public VatTaxProvider() {
    }

    #region ITaxProvider Members

    public bool IsProductLevelTaxProvider {
      get {
        return true;
      }
    }

    public decimal GetTaxRate(Product product) {
      VatTaxRate vatTaxRate = new VatTaxRate(product.TaxRateId);
      return vatTaxRate.VatTaxRateId == 0 ? 0 : vatTaxRate.Rate;
    }

    public void GetTaxRate(Order order) {
      VatTaxRate vatTaxRate;
      Product product;
      foreach (var orderItem in order.OrderItemCollection) {
        product = new Product(orderItem.ProductId);
        vatTaxRate = new VatTaxRate(product.TaxRateId);
        orderItem.ItemTax = (orderItem.PricePaid - orderItem.DiscountAmount) * vatTaxRate.Rate;
      }
    }

    #endregion
  }
}
