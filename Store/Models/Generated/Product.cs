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
	/// Strongly-typed collection for the Product class.
	/// </summary>
	[Serializable]
	public partial class ProductCollection : ActiveList<Product, ProductCollection> 
	{	   
		public ProductCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_Product table.
	/// </summary>
	[Serializable]
	public partial class Product : ActiveRecord<Product>
	{
		#region .ctors and Default Settings
		
		public Product()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Product(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Product(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Product(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_Product", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarProductId = new TableSchema.TableColumn(schema);
				colvarProductId.ColumnName = "ProductId";
				colvarProductId.DataType = DbType.Int32;
				colvarProductId.MaxLength = 0;
				colvarProductId.AutoIncrement = true;
				colvarProductId.IsNullable = false;
				colvarProductId.IsPrimaryKey = true;
				colvarProductId.IsForeignKey = false;
				colvarProductId.IsReadOnly = false;
				colvarProductId.DefaultSetting = @"";
				colvarProductId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProductId);
				
				TableSchema.TableColumn colvarManufacturerId = new TableSchema.TableColumn(schema);
				colvarManufacturerId.ColumnName = "ManufacturerId";
				colvarManufacturerId.DataType = DbType.Int32;
				colvarManufacturerId.MaxLength = 0;
				colvarManufacturerId.AutoIncrement = false;
				colvarManufacturerId.IsNullable = false;
				colvarManufacturerId.IsPrimaryKey = false;
				colvarManufacturerId.IsForeignKey = true;
				colvarManufacturerId.IsReadOnly = false;
				
						colvarManufacturerId.DefaultSetting = @"((1))";
				
					colvarManufacturerId.ForeignKeyTableName = "dashCommerce_Store_Manufacturer";
				schema.Columns.Add(colvarManufacturerId);
				
				TableSchema.TableColumn colvarProductStatusDescriptorId = new TableSchema.TableColumn(schema);
				colvarProductStatusDescriptorId.ColumnName = "ProductStatusDescriptorId";
				colvarProductStatusDescriptorId.DataType = DbType.Int32;
				colvarProductStatusDescriptorId.MaxLength = 0;
				colvarProductStatusDescriptorId.AutoIncrement = false;
				colvarProductStatusDescriptorId.IsNullable = false;
				colvarProductStatusDescriptorId.IsPrimaryKey = false;
				colvarProductStatusDescriptorId.IsForeignKey = true;
				colvarProductStatusDescriptorId.IsReadOnly = false;
				
						colvarProductStatusDescriptorId.DefaultSetting = @"((1))";
				
					colvarProductStatusDescriptorId.ForeignKeyTableName = "dashCommerce_Store_ProductStatusDescriptor";
				schema.Columns.Add(colvarProductStatusDescriptorId);
				
				TableSchema.TableColumn colvarProductTypeId = new TableSchema.TableColumn(schema);
				colvarProductTypeId.ColumnName = "ProductTypeId";
				colvarProductTypeId.DataType = DbType.Int32;
				colvarProductTypeId.MaxLength = 0;
				colvarProductTypeId.AutoIncrement = false;
				colvarProductTypeId.IsNullable = false;
				colvarProductTypeId.IsPrimaryKey = false;
				colvarProductTypeId.IsForeignKey = true;
				colvarProductTypeId.IsReadOnly = false;
				
						colvarProductTypeId.DefaultSetting = @"((1))";
				
					colvarProductTypeId.ForeignKeyTableName = "dashCommerce_Store_ProductType";
				schema.Columns.Add(colvarProductTypeId);
				
				TableSchema.TableColumn colvarShippingEstimateId = new TableSchema.TableColumn(schema);
				colvarShippingEstimateId.ColumnName = "ShippingEstimateId";
				colvarShippingEstimateId.DataType = DbType.Int32;
				colvarShippingEstimateId.MaxLength = 0;
				colvarShippingEstimateId.AutoIncrement = false;
				colvarShippingEstimateId.IsNullable = false;
				colvarShippingEstimateId.IsPrimaryKey = false;
				colvarShippingEstimateId.IsForeignKey = true;
				colvarShippingEstimateId.IsReadOnly = false;
				
						colvarShippingEstimateId.DefaultSetting = @"((1))";
				
					colvarShippingEstimateId.ForeignKeyTableName = "dashCommerce_Store_ShippingEstimate";
				schema.Columns.Add(colvarShippingEstimateId);
				
				TableSchema.TableColumn colvarBaseSku = new TableSchema.TableColumn(schema);
				colvarBaseSku.ColumnName = "BaseSku";
				colvarBaseSku.DataType = DbType.String;
				colvarBaseSku.MaxLength = 50;
				colvarBaseSku.AutoIncrement = false;
				colvarBaseSku.IsNullable = true;
				colvarBaseSku.IsPrimaryKey = false;
				colvarBaseSku.IsForeignKey = false;
				colvarBaseSku.IsReadOnly = false;
				colvarBaseSku.DefaultSetting = @"";
				colvarBaseSku.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBaseSku);
				
				TableSchema.TableColumn colvarProductGuid = new TableSchema.TableColumn(schema);
				colvarProductGuid.ColumnName = "ProductGuid";
				colvarProductGuid.DataType = DbType.Guid;
				colvarProductGuid.MaxLength = 0;
				colvarProductGuid.AutoIncrement = false;
				colvarProductGuid.IsNullable = false;
				colvarProductGuid.IsPrimaryKey = false;
				colvarProductGuid.IsForeignKey = false;
				colvarProductGuid.IsReadOnly = false;
				
						colvarProductGuid.DefaultSetting = @"(newid())";
				colvarProductGuid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProductGuid);
				
				TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
				colvarName.ColumnName = "Name";
				colvarName.DataType = DbType.String;
				colvarName.MaxLength = 150;
				colvarName.AutoIncrement = false;
				colvarName.IsNullable = false;
				colvarName.IsPrimaryKey = false;
				colvarName.IsForeignKey = false;
				colvarName.IsReadOnly = false;
				colvarName.DefaultSetting = @"";
				colvarName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarName);
				
				TableSchema.TableColumn colvarShortDescription = new TableSchema.TableColumn(schema);
				colvarShortDescription.ColumnName = "ShortDescription";
				colvarShortDescription.DataType = DbType.String;
				colvarShortDescription.MaxLength = -1;
				colvarShortDescription.AutoIncrement = false;
				colvarShortDescription.IsNullable = true;
				colvarShortDescription.IsPrimaryKey = false;
				colvarShortDescription.IsForeignKey = false;
				colvarShortDescription.IsReadOnly = false;
				colvarShortDescription.DefaultSetting = @"";
				colvarShortDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarShortDescription);
				
				TableSchema.TableColumn colvarOurPrice = new TableSchema.TableColumn(schema);
				colvarOurPrice.ColumnName = "OurPrice";
				colvarOurPrice.DataType = DbType.Currency;
				colvarOurPrice.MaxLength = 0;
				colvarOurPrice.AutoIncrement = false;
				colvarOurPrice.IsNullable = false;
				colvarOurPrice.IsPrimaryKey = false;
				colvarOurPrice.IsForeignKey = false;
				colvarOurPrice.IsReadOnly = false;
				colvarOurPrice.DefaultSetting = @"";
				colvarOurPrice.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOurPrice);
				
				TableSchema.TableColumn colvarRetailPrice = new TableSchema.TableColumn(schema);
				colvarRetailPrice.ColumnName = "RetailPrice";
				colvarRetailPrice.DataType = DbType.Currency;
				colvarRetailPrice.MaxLength = 0;
				colvarRetailPrice.AutoIncrement = false;
				colvarRetailPrice.IsNullable = false;
				colvarRetailPrice.IsPrimaryKey = false;
				colvarRetailPrice.IsForeignKey = false;
				colvarRetailPrice.IsReadOnly = false;
				colvarRetailPrice.DefaultSetting = @"";
				colvarRetailPrice.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRetailPrice);
				
				TableSchema.TableColumn colvarTaxRateId = new TableSchema.TableColumn(schema);
				colvarTaxRateId.ColumnName = "TaxRateId";
				colvarTaxRateId.DataType = DbType.Int32;
				colvarTaxRateId.MaxLength = 0;
				colvarTaxRateId.AutoIncrement = false;
				colvarTaxRateId.IsNullable = false;
				colvarTaxRateId.IsPrimaryKey = false;
				colvarTaxRateId.IsForeignKey = false;
				colvarTaxRateId.IsReadOnly = false;
				
						colvarTaxRateId.DefaultSetting = @"((0))";
				colvarTaxRateId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTaxRateId);
				
				TableSchema.TableColumn colvarWeight = new TableSchema.TableColumn(schema);
				colvarWeight.ColumnName = "Weight";
				colvarWeight.DataType = DbType.Decimal;
				colvarWeight.MaxLength = 0;
				colvarWeight.AutoIncrement = false;
				colvarWeight.IsNullable = false;
				colvarWeight.IsPrimaryKey = false;
				colvarWeight.IsForeignKey = false;
				colvarWeight.IsReadOnly = false;
				
						colvarWeight.DefaultSetting = @"((0))";
				colvarWeight.ForeignKeyTableName = "";
				schema.Columns.Add(colvarWeight);
				
				TableSchema.TableColumn colvarLength = new TableSchema.TableColumn(schema);
				colvarLength.ColumnName = "Length";
				colvarLength.DataType = DbType.Decimal;
				colvarLength.MaxLength = 0;
				colvarLength.AutoIncrement = false;
				colvarLength.IsNullable = false;
				colvarLength.IsPrimaryKey = false;
				colvarLength.IsForeignKey = false;
				colvarLength.IsReadOnly = false;
				
						colvarLength.DefaultSetting = @"((0))";
				colvarLength.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLength);
				
				TableSchema.TableColumn colvarHeight = new TableSchema.TableColumn(schema);
				colvarHeight.ColumnName = "Height";
				colvarHeight.DataType = DbType.Decimal;
				colvarHeight.MaxLength = 0;
				colvarHeight.AutoIncrement = false;
				colvarHeight.IsNullable = false;
				colvarHeight.IsPrimaryKey = false;
				colvarHeight.IsForeignKey = false;
				colvarHeight.IsReadOnly = false;
				
						colvarHeight.DefaultSetting = @"((0))";
				colvarHeight.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHeight);
				
				TableSchema.TableColumn colvarWidth = new TableSchema.TableColumn(schema);
				colvarWidth.ColumnName = "Width";
				colvarWidth.DataType = DbType.Decimal;
				colvarWidth.MaxLength = 0;
				colvarWidth.AutoIncrement = false;
				colvarWidth.IsNullable = false;
				colvarWidth.IsPrimaryKey = false;
				colvarWidth.IsForeignKey = false;
				colvarWidth.IsReadOnly = false;
				
						colvarWidth.DefaultSetting = @"((0))";
				colvarWidth.ForeignKeyTableName = "";
				schema.Columns.Add(colvarWidth);
				
				TableSchema.TableColumn colvarSortOrder = new TableSchema.TableColumn(schema);
				colvarSortOrder.ColumnName = "SortOrder";
				colvarSortOrder.DataType = DbType.Int32;
				colvarSortOrder.MaxLength = 0;
				colvarSortOrder.AutoIncrement = false;
				colvarSortOrder.IsNullable = false;
				colvarSortOrder.IsPrimaryKey = false;
				colvarSortOrder.IsForeignKey = false;
				colvarSortOrder.IsReadOnly = false;
				
						colvarSortOrder.DefaultSetting = @"((1))";
				colvarSortOrder.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSortOrder);
				
				TableSchema.TableColumn colvarRatingSum = new TableSchema.TableColumn(schema);
				colvarRatingSum.ColumnName = "RatingSum";
				colvarRatingSum.DataType = DbType.Int32;
				colvarRatingSum.MaxLength = 0;
				colvarRatingSum.AutoIncrement = false;
				colvarRatingSum.IsNullable = false;
				colvarRatingSum.IsPrimaryKey = false;
				colvarRatingSum.IsForeignKey = false;
				colvarRatingSum.IsReadOnly = false;
				
						colvarRatingSum.DefaultSetting = @"((4))";
				colvarRatingSum.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRatingSum);
				
				TableSchema.TableColumn colvarTotalRatingVotes = new TableSchema.TableColumn(schema);
				colvarTotalRatingVotes.ColumnName = "TotalRatingVotes";
				colvarTotalRatingVotes.DataType = DbType.Int32;
				colvarTotalRatingVotes.MaxLength = 0;
				colvarTotalRatingVotes.AutoIncrement = false;
				colvarTotalRatingVotes.IsNullable = false;
				colvarTotalRatingVotes.IsPrimaryKey = false;
				colvarTotalRatingVotes.IsForeignKey = false;
				colvarTotalRatingVotes.IsReadOnly = false;
				
						colvarTotalRatingVotes.DefaultSetting = @"((1))";
				colvarTotalRatingVotes.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTotalRatingVotes);
				
				TableSchema.TableColumn colvarAllowNegativeInventories = new TableSchema.TableColumn(schema);
				colvarAllowNegativeInventories.ColumnName = "AllowNegativeInventories";
				colvarAllowNegativeInventories.DataType = DbType.Boolean;
				colvarAllowNegativeInventories.MaxLength = 0;
				colvarAllowNegativeInventories.AutoIncrement = false;
				colvarAllowNegativeInventories.IsNullable = false;
				colvarAllowNegativeInventories.IsPrimaryKey = false;
				colvarAllowNegativeInventories.IsForeignKey = false;
				colvarAllowNegativeInventories.IsReadOnly = false;
				
						colvarAllowNegativeInventories.DefaultSetting = @"((0))";
				colvarAllowNegativeInventories.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAllowNegativeInventories);
				
				TableSchema.TableColumn colvarIsEnabled = new TableSchema.TableColumn(schema);
				colvarIsEnabled.ColumnName = "IsEnabled";
				colvarIsEnabled.DataType = DbType.Boolean;
				colvarIsEnabled.MaxLength = 0;
				colvarIsEnabled.AutoIncrement = false;
				colvarIsEnabled.IsNullable = false;
				colvarIsEnabled.IsPrimaryKey = false;
				colvarIsEnabled.IsForeignKey = false;
				colvarIsEnabled.IsReadOnly = false;
				
						colvarIsEnabled.DefaultSetting = @"((0))";
				colvarIsEnabled.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsEnabled);
				
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
				
				TableSchema.TableColumn colvarIsDeleted = new TableSchema.TableColumn(schema);
				colvarIsDeleted.ColumnName = "IsDeleted";
				colvarIsDeleted.DataType = DbType.Boolean;
				colvarIsDeleted.MaxLength = 0;
				colvarIsDeleted.AutoIncrement = false;
				colvarIsDeleted.IsNullable = false;
				colvarIsDeleted.IsPrimaryKey = false;
				colvarIsDeleted.IsForeignKey = false;
				colvarIsDeleted.IsReadOnly = false;
				
						colvarIsDeleted.DefaultSetting = @"((0))";
				colvarIsDeleted.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsDeleted);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_Product",schema);
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

		  
		[XmlAttribute("ManufacturerId")]
		public int ManufacturerId 
		{
			get { return GetColumnValue<int>("ManufacturerId"); }

			set { SetColumnValue("ManufacturerId", value); }

		}

		  
		[XmlAttribute("ProductStatusDescriptorId")]
		public int ProductStatusDescriptorId 
		{
			get { return GetColumnValue<int>("ProductStatusDescriptorId"); }

			set { SetColumnValue("ProductStatusDescriptorId", value); }

		}

		  
		[XmlAttribute("ProductTypeId")]
		public int ProductTypeId 
		{
			get { return GetColumnValue<int>("ProductTypeId"); }

			set { SetColumnValue("ProductTypeId", value); }

		}

		  
		[XmlAttribute("ShippingEstimateId")]
		public int ShippingEstimateId 
		{
			get { return GetColumnValue<int>("ShippingEstimateId"); }

			set { SetColumnValue("ShippingEstimateId", value); }

		}

		  
		[XmlAttribute("BaseSku")]
		public string BaseSku 
		{
			get { return GetColumnValue<string>("BaseSku"); }

			set { SetColumnValue("BaseSku", value); }

		}

		  
		[XmlAttribute("ProductGuid")]
		public Guid ProductGuid 
		{
			get { return GetColumnValue<Guid>("ProductGuid"); }

			set { SetColumnValue("ProductGuid", value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>("Name"); }

			set { SetColumnValue("Name", value); }

		}

		  
		[XmlAttribute("ShortDescription")]
		public string ShortDescription 
		{
			get { return GetColumnValue<string>("ShortDescription"); }

			set { SetColumnValue("ShortDescription", value); }

		}

		  
		[XmlAttribute("OurPrice")]
		public decimal OurPrice 
		{
			get { return GetColumnValue<decimal>("OurPrice"); }

			set { SetColumnValue("OurPrice", value); }

		}

		  
		[XmlAttribute("RetailPrice")]
		public decimal RetailPrice 
		{
			get { return GetColumnValue<decimal>("RetailPrice"); }

			set { SetColumnValue("RetailPrice", value); }

		}

		  
		[XmlAttribute("TaxRateId")]
		public int TaxRateId 
		{
			get { return GetColumnValue<int>("TaxRateId"); }

			set { SetColumnValue("TaxRateId", value); }

		}

		  
		[XmlAttribute("Weight")]
		public decimal Weight 
		{
			get { return GetColumnValue<decimal>("Weight"); }

			set { SetColumnValue("Weight", value); }

		}

		  
		[XmlAttribute("Length")]
		public decimal Length 
		{
			get { return GetColumnValue<decimal>("Length"); }

			set { SetColumnValue("Length", value); }

		}

		  
		[XmlAttribute("Height")]
		public decimal Height 
		{
			get { return GetColumnValue<decimal>("Height"); }

			set { SetColumnValue("Height", value); }

		}

		  
		[XmlAttribute("Width")]
		public decimal Width 
		{
			get { return GetColumnValue<decimal>("Width"); }

			set { SetColumnValue("Width", value); }

		}

		  
		[XmlAttribute("SortOrder")]
		public int SortOrder 
		{
			get { return GetColumnValue<int>("SortOrder"); }

			set { SetColumnValue("SortOrder", value); }

		}

		  
		[XmlAttribute("RatingSum")]
		public int RatingSum 
		{
			get { return GetColumnValue<int>("RatingSum"); }

			set { SetColumnValue("RatingSum", value); }

		}

		  
		[XmlAttribute("TotalRatingVotes")]
		public int TotalRatingVotes 
		{
			get { return GetColumnValue<int>("TotalRatingVotes"); }

			set { SetColumnValue("TotalRatingVotes", value); }

		}

		  
		[XmlAttribute("AllowNegativeInventories")]
		public bool AllowNegativeInventories 
		{
			get { return GetColumnValue<bool>("AllowNegativeInventories"); }

			set { SetColumnValue("AllowNegativeInventories", value); }

		}

		  
		[XmlAttribute("IsEnabled")]
		public bool IsEnabled 
		{
			get { return GetColumnValue<bool>("IsEnabled"); }

			set { SetColumnValue("IsEnabled", value); }

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

		  
		[XmlAttribute("IsDeleted")]
		public bool IsDeleted 
		{
			get { return GetColumnValue<bool>("IsDeleted"); }

			set { SetColumnValue("IsDeleted", value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		public MettleSystems.dashCommerce.Store.CustomizedProductDisplayTypeProductMapCollection CustomizedProductDisplayTypeProductMapRecords()
		{
			return new MettleSystems.dashCommerce.Store.CustomizedProductDisplayTypeProductMapCollection().Where(CustomizedProductDisplayTypeProductMap.Columns.ProductId, ProductId).Load();
		}

		public MettleSystems.dashCommerce.Store.ImageCollection ImageRecords()
		{
			return new MettleSystems.dashCommerce.Store.ImageCollection().Where(Image.Columns.ProductId, ProductId).Load();
		}

		public MettleSystems.dashCommerce.Store.ProductCategoryMapCollection ProductCategoryMapRecords()
		{
			return new MettleSystems.dashCommerce.Store.ProductCategoryMapCollection().Where(ProductCategoryMap.Columns.ProductId, ProductId).Load();
		}

		public MettleSystems.dashCommerce.Store.CrossSellCollection CrossSellRecords()
		{
			return new MettleSystems.dashCommerce.Store.CrossSellCollection().Where(CrossSell.Columns.ProductId, ProductId).Load();
		}

		public MettleSystems.dashCommerce.Store.CrossSellCollection CrossSellRecordsFromProduct()
		{
			return new MettleSystems.dashCommerce.Store.CrossSellCollection().Where(CrossSell.Columns.CrossProductId, ProductId).Load();
		}

		public MettleSystems.dashCommerce.Store.ProductAttributeMapCollection ProductAttributeMapRecords()
		{
			return new MettleSystems.dashCommerce.Store.ProductAttributeMapCollection().Where(ProductAttributeMap.Columns.ProductId, ProductId).Load();
		}

		public MettleSystems.dashCommerce.Store.DescriptorCollection DescriptorRecords()
		{
			return new MettleSystems.dashCommerce.Store.DescriptorCollection().Where(Descriptor.Columns.ProductId, ProductId).Load();
		}

		public MettleSystems.dashCommerce.Store.ReviewCollection ReviewRecords()
		{
			return new MettleSystems.dashCommerce.Store.ReviewCollection().Where(Review.Columns.ProductId, ProductId).Load();
		}

		public MettleSystems.dashCommerce.Store.SkuCollection SkuRecords()
		{
			return new MettleSystems.dashCommerce.Store.SkuCollection().Where(Sku.Columns.ProductId, ProductId).Load();
		}

		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Manufacturer ActiveRecord object related to this Product
		/// 
		/// </summary>
		public MettleSystems.dashCommerce.Store.Manufacturer Manufacturer
		{
			get { return MettleSystems.dashCommerce.Store.Manufacturer.FetchByID(this.ManufacturerId); }

			set { SetColumnValue("ManufacturerId", value.ManufacturerId); }

		}

		
		
		/// <summary>
		/// Returns a ProductStatusDescriptor ActiveRecord object related to this Product
		/// 
		/// </summary>
		public MettleSystems.dashCommerce.Store.ProductStatusDescriptor ProductStatusDescriptor
		{
			get { return MettleSystems.dashCommerce.Store.ProductStatusDescriptor.FetchByID(this.ProductStatusDescriptorId); }

			set { SetColumnValue("ProductStatusDescriptorId", value.ProductStatusDescriptorId); }

		}

		
		
		/// <summary>
		/// Returns a ProductType ActiveRecord object related to this Product
		/// 
		/// </summary>
		public MettleSystems.dashCommerce.Store.ProductType ProductType
		{
			get { return MettleSystems.dashCommerce.Store.ProductType.FetchByID(this.ProductTypeId); }

			set { SetColumnValue("ProductTypeId", value.ProductTypeId); }

		}

		
		
		/// <summary>
		/// Returns a ShippingEstimate ActiveRecord object related to this Product
		/// 
		/// </summary>
		public MettleSystems.dashCommerce.Store.ShippingEstimate ShippingEstimate
		{
			get { return MettleSystems.dashCommerce.Store.ShippingEstimate.FetchByID(this.ShippingEstimateId); }

			set { SetColumnValue("ShippingEstimateId", value.ShippingEstimateId); }

		}

		
		
		#endregion
		
		
		
		#region Many To Many Helpers
		
		 
		public MettleSystems.dashCommerce.Store.CategoryCollection GetCategoryCollection() { return Product.GetCategoryCollection(this.ProductId); }

		public static MettleSystems.dashCommerce.Store.CategoryCollection GetCategoryCollection(int varProductId)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM dashCommerce_Store_Category INNER JOIN dashCommerce_Store_Product_Category_Map ON "+
				"dashCommerce_Store_Category.CategoryId=dashCommerce_Store_Product_Category_Map.CategoryId WHERE dashCommerce_Store_Product_Category_Map.ProductId=@ProductId", Product.Schema.Provider.Name);
			
			cmd.AddParameter("@ProductId", varProductId, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			CategoryCollection coll = new CategoryCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveCategoryMap(int varProductId, CategoryCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Store_Product_Category_Map WHERE ProductId=@ProductId", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductId", varProductId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Category item in items)
			{
				ProductCategoryMap varProductCategoryMap = new ProductCategoryMap();
				varProductCategoryMap.SetColumnValue("ProductId", varProductId);
				varProductCategoryMap.SetColumnValue("CategoryId", item.GetPrimaryKeyValue());
				varProductCategoryMap.Save();
			}

		}

		public static void SaveCategoryMap(int varProductId, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Store_Product_Category_Map WHERE ProductId=@ProductId", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductId", varProductId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductCategoryMap varProductCategoryMap = new ProductCategoryMap();
					varProductCategoryMap.SetColumnValue("ProductId", varProductId);
					varProductCategoryMap.SetColumnValue("CategoryId", l.Value);
					varProductCategoryMap.Save();
				}

			}

		}

		public static void SaveCategoryMap(int varProductId , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Store_Product_Category_Map WHERE ProductId=@ProductId", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductId", varProductId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				ProductCategoryMap varProductCategoryMap = new ProductCategoryMap();
				varProductCategoryMap.SetColumnValue("ProductId", varProductId);
				varProductCategoryMap.SetColumnValue("CategoryId", item);
				varProductCategoryMap.Save();
			}

		}

		
		public static void DeleteCategoryMap(int varProductId) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Store_Product_Category_Map WHERE ProductId=@ProductId", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductId", varProductId);
			DataService.ExecuteQuery(cmdDel);
		}

		
		 
		public MettleSystems.dashCommerce.Store.AttributeCollection GetAttributeCollection() { return Product.GetAttributeCollection(this.ProductId); }

		public static MettleSystems.dashCommerce.Store.AttributeCollection GetAttributeCollection(int varProductId)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM dashCommerce_Store_Attribute INNER JOIN dashCommerce_Store_Product_Attribute_Map ON "+
				"dashCommerce_Store_Attribute.AttributeId=dashCommerce_Store_Product_Attribute_Map.AttributeId WHERE dashCommerce_Store_Product_Attribute_Map.ProductId=@ProductId", Product.Schema.Provider.Name);
			
			cmd.AddParameter("@ProductId", varProductId, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			AttributeCollection coll = new AttributeCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveAttributeMap(int varProductId, AttributeCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Store_Product_Attribute_Map WHERE ProductId=@ProductId", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductId", varProductId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Attribute item in items)
			{
				ProductAttributeMap varProductAttributeMap = new ProductAttributeMap();
				varProductAttributeMap.SetColumnValue("ProductId", varProductId);
				varProductAttributeMap.SetColumnValue("AttributeId", item.GetPrimaryKeyValue());
				varProductAttributeMap.Save();
			}

		}

		public static void SaveAttributeMap(int varProductId, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Store_Product_Attribute_Map WHERE ProductId=@ProductId", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductId", varProductId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductAttributeMap varProductAttributeMap = new ProductAttributeMap();
					varProductAttributeMap.SetColumnValue("ProductId", varProductId);
					varProductAttributeMap.SetColumnValue("AttributeId", l.Value);
					varProductAttributeMap.Save();
				}

			}

		}

		public static void SaveAttributeMap(int varProductId , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Store_Product_Attribute_Map WHERE ProductId=@ProductId", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductId", varProductId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				ProductAttributeMap varProductAttributeMap = new ProductAttributeMap();
				varProductAttributeMap.SetColumnValue("ProductId", varProductId);
				varProductAttributeMap.SetColumnValue("AttributeId", item);
				varProductAttributeMap.Save();
			}

		}

		
		public static void DeleteAttributeMap(int varProductId) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Store_Product_Attribute_Map WHERE ProductId=@ProductId", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductId", varProductId);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varManufacturerId,int varProductStatusDescriptorId,int varProductTypeId,int varShippingEstimateId,string varBaseSku,Guid varProductGuid,string varName,string varShortDescription,decimal varOurPrice,decimal varRetailPrice,int varTaxRateId,decimal varWeight,decimal varLength,decimal varHeight,decimal varWidth,int varSortOrder,int varRatingSum,int varTotalRatingVotes,bool varAllowNegativeInventories,bool varIsEnabled,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn,bool varIsDeleted)
		{
			Product item = new Product();
			
			item.ManufacturerId = varManufacturerId;
			
			item.ProductStatusDescriptorId = varProductStatusDescriptorId;
			
			item.ProductTypeId = varProductTypeId;
			
			item.ShippingEstimateId = varShippingEstimateId;
			
			item.BaseSku = varBaseSku;
			
			item.ProductGuid = varProductGuid;
			
			item.Name = varName;
			
			item.ShortDescription = varShortDescription;
			
			item.OurPrice = varOurPrice;
			
			item.RetailPrice = varRetailPrice;
			
			item.TaxRateId = varTaxRateId;
			
			item.Weight = varWeight;
			
			item.Length = varLength;
			
			item.Height = varHeight;
			
			item.Width = varWidth;
			
			item.SortOrder = varSortOrder;
			
			item.RatingSum = varRatingSum;
			
			item.TotalRatingVotes = varTotalRatingVotes;
			
			item.AllowNegativeInventories = varAllowNegativeInventories;
			
			item.IsEnabled = varIsEnabled;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedOn = varModifiedOn;
			
			item.IsDeleted = varIsDeleted;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varProductId,int varManufacturerId,int varProductStatusDescriptorId,int varProductTypeId,int varShippingEstimateId,string varBaseSku,Guid varProductGuid,string varName,string varShortDescription,decimal varOurPrice,decimal varRetailPrice,int varTaxRateId,decimal varWeight,decimal varLength,decimal varHeight,decimal varWidth,int varSortOrder,int varRatingSum,int varTotalRatingVotes,bool varAllowNegativeInventories,bool varIsEnabled,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn,bool varIsDeleted)
		{
			Product item = new Product();
			
				item.ProductId = varProductId;
				
				item.ManufacturerId = varManufacturerId;
				
				item.ProductStatusDescriptorId = varProductStatusDescriptorId;
				
				item.ProductTypeId = varProductTypeId;
				
				item.ShippingEstimateId = varShippingEstimateId;
				
				item.BaseSku = varBaseSku;
				
				item.ProductGuid = varProductGuid;
				
				item.Name = varName;
				
				item.ShortDescription = varShortDescription;
				
				item.OurPrice = varOurPrice;
				
				item.RetailPrice = varRetailPrice;
				
				item.TaxRateId = varTaxRateId;
				
				item.Weight = varWeight;
				
				item.Length = varLength;
				
				item.Height = varHeight;
				
				item.Width = varWidth;
				
				item.SortOrder = varSortOrder;
				
				item.RatingSum = varRatingSum;
				
				item.TotalRatingVotes = varTotalRatingVotes;
				
				item.AllowNegativeInventories = varAllowNegativeInventories;
				
				item.IsEnabled = varIsEnabled;
				
				item.CreatedBy = varCreatedBy;
				
				item.CreatedOn = varCreatedOn;
				
				item.ModifiedBy = varModifiedBy;
				
				item.ModifiedOn = varModifiedOn;
				
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
			 public static string ProductId = @"ProductId";
			 public static string ManufacturerId = @"ManufacturerId";
			 public static string ProductStatusDescriptorId = @"ProductStatusDescriptorId";
			 public static string ProductTypeId = @"ProductTypeId";
			 public static string ShippingEstimateId = @"ShippingEstimateId";
			 public static string BaseSku = @"BaseSku";
			 public static string ProductGuid = @"ProductGuid";
			 public static string Name = @"Name";
			 public static string ShortDescription = @"ShortDescription";
			 public static string OurPrice = @"OurPrice";
			 public static string RetailPrice = @"RetailPrice";
			 public static string TaxRateId = @"TaxRateId";
			 public static string Weight = @"Weight";
			 public static string Length = @"Length";
			 public static string Height = @"Height";
			 public static string Width = @"Width";
			 public static string SortOrder = @"SortOrder";
			 public static string RatingSum = @"RatingSum";
			 public static string TotalRatingVotes = @"TotalRatingVotes";
			 public static string AllowNegativeInventories = @"AllowNegativeInventories";
			 public static string IsEnabled = @"IsEnabled";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string IsDeleted = @"IsDeleted";
						
		}

		#endregion
	}

}

