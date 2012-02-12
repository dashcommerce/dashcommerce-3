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
	/// Strongly-typed collection for the TemplateRegion class.
	/// </summary>
	[Serializable]
	public partial class TemplateRegionCollection : ActiveList<TemplateRegion, TemplateRegionCollection> 
	{	   
		public TemplateRegionCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Content_TemplateRegion table.
	/// </summary>
	[Serializable]
	public partial class TemplateRegion : ActiveRecord<TemplateRegion>
	{
		#region .ctors and Default Settings
		
		public TemplateRegion()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public TemplateRegion(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public TemplateRegion(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public TemplateRegion(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Content_TemplateRegion", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarTemplateRegionId = new TableSchema.TableColumn(schema);
				colvarTemplateRegionId.ColumnName = "TemplateRegionId";
				colvarTemplateRegionId.DataType = DbType.Int32;
				colvarTemplateRegionId.MaxLength = 0;
				colvarTemplateRegionId.AutoIncrement = true;
				colvarTemplateRegionId.IsNullable = false;
				colvarTemplateRegionId.IsPrimaryKey = true;
				colvarTemplateRegionId.IsForeignKey = false;
				colvarTemplateRegionId.IsReadOnly = false;
				colvarTemplateRegionId.DefaultSetting = @"";
				colvarTemplateRegionId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTemplateRegionId);
				
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
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Content_TemplateRegion",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("TemplateRegionId")]
		public int TemplateRegionId 
		{
			get { return GetColumnValue<int>("TemplateRegionId"); }

			set { SetColumnValue("TemplateRegionId", value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>("Name"); }

			set { SetColumnValue("Name", value); }

		}

		  
		[XmlAttribute("Description")]
		public string Description 
		{
			get { return GetColumnValue<string>("Description"); }

			set { SetColumnValue("Description", value); }

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
		
		public MettleSystems.dashCommerce.Content.RegionCollection RegionRecords()
		{
			return new MettleSystems.dashCommerce.Content.RegionCollection().Where(Region.Columns.TemplateRegionId, TemplateRegionId).Load();
		}

		public MettleSystems.dashCommerce.Content.TemplateTemplateRegionMapCollection TemplateTemplateRegionMapRecords()
		{
			return new MettleSystems.dashCommerce.Content.TemplateTemplateRegionMapCollection().Where(TemplateTemplateRegionMap.Columns.TemplateRegionId, TemplateRegionId).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public MettleSystems.dashCommerce.Content.TemplateCollection GetTemplateCollection() { return TemplateRegion.GetTemplateCollection(this.TemplateRegionId); }

		public static MettleSystems.dashCommerce.Content.TemplateCollection GetTemplateCollection(int varTemplateRegionId)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM dashCommerce_Content_Template INNER JOIN dashCommerce_Content_Template_TemplateRegion_Map ON "+
				"dashCommerce_Content_Template.TemplateId=dashCommerce_Content_Template_TemplateRegion_Map.TemplateId WHERE dashCommerce_Content_Template_TemplateRegion_Map.TemplateRegionId=@TemplateRegionId", TemplateRegion.Schema.Provider.Name);
			
			cmd.AddParameter("@TemplateRegionId", varTemplateRegionId, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			TemplateCollection coll = new TemplateCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveTemplateMap(int varTemplateRegionId, TemplateCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Content_Template_TemplateRegion_Map WHERE TemplateRegionId=@TemplateRegionId", TemplateRegion.Schema.Provider.Name);
			cmdDel.AddParameter("@TemplateRegionId", varTemplateRegionId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Template item in items)
			{
				TemplateTemplateRegionMap varTemplateTemplateRegionMap = new TemplateTemplateRegionMap();
				varTemplateTemplateRegionMap.SetColumnValue("TemplateRegionId", varTemplateRegionId);
				varTemplateTemplateRegionMap.SetColumnValue("TemplateId", item.GetPrimaryKeyValue());
				varTemplateTemplateRegionMap.Save();
			}

		}

		public static void SaveTemplateMap(int varTemplateRegionId, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Content_Template_TemplateRegion_Map WHERE TemplateRegionId=@TemplateRegionId", TemplateRegion.Schema.Provider.Name);
			cmdDel.AddParameter("@TemplateRegionId", varTemplateRegionId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					TemplateTemplateRegionMap varTemplateTemplateRegionMap = new TemplateTemplateRegionMap();
					varTemplateTemplateRegionMap.SetColumnValue("TemplateRegionId", varTemplateRegionId);
					varTemplateTemplateRegionMap.SetColumnValue("TemplateId", l.Value);
					varTemplateTemplateRegionMap.Save();
				}

			}

		}

		public static void SaveTemplateMap(int varTemplateRegionId , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Content_Template_TemplateRegion_Map WHERE TemplateRegionId=@TemplateRegionId", TemplateRegion.Schema.Provider.Name);
			cmdDel.AddParameter("@TemplateRegionId", varTemplateRegionId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				TemplateTemplateRegionMap varTemplateTemplateRegionMap = new TemplateTemplateRegionMap();
				varTemplateTemplateRegionMap.SetColumnValue("TemplateRegionId", varTemplateRegionId);
				varTemplateTemplateRegionMap.SetColumnValue("TemplateId", item);
				varTemplateTemplateRegionMap.Save();
			}

		}

		
		public static void DeleteTemplateMap(int varTemplateRegionId) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Content_Template_TemplateRegion_Map WHERE TemplateRegionId=@TemplateRegionId", TemplateRegion.Schema.Provider.Name);
			cmdDel.AddParameter("@TemplateRegionId", varTemplateRegionId);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,string varDescription,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			TemplateRegion item = new TemplateRegion();
			
			item.Name = varName;
			
			item.Description = varDescription;
			
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
		public static void Update(int varTemplateRegionId,string varName,string varDescription,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			TemplateRegion item = new TemplateRegion();
			
				item.TemplateRegionId = varTemplateRegionId;
				
				item.Name = varName;
				
				item.Description = varDescription;
				
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
			 public static string TemplateRegionId = @"TemplateRegionId";
			 public static string Name = @"Name";
			 public static string Description = @"Description";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}

		#endregion
	}

}

