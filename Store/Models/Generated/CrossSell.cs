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
	/// Strongly-typed collection for the CrossSell class.
	/// </summary>
	[Serializable]
	public partial class CrossSellCollection : ActiveList<CrossSell, CrossSellCollection> 
	{	   
		public CrossSellCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_CrossSell table.
	/// </summary>
	[Serializable]
	public partial class CrossSell : ActiveRecord<CrossSell>
	{
		#region .ctors and Default Settings
		
		public CrossSell()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public CrossSell(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public CrossSell(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public CrossSell(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_CrossSell", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
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
				
				TableSchema.TableColumn colvarCrossProductId = new TableSchema.TableColumn(schema);
				colvarCrossProductId.ColumnName = "CrossProductId";
				colvarCrossProductId.DataType = DbType.Int32;
				colvarCrossProductId.MaxLength = 0;
				colvarCrossProductId.AutoIncrement = false;
				colvarCrossProductId.IsNullable = false;
				colvarCrossProductId.IsPrimaryKey = true;
				colvarCrossProductId.IsForeignKey = true;
				colvarCrossProductId.IsReadOnly = false;
				colvarCrossProductId.DefaultSetting = @"";
				
					colvarCrossProductId.ForeignKeyTableName = "dashCommerce_Store_Product";
				schema.Columns.Add(colvarCrossProductId);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_CrossSell",schema);
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

		  
		[XmlAttribute("CrossProductId")]
		public int CrossProductId 
		{
			get { return GetColumnValue<int>("CrossProductId"); }

			set { SetColumnValue("CrossProductId", value); }

		}

		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Product ActiveRecord object related to this CrossSell
		/// 
		/// </summary>
		public MettleSystems.dashCommerce.Store.Product Product
		{
			get { return MettleSystems.dashCommerce.Store.Product.FetchByID(this.ProductId); }

			set { SetColumnValue("ProductId", value.ProductId); }

		}

		
		
		/// <summary>
		/// Returns a Product ActiveRecord object related to this CrossSell
		/// 
		/// </summary>
		public MettleSystems.dashCommerce.Store.Product ProductToCrossProductId
		{
			get { return MettleSystems.dashCommerce.Store.Product.FetchByID(this.CrossProductId); }

			set { SetColumnValue("CrossProductId", value.ProductId); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varProductId,int varCrossProductId)
		{
			CrossSell item = new CrossSell();
			
			item.ProductId = varProductId;
			
			item.CrossProductId = varCrossProductId;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varProductId,int varCrossProductId)
		{
			CrossSell item = new CrossSell();
			
				item.ProductId = varProductId;
				
				item.CrossProductId = varCrossProductId;
				
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
			 public static string CrossProductId = @"CrossProductId";
						
		}

		#endregion
	}

}

