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
	/// Strongly-typed collection for the Currency class.
	/// </summary>
	[Serializable]
	public partial class CurrencyCollection : ActiveList<Currency, CurrencyCollection> 
	{	   
		public CurrencyCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_Currency table.
	/// </summary>
	[Serializable]
	public partial class Currency : ActiveRecord<Currency>
	{
		#region .ctors and Default Settings
		
		public Currency()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Currency(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Currency(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Currency(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_Currency", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarCodeID = new TableSchema.TableColumn(schema);
				colvarCodeID.ColumnName = "codeID";
				colvarCodeID.DataType = DbType.Int32;
				colvarCodeID.MaxLength = 0;
				colvarCodeID.AutoIncrement = true;
				colvarCodeID.IsNullable = false;
				colvarCodeID.IsPrimaryKey = true;
				colvarCodeID.IsForeignKey = false;
				colvarCodeID.IsReadOnly = false;
				colvarCodeID.DefaultSetting = @"";
				colvarCodeID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodeID);
				
				TableSchema.TableColumn colvarCode = new TableSchema.TableColumn(schema);
				colvarCode.ColumnName = "code";
				colvarCode.DataType = DbType.AnsiStringFixedLength;
				colvarCode.MaxLength = 3;
				colvarCode.AutoIncrement = false;
				colvarCode.IsNullable = false;
				colvarCode.IsPrimaryKey = false;
				colvarCode.IsForeignKey = false;
				colvarCode.IsReadOnly = false;
				colvarCode.DefaultSetting = @"";
				colvarCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCode);
				
				TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
				colvarDescription.ColumnName = "description";
				colvarDescription.DataType = DbType.String;
				colvarDescription.MaxLength = 255;
				colvarDescription.AutoIncrement = false;
				colvarDescription.IsNullable = false;
				colvarDescription.IsPrimaryKey = false;
				colvarDescription.IsForeignKey = false;
				colvarDescription.IsReadOnly = false;
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_Currency",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("CodeID")]
		public int CodeID 
		{
			get { return GetColumnValue<int>("codeID"); }

			set { SetColumnValue("codeID", value); }

		}

		  
		[XmlAttribute("Code")]
		public string Code 
		{
			get { return GetColumnValue<string>("code"); }

			set { SetColumnValue("code", value); }

		}

		  
		[XmlAttribute("Description")]
		public string Description 
		{
			get { return GetColumnValue<string>("description"); }

			set { SetColumnValue("description", value); }

		}

		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCode,string varDescription)
		{
			Currency item = new Currency();
			
			item.Code = varCode;
			
			item.Description = varDescription;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varCodeID,string varCode,string varDescription)
		{
			Currency item = new Currency();
			
				item.CodeID = varCodeID;
				
				item.Code = varCode;
				
				item.Description = varDescription;
				
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
			 public static string CodeID = @"codeID";
			 public static string Code = @"code";
			 public static string Description = @"description";
						
		}

		#endregion
	}

}

