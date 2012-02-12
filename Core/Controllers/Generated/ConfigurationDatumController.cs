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

namespace MettleSystems.dashCommerce.Core
{
    /// <summary>
    /// Controller class for dashCommerce_Core_ConfigurationData
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ConfigurationDatumController
    {
        // Preload our schema..
        ConfigurationDatum thisSchemaLoad = new ConfigurationDatum();
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
        public ConfigurationDatumCollection FetchAll()
        {
            ConfigurationDatumCollection coll = new ConfigurationDatumCollection();
            Query qry = new Query(ConfigurationDatum.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConfigurationDatumCollection FetchByID(object ConfigurationDataId)
        {
            ConfigurationDatumCollection coll = new ConfigurationDatumCollection().Where("ConfigurationDataId", ConfigurationDataId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ConfigurationDatumCollection FetchByQuery(Query qry)
        {
            ConfigurationDatumCollection coll = new ConfigurationDatumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ConfigurationDataId)
        {
            return (ConfigurationDatum.Delete(ConfigurationDataId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ConfigurationDataId)
        {
            return (ConfigurationDatum.Destroy(ConfigurationDataId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,string Type,string ValueX,string CreatedBy,DateTime CreatedDate,string ModifiedBy,DateTime ModifiedDate,bool IsDeleted)
	    {
		    ConfigurationDatum item = new ConfigurationDatum();
		    
            item.Name = Name;
            
            item.Type = Type;
            
            item.ValueX = ValueX;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedDate = CreatedDate;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedDate = ModifiedDate;
            
            item.IsDeleted = IsDeleted;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ConfigurationDataId,string Name,string Type,string ValueX,string CreatedBy,DateTime CreatedDate,string ModifiedBy,DateTime ModifiedDate,bool IsDeleted)
	    {
		    ConfigurationDatum item = new ConfigurationDatum();
		    
				item.ConfigurationDataId = ConfigurationDataId;
				
				item.Name = Name;
				
				item.Type = Type;
				
				item.ValueX = ValueX;
				
				item.CreatedBy = CreatedBy;
				
				item.CreatedDate = CreatedDate;
				
				item.ModifiedBy = ModifiedBy;
				
				item.ModifiedDate = ModifiedDate;
				
				item.IsDeleted = IsDeleted;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

