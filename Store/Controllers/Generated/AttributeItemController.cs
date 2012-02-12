using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Store
{
    /// <summary>
    /// Controller class for dashCommerce_Store_AttributeItem
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AttributeItemController
    {
        // Preload our schema..
        AttributeItem thisSchemaLoad = new AttributeItem();
        private string userName = string.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}

					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}

				}

				return userName;
            }

        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public AttributeItemCollection FetchAll()
        {
            AttributeItemCollection coll = new AttributeItemCollection();
            Query qry = new Query(AttributeItem.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AttributeItemCollection FetchByID(object AttributeItemId)
        {
            AttributeItemCollection coll = new AttributeItemCollection().Where("AttributeItemId", AttributeItemId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AttributeItemCollection FetchByQuery(Query qry)
        {
            AttributeItemCollection coll = new AttributeItemCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object AttributeItemId)
        {
            return (AttributeItem.Delete(AttributeItemId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object AttributeItemId)
        {
            return (AttributeItem.Destroy(AttributeItemId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int AttributeId,string Name,decimal Adjustment,int SortOrder,string SkuSuffix)
	    {
		    AttributeItem item = new AttributeItem();
		    
            item.AttributeId = AttributeId;
            
            item.Name = Name;
            
            item.Adjustment = Adjustment;
            
            item.SortOrder = SortOrder;
            
            item.SkuSuffix = SkuSuffix;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int AttributeItemId,int AttributeId,string Name,decimal Adjustment,int SortOrder,string SkuSuffix)
	    {
		    AttributeItem item = new AttributeItem();
		    
				item.AttributeItemId = AttributeItemId;
				
				item.AttributeId = AttributeId;
				
				item.Name = Name;
				
				item.Adjustment = Adjustment;
				
				item.SortOrder = SortOrder;
				
				item.SkuSuffix = SkuSuffix;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

