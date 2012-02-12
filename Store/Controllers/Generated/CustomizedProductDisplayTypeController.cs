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
    /// Controller class for dashCommerce_Store_CustomizedProductDisplayType
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CustomizedProductDisplayTypeController
    {
        // Preload our schema..
        CustomizedProductDisplayType thisSchemaLoad = new CustomizedProductDisplayType();
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
        public CustomizedProductDisplayTypeCollection FetchAll()
        {
            CustomizedProductDisplayTypeCollection coll = new CustomizedProductDisplayTypeCollection();
            Query qry = new Query(CustomizedProductDisplayType.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CustomizedProductDisplayTypeCollection FetchByID(object CustomizedProductDisplayTypeId)
        {
            CustomizedProductDisplayTypeCollection coll = new CustomizedProductDisplayTypeCollection().Where("CustomizedProductDisplayTypeId", CustomizedProductDisplayTypeId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CustomizedProductDisplayTypeCollection FetchByQuery(Query qry)
        {
            CustomizedProductDisplayTypeCollection coll = new CustomizedProductDisplayTypeCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object CustomizedProductDisplayTypeId)
        {
            return (CustomizedProductDisplayType.Delete(CustomizedProductDisplayTypeId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object CustomizedProductDisplayTypeId)
        {
            return (CustomizedProductDisplayType.Destroy(CustomizedProductDisplayTypeId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    CustomizedProductDisplayType item = new CustomizedProductDisplayType();
		    
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
	    public void Update(int CustomizedProductDisplayTypeId,string Name,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    CustomizedProductDisplayType item = new CustomizedProductDisplayType();
		    
				item.CustomizedProductDisplayTypeId = CustomizedProductDisplayTypeId;
				
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

