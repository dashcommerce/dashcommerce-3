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
    /// Controller class for dashCommerce_Store_Coupon
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CouponController
    {
        // Preload our schema..
        Coupon thisSchemaLoad = new Coupon();
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
        public CouponCollection FetchAll()
        {
            CouponCollection coll = new CouponCollection();
            Query qry = new Query(Coupon.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CouponCollection FetchByID(object CouponId)
        {
            CouponCollection coll = new CouponCollection().Where("CouponId", CouponId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CouponCollection FetchByQuery(Query qry)
        {
            CouponCollection coll = new CouponCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object CouponId)
        {
            return (Coupon.Delete(CouponId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object CouponId)
        {
            return (Coupon.Destroy(CouponId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string CouponCode,DateTime? ExpirationDate,bool IsSingleUse,string Type,string ValueX,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    Coupon item = new Coupon();
		    
            item.CouponCode = CouponCode;
            
            item.ExpirationDate = ExpirationDate;
            
            item.IsSingleUse = IsSingleUse;
            
            item.Type = Type;
            
            item.ValueX = ValueX;
            
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
	    public void Update(int CouponId,string CouponCode,DateTime? ExpirationDate,bool IsSingleUse,string Type,string ValueX,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    Coupon item = new Coupon();
		    
				item.CouponId = CouponId;
				
				item.CouponCode = CouponCode;
				
				item.ExpirationDate = ExpirationDate;
				
				item.IsSingleUse = IsSingleUse;
				
				item.Type = Type;
				
				item.ValueX = ValueX;
				
				item.CreatedBy = CreatedBy;
				
				item.CreatedOn = CreatedOn;
				
				item.ModifiedBy = ModifiedBy;
				
				item.ModifiedOn = ModifiedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

