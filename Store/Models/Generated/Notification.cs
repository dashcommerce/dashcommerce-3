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
	/// Strongly-typed collection for the Notification class.
	/// </summary>
	[Serializable]
	public partial class NotificationCollection : ActiveList<Notification, NotificationCollection> 
	{	   
		public NotificationCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_Notification table.
	/// </summary>
	[Serializable]
	public partial class Notification : ActiveRecord<Notification>
	{
		#region .ctors and Default Settings
		
		public Notification()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Notification(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Notification(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Notification(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_Notification", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarNotificationId = new TableSchema.TableColumn(schema);
				colvarNotificationId.ColumnName = "NotificationId";
				colvarNotificationId.DataType = DbType.Int32;
				colvarNotificationId.MaxLength = 0;
				colvarNotificationId.AutoIncrement = true;
				colvarNotificationId.IsNullable = false;
				colvarNotificationId.IsPrimaryKey = true;
				colvarNotificationId.IsForeignKey = false;
				colvarNotificationId.IsReadOnly = false;
				colvarNotificationId.DefaultSetting = @"";
				colvarNotificationId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNotificationId);
				
				TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
				colvarName.ColumnName = "Name";
				colvarName.DataType = DbType.String;
				colvarName.MaxLength = 50;
				colvarName.AutoIncrement = false;
				colvarName.IsNullable = false;
				colvarName.IsPrimaryKey = false;
				colvarName.IsForeignKey = false;
				colvarName.IsReadOnly = false;
				colvarName.DefaultSetting = @"";
				colvarName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarName);
				
				TableSchema.TableColumn colvarToList = new TableSchema.TableColumn(schema);
				colvarToList.ColumnName = "ToList";
				colvarToList.DataType = DbType.String;
				colvarToList.MaxLength = 500;
				colvarToList.AutoIncrement = false;
				colvarToList.IsNullable = true;
				colvarToList.IsPrimaryKey = false;
				colvarToList.IsForeignKey = false;
				colvarToList.IsReadOnly = false;
				colvarToList.DefaultSetting = @"";
				colvarToList.ForeignKeyTableName = "";
				schema.Columns.Add(colvarToList);
				
				TableSchema.TableColumn colvarCcList = new TableSchema.TableColumn(schema);
				colvarCcList.ColumnName = "CcList";
				colvarCcList.DataType = DbType.String;
				colvarCcList.MaxLength = 500;
				colvarCcList.AutoIncrement = false;
				colvarCcList.IsNullable = true;
				colvarCcList.IsPrimaryKey = false;
				colvarCcList.IsForeignKey = false;
				colvarCcList.IsReadOnly = false;
				colvarCcList.DefaultSetting = @"";
				colvarCcList.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCcList);
				
				TableSchema.TableColumn colvarFromName = new TableSchema.TableColumn(schema);
				colvarFromName.ColumnName = "FromName";
				colvarFromName.DataType = DbType.String;
				colvarFromName.MaxLength = 50;
				colvarFromName.AutoIncrement = false;
				colvarFromName.IsNullable = false;
				colvarFromName.IsPrimaryKey = false;
				colvarFromName.IsForeignKey = false;
				colvarFromName.IsReadOnly = false;
				colvarFromName.DefaultSetting = @"";
				colvarFromName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFromName);
				
				TableSchema.TableColumn colvarFromEmail = new TableSchema.TableColumn(schema);
				colvarFromEmail.ColumnName = "FromEmail";
				colvarFromEmail.DataType = DbType.String;
				colvarFromEmail.MaxLength = 50;
				colvarFromEmail.AutoIncrement = false;
				colvarFromEmail.IsNullable = false;
				colvarFromEmail.IsPrimaryKey = false;
				colvarFromEmail.IsForeignKey = false;
				colvarFromEmail.IsReadOnly = false;
				colvarFromEmail.DefaultSetting = @"";
				colvarFromEmail.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFromEmail);
				
				TableSchema.TableColumn colvarSubject = new TableSchema.TableColumn(schema);
				colvarSubject.ColumnName = "Subject";
				colvarSubject.DataType = DbType.String;
				colvarSubject.MaxLength = 50;
				colvarSubject.AutoIncrement = false;
				colvarSubject.IsNullable = false;
				colvarSubject.IsPrimaryKey = false;
				colvarSubject.IsForeignKey = false;
				colvarSubject.IsReadOnly = false;
				colvarSubject.DefaultSetting = @"";
				colvarSubject.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSubject);
				
				TableSchema.TableColumn colvarNotificationBody = new TableSchema.TableColumn(schema);
				colvarNotificationBody.ColumnName = "NotificationBody";
				colvarNotificationBody.DataType = DbType.String;
				colvarNotificationBody.MaxLength = 1073741823;
				colvarNotificationBody.AutoIncrement = false;
				colvarNotificationBody.IsNullable = false;
				colvarNotificationBody.IsPrimaryKey = false;
				colvarNotificationBody.IsForeignKey = false;
				colvarNotificationBody.IsReadOnly = false;
				colvarNotificationBody.DefaultSetting = @"";
				colvarNotificationBody.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNotificationBody);
				
				TableSchema.TableColumn colvarIsHTML = new TableSchema.TableColumn(schema);
				colvarIsHTML.ColumnName = "IsHTML";
				colvarIsHTML.DataType = DbType.Boolean;
				colvarIsHTML.MaxLength = 0;
				colvarIsHTML.AutoIncrement = false;
				colvarIsHTML.IsNullable = false;
				colvarIsHTML.IsPrimaryKey = false;
				colvarIsHTML.IsForeignKey = false;
				colvarIsHTML.IsReadOnly = false;
				
						colvarIsHTML.DefaultSetting = @"((0))";
				colvarIsHTML.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsHTML);
				
				TableSchema.TableColumn colvarIsSystemNotification = new TableSchema.TableColumn(schema);
				colvarIsSystemNotification.ColumnName = "IsSystemNotification";
				colvarIsSystemNotification.DataType = DbType.Boolean;
				colvarIsSystemNotification.MaxLength = 0;
				colvarIsSystemNotification.AutoIncrement = false;
				colvarIsSystemNotification.IsNullable = false;
				colvarIsSystemNotification.IsPrimaryKey = false;
				colvarIsSystemNotification.IsForeignKey = false;
				colvarIsSystemNotification.IsReadOnly = false;
				
						colvarIsSystemNotification.DefaultSetting = @"((0))";
				colvarIsSystemNotification.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsSystemNotification);
				
				TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
				colvarCreatedBy.ColumnName = "CreatedBy";
				colvarCreatedBy.DataType = DbType.String;
				colvarCreatedBy.MaxLength = 50;
				colvarCreatedBy.AutoIncrement = false;
				colvarCreatedBy.IsNullable = true;
				colvarCreatedBy.IsPrimaryKey = false;
				colvarCreatedBy.IsForeignKey = false;
				colvarCreatedBy.IsReadOnly = false;
				colvarCreatedBy.DefaultSetting = @"";
				colvarCreatedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedBy);
				
				TableSchema.TableColumn colvarCreatedOn = new TableSchema.TableColumn(schema);
				colvarCreatedOn.ColumnName = "CreatedOn";
				colvarCreatedOn.DataType = DbType.DateTime;
				colvarCreatedOn.MaxLength = 0;
				colvarCreatedOn.AutoIncrement = false;
				colvarCreatedOn.IsNullable = false;
				colvarCreatedOn.IsPrimaryKey = false;
				colvarCreatedOn.IsForeignKey = false;
				colvarCreatedOn.IsReadOnly = false;
				
						colvarCreatedOn.DefaultSetting = @"(getutcdate())";
				colvarCreatedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedOn);
				
				TableSchema.TableColumn colvarModifiedBy = new TableSchema.TableColumn(schema);
				colvarModifiedBy.ColumnName = "ModifiedBy";
				colvarModifiedBy.DataType = DbType.String;
				colvarModifiedBy.MaxLength = 50;
				colvarModifiedBy.AutoIncrement = false;
				colvarModifiedBy.IsNullable = true;
				colvarModifiedBy.IsPrimaryKey = false;
				colvarModifiedBy.IsForeignKey = false;
				colvarModifiedBy.IsReadOnly = false;
				colvarModifiedBy.DefaultSetting = @"";
				colvarModifiedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedBy);
				
				TableSchema.TableColumn colvarModifiedOn = new TableSchema.TableColumn(schema);
				colvarModifiedOn.ColumnName = "ModifiedOn";
				colvarModifiedOn.DataType = DbType.DateTime;
				colvarModifiedOn.MaxLength = 0;
				colvarModifiedOn.AutoIncrement = false;
				colvarModifiedOn.IsNullable = false;
				colvarModifiedOn.IsPrimaryKey = false;
				colvarModifiedOn.IsForeignKey = false;
				colvarModifiedOn.IsReadOnly = false;
				
						colvarModifiedOn.DefaultSetting = @"(getutcdate())";
				colvarModifiedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedOn);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_Notification",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("NotificationId")]
		public int NotificationId 
		{
			get { return GetColumnValue<int>("NotificationId"); }

			set { SetColumnValue("NotificationId", value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>("Name"); }

			set { SetColumnValue("Name", value); }

		}

		  
		[XmlAttribute("ToList")]
		public string ToList 
		{
			get { return GetColumnValue<string>("ToList"); }

			set { SetColumnValue("ToList", value); }

		}

		  
		[XmlAttribute("CcList")]
		public string CcList 
		{
			get { return GetColumnValue<string>("CcList"); }

			set { SetColumnValue("CcList", value); }

		}

		  
		[XmlAttribute("FromName")]
		public string FromName 
		{
			get { return GetColumnValue<string>("FromName"); }

			set { SetColumnValue("FromName", value); }

		}

		  
		[XmlAttribute("FromEmail")]
		public string FromEmail 
		{
			get { return GetColumnValue<string>("FromEmail"); }

			set { SetColumnValue("FromEmail", value); }

		}

		  
		[XmlAttribute("Subject")]
		public string Subject 
		{
			get { return GetColumnValue<string>("Subject"); }

			set { SetColumnValue("Subject", value); }

		}

		  
		[XmlAttribute("NotificationBody")]
		public string NotificationBody 
		{
			get { return GetColumnValue<string>("NotificationBody"); }

			set { SetColumnValue("NotificationBody", value); }

		}

		  
		[XmlAttribute("IsHTML")]
		public bool IsHTML 
		{
			get { return GetColumnValue<bool>("IsHTML"); }

			set { SetColumnValue("IsHTML", value); }

		}

		  
		[XmlAttribute("IsSystemNotification")]
		public bool IsSystemNotification 
		{
			get { return GetColumnValue<bool>("IsSystemNotification"); }

			set { SetColumnValue("IsSystemNotification", value); }

		}

		  
		[XmlAttribute("CreatedBy")]
		public string CreatedBy 
		{
			get { return GetColumnValue<string>("CreatedBy"); }

			set { SetColumnValue("CreatedBy", value); }

		}

		  
		[XmlAttribute("CreatedOn")]
		public DateTime CreatedOn 
		{
			get { return GetColumnValue<DateTime>("CreatedOn"); }

			set { SetColumnValue("CreatedOn", value); }

		}

		  
		[XmlAttribute("ModifiedBy")]
		public string ModifiedBy 
		{
			get { return GetColumnValue<string>("ModifiedBy"); }

			set { SetColumnValue("ModifiedBy", value); }

		}

		  
		[XmlAttribute("ModifiedOn")]
		public DateTime ModifiedOn 
		{
			get { return GetColumnValue<DateTime>("ModifiedOn"); }

			set { SetColumnValue("ModifiedOn", value); }

		}

		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,string varToList,string varCcList,string varFromName,string varFromEmail,string varSubject,string varNotificationBody,bool varIsHTML,bool varIsSystemNotification,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			Notification item = new Notification();
			
			item.Name = varName;
			
			item.ToList = varToList;
			
			item.CcList = varCcList;
			
			item.FromName = varFromName;
			
			item.FromEmail = varFromEmail;
			
			item.Subject = varSubject;
			
			item.NotificationBody = varNotificationBody;
			
			item.IsHTML = varIsHTML;
			
			item.IsSystemNotification = varIsSystemNotification;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedOn = varModifiedOn;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varNotificationId,string varName,string varToList,string varCcList,string varFromName,string varFromEmail,string varSubject,string varNotificationBody,bool varIsHTML,bool varIsSystemNotification,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			Notification item = new Notification();
			
				item.NotificationId = varNotificationId;
				
				item.Name = varName;
				
				item.ToList = varToList;
				
				item.CcList = varCcList;
				
				item.FromName = varFromName;
				
				item.FromEmail = varFromEmail;
				
				item.Subject = varSubject;
				
				item.NotificationBody = varNotificationBody;
				
				item.IsHTML = varIsHTML;
				
				item.IsSystemNotification = varIsSystemNotification;
				
				item.CreatedBy = varCreatedBy;
				
				item.CreatedOn = varCreatedOn;
				
				item.ModifiedBy = varModifiedBy;
				
				item.ModifiedOn = varModifiedOn;
				
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
			 public static string NotificationId = @"NotificationId";
			 public static string Name = @"Name";
			 public static string ToList = @"ToList";
			 public static string CcList = @"CcList";
			 public static string FromName = @"FromName";
			 public static string FromEmail = @"FromEmail";
			 public static string Subject = @"Subject";
			 public static string NotificationBody = @"NotificationBody";
			 public static string IsHTML = @"IsHTML";
			 public static string IsSystemNotification = @"IsSystemNotification";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}

		#endregion
	}

}

