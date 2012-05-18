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
using System.Collections.Specialized;
using System.Xml.Serialization;

using MettleSystems.dashCommerce.Core;

namespace MettleSystems.dashCommerce.Store.Services {

  [Serializable()]
  public class ProviderSettings : IXmlSerializable {
  
    #region Constants
    
    private const string NAME = "Name";
    private const string TYPE = "Type";
    
    #endregion
    
    #region Member Variables

    private string _name;
    private string _type;
    private NameValueCollection _parameters;
    
    #endregion
    
    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="T:ProviderSettings"/> class.
    /// </summary>
    public ProviderSettings() {
      _parameters = new NameValueCollection();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:ProviderSettings"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="type">The type.</param>
    public ProviderSettings(string name, string type) {
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(name, NAME);
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(type, TYPE);
      _parameters = new NameValueCollection();
      _name = name;
      _type = type;
    }
    
    #endregion
    
    #region Properties

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    [XmlAttribute]
    public string Name {
      get {
        return _name;
      }
      set {
        _name = value;
      }
    }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    /// <value>The type.</value>
    [XmlAttribute]
    public string Type {
      get {
        return _type;
      }
      set {
        _type = value;
      }
    }

    /// <summary>
    /// Gets or sets the parameters.
    /// </summary>
    /// <value>The parameters.</value>
    [XmlIgnore]
    public NameValueCollection Parameters {
      get {
        return _parameters;
      }
      set {
        _parameters = value;
      }
    }

    /// <summary>
    /// Gets the arguments.
    /// </summary>
    /// <value>The arguments.</value>
    public object[] Arguments {
      get {
        object[] args = new object[_parameters.Keys.Count];
        for (int i = 0; i < _parameters.Keys.Count; i++) {
          args[i] = _parameters[i];
        }
        return args;
      }
    }
    
    #endregion

    #region IXmlSerializable Members

    public System.Xml.Schema.XmlSchema GetSchema() {
     return null;
    }

    public void ReadXml(System.Xml.XmlReader reader) {
      _name = reader.GetAttribute(NAME);
      _type = reader.GetAttribute(TYPE);
      while (reader.MoveToNextAttribute())
        if(reader.Name != NAME && reader.Name != TYPE)
          _parameters.Add(reader.Name, reader.Value);
      reader.Read();
    }

    public void WriteXml(System.Xml.XmlWriter writer) {
      writer.WriteAttributeString(NAME, _name);
      writer.WriteAttributeString(TYPE, _type);
      foreach (string key in _parameters.Keys) {
        writer.WriteAttributeString(key, _parameters[key]);
      }
    }

    #endregion
    
  }
}
