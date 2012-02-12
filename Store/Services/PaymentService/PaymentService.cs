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

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Core.Configuration;

namespace MettleSystems.dashCommerce.Store.Services.PaymentService {
  
  public class PaymentService {

    #region Constants

    private const string PAYMENT_PROVIDER = "paymentProvider";
    private const string PROVIDER_NAME = "providerName";
    private const string DEFAULT_PAYMENT_PROVIDER = "defaultPaymentProvider";
    private const string PAYMENT_SERVICE_SETTINGS = "paymentServiceSettings";

    #endregion

    #region Member Variables

    private PaymentProviderCollection _paymentProviderCollection;
    private PaymentServiceSettings _paymentServiceSettings;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="T:PaymentService"/> class.
    /// </summary>
    public PaymentService() {
      _paymentProviderCollection = new PaymentProviderCollection();
      LoadProviders();
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the payment service settings.
    /// </summary>
    /// <value>The payment service settings.</value>
    public PaymentServiceSettings PaymentServiceSettings {
      get {
        if(_paymentServiceSettings == null) {
          _paymentServiceSettings = PaymentService.FetchPaymentServiceSettings();
        }
        return _paymentServiceSettings;
      }
    }

    #endregion

    #region Methods

    #region Public

    #region Generic Gateway Methods

    /// <summary>
    /// Authorizes the specified order.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <returns></returns>
    public Transaction Authorize(Order order) {
      Transaction transaction = null;
      if(_paymentProviderCollection.Count > 0) {
        transaction = _paymentProviderCollection.Find(provider => provider.GetType().Name.Contains(PaymentServiceSettings.DefaultProvider)).Authorize(order);
      }
      return transaction;
    }

    /// <summary>
    /// Charges the specified order.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <returns></returns>
    public Transaction Charge(Order order) {
      Transaction transaction = null;
      if(_paymentProviderCollection.Count > 0) {
        transaction = _paymentProviderCollection.Find(provider => provider.GetType().Name.Contains(PaymentServiceSettings.DefaultProvider)).Charge(order);
      }
      return transaction;
    }

    /// <summary>
    /// Refunds the specified transaction.
    /// </summary>
    /// <param name="transaction">The transaction.</param>
    /// <returns></returns>
    public Transaction Refund(Transaction transaction, Order order) {
      Transaction refundTransaction = null;
      if(_paymentProviderCollection.Count > 0) {
        refundTransaction = _paymentProviderCollection.Find(provider => provider.GetType().Name.Contains(PaymentServiceSettings.DefaultProvider)).Refund(transaction, order);
      }
      return refundTransaction;
    }

    #endregion

    #region PayPal Standard

    /// <summary>
    /// Creates the cart URL.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <returns></returns>
    public string CreateCartUrl(Order order, string returnUrl, string cancelUrl, string notifyUrl) {
      string url = string.Empty;
      if(_paymentProviderCollection.Count > 0) {
        IPayPalPaymentProvider _provider = _paymentProviderCollection.Find(provider => provider.GetType().Name.Contains("PayPalStandardPaymentProvider")) as IPayPalPaymentProvider;
        url = _provider.CreateCartUrl(order, returnUrl, cancelUrl, notifyUrl);
      }
      return url;
    }

    /// <summary>
    /// Synchronizes the specified args.
    /// </summary>
    /// <param name="args">The args.</param>
    /// <returns></returns>
    public string Synchronize(string content) {
      string response = string.Empty;
      if(_paymentProviderCollection.Count > 0) {
        IPayPalPaymentProvider _provider = _paymentProviderCollection.Find(provider => provider.GetType().Name.Contains("PayPalStandardPaymentProvider")) as IPayPalPaymentProvider;
        response = _provider.Synchronize(content);
      }
      return response;
    }

    #endregion

    #region PayPal Express

    /// <summary>
    /// Sets the express checkout.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <param name="returnUrl">The return URL.</param>
    /// <param name="cancelUrl">The cancel URL.</param>
    /// <param name="authorizeOnly">if set to <c>true</c> [authorize only].</param>
    /// <returns></returns>
    public string SetExpressCheckout(Order order, string returnUrl, string cancelUrl, bool authorizeOnly) {
      string url = string.Empty;
      if(_paymentProviderCollection.Count > 0) {
        IPayPalPaymentProvider _provider = _paymentProviderCollection.Find(provider => provider.GetType().Name.Contains("PayPalProPaymentProvider")) as IPayPalPaymentProvider;
        url = _provider.SetExpressCheckout(order, returnUrl, cancelUrl, authorizeOnly);

      }
      return url;
    }

    /// <summary>
    /// Gets the express checkout details.
    /// </summary>
    /// <param name="token">The token.</param>
    /// <returns></returns>
    public PayPalPayer GetExpressCheckoutDetails(string token) {
      PayPalPayer payPalPayer = null;
      if(_paymentProviderCollection.Count > 0) {
        IPayPalPaymentProvider _provider = _paymentProviderCollection.Find(provider => provider.GetType().Name.Contains("PayPalProPaymentProvider")) as IPayPalPaymentProvider;
        payPalPayer = _provider.GetExpressCheckoutDetails(token);

      }
      return payPalPayer;
    }

    /// <summary>
    /// Does the express checkout.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <param name="authorizeOnly">if set to <c>true</c> [authorize only].</param>
    /// <returns></returns>
    public Transaction DoExpressCheckout(Order order, bool authorizeOnly) {
      Transaction transaction = null;
      if(_paymentProviderCollection.Count > 0) {
        IPayPalPaymentProvider _provider = _paymentProviderCollection.Find(provider => provider.GetType().Name.Contains("PayPalProPaymentProvider")) as IPayPalPaymentProvider;
        transaction = _provider.DoExpressCheckout(order, authorizeOnly);

      }
      return transaction;
    }

    #endregion

    #region Static Methods

    /// <summary>
    /// Fetches the configured payment providers.
    /// </summary>
    /// <returns></returns>
    public static PaymentServiceSettings FetchConfiguredPaymentProviders() {
      PaymentServiceSettings paymentServiceSettings = FetchPaymentServiceSettings();
      return paymentServiceSettings;
    }

    /// <summary>
    /// Sets the default payment provider.
    /// </summary>
    /// <param name="defaultPaymentProvider">The default payment provider.</param>
    /// <returns></returns>
    public static int SetDefaultPaymentProvider(string defaultPaymentProvider, string userName) {
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(defaultPaymentProvider, DEFAULT_PAYMENT_PROVIDER);
      DatabaseConfigurationProvider _databaseConfigurationProvider = new DatabaseConfigurationProvider();
      PaymentServiceSettings paymentServiceSettings =
      _databaseConfigurationProvider.FetchConfigurationByName(PaymentServiceSettings.SECTION_NAME) as PaymentServiceSettings;
      paymentServiceSettings.DefaultProvider = defaultPaymentProvider;
      int id = _databaseConfigurationProvider.SaveConfiguration(PaymentServiceSettings.SECTION_NAME, paymentServiceSettings, userName);
      return id;
    }

    /// <summary>
    /// Removes the payment provider.
    /// </summary>
    /// <param name="providerName">Name of the provider.</param>
    public static void RemovePaymentProvider(string providerName, string userName) {
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(providerName, PROVIDER_NAME);
      DatabaseConfigurationProvider _databaseConfigurationProvider = new DatabaseConfigurationProvider();
      PaymentServiceSettings paymentServiceSettings =
        _databaseConfigurationProvider.FetchConfigurationByName(PaymentServiceSettings.SECTION_NAME) as PaymentServiceSettings;
      if (providerName == paymentServiceSettings.DefaultProvider) {
        throw new InvalidOperationException(Strings.ResourceManager.GetString("UnableToDeleteDefaultProvider"));
      }
      ProviderSettings providerSettings = paymentServiceSettings.ProviderSettingsCollection.Find(delegate(ProviderSettings theProviderSettings) {return theProviderSettings.Name == providerName;});
      if (providerSettings != null) {
        paymentServiceSettings.ProviderSettingsCollection.Remove(providerSettings);
        _databaseConfigurationProvider.SaveConfiguration(PaymentServiceSettings.SECTION_NAME, paymentServiceSettings, userName);
      }
    }

    /// <summary>
    /// Saves the specified payment service settings.
    /// </summary>
    /// <param name="paymentServiceSettings">The payment service settings.</param>
    /// <returns></returns>
    public static int Save(PaymentServiceSettings paymentServiceSettings, string userName) {
      Validator.ValidateObjectIsNotNull(paymentServiceSettings, PAYMENT_SERVICE_SETTINGS);
      Validator.ValidateObjectType(paymentServiceSettings, typeof(PaymentServiceSettings));
      //Set a default provider, regardless of whether or not the service uses one.
      if(paymentServiceSettings.ProviderSettingsCollection.Count == 1) {
        paymentServiceSettings.DefaultProvider = paymentServiceSettings.ProviderSettingsCollection[0].Name;
      }
      DatabaseConfigurationProvider databaseConfigurationProvider = new DatabaseConfigurationProvider();
      int id = databaseConfigurationProvider.SaveConfiguration(PaymentServiceSettings.SECTION_NAME, paymentServiceSettings, userName);
      return id;      
    }

    #endregion

    #endregion

    #region Private

    /// <summary>
    /// Loads the providers.
    /// </summary>
    private void LoadProviders() {
      PaymentServiceSettings paymentServiceSettings = FetchPaymentServiceSettings();
      IPaymentProvider paymentProvider = null;
      Type type = null;
      foreach (ProviderSettings providerSettings in paymentServiceSettings.ProviderSettingsCollection) {
        //We only want to load the defaultProvider
        //if(paymentServiceSettings.DefaultProvider == providerSettings.Name) {
          type = Type.GetType(providerSettings.Type);
          paymentProvider = Activator.CreateInstance(type, providerSettings.Arguments) as IPaymentProvider;
          Validator.ValidateObjectIsNotNull(paymentProvider, PAYMENT_PROVIDER);
          _paymentProviderCollection.Add(paymentProvider);
        //}
      }
    }

    /// <summary>
    /// Fetches the payment service settings.
    /// </summary>
    /// <returns></returns>
    private static PaymentServiceSettings FetchPaymentServiceSettings() {
      DatabaseConfigurationProvider _databaseConfigurationProvider = new DatabaseConfigurationProvider();
      PaymentServiceSettings paymentServiceSettings = 
        _databaseConfigurationProvider.FetchConfigurationByName(PaymentServiceSettings.SECTION_NAME) as PaymentServiceSettings;
      return paymentServiceSettings;    
    }

 
    #endregion

    #endregion

  }
}
