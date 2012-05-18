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


namespace MettleSystems.dashCommerce.Store {
  public partial class OrderItem {
  
    #region Member Variables
    
    private ExtendedProperties _extendedProperties = null;
    
    #endregion

    #region Properties

    /// <summary>
    /// Gets the extended price.
    /// </summary>
    /// <value>The extended price.</value>
    public decimal ExtendedPrice {
      get {
        return this.PricePaid * this.Quantity;
      }
    }

    /// <summary>
    /// Gets the total item tax.
    /// </summary>
    /// <value>The total item tax.</value>
    public decimal TotalItemTax {
      get {
        return this.ItemTax * this.Quantity;
      }
    }

    /// <summary>
    /// Gets the total item discount.
    /// </summary>
    /// <value>The total item discount.</value>
    public decimal TotalItemDiscount {
      get {
        return this.DiscountAmount * this.Quantity;
      }
    }

    /// <summary>
    /// Gets the item discounted price.
    /// </summary>
    /// <value>The item discounted price.</value>
    public decimal ItemDiscountedPrice {
      get {
        return this.PricePaid - this.DiscountAmount;
      }
    }

    /// <summary>
    /// Gets the extended properties.
    /// </summary>
    /// <value>The extended properties.</value>
    public ExtendedProperties ExtendedProperties {
      get {
        if(_extendedProperties == null) {
          if(!string.IsNullOrEmpty(this.AdditionalProperties)) {
            _extendedProperties = new ExtendedProperties().NewFromXml(this.AdditionalProperties) as ExtendedProperties;
          }
          else {
            _extendedProperties = new ExtendedProperties();
          }
        }
        return _extendedProperties;
      }
    }

    

    #endregion
	
  }
}
