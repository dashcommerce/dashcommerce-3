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
	/// Strongly-typed collection for the SimpleHtml class.
	/// </summary>
	[Serializable]
	public partial class SimpleHtmlCollection : ActiveList<SimpleHtml, SimpleHtmlCollection> 
	{	   
		public SimpleHtmlCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Content_SimpleHtml table.
	/// </summary>
	[Serializable]
	public partial class SimpleHtml : ActiveRecord<SimpleHtml>
	{
		#region .ctors and Default Settings
		
		public SimpleHtml()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public SimpleHtml(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public SimpleHtml(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public SimpleHtml(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Content_SimpleHtml", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarSimpleHtmlId = new TableSchema.TableColumn(schema);
				colvarSimpleHtmlId.ColumnName = "SimpleHtmlId";
				colvarSimpleHtmlId.DataType = DbType.Int32;
				colvarSimpleHtmlId.MaxLength = 0;
				colvarSimpleHtmlId.AutoIncrement = true;
				colvarSimpleHtmlId.IsNullable = false;
				colvarSimpleHtmlId.IsPrimaryKey = true;
				colvarSimpleHtmlId.IsForeignKey = false;
				colvarSimpleHtmlId.IsReadOnly = false;
				colvarSimpleHtmlId.DefaultSetting = @"";
				colvarSimpleHtmlId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSimpleHtmlId);
				
				TableSchema.TableColumn colvarRegionId = new TableSchema.TableColumn(schema);
				colvarRegionId.ColumnName = "RegionId";
				colvarRegionId.DataType = DbType.Int32;
				colvarRegionId.MaxLength = 0;
				colvarRegionId.AutoIncrement = false;
				colvarRegionId.IsNullable = false;
				colvarRegionId.IsPrimaryKey = false;
				colvarRegionId.IsForeignKey = false;
				colvarRegionId.IsReadOnly = false;
				colvarRegionId.DefaultSetting = @"";
				colvarRegionId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRegionId);
				
				TableSchema.TableColumn colvarHtml = new TableSchema.TableColumn(schema);
				colvarHtml.ColumnName = "Html";
				colvarHtml.DataType = DbType.String;
				colvarHtml.MaxLength = -1;
				colvarHtml.AutoIncrement = false;
				colvarHtml.IsNullable = false;
				colvarHtml.IsPrimaryKey = false;
				colvarHtml.IsForeignKey = false;
				colvarHtml.IsReadOnly = false;
				colvarHtml.DefaultSetting = @"";
				colvarHtml.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHtml);
				
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
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Content_SimpleHtml",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("SimpleHtmlId")]
		public int SimpleHtmlId 
		{
			get { return GetColumnValue<int>("SimpleHtmlId"); }

			set { SetColumnValue("SimpleHtmlId", value); }

		}

		  
		[XmlAttribute("RegionId")]
		public int RegionId 
		{
			get { return GetColumnValue<int>("RegionId"); }

			set { SetColumnValue("RegionId", value); }

		}

		  
		[XmlAttribute("Html")]
		public string Html 
		{
			get { return GetColumnValue<string>("Html"); }

			set { SetColumnValue("Html", value); }

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
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varRegionId,string varHtml,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			SimpleHtml item = new SimpleHtml();
			
			item.RegionId = varRegionId;
			
			item.Html = varHtml;
			
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
		public static void Update(int varSimpleHtmlId,int varRegionId,string varHtml,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			SimpleHtml item = new SimpleHtml();
			
				item.SimpleHtmlId = varSimpleHtmlId;
				
				item.RegionId = varRegionId;
				
				item.Html = varHtml;
				
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
			 public static string SimpleHtmlId = @"SimpleHtmlId";
			 public static string RegionId = @"RegionId";
			 public static string Html = @"Html";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}

		#endregion
	}

}

