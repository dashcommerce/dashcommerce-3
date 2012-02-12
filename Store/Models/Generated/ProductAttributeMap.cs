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
	/// Strongly-typed collection for the ProductAttributeMap class.
	/// </summary>
	[Serializable]
	public partial class ProductAttributeMapCollection : ActiveList<ProductAttributeMap, ProductAttributeMapCollection> 
	{	   
		public ProductAttributeMapCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_Product_Attribute_Map table.
	/// </summary>
	[Serializable]
	public partial class ProductAttributeMap : ActiveRecord<ProductAttributeMap>
	{
		#region .ctors and Default Settings
		
		public ProductAttributeMap()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public ProductAttributeMap(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public ProductAttributeMap(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public ProductAttributeMap(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_Product_Attribute_Map", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarAttributeId = new TableSchema.TableColumn(schema);
				colvarAttributeId.ColumnName = "AttributeId";
				colvarAttributeId.DataType = DbType.Int32;
				colvarAttributeId.MaxLength = 0;
				colvarAttributeId.AutoIncrement = false;
				colvarAttributeId.IsNullable = false;
				colvarAttributeId.IsPrimaryKey = true;
				colvarAttributeId.IsForeignKey = true;
				colvarAttributeId.IsReadOnly = false;
				colvarAttributeId.DefaultSetting = @"";
				
					colvarAttributeId.ForeignKeyTableName = "dashCommerce_Store_Attribute";
				schema.Columns.Add(colvarAttributeId);
				
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
				
				TableSchema.TableColumn colvarSortOrder = new TableSchema.TableColumn(schema);
				colvarSortOrder.ColumnName = "SortOrder";
				colvarSortOrder.DataType = DbType.Int32;
				colvarSortOrder.MaxLength = 0;
				colvarSortOrder.AutoIncrement = false;
				colvarSortOrder.IsNullable = false;
				colvarSortOrder.IsPrimaryKey = false;
				colvarSortOrder.IsForeignKey = false;
				colvarSortOrder.IsReadOnly = false;
				
						colvarSortOrder.DefaultSetting = @"((0))";
				colvarSortOrder.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSortOrder);
				
				TableSchema.TableColumn colvarIsRequired = new TableSchema.TableColumn(schema);
				colvarIsRequired.ColumnName = "IsRequired";
				colvarIsRequired.DataType = DbType.Boolean;
				colvarIsRequired.MaxLength = 0;
				colvarIsRequired.AutoIncrement = false;
				colvarIsRequired.IsNullable = false;
				colvarIsRequired.IsPrimaryKey = false;
				colvarIsRequired.IsForeignKey = false;
				colvarIsRequired.IsReadOnly = false;
				
						colvarIsRequired.DefaultSetting = @"((0))";
				colvarIsRequired.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsRequired);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_Product_Attribute_Map",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("AttributeId")]
		public int AttributeId 
		{
			get { return GetColumnValue<int>("AttributeId"); }

			set { SetColumnValue("AttributeId", value); }

		}

		  
		[XmlAttribute("ProductId")]
		public int ProductId 
		{
			get { return GetColumnValue<int>("ProductId"); }

			set { SetColumnValue("ProductId", value); }

		}

		  
		[XmlAttribute("SortOrder")]
		public int SortOrder 
		{
			get { return GetColumnValue<int>("SortOrder"); }

			set { SetColumnValue("SortOrder", value); }

		}

		  
		[XmlAttribute("IsRequired")]
		public bool IsRequired 
		{
			get { return GetColumnValue<bool>("IsRequired"); }

			set { SetColumnValue("IsRequired", value); }

		}

		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Product ActiveRecord object related to this ProductAttributeMap
		/// 
		/// </summary>
		public MettleSystems.dashCommerce.Store.Product Product
		{
			get { return MettleSystems.dashCommerce.Store.Product.FetchByID(this.ProductId); }

			set { SetColumnValue("ProductId", value.ProductId); }

		}

		
		
		/// <summary>
		/// Returns a Attribute ActiveRecord object related to this ProductAttributeMap
		/// 
		/// </summary>
		public MettleSystems.dashCommerce.Store.Attribute Attribute
		{
			get { return MettleSystems.dashCommerce.Store.Attribute.FetchByID(this.AttributeId); }

			set { SetColumnValue("AttributeId", value.AttributeId); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varAttributeId,int varProductId,int varSortOrder,bool varIsRequired)
		{
			ProductAttributeMap item = new ProductAttributeMap();
			
			item.AttributeId = varAttributeId;
			
			item.ProductId = varProductId;
			
			item.SortOrder = varSortOrder;
			
			item.IsRequired = varIsRequired;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varAttributeId,int varProductId,int varSortOrder,bool varIsRequired)
		{
			ProductAttributeMap item = new ProductAttributeMap();
			
				item.AttributeId = varAttributeId;
				
				item.ProductId = varProductId;
				
				item.SortOrder = varSortOrder;
				
				item.IsRequired = varIsRequired;
				
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
			 public static string AttributeId = @"AttributeId";
			 public static string ProductId = @"ProductId";
			 public static string SortOrder = @"SortOrder";
			 public static string IsRequired = @"IsRequired";
						
		}

		#endregion
	}

}

