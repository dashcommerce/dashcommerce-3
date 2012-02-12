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
    /// Controller class for dashCommerce_Store_Order
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class OrderController
    {
        // Preload our schema..
        Order thisSchemaLoad = new Order();
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
        public OrderCollection FetchAll()
        {
            OrderCollection coll = new OrderCollection();
            Query qry = new Query(Order.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public OrderCollection FetchByID(object OrderId)
        {
            OrderCollection coll = new OrderCollection().Where("OrderId", OrderId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public OrderCollection FetchByQuery(Query qry)
        {
            OrderCollection coll = new OrderCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object OrderId)
        {
            return (Order.Delete(OrderId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object OrderId)
        {
            return (Order.Destroy(OrderId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(Guid OrderGuid,string OrderNumber,int OrderTypeId,int OrderParentId,int OrderStatusDescriptorId,string UserName,decimal ShippingAmount,string ShippingMethod,decimal HandlingAmount,string BillToAddress,string ShipToAddress,string IPAddress,string PaymentMethod,string ShippingTrackingNumber,string AdditionalProperties,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    Order item = new Order();
		    
            item.OrderGuid = OrderGuid;
            
            item.OrderNumber = OrderNumber;
            
            item.OrderTypeId = OrderTypeId;
            
            item.OrderParentId = OrderParentId;
            
            item.OrderStatusDescriptorId = OrderStatusDescriptorId;
            
            item.UserName = UserName;
            
            item.ShippingAmount = ShippingAmount;
            
            item.ShippingMethod = ShippingMethod;
            
            item.HandlingAmount = HandlingAmount;
            
            item.BillToAddress = BillToAddress;
            
            item.ShipToAddress = ShipToAddress;
            
            item.IPAddress = IPAddress;
            
            item.PaymentMethod = PaymentMethod;
            
            item.ShippingTrackingNumber = ShippingTrackingNumber;
            
            item.AdditionalProperties = AdditionalProperties;
            
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
	    public void Update(int OrderId,Guid OrderGuid,string OrderNumber,int OrderTypeId,int OrderParentId,int OrderStatusDescriptorId,string UserName,decimal ShippingAmount,string ShippingMethod,decimal HandlingAmount,string BillToAddress,string ShipToAddress,string IPAddress,string PaymentMethod,string ShippingTrackingNumber,string AdditionalProperties,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    Order item = new Order();
		    
				item.OrderId = OrderId;
				
				item.OrderGuid = OrderGuid;
				
				item.OrderNumber = OrderNumber;
				
				item.OrderTypeId = OrderTypeId;
				
				item.OrderParentId = OrderParentId;
				
				item.OrderStatusDescriptorId = OrderStatusDescriptorId;
				
				item.UserName = UserName;
				
				item.ShippingAmount = ShippingAmount;
				
				item.ShippingMethod = ShippingMethod;
				
				item.HandlingAmount = HandlingAmount;
				
				item.BillToAddress = BillToAddress;
				
				item.ShipToAddress = ShipToAddress;
				
				item.IPAddress = IPAddress;
				
				item.PaymentMethod = PaymentMethod;
				
				item.ShippingTrackingNumber = ShippingTrackingNumber;
				
				item.AdditionalProperties = AdditionalProperties;
				
				item.CreatedBy = CreatedBy;
				
				item.CreatedOn = CreatedOn;
				
				item.ModifiedBy = ModifiedBy;
				
				item.ModifiedOn = ModifiedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

