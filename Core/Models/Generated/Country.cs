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

namespace MettleSystems.dashCommerce.Core
{
	/// <summary>
	/// Strongly-typed collection for the Country class.
	/// </summary>
	[Serializable]
	public partial class CountryCollection : ActiveList<Country, CountryCollection> 
	{	   
		public CountryCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Core_Country table.
	/// </summary>
	[Serializable]
	public partial class Country : ActiveRecord<Country>
	{
		#region .ctors and Default Settings
		
		public Country()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Country(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Country(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Country(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Core_Country", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarCountryId = new TableSchema.TableColumn(schema);
				colvarCountryId.ColumnName = "CountryId";
				colvarCountryId.DataType = DbType.Int32;
				colvarCountryId.MaxLength = 0;
				colvarCountryId.AutoIncrement = true;
				colvarCountryId.IsNullable = false;
				colvarCountryId.IsPrimaryKey = true;
				colvarCountryId.IsForeignKey = false;
				colvarCountryId.IsReadOnly = false;
				colvarCountryId.DefaultSetting = @"";
				colvarCountryId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCountryId);
				
				TableSchema.TableColumn colvarCode = new TableSchema.TableColumn(schema);
				colvarCode.ColumnName = "Code";
				colvarCode.DataType = DbType.String;
				colvarCode.MaxLength = 2;
				colvarCode.AutoIncrement = false;
				colvarCode.IsNullable = false;
				colvarCode.IsPrimaryKey = false;
				colvarCode.IsForeignKey = false;
				colvarCode.IsReadOnly = false;
				colvarCode.DefaultSetting = @"";
				colvarCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCode);
				
				TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
				colvarName.ColumnName = "Name";
				colvarName.DataType = DbType.String;
				colvarName.MaxLength = 255;
				colvarName.AutoIncrement = false;
				colvarName.IsNullable = false;
				colvarName.IsPrimaryKey = false;
				colvarName.IsForeignKey = false;
				colvarName.IsReadOnly = false;
				colvarName.DefaultSetting = @"";
				colvarName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarName);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Core_Country",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("CountryId")]
		public int CountryId 
		{
			get { return GetColumnValue<int>("CountryId"); }

			set { SetColumnValue("CountryId", value); }

		}

		  
		[XmlAttribute("Code")]
		public string Code 
		{
			get { return GetColumnValue<string>("Code"); }

			set { SetColumnValue("Code", value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>("Name"); }

			set { SetColumnValue("Name", value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		public MettleSystems.dashCommerce.Core.StateOrRegionCollection StateOrRegionRecords()
		{
			return new MettleSystems.dashCommerce.Core.StateOrRegionCollection().Where(StateOrRegion.Columns.CountryId, CountryId).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCode,string varName)
		{
			Country item = new Country();
			
			item.Code = varCode;
			
			item.Name = varName;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varCountryId,string varCode,string varName)
		{
			Country item = new Country();
			
				item.CountryId = varCountryId;
				
				item.Code = varCode;
				
				item.Name = varName;
				
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
			 public static string CountryId = @"CountryId";
			 public static string Code = @"Code";
			 public static string Name = @"Name";
						
		}

		#endregion
	}

}

