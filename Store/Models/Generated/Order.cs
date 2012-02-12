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
	/// Strongly-typed collection for the Order class.
	/// </summary>
	[Serializable]
	public partial class OrderCollection : ActiveList<Order, OrderCollection> 
	{	   
		public OrderCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_Order table.
	/// </summary>
	[Serializable]
	public partial class Order : ActiveRecord<Order>
	{
		#region .ctors and Default Settings
		
		public Order()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Order(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Order(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Order(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_Order", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarOrderId = new TableSchema.TableColumn(schema);
				colvarOrderId.ColumnName = "OrderId";
				colvarOrderId.DataType = DbType.Int32;
				colvarOrderId.MaxLength = 0;
				colvarOrderId.AutoIncrement = true;
				colvarOrderId.IsNullable = false;
				colvarOrderId.IsPrimaryKey = true;
				colvarOrderId.IsForeignKey = false;
				colvarOrderId.IsReadOnly = false;
				colvarOrderId.DefaultSetting = @"";
				colvarOrderId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrderId);
				
				TableSchema.TableColumn colvarOrderGuid = new TableSchema.TableColumn(schema);
				colvarOrderGuid.ColumnName = "OrderGuid";
				colvarOrderGuid.DataType = DbType.Guid;
				colvarOrderGuid.MaxLength = 0;
				colvarOrderGuid.AutoIncrement = false;
				colvarOrderGuid.IsNullable = false;
				colvarOrderGuid.IsPrimaryKey = false;
				colvarOrderGuid.IsForeignKey = false;
				colvarOrderGuid.IsReadOnly = false;
				
						colvarOrderGuid.DefaultSetting = @"(newid())";
				colvarOrderGuid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrderGuid);
				
				TableSchema.TableColumn colvarOrderNumber = new TableSchema.TableColumn(schema);
				colvarOrderNumber.ColumnName = "OrderNumber";
				colvarOrderNumber.DataType = DbType.String;
				colvarOrderNumber.MaxLength = 50;
				colvarOrderNumber.AutoIncrement = false;
				colvarOrderNumber.IsNullable = true;
				colvarOrderNumber.IsPrimaryKey = false;
				colvarOrderNumber.IsForeignKey = false;
				colvarOrderNumber.IsReadOnly = false;
				colvarOrderNumber.DefaultSetting = @"";
				colvarOrderNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrderNumber);
				
				TableSchema.TableColumn colvarOrderTypeId = new TableSchema.TableColumn(schema);
				colvarOrderTypeId.ColumnName = "OrderTypeId";
				colvarOrderTypeId.DataType = DbType.Int32;
				colvarOrderTypeId.MaxLength = 0;
				colvarOrderTypeId.AutoIncrement = false;
				colvarOrderTypeId.IsNullable = false;
				colvarOrderTypeId.IsPrimaryKey = false;
				colvarOrderTypeId.IsForeignKey = false;
				colvarOrderTypeId.IsReadOnly = false;
				
						colvarOrderTypeId.DefaultSetting = @"((1))";
				colvarOrderTypeId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrderTypeId);
				
				TableSchema.TableColumn colvarOrderParentId = new TableSchema.TableColumn(schema);
				colvarOrderParentId.ColumnName = "OrderParentId";
				colvarOrderParentId.DataType = DbType.Int32;
				colvarOrderParentId.MaxLength = 0;
				colvarOrderParentId.AutoIncrement = false;
				colvarOrderParentId.IsNullable = false;
				colvarOrderParentId.IsPrimaryKey = false;
				colvarOrderParentId.IsForeignKey = false;
				colvarOrderParentId.IsReadOnly = false;
				
						colvarOrderParentId.DefaultSetting = @"((0))";
				colvarOrderParentId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrderParentId);
				
				TableSchema.TableColumn colvarOrderStatusDescriptorId = new TableSchema.TableColumn(schema);
				colvarOrderStatusDescriptorId.ColumnName = "OrderStatusDescriptorId";
				colvarOrderStatusDescriptorId.DataType = DbType.Int32;
				colvarOrderStatusDescriptorId.MaxLength = 0;
				colvarOrderStatusDescriptorId.AutoIncrement = false;
				colvarOrderStatusDescriptorId.IsNullable = false;
				colvarOrderStatusDescriptorId.IsPrimaryKey = false;
				colvarOrderStatusDescriptorId.IsForeignKey = true;
				colvarOrderStatusDescriptorId.IsReadOnly = false;
				
						colvarOrderStatusDescriptorId.DefaultSetting = @"((0))";
				
					colvarOrderStatusDescriptorId.ForeignKeyTableName = "dashCommerce_Store_OrderStatusDescriptor";
				schema.Columns.Add(colvarOrderStatusDescriptorId);
				
				TableSchema.TableColumn colvarUserName = new TableSchema.TableColumn(schema);
				colvarUserName.ColumnName = "UserName";
				colvarUserName.DataType = DbType.String;
				colvarUserName.MaxLength = 100;
				colvarUserName.AutoIncrement = false;
				colvarUserName.IsNullable = false;
				colvarUserName.IsPrimaryKey = false;
				colvarUserName.IsForeignKey = false;
				colvarUserName.IsReadOnly = false;
				colvarUserName.DefaultSetting = @"";
				colvarUserName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserName);
				
				TableSchema.TableColumn colvarShippingAmount = new TableSchema.TableColumn(schema);
				colvarShippingAmount.ColumnName = "ShippingAmount";
				colvarShippingAmount.DataType = DbType.Currency;
				colvarShippingAmount.MaxLength = 0;
				colvarShippingAmount.AutoIncrement = false;
				colvarShippingAmount.IsNullable = false;
				colvarShippingAmount.IsPrimaryKey = false;
				colvarShippingAmount.IsForeignKey = false;
				colvarShippingAmount.IsReadOnly = false;
				
						colvarShippingAmount.DefaultSetting = @"((0))";
				colvarShippingAmount.ForeignKeyTableName = "";
				schema.Columns.Add(colvarShippingAmount);
				
				TableSchema.TableColumn colvarShippingMethod = new TableSchema.TableColumn(schema);
				colvarShippingMethod.ColumnName = "ShippingMethod";
				colvarShippingMethod.DataType = DbType.String;
				colvarShippingMethod.MaxLength = 100;
				colvarShippingMethod.AutoIncrement = false;
				colvarShippingMethod.IsNullable = true;
				colvarShippingMethod.IsPrimaryKey = false;
				colvarShippingMethod.IsForeignKey = false;
				colvarShippingMethod.IsReadOnly = false;
				colvarShippingMethod.DefaultSetting = @"";
				colvarShippingMethod.ForeignKeyTableName = "";
				schema.Columns.Add(colvarShippingMethod);
				
				TableSchema.TableColumn colvarHandlingAmount = new TableSchema.TableColumn(schema);
				colvarHandlingAmount.ColumnName = "HandlingAmount";
				colvarHandlingAmount.DataType = DbType.Currency;
				colvarHandlingAmount.MaxLength = 0;
				colvarHandlingAmount.AutoIncrement = false;
				colvarHandlingAmount.IsNullable = false;
				colvarHandlingAmount.IsPrimaryKey = false;
				colvarHandlingAmount.IsForeignKey = false;
				colvarHandlingAmount.IsReadOnly = false;
				
						colvarHandlingAmount.DefaultSetting = @"((0))";
				colvarHandlingAmount.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHandlingAmount);
				
				TableSchema.TableColumn colvarBillToAddress = new TableSchema.TableColumn(schema);
				colvarBillToAddress.ColumnName = "BillToAddress";
				colvarBillToAddress.DataType = DbType.String;
				colvarBillToAddress.MaxLength = 1500;
				colvarBillToAddress.AutoIncrement = false;
				colvarBillToAddress.IsNullable = true;
				colvarBillToAddress.IsPrimaryKey = false;
				colvarBillToAddress.IsForeignKey = false;
				colvarBillToAddress.IsReadOnly = false;
				colvarBillToAddress.DefaultSetting = @"";
				colvarBillToAddress.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBillToAddress);
				
				TableSchema.TableColumn colvarShipToAddress = new TableSchema.TableColumn(schema);
				colvarShipToAddress.ColumnName = "ShipToAddress";
				colvarShipToAddress.DataType = DbType.String;
				colvarShipToAddress.MaxLength = 1500;
				colvarShipToAddress.AutoIncrement = false;
				colvarShipToAddress.IsNullable = true;
				colvarShipToAddress.IsPrimaryKey = false;
				colvarShipToAddress.IsForeignKey = false;
				colvarShipToAddress.IsReadOnly = false;
				colvarShipToAddress.DefaultSetting = @"";
				colvarShipToAddress.ForeignKeyTableName = "";
				schema.Columns.Add(colvarShipToAddress);
				
				TableSchema.TableColumn colvarIPAddress = new TableSchema.TableColumn(schema);
				colvarIPAddress.ColumnName = "IPAddress";
				colvarIPAddress.DataType = DbType.String;
				colvarIPAddress.MaxLength = 50;
				colvarIPAddress.AutoIncrement = false;
				colvarIPAddress.IsNullable = false;
				colvarIPAddress.IsPrimaryKey = false;
				colvarIPAddress.IsForeignKey = false;
				colvarIPAddress.IsReadOnly = false;
				colvarIPAddress.DefaultSetting = @"";
				colvarIPAddress.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIPAddress);
				
				TableSchema.TableColumn colvarPaymentMethod = new TableSchema.TableColumn(schema);
				colvarPaymentMethod.ColumnName = "PaymentMethod";
				colvarPaymentMethod.DataType = DbType.String;
				colvarPaymentMethod.MaxLength = 50;
				colvarPaymentMethod.AutoIncrement = false;
				colvarPaymentMethod.IsNullable = true;
				colvarPaymentMethod.IsPrimaryKey = false;
				colvarPaymentMethod.IsForeignKey = false;
				colvarPaymentMethod.IsReadOnly = false;
				colvarPaymentMethod.DefaultSetting = @"";
				colvarPaymentMethod.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPaymentMethod);
				
				TableSchema.TableColumn colvarShippingTrackingNumber = new TableSchema.TableColumn(schema);
				colvarShippingTrackingNumber.ColumnName = "ShippingTrackingNumber";
				colvarShippingTrackingNumber.DataType = DbType.String;
				colvarShippingTrackingNumber.MaxLength = 150;
				colvarShippingTrackingNumber.AutoIncrement = false;
				colvarShippingTrackingNumber.IsNullable = true;
				colvarShippingTrackingNumber.IsPrimaryKey = false;
				colvarShippingTrackingNumber.IsForeignKey = false;
				colvarShippingTrackingNumber.IsReadOnly = false;
				colvarShippingTrackingNumber.DefaultSetting = @"";
				colvarShippingTrackingNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarShippingTrackingNumber);
				
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
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_Order",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("OrderId")]
		public int OrderId 
		{
			get { return GetColumnValue<int>("OrderId"); }

			set { SetColumnValue("OrderId", value); }

		}

		  
		[XmlAttribute("OrderGuid")]
		public Guid OrderGuid 
		{
			get { return GetColumnValue<Guid>("OrderGuid"); }

			set { SetColumnValue("OrderGuid", value); }

		}

		  
		[XmlAttribute("OrderNumber")]
		public string OrderNumber 
		{
			get { return GetColumnValue<string>("OrderNumber"); }

			set { SetColumnValue("OrderNumber", value); }

		}

		  
		[XmlAttribute("OrderTypeId")]
		public int OrderTypeId 
		{
			get { return GetColumnValue<int>("OrderTypeId"); }

			set { SetColumnValue("OrderTypeId", value); }

		}

		  
		[XmlAttribute("OrderParentId")]
		public int OrderParentId 
		{
			get { return GetColumnValue<int>("OrderParentId"); }

			set { SetColumnValue("OrderParentId", value); }

		}

		  
		[XmlAttribute("OrderStatusDescriptorId")]
		public int OrderStatusDescriptorId 
		{
			get { return GetColumnValue<int>("OrderStatusDescriptorId"); }

			set { SetColumnValue("OrderStatusDescriptorId", value); }

		}

		  
		[XmlAttribute("UserName")]
		public string UserName 
		{
			get { return GetColumnValue<string>("UserName"); }

			set { SetColumnValue("UserName", value); }

		}

		  
		[XmlAttribute("ShippingAmount")]
		public decimal ShippingAmount 
		{
			get { return GetColumnValue<decimal>("ShippingAmount"); }

			set { SetColumnValue("ShippingAmount", value); }

		}

		  
		[XmlAttribute("ShippingMethod")]
		public string ShippingMethod 
		{
			get { return GetColumnValue<string>("ShippingMethod"); }

			set { SetColumnValue("ShippingMethod", value); }

		}

		  
		[XmlAttribute("HandlingAmount")]
		public decimal HandlingAmount 
		{
			get { return GetColumnValue<decimal>("HandlingAmount"); }

			set { SetColumnValue("HandlingAmount", value); }

		}

		  
		[XmlAttribute("BillToAddress")]
		public string BillToAddress 
		{
			get { return GetColumnValue<string>("BillToAddress"); }

			set { SetColumnValue("BillToAddress", value); }

		}

		  
		[XmlAttribute("ShipToAddress")]
		public string ShipToAddress 
		{
			get { return GetColumnValue<string>("ShipToAddress"); }

			set { SetColumnValue("ShipToAddress", value); }

		}

		  
		[XmlAttribute("IPAddress")]
		public string IPAddress 
		{
			get { return GetColumnValue<string>("IPAddress"); }

			set { SetColumnValue("IPAddress", value); }

		}

		  
		[XmlAttribute("PaymentMethod")]
		public string PaymentMethod 
		{
			get { return GetColumnValue<string>("PaymentMethod"); }

			set { SetColumnValue("PaymentMethod", value); }

		}

		  
		[XmlAttribute("ShippingTrackingNumber")]
		public string ShippingTrackingNumber 
		{
			get { return GetColumnValue<string>("ShippingTrackingNumber"); }

			set { SetColumnValue("ShippingTrackingNumber", value); }

		}

		  
		[XmlAttribute("AdditionalProperties")]
		public string AdditionalProperties 
		{
			get { return GetColumnValue<string>("AdditionalProperties"); }

			set { SetColumnValue("AdditionalProperties", value); }

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
		
		public MettleSystems.dashCommerce.Store.OrderItemCollection OrderItemRecords()
		{
			return new MettleSystems.dashCommerce.Store.OrderItemCollection().Where(OrderItem.Columns.OrderId, OrderId).Load();
		}

		public MettleSystems.dashCommerce.Store.OrderNoteCollection OrderNoteRecords()
		{
			return new MettleSystems.dashCommerce.Store.OrderNoteCollection().Where(OrderNote.Columns.OrderId, OrderId).Load();
		}

		public MettleSystems.dashCommerce.Store.TransactionCollection TransactionRecords()
		{
			return new MettleSystems.dashCommerce.Store.TransactionCollection().Where(Transaction.Columns.OrderId, OrderId).Load();
		}

		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a OrderStatusDescriptor ActiveRecord object related to this Order
		/// 
		/// </summary>
		public MettleSystems.dashCommerce.Store.OrderStatusDescriptor OrderStatusDescriptor
		{
			get { return MettleSystems.dashCommerce.Store.OrderStatusDescriptor.FetchByID(this.OrderStatusDescriptorId); }

			set { SetColumnValue("OrderStatusDescriptorId", value.OrderStatusDescriptorId); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(Guid varOrderGuid,string varOrderNumber,int varOrderTypeId,int varOrderParentId,int varOrderStatusDescriptorId,string varUserName,decimal varShippingAmount,string varShippingMethod,decimal varHandlingAmount,string varBillToAddress,string varShipToAddress,string varIPAddress,string varPaymentMethod,string varShippingTrackingNumber,string varAdditionalProperties,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			Order item = new Order();
			
			item.OrderGuid = varOrderGuid;
			
			item.OrderNumber = varOrderNumber;
			
			item.OrderTypeId = varOrderTypeId;
			
			item.OrderParentId = varOrderParentId;
			
			item.OrderStatusDescriptorId = varOrderStatusDescriptorId;
			
			item.UserName = varUserName;
			
			item.ShippingAmount = varShippingAmount;
			
			item.ShippingMethod = varShippingMethod;
			
			item.HandlingAmount = varHandlingAmount;
			
			item.BillToAddress = varBillToAddress;
			
			item.ShipToAddress = varShipToAddress;
			
			item.IPAddress = varIPAddress;
			
			item.PaymentMethod = varPaymentMethod;
			
			item.ShippingTrackingNumber = varShippingTrackingNumber;
			
			item.AdditionalProperties = varAdditionalProperties;
			
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
		public static void Update(int varOrderId,Guid varOrderGuid,string varOrderNumber,int varOrderTypeId,int varOrderParentId,int varOrderStatusDescriptorId,string varUserName,decimal varShippingAmount,string varShippingMethod,decimal varHandlingAmount,string varBillToAddress,string varShipToAddress,string varIPAddress,string varPaymentMethod,string varShippingTrackingNumber,string varAdditionalProperties,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			Order item = new Order();
			
				item.OrderId = varOrderId;
				
				item.OrderGuid = varOrderGuid;
				
				item.OrderNumber = varOrderNumber;
				
				item.OrderTypeId = varOrderTypeId;
				
				item.OrderParentId = varOrderParentId;
				
				item.OrderStatusDescriptorId = varOrderStatusDescriptorId;
				
				item.UserName = varUserName;
				
				item.ShippingAmount = varShippingAmount;
				
				item.ShippingMethod = varShippingMethod;
				
				item.HandlingAmount = varHandlingAmount;
				
				item.BillToAddress = varBillToAddress;
				
				item.ShipToAddress = varShipToAddress;
				
				item.IPAddress = varIPAddress;
				
				item.PaymentMethod = varPaymentMethod;
				
				item.ShippingTrackingNumber = varShippingTrackingNumber;
				
				item.AdditionalProperties = varAdditionalProperties;
				
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
			 public static string OrderId = @"OrderId";
			 public static string OrderGuid = @"OrderGuid";
			 public static string OrderNumber = @"OrderNumber";
			 public static string OrderTypeId = @"OrderTypeId";
			 public static string OrderParentId = @"OrderParentId";
			 public static string OrderStatusDescriptorId = @"OrderStatusDescriptorId";
			 public static string UserName = @"UserName";
			 public static string ShippingAmount = @"ShippingAmount";
			 public static string ShippingMethod = @"ShippingMethod";
			 public static string HandlingAmount = @"HandlingAmount";
			 public static string BillToAddress = @"BillToAddress";
			 public static string ShipToAddress = @"ShipToAddress";
			 public static string IPAddress = @"IPAddress";
			 public static string PaymentMethod = @"PaymentMethod";
			 public static string ShippingTrackingNumber = @"ShippingTrackingNumber";
			 public static string AdditionalProperties = @"AdditionalProperties";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}

		#endregion
	}

}

