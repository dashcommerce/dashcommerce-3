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
    /// Controller class for dashCommerce_Content_TemplateRegion
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TemplateRegionController
    {
        // Preload our schema..
        TemplateRegion thisSchemaLoad = new TemplateRegion();
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
        public TemplateRegionCollection FetchAll()
        {
            TemplateRegionCollection coll = new TemplateRegionCollection();
            Query qry = new Query(TemplateRegion.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TemplateRegionCollection FetchByID(object TemplateRegionId)
        {
            TemplateRegionCollection coll = new TemplateRegionCollection().Where("TemplateRegionId", TemplateRegionId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TemplateRegionCollection FetchByQuery(Query qry)
        {
            TemplateRegionCollection coll = new TemplateRegionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object TemplateRegionId)
        {
            return (TemplateRegion.Delete(TemplateRegionId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object TemplateRegionId)
        {
            return (TemplateRegion.Destroy(TemplateRegionId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,string Description,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    TemplateRegion item = new TemplateRegion();
		    
            item.Name = Name;
            
            item.Description = Description;
            
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
	    public void Update(int TemplateRegionId,string Name,string Description,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    TemplateRegion item = new TemplateRegion();
		    
				item.TemplateRegionId = TemplateRegionId;
				
				item.Name = Name;
				
				item.Description = Description;
				
				item.CreatedBy = CreatedBy;
				
				item.CreatedOn = CreatedOn;
				
				item.ModifiedBy = ModifiedBy;
				
				item.ModifiedOn = ModifiedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

