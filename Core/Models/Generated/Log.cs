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
	/// Strongly-typed collection for the Log class.
	/// </summary>
	[Serializable]
	public partial class LogCollection : ActiveList<Log, LogCollection> 
	{	   
		public LogCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Core_Log table.
	/// </summary>
	[Serializable]
	public partial class Log : ActiveRecord<Log>
	{
		#region .ctors and Default Settings
		
		public Log()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Log(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Log(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Log(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}

		
		protected static void SetSQLProps() { GetTableSchema(); }

		
		#endregion
		
		#region Schema and Query Accessor
		public static Query CreateQuery() { return new Query(Schema); }

		
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}

		}

		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Core_Log", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarLogID = new TableSchema.TableColumn(schema);
				colvarLogID.ColumnName = "LogID";
				colvarLogID.DataType = DbType.Int32;
				colvarLogID.MaxLength = 0;
				colvarLogID.AutoIncrement = true;
				colvarLogID.IsNullable = false;
				colvarLogID.IsPrimaryKey = true;
				colvarLogID.IsForeignKey = false;
				colvarLogID.IsReadOnly = false;
				colvarLogID.DefaultSetting = @"";
				colvarLogID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLogID);
				
				TableSchema.TableColumn colvarLogDate = new TableSchema.TableColumn(schema);
				colvarLogDate.ColumnName = "LogDate";
				colvarLogDate.DataType = DbType.DateTime;
				colvarLogDate.MaxLength = 0;
				colvarLogDate.AutoIncrement = false;
				colvarLogDate.IsNullable = false;
				colvarLogDate.IsPrimaryKey = false;
				colvarLogDate.IsForeignKey = false;
				colvarLogDate.IsReadOnly = false;
				
						colvarLogDate.DefaultSetting = @"(getdate())";
				colvarLogDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLogDate);
				
				TableSchema.TableColumn colvarMessage = new TableSchema.TableColumn(schema);
				colvarMessage.ColumnName = "Message";
				colvarMessage.DataType = DbType.String;
				colvarMessage.MaxLength = 2147483647;
				colvarMessage.AutoIncrement = false;
				colvarMessage.IsNullable = true;
				colvarMessage.IsPrimaryKey = false;
				colvarMessage.IsForeignKey = false;
				colvarMessage.IsReadOnly = false;
				colvarMessage.DefaultSetting = @"";
				colvarMessage.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMessage);
				
				TableSchema.TableColumn colvarMessageType = new TableSchema.TableColumn(schema);
				colvarMessageType.ColumnName = "MessageType";
				colvarMessageType.DataType = DbType.Byte;
				colvarMessageType.MaxLength = 0;
				colvarMessageType.AutoIncrement = false;
				colvarMessageType.IsNullable = false;
				colvarMessageType.IsPrimaryKey = false;
				colvarMessageType.IsForeignKey = false;
				colvarMessageType.IsReadOnly = false;
				colvarMessageType.DefaultSetting = @"";
				colvarMessageType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMessageType);
				
				TableSchema.TableColumn colvarUserAgent = new TableSchema.TableColumn(schema);
				colvarUserAgent.ColumnName = "UserAgent";
				colvarUserAgent.DataType = DbType.String;
				colvarUserAgent.MaxLength = 256;
				colvarUserAgent.AutoIncrement = false;
				colvarUserAgent.IsNullable = true;
				colvarUserAgent.IsPrimaryKey = false;
				colvarUserAgent.IsForeignKey = false;
				colvarUserAgent.IsReadOnly = false;
				colvarUserAgent.DefaultSetting = @"";
				colvarUserAgent.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserAgent);
				
				TableSchema.TableColumn colvarRemoteHost = new TableSchema.TableColumn(schema);
				colvarRemoteHost.ColumnName = "RemoteHost";
				colvarRemoteHost.DataType = DbType.String;
				colvarRemoteHost.MaxLength = 256;
				colvarRemoteHost.AutoIncrement = false;
				colvarRemoteHost.IsNullable = true;
				colvarRemoteHost.IsPrimaryKey = false;
				colvarRemoteHost.IsForeignKey = false;
				colvarRemoteHost.IsReadOnly = false;
				colvarRemoteHost.DefaultSetting = @"";
				colvarRemoteHost.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRemoteHost);
				
				TableSchema.TableColumn colvarAuthUser = new TableSchema.TableColumn(schema);
				colvarAuthUser.ColumnName = "AuthUser";
				colvarAuthUser.DataType = DbType.String;
				colvarAuthUser.MaxLength = 64;
				colvarAuthUser.AutoIncrement = false;
				colvarAuthUser.IsNullable = true;
				colvarAuthUser.IsPrimaryKey = false;
				colvarAuthUser.IsForeignKey = false;
				colvarAuthUser.IsReadOnly = false;
				colvarAuthUser.DefaultSetting = @"";
				colvarAuthUser.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAuthUser);
				
				TableSchema.TableColumn colvarReferer = new TableSchema.TableColumn(schema);
				colvarReferer.ColumnName = "Referer";
				colvarReferer.DataType = DbType.String;
				colvarReferer.MaxLength = 512;
				colvarReferer.AutoIncrement = false;
				colvarReferer.IsNullable = true;
				colvarReferer.IsPrimaryKey = false;
				colvarReferer.IsForeignKey = false;
				colvarReferer.IsReadOnly = false;
				colvarReferer.DefaultSetting = @"";
				colvarReferer.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReferer);
				
				TableSchema.TableColumn colvarMachineName = new TableSchema.TableColumn(schema);
				colvarMachineName.ColumnName = "MachineName";
				colvarMachineName.DataType = DbType.String;
				colvarMachineName.MaxLength = 32;
				colvarMachineName.AutoIncrement = false;
				colvarMachineName.IsNullable = true;
				colvarMachineName.IsPrimaryKey = false;
				colvarMachineName.IsForeignKey = false;
				colvarMachineName.IsReadOnly = false;
				colvarMachineName.DefaultSetting = @"";
				colvarMachineName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMachineName);
				
				TableSchema.TableColumn colvarFormData = new TableSchema.TableColumn(schema);
				colvarFormData.ColumnName = "FormData";
				colvarFormData.DataType = DbType.String;
				colvarFormData.MaxLength = 2147483647;
				colvarFormData.AutoIncrement = false;
				colvarFormData.IsNullable = true;
				colvarFormData.IsPrimaryKey = false;
				colvarFormData.IsForeignKey = false;
				colvarFormData.IsReadOnly = false;
				colvarFormData.DefaultSetting = @"";
				colvarFormData.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFormData);
				
				TableSchema.TableColumn colvarQueryStringData = new TableSchema.TableColumn(schema);
				colvarQueryStringData.ColumnName = "QueryStringData";
				colvarQueryStringData.DataType = DbType.String;
				colvarQueryStringData.MaxLength = 512;
				colvarQueryStringData.AutoIncrement = false;
				colvarQueryStringData.IsNullable = true;
				colvarQueryStringData.IsPrimaryKey = false;
				colvarQueryStringData.IsForeignKey = false;
				colvarQueryStringData.IsReadOnly = false;
				colvarQueryStringData.DefaultSetting = @"";
				colvarQueryStringData.ForeignKeyTableName = "";
				schema.Columns.Add(colvarQueryStringData);
				
				TableSchema.TableColumn colvarCookiesData = new TableSchema.TableColumn(schema);
				colvarCookiesData.ColumnName = "CookiesData";
				colvarCookiesData.DataType = DbType.String;
				colvarCookiesData.MaxLength = 2048;
				colvarCookiesData.AutoIncrement = false;
				colvarCookiesData.IsNullable = true;
				colvarCookiesData.IsPrimaryKey = false;
				colvarCookiesData.IsForeignKey = false;
				colvarCookiesData.IsReadOnly = false;
				colvarCookiesData.DefaultSetting = @"";
				colvarCookiesData.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCookiesData);
				
				TableSchema.TableColumn colvarExceptionType = new TableSchema.TableColumn(schema);
				colvarExceptionType.ColumnName = "ExceptionType";
				colvarExceptionType.DataType = DbType.String;
				colvarExceptionType.MaxLength = 256;
				colvarExceptionType.AutoIncrement = false;
				colvarExceptionType.IsNullable = true;
				colvarExceptionType.IsPrimaryKey = false;
				colvarExceptionType.IsForeignKey = false;
				colvarExceptionType.IsReadOnly = false;
				colvarExceptionType.DefaultSetting = @"";
				colvarExceptionType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExceptionType);
				
				TableSchema.TableColumn colvarScriptName = new TableSchema.TableColumn(schema);
				colvarScriptName.ColumnName = "ScriptName";
				colvarScriptName.DataType = DbType.String;
				colvarScriptName.MaxLength = 256;
				colvarScriptName.AutoIncrement = false;
				colvarScriptName.IsNullable = true;
				colvarScriptName.IsPrimaryKey = false;
				colvarScriptName.IsForeignKey = false;
				colvarScriptName.IsReadOnly = false;
				colvarScriptName.DefaultSetting = @"";
				colvarScriptName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarScriptName);
				
				TableSchema.TableColumn colvarExceptionMessage = new TableSchema.TableColumn(schema);
				colvarExceptionMessage.ColumnName = "ExceptionMessage";
				colvarExceptionMessage.DataType = DbType.String;
				colvarExceptionMessage.MaxLength = 512;
				colvarExceptionMessage.AutoIncrement = false;
				colvarExceptionMessage.IsNullable = true;
				colvarExceptionMessage.IsPrimaryKey = false;
				colvarExceptionMessage.IsForeignKey = false;
				colvarExceptionMessage.IsReadOnly = false;
				colvarExceptionMessage.DefaultSetting = @"";
				colvarExceptionMessage.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExceptionMessage);
				
				TableSchema.TableColumn colvarExceptionSource = new TableSchema.TableColumn(schema);
				colvarExceptionSource.ColumnName = "ExceptionSource";
				colvarExceptionSource.DataType = DbType.String;
				colvarExceptionSource.MaxLength = 256;
				colvarExceptionSource.AutoIncrement = false;
				colvarExceptionSource.IsNullable = true;
				colvarExceptionSource.IsPrimaryKey = false;
				colvarExceptionSource.IsForeignKey = false;
				colvarExceptionSource.IsReadOnly = false;
				colvarExceptionSource.DefaultSetting = @"";
				colvarExceptionSource.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExceptionSource);
				
				TableSchema.TableColumn colvarExceptionStackTrace = new TableSchema.TableColumn(schema);
				colvarExceptionStackTrace.ColumnName = "ExceptionStackTrace";
				colvarExceptionStackTrace.DataType = DbType.String;
				colvarExceptionStackTrace.MaxLength = 2048;
				colvarExceptionStackTrace.AutoIncrement = false;
				colvarExceptionStackTrace.IsNullable = true;
				colvarExceptionStackTrace.IsPrimaryKey = false;
				colvarExceptionStackTrace.IsForeignKey = false;
				colvarExceptionStackTrace.IsReadOnly = false;
				colvarExceptionStackTrace.DefaultSetting = @"";
				colvarExceptionStackTrace.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExceptionStackTrace);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Core_Log",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("LogID")]
		public int LogID 
		{
			get { return GetColumnValue<int>("LogID"); }

			set { SetColumnValue("LogID", value); }

		}

		  
		[XmlAttribute("LogDate")]
		public DateTime LogDate 
		{
			get { return GetColumnValue<DateTime>("LogDate"); }

			set { SetColumnValue("LogDate", value); }

		}

		  
		[XmlAttribute("Message")]
		public string Message 
		{
			get { return GetColumnValue<string>("Message"); }

			set { SetColumnValue("Message", value); }

		}

		  
		[XmlAttribute("MessageType")]
		public byte MessageType 
		{
			get { return GetColumnValue<byte>("MessageType"); }

			set { SetColumnValue("MessageType", value); }

		}

		  
		[XmlAttribute("UserAgent")]
		public string UserAgent 
		{
			get { return GetColumnValue<string>("UserAgent"); }

			set { SetColumnValue("UserAgent", value); }

		}

		  
		[XmlAttribute("RemoteHost")]
		public string RemoteHost 
		{
			get { return GetColumnValue<string>("RemoteHost"); }

			set { SetColumnValue("RemoteHost", value); }

		}

		  
		[XmlAttribute("AuthUser")]
		public string AuthUser 
		{
			get { return GetColumnValue<string>("AuthUser"); }

			set { SetColumnValue("AuthUser", value); }

		}

		  
		[XmlAttribute("Referer")]
		public string Referer 
		{
			get { return GetColumnValue<string>("Referer"); }

			set { SetColumnValue("Referer", value); }

		}

		  
		[XmlAttribute("MachineName")]
		public string MachineName 
		{
			get { return GetColumnValue<string>("MachineName"); }

			set { SetColumnValue("MachineName", value); }

		}

		  
		[XmlAttribute("FormData")]
		public string FormData 
		{
			get { return GetColumnValue<string>("FormData"); }

			set { SetColumnValue("FormData", value); }

		}

		  
		[XmlAttribute("QueryStringData")]
		public string QueryStringData 
		{
			get { return GetColumnValue<string>("QueryStringData"); }

			set { SetColumnValue("QueryStringData", value); }

		}

		  
		[XmlAttribute("CookiesData")]
		public string CookiesData 
		{
			get { return GetColumnValue<string>("CookiesData"); }

			set { SetColumnValue("CookiesData", value); }

		}

		  
		[XmlAttribute("ExceptionType")]
		public string ExceptionType 
		{
			get { return GetColumnValue<string>("ExceptionType"); }

			set { SetColumnValue("ExceptionType", value); }

		}

		  
		[XmlAttribute("ScriptName")]
		public string ScriptName 
		{
			get { return GetColumnValue<string>("ScriptName"); }

			set { SetColumnValue("ScriptName", value); }

		}

		  
		[XmlAttribute("ExceptionMessage")]
		public string ExceptionMessage 
		{
			get { return GetColumnValue<string>("ExceptionMessage"); }

			set { SetColumnValue("ExceptionMessage", value); }

		}

		  
		[XmlAttribute("ExceptionSource")]
		public string ExceptionSource 
		{
			get { return GetColumnValue<string>("ExceptionSource"); }

			set { SetColumnValue("ExceptionSource", value); }

		}

		  
		[XmlAttribute("ExceptionStackTrace")]
		public string ExceptionStackTrace 
		{
			get { return GetColumnValue<string>("ExceptionStackTrace"); }

			set { SetColumnValue("ExceptionStackTrace", value); }

		}

		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(DateTime varLogDate,string varMessage,byte varMessageType,string varUserAgent,string varRemoteHost,string varAuthUser,string varReferer,string varMachineName,string varFormData,string varQueryStringData,string varCookiesData,string varExceptionType,string varScriptName,string varExceptionMessage,string varExceptionSource,string varExceptionStackTrace)
		{
			Log item = new Log();
			
			item.LogDate = varLogDate;
			
			item.Message = varMessage;
			
			item.MessageType = varMessageType;
			
			item.UserAgent = varUserAgent;
			
			item.RemoteHost = varRemoteHost;
			
			item.AuthUser = varAuthUser;
			
			item.Referer = varReferer;
			
			item.MachineName = varMachineName;
			
			item.FormData = varFormData;
			
			item.QueryStringData = varQueryStringData;
			
			item.CookiesData = varCookiesData;
			
			item.ExceptionType = varExceptionType;
			
			item.ScriptName = varScriptName;
			
			item.ExceptionMessage = varExceptionMessage;
			
			item.ExceptionSource = varExceptionSource;
			
			item.ExceptionStackTrace = varExceptionStackTrace;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varLogID,DateTime varLogDate,string varMessage,byte varMessageType,string varUserAgent,string varRemoteHost,string varAuthUser,string varReferer,string varMachineName,string varFormData,string varQueryStringData,string varCookiesData,string varExceptionType,string varScriptName,string varExceptionMessage,string varExceptionSource,string varExceptionStackTrace)
		{
			Log item = new Log();
			
				item.LogID = varLogID;
				
				item.LogDate = varLogDate;
				
				item.Message = varMessage;
				
				item.MessageType = varMessageType;
				
				item.UserAgent = varUserAgent;
				
				item.RemoteHost = varRemoteHost;
				
				item.AuthUser = varAuthUser;
				
				item.Referer = varReferer;
				
				item.MachineName = varMachineName;
				
				item.FormData = varFormData;
				
				item.QueryStringData = varQueryStringData;
				
				item.CookiesData = varCookiesData;
				
				item.ExceptionType = varExceptionType;
				
				item.ScriptName = varScriptName;
				
				item.ExceptionMessage = varExceptionMessage;
				
				item.ExceptionSource = varExceptionSource;
				
				item.ExceptionStackTrace = varExceptionStackTrace;
				
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		#endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string LogID = @"LogID";
			 public static string LogDate = @"LogDate";
			 public static string Message = @"Message";
			 public static string MessageType = @"MessageType";
			 public static string UserAgent = @"UserAgent";
			 public static string RemoteHost = @"RemoteHost";
			 public static string AuthUser = @"AuthUser";
			 public static string Referer = @"Referer";
			 public static string MachineName = @"MachineName";
			 public static string FormData = @"FormData";
			 public static string QueryStringData = @"QueryStringData";
			 public static string CookiesData = @"CookiesData";
			 public static string ExceptionType = @"ExceptionType";
			 public static string ScriptName = @"ScriptName";
			 public static string ExceptionMessage = @"ExceptionMessage";
			 public static string ExceptionSource = @"ExceptionSource";
			 public static string ExceptionStackTrace = @"ExceptionStackTrace";
						
		}

		#endregion
	}

}

