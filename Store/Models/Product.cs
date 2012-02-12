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
using MettleSystems.dashCommerce.Core.Caching;
using MettleSystems.dashCommerce.Store.Services.TaxService;

namespace MettleSystems.dashCommerce.Store {
  public partial class Product {

    #region Member Variables

    private string _defaultImagePath = null;
    private decimal _displayPrice;
    private decimal _itemTax;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the rating.
    /// </summary>
    /// <value>The rating.</value>
    public int Rating {
      get {
        return this.RatingSum / this.TotalRatingVotes;
      }
    }

    /// <summary>
    /// Gets the default image path.
    /// </summary>
    /// <value>The default image path.</value>
    public string DefaultImagePath {
      get {
        if (_defaultImagePath == null) {
          ImageCollection imageCollection = this.ImageRecords();
          if (imageCollection.Count > 0) {
            imageCollection.Sort(Image.Columns.SortOrder, true);
            _defaultImagePath = imageCollection[0].ImageFile;
          }
          else {
            _defaultImagePath = string.Empty;
          }
        }

        return _defaultImagePath;
      }
    }

    /// <summary>
    /// Gets the you save amount.
    /// </summary>
    /// <value>The you save amount.</value>
    public decimal YouSaveAmount {
      get {
        return (this.RetailPrice - this.OurPrice);
      }
    }

    /// <summary>
    /// Gets the you save percentage.
    /// </summary>
    /// <value>The you save percentage.</value>
    public decimal YouSavePercentage {
      get {
        return ((this.RetailPrice - this.OurPrice) / this.RetailPrice);
      }
    }

    /// <summary>
    /// Gets the display price.
    /// </summary>
    /// <value>The display price.</value>
    public decimal DisplayPrice {
      get {
        _displayPrice = this.OurPrice + this.ItemTax;
        return _displayPrice;
      }
    }

    public decimal ItemTax {
      get {
        SiteSettings siteSettings = SiteSettingCache.GetSiteSettings();
        ITaxProvider taxProvider = TaxService.GetDefaultTaxProvider();
        if (siteSettings.AddTaxToPrice && taxProvider.IsProductLevelTaxProvider) {
          decimal taxRate = taxProvider.GetTaxRate(this);
          _itemTax = decimal.Round((this.OurPrice * taxRate), siteSettings.CurrencyDecimals); 
        }
        return _itemTax;
      }

    }

    #endregion

  }
}
