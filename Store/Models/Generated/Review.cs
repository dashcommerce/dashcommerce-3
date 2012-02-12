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
	/// Strongly-typed collection for the Review class.
	/// </summary>
	[Serializable]
	public partial class ReviewCollection : ActiveList<Review, ReviewCollection> 
	{	   
		public ReviewCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_Review table.
	/// </summary>
	[Serializable]
	public partial class Review : ActiveRecord<Review>
	{
		#region .ctors and Default Settings
		
		public Review()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Review(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Review(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Review(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_Review", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarReviewId = new TableSchema.TableColumn(schema);
				colvarReviewId.ColumnName = "ReviewId";
				colvarReviewId.DataType = DbType.Int32;
				colvarReviewId.MaxLength = 0;
				colvarReviewId.AutoIncrement = true;
				colvarReviewId.IsNullable = false;
				colvarReviewId.IsPrimaryKey = true;
				colvarReviewId.IsForeignKey = false;
				colvarReviewId.IsReadOnly = false;
				colvarReviewId.DefaultSetting = @"";
				colvarReviewId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReviewId);
				
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
				
				TableSchema.TableColumn colvarTitle = new TableSchema.TableColumn(schema);
				colvarTitle.ColumnName = "Title";
				colvarTitle.DataType = DbType.String;
				colvarTitle.MaxLength = 100;
				colvarTitle.AutoIncrement = false;
				colvarTitle.IsNullable = false;
				colvarTitle.IsPrimaryKey = false;
				colvarTitle.IsForeignKey = false;
				colvarTitle.IsReadOnly = false;
				
						colvarTitle.DefaultSetting = @"('')";
				colvarTitle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTitle);
				
				TableSchema.TableColumn colvarBody = new TableSchema.TableColumn(schema);
				colvarBody.ColumnName = "Body";
				colvarBody.DataType = DbType.String;
				colvarBody.MaxLength = 1073741823;
				colvarBody.AutoIncrement = false;
				colvarBody.IsNullable = false;
				colvarBody.IsPrimaryKey = false;
				colvarBody.IsForeignKey = false;
				colvarBody.IsReadOnly = false;
				
						colvarBody.DefaultSetting = @"('')";
				colvarBody.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBody);
				
				TableSchema.TableColumn colvarRating = new TableSchema.TableColumn(schema);
				colvarRating.ColumnName = "Rating";
				colvarRating.DataType = DbType.Int32;
				colvarRating.MaxLength = 0;
				colvarRating.AutoIncrement = false;
				colvarRating.IsNullable = false;
				colvarRating.IsPrimaryKey = false;
				colvarRating.IsForeignKey = false;
				colvarRating.IsReadOnly = false;
				
						colvarRating.DefaultSetting = @"((0))";
				colvarRating.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRating);
				
				TableSchema.TableColumn colvarIsApproved = new TableSchema.TableColumn(schema);
				colvarIsApproved.ColumnName = "IsApproved";
				colvarIsApproved.DataType = DbType.Boolean;
				colvarIsApproved.MaxLength = 0;
				colvarIsApproved.AutoIncrement = false;
				colvarIsApproved.IsNullable = false;
				colvarIsApproved.IsPrimaryKey = false;
				colvarIsApproved.IsForeignKey = false;
				colvarIsApproved.IsReadOnly = false;
				
						colvarIsApproved.DefaultSetting = @"((0))";
				colvarIsApproved.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsApproved);
				
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
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_Review",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("ReviewId")]
		public int ReviewId 
		{
			get { return GetColumnValue<int>("ReviewId"); }

			set { SetColumnValue("ReviewId", value); }

		}

		  
		[XmlAttribute("ProductId")]
		public int ProductId 
		{
			get { return GetColumnValue<int>("ProductId"); }

			set { SetColumnValue("ProductId", value); }

		}

		  
		[XmlAttribute("Title")]
		public string Title 
		{
			get { return GetColumnValue<string>("Title"); }

			set { SetColumnValue("Title", value); }

		}

		  
		[XmlAttribute("Body")]
		public string Body 
		{
			get { return GetColumnValue<string>("Body"); }

			set { SetColumnValue("Body", value); }

		}

		  
		[XmlAttribute("Rating")]
		public int Rating 
		{
			get { return GetColumnValue<int>("Rating"); }

			set { SetColumnValue("Rating", value); }

		}

		  
		[XmlAttribute("IsApproved")]
		public bool IsApproved 
		{
			get { return GetColumnValue<bool>("IsApproved"); }

			set { SetColumnValue("IsApproved", value); }

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
		/// Returns a Product ActiveRecord object related to this Review
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
		public static void Insert(int varProductId,string varTitle,string varBody,int varRating,bool varIsApproved,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			Review item = new Review();
			
			item.ProductId = varProductId;
			
			item.Title = varTitle;
			
			item.Body = varBody;
			
			item.Rating = varRating;
			
			item.IsApproved = varIsApproved;
			
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
		public static void Update(int varReviewId,int varProductId,string varTitle,string varBody,int varRating,bool varIsApproved,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			Review item = new Review();
			
				item.ReviewId = varReviewId;
				
				item.ProductId = varProductId;
				
				item.Title = varTitle;
				
				item.Body = varBody;
				
				item.Rating = varRating;
				
				item.IsApproved = varIsApproved;
				
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
			 public static string ReviewId = @"ReviewId";
			 public static string ProductId = @"ProductId";
			 public static string Title = @"Title";
			 public static string Body = @"Body";
			 public static string Rating = @"Rating";
			 public static string IsApproved = @"IsApproved";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}

		#endregion
	}

}

