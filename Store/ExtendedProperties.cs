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
using System.Collections;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using MettleSystems.dashCommerce.Core.Serialization;


namespace MettleSystems.dashCommerce.Store {
  public class ExtendedProperties : Hashtable, IXmlSerializable {

    #region Methods

    #region Public

    /// <summary>
    /// New from XML.
    /// </summary>
    /// <param name="xml">The XML.</param>
    /// <returns></returns>
    public object NewFromXml(string xml) {
      Serializer serializer = new Serializer();
      return serializer.DeserializeObject(xml, typeof(ExtendedProperties).AssemblyQualifiedName);
    }

    /// <summary>
    /// To XML.
    /// </summary>
    /// <returns></returns>
    public string ToXml() {
      Serializer serializer = new Serializer();
      return serializer.SerializeObject(this, typeof(ExtendedProperties));
    }

    # region IXmlSerializable

    /// <summary>
    /// This property is reserved, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute"></see> to the class instead.
    /// </summary>
    /// <returns>
    /// An <see cref="T:System.Xml.Schema.XmlSchema"></see> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"></see> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"></see> method.
    /// </returns>
    XmlSchema IXmlSerializable.GetSchema() {
      return null;
    }

    /// <summary>
    /// Generates an object from its XML representation.
    /// </summary>
    /// <param name="reader">The <see cref="T:System.Xml.XmlReader"></see> stream from which the object is deserialized.</param>
    void IXmlSerializable.ReadXml(XmlReader reader) {
      reader.Read();
      reader.ReadStartElement("dictionary");
      while (reader.NodeType != XmlNodeType.EndElement) {
        reader.ReadStartElement("item");
        string key = reader.ReadElementString("key");
        string value = reader.ReadElementString("value");
        reader.ReadEndElement();
        reader.MoveToContent();
        this.Add(key, value);
      }
      reader.ReadEndElement();
    }

    /// <summary>
    /// Converts an object into its XML representation.
    /// </summary>
    /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"></see> stream to which the object is serialized.</param>
    void IXmlSerializable.WriteXml(XmlWriter writer) {
      writer.WriteStartElement("dictionary");
      foreach (object key in this.Keys) {
        object value = this[key];
        writer.WriteStartElement("item");
        writer.WriteElementString("key", key.ToString());
        writer.WriteElementString("value", value.ToString());
        writer.WriteEndElement();
      }
      writer.WriteEndElement();
    }

    #endregion

    #endregion

    #endregion

  }
}
