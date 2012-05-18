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
using System.Collections.Generic;
using System.Data;

using SubSonic;

namespace MettleSystems.dashCommerce.Store {

  public partial class AssociatedAttributeCollection : List<AssociatedAttribute> {
  
    #region Methods
    
    #region Public

    /// <summary>
    /// Loads the specified reader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    public void Load(IDataReader reader) {
      AssociatedAttribute associatedAttribute;
      while(reader.Read()) {
        associatedAttribute = new AssociatedAttribute();
        associatedAttribute.Load(reader);
        this.Add(associatedAttribute);
      }
    }
    
    #endregion
    
    #endregion
    
    #region Properties

    /// <summary>
    /// Gets the total combinations.
    /// </summary>
    /// <value>The total combinations.</value>
    public int TotalCombinations {
      get {
        int totalCombinations = 1;
        foreach(AssociatedAttribute associatedAttribute in this) {
          totalCombinations *= associatedAttribute.AttributeItemCollection.Count;
        }
        return totalCombinations;
      }
    }
    
    #endregion
	
  }

  public partial class AssociatedAttribute {
  
    #region Member Variables

    private int _attributeId;
    private int _attributeTypeId;
    private string _name;
    private string _label;
    private int _sortOrder;
    private bool _isRequired;
    private AttributeItemCollection _attributeItemCollection;
   
    #endregion

    #region Methods
    
    #region Public

    //TODO: CMC - Fix this up
    public void Load(IDataReader reader) {
      this.AttributeId = (int)reader["AttributeId"];
      this.AttributeTypeId = (int)reader["AttributeTypeId"];
      this.Name = reader["Name"].ToString();
      this.Label = reader["Label"].ToString();
      this.SortOrder = (int)reader["SortOrder"];
      this.IsRequired = (bool)reader["IsRequired"];    
    }
    
    #endregion
    
    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the attribute id.
    /// </summary>
    /// <value>The attribute id.</value>
    public int AttributeId {
      get {
        return _attributeId;
      }
      set {
        _attributeId = value;
      }
    }

    /// <summary>
    /// Gets or sets the attribute type id.
    /// </summary>
    /// <value>The attribute type id.</value>
    public int AttributeTypeId {
      get {
        return _attributeTypeId;
      }
      set {
        _attributeTypeId = value;
      }
    }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Name {
      get {
        return _name;
      }
      set {
        _name = value;
      }
    }

    /// <summary>
    /// Gets or sets the label.
    /// </summary>
    /// <value>The label.</value>
    public string Label {
      get {
        return _label;
      }
      set {
        _label = value;
      }
    }

    /// <summary>
    /// Gets or sets the sort order.
    /// </summary>
    /// <value>The sort order.</value>
    public int SortOrder {
      get {
        return _sortOrder;
      }
      set {
        _sortOrder = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is required.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is required; otherwise, <c>false</c>.
    /// </value>
    public bool IsRequired {
      get {
        return _isRequired;
      }
      set {
        _isRequired = value;
      }
    }

    /// <summary>
    /// Gets or sets the attribute item collection.
    /// </summary>
    /// <value>The attribute item collection.</value>
    public AttributeItemCollection AttributeItemCollection {
      get {
        if(_attributeItemCollection == null) {
          _attributeItemCollection = new AttributeItemCollection().Where(AttributeItem.Columns.AttributeId, Comparison.Equals, this._attributeId).Load();
        }
        return _attributeItemCollection;
      }
      set {
        _attributeItemCollection = value;
      }
    }

    #endregion
    
  }
}
