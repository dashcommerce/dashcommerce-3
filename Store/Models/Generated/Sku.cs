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
	/// Strongly-typed collection for the Sku class.
	/// </summary>
	[Serializable]
	public partial class SkuCollection : ActiveList<Sku, SkuCollection> 
	{	   
		public SkuCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_Sku table.
	/// </summary>
	[Serializable]
	public partial class Sku : ActiveRecord<Sku>
	{
		#region .ctors and Default Settings
		
		public Sku()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Sku(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Sku(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Sku(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_Sku", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarSkuId = new TableSchema.TableColumn(schema);
				colvarSkuId.ColumnName = "SkuId";
				colvarSkuId.DataType = DbType.Int32;
				colvarSkuId.MaxLength = 0;
				colvarSkuId.AutoIncrement = true;
				colvarSkuId.IsNullable = false;
				colvarSkuId.IsPrimaryKey = true;
				colvarSkuId.IsForeignKey = false;
				colvarSkuId.IsReadOnly = false;
				colvarSkuId.DefaultSetting = @"";
				colvarSkuId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSkuId);
				
				TableSchema.TableColumn colvarProductId = new TableSchema.TableColumn(schema);
				colvarProductId.ColumnName = "ProductId";
				colvarProductId.DataType = DbType.Int32;
				colvarProductId.MaxLength = 0;
				colvarProductId.AutoIncrement = false;
				colvarProductId.IsNullable = false;
				colvarProductId.IsPrimaryKey = false;
				colvarProductId.IsForeignKey = true;
				colvarProductId.IsReadOnly = false;
				colvarProductId.DefaultSetting = @"";
				
					colvarProductId.ForeignKeyTableName = "dashCommerce_Store_Product";
				schema.Columns.Add(colvarProductId);
				
				TableSchema.TableColumn colvarSkuX = new TableSchema.TableColumn(schema);
				colvarSkuX.ColumnName = "Sku";
				colvarSkuX.DataType = DbType.String;
				colvarSkuX.MaxLength = 100;
				colvarSkuX.AutoIncrement = false;
				colvarSkuX.IsNullable = false;
				colvarSkuX.IsPrimaryKey = false;
				colvarSkuX.IsForeignKey = false;
				colvarSkuX.IsReadOnly = false;
				colvarSkuX.DefaultSetting = @"";
				colvarSkuX.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSkuX);
				
				TableSchema.TableColumn colvarInventory = new TableSchema.TableColumn(schema);
				colvarInventory.ColumnName = "Inventory";
				colvarInventory.DataType = DbType.Int32;
				colvarInventory.MaxLength = 0;
				colvarInventory.AutoIncrement = false;
				colvarInventory.IsNullable = false;
				colvarInventory.IsPrimaryKey = false;
				colvarInventory.IsForeignKey = false;
				colvarInventory.IsReadOnly = false;
				
						colvarInventory.DefaultSetting = @"((0))";
				colvarInventory.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInventory);
				
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
				colvarCreatedOn.DataType = DbType.String;
				colvarCreatedOn.MaxLength = 50;
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
				colvarModifiedOn.DataType = DbType.String;
				colvarModifiedOn.MaxLength = 50;
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
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_Sku",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("SkuId")]
		public int SkuId 
		{
			get { return GetColumnValue<int>("SkuId"); }

			set { SetColumnValue("SkuId", value); }

		}

		  
		[XmlAttribute("ProductId")]
		public int ProductId 
		{
			get { return GetColumnValue<int>("ProductId"); }

			set { SetColumnValue("ProductId", value); }

		}

		  
		[XmlAttribute("SkuX")]
		public string SkuX 
		{
			get { return GetColumnValue<string>("Sku"); }

			set { SetColumnValue("Sku", value); }

		}

		  
		[XmlAttribute("Inventory")]
		public int Inventory 
		{
			get { return GetColumnValue<int>("Inventory"); }

			set { SetColumnValue("Inventory", value); }

		}

		  
		[XmlAttribute("CreatedBy")]
		public string CreatedBy 
		{
			get { return GetColumnValue<string>("CreatedBy"); }

			set { SetColumnValue("CreatedBy", value); }

		}

		  
		[XmlAttribute("CreatedOn")]
		public string CreatedOn 
		{
			get { return GetColumnValue<string>("CreatedOn"); }

			set { SetColumnValue("CreatedOn", value); }

		}

		  
		[XmlAttribute("ModifiedBy")]
		public string ModifiedBy 
		{
			get { return GetColumnValue<string>("ModifiedBy"); }

			set { SetColumnValue("ModifiedBy", value); }

		}

		  
		[XmlAttribute("ModifiedOn")]
		public string ModifiedOn 
		{
			get { return GetColumnValue<string>("ModifiedOn"); }

			set { SetColumnValue("ModifiedOn", value); }

		}

		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Product ActiveRecord object related to this Sku
		/// 
		/// </summary>
		public MettleSystems.dashCommerce.Store.Product Product
		{
			get { return MettleSystems.dashCommerce.Store.Product.FetchByID(this.ProductId); }

			set { SetColumnValue("ProductId", value.ProductId); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varProductId,string varSkuX,int varInventory,string varCreatedBy,string varCreatedOn,string varModifiedBy,string varModifiedOn)
		{
			Sku item = new Sku();
			
			item.ProductId = varProductId;
			
			item.SkuX = varSkuX;
			
			item.Inventory = varInventory;
			
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
		public static void Update(int varSkuId,int varProductId,string varSkuX,int varInventory,string varCreatedBy,string varCreatedOn,string varModifiedBy,string varModifiedOn)
		{
			Sku item = new Sku();
			
				item.SkuId = varSkuId;
				
				item.ProductId = varProductId;
				
				item.SkuX = varSkuX;
				
				item.Inventory = varInventory;
				
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
			 public static string SkuId = @"SkuId";
			 public static string ProductId = @"ProductId";
			 public static string SkuX = @"Sku";
			 public static string Inventory = @"Inventory";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}

		#endregion
	}

}

