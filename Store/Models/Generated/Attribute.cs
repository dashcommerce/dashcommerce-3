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
	/// Strongly-typed collection for the Attribute class.
	/// </summary>
	[Serializable]
	public partial class AttributeCollection : ActiveList<Attribute, AttributeCollection> 
	{	   
		public AttributeCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_Attribute table.
	/// </summary>
	[Serializable]
	public partial class Attribute : ActiveRecord<Attribute>
	{
		#region .ctors and Default Settings
		
		public Attribute()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Attribute(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Attribute(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Attribute(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_Attribute", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarAttributeId = new TableSchema.TableColumn(schema);
				colvarAttributeId.ColumnName = "AttributeId";
				colvarAttributeId.DataType = DbType.Int32;
				colvarAttributeId.MaxLength = 0;
				colvarAttributeId.AutoIncrement = true;
				colvarAttributeId.IsNullable = false;
				colvarAttributeId.IsPrimaryKey = true;
				colvarAttributeId.IsForeignKey = false;
				colvarAttributeId.IsReadOnly = false;
				colvarAttributeId.DefaultSetting = @"";
				colvarAttributeId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAttributeId);
				
				TableSchema.TableColumn colvarAttributeTypeId = new TableSchema.TableColumn(schema);
				colvarAttributeTypeId.ColumnName = "AttributeTypeId";
				colvarAttributeTypeId.DataType = DbType.Int32;
				colvarAttributeTypeId.MaxLength = 0;
				colvarAttributeTypeId.AutoIncrement = false;
				colvarAttributeTypeId.IsNullable = false;
				colvarAttributeTypeId.IsPrimaryKey = false;
				colvarAttributeTypeId.IsForeignKey = true;
				colvarAttributeTypeId.IsReadOnly = false;
				colvarAttributeTypeId.DefaultSetting = @"";
				
					colvarAttributeTypeId.ForeignKeyTableName = "dashCommerce_Store_AttributeType";
				schema.Columns.Add(colvarAttributeTypeId);
				
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
				
				TableSchema.TableColumn colvarLabel = new TableSchema.TableColumn(schema);
				colvarLabel.ColumnName = "Label";
				colvarLabel.DataType = DbType.String;
				colvarLabel.MaxLength = 150;
				colvarLabel.AutoIncrement = false;
				colvarLabel.IsNullable = true;
				colvarLabel.IsPrimaryKey = false;
				colvarLabel.IsForeignKey = false;
				colvarLabel.IsReadOnly = false;
				colvarLabel.DefaultSetting = @"";
				colvarLabel.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLabel);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_Attribute",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("AttributeId")]
		public int AttributeId 
		{
			get { return GetColumnValue<int>("AttributeId"); }

			set { SetColumnValue("AttributeId", value); }

		}

		  
		[XmlAttribute("AttributeTypeId")]
		public int AttributeTypeId 
		{
			get { return GetColumnValue<int>("AttributeTypeId"); }

			set { SetColumnValue("AttributeTypeId", value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>("Name"); }

			set { SetColumnValue("Name", value); }

		}

		  
		[XmlAttribute("Label")]
		public string Label 
		{
			get { return GetColumnValue<string>("Label"); }

			set { SetColumnValue("Label", value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		public MettleSystems.dashCommerce.Store.AttributeItemCollection AttributeItemRecords()
		{
			return new MettleSystems.dashCommerce.Store.AttributeItemCollection().Where(AttributeItem.Columns.AttributeId, AttributeId).Load();
		}

		public MettleSystems.dashCommerce.Store.ProductAttributeMapCollection ProductAttributeMapRecords()
		{
			return new MettleSystems.dashCommerce.Store.ProductAttributeMapCollection().Where(ProductAttributeMap.Columns.AttributeId, AttributeId).Load();
		}

		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AttributeType ActiveRecord object related to this Attribute
		/// 
		/// </summary>
		public MettleSystems.dashCommerce.Store.AttributeType AttributeType
		{
			get { return MettleSystems.dashCommerce.Store.AttributeType.FetchByID(this.AttributeTypeId); }

			set { SetColumnValue("AttributeTypeId", value.AttributeTypeId); }

		}

		
		
		#endregion
		
		
		
		#region Many To Many Helpers
		
		 
		public MettleSystems.dashCommerce.Store.ProductCollection GetProductCollection() { return Attribute.GetProductCollection(this.AttributeId); }

		public static MettleSystems.dashCommerce.Store.ProductCollection GetProductCollection(int varAttributeId)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM dashCommerce_Store_Product INNER JOIN dashCommerce_Store_Product_Attribute_Map ON "+
				"dashCommerce_Store_Product.ProductId=dashCommerce_Store_Product_Attribute_Map.ProductId WHERE dashCommerce_Store_Product_Attribute_Map.AttributeId=@AttributeId", Attribute.Schema.Provider.Name);
			
			cmd.AddParameter("@AttributeId", varAttributeId, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ProductCollection coll = new ProductCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveProductMap(int varAttributeId, ProductCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Store_Product_Attribute_Map WHERE AttributeId=@AttributeId", Attribute.Schema.Provider.Name);
			cmdDel.AddParameter("@AttributeId", varAttributeId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Product item in items)
			{
				ProductAttributeMap varProductAttributeMap = new ProductAttributeMap();
				varProductAttributeMap.SetColumnValue("AttributeId", varAttributeId);
				varProductAttributeMap.SetColumnValue("ProductId", item.GetPrimaryKeyValue());
				varProductAttributeMap.Save();
			}

		}

		public static void SaveProductMap(int varAttributeId, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Store_Product_Attribute_Map WHERE AttributeId=@AttributeId", Attribute.Schema.Provider.Name);
			cmdDel.AddParameter("@AttributeId", varAttributeId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductAttributeMap varProductAttributeMap = new ProductAttributeMap();
					varProductAttributeMap.SetColumnValue("AttributeId", varAttributeId);
					varProductAttributeMap.SetColumnValue("ProductId", l.Value);
					varProductAttributeMap.Save();
				}

			}

		}

		public static void SaveProductMap(int varAttributeId , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Store_Product_Attribute_Map WHERE AttributeId=@AttributeId", Attribute.Schema.Provider.Name);
			cmdDel.AddParameter("@AttributeId", varAttributeId);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				ProductAttributeMap varProductAttributeMap = new ProductAttributeMap();
				varProductAttributeMap.SetColumnValue("AttributeId", varAttributeId);
				varProductAttributeMap.SetColumnValue("ProductId", item);
				varProductAttributeMap.Save();
			}

		}

		
		public static void DeleteProductMap(int varAttributeId) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM dashCommerce_Store_Product_Attribute_Map WHERE AttributeId=@AttributeId", Attribute.Schema.Provider.Name);
			cmdDel.AddParameter("@AttributeId", varAttributeId);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varAttributeTypeId,string varName,string varLabel)
		{
			Attribute item = new Attribute();
			
			item.AttributeTypeId = varAttributeTypeId;
			
			item.Name = varName;
			
			item.Label = varLabel;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varAttributeId,int varAttributeTypeId,string varName,string varLabel)
		{
			Attribute item = new Attribute();
			
				item.AttributeId = varAttributeId;
				
				item.AttributeTypeId = varAttributeTypeId;
				
				item.Name = varName;
				
				item.Label = varLabel;
				
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
			 public static string AttributeId = @"AttributeId";
			 public static string AttributeTypeId = @"AttributeTypeId";
			 public static string Name = @"Name";
			 public static string Label = @"Label";
						
		}

		#endregion
	}

}

