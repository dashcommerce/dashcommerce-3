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
    /// Controller class for dashCommerce_Store_Descriptor
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class DescriptorController
    {
        // Preload our schema..
        Descriptor thisSchemaLoad = new Descriptor();
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
        public DescriptorCollection FetchAll()
        {
            DescriptorCollection coll = new DescriptorCollection();
            Query qry = new Query(Descriptor.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public DescriptorCollection FetchByID(object DescriptorId)
        {
            DescriptorCollection coll = new DescriptorCollection().Where("DescriptorId", DescriptorId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public DescriptorCollection FetchByQuery(Query qry)
        {
            DescriptorCollection coll = new DescriptorCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object DescriptorId)
        {
            return (Descriptor.Delete(DescriptorId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object DescriptorId)
        {
            return (Descriptor.Destroy(DescriptorId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ProductId,string Title,string DescriptorX,int SortOrder,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    Descriptor item = new Descriptor();
		    
            item.ProductId = ProductId;
            
            item.Title = Title;
            
            item.DescriptorX = DescriptorX;
            
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
	    public void Update(int DescriptorId,int ProductId,string Title,string DescriptorX,int SortOrder,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    Descriptor item = new Descriptor();
		    
				item.DescriptorId = DescriptorId;
				
				item.ProductId = ProductId;
				
				item.Title = Title;
				
				item.DescriptorX = DescriptorX;
				
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

