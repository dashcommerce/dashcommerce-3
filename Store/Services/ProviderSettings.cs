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
