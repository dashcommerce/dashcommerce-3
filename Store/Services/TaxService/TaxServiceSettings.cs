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

namespace MettleSystems.dashCommerce.Store.Services.TaxService {
  
  [Serializable()]
  public class TaxServiceSettings {
    
    #region Constants

    public const string SECTION_NAME = "taxServiceSettings";

    #endregion

    #region Member Variables

    private string _defaultProvider;
    private ProviderSettingsCollection _providerSettingsCollection;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="T:TaxServiceSettings"/> class.
    /// </summary>
    public TaxServiceSettings() {
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
