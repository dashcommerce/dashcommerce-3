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
    /// Controller class for dashCommerce_Store_Product_Download_Map
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ProductDownloadMapController
    {
        // Preload our schema..
        ProductDownloadMap thisSchemaLoad = new ProductDownloadMap();
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
        public ProductDownloadMapCollection FetchAll()
        {
            ProductDownloadMapCollection coll = new ProductDownloadMapCollection();
            Query qry = new Query(ProductDownloadMap.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductDownloadMapCollection FetchByID(object ProductId)
        {
            ProductDownloadMapCollection coll = new ProductDownloadMapCollection().Where("ProductId", ProductId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductDownloadMapCollection FetchByQuery(Query qry)
        {
            ProductDownloadMapCollection coll = new ProductDownloadMapCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ProductId)
        {
            return (ProductDownloadMap.Delete(ProductId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ProductId)
        {
            return (ProductDownloadMap.Destroy(ProductId) == 1);
        }

        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int ProductId,int DownloadId)
        {
            Query qry = new Query(ProductDownloadMap.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("ProductId", ProductId).AND("DownloadId", DownloadId);
            qry.Execute();
            return (true);
        }
        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ProductId,int DownloadId)
	    {
		    ProductDownloadMap item = new ProductDownloadMap();
		    
            item.ProductId = ProductId;
            
            item.DownloadId = DownloadId;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ProductId,int DownloadId)
	    {
		    ProductDownloadMap item = new ProductDownloadMap();
		    
				item.ProductId = ProductId;
				
				item.DownloadId = DownloadId;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

