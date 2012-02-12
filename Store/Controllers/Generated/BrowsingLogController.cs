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
    /// Controller class for dashCommerce_Store_Browsing_Log
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class BrowsingLogController
    {
        // Preload our schema..
        BrowsingLog thisSchemaLoad = new BrowsingLog();
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
        public BrowsingLogCollection FetchAll()
        {
            BrowsingLogCollection coll = new BrowsingLogCollection();
            Query qry = new Query(BrowsingLog.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public BrowsingLogCollection FetchByID(object BrowsingLogId)
        {
            BrowsingLogCollection coll = new BrowsingLogCollection().Where("BrowsingLogId", BrowsingLogId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public BrowsingLogCollection FetchByQuery(Query qry)
        {
            BrowsingLogCollection coll = new BrowsingLogCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object BrowsingLogId)
        {
            return (BrowsingLog.Delete(BrowsingLogId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object BrowsingLogId)
        {
            return (BrowsingLog.Destroy(BrowsingLogId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int BrowsingBehaviorId,int? RelevantId,string UserName,string Url,string SearchTerms,string SessionId,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    BrowsingLog item = new BrowsingLog();
		    
            item.BrowsingBehaviorId = BrowsingBehaviorId;
            
            item.RelevantId = RelevantId;
            
            item.UserName = UserName;
            
            item.Url = Url;
            
            item.SearchTerms = SearchTerms;
            
            item.SessionId = SessionId;
            
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
	    public void Update(int BrowsingLogId,int BrowsingBehaviorId,int? RelevantId,string UserName,string Url,string SearchTerms,string SessionId,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    BrowsingLog item = new BrowsingLog();
		    
				item.BrowsingLogId = BrowsingLogId;
				
				item.BrowsingBehaviorId = BrowsingBehaviorId;
				
				item.RelevantId = RelevantId;
				
				item.UserName = UserName;
				
				item.Url = Url;
				
				item.SearchTerms = SearchTerms;
				
				item.SessionId = SessionId;
				
				item.CreatedBy = CreatedBy;
				
				item.CreatedOn = CreatedOn;
				
				item.ModifiedBy = ModifiedBy;
				
				item.ModifiedOn = ModifiedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

