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
	/// Strongly-typed collection for the OrderItem class.
	/// </summary>
	[Serializable]
	public partial class OrderItemCollection : ActiveList<OrderItem, OrderItemCollection> 
	{	   
		public OrderItemCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_OrderItem table.
	/// </summary>
	[Serializable]
	public partial class OrderItem : ActiveRecord<OrderItem>
	{
		#region .ctors and Default Settings
		
		public OrderItem()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public OrderItem(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public OrderItem(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public OrderItem(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_OrderItem", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarOrderItemId = new TableSchema.TableColumn(schema);
				colvarOrderItemId.ColumnName = "OrderItemId";
				colvarOrderItemId.DataType = DbType.Int32;
				colvarOrderItemId.MaxLength = 0;
				colvarOrderItemId.AutoIncrement = true;
				colvarOrderItemId.IsNullable = false;
				colvarOrderItemId.IsPrimaryKey = true;
				colvarOrderItemId.IsForeignKey = false;
				colvarOrderItemId.IsReadOnly = false;
				colvarOrderItemId.DefaultSetting = @"";
				colvarOrderItemId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrderItemId);
				
				TableSchema.TableColumn colvarOrderId = new TableSchema.TableColumn(schema);
				colvarOrderId.ColumnName = "OrderId";
				colvarOrderId.DataType = DbType.Int32;
				colvarOrderId.MaxLength = 0;
				colvarOrderId.AutoIncrement = false;
				colvarOrderId.IsNullable = false;
				colvarOrderId.IsPrimaryKey = false;
				colvarOrderId.IsForeignKey = true;
				colvarOrderId.IsReadOnly = false;
				colvarOrderId.DefaultSetting = @"";
				
					colvarOrderId.ForeignKeyTableName = "dashCommerce_Store_Order";
				schema.Columns.Add(colvarOrderId);
				
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
				
				TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
				colvarName.ColumnName = "Name";
				colvarName.DataType = DbType.String;
				colvarName.MaxLength = 150;
				colvarName.AutoIncrement = false;
				colvarName.IsNullable = true;
				colvarName.IsPrimaryKey = false;
				colvarName.IsForeignKey = false;
				colvarName.IsReadOnly = false;
				colvarName.DefaultSetting = @"";
				colvarName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarName);
				
				TableSchema.TableColumn colvarSku = new TableSchema.TableColumn(schema);
				colvarSku.ColumnName = "Sku";
				colvarSku.DataType = DbType.String;
				colvarSku.MaxLength = 100;
				colvarSku.AutoIncrement = false;
				colvarSku.IsNullable = true;
				colvarSku.IsPrimaryKey = false;
				colvarSku.IsForeignKey = false;
				colvarSku.IsReadOnly = false;
				colvarSku.DefaultSetting = @"";
				colvarSku.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSku);
				
				TableSchema.TableColumn colvarQuantity = new TableSchema.TableColumn(schema);
				colvarQuantity.ColumnName = "Quantity";
				colvarQuantity.DataType = DbType.Int32;
				colvarQuantity.MaxLength = 0;
				colvarQuantity.AutoIncrement = false;
				colvarQuantity.IsNullable = false;
				colvarQuantity.IsPrimaryKey = false;
				colvarQuantity.IsForeignKey = false;
				colvarQuantity.IsReadOnly = false;
				colvarQuantity.DefaultSetting = @"";
				colvarQuantity.ForeignKeyTableName = "";
				schema.Columns.Add(colvarQuantity);
				
				TableSchema.TableColumn colvarPricePaid = new TableSchema.TableColumn(schema);
				colvarPricePaid.ColumnName = "PricePaid";
				colvarPricePaid.DataType = DbType.Currency;
				colvarPricePaid.MaxLength = 0;
				colvarPricePaid.AutoIncrement = false;
				colvarPricePaid.IsNullable = false;
				colvarPricePaid.IsPrimaryKey = false;
				colvarPricePaid.IsForeignKey = false;
				colvarPricePaid.IsReadOnly = false;
				colvarPricePaid.DefaultSetting = @"";
				colvarPricePaid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPricePaid);
				
				TableSchema.TableColumn colvarAttributes = new TableSchema.TableColumn(schema);
				colvarAttributes.ColumnName = "Attributes";
				colvarAttributes.DataType = DbType.String;
				colvarAttributes.MaxLength = 100;
				colvarAttributes.AutoIncrement = false;
				colvarAttributes.IsNullable = true;
				colvarAttributes.IsPrimaryKey = false;
				colvarAttributes.IsForeignKey = false;
				colvarAttributes.IsReadOnly = false;
				colvarAttributes.DefaultSetting = @"";
				colvarAttributes.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAttributes);
				
				TableSchema.TableColumn colvarAdditionalProperties = new TableSchema.TableColumn(schema);
				colvarAdditionalProperties.ColumnName = "AdditionalProperties";
				colvarAdditionalProperties.DataType = DbType.String;
				colvarAdditionalProperties.MaxLength = 2000;
				colvarAdditionalProperties.AutoIncrement = false;
				colvarAdditionalProperties.IsNullable = true;
				colvarAdditionalProperties.IsPrimaryKey = false;
				colvarAdditionalProperties.IsForeignKey = false;
				colvarAdditionalProperties.IsReadOnly = false;
				colvarAdditionalProperties.DefaultSetting = @"";
				colvarAdditionalProperties.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdditionalProperties);
				
				TableSchema.TableColumn colvarWeight = new TableSchema.TableColumn(schema);
				colvarWeight.ColumnName = "Weight";
				colvarWeight.DataType = DbType.Decimal;
				colvarWeight.MaxLength = 0;
				colvarWeight.AutoIncrement = false;
				colvarWeight.IsNullable = false;
				colvarWeight.IsPrimaryKey = false;
				colvarWeight.IsForeignKey = false;
				colvarWeight.IsReadOnly = false;
				colvarWeight.DefaultSetting = @"";
				colvarWeight.ForeignKeyTableName = "";
				schema.Columns.Add(colvarWeight);
				
				TableSchema.TableColumn colvarItemTax = new TableSchema.TableColumn(schema);
				colvarItemTax.ColumnName = "ItemTax";
				colvarItemTax.DataType = DbType.Currency;
				colvarItemTax.MaxLength = 0;
				colvarItemTax.AutoIncrement = false;
				colvarItemTax.IsNullable = false;
				colvarItemTax.IsPrimaryKey = false;
				colvarItemTax.IsForeignKey = false;
				colvarItemTax.IsReadOnly = false;
				colvarItemTax.DefaultSetting = @"";
				colvarItemTax.ForeignKeyTableName = "";
				schema.Columns.Add(colvarItemTax);
				
				TableSchema.TableColumn colvarDiscountAmount = new TableSchema.TableColumn(schema);
				colvarDiscountAmount.ColumnName = "DiscountAmount";
				colvarDiscountAmount.DataType = DbType.Currency;
				colvarDiscountAmount.MaxLength = 0;
				colvarDiscountAmount.AutoIncrement = false;
				colvarDiscountAmount.IsNullable = false;
				colvarDiscountAmount.IsPrimaryKey = false;
				colvarDiscountAmount.IsForeignKey = false;
				colvarDiscountAmount.IsReadOnly = false;
				
						colvarDiscountAmount.DefaultSetting = @"((0))";
				colvarDiscountAmount.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiscountAmount);
				
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
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_OrderItem",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("OrderItemId")]
		public int OrderItemId 
		{
			get { return GetColumnValue<int>("OrderItemId"); }

			set { SetColumnValue("OrderItemId", value); }

		}

		  
		[XmlAttribute("OrderId")]
		public int OrderId 
		{
			get { return GetColumnValue<int>("OrderId"); }

			set { SetColumnValue("OrderId", value); }

		}

		  
		[XmlAttribute("ProductId")]
		public int ProductId 
		{
			get { return GetColumnValue<int>("ProductId"); }

			set { SetColumnValue("ProductId", value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>("Name"); }

			set { SetColumnValue("Name", value); }

		}

		  
		[XmlAttribute("Sku")]
		public string Sku 
		{
			get { return GetColumnValue<string>("Sku"); }

			set { SetColumnValue("Sku", value); }

		}

		  
		[XmlAttribute("Quantity")]
		public int Quantity 
		{
			get { return GetColumnValue<int>("Quantity"); }

			set { SetColumnValue("Quantity", value); }

		}

		  
		[XmlAttribute("PricePaid")]
		public decimal PricePaid 
		{
			get { return GetColumnValue<decimal>("PricePaid"); }

			set { SetColumnValue("PricePaid", value); }

		}

		  
		[XmlAttribute("Attributes")]
		public string Attributes 
		{
			get { return GetColumnValue<string>("Attributes"); }

			set { SetColumnValue("Attributes", value); }

		}

		  
		[XmlAttribute("AdditionalProperties")]
		public string AdditionalProperties 
		{
			get { return GetColumnValue<string>("AdditionalProperties"); }

			set { SetColumnValue("AdditionalProperties", value); }

		}

		  
		[XmlAttribute("Weight")]
		public decimal Weight 
		{
			get { return GetColumnValue<decimal>("Weight"); }

			set { SetColumnValue("Weight", value); }

		}

		  
		[XmlAttribute("ItemTax")]
		public decimal ItemTax 
		{
			get { return GetColumnValue<decimal>("ItemTax"); }

			set { SetColumnValue("ItemTax", value); }

		}

		  
		[XmlAttribute("DiscountAmount")]
		public decimal DiscountAmount 
		{
			get { return GetColumnValue<decimal>("DiscountAmount"); }

			set { SetColumnValue("DiscountAmount", value); }

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
		/// Returns a Order ActiveRecord object related to this OrderItem
		/// 
		/// </summary>
		public MettleSystems.dashCommerce.Store.Order Order
		{
			get { return MettleSystems.dashCommerce.Store.Order.FetchByID(this.OrderId); }

			set { SetColumnValue("OrderId", value.OrderId); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varOrderId,int varProductId,string varName,string varSku,int varQuantity,decimal varPricePaid,string varAttributes,string varAdditionalProperties,decimal varWeight,decimal varItemTax,decimal varDiscountAmount,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			OrderItem item = new OrderItem();
			
			item.OrderId = varOrderId;
			
			item.ProductId = varProductId;
			
			item.Name = varName;
			
			item.Sku = varSku;
			
			item.Quantity = varQuantity;
			
			item.PricePaid = varPricePaid;
			
			item.Attributes = varAttributes;
			
			item.AdditionalProperties = varAdditionalProperties;
			
			item.Weight = varWeight;
			
			item.ItemTax = varItemTax;
			
			item.DiscountAmount = varDiscountAmount;
			
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
		public static void Update(int varOrderItemId,int varOrderId,int varProductId,string varName,string varSku,int varQuantity,decimal varPricePaid,string varAttributes,string varAdditionalProperties,decimal varWeight,decimal varItemTax,decimal varDiscountAmount,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			OrderItem item = new OrderItem();
			
				item.OrderItemId = varOrderItemId;
				
				item.OrderId = varOrderId;
				
				item.ProductId = varProductId;
				
				item.Name = varName;
				
				item.Sku = varSku;
				
				item.Quantity = varQuantity;
				
				item.PricePaid = varPricePaid;
				
				item.Attributes = varAttributes;
				
				item.AdditionalProperties = varAdditionalProperties;
				
				item.Weight = varWeight;
				
				item.ItemTax = varItemTax;
				
				item.DiscountAmount = varDiscountAmount;
				
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
			 public static string OrderItemId = @"OrderItemId";
			 public static string OrderId = @"OrderId";
			 public static string ProductId = @"ProductId";
			 public static string Name = @"Name";
			 public static string Sku = @"Sku";
			 public static string Quantity = @"Quantity";
			 public static string PricePaid = @"PricePaid";
			 public static string Attributes = @"Attributes";
			 public static string AdditionalProperties = @"AdditionalProperties";
			 public static string Weight = @"Weight";
			 public static string ItemTax = @"ItemTax";
			 public static string DiscountAmount = @"DiscountAmount";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}

		#endregion
	}

}

