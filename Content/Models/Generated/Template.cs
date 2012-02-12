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
	/// Strongly-typed collection for the Template class.
	/// </summary>
	[Serializable]
	public partial class TemplateCollection : ActiveList<Template, TemplateCollection> 
	{	   
		public TemplateCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Content_Template table.
	/// </summary>
	[Serializable]
	public partial class Template : ActiveRecord<Template>
	{
		#region .ctors and Default Settings
		
		public Template()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Template(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Template(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Template(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Content_Template", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarTemplateId = new TableSchema.TableColumn(schema);
				colvarTemplateId.ColumnName = "TemplateId";
				colvarTemplateId.DataType = DbType.Int32;
				colvarTemplateId.MaxLength = 0;
				colvarTemplateId.AutoIncrement = true;
				colvarTemplateId.IsNullable = false;
				colvarTemplateId.IsPrimaryKey = true;
				colvarTemplateId.IsForeignKey = false;
				colvarTemplateId.IsReadOnly = false;
				colvarTemplateId.DefaultSetting = @"";
				colvarTemplateId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTemplateId);
				
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
				
				TableSchema.TableColumn colvarStyleSheet = new TableSchema.TableColumn(schema);
				colvarStyleSheet.ColumnName = "StyleSheet";
				colvarStyleSheet.DataType = DbType.String;
				colvarStyleSheet.MaxLength = 250;
				colvarStyleSheet.AutoIncrement = false;
				colvarStyleSheet.IsNullable = true;
				colvarStyleSheet.IsPrimaryKey = false;
				colvarStyleSheet.IsForeignKey = false;
				colvarStyleSheet.IsReadOnly = false;
				colvarStyleSheet.DefaultSetting = @"";
				colvarStyleSheet.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStyleSheet);
				
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
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Content_Template",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("TemplateId")]
		public int TemplateId 
		{
			get { return GetColumnValue<int>("TemplateId"); }

			set { SetColumnValue("TemplateId", value); }

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

		  
		[XmlAttribute("StyleSheet")]
		public string StyleSheet 
		{
			get { return GetColumnValue<string>("StyleSheet"); }

			set { SetColumnValue("StyleSheet", value); }

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
		
		public MettleSystems.dashCommerce.Content.TemplateTemplateRegionMapCollection TemplateTemplateRegionMapRecords()
		{
			return new MettleSystems.dashCommerce.Content.TemplateTemplateRegionMapCollection().Where(TemplateTemplateRegionMap.Columns.TemplateId, TemplateId).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public MettleSystems.dashCommerce.Content.TemplateRegionCollection GetTemplateRegionCollection() { return Template.GetTemplateRegionCollection(this.TemplateId); }

		public static MettleSystems.dashCommerce.Content.TemplateRegionCollection GetTemplateRegionCollection(int varTemplateId)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM dashCommerce_Content_TemplateRegion INNER JOIN dashCommerce_Content_Template_TemplateRegion_Map ON "+
				"dashCommerce_Content_TemplateRegion.TemplateRegionId=dashCommerce_Content_Template_TemplateRegion_Map.TemplateRegionId WHERE dashCommerce_Content_Template_TemplateRegion_Map.TemplateId=@TemplateId", Template.Schema.Provider.Name);
			
			cmd.AddParameter("@TemplateId", varTemplateId, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			TemplateRegionCollection coll = new TemplateRegionCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveTemplateRegionMap(int varTemplateId, TemplateRegionCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Content_Template_TemplateRegion_Map WHERE TemplateId=@TemplateId", Template.Schema.Provider.Name);
			cmdDel.AddParameter("@TemplateId", varTemplateId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (TemplateRegion item in items)
			{
				TemplateTemplateRegionMap varTemplateTemplateRegionMap = new TemplateTemplateRegionMap();
				varTemplateTemplateRegionMap.SetColumnValue("TemplateId", varTemplateId);
				varTemplateTemplateRegionMap.SetColumnValue("TemplateRegionId", item.GetPrimaryKeyValue());
				varTemplateTemplateRegionMap.Save();
			}

		}

		public static void SaveTemplateRegionMap(int varTemplateId, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Content_Template_TemplateRegion_Map WHERE TemplateId=@TemplateId", Template.Schema.Provider.Name);
			cmdDel.AddParameter("@TemplateId", varTemplateId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					TemplateTemplateRegionMap varTemplateTemplateRegionMap = new TemplateTemplateRegionMap();
					varTemplateTemplateRegionMap.SetColumnValue("TemplateId", varTemplateId);
					varTemplateTemplateRegionMap.SetColumnValue("TemplateRegionId", l.Value);
					varTemplateTemplateRegionMap.Save();
				}

			}

		}

		public static void SaveTemplateRegionMap(int varTemplateId , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Content_Template_TemplateRegion_Map WHERE TemplateId=@TemplateId", Template.Schema.Provider.Name);
			cmdDel.AddParameter("@TemplateId", varTemplateId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				TemplateTemplateRegionMap varTemplateTemplateRegionMap = new TemplateTemplateRegionMap();
				varTemplateTemplateRegionMap.SetColumnValue("TemplateId", varTemplateId);
				varTemplateTemplateRegionMap.SetColumnValue("TemplateRegionId", item);
				varTemplateTemplateRegionMap.Save();
			}

		}

		
		public static void DeleteTemplateRegionMap(int varTemplateId) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Content_Template_TemplateRegion_Map WHERE TemplateId=@TemplateId", Template.Schema.Provider.Name);
			cmdDel.AddParameter("@TemplateId", varTemplateId);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,string varDescription,string varStyleSheet,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			Template item = new Template();
			
			item.Name = varName;
			
			item.Description = varDescription;
			
			item.StyleSheet = varStyleSheet;
			
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
		public static void Update(int varTemplateId,string varName,string varDescription,string varStyleSheet,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			Template item = new Template();
			
				item.TemplateId = varTemplateId;
				
				item.Name = varName;
				
				item.Description = varDescription;
				
				item.StyleSheet = varStyleSheet;
				
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
			 public static string TemplateId = @"TemplateId";
			 public static string Name = @"Name";
			 public static string Description = @"Description";
			 public static string StyleSheet = @"StyleSheet";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}

		#endregion
	}

}

