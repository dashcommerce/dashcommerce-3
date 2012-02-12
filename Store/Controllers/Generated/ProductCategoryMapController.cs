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
    /// Controller class for dashCommerce_Store_Product_Category_Map
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ProductCategoryMapController
    {
        // Preload our schema..
        ProductCategoryMap thisSchemaLoad = new ProductCategoryMap();
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
        public ProductCategoryMapCollection FetchAll()
        {
            ProductCategoryMapCollection coll = new ProductCategoryMapCollection();
            Query qry = new Query(ProductCategoryMap.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductCategoryMapCollection FetchByID(object ProductId)
        {
            ProductCategoryMapCollection coll = new ProductCategoryMapCollection().Where("ProductId", ProductId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductCategoryMapCollection FetchByQuery(Query qry)
        {
            ProductCategoryMapCollection coll = new ProductCategoryMapCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ProductId)
        {
            return (ProductCategoryMap.Delete(ProductId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ProductId)
        {
            return (ProductCategoryMap.Destroy(ProductId) == 1);
        }

        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int ProductId,int CategoryId)
        {
            Query qry = new Query(ProductCategoryMap.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("ProductId", ProductId).AND("CategoryId", CategoryId);
            qry.Execute();
            return (true);
        }
        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ProductId,int CategoryId,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    ProductCategoryMap item = new ProductCategoryMap();
		    
            item.ProductId = ProductId;
            
            item.CategoryId = CategoryId;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ProductId,int CategoryId,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    ProductCategoryMap item = new ProductCategoryMap();
		    
				item.ProductId = ProductId;
				
				item.CategoryId = CategoryId;
				
				item.CreatedBy = CreatedBy;
				
				item.CreatedOn = CreatedOn;
				
				item.ModifiedBy = ModifiedBy;
				
				item.ModifiedOn = ModifiedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

