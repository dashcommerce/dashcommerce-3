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
    /// Controller class for dashCommerce_Store_Product_Attribute_Map
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ProductAttributeMapController
    {
        // Preload our schema..
        ProductAttributeMap thisSchemaLoad = new ProductAttributeMap();
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
        public ProductAttributeMapCollection FetchAll()
        {
            ProductAttributeMapCollection coll = new ProductAttributeMapCollection();
            Query qry = new Query(ProductAttributeMap.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductAttributeMapCollection FetchByID(object AttributeId)
        {
            ProductAttributeMapCollection coll = new ProductAttributeMapCollection().Where("AttributeId", AttributeId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductAttributeMapCollection FetchByQuery(Query qry)
        {
            ProductAttributeMapCollection coll = new ProductAttributeMapCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object AttributeId)
        {
            return (ProductAttributeMap.Delete(AttributeId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object AttributeId)
        {
            return (ProductAttributeMap.Destroy(AttributeId) == 1);
        }

        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int AttributeId,int ProductId)
        {
            Query qry = new Query(ProductAttributeMap.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("AttributeId", AttributeId).AND("ProductId", ProductId);
            qry.Execute();
            return (true);
        }
        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int AttributeId,int ProductId,int SortOrder,bool IsRequired)
	    {
		    ProductAttributeMap item = new ProductAttributeMap();
		    
            item.AttributeId = AttributeId;
            
            item.ProductId = ProductId;
            
            item.SortOrder = SortOrder;
            
            item.IsRequired = IsRequired;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int AttributeId,int ProductId,int SortOrder,bool IsRequired)
	    {
		    ProductAttributeMap item = new ProductAttributeMap();
		    
				item.AttributeId = AttributeId;
				
				item.ProductId = ProductId;
				
				item.SortOrder = SortOrder;
				
				item.IsRequired = IsRequired;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

