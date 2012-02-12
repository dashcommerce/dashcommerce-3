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
    /// Controller class for dashCommerce_Store_Provider
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ProviderController
    {
        // Preload our schema..
        Provider thisSchemaLoad = new Provider();
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
        public ProviderCollection FetchAll()
        {
            ProviderCollection coll = new ProviderCollection();
            Query qry = new Query(Provider.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProviderCollection FetchByID(object ProviderId)
        {
            ProviderCollection coll = new ProviderCollection().Where("ProviderId", ProviderId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProviderCollection FetchByQuery(Query qry)
        {
            ProviderCollection coll = new ProviderCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ProviderId)
        {
            return (Provider.Delete(ProviderId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ProviderId)
        {
            return (Provider.Destroy(ProviderId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ProviderTypeId,string Name,string Description,string ConfigurationControlPath,string CreatedBy,DateTime CreatedDate,string ModifiedBy,DateTime ModifiedDate)
	    {
		    Provider item = new Provider();
		    
            item.ProviderTypeId = ProviderTypeId;
            
            item.Name = Name;
            
            item.Description = Description;
            
            item.ConfigurationControlPath = ConfigurationControlPath;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedDate = CreatedDate;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ProviderId,int ProviderTypeId,string Name,string Description,string ConfigurationControlPath,string CreatedBy,DateTime CreatedDate,string ModifiedBy,DateTime ModifiedDate)
	    {
		    Provider item = new Provider();
		    
				item.ProviderId = ProviderId;
				
				item.ProviderTypeId = ProviderTypeId;
				
				item.Name = Name;
				
				item.Description = Description;
				
				item.ConfigurationControlPath = ConfigurationControlPath;
				
				item.CreatedBy = CreatedBy;
				
				item.CreatedDate = CreatedDate;
				
				item.ModifiedBy = ModifiedBy;
				
				item.ModifiedDate = ModifiedDate;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

