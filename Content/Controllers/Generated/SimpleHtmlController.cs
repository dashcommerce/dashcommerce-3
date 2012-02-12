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
    /// Controller class for dashCommerce_Content_SimpleHtml
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SimpleHtmlController
    {
        // Preload our schema..
        SimpleHtml thisSchemaLoad = new SimpleHtml();
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
        public SimpleHtmlCollection FetchAll()
        {
            SimpleHtmlCollection coll = new SimpleHtmlCollection();
            Query qry = new Query(SimpleHtml.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SimpleHtmlCollection FetchByID(object SimpleHtmlId)
        {
            SimpleHtmlCollection coll = new SimpleHtmlCollection().Where("SimpleHtmlId", SimpleHtmlId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SimpleHtmlCollection FetchByQuery(Query qry)
        {
            SimpleHtmlCollection coll = new SimpleHtmlCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object SimpleHtmlId)
        {
            return (SimpleHtml.Delete(SimpleHtmlId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object SimpleHtmlId)
        {
            return (SimpleHtml.Destroy(SimpleHtmlId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int RegionId,string Html,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    SimpleHtml item = new SimpleHtml();
		    
            item.RegionId = RegionId;
            
            item.Html = Html;
            
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
	    public void Update(int SimpleHtmlId,int RegionId,string Html,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    SimpleHtml item = new SimpleHtml();
		    
				item.SimpleHtmlId = SimpleHtmlId;
				
				item.RegionId = RegionId;
				
				item.Html = Html;
				
				item.CreatedBy = CreatedBy;
				
				item.CreatedOn = CreatedOn;
				
				item.ModifiedBy = ModifiedBy;
				
				item.ModifiedOn = ModifiedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

