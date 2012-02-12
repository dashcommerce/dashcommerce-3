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
	/// Strongly-typed collection for the ProductCategoryMap class.
	/// </summary>
	[Serializable]
	public partial class ProductCategoryMapCollection : ActiveList<ProductCategoryMap, ProductCategoryMapCollection> 
	{	   
		public ProductCategoryMapCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_Product_Category_Map table.
	/// </summary>
	[Serializable]
	public partial class ProductCategoryMap : ActiveRecord<ProductCategoryMap>
	{
		#region .ctors and Default Settings
		
		public ProductCategoryMap()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public ProductCategoryMap(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public ProductCategoryMap(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public ProductCategoryMap(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_Product_Category_Map", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarProductId = new TableSchema.TableColumn(schema);
				colvarProductId.ColumnName = "ProductId";
				colvarProductId.DataType = DbType.Int32;
				colvarProductId.MaxLength = 0;
				colvarProductId.AutoIncrement = false;
				colvarProductId.IsNullable = false;
				colvarProductId.IsPrimaryKey = true;
				colvarProductId.IsForeignKey = true;
				colvarProductId.IsReadOnly = false;
				colvarProductId.DefaultSetting = @"";
				
					colvarProductId.ForeignKeyTableName = "dashCommerce_Store_Product";
				schema.Columns.Add(colvarProductId);
				
				TableSchema.TableColumn colvarCategoryId = new TableSchema.TableColumn(schema);
				colvarCategoryId.ColumnName = "CategoryId";
				colvarCategoryId.DataType = DbType.Int32;
				colvarCategoryId.MaxLength = 0;
				colvarCategoryId.AutoIncrement = false;
				colvarCategoryId.IsNullable = false;
				colvarCategoryId.IsPrimaryKey = true;
				colvarCategoryId.IsForeignKey = true;
				colvarCategoryId.IsReadOnly = false;
				colvarCategoryId.DefaultSetting = @"";
				
					colvarCategoryId.ForeignKeyTableName = "dashCommerce_Store_Category";
				schema.Columns.Add(colvarCategoryId);
				
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
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_Product_Category_Map",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("ProductId")]
		public int ProductId 
		{
			get { return GetColumnValue<int>("ProductId"); }

			set { SetColumnValue("ProductId", value); }

		}

		  
		[XmlAttribute("CategoryId")]
		public int CategoryId 
		{
			get { return GetColumnValue<int>("CategoryId"); }

			set { SetColumnValue("CategoryId", value); }

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
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Category ActiveRecord object related to this ProductCategoryMap
		/// 
		/// </summary>
		public MettleSystems.dashCommerce.Store.Category Category
		{
			get { return MettleSystems.dashCommerce.Store.Category.FetchByID(this.CategoryId); }

			set { SetColumnValue("CategoryId", value.CategoryId); }

		}

		
		
		/// <summary>
		/// Returns a Product ActiveRecord object related to this ProductCategoryMap
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
		public static void Insert(int varProductId,int varCategoryId,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			ProductCategoryMap item = new ProductCategoryMap();
			
			item.ProductId = varProductId;
			
			item.CategoryId = varCategoryId;
			
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
		public static void Update(int varProductId,int varCategoryId,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			ProductCategoryMap item = new ProductCategoryMap();
			
				item.ProductId = varProductId;
				
				item.CategoryId = varCategoryId;
				
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
			 public static string ProductId = @"ProductId";
			 public static string CategoryId = @"CategoryId";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}

		#endregion
	}

}

