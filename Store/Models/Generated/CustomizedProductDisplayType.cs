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
	/// Strongly-typed collection for the CustomizedProductDisplayType class.
	/// </summary>
	[Serializable]
	public partial class CustomizedProductDisplayTypeCollection : ActiveList<CustomizedProductDisplayType, CustomizedProductDisplayTypeCollection> 
	{	   
		public CustomizedProductDisplayTypeCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_CustomizedProductDisplayType table.
	/// </summary>
	[Serializable]
	public partial class CustomizedProductDisplayType : ActiveRecord<CustomizedProductDisplayType>
	{
		#region .ctors and Default Settings
		
		public CustomizedProductDisplayType()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public CustomizedProductDisplayType(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public CustomizedProductDisplayType(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public CustomizedProductDisplayType(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_CustomizedProductDisplayType", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarCustomizedProductDisplayTypeId = new TableSchema.TableColumn(schema);
				colvarCustomizedProductDisplayTypeId.ColumnName = "CustomizedProductDisplayTypeId";
				colvarCustomizedProductDisplayTypeId.DataType = DbType.Int32;
				colvarCustomizedProductDisplayTypeId.MaxLength = 0;
				colvarCustomizedProductDisplayTypeId.AutoIncrement = true;
				colvarCustomizedProductDisplayTypeId.IsNullable = false;
				colvarCustomizedProductDisplayTypeId.IsPrimaryKey = true;
				colvarCustomizedProductDisplayTypeId.IsForeignKey = false;
				colvarCustomizedProductDisplayTypeId.IsReadOnly = false;
				colvarCustomizedProductDisplayTypeId.DefaultSetting = @"";
				colvarCustomizedProductDisplayTypeId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCustomizedProductDisplayTypeId);
				
				TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
				colvarName.ColumnName = "Name";
				colvarName.DataType = DbType.String;
				colvarName.MaxLength = 50;
				colvarName.AutoIncrement = false;
				colvarName.IsNullable = false;
				colvarName.IsPrimaryKey = false;
				colvarName.IsForeignKey = false;
				colvarName.IsReadOnly = false;
				colvarName.DefaultSetting = @"";
				colvarName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarName);
				
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
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_CustomizedProductDisplayType",schema);
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

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>("Name"); }

			set { SetColumnValue("Name", value); }

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
		
		public MettleSystems.dashCommerce.Store.CustomizedProductDisplayTypeProductMapCollection CustomizedProductDisplayTypeProductMapRecords()
		{
			return new MettleSystems.dashCommerce.Store.CustomizedProductDisplayTypeProductMapCollection().Where(CustomizedProductDisplayTypeProductMap.Columns.CustomizedProductDisplayTypeId, CustomizedProductDisplayTypeId).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public MettleSystems.dashCommerce.Store.ProductCollection GetProductCollection() { return CustomizedProductDisplayType.GetProductCollection(this.CustomizedProductDisplayTypeId); }

		public static MettleSystems.dashCommerce.Store.ProductCollection GetProductCollection(int varCustomizedProductDisplayTypeId)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM dashCommerce_Store_Product INNER JOIN dashCommerce_Store_CustomizedProductDisplayType_Product_Map ON "+
				"dashCommerce_Store_Product.ProductId=dashCommerce_Store_CustomizedProductDisplayType_Product_Map.ProductId WHERE dashCommerce_Store_CustomizedProductDisplayType_Product_Map.CustomizedProductDisplayTypeId=@CustomizedProductDisplayTypeId", CustomizedProductDisplayType.Schema.Provider.Name);
			
			cmd.AddParameter("@CustomizedProductDisplayTypeId", varCustomizedProductDisplayTypeId, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ProductCollection coll = new ProductCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveProductMap(int varCustomizedProductDisplayTypeId, ProductCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Store_CustomizedProductDisplayType_Product_Map WHERE CustomizedProductDisplayTypeId=@CustomizedProductDisplayTypeId", CustomizedProductDisplayType.Schema.Provider.Name);
			cmdDel.AddParameter("@CustomizedProductDisplayTypeId", varCustomizedProductDisplayTypeId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Product item in items)
			{
				CustomizedProductDisplayTypeProductMap varCustomizedProductDisplayTypeProductMap = new CustomizedProductDisplayTypeProductMap();
				varCustomizedProductDisplayTypeProductMap.SetColumnValue("CustomizedProductDisplayTypeId", varCustomizedProductDisplayTypeId);
				varCustomizedProductDisplayTypeProductMap.SetColumnValue("ProductId", item.GetPrimaryKeyValue());
				varCustomizedProductDisplayTypeProductMap.Save();
			}

		}

		public static void SaveProductMap(int varCustomizedProductDisplayTypeId, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Store_CustomizedProductDisplayType_Product_Map WHERE CustomizedProductDisplayTypeId=@CustomizedProductDisplayTypeId", CustomizedProductDisplayType.Schema.Provider.Name);
			cmdDel.AddParameter("@CustomizedProductDisplayTypeId", varCustomizedProductDisplayTypeId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					CustomizedProductDisplayTypeProductMap varCustomizedProductDisplayTypeProductMap = new CustomizedProductDisplayTypeProductMap();
					varCustomizedProductDisplayTypeProductMap.SetColumnValue("CustomizedProductDisplayTypeId", varCustomizedProductDisplayTypeId);
					varCustomizedProductDisplayTypeProductMap.SetColumnValue("ProductId", l.Value);
					varCustomizedProductDisplayTypeProductMap.Save();
				}

			}

		}

		public static void SaveProductMap(int varCustomizedProductDisplayTypeId , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Store_CustomizedProductDisplayType_Product_Map WHERE CustomizedProductDisplayTypeId=@CustomizedProductDisplayTypeId", CustomizedProductDisplayType.Schema.Provider.Name);
			cmdDel.AddParameter("@CustomizedProductDisplayTypeId", varCustomizedProductDisplayTypeId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				CustomizedProductDisplayTypeProductMap varCustomizedProductDisplayTypeProductMap = new CustomizedProductDisplayTypeProductMap();
				varCustomizedProductDisplayTypeProductMap.SetColumnValue("CustomizedProductDisplayTypeId", varCustomizedProductDisplayTypeId);
				varCustomizedProductDisplayTypeProductMap.SetColumnValue("ProductId", item);
				varCustomizedProductDisplayTypeProductMap.Save();
			}

		}

		
		public static void DeleteProductMap(int varCustomizedProductDisplayTypeId) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Store_CustomizedProductDisplayType_Product_Map WHERE CustomizedProductDisplayTypeId=@CustomizedProductDisplayTypeId", CustomizedProductDisplayType.Schema.Provider.Name);
			cmdDel.AddParameter("@CustomizedProductDisplayTypeId", varCustomizedProductDisplayTypeId);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			CustomizedProductDisplayType item = new CustomizedProductDisplayType();
			
			item.Name = varName;
			
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
		public static void Update(int varCustomizedProductDisplayTypeId,string varName,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			CustomizedProductDisplayType item = new CustomizedProductDisplayType();
			
				item.CustomizedProductDisplayTypeId = varCustomizedProductDisplayTypeId;
				
				item.Name = varName;
				
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
			 public static string CustomizedProductDisplayTypeId = @"CustomizedProductDisplayTypeId";
			 public static string Name = @"Name";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}

		#endregion
	}

}

