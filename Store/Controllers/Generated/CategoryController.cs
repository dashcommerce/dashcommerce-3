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
    /// Controller class for dashCommerce_Store_Category
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CategoryController
    {
        // Preload our schema..
        Category thisSchemaLoad = new Category();
        private string userName = string.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}

					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}

				}

				return userName;
            }

        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CategoryCollection FetchAll()
        {
            CategoryCollection coll = new CategoryCollection();
            Query qry = new Query(Category.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CategoryCollection FetchByID(object CategoryId)
        {
            CategoryCollection coll = new CategoryCollection().Where("CategoryId", CategoryId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CategoryCollection FetchByQuery(Query qry)
        {
            CategoryCollection coll = new CategoryCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object CategoryId)
        {
            return (Category.Delete(CategoryId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object CategoryId)
        {
            return (Category.Destroy(CategoryId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(Guid CategoryGuid,int ParentId,string Name,string ImageFile,string Description,int SortOrder,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    Category item = new Category();
		    
            item.CategoryGuid = CategoryGuid;
            
            item.ParentId = ParentId;
            
            item.Name = Name;
            
            item.ImageFile = ImageFile;
            
            item.Description = Description;
            
            item.SortOrder = SortOrder;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int CategoryId,Guid CategoryGuid,int ParentId,string Name,string ImageFile,string Description,int SortOrder,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    Category item = new Category();
		    
				item.CategoryId = CategoryId;
				
				item.CategoryGuid = CategoryGuid;
				
				item.ParentId = ParentId;
				
				item.Name = Name;
				
				item.ImageFile = ImageFile;
				
				item.Description = Description;
				
				item.SortOrder = SortOrder;
				
				item.CreatedBy = CreatedBy;
				
				item.CreatedOn = CreatedOn;
				
				item.ModifiedBy = ModifiedBy;
				
				item.ModifiedOn = ModifiedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

