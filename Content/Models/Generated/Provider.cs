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
	/// Strongly-typed collection for the Provider class.
	/// </summary>
	[Serializable]
	public partial class ProviderCollection : ActiveList<Provider, ProviderCollection> 
	{	   
		public ProviderCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Content_Provider table.
	/// </summary>
	[Serializable]
	public partial class Provider : ActiveRecord<Provider>
	{
		#region .ctors and Default Settings
		
		public Provider()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Provider(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Provider(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Provider(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Content_Provider", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarProviderId = new TableSchema.TableColumn(schema);
				colvarProviderId.ColumnName = "ProviderId";
				colvarProviderId.DataType = DbType.Int32;
				colvarProviderId.MaxLength = 0;
				colvarProviderId.AutoIncrement = true;
				colvarProviderId.IsNullable = false;
				colvarProviderId.IsPrimaryKey = true;
				colvarProviderId.IsForeignKey = false;
				colvarProviderId.IsReadOnly = false;
				colvarProviderId.DefaultSetting = @"";
				colvarProviderId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProviderId);
				
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
				
				TableSchema.TableColumn colvarViewControl = new TableSchema.TableColumn(schema);
				colvarViewControl.ColumnName = "ViewControl";
				colvarViewControl.DataType = DbType.String;
				colvarViewControl.MaxLength = 250;
				colvarViewControl.AutoIncrement = false;
				colvarViewControl.IsNullable = false;
				colvarViewControl.IsPrimaryKey = false;
				colvarViewControl.IsForeignKey = false;
				colvarViewControl.IsReadOnly = false;
				colvarViewControl.DefaultSetting = @"";
				colvarViewControl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarViewControl);
				
				TableSchema.TableColumn colvarEditControl = new TableSchema.TableColumn(schema);
				colvarEditControl.ColumnName = "EditControl";
				colvarEditControl.DataType = DbType.String;
				colvarEditControl.MaxLength = 250;
				colvarEditControl.AutoIncrement = false;
				colvarEditControl.IsNullable = false;
				colvarEditControl.IsPrimaryKey = false;
				colvarEditControl.IsForeignKey = false;
				colvarEditControl.IsReadOnly = false;
				colvarEditControl.DefaultSetting = @"";
				colvarEditControl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEditControl);
				
				TableSchema.TableColumn colvarStyleSheet = new TableSchema.TableColumn(schema);
				colvarStyleSheet.ColumnName = "StyleSheet";
				colvarStyleSheet.DataType = DbType.String;
				colvarStyleSheet.MaxLength = 250;
				colvarStyleSheet.AutoIncrement = false;
				colvarStyleSheet.IsNullable = true;
				colvarStyleSheet.IsPrimaryKey = false;
				colvarStyleSheet.IsForeignKey = false;
				colvarStyleSheet.IsReadOnly = false;
				colvarStyleSheet.DefaultSetting = @"";
				colvarStyleSheet.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStyleSheet);
				
				TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
				colvarCreatedBy.ColumnName = "CreatedBy";
				colvarCreatedBy.DataType = DbType.String;
				colvarCreatedBy.MaxLength = 50;
				colvarCreatedBy.AutoIncrement = false;
				colvarCreatedBy.IsNullable = false;
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
				colvarModifiedBy.IsNullable = false;
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
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Content_Provider",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("ProviderId")]
		public int ProviderId 
		{
			get { return GetColumnValue<int>("ProviderId"); }

			set { SetColumnValue("ProviderId", value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>("Name"); }

			set { SetColumnValue("Name", value); }

		}

		  
		[XmlAttribute("ViewControl")]
		public string ViewControl 
		{
			get { return GetColumnValue<string>("ViewControl"); }

			set { SetColumnValue("ViewControl", value); }

		}

		  
		[XmlAttribute("EditControl")]
		public string EditControl 
		{
			get { return GetColumnValue<string>("EditControl"); }

			set { SetColumnValue("EditControl", value); }

		}

		  
		[XmlAttribute("StyleSheet")]
		public string StyleSheet 
		{
			get { return GetColumnValue<string>("StyleSheet"); }

			set { SetColumnValue("StyleSheet", value); }

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
		public static void Insert(string varName,string varViewControl,string varEditControl,string varStyleSheet,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			Provider item = new Provider();
			
			item.Name = varName;
			
			item.ViewControl = varViewControl;
			
			item.EditControl = varEditControl;
			
			item.StyleSheet = varStyleSheet;
			
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
		public static void Update(int varProviderId,string varName,string varViewControl,string varEditControl,string varStyleSheet,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			Provider item = new Provider();
			
				item.ProviderId = varProviderId;
				
				item.Name = varName;
				
				item.ViewControl = varViewControl;
				
				item.EditControl = varEditControl;
				
				item.StyleSheet = varStyleSheet;
				
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
			 public static string ProviderId = @"ProviderId";
			 public static string Name = @"Name";
			 public static string ViewControl = @"ViewControl";
			 public static string EditControl = @"EditControl";
			 public static string StyleSheet = @"StyleSheet";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}

		#endregion
	}

}

