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
	/// Strongly-typed collection for the CustomizedProductDisplay class.
	/// </summary>
	[Serializable]
	public partial class CustomizedProductDisplayCollection : ActiveList<CustomizedProductDisplay, CustomizedProductDisplayCollection> 
	{	   
		public CustomizedProductDisplayCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Content_CustomizedProductDisplay table.
	/// </summary>
	[Serializable]
	public partial class CustomizedProductDisplay : ActiveRecord<CustomizedProductDisplay>
	{
		#region .ctors and Default Settings
		
		public CustomizedProductDisplay()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public CustomizedProductDisplay(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public CustomizedProductDisplay(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public CustomizedProductDisplay(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Content_CustomizedProductDisplay", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarCustomizedProductDisplayId = new TableSchema.TableColumn(schema);
				colvarCustomizedProductDisplayId.ColumnName = "CustomizedProductDisplayId";
				colvarCustomizedProductDisplayId.DataType = DbType.Int32;
				colvarCustomizedProductDisplayId.MaxLength = 0;
				colvarCustomizedProductDisplayId.AutoIncrement = true;
				colvarCustomizedProductDisplayId.IsNullable = false;
				colvarCustomizedProductDisplayId.IsPrimaryKey = true;
				colvarCustomizedProductDisplayId.IsForeignKey = false;
				colvarCustomizedProductDisplayId.IsReadOnly = false;
				colvarCustomizedProductDisplayId.DefaultSetting = @"";
				colvarCustomizedProductDisplayId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCustomizedProductDisplayId);
				
				TableSchema.TableColumn colvarCustomizedProductDisplayTypeId = new TableSchema.TableColumn(schema);
				colvarCustomizedProductDisplayTypeId.ColumnName = "CustomizedProductDisplayTypeId";
				colvarCustomizedProductDisplayTypeId.DataType = DbType.Int32;
				colvarCustomizedProductDisplayTypeId.MaxLength = 0;
				colvarCustomizedProductDisplayTypeId.AutoIncrement = false;
				colvarCustomizedProductDisplayTypeId.IsNullable = false;
				colvarCustomizedProductDisplayTypeId.IsPrimaryKey = false;
				colvarCustomizedProductDisplayTypeId.IsForeignKey = false;
				colvarCustomizedProductDisplayTypeId.IsReadOnly = false;
				colvarCustomizedProductDisplayTypeId.DefaultSetting = @"";
				colvarCustomizedProductDisplayTypeId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCustomizedProductDisplayTypeId);
				
				TableSchema.TableColumn colvarRegionId = new TableSchema.TableColumn(schema);
				colvarRegionId.ColumnName = "RegionId";
				colvarRegionId.DataType = DbType.Int32;
				colvarRegionId.MaxLength = 0;
				colvarRegionId.AutoIncrement = false;
				colvarRegionId.IsNullable = false;
				colvarRegionId.IsPrimaryKey = false;
				colvarRegionId.IsForeignKey = false;
				colvarRegionId.IsReadOnly = false;
				colvarRegionId.DefaultSetting = @"";
				colvarRegionId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRegionId);
				
				TableSchema.TableColumn colvarIsActive = new TableSchema.TableColumn(schema);
				colvarIsActive.ColumnName = "IsActive";
				colvarIsActive.DataType = DbType.Boolean;
				colvarIsActive.MaxLength = 0;
				colvarIsActive.AutoIncrement = false;
				colvarIsActive.IsNullable = false;
				colvarIsActive.IsPrimaryKey = false;
				colvarIsActive.IsForeignKey = false;
				colvarIsActive.IsReadOnly = false;
				colvarIsActive.DefaultSetting = @"";
				colvarIsActive.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsActive);
				
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
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Content_CustomizedProductDisplay",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("CustomizedProductDisplayId")]
		public int CustomizedProductDisplayId 
		{
			get { return GetColumnValue<int>("CustomizedProductDisplayId"); }

			set { SetColumnValue("CustomizedProductDisplayId", value); }

		}

		  
		[XmlAttribute("CustomizedProductDisplayTypeId")]
		public int CustomizedProductDisplayTypeId 
		{
			get { return GetColumnValue<int>("CustomizedProductDisplayTypeId"); }

			set { SetColumnValue("CustomizedProductDisplayTypeId", value); }

		}

		  
		[XmlAttribute("RegionId")]
		public int RegionId 
		{
			get { return GetColumnValue<int>("RegionId"); }

			set { SetColumnValue("RegionId", value); }

		}

		  
		[XmlAttribute("IsActive")]
		public bool IsActive 
		{
			get { return GetColumnValue<bool>("IsActive"); }

			set { SetColumnValue("IsActive", value); }

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
		public static void Insert(int varCustomizedProductDisplayTypeId,int varRegionId,bool varIsActive,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			CustomizedProductDisplay item = new CustomizedProductDisplay();
			
			item.CustomizedProductDisplayTypeId = varCustomizedProductDisplayTypeId;
			
			item.RegionId = varRegionId;
			
			item.IsActive = varIsActive;
			
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
		public static void Update(int varCustomizedProductDisplayId,int varCustomizedProductDisplayTypeId,int varRegionId,bool varIsActive,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			CustomizedProductDisplay item = new CustomizedProductDisplay();
			
				item.CustomizedProductDisplayId = varCustomizedProductDisplayId;
				
				item.CustomizedProductDisplayTypeId = varCustomizedProductDisplayTypeId;
				
				item.RegionId = varRegionId;
				
				item.IsActive = varIsActive;
				
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
			 public static string CustomizedProductDisplayId = @"CustomizedProductDisplayId";
			 public static string CustomizedProductDisplayTypeId = @"CustomizedProductDisplayTypeId";
			 public static string RegionId = @"RegionId";
			 public static string IsActive = @"IsActive";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}

		#endregion
	}

}

