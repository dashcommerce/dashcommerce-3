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
    /// Controller class for dashCommerce_Store_DownloadAccessControl
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class DownloadAccessControlController
    {
        // Preload our schema..
        DownloadAccessControl thisSchemaLoad = new DownloadAccessControl();
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
        public DownloadAccessControlCollection FetchAll()
        {
            DownloadAccessControlCollection coll = new DownloadAccessControlCollection();
            Query qry = new Query(DownloadAccessControl.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public DownloadAccessControlCollection FetchByID(object UserId)
        {
            DownloadAccessControlCollection coll = new DownloadAccessControlCollection().Where("UserId", UserId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public DownloadAccessControlCollection FetchByQuery(Query qry)
        {
            DownloadAccessControlCollection coll = new DownloadAccessControlCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object UserId)
        {
            return (DownloadAccessControl.Delete(UserId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object UserId)
        {
            return (DownloadAccessControl.Destroy(UserId) == 1);
        }

        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(Guid UserId,int DownloadId)
        {
            Query qry = new Query(DownloadAccessControl.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("UserId", UserId).AND("DownloadId", DownloadId);
            qry.Execute();
            return (true);
        }
        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(Guid UserId,int DownloadId)
	    {
		    DownloadAccessControl item = new DownloadAccessControl();
		    
            item.UserId = UserId;
            
            item.DownloadId = DownloadId;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(Guid UserId,int DownloadId)
	    {
		    DownloadAccessControl item = new DownloadAccessControl();
		    
				item.UserId = UserId;
				
				item.DownloadId = DownloadId;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

