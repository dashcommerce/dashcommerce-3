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
using System.IO;
using System.Xml.Serialization;

namespace MettleSystems.dashCommerce.Core.Serialization {
  
  public class Serializer {
  
    #region Methods
  
    #region Public

    /// <summary>
    /// Serializes the object.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <param name="type">The type.</param>
    /// <returns></returns>
    public string SerializeObject(object obj, Type type) {
      string xml = string.Empty;
      XmlSerializer xs = new XmlSerializer(type);
      using(MemoryStream memoryStream = new MemoryStream()) {
        xs.Serialize(memoryStream, obj, null);
        memoryStream.Position = 0;
        using(StreamReader streamReader = new StreamReader(memoryStream)) {
          xml = streamReader.ReadToEnd();
        }
      }
      return xml;
    }

    /// <summary>
    /// Deserializes the object.
    /// </summary>
    /// <param name="xml">The XML.</param>
    /// <param name="typeName">Name of the type.</param>
    /// <returns></returns>
    public object DeserializeObject(string xml, string typeName) {
      object obj = null;
      XmlSerializer xs = new XmlSerializer(Type.GetType(typeName));
      StringReader stringReader = new StringReader(xml);
      obj = xs.Deserialize(stringReader);
      stringReader.Close();
      return obj;
    }
    
    #endregion
    
    #endregion

  }
}
