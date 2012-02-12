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
    /// Controller class for dashCommerce_Store_CustomizedProductDisplayType_Product_Map
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CustomizedProductDisplayTypeProductMapController
    {
        // Preload our schema..
        CustomizedProductDisplayTypeProductMap thisSchemaLoad = new CustomizedProductDisplayTypeProductMap();
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
        public CustomizedProductDisplayTypeProductMapCollection FetchAll()
        {
            CustomizedProductDisplayTypeProductMapCollection coll = new CustomizedProductDisplayTypeProductMapCollection();
            Query qry = new Query(CustomizedProductDisplayTypeProductMap.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CustomizedProductDisplayTypeProductMapCollection FetchByID(object CustomizedProductDisplayTypeId)
        {
            CustomizedProductDisplayTypeProductMapCollection coll = new CustomizedProductDisplayTypeProductMapCollection().Where("CustomizedProductDisplayTypeId", CustomizedProductDisplayTypeId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CustomizedProductDisplayTypeProductMapCollection FetchByQuery(Query qry)
        {
            CustomizedProductDisplayTypeProductMapCollection coll = new CustomizedProductDisplayTypeProductMapCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object CustomizedProductDisplayTypeId)
        {
            return (CustomizedProductDisplayTypeProductMap.Delete(CustomizedProductDisplayTypeId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object CustomizedProductDisplayTypeId)
        {
            return (CustomizedProductDisplayTypeProductMap.Destroy(CustomizedProductDisplayTypeId) == 1);
        }

        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int CustomizedProductDisplayTypeId,int ProductId)
        {
            Query qry = new Query(CustomizedProductDisplayTypeProductMap.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("CustomizedProductDisplayTypeId", CustomizedProductDisplayTypeId).AND("ProductId", ProductId);
            qry.Execute();
            return (true);
        }
        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int CustomizedProductDisplayTypeId,int ProductId)
	    {
		    CustomizedProductDisplayTypeProductMap item = new CustomizedProductDisplayTypeProductMap();
		    
            item.CustomizedProductDisplayTypeId = CustomizedProductDisplayTypeId;
            
            item.ProductId = ProductId;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int CustomizedProductDisplayTypeId,int ProductId)
	    {
		    CustomizedProductDisplayTypeProductMap item = new CustomizedProductDisplayTypeProductMap();
		    
				item.CustomizedProductDisplayTypeId = CustomizedProductDisplayTypeId;
				
				item.ProductId = ProductId;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

