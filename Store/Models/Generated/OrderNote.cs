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
	/// Strongly-typed collection for the OrderNote class.
	/// </summary>
	[Serializable]
	public partial class OrderNoteCollection : ActiveList<OrderNote, OrderNoteCollection> 
	{	   
		public OrderNoteCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_OrderNote table.
	/// </summary>
	[Serializable]
	public partial class OrderNote : ActiveRecord<OrderNote>
	{
		#region .ctors and Default Settings
		
		public OrderNote()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public OrderNote(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public OrderNote(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public OrderNote(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_OrderNote", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarOrderNoteId = new TableSchema.TableColumn(schema);
				colvarOrderNoteId.ColumnName = "OrderNoteId";
				colvarOrderNoteId.DataType = DbType.Int32;
				colvarOrderNoteId.MaxLength = 0;
				colvarOrderNoteId.AutoIncrement = true;
				colvarOrderNoteId.IsNullable = false;
				colvarOrderNoteId.IsPrimaryKey = true;
				colvarOrderNoteId.IsForeignKey = false;
				colvarOrderNoteId.IsReadOnly = false;
				colvarOrderNoteId.DefaultSetting = @"";
				colvarOrderNoteId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrderNoteId);
				
				TableSchema.TableColumn colvarOrderId = new TableSchema.TableColumn(schema);
				colvarOrderId.ColumnName = "OrderId";
				colvarOrderId.DataType = DbType.Int32;
				colvarOrderId.MaxLength = 0;
				colvarOrderId.AutoIncrement = false;
				colvarOrderId.IsNullable = false;
				colvarOrderId.IsPrimaryKey = false;
				colvarOrderId.IsForeignKey = true;
				colvarOrderId.IsReadOnly = false;
				colvarOrderId.DefaultSetting = @"";
				
					colvarOrderId.ForeignKeyTableName = "dashCommerce_Store_Order";
				schema.Columns.Add(colvarOrderId);
				
				TableSchema.TableColumn colvarNote = new TableSchema.TableColumn(schema);
				colvarNote.ColumnName = "Note";
				colvarNote.DataType = DbType.String;
				colvarNote.MaxLength = 1500;
				colvarNote.AutoIncrement = false;
				colvarNote.IsNullable = false;
				colvarNote.IsPrimaryKey = false;
				colvarNote.IsForeignKey = false;
				colvarNote.IsReadOnly = false;
				colvarNote.DefaultSetting = @"";
				colvarNote.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNote);
				
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
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_OrderNote",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("OrderNoteId")]
		public int OrderNoteId 
		{
			get { return GetColumnValue<int>("OrderNoteId"); }

			set { SetColumnValue("OrderNoteId", value); }

		}

		  
		[XmlAttribute("OrderId")]
		public int OrderId 
		{
			get { return GetColumnValue<int>("OrderId"); }

			set { SetColumnValue("OrderId", value); }

		}

		  
		[XmlAttribute("Note")]
		public string Note 
		{
			get { return GetColumnValue<string>("Note"); }

			set { SetColumnValue("Note", value); }

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
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Order ActiveRecord object related to this OrderNote
		/// 
		/// </summary>
		public MettleSystems.dashCommerce.Store.Order Order
		{
			get { return MettleSystems.dashCommerce.Store.Order.FetchByID(this.OrderId); }

			set { SetColumnValue("OrderId", value.OrderId); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varOrderId,string varNote,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			OrderNote item = new OrderNote();
			
			item.OrderId = varOrderId;
			
			item.Note = varNote;
			
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
		public static void Update(int varOrderNoteId,int varOrderId,string varNote,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			OrderNote item = new OrderNote();
			
				item.OrderNoteId = varOrderNoteId;
				
				item.OrderId = varOrderId;
				
				item.Note = varNote;
				
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
			 public static string OrderNoteId = @"OrderNoteId";
			 public static string OrderId = @"OrderId";
			 public static string Note = @"Note";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}

		#endregion
	}

}

