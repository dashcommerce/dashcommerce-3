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

namespace MettleSystems.dashCommerce.Core
{
    /// <summary>
    /// Controller class for dashCommerce_Core_Log
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LogController
    {
        // Preload our schema..
        Log thisSchemaLoad = new Log();
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
        public LogCollection FetchAll()
        {
            LogCollection coll = new LogCollection();
            Query qry = new Query(Log.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LogCollection FetchByID(object LogID)
        {
            LogCollection coll = new LogCollection().Where("LogID", LogID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LogCollection FetchByQuery(Query qry)
        {
            LogCollection coll = new LogCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object LogID)
        {
            return (Log.Delete(LogID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object LogID)
        {
            return (Log.Destroy(LogID) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(DateTime LogDate,string Message,byte MessageType,string UserAgent,string RemoteHost,string AuthUser,string Referer,string MachineName,string FormData,string QueryStringData,string CookiesData,string ExceptionType,string ScriptName,string ExceptionMessage,string ExceptionSource,string ExceptionStackTrace)
	    {
		    Log item = new Log();
		    
            item.LogDate = LogDate;
            
            item.Message = Message;
            
            item.MessageType = MessageType;
            
            item.UserAgent = UserAgent;
            
            item.RemoteHost = RemoteHost;
            
            item.AuthUser = AuthUser;
            
            item.Referer = Referer;
            
            item.MachineName = MachineName;
            
            item.FormData = FormData;
            
            item.QueryStringData = QueryStringData;
            
            item.CookiesData = CookiesData;
            
            item.ExceptionType = ExceptionType;
            
            item.ScriptName = ScriptName;
            
            item.ExceptionMessage = ExceptionMessage;
            
            item.ExceptionSource = ExceptionSource;
            
            item.ExceptionStackTrace = ExceptionStackTrace;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int LogID,DateTime LogDate,string Message,byte MessageType,string UserAgent,string RemoteHost,string AuthUser,string Referer,string MachineName,string FormData,string QueryStringData,string CookiesData,string ExceptionType,string ScriptName,string ExceptionMessage,string ExceptionSource,string ExceptionStackTrace)
	    {
		    Log item = new Log();
		    
				item.LogID = LogID;
				
				item.LogDate = LogDate;
				
				item.Message = Message;
				
				item.MessageType = MessageType;
				
				item.UserAgent = UserAgent;
				
				item.RemoteHost = RemoteHost;
				
				item.AuthUser = AuthUser;
				
				item.Referer = Referer;
				
				item.MachineName = MachineName;
				
				item.FormData = FormData;
				
				item.QueryStringData = QueryStringData;
				
				item.CookiesData = CookiesData;
				
				item.ExceptionType = ExceptionType;
				
				item.ScriptName = ScriptName;
				
				item.ExceptionMessage = ExceptionMessage;
				
				item.ExceptionSource = ExceptionSource;
				
				item.ExceptionStackTrace = ExceptionStackTrace;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

