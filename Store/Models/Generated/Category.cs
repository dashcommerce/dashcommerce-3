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
	/// Strongly-typed collection for the Category class.
	/// </summary>
	[Serializable]
	public partial class CategoryCollection : ActiveList<Category, CategoryCollection> 
	{	   
		public CategoryCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_Category table.
	/// </summary>
	[Serializable]
	public partial class Category : ActiveRecord<Category>
	{
		#region .ctors and Default Settings
		
		public Category()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Category(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Category(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Category(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_Category", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarCategoryId = new TableSchema.TableColumn(schema);
				colvarCategoryId.ColumnName = "CategoryId";
				colvarCategoryId.DataType = DbType.Int32;
				colvarCategoryId.MaxLength = 0;
				colvarCategoryId.AutoIncrement = true;
				colvarCategoryId.IsNullable = false;
				colvarCategoryId.IsPrimaryKey = true;
				colvarCategoryId.IsForeignKey = false;
				colvarCategoryId.IsReadOnly = false;
				colvarCategoryId.DefaultSetting = @"";
				colvarCategoryId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCategoryId);
				
				TableSchema.TableColumn colvarCategoryGuid = new TableSchema.TableColumn(schema);
				colvarCategoryGuid.ColumnName = "CategoryGuid";
				colvarCategoryGuid.DataType = DbType.Guid;
				colvarCategoryGuid.MaxLength = 0;
				colvarCategoryGuid.AutoIncrement = false;
				colvarCategoryGuid.IsNullable = false;
				colvarCategoryGuid.IsPrimaryKey = false;
				colvarCategoryGuid.IsForeignKey = false;
				colvarCategoryGuid.IsReadOnly = false;
				
						colvarCategoryGuid.DefaultSetting = @"(newid())";
				colvarCategoryGuid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCategoryGuid);
				
				TableSchema.TableColumn colvarParentId = new TableSchema.TableColumn(schema);
				colvarParentId.ColumnName = "ParentId";
				colvarParentId.DataType = DbType.Int32;
				colvarParentId.MaxLength = 0;
				colvarParentId.AutoIncrement = false;
				colvarParentId.IsNullable = false;
				colvarParentId.IsPrimaryKey = false;
				colvarParentId.IsForeignKey = false;
				colvarParentId.IsReadOnly = false;
				
						colvarParentId.DefaultSetting = @"((0))";
				colvarParentId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarParentId);
				
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
				
				TableSchema.TableColumn colvarImageFile = new TableSchema.TableColumn(schema);
				colvarImageFile.ColumnName = "ImageFile";
				colvarImageFile.DataType = DbType.String;
				colvarImageFile.MaxLength = 255;
				colvarImageFile.AutoIncrement = false;
				colvarImageFile.IsNullable = true;
				colvarImageFile.IsPrimaryKey = false;
				colvarImageFile.IsForeignKey = false;
				colvarImageFile.IsReadOnly = false;
				colvarImageFile.DefaultSetting = @"";
				colvarImageFile.ForeignKeyTableName = "";
				schema.Columns.Add(colvarImageFile);
				
				TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
				colvarDescription.ColumnName = "Description";
				colvarDescription.DataType = DbType.String;
				colvarDescription.MaxLength = 500;
				colvarDescription.AutoIncrement = false;
				colvarDescription.IsNullable = true;
				colvarDescription.IsPrimaryKey = false;
				colvarDescription.IsForeignKey = false;
				colvarDescription.IsReadOnly = false;
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
				TableSchema.TableColumn colvarSortOrder = new TableSchema.TableColumn(schema);
				colvarSortOrder.ColumnName = "SortOrder";
				colvarSortOrder.DataType = DbType.Int32;
				colvarSortOrder.MaxLength = 0;
				colvarSortOrder.AutoIncrement = false;
				colvarSortOrder.IsNullable = false;
				colvarSortOrder.IsPrimaryKey = false;
				colvarSortOrder.IsForeignKey = false;
				colvarSortOrder.IsReadOnly = false;
				colvarSortOrder.DefaultSetting = @"";
				colvarSortOrder.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSortOrder);
				
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
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_Category",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("CategoryId")]
		public int CategoryId 
		{
			get { return GetColumnValue<int>("CategoryId"); }

			set { SetColumnValue("CategoryId", value); }

		}

		  
		[XmlAttribute("CategoryGuid")]
		public Guid CategoryGuid 
		{
			get { return GetColumnValue<Guid>("CategoryGuid"); }

			set { SetColumnValue("CategoryGuid", value); }

		}

		  
		[XmlAttribute("ParentId")]
		public int ParentId 
		{
			get { return GetColumnValue<int>("ParentId"); }

			set { SetColumnValue("ParentId", value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>("Name"); }

			set { SetColumnValue("Name", value); }

		}

		  
		[XmlAttribute("ImageFile")]
		public string ImageFile 
		{
			get { return GetColumnValue<string>("ImageFile"); }

			set { SetColumnValue("ImageFile", value); }

		}

		  
		[XmlAttribute("Description")]
		public string Description 
		{
			get { return GetColumnValue<string>("Description"); }

			set { SetColumnValue("Description", value); }

		}

		  
		[XmlAttribute("SortOrder")]
		public int SortOrder 
		{
			get { return GetColumnValue<int>("SortOrder"); }

			set { SetColumnValue("SortOrder", value); }

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
		
		
		#region PrimaryKey Methods
		
		public MettleSystems.dashCommerce.Store.ProductCategoryMapCollection ProductCategoryMapRecords()
		{
			return new MettleSystems.dashCommerce.Store.ProductCategoryMapCollection().Where(ProductCategoryMap.Columns.CategoryId, CategoryId).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public MettleSystems.dashCommerce.Store.ProductCollection GetProductCollection() { return Category.GetProductCollection(this.CategoryId); }

		public static MettleSystems.dashCommerce.Store.ProductCollection GetProductCollection(int varCategoryId)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM dashCommerce_Store_Product INNER JOIN dashCommerce_Store_Product_Category_Map ON "+
				"dashCommerce_Store_Product.ProductId=dashCommerce_Store_Product_Category_Map.ProductId WHERE dashCommerce_Store_Product_Category_Map.CategoryId=@CategoryId", Category.Schema.Provider.Name);
			
			cmd.AddParameter("@CategoryId", varCategoryId, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ProductCollection coll = new ProductCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveProductMap(int varCategoryId, ProductCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Store_Product_Category_Map WHERE CategoryId=@CategoryId", Category.Schema.Provider.Name);
			cmdDel.AddParameter("@CategoryId", varCategoryId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Product item in items)
			{
				ProductCategoryMap varProductCategoryMap = new ProductCategoryMap();
				varProductCategoryMap.SetColumnValue("CategoryId", varCategoryId);
				varProductCategoryMap.SetColumnValue("ProductId", item.GetPrimaryKeyValue());
				varProductCategoryMap.Save();
			}

		}

		public static void SaveProductMap(int varCategoryId, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Store_Product_Category_Map WHERE CategoryId=@CategoryId", Category.Schema.Provider.Name);
			cmdDel.AddParameter("@CategoryId", varCategoryId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductCategoryMap varProductCategoryMap = new ProductCategoryMap();
					varProductCategoryMap.SetColumnValue("CategoryId", varCategoryId);
					varProductCategoryMap.SetColumnValue("ProductId", l.Value);
					varProductCategoryMap.Save();
				}

			}

		}

		public static void SaveProductMap(int varCategoryId , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Store_Product_Category_Map WHERE CategoryId=@CategoryId", Category.Schema.Provider.Name);
			cmdDel.AddParameter("@CategoryId", varCategoryId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				ProductCategoryMap varProductCategoryMap = new ProductCategoryMap();
				varProductCategoryMap.SetColumnValue("CategoryId", varCategoryId);
				varProductCategoryMap.SetColumnValue("ProductId", item);
				varProductCategoryMap.Save();
			}

		}

		
		public static void DeleteProductMap(int varCategoryId) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Store_Product_Category_Map WHERE CategoryId=@CategoryId", Category.Schema.Provider.Name);
			cmdDel.AddParameter("@CategoryId", varCategoryId);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(Guid varCategoryGuid,int varParentId,string varName,string varImageFile,string varDescription,int varSortOrder,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			Category item = new Category();
			
			item.CategoryGuid = varCategoryGuid;
			
			item.ParentId = varParentId;
			
			item.Name = varName;
			
			item.ImageFile = varImageFile;
			
			item.Description = varDescription;
			
			item.SortOrder = varSortOrder;
			
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
		public static void Update(int varCategoryId,Guid varCategoryGuid,int varParentId,string varName,string varImageFile,string varDescription,int varSortOrder,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			Category item = new Category();
			
				item.CategoryId = varCategoryId;
				
				item.CategoryGuid = varCategoryGuid;
				
				item.ParentId = varParentId;
				
				item.Name = varName;
				
				item.ImageFile = varImageFile;
				
				item.Description = varDescription;
				
				item.SortOrder = varSortOrder;
				
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
			 public static string CategoryId = @"CategoryId";
			 public static string CategoryGuid = @"CategoryGuid";
			 public static string ParentId = @"ParentId";
			 public static string Name = @"Name";
			 public static string ImageFile = @"ImageFile";
			 public static string Description = @"Description";
			 public static string SortOrder = @"SortOrder";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}

		#endregion
	}

}

