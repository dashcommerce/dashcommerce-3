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
