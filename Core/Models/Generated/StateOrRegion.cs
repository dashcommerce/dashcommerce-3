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
	/// Strongly-typed collection for the StateOrRegion class.
	/// </summary>
	[Serializable]
	public partial class StateOrRegionCollection : ActiveList<StateOrRegion, StateOrRegionCollection> 
	{	   
		public StateOrRegionCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Core_StateOrRegion table.
	/// </summary>
	[Serializable]
	public partial class StateOrRegion : ActiveRecord<StateOrRegion>
	{
		#region .ctors and Default Settings
		
		public StateOrRegion()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public StateOrRegion(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public StateOrRegion(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public StateOrRegion(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Core_StateOrRegion", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarStateOrRegionId = new TableSchema.TableColumn(schema);
				colvarStateOrRegionId.ColumnName = "StateOrRegionId";
				colvarStateOrRegionId.DataType = DbType.Int32;
				colvarStateOrRegionId.MaxLength = 0;
				colvarStateOrRegionId.AutoIncrement = true;
				colvarStateOrRegionId.IsNullable = false;
				colvarStateOrRegionId.IsPrimaryKey = true;
				colvarStateOrRegionId.IsForeignKey = false;
				colvarStateOrRegionId.IsReadOnly = false;
				colvarStateOrRegionId.DefaultSetting = @"";
				colvarStateOrRegionId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStateOrRegionId);
				
				TableSchema.TableColumn colvarCountryId = new TableSchema.TableColumn(schema);
				colvarCountryId.ColumnName = "CountryId";
				colvarCountryId.DataType = DbType.Int32;
				colvarCountryId.MaxLength = 0;
				colvarCountryId.AutoIncrement = false;
				colvarCountryId.IsNullable = false;
				colvarCountryId.IsPrimaryKey = false;
				colvarCountryId.IsForeignKey = true;
				colvarCountryId.IsReadOnly = false;
				colvarCountryId.DefaultSetting = @"";
				
					colvarCountryId.ForeignKeyTableName = "dashCommerce_Core_Country";
				schema.Columns.Add(colvarCountryId);
				
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
				
				TableSchema.TableColumn colvarAbbreviation = new TableSchema.TableColumn(schema);
				colvarAbbreviation.ColumnName = "Abbreviation";
				colvarAbbreviation.DataType = DbType.String;
				colvarAbbreviation.MaxLength = 6;
				colvarAbbreviation.AutoIncrement = false;
				colvarAbbreviation.IsNullable = false;
				colvarAbbreviation.IsPrimaryKey = false;
				colvarAbbreviation.IsForeignKey = false;
				colvarAbbreviation.IsReadOnly = false;
				colvarAbbreviation.DefaultSetting = @"";
				colvarAbbreviation.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAbbreviation);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Core_StateOrRegion",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("StateOrRegionId")]
		public int StateOrRegionId 
		{
			get { return GetColumnValue<int>("StateOrRegionId"); }

			set { SetColumnValue("StateOrRegionId", value); }

		}

		  
		[XmlAttribute("CountryId")]
		public int CountryId 
		{
			get { return GetColumnValue<int>("CountryId"); }

			set { SetColumnValue("CountryId", value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>("Name"); }

			set { SetColumnValue("Name", value); }

		}

		  
		[XmlAttribute("Abbreviation")]
		public string Abbreviation 
		{
			get { return GetColumnValue<string>("Abbreviation"); }

			set { SetColumnValue("Abbreviation", value); }

		}

		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Country ActiveRecord object related to this StateOrRegion
		/// 
		/// </summary>
		public MettleSystems.dashCommerce.Core.Country Country
		{
			get { return MettleSystems.dashCommerce.Core.Country.FetchByID(this.CountryId); }

			set { SetColumnValue("CountryId", value.CountryId); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varCountryId,string varName,string varAbbreviation)
		{
			StateOrRegion item = new StateOrRegion();
			
			item.CountryId = varCountryId;
			
			item.Name = varName;
			
			item.Abbreviation = varAbbreviation;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varStateOrRegionId,int varCountryId,string varName,string varAbbreviation)
		{
			StateOrRegion item = new StateOrRegion();
			
				item.StateOrRegionId = varStateOrRegionId;
				
				item.CountryId = varCountryId;
				
				item.Name = varName;
				
				item.Abbreviation = varAbbreviation;
				
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
			 public static string StateOrRegionId = @"StateOrRegionId";
			 public static string CountryId = @"CountryId";
			 public static string Name = @"Name";
			 public static string Abbreviation = @"Abbreviation";
						
		}

		#endregion
	}

}

