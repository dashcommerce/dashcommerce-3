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

namespace MettleSystems.dashCommerce.Content{
    public partial class SPs{
        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Content_FetchRegionsByPageId Procedure
        /// </summary>
        public static StoredProcedure FetchRegionsByPageId(int? PageId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Content_FetchRegionsByPageId" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@PageId", PageId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Content_FetchRegionsByPageIdAndTemplateRegionId Procedure
        /// </summary>
        public static StoredProcedure FetchRegionsByPageIdAndTemplateRegionId(int? PageId, int? TemplateRegionId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Content_FetchRegionsByPageIdAndTemplateRegionId" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@PageId", PageId,DbType.Int32);
        	    
            sp.Command.AddParameter("@TemplateRegionId", TemplateRegionId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Content_JoinRegionToPage Procedure
        /// </summary>
        public static StoredProcedure JoinRegionToPage(int? RegionId, int? PageId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Content_JoinRegionToPage" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@RegionId", RegionId,DbType.Int32);
        	    
            sp.Command.AddParameter("@PageId", PageId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Content_FetchTemplateRegionsByTemplateId Procedure
        /// </summary>
        public static StoredProcedure FetchTemplateRegionsByTemplateId(int? TemplateId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Content_FetchTemplateRegionsByTemplateId" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@TemplateId", TemplateId,DbType.Int32);
        	    
            return sp;
        }

        
    }

    
}

