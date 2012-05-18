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

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Core.Configuration;

namespace MettleSystems.dashCommerce.Store.Services.ShippingService {
  
  public class ShippingService {

    #region Constants

    private const string SHIPPING_PROVIDER = "shippingProvider";
    private const string PROVIDER_NAME = "providerName";
    private const string DEFAULT_SHIPPING_PROVIDER = "defaultShippingProvider";
    private const string SHIPPING_SERVICE_SETTINGS = "shippingServiceSettings";

    #endregion

    #region Member Variables

    ShippingProviderCollection _shippingProviderCollection;
    private ShippingServiceSettings _shippingServiceSettings;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="T:ShippingService"/> class.
    /// </summary>
    public ShippingService() {
      _shippingServiceSettings = ShippingService.FetchShippingServiceSettings();
      _shippingProviderCollection = new ShippingProviderCollection();
      LoadProviders();
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the shipping service settings.
    /// </summary>
    /// <value>The shipping service settings.</value>
    public ShippingServiceSettings ShippingServiceSettings {
      get {
        if(_shippingServiceSettings == null) {
          _shippingServiceSettings = ShippingService.FetchShippingServiceSettings();
        }
        return _shippingServiceSettings;
      }
    }

    #endregion

    #region Methods

    #region Public

    /// <summary>
    /// Gets the shipping options.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <returns></returns>
    public ShippingOptionCollection GetShippingOptions(Order order) {
      ShippingOptionCollection shippingOptionCollection = new ShippingOptionCollection();
      ShippingOptionCollection serviceOptionCollection;
      foreach(IShippingProvider shippingProvider in _shippingProviderCollection) {
        serviceOptionCollection = shippingProvider.GetShippingOptions(order);
        if(this.ShippingServiceSettings.ShippingBuffer > 0) {
          foreach(ShippingOption shippingOption in serviceOptionCollection) {
            shippingOption.Rate = shippingOption.Rate + this.ShippingServiceSettings.ShippingBuffer;
          }
        }
        shippingOptionCollection.Add(serviceOptionCollection);
      }
      return shippingOptionCollection;
    }

    #region Static Methods

    /// <summary>
    /// Fetches the configured shipping providers.
    /// </summary>
    /// <returns></returns>
    public static ShippingServiceSettings FetchConfiguredShippingProviders() {
      ShippingServiceSettings shippingServiceSettings = FetchShippingServiceSettings();
      return shippingServiceSettings;
    }

    /// <summary>
    /// Sets the default shipping provider.
    /// </summary>
    /// <param name="defaultTaxProvider">The default tax provider.</param>
    /// <returns></returns>
    public static int SetDefaultShippingProvider(string defaultShippingProvider, string userName) {
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(defaultShippingProvider, DEFAULT_SHIPPING_PROVIDER);
      DatabaseConfigurationProvider databaseConfigurationProvider = new DatabaseConfigurationProvider();
      ShippingServiceSettings shippingServiceSettings =
        databaseConfigurationProvider.FetchConfigurationByName(ShippingServiceSettings.SECTION_NAME) as ShippingServiceSettings;
      shippingServiceSettings.DefaultProvider = defaultShippingProvider;
      int id = databaseConfigurationProvider.SaveConfiguration(ShippingServiceSettings.SECTION_NAME, shippingServiceSettings, userName);
      return id;
    }

    /// <summary>
    /// Removes the shipping provider.
    /// </summary>
    /// <param name="providerName">Name of the provider.</param>
    public static void RemoveShippingProvider(string providerName, string userName) {
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(providerName, PROVIDER_NAME);
      DatabaseConfigurationProvider databaseConfigurationProvider = new DatabaseConfigurationProvider();
      ShippingServiceSettings shippingServiceSettings =
        databaseConfigurationProvider.FetchConfigurationByName(ShippingServiceSettings.SECTION_NAME) as ShippingServiceSettings;
      if(providerName == shippingServiceSettings.DefaultProvider) {
        throw new InvalidOperationException(Strings.ResourceManager.GetString("UnableToDeleteDefaultProvider"));
      }
      ProviderSettings providerSettings = shippingServiceSettings.ProviderSettingsCollection.Find(delegate(ProviderSettings theProviderSettings) {return theProviderSettings.Name == providerName;});
      if(providerSettings != null) {
        shippingServiceSettings.ProviderSettingsCollection.Remove(providerSettings);
        databaseConfigurationProvider.SaveConfiguration(ShippingServiceSettings.SECTION_NAME, shippingServiceSettings, userName);
      }
    }

    /// <summary>
    /// Saves the specified shipping service settings.
    /// </summary>
    /// <param name="shippingServiceSettings">The shipping service settings.</param>
    /// <returns></returns>
    public static int Save(ShippingServiceSettings shippingServiceSettings, string userName) {
      Validator.ValidateObjectIsNotNull(shippingServiceSettings, SHIPPING_SERVICE_SETTINGS);
      Validator.ValidateObjectType(shippingServiceSettings, typeof(ShippingServiceSettings));
      //Set a default provider, regardless of whether or not the service uses one.
      if(shippingServiceSettings.ProviderSettingsCollection.Count == 1) {
        shippingServiceSettings.DefaultProvider = shippingServiceSettings.ProviderSettingsCollection[0].Name;
      }
      DatabaseConfigurationProvider databaseConfigurationProvider = new DatabaseConfigurationProvider();
      int id = databaseConfigurationProvider.SaveConfiguration(ShippingServiceSettings.SECTION_NAME, shippingServiceSettings, userName);
      return id;
    }

    #endregion

    #endregion

    #region Private

    /// <summary>
    /// Loads the providers.
    /// </summary>
    private void LoadProviders() {
      DatabaseConfigurationProvider databaseConfigurationProvider = new DatabaseConfigurationProvider();
      ShippingServiceSettings shippingServiceSettings = 
        databaseConfigurationProvider.FetchConfigurationByName(ShippingServiceSettings.SECTION_NAME) as ShippingServiceSettings;
      IShippingProvider shippingProvider = null;
      Type type = null;
      foreach (ProviderSettings providerSettings in shippingServiceSettings.ProviderSettingsCollection) {
        type = Type.GetType(providerSettings.Type);
        shippingProvider = Activator.CreateInstance(type, providerSettings.Arguments) as IShippingProvider;
        Validator.ValidateObjectIsNotNull(shippingProvider, SHIPPING_PROVIDER);
        _shippingProviderCollection.Add(shippingProvider);
      }
    }

    /// <summary>
    /// Fetches the shipping service settings.
    /// </summary>
    /// <returns></returns>
    private static ShippingServiceSettings FetchShippingServiceSettings() {
      DatabaseConfigurationProvider _databaseConfigurationProvider = new DatabaseConfigurationProvider();
      ShippingServiceSettings shippingServiceSettings =
        _databaseConfigurationProvider.FetchConfigurationByName(ShippingServiceSettings.SECTION_NAME) as ShippingServiceSettings;
      return shippingServiceSettings;
    }


    #endregion

    #endregion
    
  }
}
