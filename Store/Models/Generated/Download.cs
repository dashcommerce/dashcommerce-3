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
	/// Strongly-typed collection for the Download class.
	/// </summary>
	[Serializable]
	public partial class DownloadCollection : ActiveList<Download, DownloadCollection> 
	{	   
		public DownloadCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_Download table.
	/// </summary>
	[Serializable]
	public partial class Download : ActiveRecord<Download>
	{
		#region .ctors and Default Settings
		
		public Download()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Download(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Download(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Download(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_Download", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarDownloadId = new TableSchema.TableColumn(schema);
				colvarDownloadId.ColumnName = "DownloadId";
				colvarDownloadId.DataType = DbType.Int32;
				colvarDownloadId.MaxLength = 0;
				colvarDownloadId.AutoIncrement = true;
				colvarDownloadId.IsNullable = false;
				colvarDownloadId.IsPrimaryKey = true;
				colvarDownloadId.IsForeignKey = false;
				colvarDownloadId.IsReadOnly = false;
				colvarDownloadId.DefaultSetting = @"";
				colvarDownloadId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDownloadId);
				
				TableSchema.TableColumn colvarDownloadFile = new TableSchema.TableColumn(schema);
				colvarDownloadFile.ColumnName = "DownloadFile";
				colvarDownloadFile.DataType = DbType.String;
				colvarDownloadFile.MaxLength = 255;
				colvarDownloadFile.AutoIncrement = false;
				colvarDownloadFile.IsNullable = false;
				colvarDownloadFile.IsPrimaryKey = false;
				colvarDownloadFile.IsForeignKey = false;
				colvarDownloadFile.IsReadOnly = false;
				colvarDownloadFile.DefaultSetting = @"";
				colvarDownloadFile.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDownloadFile);
				
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
				
				TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
				colvarDescription.ColumnName = "Description";
				colvarDescription.DataType = DbType.String;
				colvarDescription.MaxLength = -1;
				colvarDescription.AutoIncrement = false;
				colvarDescription.IsNullable = true;
				colvarDescription.IsPrimaryKey = false;
				colvarDescription.IsForeignKey = false;
				colvarDescription.IsReadOnly = false;
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
				TableSchema.TableColumn colvarForPurchaseOnly = new TableSchema.TableColumn(schema);
				colvarForPurchaseOnly.ColumnName = "ForPurchaseOnly";
				colvarForPurchaseOnly.DataType = DbType.Boolean;
				colvarForPurchaseOnly.MaxLength = 0;
				colvarForPurchaseOnly.AutoIncrement = false;
				colvarForPurchaseOnly.IsNullable = false;
				colvarForPurchaseOnly.IsPrimaryKey = false;
				colvarForPurchaseOnly.IsForeignKey = false;
				colvarForPurchaseOnly.IsReadOnly = false;
				
						colvarForPurchaseOnly.DefaultSetting = @"((1))";
				colvarForPurchaseOnly.ForeignKeyTableName = "";
				schema.Columns.Add(colvarForPurchaseOnly);
				
				TableSchema.TableColumn colvarContentType = new TableSchema.TableColumn(schema);
				colvarContentType.ColumnName = "ContentType";
				colvarContentType.DataType = DbType.String;
				colvarContentType.MaxLength = 50;
				colvarContentType.AutoIncrement = false;
				colvarContentType.IsNullable = true;
				colvarContentType.IsPrimaryKey = false;
				colvarContentType.IsForeignKey = false;
				colvarContentType.IsReadOnly = false;
				colvarContentType.DefaultSetting = @"";
				colvarContentType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarContentType);
				
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
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_Download",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("DownloadId")]
		public int DownloadId 
		{
			get { return GetColumnValue<int>("DownloadId"); }

			set { SetColumnValue("DownloadId", value); }

		}

		  
		[XmlAttribute("DownloadFile")]
		public string DownloadFile 
		{
			get { return GetColumnValue<string>("DownloadFile"); }

			set { SetColumnValue("DownloadFile", value); }

		}

		  
		[XmlAttribute("Title")]
		public string Title 
		{
			get { return GetColumnValue<string>("Title"); }

			set { SetColumnValue("Title", value); }

		}

		  
		[XmlAttribute("Description")]
		public string Description 
		{
			get { return GetColumnValue<string>("Description"); }

			set { SetColumnValue("Description", value); }

		}

		  
		[XmlAttribute("ForPurchaseOnly")]
		public bool ForPurchaseOnly 
		{
			get { return GetColumnValue<bool>("ForPurchaseOnly"); }

			set { SetColumnValue("ForPurchaseOnly", value); }

		}

		  
		[XmlAttribute("ContentType")]
		public string ContentType 
		{
			get { return GetColumnValue<string>("ContentType"); }

			set { SetColumnValue("ContentType", value); }

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
		
		public MettleSystems.dashCommerce.Store.DownloadAccessControlCollection DownloadAccessControlRecords()
		{
			return new MettleSystems.dashCommerce.Store.DownloadAccessControlCollection().Where(DownloadAccessControl.Columns.DownloadId, DownloadId).Load();
		}

		public MettleSystems.dashCommerce.Store.ProductDownloadMapCollection ProductDownloadMapRecords()
		{
			return new MettleSystems.dashCommerce.Store.ProductDownloadMapCollection().Where(ProductDownloadMap.Columns.DownloadId, DownloadId).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public MettleSystems.dashCommerce.Store.ProductCollection GetProductCollection() { return Download.GetProductCollection(this.DownloadId); }

		public static MettleSystems.dashCommerce.Store.ProductCollection GetProductCollection(int varDownloadId)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM dashCommerce_Store_Product INNER JOIN dashCommerce_Store_Product_Download_Map ON "+
				"dashCommerce_Store_Product.ProductId=dashCommerce_Store_Product_Download_Map.ProductId WHERE dashCommerce_Store_Product_Download_Map.DownloadId=@DownloadId", Download.Schema.Provider.Name);
			
			cmd.AddParameter("@DownloadId", varDownloadId, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ProductCollection coll = new ProductCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveProductMap(int varDownloadId, ProductCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Store_Product_Download_Map WHERE DownloadId=@DownloadId", Download.Schema.Provider.Name);
			cmdDel.AddParameter("@DownloadId", varDownloadId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Product item in items)
			{
				ProductDownloadMap varProductDownloadMap = new ProductDownloadMap();
				varProductDownloadMap.SetColumnValue("DownloadId", varDownloadId);
				varProductDownloadMap.SetColumnValue("ProductId", item.GetPrimaryKeyValue());
				varProductDownloadMap.Save();
			}

		}

		public static void SaveProductMap(int varDownloadId, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Store_Product_Download_Map WHERE DownloadId=@DownloadId", Download.Schema.Provider.Name);
			cmdDel.AddParameter("@DownloadId", varDownloadId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductDownloadMap varProductDownloadMap = new ProductDownloadMap();
					varProductDownloadMap.SetColumnValue("DownloadId", varDownloadId);
					varProductDownloadMap.SetColumnValue("ProductId", l.Value);
					varProductDownloadMap.Save();
				}

			}

		}

		public static void SaveProductMap(int varDownloadId , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Store_Product_Download_Map WHERE DownloadId=@DownloadId", Download.Schema.Provider.Name);
			cmdDel.AddParameter("@DownloadId", varDownloadId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				ProductDownloadMap varProductDownloadMap = new ProductDownloadMap();
				varProductDownloadMap.SetColumnValue("DownloadId", varDownloadId);
				varProductDownloadMap.SetColumnValue("ProductId", item);
				varProductDownloadMap.Save();
			}

		}

		
		public static void DeleteProductMap(int varDownloadId) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Store_Product_Download_Map WHERE DownloadId=@DownloadId", Download.Schema.Provider.Name);
			cmdDel.AddParameter("@DownloadId", varDownloadId);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDownloadFile,string varTitle,string varDescription,bool varForPurchaseOnly,string varContentType,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			Download item = new Download();
			
			item.DownloadFile = varDownloadFile;
			
			item.Title = varTitle;
			
			item.Description = varDescription;
			
			item.ForPurchaseOnly = varForPurchaseOnly;
			
			item.ContentType = varContentType;
			
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
		public static void Update(int varDownloadId,string varDownloadFile,string varTitle,string varDescription,bool varForPurchaseOnly,string varContentType,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			Download item = new Download();
			
				item.DownloadId = varDownloadId;
				
				item.DownloadFile = varDownloadFile;
				
				item.Title = varTitle;
				
				item.Description = varDescription;
				
				item.ForPurchaseOnly = varForPurchaseOnly;
				
				item.ContentType = varContentType;
				
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
			 public static string DownloadId = @"DownloadId";
			 public static string DownloadFile = @"DownloadFile";
			 public static string Title = @"Title";
			 public static string Description = @"Description";
			 public static string ForPurchaseOnly = @"ForPurchaseOnly";
			 public static string ContentType = @"ContentType";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}

		#endregion
	}

}

