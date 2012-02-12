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

namespace MettleSystems.dashCommerce.Store{
    public partial class SPs{
        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchCategoryBreadCrumbs Procedure
        /// </summary>
        public static StoredProcedure FetchCategoryBreadCrumbs(int? CategoryId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchCategoryBreadCrumbs" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@CategoryId", CategoryId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchRandomProducts Procedure
        /// </summary>
        public static StoredProcedure FetchRandomProducts()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchRandomProducts" , DataService.GetInstance("dashCommerceProvider"));
        	
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchProductCrossSells Procedure
        /// </summary>
        public static StoredProcedure FetchProductCrossSells(int? ProductId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchProductCrossSells" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@ProductId", ProductId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchAssociatedAttributesByProductId Procedure
        /// </summary>
        public static StoredProcedure FetchAssociatedAttributesByProductId(int? ProductId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchAssociatedAttributesByProductId" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@ProductId", ProductId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchAvailableAttributesByProductId Procedure
        /// </summary>
        public static StoredProcedure FetchAvailableAttributesByProductId(int? ProductId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchAvailableAttributesByProductId" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@ProductId", ProductId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchAssociatedCategoriesByProductId Procedure
        /// </summary>
        public static StoredProcedure FetchAssociatedCategoriesByProductId(int? ProductId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchAssociatedCategoriesByProductId" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@ProductId", ProductId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchCategoryPriceRanges Procedure
        /// </summary>
        public static StoredProcedure FetchCategoryPriceRanges(int? CategoryId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchCategoryPriceRanges" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@CategoryId", CategoryId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchCategoryManufacturers Procedure
        /// </summary>
        public static StoredProcedure FetchCategoryManufacturers(int? CategoryId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchCategoryManufacturers" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@CategoryId", CategoryId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchProductsByCategoryIdAndManufacturerId Procedure
        /// </summary>
        public static StoredProcedure FetchProductsByCategoryIdAndManufacturerId(int? CategoryId, int? ManufacturerId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchProductsByCategoryIdAndManufacturerId" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@CategoryId", CategoryId,DbType.Int32);
        	    
            sp.Command.AddParameter("@ManufacturerId", ManufacturerId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchProductsByCategoryId Procedure
        /// </summary>
        public static StoredProcedure FetchProductsByCategoryId(int? CategoryId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchProductsByCategoryId" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@CategoryId", CategoryId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchProductsByCategoryIdAndPriceRange Procedure
        /// </summary>
        public static StoredProcedure FetchProductsByCategoryIdAndPriceRange(int? CategoryId, decimal? PriceStart, decimal? PriceEnd)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchProductsByCategoryIdAndPriceRange" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@CategoryId", CategoryId,DbType.Int32);
        	    
            sp.Command.AddParameter("@PriceStart", PriceStart,DbType.Currency);
        	    
            sp.Command.AddParameter("@PriceEnd", PriceEnd,DbType.Currency);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchAllProductsByCategoryId Procedure
        /// </summary>
        public static StoredProcedure FetchAllProductsByCategoryId(int? CategoryId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchAllProductsByCategoryId" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@CategoryId", CategoryId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_ProductSearch Procedure
        /// </summary>
        public static StoredProcedure ProductSearch(string searchTerm)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_ProductSearch" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@searchTerm", searchTerm,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchProductBrowsingLog Procedure
        /// </summary>
        public static StoredProcedure FetchProductBrowsingLog()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchProductBrowsingLog" , DataService.GetInstance("dashCommerceProvider"));
        	
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchBrowsingLogSearchTerms Procedure
        /// </summary>
        public static StoredProcedure FetchBrowsingLogSearchTerms()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchBrowsingLogSearchTerms" , DataService.GetInstance("dashCommerceProvider"));
        	
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchFavoriteCategories Procedure
        /// </summary>
        public static StoredProcedure FetchFavoriteCategories(string UserName, int? BrowsingBehaviorId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchFavoriteCategories" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@UserName", UserName,DbType.String);
        	    
            sp.Command.AddParameter("@BrowsingBehaviorId", BrowsingBehaviorId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchCategoryBrowsingLog Procedure
        /// </summary>
        public static StoredProcedure FetchCategoryBrowsingLog()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchCategoryBrowsingLog" , DataService.GetInstance("dashCommerceProvider"));
        	
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchFavoriteProducts Procedure
        /// </summary>
        public static StoredProcedure FetchFavoriteProducts(string UserName, int? BrowsingBehaviorId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchFavoriteProducts" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@UserName", UserName,DbType.String);
        	    
            sp.Command.AddParameter("@BrowsingBehaviorId", BrowsingBehaviorId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchMostPopularProducts Procedure
        /// </summary>
        public static StoredProcedure FetchMostPopularProducts(int? BrowsingBehviorId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchMostPopularProducts" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@BrowsingBehviorId", BrowsingBehviorId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchAssociatedOrderTransactions Procedure
        /// </summary>
        public static StoredProcedure FetchAssociatedOrderTransactions(int? OrderId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchAssociatedOrderTransactions" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@OrderId", OrderId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchAssociatedOrders Procedure
        /// </summary>
        public static StoredProcedure FetchAssociatedOrders(int? OrderId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchAssociatedOrders" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@OrderId", OrderId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchRefundedOrderItems Procedure
        /// </summary>
        public static StoredProcedure FetchRefundedOrderItems(int? OrderId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchRefundedOrderItems" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@OrderId", OrderId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchAvailableDownloadsByProductId Procedure
        /// </summary>
        public static StoredProcedure FetchAvailableDownloadsByProductId(int? ProductId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchAvailableDownloadsByProductId" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@ProductId", ProductId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchAssociatedDownloadsByProductId Procedure
        /// </summary>
        public static StoredProcedure FetchAssociatedDownloadsByProductId(int? ProductId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchAssociatedDownloadsByProductId" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@ProductId", ProductId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchAssociatedDownloadsByProductIdAndForPurchase Procedure
        /// </summary>
        public static StoredProcedure FetchAssociatedDownloadsByProductIdAndForPurchase(int? ProductId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchAssociatedDownloadsByProductIdAndForPurchase" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@ProductId", ProductId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchAssociatedDownloadsByProductIdAndNotForPurchase Procedure
        /// </summary>
        public static StoredProcedure FetchAssociatedDownloadsByProductIdAndNotForPurchase(int? ProductId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchAssociatedDownloadsByProductIdAndNotForPurchase" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@ProductId", ProductId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Store_FetchPurchasedDownloadsByUserId Procedure
        /// </summary>
        public static StoredProcedure FetchPurchasedDownloadsByUserId(Guid? UserId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Store_FetchPurchasedDownloadsByUserId" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@UserId", UserId,DbType.Guid);
        	    
            return sp;
        }

        
    }

    
}

