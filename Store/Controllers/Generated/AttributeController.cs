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
    /// Controller class for dashCommerce_Store_Attribute
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AttributeController
    {
        // Preload our schema..
        Attribute thisSchemaLoad = new Attribute();
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
        public AttributeCollection FetchAll()
        {
            AttributeCollection coll = new AttributeCollection();
            Query qry = new Query(Attribute.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AttributeCollection FetchByID(object AttributeId)
        {
            AttributeCollection coll = new AttributeCollection().Where("AttributeId", AttributeId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AttributeCollection FetchByQuery(Query qry)
        {
            AttributeCollection coll = new AttributeCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object AttributeId)
        {
            return (Attribute.Delete(AttributeId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object AttributeId)
        {
            return (Attribute.Destroy(AttributeId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int AttributeTypeId,string Name,string Label)
	    {
		    Attribute item = new Attribute();
		    
            item.AttributeTypeId = AttributeTypeId;
            
            item.Name = Name;
            
            item.Label = Label;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int AttributeId,int AttributeTypeId,string Name,string Label)
	    {
		    Attribute item = new Attribute();
		    
				item.AttributeId = AttributeId;
				
				item.AttributeTypeId = AttributeTypeId;
				
				item.Name = Name;
				
				item.Label = Label;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

