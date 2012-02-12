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
	/// Strongly-typed collection for the SimpleWeightShippingRate class.
	/// </summary>
	[Serializable]
	public partial class SimpleWeightShippingRateCollection : ActiveList<SimpleWeightShippingRate, SimpleWeightShippingRateCollection> 
	{	   
		public SimpleWeightShippingRateCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_SimpleWeightShippingRate table.
	/// </summary>
	[Serializable]
	public partial class SimpleWeightShippingRate : ActiveRecord<SimpleWeightShippingRate>
	{
		#region .ctors and Default Settings
		
		public SimpleWeightShippingRate()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public SimpleWeightShippingRate(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public SimpleWeightShippingRate(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public SimpleWeightShippingRate(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_SimpleWeightShippingRate", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarSimpleWeightShippingRateId = new TableSchema.TableColumn(schema);
				colvarSimpleWeightShippingRateId.ColumnName = "SimpleWeightShippingRateId";
				colvarSimpleWeightShippingRateId.DataType = DbType.Int32;
				colvarSimpleWeightShippingRateId.MaxLength = 0;
				colvarSimpleWeightShippingRateId.AutoIncrement = true;
				colvarSimpleWeightShippingRateId.IsNullable = false;
				colvarSimpleWeightShippingRateId.IsPrimaryKey = true;
				colvarSimpleWeightShippingRateId.IsForeignKey = false;
				colvarSimpleWeightShippingRateId.IsReadOnly = false;
				colvarSimpleWeightShippingRateId.DefaultSetting = @"";
				colvarSimpleWeightShippingRateId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSimpleWeightShippingRateId);
				
				TableSchema.TableColumn colvarService = new TableSchema.TableColumn(schema);
				colvarService.ColumnName = "Service";
				colvarService.DataType = DbType.String;
				colvarService.MaxLength = 50;
				colvarService.AutoIncrement = false;
				colvarService.IsNullable = false;
				colvarService.IsPrimaryKey = false;
				colvarService.IsForeignKey = false;
				colvarService.IsReadOnly = false;
				colvarService.DefaultSetting = @"";
				colvarService.ForeignKeyTableName = "";
				schema.Columns.Add(colvarService);
				
				TableSchema.TableColumn colvarAmountPerUnit = new TableSchema.TableColumn(schema);
				colvarAmountPerUnit.ColumnName = "AmountPerUnit";
				colvarAmountPerUnit.DataType = DbType.Currency;
				colvarAmountPerUnit.MaxLength = 0;
				colvarAmountPerUnit.AutoIncrement = false;
				colvarAmountPerUnit.IsNullable = false;
				colvarAmountPerUnit.IsPrimaryKey = false;
				colvarAmountPerUnit.IsForeignKey = false;
				colvarAmountPerUnit.IsReadOnly = false;
				colvarAmountPerUnit.DefaultSetting = @"";
				colvarAmountPerUnit.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAmountPerUnit);
				
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
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_SimpleWeightShippingRate",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("SimpleWeightShippingRateId")]
		public int SimpleWeightShippingRateId 
		{
			get { return GetColumnValue<int>("SimpleWeightShippingRateId"); }

			set { SetColumnValue("SimpleWeightShippingRateId", value); }

		}

		  
		[XmlAttribute("Service")]
		public string Service 
		{
			get { return GetColumnValue<string>("Service"); }

			set { SetColumnValue("Service", value); }

		}

		  
		[XmlAttribute("AmountPerUnit")]
		public decimal AmountPerUnit 
		{
			get { return GetColumnValue<decimal>("AmountPerUnit"); }

			set { SetColumnValue("AmountPerUnit", value); }

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
		public static void Insert(string varService,decimal varAmountPerUnit,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			SimpleWeightShippingRate item = new SimpleWeightShippingRate();
			
			item.Service = varService;
			
			item.AmountPerUnit = varAmountPerUnit;
			
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
		public static void Update(int varSimpleWeightShippingRateId,string varService,decimal varAmountPerUnit,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			SimpleWeightShippingRate item = new SimpleWeightShippingRate();
			
				item.SimpleWeightShippingRateId = varSimpleWeightShippingRateId;
				
				item.Service = varService;
				
				item.AmountPerUnit = varAmountPerUnit;
				
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
			 public static string SimpleWeightShippingRateId = @"SimpleWeightShippingRateId";
			 public static string Service = @"Service";
			 public static string AmountPerUnit = @"AmountPerUnit";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}

		#endregion
	}

}

