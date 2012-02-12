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

namespace MettleSystems.dashCommerce.Content
{
	/// <summary>
	/// Strongly-typed collection for the PageRegionMap class.
	/// </summary>
	[Serializable]
	public partial class PageRegionMapCollection : ActiveList<PageRegionMap, PageRegionMapCollection> 
	{	   
		public PageRegionMapCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Content_Page_Region_Map table.
	/// </summary>
	[Serializable]
	public partial class PageRegionMap : ActiveRecord<PageRegionMap>
	{
		#region .ctors and Default Settings
		
		public PageRegionMap()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public PageRegionMap(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public PageRegionMap(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public PageRegionMap(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Content_Page_Region_Map", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarRegionId = new TableSchema.TableColumn(schema);
				colvarRegionId.ColumnName = "RegionId";
				colvarRegionId.DataType = DbType.Int32;
				colvarRegionId.MaxLength = 0;
				colvarRegionId.AutoIncrement = false;
				colvarRegionId.IsNullable = false;
				colvarRegionId.IsPrimaryKey = true;
				colvarRegionId.IsForeignKey = true;
				colvarRegionId.IsReadOnly = false;
				colvarRegionId.DefaultSetting = @"";
				
					colvarRegionId.ForeignKeyTableName = "dashCommerce_Content_Region";
				schema.Columns.Add(colvarRegionId);
				
				TableSchema.TableColumn colvarPageId = new TableSchema.TableColumn(schema);
				colvarPageId.ColumnName = "PageId";
				colvarPageId.DataType = DbType.Int32;
				colvarPageId.MaxLength = 0;
				colvarPageId.AutoIncrement = false;
				colvarPageId.IsNullable = false;
				colvarPageId.IsPrimaryKey = true;
				colvarPageId.IsForeignKey = true;
				colvarPageId.IsReadOnly = false;
				colvarPageId.DefaultSetting = @"";
				
					colvarPageId.ForeignKeyTableName = "dashCommerce_Content_Page";
				schema.Columns.Add(colvarPageId);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Content_Page_Region_Map",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("RegionId")]
		public int RegionId 
		{
			get { return GetColumnValue<int>("RegionId"); }

			set { SetColumnValue("RegionId", value); }

		}

		  
		[XmlAttribute("PageId")]
		public int PageId 
		{
			get { return GetColumnValue<int>("PageId"); }

			set { SetColumnValue("PageId", value); }

		}

		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Page ActiveRecord object related to this PageRegionMap
		/// 
		/// </summary>
		public MettleSystems.dashCommerce.Content.Page Page
		{
			get { return MettleSystems.dashCommerce.Content.Page.FetchByID(this.PageId); }

			set { SetColumnValue("PageId", value.PageId); }

		}

		
		
		/// <summary>
		/// Returns a Region ActiveRecord object related to this PageRegionMap
		/// 
		/// </summary>
		public MettleSystems.dashCommerce.Content.Region Region
		{
			get { return MettleSystems.dashCommerce.Content.Region.FetchByID(this.RegionId); }

			set { SetColumnValue("RegionId", value.RegionId); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varRegionId,int varPageId)
		{
			PageRegionMap item = new PageRegionMap();
			
			item.RegionId = varRegionId;
			
			item.PageId = varPageId;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varRegionId,int varPageId)
		{
			PageRegionMap item = new PageRegionMap();
			
				item.RegionId = varRegionId;
				
				item.PageId = varPageId;
				
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
			 public static string RegionId = @"RegionId";
			 public static string PageId = @"PageId";
						
		}

		#endregion
	}

}

