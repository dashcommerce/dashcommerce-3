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
using System.Xml.Serialization;

namespace MettleSystems.dashCommerce.Store.Services.ShippingService {

  [Serializable()]
  public class ShippingServiceSettings {

    #region Constants

    public const string SECTION_NAME = "shippingServiceSettings";

    #endregion

    #region Member Variables

    private string _defaultProvider;
    private bool _useShipping;
    private string _shipFromZip = string.Empty;
    private string _shipFromCountryCode = string.Empty;
    private decimal _shippingBuffer;
    private ProviderSettingsCollection _providerSettingsCollection;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="T:ShippingServiceSettings"/> class.
    /// </summary>
    public ShippingServiceSettings() {
      _providerSettingsCollection = new ProviderSettingsCollection();
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the default provider.
    /// </summary>
    /// <value>The default provider.</value>
    [XmlAttribute()]
    public string DefaultProvider {
      get {
        return _defaultProvider;
      }
      set {
        _defaultProvider = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [use shipping].
    /// </summary>
    /// <value><c>true</c> if [use shipping]; otherwise, <c>false</c>.</value>
    [XmlAttribute()]
    public bool UseShipping {
      get {
        return _useShipping;
      }
      set {
        _useShipping = value;
      }
    }

    /// <summary>
    /// Gets or sets the ship from zip.
    /// </summary>
    /// <value>The ship from zip.</value>
    [XmlAttribute()]
    public string ShipFromZip {
      get {
        return _shipFromZip;
      }
      set {
        _shipFromZip = value;
      }
    }

    /// <summary>
    /// Gets or sets the ship from country code.
    /// </summary>
    /// <value>The ship from country code.</value>
    [XmlAttribute()]
    public string ShipFromCountryCode {
      get {
        return _shipFromCountryCode;
      }
      set {
        _shipFromCountryCode = value;
      }
    }

    /// <summary>
    /// Gets or sets the shipping buffer.
    /// </summary>
    /// <value>The shipping buffer.</value>
    [XmlAttribute()]
    public decimal ShippingBuffer {
      get {
        return _shippingBuffer;
      }
      set {
        _shippingBuffer = value;
      }
    }
	
    /// <summary>
    /// Gets or sets the provider settings collection.
    /// </summary>
    /// <value>The provider settings collection.</value>
    public ProviderSettingsCollection ProviderSettingsCollection {
      get {
        return _providerSettingsCollection;
      }
      set {
        _providerSettingsCollection = value;
      }
    }

    #endregion

  }
}
