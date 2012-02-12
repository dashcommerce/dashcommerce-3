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
	/// Strongly-typed collection for the Region class.
	/// </summary>
	[Serializable]
	public partial class RegionCollection : ActiveList<Region, RegionCollection> 
	{	   
		public RegionCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Content_Region table.
	/// </summary>
	[Serializable]
	public partial class Region : ActiveRecord<Region>
	{
		#region .ctors and Default Settings
		
		public Region()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Region(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Region(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Region(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Content_Region", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarRegionId = new TableSchema.TableColumn(schema);
				colvarRegionId.ColumnName = "RegionId";
				colvarRegionId.DataType = DbType.Int32;
				colvarRegionId.MaxLength = 0;
				colvarRegionId.AutoIncrement = true;
				colvarRegionId.IsNullable = false;
				colvarRegionId.IsPrimaryKey = true;
				colvarRegionId.IsForeignKey = false;
				colvarRegionId.IsReadOnly = false;
				colvarRegionId.DefaultSetting = @"";
				colvarRegionId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRegionId);
				
				TableSchema.TableColumn colvarRegionGuid = new TableSchema.TableColumn(schema);
				colvarRegionGuid.ColumnName = "RegionGuid";
				colvarRegionGuid.DataType = DbType.Guid;
				colvarRegionGuid.MaxLength = 0;
				colvarRegionGuid.AutoIncrement = false;
				colvarRegionGuid.IsNullable = false;
				colvarRegionGuid.IsPrimaryKey = false;
				colvarRegionGuid.IsForeignKey = false;
				colvarRegionGuid.IsReadOnly = false;
				colvarRegionGuid.DefaultSetting = @"";
				colvarRegionGuid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRegionGuid);
				
				TableSchema.TableColumn colvarProviderId = new TableSchema.TableColumn(schema);
				colvarProviderId.ColumnName = "ProviderId";
				colvarProviderId.DataType = DbType.Int32;
				colvarProviderId.MaxLength = 0;
				colvarProviderId.AutoIncrement = false;
				colvarProviderId.IsNullable = false;
				colvarProviderId.IsPrimaryKey = false;
				colvarProviderId.IsForeignKey = false;
				colvarProviderId.IsReadOnly = false;
				colvarProviderId.DefaultSetting = @"";
				colvarProviderId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProviderId);
				
				TableSchema.TableColumn colvarTitle = new TableSchema.TableColumn(schema);
				colvarTitle.ColumnName = "Title";
				colvarTitle.DataType = DbType.String;
				colvarTitle.MaxLength = 50;
				colvarTitle.AutoIncrement = false;
				colvarTitle.IsNullable = false;
				colvarTitle.IsPrimaryKey = false;
				colvarTitle.IsForeignKey = false;
				colvarTitle.IsReadOnly = false;
				colvarTitle.DefaultSetting = @"";
				colvarTitle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTitle);
				
				TableSchema.TableColumn colvarTemplateRegionId = new TableSchema.TableColumn(schema);
				colvarTemplateRegionId.ColumnName = "TemplateRegionId";
				colvarTemplateRegionId.DataType = DbType.Int32;
				colvarTemplateRegionId.MaxLength = 0;
				colvarTemplateRegionId.AutoIncrement = false;
				colvarTemplateRegionId.IsNullable = false;
				colvarTemplateRegionId.IsPrimaryKey = false;
				colvarTemplateRegionId.IsForeignKey = true;
				colvarTemplateRegionId.IsReadOnly = false;
				colvarTemplateRegionId.DefaultSetting = @"";
				
					colvarTemplateRegionId.ForeignKeyTableName = "dashCommerce_Content_TemplateRegion";
				schema.Columns.Add(colvarTemplateRegionId);
				
				TableSchema.TableColumn colvarSortOrder = new TableSchema.TableColumn(schema);
				colvarSortOrder.ColumnName = "SortOrder";
				colvarSortOrder.DataType = DbType.Int32;
				colvarSortOrder.MaxLength = 0;
				colvarSortOrder.AutoIncrement = false;
				colvarSortOrder.IsNullable = false;
				colvarSortOrder.IsPrimaryKey = false;
				colvarSortOrder.IsForeignKey = false;
				colvarSortOrder.IsReadOnly = false;
				colvarSortOrder.DefaultSetting = @"";
				colvarSortOrder.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSortOrder);
				
				TableSchema.TableColumn colvarShowTitle = new TableSchema.TableColumn(schema);
				colvarShowTitle.ColumnName = "ShowTitle";
				colvarShowTitle.DataType = DbType.Boolean;
				colvarShowTitle.MaxLength = 0;
				colvarShowTitle.AutoIncrement = false;
				colvarShowTitle.IsNullable = false;
				colvarShowTitle.IsPrimaryKey = false;
				colvarShowTitle.IsForeignKey = false;
				colvarShowTitle.IsReadOnly = false;
				colvarShowTitle.DefaultSetting = @"";
				colvarShowTitle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarShowTitle);
				
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
				
						colvarModifiedOn.DefaultSetting = @"(getutcdate())";
				colvarModifiedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedOn);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Content_Region",schema);
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

		  
		[XmlAttribute("RegionGuid")]
		public Guid RegionGuid 
		{
			get { return GetColumnValue<Guid>("RegionGuid"); }

			set { SetColumnValue("RegionGuid", value); }

		}

		  
		[XmlAttribute("ProviderId")]
		public int ProviderId 
		{
			get { return GetColumnValue<int>("ProviderId"); }

			set { SetColumnValue("ProviderId", value); }

		}

		  
		[XmlAttribute("Title")]
		public string Title 
		{
			get { return GetColumnValue<string>("Title"); }

			set { SetColumnValue("Title", value); }

		}

		  
		[XmlAttribute("TemplateRegionId")]
		public int TemplateRegionId 
		{
			get { return GetColumnValue<int>("TemplateRegionId"); }

			set { SetColumnValue("TemplateRegionId", value); }

		}

		  
		[XmlAttribute("SortOrder")]
		public int SortOrder 
		{
			get { return GetColumnValue<int>("SortOrder"); }

			set { SetColumnValue("SortOrder", value); }

		}

		  
		[XmlAttribute("ShowTitle")]
		public bool ShowTitle 
		{
			get { return GetColumnValue<bool>("ShowTitle"); }

			set { SetColumnValue("ShowTitle", value); }

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
		
		public MettleSystems.dashCommerce.Content.PageRegionMapCollection PageRegionMapRecords()
		{
			return new MettleSystems.dashCommerce.Content.PageRegionMapCollection().Where(PageRegionMap.Columns.RegionId, RegionId).Load();
		}

		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a TemplateRegion ActiveRecord object related to this Region
		/// 
		/// </summary>
		public MettleSystems.dashCommerce.Content.TemplateRegion TemplateRegion
		{
			get { return MettleSystems.dashCommerce.Content.TemplateRegion.FetchByID(this.TemplateRegionId); }

			set { SetColumnValue("TemplateRegionId", value.TemplateRegionId); }

		}

		
		
		#endregion
		
		
		
		#region Many To Many Helpers
		
		 
		public MettleSystems.dashCommerce.Content.PageCollection GetPageCollection() { return Region.GetPageCollection(this.RegionId); }

		public static MettleSystems.dashCommerce.Content.PageCollection GetPageCollection(int varRegionId)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM dashCommerce_Content_Page INNER JOIN dashCommerce_Content_Page_Region_Map ON "+
				"dashCommerce_Content_Page.PageId=dashCommerce_Content_Page_Region_Map.PageId WHERE dashCommerce_Content_Page_Region_Map.RegionId=@RegionId", Region.Schema.Provider.Name);
			
			cmd.AddParameter("@RegionId", varRegionId, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			PageCollection coll = new PageCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SavePageMap(int varRegionId, PageCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Content_Page_Region_Map WHERE RegionId=@RegionId", Region.Schema.Provider.Name);
			cmdDel.AddParameter("@RegionId", varRegionId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Page item in items)
			{
				PageRegionMap varPageRegionMap = new PageRegionMap();
				varPageRegionMap.SetColumnValue("RegionId", varRegionId);
				varPageRegionMap.SetColumnValue("PageId", item.GetPrimaryKeyValue());
				varPageRegionMap.Save();
			}

		}

		public static void SavePageMap(int varRegionId, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Content_Page_Region_Map WHERE RegionId=@RegionId", Region.Schema.Provider.Name);
			cmdDel.AddParameter("@RegionId", varRegionId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					PageRegionMap varPageRegionMap = new PageRegionMap();
					varPageRegionMap.SetColumnValue("RegionId", varRegionId);
					varPageRegionMap.SetColumnValue("PageId", l.Value);
					varPageRegionMap.Save();
				}

			}

		}

		public static void SavePageMap(int varRegionId , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Content_Page_Region_Map WHERE RegionId=@RegionId", Region.Schema.Provider.Name);
			cmdDel.AddParameter("@RegionId", varRegionId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				PageRegionMap varPageRegionMap = new PageRegionMap();
				varPageRegionMap.SetColumnValue("RegionId", varRegionId);
				varPageRegionMap.SetColumnValue("PageId", item);
				varPageRegionMap.Save();
			}

		}

		
		public static void DeletePageMap(int varRegionId) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Content_Page_Region_Map WHERE RegionId=@RegionId", Region.Schema.Provider.Name);
			cmdDel.AddParameter("@RegionId", varRegionId);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(Guid varRegionGuid,int varProviderId,string varTitle,int varTemplateRegionId,int varSortOrder,bool varShowTitle,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			Region item = new Region();
			
			item.RegionGuid = varRegionGuid;
			
			item.ProviderId = varProviderId;
			
			item.Title = varTitle;
			
			item.TemplateRegionId = varTemplateRegionId;
			
			item.SortOrder = varSortOrder;
			
			item.ShowTitle = varShowTitle;
			
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
		public static void Update(int varRegionId,Guid varRegionGuid,int varProviderId,string varTitle,int varTemplateRegionId,int varSortOrder,bool varShowTitle,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			Region item = new Region();
			
				item.RegionId = varRegionId;
				
				item.RegionGuid = varRegionGuid;
				
				item.ProviderId = varProviderId;
				
				item.Title = varTitle;
				
				item.TemplateRegionId = varTemplateRegionId;
				
				item.SortOrder = varSortOrder;
				
				item.ShowTitle = varShowTitle;
				
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
			 public static string RegionId = @"RegionId";
			 public static string RegionGuid = @"RegionGuid";
			 public static string ProviderId = @"ProviderId";
			 public static string Title = @"Title";
			 public static string TemplateRegionId = @"TemplateRegionId";
			 public static string SortOrder = @"SortOrder";
			 public static string ShowTitle = @"ShowTitle";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}

		#endregion
	}

}

