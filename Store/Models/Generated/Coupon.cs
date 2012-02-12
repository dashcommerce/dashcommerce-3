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
	/// Strongly-typed collection for the Coupon class.
	/// </summary>
	[Serializable]
	public partial class CouponCollection : ActiveList<Coupon, CouponCollection> 
	{	   
		public CouponCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_Coupon table.
	/// </summary>
	[Serializable]
	public partial class Coupon : ActiveRecord<Coupon>
	{
		#region .ctors and Default Settings
		
		public Coupon()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Coupon(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Coupon(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Coupon(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_Coupon", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarCouponId = new TableSchema.TableColumn(schema);
				colvarCouponId.ColumnName = "CouponId";
				colvarCouponId.DataType = DbType.Int32;
				colvarCouponId.MaxLength = 0;
				colvarCouponId.AutoIncrement = true;
				colvarCouponId.IsNullable = false;
				colvarCouponId.IsPrimaryKey = true;
				colvarCouponId.IsForeignKey = false;
				colvarCouponId.IsReadOnly = false;
				colvarCouponId.DefaultSetting = @"";
				colvarCouponId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCouponId);
				
				TableSchema.TableColumn colvarCouponCode = new TableSchema.TableColumn(schema);
				colvarCouponCode.ColumnName = "CouponCode";
				colvarCouponCode.DataType = DbType.String;
				colvarCouponCode.MaxLength = 50;
				colvarCouponCode.AutoIncrement = false;
				colvarCouponCode.IsNullable = false;
				colvarCouponCode.IsPrimaryKey = false;
				colvarCouponCode.IsForeignKey = false;
				colvarCouponCode.IsReadOnly = false;
				colvarCouponCode.DefaultSetting = @"";
				colvarCouponCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCouponCode);
				
				TableSchema.TableColumn colvarExpirationDate = new TableSchema.TableColumn(schema);
				colvarExpirationDate.ColumnName = "ExpirationDate";
				colvarExpirationDate.DataType = DbType.DateTime;
				colvarExpirationDate.MaxLength = 0;
				colvarExpirationDate.AutoIncrement = false;
				colvarExpirationDate.IsNullable = true;
				colvarExpirationDate.IsPrimaryKey = false;
				colvarExpirationDate.IsForeignKey = false;
				colvarExpirationDate.IsReadOnly = false;
				colvarExpirationDate.DefaultSetting = @"";
				colvarExpirationDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExpirationDate);
				
				TableSchema.TableColumn colvarIsSingleUse = new TableSchema.TableColumn(schema);
				colvarIsSingleUse.ColumnName = "IsSingleUse";
				colvarIsSingleUse.DataType = DbType.Boolean;
				colvarIsSingleUse.MaxLength = 0;
				colvarIsSingleUse.AutoIncrement = false;
				colvarIsSingleUse.IsNullable = false;
				colvarIsSingleUse.IsPrimaryKey = false;
				colvarIsSingleUse.IsForeignKey = false;
				colvarIsSingleUse.IsReadOnly = false;
				colvarIsSingleUse.DefaultSetting = @"";
				colvarIsSingleUse.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsSingleUse);
				
				TableSchema.TableColumn colvarType = new TableSchema.TableColumn(schema);
				colvarType.ColumnName = "Type";
				colvarType.DataType = DbType.String;
				colvarType.MaxLength = 300;
				colvarType.AutoIncrement = false;
				colvarType.IsNullable = false;
				colvarType.IsPrimaryKey = false;
				colvarType.IsForeignKey = false;
				colvarType.IsReadOnly = false;
				colvarType.DefaultSetting = @"";
				colvarType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarType);
				
				TableSchema.TableColumn colvarValueX = new TableSchema.TableColumn(schema);
				colvarValueX.ColumnName = "Value";
				colvarValueX.DataType = DbType.String;
				colvarValueX.MaxLength = 1073741823;
				colvarValueX.AutoIncrement = false;
				colvarValueX.IsNullable = false;
				colvarValueX.IsPrimaryKey = false;
				colvarValueX.IsForeignKey = false;
				colvarValueX.IsReadOnly = false;
				colvarValueX.DefaultSetting = @"";
				colvarValueX.ForeignKeyTableName = "";
				schema.Columns.Add(colvarValueX);
				
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
				colvarModifiedOn.DefaultSetting = @"";
				colvarModifiedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedOn);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_Coupon",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("CouponId")]
		public int CouponId 
		{
			get { return GetColumnValue<int>("CouponId"); }

			set { SetColumnValue("CouponId", value); }

		}

		  
		[XmlAttribute("CouponCode")]
		public string CouponCode 
		{
			get { return GetColumnValue<string>("CouponCode"); }

			set { SetColumnValue("CouponCode", value); }

		}

		  
		[XmlAttribute("ExpirationDate")]
		public DateTime? ExpirationDate 
		{
			get { return GetColumnValue<DateTime?>("ExpirationDate"); }

			set { SetColumnValue("ExpirationDate", value); }

		}

		  
		[XmlAttribute("IsSingleUse")]
		public bool IsSingleUse 
		{
			get { return GetColumnValue<bool>("IsSingleUse"); }

			set { SetColumnValue("IsSingleUse", value); }

		}

		  
		[XmlAttribute("Type")]
		public string Type 
		{
			get { return GetColumnValue<string>("Type"); }

			set { SetColumnValue("Type", value); }

		}

		  
		[XmlAttribute("ValueX")]
		public string ValueX 
		{
			get { return GetColumnValue<string>("Value"); }

			set { SetColumnValue("Value", value); }

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
		public static void Insert(string varCouponCode,DateTime? varExpirationDate,bool varIsSingleUse,string varType,string varValueX,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			Coupon item = new Coupon();
			
			item.CouponCode = varCouponCode;
			
			item.ExpirationDate = varExpirationDate;
			
			item.IsSingleUse = varIsSingleUse;
			
			item.Type = varType;
			
			item.ValueX = varValueX;
			
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
		public static void Update(int varCouponId,string varCouponCode,DateTime? varExpirationDate,bool varIsSingleUse,string varType,string varValueX,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			Coupon item = new Coupon();
			
				item.CouponId = varCouponId;
				
				item.CouponCode = varCouponCode;
				
				item.ExpirationDate = varExpirationDate;
				
				item.IsSingleUse = varIsSingleUse;
				
				item.Type = varType;
				
				item.ValueX = varValueX;
				
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
			 public static string CouponId = @"CouponId";
			 public static string CouponCode = @"CouponCode";
			 public static string ExpirationDate = @"ExpirationDate";
			 public static string IsSingleUse = @"IsSingleUse";
			 public static string Type = @"Type";
			 public static string ValueX = @"Value";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}

		#endregion
	}

}

