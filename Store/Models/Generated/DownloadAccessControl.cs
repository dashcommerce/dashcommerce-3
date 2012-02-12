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
	/// Strongly-typed collection for the DownloadAccessControl class.
	/// </summary>
	[Serializable]
	public partial class DownloadAccessControlCollection : ActiveList<DownloadAccessControl, DownloadAccessControlCollection> 
	{	   
		public DownloadAccessControlCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the dashCommerce_Store_DownloadAccessControl table.
	/// </summary>
	[Serializable]
	public partial class DownloadAccessControl : ActiveRecord<DownloadAccessControl>
	{
		#region .ctors and Default Settings
		
		public DownloadAccessControl()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public DownloadAccessControl(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public DownloadAccessControl(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public DownloadAccessControl(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("dashCommerce_Store_DownloadAccessControl", TableType.Table, DataService.GetInstance("dashCommerceProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarUserId = new TableSchema.TableColumn(schema);
				colvarUserId.ColumnName = "UserId";
				colvarUserId.DataType = DbType.Guid;
				colvarUserId.MaxLength = 0;
				colvarUserId.AutoIncrement = false;
				colvarUserId.IsNullable = false;
				colvarUserId.IsPrimaryKey = true;
				colvarUserId.IsForeignKey = true;
				colvarUserId.IsReadOnly = false;
				colvarUserId.DefaultSetting = @"";
				
					colvarUserId.ForeignKeyTableName = "aspnet_Users";
				schema.Columns.Add(colvarUserId);
				
				TableSchema.TableColumn colvarDownloadId = new TableSchema.TableColumn(schema);
				colvarDownloadId.ColumnName = "DownloadId";
				colvarDownloadId.DataType = DbType.Int32;
				colvarDownloadId.MaxLength = 0;
				colvarDownloadId.AutoIncrement = false;
				colvarDownloadId.IsNullable = false;
				colvarDownloadId.IsPrimaryKey = true;
				colvarDownloadId.IsForeignKey = true;
				colvarDownloadId.IsReadOnly = false;
				colvarDownloadId.DefaultSetting = @"";
				
					colvarDownloadId.ForeignKeyTableName = "dashCommerce_Store_Download";
				schema.Columns.Add(colvarDownloadId);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["dashCommerceProvider"].AddSchema("dashCommerce_Store_DownloadAccessControl",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("UserId")]
		public Guid UserId 
		{
			get { return GetColumnValue<Guid>("UserId"); }

			set { SetColumnValue("UserId", value); }

		}

		  
		[XmlAttribute("DownloadId")]
		public int DownloadId 
		{
			get { return GetColumnValue<int>("DownloadId"); }

			set { SetColumnValue("DownloadId", value); }

		}

		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Download ActiveRecord object related to this DownloadAccessControl
		/// 
		/// </summary>
		public MettleSystems.dashCommerce.Store.Download Download
		{
			get { return MettleSystems.dashCommerce.Store.Download.FetchByID(this.DownloadId); }

			set { SetColumnValue("DownloadId", value.DownloadId); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(Guid varUserId,int varDownloadId)
		{
			DownloadAccessControl item = new DownloadAccessControl();
			
			item.UserId = varUserId;
			
			item.DownloadId = varDownloadId;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(Guid varUserId,int varDownloadId)
		{
			DownloadAccessControl item = new DownloadAccessControl();
			
				item.UserId = varUserId;
				
				item.DownloadId = varDownloadId;
				
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
			 public static string UserId = @"UserId";
			 public static string DownloadId = @"DownloadId";
						
		}

		#endregion
	}

}

