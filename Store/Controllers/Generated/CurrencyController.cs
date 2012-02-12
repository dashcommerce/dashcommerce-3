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
    /// Controller class for dashCommerce_Store_Currency
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CurrencyController
    {
        // Preload our schema..
        Currency thisSchemaLoad = new Currency();
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
        public CurrencyCollection FetchAll()
        {
            CurrencyCollection coll = new CurrencyCollection();
            Query qry = new Query(Currency.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CurrencyCollection FetchByID(object CodeID)
        {
            CurrencyCollection coll = new CurrencyCollection().Where("codeID", CodeID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CurrencyCollection FetchByQuery(Query qry)
        {
            CurrencyCollection coll = new CurrencyCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object CodeID)
        {
            return (Currency.Delete(CodeID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object CodeID)
        {
            return (Currency.Destroy(CodeID) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Code,string Description)
	    {
		    Currency item = new Currency();
		    
            item.Code = Code;
            
            item.Description = Description;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int CodeID,string Code,string Description)
	    {
		    Currency item = new Currency();
		    
				item.CodeID = CodeID;
				
				item.Code = Code;
				
				item.Description = Description;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

