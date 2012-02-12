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

namespace MettleSystems.dashCommerce.Core
{
    /// <summary>
    /// Controller class for dashCommerce_Core_Country
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CountryController
    {
        // Preload our schema..
        Country thisSchemaLoad = new Country();
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
        public CountryCollection FetchAll()
        {
            CountryCollection coll = new CountryCollection();
            Query qry = new Query(Country.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CountryCollection FetchByID(object CountryId)
        {
            CountryCollection coll = new CountryCollection().Where("CountryId", CountryId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CountryCollection FetchByQuery(Query qry)
        {
            CountryCollection coll = new CountryCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object CountryId)
        {
            return (Country.Delete(CountryId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object CountryId)
        {
            return (Country.Destroy(CountryId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Code,string Name)
	    {
		    Country item = new Country();
		    
            item.Code = Code;
            
            item.Name = Name;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int CountryId,string Code,string Name)
	    {
		    Country item = new Country();
		    
				item.CountryId = CountryId;
				
				item.Code = Code;
				
				item.Name = Name;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

