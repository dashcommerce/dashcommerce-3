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
	/// Strongly-typed collection for the BrowsingLog class.
	/// </summary>
	[Serializable]
	public partial class BrowsingLogCollection : ActiveList<BrowsingLog, BrowsingLogCollection> 
	{	   
		public BrowsingLogCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_Browsing_Log table.
	/// </summary>
	[Serializable]
	public partial class BrowsingLog : ActiveRecord<BrowsingLog>
	{
		#region .ctors and Default Settings
		
		public BrowsingLog()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public BrowsingLog(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public BrowsingLog(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public BrowsingLog(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_Browsing_Log", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarBrowsingLogId = new TableSchema.TableColumn(schema);
				colvarBrowsingLogId.ColumnName = "BrowsingLogId";
				colvarBrowsingLogId.DataType = DbType.Int32;
				colvarBrowsingLogId.MaxLength = 0;
				colvarBrowsingLogId.AutoIncrement = true;
				colvarBrowsingLogId.IsNullable = false;
				colvarBrowsingLogId.IsPrimaryKey = true;
				colvarBrowsingLogId.IsForeignKey = false;
				colvarBrowsingLogId.IsReadOnly = false;
				colvarBrowsingLogId.DefaultSetting = @"";
				colvarBrowsingLogId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBrowsingLogId);
				
				TableSchema.TableColumn colvarBrowsingBehaviorId = new TableSchema.TableColumn(schema);
				colvarBrowsingBehaviorId.ColumnName = "BrowsingBehaviorId";
				colvarBrowsingBehaviorId.DataType = DbType.Int32;
				colvarBrowsingBehaviorId.MaxLength = 0;
				colvarBrowsingBehaviorId.AutoIncrement = false;
				colvarBrowsingBehaviorId.IsNullable = false;
				colvarBrowsingBehaviorId.IsPrimaryKey = false;
				colvarBrowsingBehaviorId.IsForeignKey = false;
				colvarBrowsingBehaviorId.IsReadOnly = false;
				colvarBrowsingBehaviorId.DefaultSetting = @"";
				colvarBrowsingBehaviorId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBrowsingBehaviorId);
				
				TableSchema.TableColumn colvarRelevantId = new TableSchema.TableColumn(schema);
				colvarRelevantId.ColumnName = "RelevantId";
				colvarRelevantId.DataType = DbType.Int32;
				colvarRelevantId.MaxLength = 0;
				colvarRelevantId.AutoIncrement = false;
				colvarRelevantId.IsNullable = true;
				colvarRelevantId.IsPrimaryKey = false;
				colvarRelevantId.IsForeignKey = false;
				colvarRelevantId.IsReadOnly = false;
				colvarRelevantId.DefaultSetting = @"";
				colvarRelevantId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRelevantId);
				
				TableSchema.TableColumn colvarUserName = new TableSchema.TableColumn(schema);
				colvarUserName.ColumnName = "UserName";
				colvarUserName.DataType = DbType.String;
				colvarUserName.MaxLength = 50;
				colvarUserName.AutoIncrement = false;
				colvarUserName.IsNullable = false;
				colvarUserName.IsPrimaryKey = false;
				colvarUserName.IsForeignKey = false;
				colvarUserName.IsReadOnly = false;
				colvarUserName.DefaultSetting = @"";
				colvarUserName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserName);
				
				TableSchema.TableColumn colvarUrl = new TableSchema.TableColumn(schema);
				colvarUrl.ColumnName = "Url";
				colvarUrl.DataType = DbType.String;
				colvarUrl.MaxLength = 255;
				colvarUrl.AutoIncrement = false;
				colvarUrl.IsNullable = true;
				colvarUrl.IsPrimaryKey = false;
				colvarUrl.IsForeignKey = false;
				colvarUrl.IsReadOnly = false;
				colvarUrl.DefaultSetting = @"";
				colvarUrl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUrl);
				
				TableSchema.TableColumn colvarSearchTerms = new TableSchema.TableColumn(schema);
				colvarSearchTerms.ColumnName = "SearchTerms";
				colvarSearchTerms.DataType = DbType.String;
				colvarSearchTerms.MaxLength = 150;
				colvarSearchTerms.AutoIncrement = false;
				colvarSearchTerms.IsNullable = true;
				colvarSearchTerms.IsPrimaryKey = false;
				colvarSearchTerms.IsForeignKey = false;
				colvarSearchTerms.IsReadOnly = false;
				colvarSearchTerms.DefaultSetting = @"";
				colvarSearchTerms.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSearchTerms);
				
				TableSchema.TableColumn colvarSessionId = new TableSchema.TableColumn(schema);
				colvarSessionId.ColumnName = "SessionId";
				colvarSessionId.DataType = DbType.String;
				colvarSessionId.MaxLength = 50;
				colvarSessionId.AutoIncrement = false;
				colvarSessionId.IsNullable = true;
				colvarSessionId.IsPrimaryKey = false;
				colvarSessionId.IsForeignKey = false;
				colvarSessionId.IsReadOnly = false;
				colvarSessionId.DefaultSetting = @"";
				colvarSessionId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSessionId);
				
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
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_Browsing_Log",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("BrowsingLogId")]
		public int BrowsingLogId 
		{
			get { return GetColumnValue<int>("BrowsingLogId"); }

			set { SetColumnValue("BrowsingLogId", value); }

		}

		  
		[XmlAttribute("BrowsingBehaviorId")]
		public int BrowsingBehaviorId 
		{
			get { return GetColumnValue<int>("BrowsingBehaviorId"); }

			set { SetColumnValue("BrowsingBehaviorId", value); }

		}

		  
		[XmlAttribute("RelevantId")]
		public int? RelevantId 
		{
			get { return GetColumnValue<int?>("RelevantId"); }

			set { SetColumnValue("RelevantId", value); }

		}

		  
		[XmlAttribute("UserName")]
		public string UserName 
		{
			get { return GetColumnValue<string>("UserName"); }

			set { SetColumnValue("UserName", value); }

		}

		  
		[XmlAttribute("Url")]
		public string Url 
		{
			get { return GetColumnValue<string>("Url"); }

			set { SetColumnValue("Url", value); }

		}

		  
		[XmlAttribute("SearchTerms")]
		public string SearchTerms 
		{
			get { return GetColumnValue<string>("SearchTerms"); }

			set { SetColumnValue("SearchTerms", value); }

		}

		  
		[XmlAttribute("SessionId")]
		public string SessionId 
		{
			get { return GetColumnValue<string>("SessionId"); }

			set { SetColumnValue("SessionId", value); }

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
		public static void Insert(int varBrowsingBehaviorId,int? varRelevantId,string varUserName,string varUrl,string varSearchTerms,string varSessionId,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			BrowsingLog item = new BrowsingLog();
			
			item.BrowsingBehaviorId = varBrowsingBehaviorId;
			
			item.RelevantId = varRelevantId;
			
			item.UserName = varUserName;
			
			item.Url = varUrl;
			
			item.SearchTerms = varSearchTerms;
			
			item.SessionId = varSessionId;
			
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
		public static void Update(int varBrowsingLogId,int varBrowsingBehaviorId,int? varRelevantId,string varUserName,string varUrl,string varSearchTerms,string varSessionId,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			BrowsingLog item = new BrowsingLog();
			
				item.BrowsingLogId = varBrowsingLogId;
				
				item.BrowsingBehaviorId = varBrowsingBehaviorId;
				
				item.RelevantId = varRelevantId;
				
				item.UserName = varUserName;
				
				item.Url = varUrl;
				
				item.SearchTerms = varSearchTerms;
				
				item.SessionId = varSessionId;
				
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
			 public static string BrowsingLogId = @"BrowsingLogId";
			 public static string BrowsingBehaviorId = @"BrowsingBehaviorId";
			 public static string RelevantId = @"RelevantId";
			 public static string UserName = @"UserName";
			 public static string Url = @"Url";
			 public static string SearchTerms = @"SearchTerms";
			 public static string SessionId = @"SessionId";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}

		#endregion
	}

}

