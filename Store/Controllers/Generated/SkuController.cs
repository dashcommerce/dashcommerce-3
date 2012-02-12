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
    /// Controller class for dashCommerce_Store_Sku
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SkuController
    {
        // Preload our schema..
        Sku thisSchemaLoad = new Sku();
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
        public SkuCollection FetchAll()
        {
            SkuCollection coll = new SkuCollection();
            Query qry = new Query(Sku.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SkuCollection FetchByID(object SkuId)
        {
            SkuCollection coll = new SkuCollection().Where("SkuId", SkuId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SkuCollection FetchByQuery(Query qry)
        {
            SkuCollection coll = new SkuCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object SkuId)
        {
            return (Sku.Delete(SkuId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object SkuId)
        {
            return (Sku.Destroy(SkuId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ProductId,string SkuX,int Inventory,string CreatedBy,string CreatedOn,string ModifiedBy,string ModifiedOn)
	    {
		    Sku item = new Sku();
		    
            item.ProductId = ProductId;
            
            item.SkuX = SkuX;
            
            item.Inventory = Inventory;
            
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
	    public void Update(int SkuId,int ProductId,string SkuX,int Inventory,string CreatedBy,string CreatedOn,string ModifiedBy,string ModifiedOn)
	    {
		    Sku item = new Sku();
		    
				item.SkuId = SkuId;
				
				item.ProductId = ProductId;
				
				item.SkuX = SkuX;
				
				item.Inventory = Inventory;
				
				item.CreatedBy = CreatedBy;
				
				item.CreatedOn = CreatedOn;
				
				item.ModifiedBy = ModifiedBy;
				
				item.ModifiedOn = ModifiedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

