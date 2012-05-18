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

namespace MettleSystems.dashCommerce.Store.Services.TaxService {

  public class TaxService {

    #region Constants

    private const string TAX_PROVIDER = "taxProvider";
    private const string PROVIDER_NAME = "providerName";
    private const string DEFAULT_TAX_PROVIDER = "defaultTaxProvider";
    private const string TAX_SERVICE_SETTINGS = "taxServiceSettings";

    #endregion

    #region Member Variables

    TaxProviderCollection _taxProviderCollection;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="T:TaxService"/> class.
    /// </summary>
    public TaxService() {
      _taxProviderCollection = new TaxProviderCollection();
      LoadProviders();
    }

    #endregion

    #region Methods

    #region Public

    /// <summary>
    /// Gets the tax rate.
    /// </summary>
    /// <param name="order">The order.</param>
    public void GetTaxRate(Order order) {
      if (_taxProviderCollection.Count > 0) {
        _taxProviderCollection[0].GetTaxRate(order);
      }
    }

    #region Static Methods

    /// <summary>
    /// Fetches the configured tax providers.
    /// </summary>
    /// <returns></returns>
    public static TaxServiceSettings FetchConfiguredTaxProviders() {
      TaxServiceSettings taxServiceSettings = FetchTaxServiceSettings();
      return taxServiceSettings;
    }

    /// <summary> 
    /// Sets the default tax provider.
    /// </summary>
    /// <param name="defaultTaxProvider">The default tax provider.</param>
    /// <returns></returns>
    public static int SetDefaultTaxProvider(string defaultTaxProvider, string userName) {
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(defaultTaxProvider, DEFAULT_TAX_PROVIDER);
      DatabaseConfigurationProvider databaseConfigurationProvider = new DatabaseConfigurationProvider();
      TaxServiceSettings taxServiceSettings =
        databaseConfigurationProvider.FetchConfigurationByName(TaxServiceSettings.SECTION_NAME) as TaxServiceSettings;
      taxServiceSettings.DefaultProvider = defaultTaxProvider;
      int id = databaseConfigurationProvider.SaveConfiguration(TaxServiceSettings.SECTION_NAME, taxServiceSettings, userName);
      return id;
    }

    /// <summary>
    /// Gets the default tax provider.
    /// </summary>
    /// <returns></returns>
    public static ITaxProvider GetDefaultTaxProvider() {
      DatabaseConfigurationProvider databaseConfigurationProvider = new DatabaseConfigurationProvider();
      TaxServiceSettings taxServiceSettings = databaseConfigurationProvider.FetchConfigurationByName(TaxServiceSettings.SECTION_NAME) as TaxServiceSettings;
      string defaultTaxProviderName = taxServiceSettings.DefaultProvider;
      if (String.IsNullOrEmpty(defaultTaxProviderName))
        return null;
      ProviderSettings ps = taxServiceSettings.ProviderSettingsCollection[defaultTaxProviderName];
      ITaxProvider taxProvider = Activator.CreateInstance(Type.GetType(ps.Type), ps.Arguments) as ITaxProvider;
      Validator.ValidateObjectIsNotNull(taxProvider, TAX_PROVIDER);
      return taxProvider;
    }


    /// <summary>
    /// Removes the tax provider.
    /// </summary>
    /// <param name="providerName">Name of the provider.</param>
    public static void RemoveTaxProvider(string providerName, string userName) {
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(providerName, PROVIDER_NAME);
      DatabaseConfigurationProvider databaseConfigurationProvider = new DatabaseConfigurationProvider();
      TaxServiceSettings taxServiceSettings =
        databaseConfigurationProvider.FetchConfigurationByName(TaxServiceSettings.SECTION_NAME) as TaxServiceSettings;
      if (providerName == taxServiceSettings.DefaultProvider) {
        throw new InvalidOperationException(Strings.ResourceManager.GetString("UnableToDeleteDefaultProvider"));
      }
      ProviderSettings providerSettings = taxServiceSettings.ProviderSettingsCollection.Find(delegate(ProviderSettings theProviderSettings) {
        return theProviderSettings.Name == providerName;
      });
      if (providerSettings != null) {
        taxServiceSettings.ProviderSettingsCollection.Remove(providerSettings);
        databaseConfigurationProvider.SaveConfiguration(TaxServiceSettings.SECTION_NAME, taxServiceSettings, userName);
      }
    }

    /// <summary>
    /// Saves the specified tax service settings.
    /// </summary>
    /// <param name="taxServiceSettings">The tax service settings.</param>
    /// <returns></returns>
    public static int Save(TaxServiceSettings taxServiceSettings, string userName) {
      Validator.ValidateObjectIsNotNull(taxServiceSettings, TAX_SERVICE_SETTINGS);
      Validator.ValidateObjectType(taxServiceSettings, typeof(TaxServiceSettings));
      //Set a default provider, regardless of whether or not the service uses one.
      if (taxServiceSettings.ProviderSettingsCollection.Count == 1) {
        taxServiceSettings.DefaultProvider = taxServiceSettings.ProviderSettingsCollection[0].Name;
      }
      DatabaseConfigurationProvider databaseConfigurationProvider = new DatabaseConfigurationProvider();
      int id = databaseConfigurationProvider.SaveConfiguration(TaxServiceSettings.SECTION_NAME, taxServiceSettings, userName);
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
      TaxServiceSettings taxServiceSettings =
        databaseConfigurationProvider.FetchConfigurationByName(TaxServiceSettings.SECTION_NAME) as TaxServiceSettings;
      ITaxProvider taxProvider = null;
      Type type = null;
      foreach (ProviderSettings providerSettings in taxServiceSettings.ProviderSettingsCollection) {
        //We only want to load the defaultProvider
        if (taxServiceSettings.DefaultProvider == providerSettings.Name) {
          type = Type.GetType(providerSettings.Type);
          taxProvider = Activator.CreateInstance(type, providerSettings.Arguments) as ITaxProvider;
          Validator.ValidateObjectIsNotNull(taxProvider, TAX_PROVIDER);
          _taxProviderCollection.Add(taxProvider);
        }
      }
    }

    /// <summary>
    /// Fetches the tax service settings.
    /// </summary>
    /// <returns></returns>
    private static TaxServiceSettings FetchTaxServiceSettings() {
      DatabaseConfigurationProvider _databaseConfigurationProvider = new DatabaseConfigurationProvider();
      TaxServiceSettings taxServiceSettings =
        _databaseConfigurationProvider.FetchConfigurationByName(TaxServiceSettings.SECTION_NAME) as TaxServiceSettings;
      return taxServiceSettings;
    }

    #endregion

    #endregion

  }
}
