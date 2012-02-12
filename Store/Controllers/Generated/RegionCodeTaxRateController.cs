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
    /// Controller class for dashCommerce_Store_RegionCodeTaxRate
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RegionCodeTaxRateController
    {
        // Preload our schema..
        RegionCodeTaxRate thisSchemaLoad = new RegionCodeTaxRate();
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
        public RegionCodeTaxRateCollection FetchAll()
        {
            RegionCodeTaxRateCollection coll = new RegionCodeTaxRateCollection();
            Query qry = new Query(RegionCodeTaxRate.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RegionCodeTaxRateCollection FetchByID(object RegionCodeTaxRateId)
        {
            RegionCodeTaxRateCollection coll = new RegionCodeTaxRateCollection().Where("RegionCodeTaxRateId", RegionCodeTaxRateId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RegionCodeTaxRateCollection FetchByQuery(Query qry)
        {
            RegionCodeTaxRateCollection coll = new RegionCodeTaxRateCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object RegionCodeTaxRateId)
        {
            return (RegionCodeTaxRate.Delete(RegionCodeTaxRateId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object RegionCodeTaxRateId)
        {
            return (RegionCodeTaxRate.Destroy(RegionCodeTaxRateId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(decimal Rate,string RegionCode,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    RegionCodeTaxRate item = new RegionCodeTaxRate();
		    
            item.Rate = Rate;
            
            item.RegionCode = RegionCode;
            
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
	    public void Update(int RegionCodeTaxRateId,decimal Rate,string RegionCode,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    RegionCodeTaxRate item = new RegionCodeTaxRate();
		    
				item.RegionCodeTaxRateId = RegionCodeTaxRateId;
				
				item.Rate = Rate;
				
				item.RegionCode = RegionCode;
				
				item.CreatedBy = CreatedBy;
				
				item.CreatedOn = CreatedOn;
				
				item.ModifiedBy = ModifiedBy;
				
				item.ModifiedOn = ModifiedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

