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
    /// Controller class for dashCommerce_Content_Page_Region_Map
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PageRegionMapController
    {
        // Preload our schema..
        PageRegionMap thisSchemaLoad = new PageRegionMap();
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
        public PageRegionMapCollection FetchAll()
        {
            PageRegionMapCollection coll = new PageRegionMapCollection();
            Query qry = new Query(PageRegionMap.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PageRegionMapCollection FetchByID(object RegionId)
        {
            PageRegionMapCollection coll = new PageRegionMapCollection().Where("RegionId", RegionId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PageRegionMapCollection FetchByQuery(Query qry)
        {
            PageRegionMapCollection coll = new PageRegionMapCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object RegionId)
        {
            return (PageRegionMap.Delete(RegionId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object RegionId)
        {
            return (PageRegionMap.Destroy(RegionId) == 1);
        }

        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int RegionId,int PageId)
        {
            Query qry = new Query(PageRegionMap.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("RegionId", RegionId).AND("PageId", PageId);
            qry.Execute();
            return (true);
        }
        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int RegionId,int PageId)
	    {
		    PageRegionMap item = new PageRegionMap();
		    
            item.RegionId = RegionId;
            
            item.PageId = PageId;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int RegionId,int PageId)
	    {
		    PageRegionMap item = new PageRegionMap();
		    
				item.RegionId = RegionId;
				
				item.PageId = PageId;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

