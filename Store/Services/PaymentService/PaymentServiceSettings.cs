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
using System.Xml.Serialization;

namespace MettleSystems.dashCommerce.Store.Services.PaymentService {

  [Serializable()]
  public class PaymentServiceSettings {

    #region Constants

    public const string SECTION_NAME = "paymentServiceSettings";

    #endregion

    #region Member Variables

    private string _defaultProvider;
    private ProviderSettingsCollection _providerSettingsCollection;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="T:PaymentServiceSettings"/> class.
    /// </summary>
    public PaymentServiceSettings() {
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
