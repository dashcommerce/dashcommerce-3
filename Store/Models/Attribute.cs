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
