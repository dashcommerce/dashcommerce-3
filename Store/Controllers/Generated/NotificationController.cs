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
    /// Controller class for dashCommerce_Store_Notification
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class NotificationController
    {
        // Preload our schema..
        Notification thisSchemaLoad = new Notification();
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
        public NotificationCollection FetchAll()
        {
            NotificationCollection coll = new NotificationCollection();
            Query qry = new Query(Notification.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public NotificationCollection FetchByID(object NotificationId)
        {
            NotificationCollection coll = new NotificationCollection().Where("NotificationId", NotificationId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public NotificationCollection FetchByQuery(Query qry)
        {
            NotificationCollection coll = new NotificationCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object NotificationId)
        {
            return (Notification.Delete(NotificationId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object NotificationId)
        {
            return (Notification.Destroy(NotificationId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,string ToList,string CcList,string FromName,string FromEmail,string Subject,string NotificationBody,bool IsHTML,bool IsSystemNotification,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    Notification item = new Notification();
		    
            item.Name = Name;
            
            item.ToList = ToList;
            
            item.CcList = CcList;
            
            item.FromName = FromName;
            
            item.FromEmail = FromEmail;
            
            item.Subject = Subject;
            
            item.NotificationBody = NotificationBody;
            
            item.IsHTML = IsHTML;
            
            item.IsSystemNotification = IsSystemNotification;
            
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
	    public void Update(int NotificationId,string Name,string ToList,string CcList,string FromName,string FromEmail,string Subject,string NotificationBody,bool IsHTML,bool IsSystemNotification,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    Notification item = new Notification();
		    
				item.NotificationId = NotificationId;
				
				item.Name = Name;
				
				item.ToList = ToList;
				
				item.CcList = CcList;
				
				item.FromName = FromName;
				
				item.FromEmail = FromEmail;
				
				item.Subject = Subject;
				
				item.NotificationBody = NotificationBody;
				
				item.IsHTML = IsHTML;
				
				item.IsSystemNotification = IsSystemNotification;
				
				item.CreatedBy = CreatedBy;
				
				item.CreatedOn = CreatedOn;
				
				item.ModifiedBy = ModifiedBy;
				
				item.ModifiedOn = ModifiedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

