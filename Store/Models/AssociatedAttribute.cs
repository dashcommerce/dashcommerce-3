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
