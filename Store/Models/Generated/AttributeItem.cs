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
	/// Strongly-typed collection for the AttributeItem class.
	/// </summary>
	[Serializable]
	public partial class AttributeItemCollection : ActiveList<AttributeItem, AttributeItemCollection> 
	{	   
		public AttributeItemCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_AttributeItem table.
	/// </summary>
	[Serializable]
	public partial class AttributeItem : ActiveRecord<AttributeItem>
	{
		#region .ctors and Default Settings
		
		public AttributeItem()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public AttributeItem(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public AttributeItem(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public AttributeItem(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_AttributeItem", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarAttributeItemId = new TableSchema.TableColumn(schema);
				colvarAttributeItemId.ColumnName = "AttributeItemId";
				colvarAttributeItemId.DataType = DbType.Int32;
				colvarAttributeItemId.MaxLength = 0;
				colvarAttributeItemId.AutoIncrement = true;
				colvarAttributeItemId.IsNullable = false;
				colvarAttributeItemId.IsPrimaryKey = true;
				colvarAttributeItemId.IsForeignKey = false;
				colvarAttributeItemId.IsReadOnly = false;
				colvarAttributeItemId.DefaultSetting = @"";
				colvarAttributeItemId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAttributeItemId);
				
				TableSchema.TableColumn colvarAttributeId = new TableSchema.TableColumn(schema);
				colvarAttributeId.ColumnName = "AttributeId";
				colvarAttributeId.DataType = DbType.Int32;
				colvarAttributeId.MaxLength = 0;
				colvarAttributeId.AutoIncrement = false;
				colvarAttributeId.IsNullable = false;
				colvarAttributeId.IsPrimaryKey = false;
				colvarAttributeId.IsForeignKey = true;
				colvarAttributeId.IsReadOnly = false;
				colvarAttributeId.DefaultSetting = @"";
				
					colvarAttributeId.ForeignKeyTableName = "dashCommerce_Store_Attribute";
				schema.Columns.Add(colvarAttributeId);
				
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
				
				TableSchema.TableColumn colvarAdjustment = new TableSchema.TableColumn(schema);
				colvarAdjustment.ColumnName = "Adjustment";
				colvarAdjustment.DataType = DbType.Currency;
				colvarAdjustment.MaxLength = 0;
				colvarAdjustment.AutoIncrement = false;
				colvarAdjustment.IsNullable = false;
				colvarAdjustment.IsPrimaryKey = false;
				colvarAdjustment.IsForeignKey = false;
				colvarAdjustment.IsReadOnly = false;
				colvarAdjustment.DefaultSetting = @"";
				colvarAdjustment.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdjustment);
				
				TableSchema.TableColumn colvarSortOrder = new TableSchema.TableColumn(schema);
				colvarSortOrder.ColumnName = "SortOrder";
				colvarSortOrder.DataType = DbType.Int32;
				colvarSortOrder.MaxLength = 0;
				colvarSortOrder.AutoIncrement = false;
				colvarSortOrder.IsNullable = false;
				colvarSortOrder.IsPrimaryKey = false;
				colvarSortOrder.IsForeignKey = false;
				colvarSortOrder.IsReadOnly = false;
				colvarSortOrder.DefaultSetting = @"";
				colvarSortOrder.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSortOrder);
				
				TableSchema.TableColumn colvarSkuSuffix = new TableSchema.TableColumn(schema);
				colvarSkuSuffix.ColumnName = "SkuSuffix";
				colvarSkuSuffix.DataType = DbType.String;
				colvarSkuSuffix.MaxLength = 50;
				colvarSkuSuffix.AutoIncrement = false;
				colvarSkuSuffix.IsNullable = true;
				colvarSkuSuffix.IsPrimaryKey = false;
				colvarSkuSuffix.IsForeignKey = false;
				colvarSkuSuffix.IsReadOnly = false;
				colvarSkuSuffix.DefaultSetting = @"";
				colvarSkuSuffix.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSkuSuffix);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_AttributeItem",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("AttributeItemId")]
		public int AttributeItemId 
		{
			get { return GetColumnValue<int>("AttributeItemId"); }

			set { SetColumnValue("AttributeItemId", value); }

		}

		  
		[XmlAttribute("AttributeId")]
		public int AttributeId 
		{
			get { return GetColumnValue<int>("AttributeId"); }

			set { SetColumnValue("AttributeId", value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>("Name"); }

			set { SetColumnValue("Name", value); }

		}

		  
		[XmlAttribute("Adjustment")]
		public decimal Adjustment 
		{
			get { return GetColumnValue<decimal>("Adjustment"); }

			set { SetColumnValue("Adjustment", value); }

		}

		  
		[XmlAttribute("SortOrder")]
		public int SortOrder 
		{
			get { return GetColumnValue<int>("SortOrder"); }

			set { SetColumnValue("SortOrder", value); }

		}

		  
		[XmlAttribute("SkuSuffix")]
		public string SkuSuffix 
		{
			get { return GetColumnValue<string>("SkuSuffix"); }

			set { SetColumnValue("SkuSuffix", value); }

		}

		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Attribute ActiveRecord object related to this AttributeItem
		/// 
		/// </summary>
		public MettleSystems.dashCommerce.Store.Attribute Attribute
		{
			get { return MettleSystems.dashCommerce.Store.Attribute.FetchByID(this.AttributeId); }

			set { SetColumnValue("AttributeId", value.AttributeId); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varAttributeId,string varName,decimal varAdjustment,int varSortOrder,string varSkuSuffix)
		{
			AttributeItem item = new AttributeItem();
			
			item.AttributeId = varAttributeId;
			
			item.Name = varName;
			
			item.Adjustment = varAdjustment;
			
			item.SortOrder = varSortOrder;
			
			item.SkuSuffix = varSkuSuffix;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varAttributeItemId,int varAttributeId,string varName,decimal varAdjustment,int varSortOrder,string varSkuSuffix)
		{
			AttributeItem item = new AttributeItem();
			
				item.AttributeItemId = varAttributeItemId;
				
				item.AttributeId = varAttributeId;
				
				item.Name = varName;
				
				item.Adjustment = varAdjustment;
				
				item.SortOrder = varSortOrder;
				
				item.SkuSuffix = varSkuSuffix;
				
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
			 public static string AttributeItemId = @"AttributeItemId";
			 public static string AttributeId = @"AttributeId";
			 public static string Name = @"Name";
			 public static string Adjustment = @"Adjustment";
			 public static string SortOrder = @"SortOrder";
			 public static string SkuSuffix = @"SkuSuffix";
						
		}

		#endregion
	}

}

