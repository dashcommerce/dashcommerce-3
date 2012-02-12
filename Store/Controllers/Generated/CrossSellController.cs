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
    /// Controller class for dashCommerce_Store_CrossSell
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CrossSellController
    {
        // Preload our schema..
        CrossSell thisSchemaLoad = new CrossSell();
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
        public CrossSellCollection FetchAll()
        {
            CrossSellCollection coll = new CrossSellCollection();
            Query qry = new Query(CrossSell.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CrossSellCollection FetchByID(object ProductId)
        {
            CrossSellCollection coll = new CrossSellCollection().Where("ProductId", ProductId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CrossSellCollection FetchByQuery(Query qry)
        {
            CrossSellCollection coll = new CrossSellCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ProductId)
        {
            return (CrossSell.Delete(ProductId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ProductId)
        {
            return (CrossSell.Destroy(ProductId) == 1);
        }

        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int ProductId,int CrossProductId)
        {
            Query qry = new Query(CrossSell.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("ProductId", ProductId).AND("CrossProductId", CrossProductId);
            qry.Execute();
            return (true);
        }
        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ProductId,int CrossProductId)
	    {
		    CrossSell item = new CrossSell();
		    
            item.ProductId = ProductId;
            
            item.CrossProductId = CrossProductId;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ProductId,int CrossProductId)
	    {
		    CrossSell item = new CrossSell();
		    
				item.ProductId = ProductId;
				
				item.CrossProductId = CrossProductId;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

