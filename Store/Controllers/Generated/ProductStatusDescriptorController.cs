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
    /// Controller class for dashCommerce_Store_ProductStatusDescriptor
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ProductStatusDescriptorController
    {
        // Preload our schema..
        ProductStatusDescriptor thisSchemaLoad = new ProductStatusDescriptor();
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
        public ProductStatusDescriptorCollection FetchAll()
        {
            ProductStatusDescriptorCollection coll = new ProductStatusDescriptorCollection();
            Query qry = new Query(ProductStatusDescriptor.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductStatusDescriptorCollection FetchByID(object ProductStatusDescriptorId)
        {
            ProductStatusDescriptorCollection coll = new ProductStatusDescriptorCollection().Where("ProductStatusDescriptorId", ProductStatusDescriptorId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductStatusDescriptorCollection FetchByQuery(Query qry)
        {
            ProductStatusDescriptorCollection coll = new ProductStatusDescriptorCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ProductStatusDescriptorId)
        {
            return (ProductStatusDescriptor.Delete(ProductStatusDescriptorId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ProductStatusDescriptorId)
        {
            return (ProductStatusDescriptor.Destroy(ProductStatusDescriptorId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    ProductStatusDescriptor item = new ProductStatusDescriptor();
		    
            item.Name = Name;
            
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
	    public void Update(int ProductStatusDescriptorId,string Name,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    ProductStatusDescriptor item = new ProductStatusDescriptor();
		    
				item.ProductStatusDescriptorId = ProductStatusDescriptorId;
				
				item.Name = Name;
				
				item.CreatedBy = CreatedBy;
				
				item.CreatedOn = CreatedOn;
				
				item.ModifiedBy = ModifiedBy;
				
				item.ModifiedOn = ModifiedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

