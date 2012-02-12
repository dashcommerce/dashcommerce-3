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

namespace MettleSystems.dashCommerce.Content
{
    /// <summary>
    /// Controller class for dashCommerce_Content_CustomizedProductDisplay
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CustomizedProductDisplayController
    {
        // Preload our schema..
        CustomizedProductDisplay thisSchemaLoad = new CustomizedProductDisplay();
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
        public CustomizedProductDisplayCollection FetchAll()
        {
            CustomizedProductDisplayCollection coll = new CustomizedProductDisplayCollection();
            Query qry = new Query(CustomizedProductDisplay.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CustomizedProductDisplayCollection FetchByID(object CustomizedProductDisplayId)
        {
            CustomizedProductDisplayCollection coll = new CustomizedProductDisplayCollection().Where("CustomizedProductDisplayId", CustomizedProductDisplayId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CustomizedProductDisplayCollection FetchByQuery(Query qry)
        {
            CustomizedProductDisplayCollection coll = new CustomizedProductDisplayCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object CustomizedProductDisplayId)
        {
            return (CustomizedProductDisplay.Delete(CustomizedProductDisplayId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object CustomizedProductDisplayId)
        {
            return (CustomizedProductDisplay.Destroy(CustomizedProductDisplayId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int CustomizedProductDisplayTypeId,int RegionId,bool IsActive,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    CustomizedProductDisplay item = new CustomizedProductDisplay();
		    
            item.CustomizedProductDisplayTypeId = CustomizedProductDisplayTypeId;
            
            item.RegionId = RegionId;
            
            item.IsActive = IsActive;
            
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
	    public void Update(int CustomizedProductDisplayId,int CustomizedProductDisplayTypeId,int RegionId,bool IsActive,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    CustomizedProductDisplay item = new CustomizedProductDisplay();
		    
				item.CustomizedProductDisplayId = CustomizedProductDisplayId;
				
				item.CustomizedProductDisplayTypeId = CustomizedProductDisplayTypeId;
				
				item.RegionId = RegionId;
				
				item.IsActive = IsActive;
				
				item.CreatedBy = CreatedBy;
				
				item.CreatedOn = CreatedOn;
				
				item.ModifiedBy = ModifiedBy;
				
				item.ModifiedOn = ModifiedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

