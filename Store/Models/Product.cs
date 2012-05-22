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
