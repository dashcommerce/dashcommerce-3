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
	/// Strongly-typed collection for the CustomizedProductDisplayTypeProductMap class.
	/// </summary>
	[Serializable]
	public partial class CustomizedProductDisplayTypeProductMapCollection : ActiveList<CustomizedProductDisplayTypeProductMap, CustomizedProductDisplayTypeProductMapCollection> 
	{	   
		public CustomizedProductDisplayTypeProductMapCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_CustomizedProductDisplayType_Product_Map table.
	/// </summary>
	[Serializable]
	public partial class CustomizedProductDisplayTypeProductMap : ActiveRecord<CustomizedProductDisplayTypeProductMap>
	{
		#region .ctors and Default Settings
		
		public CustomizedProductDisplayTypeProductMap()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public CustomizedProductDisplayTypeProductMap(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public CustomizedProductDisplayTypeProductMap(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public CustomizedProductDisplayTypeProductMap(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_CustomizedProductDisplayType_Product_Map", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarCustomizedProductDisplayTypeId = new TableSchema.TableColumn(schema);
				colvarCustomizedProductDisplayTypeId.ColumnName = "CustomizedProductDisplayTypeId";
				colvarCustomizedProductDisplayTypeId.DataType = DbType.Int32;
				colvarCustomizedProductDisplayTypeId.MaxLength = 0;
				colvarCustomizedProductDisplayTypeId.AutoIncrement = false;
				colvarCustomizedProductDisplayTypeId.IsNullable = false;
				colvarCustomizedProductDisplayTypeId.IsPrimaryKey = true;
				colvarCustomizedProductDisplayTypeId.IsForeignKey = true;
				colvarCustomizedProductDisplayTypeId.IsReadOnly = false;
				colvarCustomizedProductDisplayTypeId.DefaultSetting = @"";
				
					colvarCustomizedProductDisplayTypeId.ForeignKeyTableName = "dashCommerce_Store_CustomizedProductDisplayType";
				schema.Columns.Add(colvarCustomizedProductDisplayTypeId);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_CustomizedProductDisplayType_Product_Map",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("CustomizedProductDisplayTypeId")]
		public int CustomizedProductDisplayTypeId 
		{
			get { return GetColumnValue<int>("CustomizedProductDisplayTypeId"); }

			set { SetColumnValue("CustomizedProductDisplayTypeId", value); }

		}

		  
		[XmlAttribute("ProductId")]
		public int ProductId 
		{
			get { return GetColumnValue<int>("ProductId"); }

			set { SetColumnValue("ProductId", value); }

		}

		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Product ActiveRecord object related to this CustomizedProductDisplayTypeProductMap
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
		public static void Insert(int varCustomizedProductDisplayTypeId,int varProductId)
		{
			CustomizedProductDisplayTypeProductMap item = new CustomizedProductDisplayTypeProductMap();
			
			item.CustomizedProductDisplayTypeId = varCustomizedProductDisplayTypeId;
			
			item.ProductId = varProductId;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varCustomizedProductDisplayTypeId,int varProductId)
		{
			CustomizedProductDisplayTypeProductMap item = new CustomizedProductDisplayTypeProductMap();
			
				item.CustomizedProductDisplayTypeId = varCustomizedProductDisplayTypeId;
				
				item.ProductId = varProductId;
				
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
			 public static string CustomizedProductDisplayTypeId = @"CustomizedProductDisplayTypeId";
			 public static string ProductId = @"ProductId";
						
		}

		#endregion
	}

}

