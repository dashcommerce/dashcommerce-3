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

using MettleSystems.dashCommerce.Core.Serialization;

namespace MettleSystems.dashCommerce.Core.Configuration {

  public class DatabaseConfigurationProvider {
  
    #region Constants
    
    private const string CONFIGURATION_SECTION_NAME = "configurationSectionName";
    private const string NAME = "name";
    private const string OBJ = "obj";
    private const string USERNAME = "userName";
    
    #endregion

    #region Methods
    
    #region Public
    
    /// <summary>
    /// Fetches the configuration by id.
    /// </summary>
    /// <param name="configurationDataId">The configuration data id.</param>
    /// <returns></returns>
    public virtual ConfigurationDatum FetchConfigurationById(int configurationDataId) {
      Validator.ValidateIntegerIsGreaterThanZero(configurationDataId,
        ConfigurationContants.ARGUMENT_CONFIGURATION_DATA_ID);

      ConfigurationDatumCollection configurationDatumCollection = 
        new ConfigurationDatumController().FetchByID(configurationDataId);

      ConfigurationDatum configurationDatum = null;
      if (configurationDatumCollection.Count == 1) {
        configurationDatum = configurationDatumCollection[0];
      }
      return configurationDatum;
    }

    /// <summary>
    /// Fetches the configuration by name.
    /// </summary>
    /// <param name="configurationSectionName">Name of the configuration section.</param>
    /// <returns></returns>
    public virtual object FetchConfigurationByName(string configurationSectionName) {
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(configurationSectionName, CONFIGURATION_SECTION_NAME);

      ConfigurationDatum configurationDatum =
        new ConfigurationDatumController().FetchConfigurationByName(configurationSectionName);
      
      object obj = null;

      if (configurationDatum != null) {
        Serializer serializer = new Serializer();
        obj = serializer.DeserializeObject(configurationDatum.ValueX, configurationDatum.Type);
      }
      return obj;
    }

    /// <summary>
    /// Saves the configuration.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="obj">The obj.</param>
    /// <param name="userName">Name of the user.</param>
    /// <returns></returns>
    public virtual int SaveConfiguration(string name, object obj, string userName) {
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(name, NAME);
      Validator.ValidateArgumentIsSerializable(obj, OBJ);
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(userName, USERNAME);
      
      Serializer serializer = new Serializer();
      string xml = serializer.SerializeObject(obj, obj.GetType());

      ConfigurationDatum configurationDatum = new ConfigurationDatum(ConfigurationDatum.Columns.Name, name);
      configurationDatum.Name = name;
      configurationDatum.Type = obj.GetType().AssemblyQualifiedName;
      configurationDatum.ValueX = xml.Trim();
      if (configurationDatum.ConfigurationDataId == 0) {
        configurationDatum.CreatedDate = DateTime.UtcNow;
      }
      else {
        configurationDatum.ModifiedDate = DateTime.UtcNow;
      }
      configurationDatum.Save(userName);
      return configurationDatum.ConfigurationDataId;    
    }
    
    #endregion
    
    #endregion

  }
}
