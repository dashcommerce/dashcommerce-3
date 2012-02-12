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
