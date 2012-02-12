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
	/// Strongly-typed collection for the Transaction class.
	/// </summary>
	[Serializable]
	public partial class TransactionCollection : ActiveList<Transaction, TransactionCollection> 
	{	   
		public TransactionCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_Transaction table.
	/// </summary>
	[Serializable]
	public partial class Transaction : ActiveRecord<Transaction>
	{
		#region .ctors and Default Settings
		
		public Transaction()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Transaction(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Transaction(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Transaction(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_Transaction", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarTransactionId = new TableSchema.TableColumn(schema);
				colvarTransactionId.ColumnName = "TransactionId";
				colvarTransactionId.DataType = DbType.Int32;
				colvarTransactionId.MaxLength = 0;
				colvarTransactionId.AutoIncrement = true;
				colvarTransactionId.IsNullable = false;
				colvarTransactionId.IsPrimaryKey = true;
				colvarTransactionId.IsForeignKey = false;
				colvarTransactionId.IsReadOnly = false;
				colvarTransactionId.DefaultSetting = @"";
				colvarTransactionId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTransactionId);
				
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
				
				TableSchema.TableColumn colvarTransactionTypeDescriptorId = new TableSchema.TableColumn(schema);
				colvarTransactionTypeDescriptorId.ColumnName = "TransactionTypeDescriptorId";
				colvarTransactionTypeDescriptorId.DataType = DbType.Int32;
				colvarTransactionTypeDescriptorId.MaxLength = 0;
				colvarTransactionTypeDescriptorId.AutoIncrement = false;
				colvarTransactionTypeDescriptorId.IsNullable = false;
				colvarTransactionTypeDescriptorId.IsPrimaryKey = false;
				colvarTransactionTypeDescriptorId.IsForeignKey = true;
				colvarTransactionTypeDescriptorId.IsReadOnly = false;
				
						colvarTransactionTypeDescriptorId.DefaultSetting = @"((1))";
				
					colvarTransactionTypeDescriptorId.ForeignKeyTableName = "dashCommerce_Store_TransactionTypeDescriptor";
				schema.Columns.Add(colvarTransactionTypeDescriptorId);
				
				TableSchema.TableColumn colvarPaymentMethod = new TableSchema.TableColumn(schema);
				colvarPaymentMethod.ColumnName = "PaymentMethod";
				colvarPaymentMethod.DataType = DbType.String;
				colvarPaymentMethod.MaxLength = 50;
				colvarPaymentMethod.AutoIncrement = false;
				colvarPaymentMethod.IsNullable = false;
				colvarPaymentMethod.IsPrimaryKey = false;
				colvarPaymentMethod.IsForeignKey = false;
				colvarPaymentMethod.IsReadOnly = false;
				colvarPaymentMethod.DefaultSetting = @"";
				colvarPaymentMethod.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPaymentMethod);
				
				TableSchema.TableColumn colvarGatewayName = new TableSchema.TableColumn(schema);
				colvarGatewayName.ColumnName = "GatewayName";
				colvarGatewayName.DataType = DbType.String;
				colvarGatewayName.MaxLength = 50;
				colvarGatewayName.AutoIncrement = false;
				colvarGatewayName.IsNullable = false;
				colvarGatewayName.IsPrimaryKey = false;
				colvarGatewayName.IsForeignKey = false;
				colvarGatewayName.IsReadOnly = false;
				colvarGatewayName.DefaultSetting = @"";
				colvarGatewayName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGatewayName);
				
				TableSchema.TableColumn colvarGatewayResponse = new TableSchema.TableColumn(schema);
				colvarGatewayResponse.ColumnName = "GatewayResponse";
				colvarGatewayResponse.DataType = DbType.String;
				colvarGatewayResponse.MaxLength = 50;
				colvarGatewayResponse.AutoIncrement = false;
				colvarGatewayResponse.IsNullable = false;
				colvarGatewayResponse.IsPrimaryKey = false;
				colvarGatewayResponse.IsForeignKey = false;
				colvarGatewayResponse.IsReadOnly = false;
				colvarGatewayResponse.DefaultSetting = @"";
				colvarGatewayResponse.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGatewayResponse);
				
				TableSchema.TableColumn colvarGatewayTransactionId = new TableSchema.TableColumn(schema);
				colvarGatewayTransactionId.ColumnName = "GatewayTransactionId";
				colvarGatewayTransactionId.DataType = DbType.String;
				colvarGatewayTransactionId.MaxLength = 100;
				colvarGatewayTransactionId.AutoIncrement = false;
				colvarGatewayTransactionId.IsNullable = false;
				colvarGatewayTransactionId.IsPrimaryKey = false;
				colvarGatewayTransactionId.IsForeignKey = false;
				colvarGatewayTransactionId.IsReadOnly = false;
				colvarGatewayTransactionId.DefaultSetting = @"";
				colvarGatewayTransactionId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGatewayTransactionId);
				
				TableSchema.TableColumn colvarAVSCode = new TableSchema.TableColumn(schema);
				colvarAVSCode.ColumnName = "AVSCode";
				colvarAVSCode.DataType = DbType.String;
				colvarAVSCode.MaxLength = 20;
				colvarAVSCode.AutoIncrement = false;
				colvarAVSCode.IsNullable = false;
				colvarAVSCode.IsPrimaryKey = false;
				colvarAVSCode.IsForeignKey = false;
				colvarAVSCode.IsReadOnly = false;
				colvarAVSCode.DefaultSetting = @"";
				colvarAVSCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAVSCode);
				
				TableSchema.TableColumn colvarCVV2Code = new TableSchema.TableColumn(schema);
				colvarCVV2Code.ColumnName = "CVV2Code";
				colvarCVV2Code.DataType = DbType.String;
				colvarCVV2Code.MaxLength = 20;
				colvarCVV2Code.AutoIncrement = false;
				colvarCVV2Code.IsNullable = false;
				colvarCVV2Code.IsPrimaryKey = false;
				colvarCVV2Code.IsForeignKey = false;
				colvarCVV2Code.IsReadOnly = false;
				colvarCVV2Code.DefaultSetting = @"";
				colvarCVV2Code.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCVV2Code);
				
				TableSchema.TableColumn colvarGrossAmount = new TableSchema.TableColumn(schema);
				colvarGrossAmount.ColumnName = "GrossAmount";
				colvarGrossAmount.DataType = DbType.Currency;
				colvarGrossAmount.MaxLength = 0;
				colvarGrossAmount.AutoIncrement = false;
				colvarGrossAmount.IsNullable = false;
				colvarGrossAmount.IsPrimaryKey = false;
				colvarGrossAmount.IsForeignKey = false;
				colvarGrossAmount.IsReadOnly = false;
				
						colvarGrossAmount.DefaultSetting = @"((0))";
				colvarGrossAmount.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGrossAmount);
				
				TableSchema.TableColumn colvarNetAmount = new TableSchema.TableColumn(schema);
				colvarNetAmount.ColumnName = "NetAmount";
				colvarNetAmount.DataType = DbType.Currency;
				colvarNetAmount.MaxLength = 0;
				colvarNetAmount.AutoIncrement = false;
				colvarNetAmount.IsNullable = false;
				colvarNetAmount.IsPrimaryKey = false;
				colvarNetAmount.IsForeignKey = false;
				colvarNetAmount.IsReadOnly = false;
				colvarNetAmount.DefaultSetting = @"";
				colvarNetAmount.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNetAmount);
				
				TableSchema.TableColumn colvarFeeAmount = new TableSchema.TableColumn(schema);
				colvarFeeAmount.ColumnName = "FeeAmount";
				colvarFeeAmount.DataType = DbType.Currency;
				colvarFeeAmount.MaxLength = 0;
				colvarFeeAmount.AutoIncrement = false;
				colvarFeeAmount.IsNullable = false;
				colvarFeeAmount.IsPrimaryKey = false;
				colvarFeeAmount.IsForeignKey = false;
				colvarFeeAmount.IsReadOnly = false;
				colvarFeeAmount.DefaultSetting = @"";
				colvarFeeAmount.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFeeAmount);
				
				TableSchema.TableColumn colvarTransactionDate = new TableSchema.TableColumn(schema);
				colvarTransactionDate.ColumnName = "TransactionDate";
				colvarTransactionDate.DataType = DbType.DateTime;
				colvarTransactionDate.MaxLength = 0;
				colvarTransactionDate.AutoIncrement = false;
				colvarTransactionDate.IsNullable = false;
				colvarTransactionDate.IsPrimaryKey = false;
				colvarTransactionDate.IsForeignKey = false;
				colvarTransactionDate.IsReadOnly = false;
				
						colvarTransactionDate.DefaultSetting = @"(getdate())";
				colvarTransactionDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTransactionDate);
				
				TableSchema.TableColumn colvarGatewayErrors = new TableSchema.TableColumn(schema);
				colvarGatewayErrors.ColumnName = "GatewayErrors";
				colvarGatewayErrors.DataType = DbType.String;
				colvarGatewayErrors.MaxLength = 500;
				colvarGatewayErrors.AutoIncrement = false;
				colvarGatewayErrors.IsNullable = true;
				colvarGatewayErrors.IsPrimaryKey = false;
				colvarGatewayErrors.IsForeignKey = false;
				colvarGatewayErrors.IsReadOnly = false;
				colvarGatewayErrors.DefaultSetting = @"";
				colvarGatewayErrors.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGatewayErrors);
				
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
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_Transaction",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("TransactionId")]
		public int TransactionId 
		{
			get { return GetColumnValue<int>("TransactionId"); }

			set { SetColumnValue("TransactionId", value); }

		}

		  
		[XmlAttribute("OrderId")]
		public int OrderId 
		{
			get { return GetColumnValue<int>("OrderId"); }

			set { SetColumnValue("OrderId", value); }

		}

		  
		[XmlAttribute("TransactionTypeDescriptorId")]
		public int TransactionTypeDescriptorId 
		{
			get { return GetColumnValue<int>("TransactionTypeDescriptorId"); }

			set { SetColumnValue("TransactionTypeDescriptorId", value); }

		}

		  
		[XmlAttribute("PaymentMethod")]
		public string PaymentMethod 
		{
			get { return GetColumnValue<string>("PaymentMethod"); }

			set { SetColumnValue("PaymentMethod", value); }

		}

		  
		[XmlAttribute("GatewayName")]
		public string GatewayName 
		{
			get { return GetColumnValue<string>("GatewayName"); }

			set { SetColumnValue("GatewayName", value); }

		}

		  
		[XmlAttribute("GatewayResponse")]
		public string GatewayResponse 
		{
			get { return GetColumnValue<string>("GatewayResponse"); }

			set { SetColumnValue("GatewayResponse", value); }

		}

		  
		[XmlAttribute("GatewayTransactionId")]
		public string GatewayTransactionId 
		{
			get { return GetColumnValue<string>("GatewayTransactionId"); }

			set { SetColumnValue("GatewayTransactionId", value); }

		}

		  
		[XmlAttribute("AVSCode")]
		public string AVSCode 
		{
			get { return GetColumnValue<string>("AVSCode"); }

			set { SetColumnValue("AVSCode", value); }

		}

		  
		[XmlAttribute("CVV2Code")]
		public string CVV2Code 
		{
			get { return GetColumnValue<string>("CVV2Code"); }

			set { SetColumnValue("CVV2Code", value); }

		}

		  
		[XmlAttribute("GrossAmount")]
		public decimal GrossAmount 
		{
			get { return GetColumnValue<decimal>("GrossAmount"); }

			set { SetColumnValue("GrossAmount", value); }

		}

		  
		[XmlAttribute("NetAmount")]
		public decimal NetAmount 
		{
			get { return GetColumnValue<decimal>("NetAmount"); }

			set { SetColumnValue("NetAmount", value); }

		}

		  
		[XmlAttribute("FeeAmount")]
		public decimal FeeAmount 
		{
			get { return GetColumnValue<decimal>("FeeAmount"); }

			set { SetColumnValue("FeeAmount", value); }

		}

		  
		[XmlAttribute("TransactionDate")]
		public DateTime TransactionDate 
		{
			get { return GetColumnValue<DateTime>("TransactionDate"); }

			set { SetColumnValue("TransactionDate", value); }

		}

		  
		[XmlAttribute("GatewayErrors")]
		public string GatewayErrors 
		{
			get { return GetColumnValue<string>("GatewayErrors"); }

			set { SetColumnValue("GatewayErrors", value); }

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
		/// Returns a TransactionTypeDescriptor ActiveRecord object related to this Transaction
		/// 
		/// </summary>
		public MettleSystems.dashCommerce.Store.TransactionTypeDescriptor TransactionTypeDescriptor
		{
			get { return MettleSystems.dashCommerce.Store.TransactionTypeDescriptor.FetchByID(this.TransactionTypeDescriptorId); }

			set { SetColumnValue("TransactionTypeDescriptorId", value.TransactionTypeDescriptorId); }

		}

		
		
		/// <summary>
		/// Returns a Order ActiveRecord object related to this Transaction
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
		public static void Insert(int varOrderId,int varTransactionTypeDescriptorId,string varPaymentMethod,string varGatewayName,string varGatewayResponse,string varGatewayTransactionId,string varAVSCode,string varCVV2Code,decimal varGrossAmount,decimal varNetAmount,decimal varFeeAmount,DateTime varTransactionDate,string varGatewayErrors,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			Transaction item = new Transaction();
			
			item.OrderId = varOrderId;
			
			item.TransactionTypeDescriptorId = varTransactionTypeDescriptorId;
			
			item.PaymentMethod = varPaymentMethod;
			
			item.GatewayName = varGatewayName;
			
			item.GatewayResponse = varGatewayResponse;
			
			item.GatewayTransactionId = varGatewayTransactionId;
			
			item.AVSCode = varAVSCode;
			
			item.CVV2Code = varCVV2Code;
			
			item.GrossAmount = varGrossAmount;
			
			item.NetAmount = varNetAmount;
			
			item.FeeAmount = varFeeAmount;
			
			item.TransactionDate = varTransactionDate;
			
			item.GatewayErrors = varGatewayErrors;
			
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
		public static void Update(int varTransactionId,int varOrderId,int varTransactionTypeDescriptorId,string varPaymentMethod,string varGatewayName,string varGatewayResponse,string varGatewayTransactionId,string varAVSCode,string varCVV2Code,decimal varGrossAmount,decimal varNetAmount,decimal varFeeAmount,DateTime varTransactionDate,string varGatewayErrors,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			Transaction item = new Transaction();
			
				item.TransactionId = varTransactionId;
				
				item.OrderId = varOrderId;
				
				item.TransactionTypeDescriptorId = varTransactionTypeDescriptorId;
				
				item.PaymentMethod = varPaymentMethod;
				
				item.GatewayName = varGatewayName;
				
				item.GatewayResponse = varGatewayResponse;
				
				item.GatewayTransactionId = varGatewayTransactionId;
				
				item.AVSCode = varAVSCode;
				
				item.CVV2Code = varCVV2Code;
				
				item.GrossAmount = varGrossAmount;
				
				item.NetAmount = varNetAmount;
				
				item.FeeAmount = varFeeAmount;
				
				item.TransactionDate = varTransactionDate;
				
				item.GatewayErrors = varGatewayErrors;
				
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
			 public static string TransactionId = @"TransactionId";
			 public static string OrderId = @"OrderId";
			 public static string TransactionTypeDescriptorId = @"TransactionTypeDescriptorId";
			 public static string PaymentMethod = @"PaymentMethod";
			 public static string GatewayName = @"GatewayName";
			 public static string GatewayResponse = @"GatewayResponse";
			 public static string GatewayTransactionId = @"GatewayTransactionId";
			 public static string AVSCode = @"AVSCode";
			 public static string CVV2Code = @"CVV2Code";
			 public static string GrossAmount = @"GrossAmount";
			 public static string NetAmount = @"NetAmount";
			 public static string FeeAmount = @"FeeAmount";
			 public static string TransactionDate = @"TransactionDate";
			 public static string GatewayErrors = @"GatewayErrors";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}

		#endregion
	}

}

