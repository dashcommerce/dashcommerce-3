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



namespace MettleSystems.dashCommerce.Store {

  public partial class AttributeCollection {
    
    #region Methods
    
    #region Public

    /// <summary>
    /// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
    /// </returns>
    public override string ToString() {
      string toString = string.Empty;
      foreach (Attribute attribute in this) {
        toString += attribute.Name + ":";
        foreach (AttributeItem item in attribute.AttributeItemCollection) {
          toString += item.Name + " ";
        }
      }
      return toString;
    }
    
    public ExtendedProperties ExtentedProperties {
      get {
        ExtendedProperties extendedProperties = new ExtendedProperties();
        foreach(Attribute attribute in this) {
          extendedProperties.Add(attribute.Name, attribute.AttributeItemCollection[0].Name);
        }
        return extendedProperties;
      }      
    }
    
    
    //public string ToXml() {
    //  Serializer serializer = new Serializer();
    //  return serializer.SerializeObject(this, typeof(AttributeCollection));
    //}

    //public object NewFromXml(string xml) {
    //  Serializer serializer = new Serializer();
    //  return serializer.DeserializeObject(xml, typeof(AttributeCollection).AssemblyQualifiedName);
    //}


    #endregion
    
    #endregion
    
  }

  public partial class Attribute {
  
    #region Member Variables

    private AttributeItemCollection _attributeItemCollection = new AttributeItemCollection();
    
    #endregion
    
    #region Properties

    /// <summary>
    /// Gets or sets the attribute item collection.
    /// </summary>
    /// <value>The attribute item collection.</value>
    public AttributeItemCollection AttributeItemCollection {
      get {
        return _attributeItemCollection;
      }
      set {
        _attributeItemCollection = value;
      }
    }
    
    #endregion
    
  }
}
