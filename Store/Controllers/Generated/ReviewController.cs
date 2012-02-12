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
    /// Controller class for dashCommerce_Store_Review
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ReviewController
    {
        // Preload our schema..
        Review thisSchemaLoad = new Review();
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
        public ReviewCollection FetchAll()
        {
            ReviewCollection coll = new ReviewCollection();
            Query qry = new Query(Review.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ReviewCollection FetchByID(object ReviewId)
        {
            ReviewCollection coll = new ReviewCollection().Where("ReviewId", ReviewId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ReviewCollection FetchByQuery(Query qry)
        {
            ReviewCollection coll = new ReviewCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ReviewId)
        {
            return (Review.Delete(ReviewId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ReviewId)
        {
            return (Review.Destroy(ReviewId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ProductId,string Title,string Body,int Rating,bool IsApproved,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    Review item = new Review();
		    
            item.ProductId = ProductId;
            
            item.Title = Title;
            
            item.Body = Body;
            
            item.Rating = Rating;
            
            item.IsApproved = IsApproved;
            
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
	    public void Update(int ReviewId,int ProductId,string Title,string Body,int Rating,bool IsApproved,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    Review item = new Review();
		    
				item.ReviewId = ReviewId;
				
				item.ProductId = ProductId;
				
				item.Title = Title;
				
				item.Body = Body;
				
				item.Rating = Rating;
				
				item.IsApproved = IsApproved;
				
				item.CreatedBy = CreatedBy;
				
				item.CreatedOn = CreatedOn;
				
				item.ModifiedBy = ModifiedBy;
				
				item.ModifiedOn = ModifiedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

