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
	/// Strongly-typed collection for the ProductDownloadMap class.
	/// </summary>
	[Serializable]
	public partial class ProductDownloadMapCollection : ActiveList<ProductDownloadMap, ProductDownloadMapCollection> 
	{	   
		public ProductDownloadMapCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_Product_Download_Map table.
	/// </summary>
	[Serializable]
	public partial class ProductDownloadMap : ActiveRecord<ProductDownloadMap>
	{
		#region .ctors and Default Settings
		
		public ProductDownloadMap()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public ProductDownloadMap(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public ProductDownloadMap(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public ProductDownloadMap(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_Product_Download_Map", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
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
				
				TableSchema.TableColumn colvarDownloadId = new TableSchema.TableColumn(schema);
				colvarDownloadId.ColumnName = "DownloadId";
				colvarDownloadId.DataType = DbType.Int32;
				colvarDownloadId.MaxLength = 0;
				colvarDownloadId.AutoIncrement = false;
				colvarDownloadId.IsNullable = false;
				colvarDownloadId.IsPrimaryKey = true;
				colvarDownloadId.IsForeignKey = true;
				colvarDownloadId.IsReadOnly = false;
				colvarDownloadId.DefaultSetting = @"";
				
					colvarDownloadId.ForeignKeyTableName = "dashCommerce_Store_Download";
				schema.Columns.Add(colvarDownloadId);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_Product_Download_Map",schema);
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

		  
		[XmlAttribute("DownloadId")]
		public int DownloadId 
		{
			get { return GetColumnValue<int>("DownloadId"); }

			set { SetColumnValue("DownloadId", value); }

		}

		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Download ActiveRecord object related to this ProductDownloadMap
		/// 
		/// </summary>
		public MettleSystems.dashCommerce.Store.Download Download
		{
			get { return MettleSystems.dashCommerce.Store.Download.FetchByID(this.DownloadId); }

			set { SetColumnValue("DownloadId", value.DownloadId); }

		}

		
		
		/// <summary>
		/// Returns a Product ActiveRecord object related to this ProductDownloadMap
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
		public static void Insert(int varProductId,int varDownloadId)
		{
			ProductDownloadMap item = new ProductDownloadMap();
			
			item.ProductId = varProductId;
			
			item.DownloadId = varDownloadId;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varProductId,int varDownloadId)
		{
			ProductDownloadMap item = new ProductDownloadMap();
			
				item.ProductId = varProductId;
				
				item.DownloadId = varDownloadId;
				
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
			 public static string DownloadId = @"DownloadId";
						
		}

		#endregion
	}

}

