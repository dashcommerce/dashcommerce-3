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
	/// Strongly-typed collection for the Provider class.
	/// </summary>
	[Serializable]
	public partial class ProviderCollection : ActiveList<Provider, ProviderCollection> 
	{	   
		public ProviderCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_Provider table.
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_Provider", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
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
				
				TableSchema.TableColumn colvarProviderTypeId = new TableSchema.TableColumn(schema);
				colvarProviderTypeId.ColumnName = "ProviderTypeId";
				colvarProviderTypeId.DataType = DbType.Int32;
				colvarProviderTypeId.MaxLength = 0;
				colvarProviderTypeId.AutoIncrement = false;
				colvarProviderTypeId.IsNullable = false;
				colvarProviderTypeId.IsPrimaryKey = false;
				colvarProviderTypeId.IsForeignKey = false;
				colvarProviderTypeId.IsReadOnly = false;
				colvarProviderTypeId.DefaultSetting = @"";
				colvarProviderTypeId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProviderTypeId);
				
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
				
				TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
				colvarDescription.ColumnName = "Description";
				colvarDescription.DataType = DbType.String;
				colvarDescription.MaxLength = -1;
				colvarDescription.AutoIncrement = false;
				colvarDescription.IsNullable = true;
				colvarDescription.IsPrimaryKey = false;
				colvarDescription.IsForeignKey = false;
				colvarDescription.IsReadOnly = false;
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
				TableSchema.TableColumn colvarConfigurationControlPath = new TableSchema.TableColumn(schema);
				colvarConfigurationControlPath.ColumnName = "ConfigurationControlPath";
				colvarConfigurationControlPath.DataType = DbType.String;
				colvarConfigurationControlPath.MaxLength = 255;
				colvarConfigurationControlPath.AutoIncrement = false;
				colvarConfigurationControlPath.IsNullable = false;
				colvarConfigurationControlPath.IsPrimaryKey = false;
				colvarConfigurationControlPath.IsForeignKey = false;
				colvarConfigurationControlPath.IsReadOnly = false;
				colvarConfigurationControlPath.DefaultSetting = @"";
				colvarConfigurationControlPath.ForeignKeyTableName = "";
				schema.Columns.Add(colvarConfigurationControlPath);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_Provider",schema);
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

		  
		[XmlAttribute("ProviderTypeId")]
		public int ProviderTypeId 
		{
			get { return GetColumnValue<int>("ProviderTypeId"); }

			set { SetColumnValue("ProviderTypeId", value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>("Name"); }

			set { SetColumnValue("Name", value); }

		}

		  
		[XmlAttribute("Description")]
		public string Description 
		{
			get { return GetColumnValue<string>("Description"); }

			set { SetColumnValue("Description", value); }

		}

		  
		[XmlAttribute("ConfigurationControlPath")]
		public string ConfigurationControlPath 
		{
			get { return GetColumnValue<string>("ConfigurationControlPath"); }

			set { SetColumnValue("ConfigurationControlPath", value); }

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

		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varProviderTypeId,string varName,string varDescription,string varConfigurationControlPath,string varCreatedBy,DateTime varCreatedDate,string varModifiedBy,DateTime varModifiedDate)
		{
			Provider item = new Provider();
			
			item.ProviderTypeId = varProviderTypeId;
			
			item.Name = varName;
			
			item.Description = varDescription;
			
			item.ConfigurationControlPath = varConfigurationControlPath;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedDate = varCreatedDate;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varProviderId,int varProviderTypeId,string varName,string varDescription,string varConfigurationControlPath,string varCreatedBy,DateTime varCreatedDate,string varModifiedBy,DateTime varModifiedDate)
		{
			Provider item = new Provider();
			
				item.ProviderId = varProviderId;
				
				item.ProviderTypeId = varProviderTypeId;
				
				item.Name = varName;
				
				item.Description = varDescription;
				
				item.ConfigurationControlPath = varConfigurationControlPath;
				
				item.CreatedBy = varCreatedBy;
				
				item.CreatedDate = varCreatedDate;
				
				item.ModifiedBy = varModifiedBy;
				
				item.ModifiedDate = varModifiedDate;
				
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
			 public static string ProviderTypeId = @"ProviderTypeId";
			 public static string Name = @"Name";
			 public static string Description = @"Description";
			 public static string ConfigurationControlPath = @"ConfigurationControlPath";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedDate = @"CreatedDate";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

