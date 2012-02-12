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
    /// Controller class for dashCommerce_Store_SimpleWeightShippingRate
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SimpleWeightShippingRateController
    {
        // Preload our schema..
        SimpleWeightShippingRate thisSchemaLoad = new SimpleWeightShippingRate();
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
        public SimpleWeightShippingRateCollection FetchAll()
        {
            SimpleWeightShippingRateCollection coll = new SimpleWeightShippingRateCollection();
            Query qry = new Query(SimpleWeightShippingRate.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SimpleWeightShippingRateCollection FetchByID(object SimpleWeightShippingRateId)
        {
            SimpleWeightShippingRateCollection coll = new SimpleWeightShippingRateCollection().Where("SimpleWeightShippingRateId", SimpleWeightShippingRateId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SimpleWeightShippingRateCollection FetchByQuery(Query qry)
        {
            SimpleWeightShippingRateCollection coll = new SimpleWeightShippingRateCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object SimpleWeightShippingRateId)
        {
            return (SimpleWeightShippingRate.Delete(SimpleWeightShippingRateId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object SimpleWeightShippingRateId)
        {
            return (SimpleWeightShippingRate.Destroy(SimpleWeightShippingRateId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Service,decimal AmountPerUnit,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    SimpleWeightShippingRate item = new SimpleWeightShippingRate();
		    
            item.Service = Service;
            
            item.AmountPerUnit = AmountPerUnit;
            
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
	    public void Update(int SimpleWeightShippingRateId,string Service,decimal AmountPerUnit,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    SimpleWeightShippingRate item = new SimpleWeightShippingRate();
		    
				item.SimpleWeightShippingRateId = SimpleWeightShippingRateId;
				
				item.Service = Service;
				
				item.AmountPerUnit = AmountPerUnit;
				
				item.CreatedBy = CreatedBy;
				
				item.CreatedOn = CreatedOn;
				
				item.ModifiedBy = ModifiedBy;
				
				item.ModifiedOn = ModifiedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

