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
	/// Strongly-typed collection for the ProductRating class.
	/// </summary>
	[Serializable]
	public partial class ProductRatingCollection : ActiveList<ProductRating, ProductRatingCollection> 
	{	   
		public ProductRatingCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_ProductRating table.
	/// </summary>
	[Serializable]
	public partial class ProductRating : ActiveRecord<ProductRating>
	{
		#region .ctors and Default Settings
		
		public ProductRating()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public ProductRating(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public ProductRating(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public ProductRating(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_ProductRating", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarProductRatingId = new TableSchema.TableColumn(schema);
				colvarProductRatingId.ColumnName = "ProductRatingId";
				colvarProductRatingId.DataType = DbType.Int32;
				colvarProductRatingId.MaxLength = 0;
				colvarProductRatingId.AutoIncrement = true;
				colvarProductRatingId.IsNullable = false;
				colvarProductRatingId.IsPrimaryKey = true;
				colvarProductRatingId.IsForeignKey = false;
				colvarProductRatingId.IsReadOnly = false;
				colvarProductRatingId.DefaultSetting = @"";
				colvarProductRatingId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProductRatingId);
				
				TableSchema.TableColumn colvarProductId = new TableSchema.TableColumn(schema);
				colvarProductId.ColumnName = "ProductId";
				colvarProductId.DataType = DbType.Int32;
				colvarProductId.MaxLength = 0;
				colvarProductId.AutoIncrement = false;
				colvarProductId.IsNullable = false;
				colvarProductId.IsPrimaryKey = false;
				colvarProductId.IsForeignKey = false;
				colvarProductId.IsReadOnly = false;
				colvarProductId.DefaultSetting = @"";
				colvarProductId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProductId);
				
				TableSchema.TableColumn colvarUserName = new TableSchema.TableColumn(schema);
				colvarUserName.ColumnName = "UserName";
				colvarUserName.DataType = DbType.String;
				colvarUserName.MaxLength = 256;
				colvarUserName.AutoIncrement = false;
				colvarUserName.IsNullable = false;
				colvarUserName.IsPrimaryKey = false;
				colvarUserName.IsForeignKey = false;
				colvarUserName.IsReadOnly = false;
				colvarUserName.DefaultSetting = @"";
				colvarUserName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserName);
				
				TableSchema.TableColumn colvarRating = new TableSchema.TableColumn(schema);
				colvarRating.ColumnName = "Rating";
				colvarRating.DataType = DbType.Int32;
				colvarRating.MaxLength = 0;
				colvarRating.AutoIncrement = false;
				colvarRating.IsNullable = false;
				colvarRating.IsPrimaryKey = false;
				colvarRating.IsForeignKey = false;
				colvarRating.IsReadOnly = false;
				colvarRating.DefaultSetting = @"";
				colvarRating.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRating);
				
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
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_ProductRating",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("ProductRatingId")]
		public int ProductRatingId 
		{
			get { return GetColumnValue<int>("ProductRatingId"); }

			set { SetColumnValue("ProductRatingId", value); }

		}

		  
		[XmlAttribute("ProductId")]
		public int ProductId 
		{
			get { return GetColumnValue<int>("ProductId"); }

			set { SetColumnValue("ProductId", value); }

		}

		  
		[XmlAttribute("UserName")]
		public string UserName 
		{
			get { return GetColumnValue<string>("UserName"); }

			set { SetColumnValue("UserName", value); }

		}

		  
		[XmlAttribute("Rating")]
		public int Rating 
		{
			get { return GetColumnValue<int>("Rating"); }

			set { SetColumnValue("Rating", value); }

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
		public static void Insert(int varProductId,string varUserName,int varRating,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			ProductRating item = new ProductRating();
			
			item.ProductId = varProductId;
			
			item.UserName = varUserName;
			
			item.Rating = varRating;
			
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
		public static void Update(int varProductRatingId,int varProductId,string varUserName,int varRating,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			ProductRating item = new ProductRating();
			
				item.ProductRatingId = varProductRatingId;
				
				item.ProductId = varProductId;
				
				item.UserName = varUserName;
				
				item.Rating = varRating;
				
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
			 public static string ProductRatingId = @"ProductRatingId";
			 public static string ProductId = @"ProductId";
			 public static string UserName = @"UserName";
			 public static string Rating = @"Rating";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}

		#endregion
	}

}

