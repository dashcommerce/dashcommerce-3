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
	/// Strongly-typed collection for the Page class.
	/// </summary>
	[Serializable]
	public partial class PageCollection : ActiveList<Page, PageCollection> 
	{	   
		public PageCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Content_Page table.
	/// </summary>
	[Serializable]
	public partial class Page : ActiveRecord<Page>
	{
		#region .ctors and Default Settings
		
		public Page()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Page(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Page(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Page(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Content_Page", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarPageId = new TableSchema.TableColumn(schema);
				colvarPageId.ColumnName = "PageId";
				colvarPageId.DataType = DbType.Int32;
				colvarPageId.MaxLength = 0;
				colvarPageId.AutoIncrement = true;
				colvarPageId.IsNullable = false;
				colvarPageId.IsPrimaryKey = true;
				colvarPageId.IsForeignKey = false;
				colvarPageId.IsReadOnly = false;
				colvarPageId.DefaultSetting = @"";
				colvarPageId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPageId);
				
				TableSchema.TableColumn colvarPageGuid = new TableSchema.TableColumn(schema);
				colvarPageGuid.ColumnName = "PageGuid";
				colvarPageGuid.DataType = DbType.Guid;
				colvarPageGuid.MaxLength = 0;
				colvarPageGuid.AutoIncrement = false;
				colvarPageGuid.IsNullable = false;
				colvarPageGuid.IsPrimaryKey = false;
				colvarPageGuid.IsForeignKey = false;
				colvarPageGuid.IsReadOnly = false;
				colvarPageGuid.DefaultSetting = @"";
				colvarPageGuid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPageGuid);
				
				TableSchema.TableColumn colvarParentId = new TableSchema.TableColumn(schema);
				colvarParentId.ColumnName = "ParentId";
				colvarParentId.DataType = DbType.Int32;
				colvarParentId.MaxLength = 0;
				colvarParentId.AutoIncrement = false;
				colvarParentId.IsNullable = false;
				colvarParentId.IsPrimaryKey = false;
				colvarParentId.IsForeignKey = false;
				colvarParentId.IsReadOnly = false;
				
						colvarParentId.DefaultSetting = @"((0))";
				colvarParentId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarParentId);
				
				TableSchema.TableColumn colvarTitle = new TableSchema.TableColumn(schema);
				colvarTitle.ColumnName = "Title";
				colvarTitle.DataType = DbType.String;
				colvarTitle.MaxLength = 250;
				colvarTitle.AutoIncrement = false;
				colvarTitle.IsNullable = false;
				colvarTitle.IsPrimaryKey = false;
				colvarTitle.IsForeignKey = false;
				colvarTitle.IsReadOnly = false;
				colvarTitle.DefaultSetting = @"";
				colvarTitle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTitle);
				
				TableSchema.TableColumn colvarMenuTitle = new TableSchema.TableColumn(schema);
				colvarMenuTitle.ColumnName = "MenuTitle";
				colvarMenuTitle.DataType = DbType.String;
				colvarMenuTitle.MaxLength = 50;
				colvarMenuTitle.AutoIncrement = false;
				colvarMenuTitle.IsNullable = false;
				colvarMenuTitle.IsPrimaryKey = false;
				colvarMenuTitle.IsForeignKey = false;
				colvarMenuTitle.IsReadOnly = false;
				colvarMenuTitle.DefaultSetting = @"";
				colvarMenuTitle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMenuTitle);
				
				TableSchema.TableColumn colvarKeywords = new TableSchema.TableColumn(schema);
				colvarKeywords.ColumnName = "Keywords";
				colvarKeywords.DataType = DbType.String;
				colvarKeywords.MaxLength = 500;
				colvarKeywords.AutoIncrement = false;
				colvarKeywords.IsNullable = true;
				colvarKeywords.IsPrimaryKey = false;
				colvarKeywords.IsForeignKey = false;
				colvarKeywords.IsReadOnly = false;
				colvarKeywords.DefaultSetting = @"";
				colvarKeywords.ForeignKeyTableName = "";
				schema.Columns.Add(colvarKeywords);
				
				TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
				colvarDescription.ColumnName = "Description";
				colvarDescription.DataType = DbType.String;
				colvarDescription.MaxLength = 500;
				colvarDescription.AutoIncrement = false;
				colvarDescription.IsNullable = true;
				colvarDescription.IsPrimaryKey = false;
				colvarDescription.IsForeignKey = false;
				colvarDescription.IsReadOnly = false;
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
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
				
				TableSchema.TableColumn colvarTemplateId = new TableSchema.TableColumn(schema);
				colvarTemplateId.ColumnName = "TemplateId";
				colvarTemplateId.DataType = DbType.Int32;
				colvarTemplateId.MaxLength = 0;
				colvarTemplateId.AutoIncrement = false;
				colvarTemplateId.IsNullable = false;
				colvarTemplateId.IsPrimaryKey = false;
				colvarTemplateId.IsForeignKey = false;
				colvarTemplateId.IsReadOnly = false;
				colvarTemplateId.DefaultSetting = @"";
				colvarTemplateId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTemplateId);
				
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
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Content_Page",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("PageId")]
		public int PageId 
		{
			get { return GetColumnValue<int>("PageId"); }

			set { SetColumnValue("PageId", value); }

		}

		  
		[XmlAttribute("PageGuid")]
		public Guid PageGuid 
		{
			get { return GetColumnValue<Guid>("PageGuid"); }

			set { SetColumnValue("PageGuid", value); }

		}

		  
		[XmlAttribute("ParentId")]
		public int ParentId 
		{
			get { return GetColumnValue<int>("ParentId"); }

			set { SetColumnValue("ParentId", value); }

		}

		  
		[XmlAttribute("Title")]
		public string Title 
		{
			get { return GetColumnValue<string>("Title"); }

			set { SetColumnValue("Title", value); }

		}

		  
		[XmlAttribute("MenuTitle")]
		public string MenuTitle 
		{
			get { return GetColumnValue<string>("MenuTitle"); }

			set { SetColumnValue("MenuTitle", value); }

		}

		  
		[XmlAttribute("Keywords")]
		public string Keywords 
		{
			get { return GetColumnValue<string>("Keywords"); }

			set { SetColumnValue("Keywords", value); }

		}

		  
		[XmlAttribute("Description")]
		public string Description 
		{
			get { return GetColumnValue<string>("Description"); }

			set { SetColumnValue("Description", value); }

		}

		  
		[XmlAttribute("SortOrder")]
		public int SortOrder 
		{
			get { return GetColumnValue<int>("SortOrder"); }

			set { SetColumnValue("SortOrder", value); }

		}

		  
		[XmlAttribute("TemplateId")]
		public int TemplateId 
		{
			get { return GetColumnValue<int>("TemplateId"); }

			set { SetColumnValue("TemplateId", value); }

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
			return new MettleSystems.dashCommerce.Content.PageRegionMapCollection().Where(PageRegionMap.Columns.PageId, PageId).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public MettleSystems.dashCommerce.Content.RegionCollection GetRegionCollection() { return Page.GetRegionCollection(this.PageId); }

		public static MettleSystems.dashCommerce.Content.RegionCollection GetRegionCollection(int varPageId)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM dashCommerce_Content_Region INNER JOIN dashCommerce_Content_Page_Region_Map ON "+
				"dashCommerce_Content_Region.RegionId=dashCommerce_Content_Page_Region_Map.RegionId WHERE dashCommerce_Content_Page_Region_Map.PageId=@PageId", Page.Schema.Provider.Name);
			
			cmd.AddParameter("@PageId", varPageId, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			RegionCollection coll = new RegionCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveRegionMap(int varPageId, RegionCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Content_Page_Region_Map WHERE PageId=@PageId", Page.Schema.Provider.Name);
			cmdDel.AddParameter("@PageId", varPageId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Region item in items)
			{
				PageRegionMap varPageRegionMap = new PageRegionMap();
				varPageRegionMap.SetColumnValue("PageId", varPageId);
				varPageRegionMap.SetColumnValue("RegionId", item.GetPrimaryKeyValue());
				varPageRegionMap.Save();
			}

		}

		public static void SaveRegionMap(int varPageId, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Content_Page_Region_Map WHERE PageId=@PageId", Page.Schema.Provider.Name);
			cmdDel.AddParameter("@PageId", varPageId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					PageRegionMap varPageRegionMap = new PageRegionMap();
					varPageRegionMap.SetColumnValue("PageId", varPageId);
					varPageRegionMap.SetColumnValue("RegionId", l.Value);
					varPageRegionMap.Save();
				}

			}

		}

		public static void SaveRegionMap(int varPageId , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Content_Page_Region_Map WHERE PageId=@PageId", Page.Schema.Provider.Name);
			cmdDel.AddParameter("@PageId", varPageId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				PageRegionMap varPageRegionMap = new PageRegionMap();
				varPageRegionMap.SetColumnValue("PageId", varPageId);
				varPageRegionMap.SetColumnValue("RegionId", item);
				varPageRegionMap.Save();
			}

		}

		
		public static void DeleteRegionMap(int varPageId) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Content_Page_Region_Map WHERE PageId=@PageId", Page.Schema.Provider.Name);
			cmdDel.AddParameter("@PageId", varPageId);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(Guid varPageGuid,int varParentId,string varTitle,string varMenuTitle,string varKeywords,string varDescription,int varSortOrder,int varTemplateId,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			Page item = new Page();
			
			item.PageGuid = varPageGuid;
			
			item.ParentId = varParentId;
			
			item.Title = varTitle;
			
			item.MenuTitle = varMenuTitle;
			
			item.Keywords = varKeywords;
			
			item.Description = varDescription;
			
			item.SortOrder = varSortOrder;
			
			item.TemplateId = varTemplateId;
			
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
		public static void Update(int varPageId,Guid varPageGuid,int varParentId,string varTitle,string varMenuTitle,string varKeywords,string varDescription,int varSortOrder,int varTemplateId,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			Page item = new Page();
			
				item.PageId = varPageId;
				
				item.PageGuid = varPageGuid;
				
				item.ParentId = varParentId;
				
				item.Title = varTitle;
				
				item.MenuTitle = varMenuTitle;
				
				item.Keywords = varKeywords;
				
				item.Description = varDescription;
				
				item.SortOrder = varSortOrder;
				
				item.TemplateId = varTemplateId;
				
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
			 public static string PageId = @"PageId";
			 public static string PageGuid = @"PageGuid";
			 public static string ParentId = @"ParentId";
			 public static string Title = @"Title";
			 public static string MenuTitle = @"MenuTitle";
			 public static string Keywords = @"Keywords";
			 public static string Description = @"Description";
			 public static string SortOrder = @"SortOrder";
			 public static string TemplateId = @"TemplateId";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}

		#endregion
	}

}

