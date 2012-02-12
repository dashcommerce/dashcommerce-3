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
