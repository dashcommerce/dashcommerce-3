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
