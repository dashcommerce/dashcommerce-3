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
    /// Controller class for dashCommerce_Store_Product
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ProductController
    {
        // Preload our schema..
        Product thisSchemaLoad = new Product();
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
        public ProductCollection FetchAll()
        {
            ProductCollection coll = new ProductCollection();
            Query qry = new Query(Product.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductCollection FetchByID(object ProductId)
        {
            ProductCollection coll = new ProductCollection().Where("ProductId", ProductId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductCollection FetchByQuery(Query qry)
        {
            ProductCollection coll = new ProductCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ProductId)
        {
            return (Product.Delete(ProductId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ProductId)
        {
            return (Product.Destroy(ProductId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ManufacturerId,int ProductStatusDescriptorId,int ProductTypeId,int ShippingEstimateId,string BaseSku,Guid ProductGuid,string Name,string ShortDescription,decimal OurPrice,decimal RetailPrice,int TaxRateId,decimal Weight,decimal Length,decimal Height,decimal Width,int SortOrder,int RatingSum,int TotalRatingVotes,bool AllowNegativeInventories,bool IsEnabled,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn,bool IsDeleted)
	    {
		    Product item = new Product();
		    
            item.ManufacturerId = ManufacturerId;
            
            item.ProductStatusDescriptorId = ProductStatusDescriptorId;
            
            item.ProductTypeId = ProductTypeId;
            
            item.ShippingEstimateId = ShippingEstimateId;
            
            item.BaseSku = BaseSku;
            
            item.ProductGuid = ProductGuid;
            
            item.Name = Name;
            
            item.ShortDescription = ShortDescription;
            
            item.OurPrice = OurPrice;
            
            item.RetailPrice = RetailPrice;
            
            item.TaxRateId = TaxRateId;
            
            item.Weight = Weight;
            
            item.Length = Length;
            
            item.Height = Height;
            
            item.Width = Width;
            
            item.SortOrder = SortOrder;
            
            item.RatingSum = RatingSum;
            
            item.TotalRatingVotes = TotalRatingVotes;
            
            item.AllowNegativeInventories = AllowNegativeInventories;
            
            item.IsEnabled = IsEnabled;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
            item.IsDeleted = IsDeleted;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ProductId,int ManufacturerId,int ProductStatusDescriptorId,int ProductTypeId,int ShippingEstimateId,string BaseSku,Guid ProductGuid,string Name,string ShortDescription,decimal OurPrice,decimal RetailPrice,int TaxRateId,decimal Weight,decimal Length,decimal Height,decimal Width,int SortOrder,int RatingSum,int TotalRatingVotes,bool AllowNegativeInventories,bool IsEnabled,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn,bool IsDeleted)
	    {
		    Product item = new Product();
		    
				item.ProductId = ProductId;
				
				item.ManufacturerId = ManufacturerId;
				
				item.ProductStatusDescriptorId = ProductStatusDescriptorId;
				
				item.ProductTypeId = ProductTypeId;
				
				item.ShippingEstimateId = ShippingEstimateId;
				
				item.BaseSku = BaseSku;
				
				item.ProductGuid = ProductGuid;
				
				item.Name = Name;
				
				item.ShortDescription = ShortDescription;
				
				item.OurPrice = OurPrice;
				
				item.RetailPrice = RetailPrice;
				
				item.TaxRateId = TaxRateId;
				
				item.Weight = Weight;
				
				item.Length = Length;
				
				item.Height = Height;
				
				item.Width = Width;
				
				item.SortOrder = SortOrder;
				
				item.RatingSum = RatingSum;
				
				item.TotalRatingVotes = TotalRatingVotes;
				
				item.AllowNegativeInventories = AllowNegativeInventories;
				
				item.IsEnabled = IsEnabled;
				
				item.CreatedBy = CreatedBy;
				
				item.CreatedOn = CreatedOn;
				
				item.ModifiedBy = ModifiedBy;
				
				item.ModifiedOn = ModifiedOn;
				
				item.IsDeleted = IsDeleted;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

