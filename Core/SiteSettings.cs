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
using System.Xml.Serialization;
using MettleSystems.dashCommerce.Core.ApplicationSettings;
using MettleSystems.dashCommerce.Core.Configuration;

namespace MettleSystems.dashCommerce.Store {

  public enum LoginRequirement {
    Checkout,
    Add_To_Cart,
    Never
  }

  [Serializable()]
  public class SiteSettings {

    #region Constants

    public const string SECTION_NAME = "siteSettings";

    #endregion

    #region Member Variables

    private string _language;
    private string _currency;
    private string _theme;
    private string _analytics;
    private string _siteName;
    private bool _displayRetailPrice;
    private bool _displayNarrowByManufacturer;
    private bool _displayNarrowByPrice;
    private bool _displaySortBy;
    private bool _requireSsl = true;
    private string _tagLine;
    CultureInfo _cultureInfo;
    private bool _collectBrowsingCategory;
    private bool _collectBrowsingProduct;
    private int _catalogItems = 6;
    private string _siteLogo;
    private LoginRequirement _loginRequirement;
    private bool _collectSearchTerms = true;
    private string _newsFeedUrl;
    private bool _useCaching = false;
    private int _shortCacheSeconds = 120;  //2 minutes
    private int _normalCacheSeconds = 300; //5 minutes
    private int _longCacheSeconds = 1500;  // 25 minutes
    private bool _generateThumbs = true;
    private int _thumbSmallWidth = 150;
    private int _thumbSmallHeight = 150;
    private int _MaxProductsAddToCart = 20; // Dropdown
    private SeoSettings _seoSettings = new SeoSettings();
    private int _defaultCatalogSort;
    private bool _displayRatings = true;
    private bool _displayShippingOnCart = false;
    private bool _displayNarrowCategory = true;
    private bool _addTaxToPrice = false;

    #endregion

    #region Methods

    #region Public

    /// <summary>
    /// Loads this instance.
    /// </summary>
    /// <returns></returns>
    public static SiteSettings Load() {
      try {
        DatabaseConfigurationProvider databaseConfigurationProvider = new DatabaseConfigurationProvider();
        SiteSettings siteSettings = databaseConfigurationProvider.FetchConfigurationByName(SiteSettings.SECTION_NAME) as SiteSettings;
        return siteSettings;
      }
      catch(Exception ex) {
        throw new Exception("Please make sure that you setup the Database, and the Connection String in the connectionString.config file.");
      }
    }

    #endregion

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets a value indicating whether the app is offline.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if the app is offline; otherwise, <c>false</c>.
    /// </value>
    public bool IsStoreClosed {
      get; set;
    }

    /// <summary>
    /// Gets or sets the site logo.
    /// </summary>
    /// <value>The site logo.</value>
    public string SiteLogo {
      get {
        return _siteLogo;
      }
      set {
        _siteLogo = value;
      }
    }

    /// <summary>
    /// Gets or sets the name of the site.
    /// </summary>
    /// <value>The name of the site.</value>
    public string SiteName {
      get {
        return _siteName;
      }
      set {
        _siteName = value;
      }
    }

    /// <summary>
    /// Gets or sets the tag line.
    /// </summary>
    /// <value>The tag line.</value>
    public string TagLine {
      get {
        return _tagLine;
      }
      set {
        _tagLine = value;
      }
    }

    /// <summary>
    /// Gets or sets the login requirement.
    /// </summary>
    /// <value>The login requirement.</value>
    public LoginRequirement LoginRequirement {
      get {
        return _loginRequirement;
      }
      set {
        _loginRequirement = value;
      }
    }

    /// <summary>
    /// Gets or sets the news feed URL.
    /// </summary>
    /// <value>The news feed URL.</value>
    public string NewsFeedUrl {
      get {
        return _newsFeedUrl;
      }
      set {
        _newsFeedUrl = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [require SSL].
    /// </summary>
    /// <value><c>true</c> if [require SSL]; otherwise, <c>false</c>.</value>
    public bool RequireSsl {
      get {
        return _requireSsl;
      }
      set {
        _requireSsl = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [collect browsing category].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [collect browsing category]; otherwise, <c>false</c>.
    /// </value>
    public bool CollectBrowsingCategory {
      get {
        return _collectBrowsingCategory;
      }
      set {
        _collectBrowsingCategory = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [collect browsing product].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [collect browsing product]; otherwise, <c>false</c>.
    /// </value>
    public bool CollectBrowsingProduct {
      get {
        return _collectBrowsingProduct;
      }
      set {
        _collectBrowsingProduct = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [collect search terms].
    /// </summary>
    /// <value><c>true</c> if [collect search terms]; otherwise, <c>false</c>.</value>
    public bool CollectSearchTerms {
      get {
        return _collectSearchTerms;
      }
      set {
        _collectSearchTerms = value;
      }
    }

    /// <summary>
    /// Gets or sets the catalog items.
    /// </summary>
    /// <value>The catalog items.</value>
    public int CatalogItems {
      get {
        return _catalogItems;
      }
      set {
        _catalogItems = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [display retail price].
    /// </summary>
    /// <value><c>true</c> if [display retail price]; otherwise, <c>false</c>.</value>
    public bool DisplayRetailPrice {
      get {
        return _displayRetailPrice;
      }
      set {
        _displayRetailPrice = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [display narrow by manufacturer].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [display narrow by manufacturer]; otherwise, <c>false</c>.
    /// </value>
    public bool DisplayNarrowByManufacturer {
      get {
        return _displayNarrowByManufacturer;
      }
      set {
        _displayNarrowByManufacturer = value;
      }
    }

    /// <summary>
    /// Gets or sets weather sorting panel should display
    /// </summary>
    public bool DisplaySortBy {
      get {
        return _displaySortBy;
      }
      set {
        _displaySortBy = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [display narrow by price].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [display narrow by price]; otherwise, <c>false</c>.
    /// </value>
    public bool DisplayNarrowByPrice {
      get {
        return _displayNarrowByPrice;
      }
      set {
        _displayNarrowByPrice = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [display narrow by category].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [display narrow by category]; otherwise, <c>false</c>.
    /// </value>
    public bool DisplayNarrowCategory {
      get { 
        return _displayNarrowCategory; 
      }
      set { 
        _displayNarrowCategory = value; 
      }
    }

    /// <summary>
    /// Gets or sets the language.
    /// </summary>
    /// <value>The language.</value>
    public string Language {
      get {
        return _language;
      }
      set {
        _language = value;
      }
    }

    /// <summary>
    /// Gets or sets the currency code.
    /// </summary>
    /// <value>The currency code.</value>
    public string CurrencyCode {
      get {
        return _currency;
      }
      set {
        _currency = value;
      }
    }

    /// <summary>
    /// Gets or sets the theme.
    /// </summary>
    /// <value>The theme.</value>
    public string Theme {
      get {
        return _theme;
      }
      set {
        _theme = value;
      }
    }

    /// <summary>
    /// Gets or sets the analytics.
    /// </summary>
    /// <value>The analytics.</value>
    public string Analytics {
      get {
        return _analytics;
      }
      set {
        _analytics = value;
      }
    }

    /// <summary>
    /// Gets the currency symbol.
    /// </summary>
    /// <value>The currency symbol.</value>
    [XmlIgnore]
    public string CurrencySymbol {
      get {
        if (_cultureInfo == null) {
          _cultureInfo = new CultureInfo(this.Language);
        }
        return _cultureInfo.NumberFormat.CurrencySymbol;
      }
    }

    /// <summary>
    /// Gets the currency decimals.
    /// </summary>
    /// <value>The currency decimals.</value>
    [XmlIgnore]
    public int CurrencyDecimals {
      get {
        if (_cultureInfo == null) {
          _cultureInfo = new CultureInfo(this.Language);
        }
        return _cultureInfo.NumberFormat.CurrencyDecimalDigits;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the site should use caching.
    /// </summary>
    /// <value><c>true</c> if [use caching]; otherwise, <c>false</c>.</value>
    public bool UseCaching {
      get {
        return _useCaching;
      }
      set {
        _useCaching = value;
      }
    }

    /// <summary>
    /// Gets or sets the short cache seconds.
    /// </summary>
    /// <value>The short cache seconds.</value>
    public int ShortCacheSeconds {
      get {
        return _shortCacheSeconds;
      }
      set {
        _shortCacheSeconds = value;
      }
    }

    /// <summary>
    /// Gets or sets the normal cache seconds.
    /// </summary>
    /// <value>The normal cache seconds.</value>
    public int NormalCacheSeconds {
      get {
        return _normalCacheSeconds;
      }
      set {
        _normalCacheSeconds = value;
      }
    }

    /// <summary>
    /// Gets or sets the long cache seconds.
    /// </summary>
    /// <value>The long cache seconds.</value>
    public int LongCacheSeconds {
      get {
        return _longCacheSeconds;
      }
      set {
        _longCacheSeconds = value;
      }
    }

    /// <summary>
    /// Gets or sets the value if the imagehandler should generate tumbs.
    /// </summary>
    /// <value><c>true</c> if [generate thumbs]; otherwise, <c>false</c>.</value>
    public bool GenerateThumbs {
      get {
        return _generateThumbs;
      }
      set {
        _generateThumbs = value;
      }
    }

    /// <summary>
    /// Gets or sets the width of the small thumbs.
    /// </summary>
    /// <value>The width of the thumb small.</value>
    public int ThumbSmallWidth {
      get {
        return _thumbSmallWidth;
      }
      set {
        _thumbSmallWidth = value;
      }
    }

    /// <summary>
    /// Gets or sets the height of the small thumbs.
    /// </summary>
    /// <value>The height of the thumb small.</value>
    public int ThumbSmallHeight {
      get {
        return _thumbSmallHeight;
      }
      set {
        _thumbSmallHeight = value;
      }
    }

    /// <summary>
    /// Gets or sets the Maximum Products to add to the Shopping Cart (int).
    /// </summary>
    /// <value>The max products add to cart.</value>
    public int MaxProductsAddToCart {
      get {
        return _MaxProductsAddToCart;
      }
      set {
        _MaxProductsAddToCart = value;
      }
    }

    /// <summary>
    /// Gets or sets the seo setting.
    /// </summary>
    /// <value>The seo settings.</value>
    public SeoSettings SeoSetting {
      get {
        return _seoSettings;
      }
      set {
        _seoSettings = value;
      }
    }

    /// <summary>
    /// Gets or sets the default site sorting
    /// </summary>
    /// <value>The sort comparison.</value>
    public int DefaultCatalogSort {
      get {
        return _defaultCatalogSort;
      }
      set {
        _defaultCatalogSort = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [display ratings].
    /// </summary>
    /// <value><c>true</c> if [display ratings]; otherwise, <c>false</c>.</value>
    public bool DisplayRatings {
      get {
        return _displayRatings;
      }
      set {
          _displayRatings = value;
      }
    }

    /// <summary>
    /// Gets or sets a value weather it should display shipping rates on cart page.
    /// </summary>
    /// <value><c>true</c> if [display shipping rates]; otherwise, <c>false</c>.</value>
    public bool DisplayShippingOnCart {
      get { 
        return _displayShippingOnCart; 
      }
      set { 
        _displayShippingOnCart = value; 
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [add tax to price].
    /// </summary>
    /// <value><c>true</c> if [add tax to price]; otherwise, <c>false</c>.</value>
    public bool AddTaxToPrice {
      get { return _addTaxToPrice; }
      set { _addTaxToPrice = value; }
    }

    #endregion
  }
}