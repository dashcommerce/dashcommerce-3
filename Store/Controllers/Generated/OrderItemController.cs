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
    /// Controller class for dashCommerce_Store_OrderItem
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class OrderItemController
    {
        // Preload our schema..
        OrderItem thisSchemaLoad = new OrderItem();
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
        public OrderItemCollection FetchAll()
        {
            OrderItemCollection coll = new OrderItemCollection();
            Query qry = new Query(OrderItem.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public OrderItemCollection FetchByID(object OrderItemId)
        {
            OrderItemCollection coll = new OrderItemCollection().Where("OrderItemId", OrderItemId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public OrderItemCollection FetchByQuery(Query qry)
        {
            OrderItemCollection coll = new OrderItemCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object OrderItemId)
        {
            return (OrderItem.Delete(OrderItemId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object OrderItemId)
        {
            return (OrderItem.Destroy(OrderItemId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int OrderId,int ProductId,string Name,string Sku,int Quantity,decimal PricePaid,string Attributes,string AdditionalProperties,decimal Weight,decimal ItemTax,decimal DiscountAmount,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    OrderItem item = new OrderItem();
		    
            item.OrderId = OrderId;
            
            item.ProductId = ProductId;
            
            item.Name = Name;
            
            item.Sku = Sku;
            
            item.Quantity = Quantity;
            
            item.PricePaid = PricePaid;
            
            item.Attributes = Attributes;
            
            item.AdditionalProperties = AdditionalProperties;
            
            item.Weight = Weight;
            
            item.ItemTax = ItemTax;
            
            item.DiscountAmount = DiscountAmount;
            
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
	    public void Update(int OrderItemId,int OrderId,int ProductId,string Name,string Sku,int Quantity,decimal PricePaid,string Attributes,string AdditionalProperties,decimal Weight,decimal ItemTax,decimal DiscountAmount,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    OrderItem item = new OrderItem();
		    
				item.OrderItemId = OrderItemId;
				
				item.OrderId = OrderId;
				
				item.ProductId = ProductId;
				
				item.Name = Name;
				
				item.Sku = Sku;
				
				item.Quantity = Quantity;
				
				item.PricePaid = PricePaid;
				
				item.Attributes = Attributes;
				
				item.AdditionalProperties = AdditionalProperties;
				
				item.Weight = Weight;
				
				item.ItemTax = ItemTax;
				
				item.DiscountAmount = DiscountAmount;
				
				item.CreatedBy = CreatedBy;
				
				item.CreatedOn = CreatedOn;
				
				item.ModifiedBy = ModifiedBy;
				
				item.ModifiedOn = ModifiedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

