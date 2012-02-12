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
    /// Controller class for dashCommerce_Store_VatTaxRate
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class VatTaxRateController
    {
        // Preload our schema..
        VatTaxRate thisSchemaLoad = new VatTaxRate();
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
        public VatTaxRateCollection FetchAll()
        {
            VatTaxRateCollection coll = new VatTaxRateCollection();
            Query qry = new Query(VatTaxRate.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public VatTaxRateCollection FetchByID(object VatTaxRateId)
        {
            VatTaxRateCollection coll = new VatTaxRateCollection().Where("VatTaxRateId", VatTaxRateId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public VatTaxRateCollection FetchByQuery(Query qry)
        {
            VatTaxRateCollection coll = new VatTaxRateCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object VatTaxRateId)
        {
            return (VatTaxRate.Delete(VatTaxRateId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object VatTaxRateId)
        {
            return (VatTaxRate.Destroy(VatTaxRateId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,decimal Rate,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    VatTaxRate item = new VatTaxRate();
		    
            item.Name = Name;
            
            item.Rate = Rate;
            
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
	    public void Update(int VatTaxRateId,string Name,decimal Rate,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    VatTaxRate item = new VatTaxRate();
		    
				item.VatTaxRateId = VatTaxRateId;
				
				item.Name = Name;
				
				item.Rate = Rate;
				
				item.CreatedBy = CreatedBy;
				
				item.CreatedOn = CreatedOn;
				
				item.ModifiedBy = ModifiedBy;
				
				item.ModifiedOn = ModifiedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

