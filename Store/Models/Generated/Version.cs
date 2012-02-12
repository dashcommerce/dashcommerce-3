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
	/// Strongly-typed collection for the Version class.
	/// </summary>
	[Serializable]
	public partial class VersionCollection : ActiveList<Version, VersionCollection> 
	{	   
		public VersionCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_Version table.
	/// </summary>
	[Serializable]
	public partial class Version : ActiveRecord<Version>
	{
		#region .ctors and Default Settings
		
		public Version()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Version(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Version(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Version(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_Version", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarVersionId = new TableSchema.TableColumn(schema);
				colvarVersionId.ColumnName = "VersionId";
				colvarVersionId.DataType = DbType.Int32;
				colvarVersionId.MaxLength = 0;
				colvarVersionId.AutoIncrement = true;
				colvarVersionId.IsNullable = false;
				colvarVersionId.IsPrimaryKey = true;
				colvarVersionId.IsForeignKey = false;
				colvarVersionId.IsReadOnly = false;
				colvarVersionId.DefaultSetting = @"";
				colvarVersionId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVersionId);
				
				TableSchema.TableColumn colvarMajor = new TableSchema.TableColumn(schema);
				colvarMajor.ColumnName = "Major";
				colvarMajor.DataType = DbType.Int32;
				colvarMajor.MaxLength = 0;
				colvarMajor.AutoIncrement = false;
				colvarMajor.IsNullable = false;
				colvarMajor.IsPrimaryKey = false;
				colvarMajor.IsForeignKey = false;
				colvarMajor.IsReadOnly = false;
				colvarMajor.DefaultSetting = @"";
				colvarMajor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMajor);
				
				TableSchema.TableColumn colvarMinor = new TableSchema.TableColumn(schema);
				colvarMinor.ColumnName = "Minor";
				colvarMinor.DataType = DbType.Int32;
				colvarMinor.MaxLength = 0;
				colvarMinor.AutoIncrement = false;
				colvarMinor.IsNullable = false;
				colvarMinor.IsPrimaryKey = false;
				colvarMinor.IsForeignKey = false;
				colvarMinor.IsReadOnly = false;
				colvarMinor.DefaultSetting = @"";
				colvarMinor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMinor);
				
				TableSchema.TableColumn colvarBuild = new TableSchema.TableColumn(schema);
				colvarBuild.ColumnName = "Build";
				colvarBuild.DataType = DbType.Int32;
				colvarBuild.MaxLength = 0;
				colvarBuild.AutoIncrement = false;
				colvarBuild.IsNullable = false;
				colvarBuild.IsPrimaryKey = false;
				colvarBuild.IsForeignKey = false;
				colvarBuild.IsReadOnly = false;
				colvarBuild.DefaultSetting = @"";
				colvarBuild.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBuild);
				
				TableSchema.TableColumn colvarRevision = new TableSchema.TableColumn(schema);
				colvarRevision.ColumnName = "Revision";
				colvarRevision.DataType = DbType.Int32;
				colvarRevision.MaxLength = 0;
				colvarRevision.AutoIncrement = false;
				colvarRevision.IsNullable = false;
				colvarRevision.IsPrimaryKey = false;
				colvarRevision.IsForeignKey = false;
				colvarRevision.IsReadOnly = false;
				colvarRevision.DefaultSetting = @"";
				colvarRevision.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRevision);
				
				TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
				colvarCreatedBy.ColumnName = "CreatedBy";
				colvarCreatedBy.DataType = DbType.String;
				colvarCreatedBy.MaxLength = 50;
				colvarCreatedBy.AutoIncrement = false;
				colvarCreatedBy.IsNullable = true;
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
				colvarModifiedBy.IsNullable = true;
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
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_Version",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("VersionId")]
		public int VersionId 
		{
			get { return GetColumnValue<int>("VersionId"); }

			set { SetColumnValue("VersionId", value); }

		}

		  
		[XmlAttribute("Major")]
		public int Major 
		{
			get { return GetColumnValue<int>("Major"); }

			set { SetColumnValue("Major", value); }

		}

		  
		[XmlAttribute("Minor")]
		public int Minor 
		{
			get { return GetColumnValue<int>("Minor"); }

			set { SetColumnValue("Minor", value); }

		}

		  
		[XmlAttribute("Build")]
		public int Build 
		{
			get { return GetColumnValue<int>("Build"); }

			set { SetColumnValue("Build", value); }

		}

		  
		[XmlAttribute("Revision")]
		public int Revision 
		{
			get { return GetColumnValue<int>("Revision"); }

			set { SetColumnValue("Revision", value); }

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
		public static void Insert(int varMajor,int varMinor,int varBuild,int varRevision,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			Version item = new Version();
			
			item.Major = varMajor;
			
			item.Minor = varMinor;
			
			item.Build = varBuild;
			
			item.Revision = varRevision;
			
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
		public static void Update(int varVersionId,int varMajor,int varMinor,int varBuild,int varRevision,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			Version item = new Version();
			
				item.VersionId = varVersionId;
				
				item.Major = varMajor;
				
				item.Minor = varMinor;
				
				item.Build = varBuild;
				
				item.Revision = varRevision;
				
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
			 public static string VersionId = @"VersionId";
			 public static string Major = @"Major";
			 public static string Minor = @"Minor";
			 public static string Build = @"Build";
			 public static string Revision = @"Revision";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}

		#endregion
	}

}

