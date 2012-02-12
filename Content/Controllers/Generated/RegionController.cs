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
    /// Controller class for dashCommerce_Content_Region
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RegionController
    {
        // Preload our schema..
        Region thisSchemaLoad = new Region();
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
        public RegionCollection FetchAll()
        {
            RegionCollection coll = new RegionCollection();
            Query qry = new Query(Region.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RegionCollection FetchByID(object RegionId)
        {
            RegionCollection coll = new RegionCollection().Where("RegionId", RegionId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RegionCollection FetchByQuery(Query qry)
        {
            RegionCollection coll = new RegionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object RegionId)
        {
            return (Region.Delete(RegionId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object RegionId)
        {
            return (Region.Destroy(RegionId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(Guid RegionGuid,int ProviderId,string Title,int TemplateRegionId,int SortOrder,bool ShowTitle,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    Region item = new Region();
		    
            item.RegionGuid = RegionGuid;
            
            item.ProviderId = ProviderId;
            
            item.Title = Title;
            
            item.TemplateRegionId = TemplateRegionId;
            
            item.SortOrder = SortOrder;
            
            item.ShowTitle = ShowTitle;
            
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
	    public void Update(int RegionId,Guid RegionGuid,int ProviderId,string Title,int TemplateRegionId,int SortOrder,bool ShowTitle,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    Region item = new Region();
		    
				item.RegionId = RegionId;
				
				item.RegionGuid = RegionGuid;
				
				item.ProviderId = ProviderId;
				
				item.Title = Title;
				
				item.TemplateRegionId = TemplateRegionId;
				
				item.SortOrder = SortOrder;
				
				item.ShowTitle = ShowTitle;
				
				item.CreatedBy = CreatedBy;
				
				item.CreatedOn = CreatedOn;
				
				item.ModifiedBy = ModifiedBy;
				
				item.ModifiedOn = ModifiedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

