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

namespace MettleSystems.dashCommerce.Core{
    public partial class SPs{
        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Core_FetchStateOrRegionByCountryCode Procedure
        /// </summary>
        public static StoredProcedure FetchStateOrRegionByCountryCode(string Code)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Core_FetchStateOrRegionByCountryCode" , DataService.GetInstance("dashCommerceProvider"));
        	
            sp.Command.AddParameter("@Code", Code,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the dashCommerce_Core_DeleteAllLogs Procedure
        /// </summary>
        public static StoredProcedure DeleteAllLogs()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dashCommerce_Core_DeleteAllLogs" , DataService.GetInstance("dashCommerceProvider"));
        	
            return sp;
        }

        
    }

    
}

