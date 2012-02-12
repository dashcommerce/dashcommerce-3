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
    /// Controller class for dashCommerce_Content_Template_TemplateRegion_Map
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TemplateTemplateRegionMapController
    {
        // Preload our schema..
        TemplateTemplateRegionMap thisSchemaLoad = new TemplateTemplateRegionMap();
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
        public TemplateTemplateRegionMapCollection FetchAll()
        {
            TemplateTemplateRegionMapCollection coll = new TemplateTemplateRegionMapCollection();
            Query qry = new Query(TemplateTemplateRegionMap.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TemplateTemplateRegionMapCollection FetchByID(object TemplateId)
        {
            TemplateTemplateRegionMapCollection coll = new TemplateTemplateRegionMapCollection().Where("TemplateId", TemplateId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TemplateTemplateRegionMapCollection FetchByQuery(Query qry)
        {
            TemplateTemplateRegionMapCollection coll = new TemplateTemplateRegionMapCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object TemplateId)
        {
            return (TemplateTemplateRegionMap.Delete(TemplateId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object TemplateId)
        {
            return (TemplateTemplateRegionMap.Destroy(TemplateId) == 1);
        }

        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int TemplateId,int TemplateRegionId)
        {
            Query qry = new Query(TemplateTemplateRegionMap.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("TemplateId", TemplateId).AND("TemplateRegionId", TemplateRegionId);
            qry.Execute();
            return (true);
        }
        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int TemplateId,int TemplateRegionId)
	    {
		    TemplateTemplateRegionMap item = new TemplateTemplateRegionMap();
		    
            item.TemplateId = TemplateId;
            
            item.TemplateRegionId = TemplateRegionId;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int TemplateId,int TemplateRegionId)
	    {
		    TemplateTemplateRegionMap item = new TemplateTemplateRegionMap();
		    
				item.TemplateId = TemplateId;
				
				item.TemplateRegionId = TemplateRegionId;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

