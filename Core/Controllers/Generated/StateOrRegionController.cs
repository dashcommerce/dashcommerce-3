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
    /// Controller class for dashCommerce_Core_StateOrRegion
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class StateOrRegionController
    {
        // Preload our schema..
        StateOrRegion thisSchemaLoad = new StateOrRegion();
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
        public StateOrRegionCollection FetchAll()
        {
            StateOrRegionCollection coll = new StateOrRegionCollection();
            Query qry = new Query(StateOrRegion.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public StateOrRegionCollection FetchByID(object StateOrRegionId)
        {
            StateOrRegionCollection coll = new StateOrRegionCollection().Where("StateOrRegionId", StateOrRegionId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public StateOrRegionCollection FetchByQuery(Query qry)
        {
            StateOrRegionCollection coll = new StateOrRegionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object StateOrRegionId)
        {
            return (StateOrRegion.Delete(StateOrRegionId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object StateOrRegionId)
        {
            return (StateOrRegion.Destroy(StateOrRegionId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int CountryId,string Name,string Abbreviation)
	    {
		    StateOrRegion item = new StateOrRegion();
		    
            item.CountryId = CountryId;
            
            item.Name = Name;
            
            item.Abbreviation = Abbreviation;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int StateOrRegionId,int CountryId,string Name,string Abbreviation)
	    {
		    StateOrRegion item = new StateOrRegion();
		    
				item.StateOrRegionId = StateOrRegionId;
				
				item.CountryId = CountryId;
				
				item.Name = Name;
				
				item.Abbreviation = Abbreviation;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

