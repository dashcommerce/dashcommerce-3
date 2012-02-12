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
	/// Strongly-typed collection for the ConfigurationDatum class.
	/// </summary>
	[Serializable]
	public partial class ConfigurationDatumCollection : ActiveList<ConfigurationDatum, ConfigurationDatumCollection> 
	{	   
		public ConfigurationDatumCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Core_ConfigurationData table.
	/// </summary>
	[Serializable]
	public partial class ConfigurationDatum : ActiveRecord<ConfigurationDatum>
	{
		#region .ctors and Default Settings
		
		public ConfigurationDatum()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public ConfigurationDatum(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public ConfigurationDatum(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public ConfigurationDatum(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Core_ConfigurationData", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarConfigurationDataId = new TableSchema.TableColumn(schema);
				colvarConfigurationDataId.ColumnName = "ConfigurationDataId";
				colvarConfigurationDataId.DataType = DbType.Int32;
				colvarConfigurationDataId.MaxLength = 0;
				colvarConfigurationDataId.AutoIncrement = true;
				colvarConfigurationDataId.IsNullable = false;
				colvarConfigurationDataId.IsPrimaryKey = true;
				colvarConfigurationDataId.IsForeignKey = false;
				colvarConfigurationDataId.IsReadOnly = false;
				colvarConfigurationDataId.DefaultSetting = @"";
				colvarConfigurationDataId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarConfigurationDataId);
				
				TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
				colvarName.ColumnName = "Name";
				colvarName.DataType = DbType.String;
				colvarName.MaxLength = 100;
				colvarName.AutoIncrement = false;
				colvarName.IsNullable = false;
				colvarName.IsPrimaryKey = false;
				colvarName.IsForeignKey = false;
				colvarName.IsReadOnly = false;
				colvarName.DefaultSetting = @"";
				colvarName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarName);
				
				TableSchema.TableColumn colvarType = new TableSchema.TableColumn(schema);
				colvarType.ColumnName = "Type";
				colvarType.DataType = DbType.String;
				colvarType.MaxLength = 300;
				colvarType.AutoIncrement = false;
				colvarType.IsNullable = false;
				colvarType.IsPrimaryKey = false;
				colvarType.IsForeignKey = false;
				colvarType.IsReadOnly = false;
				colvarType.DefaultSetting = @"";
				colvarType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarType);
				
				TableSchema.TableColumn colvarValueX = new TableSchema.TableColumn(schema);
				colvarValueX.ColumnName = "Value";
				colvarValueX.DataType = DbType.String;
				colvarValueX.MaxLength = 1073741823;
				colvarValueX.AutoIncrement = false;
				colvarValueX.IsNullable = false;
				colvarValueX.IsPrimaryKey = false;
				colvarValueX.IsForeignKey = false;
				colvarValueX.IsReadOnly = false;
				colvarValueX.DefaultSetting = @"";
				colvarValueX.ForeignKeyTableName = "";
				schema.Columns.Add(colvarValueX);
				
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
				
				TableSchema.TableColumn colvarCreatedDate = new TableSchema.TableColumn(schema);
				colvarCreatedDate.ColumnName = "CreatedDate";
				colvarCreatedDate.DataType = DbType.DateTime;
				colvarCreatedDate.MaxLength = 0;
				colvarCreatedDate.AutoIncrement = false;
				colvarCreatedDate.IsNullable = false;
				colvarCreatedDate.IsPrimaryKey = false;
				colvarCreatedDate.IsForeignKey = false;
				colvarCreatedDate.IsReadOnly = false;
				
						colvarCreatedDate.DefaultSetting = @"(getutcdate())";
				colvarCreatedDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedDate);
				
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
				
				TableSchema.TableColumn colvarModifiedDate = new TableSchema.TableColumn(schema);
				colvarModifiedDate.ColumnName = "ModifiedDate";
				colvarModifiedDate.DataType = DbType.DateTime;
				colvarModifiedDate.MaxLength = 0;
				colvarModifiedDate.AutoIncrement = false;
				colvarModifiedDate.IsNullable = false;
				colvarModifiedDate.IsPrimaryKey = false;
				colvarModifiedDate.IsForeignKey = false;
				colvarModifiedDate.IsReadOnly = false;
				
						colvarModifiedDate.DefaultSetting = @"(getutcdate())";
				colvarModifiedDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedDate);
				
				TableSchema.TableColumn colvarIsDeleted = new TableSchema.TableColumn(schema);
				colvarIsDeleted.ColumnName = "IsDeleted";
				colvarIsDeleted.DataType = DbType.Boolean;
				colvarIsDeleted.MaxLength = 0;
				colvarIsDeleted.AutoIncrement = false;
				colvarIsDeleted.IsNullable = false;
				colvarIsDeleted.IsPrimaryKey = false;
				colvarIsDeleted.IsForeignKey = false;
				colvarIsDeleted.IsReadOnly = false;
				colvarIsDeleted.DefaultSetting = @"";
				colvarIsDeleted.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsDeleted);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Core_ConfigurationData",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("ConfigurationDataId")]
		public int ConfigurationDataId 
		{
			get { return GetColumnValue<int>("ConfigurationDataId"); }

			set { SetColumnValue("ConfigurationDataId", value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>("Name"); }

			set { SetColumnValue("Name", value); }

		}

		  
		[XmlAttribute("Type")]
		public string Type 
		{
			get { return GetColumnValue<string>("Type"); }

			set { SetColumnValue("Type", value); }

		}

		  
		[XmlAttribute("ValueX")]
		public string ValueX 
		{
			get { return GetColumnValue<string>("Value"); }

			set { SetColumnValue("Value", value); }

		}

		  
		[XmlAttribute("CreatedBy")]
		public string CreatedBy 
		{
			get { return GetColumnValue<string>("CreatedBy"); }

			set { SetColumnValue("CreatedBy", value); }

		}

		  
		[XmlAttribute("CreatedDate")]
		public DateTime CreatedDate 
		{
			get { return GetColumnValue<DateTime>("CreatedDate"); }

			set { SetColumnValue("CreatedDate", value); }

		}

		  
		[XmlAttribute("ModifiedBy")]
		public string ModifiedBy 
		{
			get { return GetColumnValue<string>("ModifiedBy"); }

			set { SetColumnValue("ModifiedBy", value); }

		}

		  
		[XmlAttribute("ModifiedDate")]
		public DateTime ModifiedDate 
		{
			get { return GetColumnValue<DateTime>("ModifiedDate"); }

			set { SetColumnValue("ModifiedDate", value); }

		}

		  
		[XmlAttribute("IsDeleted")]
		public bool IsDeleted 
		{
			get { return GetColumnValue<bool>("IsDeleted"); }

			set { SetColumnValue("IsDeleted", value); }

		}

		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,string varType,string varValueX,string varCreatedBy,DateTime varCreatedDate,string varModifiedBy,DateTime varModifiedDate,bool varIsDeleted)
		{
			ConfigurationDatum item = new ConfigurationDatum();
			
			item.Name = varName;
			
			item.Type = varType;
			
			item.ValueX = varValueX;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedDate = varCreatedDate;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedDate = varModifiedDate;
			
			item.IsDeleted = varIsDeleted;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varConfigurationDataId,string varName,string varType,string varValueX,string varCreatedBy,DateTime varCreatedDate,string varModifiedBy,DateTime varModifiedDate,bool varIsDeleted)
		{
			ConfigurationDatum item = new ConfigurationDatum();
			
				item.ConfigurationDataId = varConfigurationDataId;
				
				item.Name = varName;
				
				item.Type = varType;
				
				item.ValueX = varValueX;
				
				item.CreatedBy = varCreatedBy;
				
				item.CreatedDate = varCreatedDate;
				
				item.ModifiedBy = varModifiedBy;
				
				item.ModifiedDate = varModifiedDate;
				
				item.IsDeleted = varIsDeleted;
				
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
			 public static string ConfigurationDataId = @"ConfigurationDataId";
			 public static string Name = @"Name";
			 public static string Type = @"Type";
			 public static string ValueX = @"Value";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedDate = @"CreatedDate";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedDate = @"ModifiedDate";
			 public static string IsDeleted = @"IsDeleted";
						
		}

		#endregion
	}

}

