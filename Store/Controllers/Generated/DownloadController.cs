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
    /// Controller class for dashCommerce_Store_Download
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class DownloadController
    {
        // Preload our schema..
        Download thisSchemaLoad = new Download();
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
        public DownloadCollection FetchAll()
        {
            DownloadCollection coll = new DownloadCollection();
            Query qry = new Query(Download.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public DownloadCollection FetchByID(object DownloadId)
        {
            DownloadCollection coll = new DownloadCollection().Where("DownloadId", DownloadId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public DownloadCollection FetchByQuery(Query qry)
        {
            DownloadCollection coll = new DownloadCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object DownloadId)
        {
            return (Download.Delete(DownloadId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object DownloadId)
        {
            return (Download.Destroy(DownloadId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string DownloadFile,string Title,string Description,bool ForPurchaseOnly,string ContentType,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    Download item = new Download();
		    
            item.DownloadFile = DownloadFile;
            
            item.Title = Title;
            
            item.Description = Description;
            
            item.ForPurchaseOnly = ForPurchaseOnly;
            
            item.ContentType = ContentType;
            
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
	    public void Update(int DownloadId,string DownloadFile,string Title,string Description,bool ForPurchaseOnly,string ContentType,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    Download item = new Download();
		    
				item.DownloadId = DownloadId;
				
				item.DownloadFile = DownloadFile;
				
				item.Title = Title;
				
				item.Description = Description;
				
				item.ForPurchaseOnly = ForPurchaseOnly;
				
				item.ContentType = ContentType;
				
				item.CreatedBy = CreatedBy;
				
				item.CreatedOn = CreatedOn;
				
				item.ModifiedBy = ModifiedBy;
				
				item.ModifiedOn = ModifiedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

