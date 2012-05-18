#region dashCommerce License
/*
dashCommerce® is Copyright © 2008-2012 Mettle Systems LLC. All Rights Reserved.


dashCommerce, and the dashCommerce logo are registered trademarks of Mettle Systems LLC. Mettle Systems LLC logos and trademarks may not be used without prior written consent.

dashCommerce is licensed under the following license. If you do not accept the terms, please discontinue the use of dashCommerce and uninstall dashCommerce. 

Your license to the dashCommerce source and/or binaries is governed by the Reciprocal Public License 1.5 (RPL1.5) license as described here: 

http://www.opensource.org/licenses/rpl1.5.txt 

If you do not wish to release the source of software you build using dashCommerce, you may purchase a site license, which will allow you to deploy dashCommerce for use in 1 web store defined as using 1 URL. You may purchase a site license here: 

http://www.dashcommerce.org/license.html 
*/
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Store.Caching;
using MettleSystems.dashCommerce.Store.Services.MessageService;
using MettleSystems.dashCommerce.Store.Services.PaymentService;
using MettleSystems.dashCommerce.Store.Services.ShippingService;
using MettleSystems.dashCommerce.Store.Services.TaxService;
using SubSonic;

namespace MettleSystems.dashCommerce.Store {
  public partial class OrderController {

    #region Constants

    private const string EXCEPTION_TOO_MANY_CARTS = "Cannot have more than one cart.";
    private const string ORDER_REFUNDED = "OrderRefunded";
    private const string ORDER_CHARGED = "OrderCharged";
    private const string SKU = "Sku";
    private const string SYSTEM = "System";
    private const string PAYPAL = "PayPal";
    private const string PAYPAL_STANDARD = "PayPal Standard";
    private const string SUCCESS = "Success";

    #endregion
    
    #region Methods
   
    #region Public

    /// <summary>
    /// Fetches the refunded order items.
    /// </summary>
    /// <param name="orderId">The order id.</param>
    /// <returns></returns>
    public DataSet FetchRefundedOrderItems(int orderId) {
      DataSet ds = SPs.FetchRefundedOrderItems(orderId).GetDataSet();
      return ds;
    }

    /// <summary>
    /// Fetches the associated orders.
    /// </summary>
    /// <param name="orderId">The order id.</param>
    /// <returns></returns>
    public OrderCollection FetchAssociatedOrders(int orderId) {
      IDataReader reader = SPs.FetchAssociatedOrders(orderId).GetReader();
      OrderCollection orderCollection = new OrderCollection();
      orderCollection.LoadAndCloseReader(reader);
      orderCollection.Sort(Order.Columns.CreatedOn, true);
      return orderCollection;
    }

    /// <summary>
    /// Fetches the order item by sku and attributes.
    /// </summary>
    /// <param name="orderId">The order id.</param>
    /// <param name="sku">The sku.</param>
    /// <param name="attributes">The attributes.</param>
    /// <returns></returns>
    public OrderItemCollection FetchOrderItemBySkuAndAttributes(int orderId, string sku, string attributes) {
      Query query = new Query(OrderItem.Schema).
        AddWhere(OrderItem.Columns.OrderId, orderId).
        AddWhere(OrderItem.Columns.Sku, sku).
        AddWhere(OrderItem.Columns.Attributes, attributes);
      OrderItemCollection orderItemCollection = new OrderItemController().FetchByQuery(query);
      return orderItemCollection;
    }

    /// <summary>
    /// Adds the item to order.
    /// </summary>
    /// <param name="userName">Name of the user.</param>
    /// <param name="productId">The product id.</param>
    /// <param name="name">The name.</param>
    /// <param name="sku">The sku.</param>
    /// <param name="quantity">The quantity.</param>
    /// <param name="pricePaid">The price paid.</param>
    /// <param name="weight">The weight.</param>
    /// <param name="attributes">The attributes.</param>
    public void AddItemToOrder(string userName, int productId, string name, string sku, int quantity, decimal pricePaid, decimal itemTax, decimal weight, string attributes, string extendedProperties) {
      int orderId = ProvisionOrder(userName);
      OrderItemCollection orderItemCollection = this.FetchOrderItemBySkuAndAttributes(orderId, sku, attributes);
      if (orderItemCollection.Count == 1) {
        orderItemCollection[0].Quantity += quantity;
        orderItemCollection[0].Save(userName);
      }
      else {
        OrderItem orderItem = new OrderItem();
        orderItem.OrderId = orderId;
        orderItem.ProductId = productId;
        orderItem.Name = name;
        orderItem.Sku = sku;
        orderItem.Quantity = quantity;
        orderItem.PricePaid = pricePaid;
        orderItem.ItemTax = itemTax;
        orderItem.Attributes = attributes;
        orderItem.AdditionalProperties = extendedProperties;
        orderItem.Weight = weight;
        orderItem.Save(userName);
      }
      ResetShippingAndTaxAndDiscount(orderId, userName);
    }

    /// <summary>
    /// Gets the order id.
    /// </summary>
    /// <param name="userName">Name of the user.</param>
    /// <returns></returns>
    public int GetOrderId(string userName) {
      int orderId = 0;
      Query query = new Query(Order.Schema).
        AddWhere(Order.Columns.UserName, userName).
        AddWhere(Order.Columns.OrderStatusDescriptorId, (int)OrderStatus.NotProcessed);
      query.SelectList = Order.Columns.OrderId;
      object result = query.ExecuteScalar();
      if(result != null) {
        int.TryParse(result.ToString(), out orderId);
      }
      return orderId;
    }

    /// <summary>
    /// Fetches the order.
    /// </summary>
    /// <param name="userName">Name of the user.</param>
    /// <returns></returns>
    public Order FetchOrder(string userName) {
      Order order = new Order();
      Query query = new Query(Order.Schema).
        AddWhere(Order.Columns.UserName, userName).
        AddWhere(Order.Columns.OrderStatusDescriptorId, (int)OrderStatus.NotProcessed);
      OrderCollection orderCollection = this.FetchByQuery(query);
      if(orderCollection.Count > 1){
        throw new InvalidOperationException(EXCEPTION_TOO_MANY_CARTS);
      }
      if(orderCollection.Count == 1) {
        order = orderCollection[0];
      }
      return order;
    }
    
    /// <summary>
    /// Fetches the order.
    /// </summary>
    /// <param name="guid">The GUID.</param>
    /// <returns></returns>
    public Order FetchOrder(Guid guid) {
      Order order = new Order();
      Query query = new Query(Order.Schema).AddWhere(Order.Columns.OrderGuid, guid.ToString());
      OrderCollection orderCollection = this.FetchByQuery(query);
      if(orderCollection.Count > 1) {
        throw new InvalidOperationException(EXCEPTION_TOO_MANY_CARTS);
      }
      if(orderCollection.Count == 1) {
        order = orderCollection[0];
      }
      return order;      
    }

    /// <summary>
    /// Fetches the order.
    /// </summary>
    /// <param name="orderId">The order id.</param>
    /// <param name="userName">Name of the user.</param>
    /// <returns></returns>
    public Order FetchOrder(int orderId, string userName) {
      Order order = new Order();
      Query query = new Query(Order.Schema).
        AddWhere(Order.Columns.OrderId, orderId).
        AddWhere(Order.Columns.UserName, userName).
        AddWhere(Order.Columns.OrderStatusDescriptorId, Comparison.NotEquals, (int)OrderStatus.NotProcessed);
      OrderCollection orderCollection = this.FetchByQuery(query);
      if(orderCollection.Count > 1) {
        throw new InvalidOperationException(EXCEPTION_TOO_MANY_CARTS);
      }
      if(orderCollection.Count == 1) {
        order = orderCollection[0];
      }
      return order;
    }

    /// <summary>
    /// Gets the item count in order.
    /// </summary>
    /// <param name="userName">Name of the user.</param>
    /// <returns></returns>
    public int GetItemCountInOrder(string userName) {
      int orderItemCount = 0;
      Order order = FetchOrder(userName);
      orderItemCount = order.OrderItemCollection.Count;
      return orderItemCount;
    }

    /// <summary>
    /// Adjusts the quantity.
    /// </summary>
    /// <param name="orderId">The order id.</param>
    /// <param name="orderItemId">The order item id.</param>
    /// <param name="quantity">The quantity.</param>
    /// <param name="userName">Name of the user.</param>
    public void AdjustQuantity(int orderId, int orderItemId, int quantity, string userName) {
      Query query = new Query(OrderItem.Schema);
      query.AddWhere(OrderItem.Columns.OrderItemId, orderItemId); 
      query.AddUpdateSetting(OrderItem.Columns.Quantity, quantity);
      query.AddUpdateSetting(OrderItem.Columns.ModifiedOn, DateTime.UtcNow.ToString());
      query.AddUpdateSetting(OrderItem.Columns.ModifiedBy, userName);
      query.Execute();
      ResetShippingAndTaxAndDiscount(orderId, userName);
    }

    /// <summary>
    /// Removes the item.
    /// </summary>
    /// <param name="orderId">The order id.</param>
    /// <param name="orderItemId">The order item id.</param>
    /// <param name="userName">Name of the user.</param>
    public void RemoveItem(int orderId, int orderItemId, string userName) {
      Query query = new Query(OrderItem.Schema);
      query.QueryType = QueryType.Delete;
      query.AddWhere(OrderItem.Columns.OrderItemId, orderItemId);
      query.Execute();
      ResetShippingAndTaxAndDiscount(orderId, userName);
    }
    
    /// <summary>
    /// Fetches the orders for user.
    /// </summary>
    /// <param name="userName">Name of the user.</param>
    /// <returns></returns>
    public OrderCollection FetchOrdersForUser(string userName) {
      IDataReader reader = new Query(Order.Schema).
        AddWhere(Order.Columns.UserName, Comparison.Equals, userName).
        AddWhere(Order.Columns.OrderStatusDescriptorId, Comparison.NotEquals, (int)OrderStatus.NotProcessed).
        ExecuteReader();
      OrderCollection orderCollection = new OrderCollection();
      orderCollection.LoadAndCloseReader(reader);
      return orderCollection;
    }
    
    #endregion

    #region Static Methods

    /// <summary>
    /// Refunds the specified transaction.
    /// </summary>
    /// <param name="transaction">The transaction.</param>
    /// <param name="refundedOrder">The order the refund should be applied to.</param>
    /// <param name="userName">Name of the user.</param>
    public static void Refund(Transaction transaction, Order refundedOrder, string userName) {
      Order order = new Order(transaction.OrderId);
      PaymentService paymentService = new PaymentService();
      Transaction refundTransaction = paymentService.Refund(transaction, refundedOrder);
      refundedOrder.Save(userName);
      //set the orderid for the refund
      foreach(OrderItem orderItem in refundedOrder.OrderItemCollection) {
        orderItem.OrderId = refundedOrder.OrderId;
      }
      refundedOrder.OrderItemCollection.SaveAll(userName);
      //set the orderId to the refunded orderId
      refundTransaction.OrderId = refundedOrder.OrderId;      
      refundTransaction.Save(userName);
      Guid userGuid = new Guid(Membership.GetUser(order.UserName).ProviderUserKey.ToString());
      foreach(OrderItem orderItem in refundedOrder.OrderItemCollection) {
        new Product(orderItem.ProductId);
        //put the stock back
        Sku sku = new Sku(Sku.Columns.SkuX, orderItem.Sku);
        sku.Inventory = sku.Inventory + orderItem.Quantity;
        sku.Save(userName);
        ProductCache.RemoveSKUFromCache(orderItem.Sku);
        //remove the access control
        DownloadCollection downloadCollection = new ProductController().FetchAssociatedDownloadsByProductIdAndForPurchase(orderItem.ProductId);
        if (downloadCollection.Count > 0) {
          foreach (Download download in downloadCollection) {
            new DownloadAccessControlController().Delete(userGuid, download.DownloadId);
          }
        }
      }
      if(refundedOrder.Total == order.Total) {
        order.OrderStatusDescriptorId = (int)OrderStatus.OrderFullyRefunded;
      }
      else {
        order.OrderStatusDescriptorId = (int)OrderStatus.OrderPartiallyRefunded;
      }
      order.Save(userName);
      //Add an OrderNote
      OrderNote orderNote = new OrderNote();
      orderNote.OrderId = order.OrderId;
      orderNote.Note = Strings.ResourceManager.GetString(ORDER_REFUNDED);
      orderNote.Save(userName);
      //send off the notifications
      MessageService messageService = new MessageService();
      messageService.SendOrderRefundToCustomer(refundedOrder);
    }

    /// <summary>
    /// Refunds the specified transaction.
    /// </summary>
    /// <param name="transaction">The transaction.</param>
    /// <param name="refundedOrder">The refunded order.</param>
    /// <param name="userName">Name of the user.</param>
    public static void RefundStandard(Transaction transaction, Order refundedOrder, string userName) {
      Order order = new Order(transaction.OrderId);
      Transaction refundTransaction = new Transaction();
      //refundTransaction.OrderId = transaction.OrderId;
      refundTransaction.TransactionTypeDescriptorId = (int)TransactionType.Refund;
      refundTransaction.PaymentMethod = PAYPAL;
      refundTransaction.GatewayName = PAYPAL_STANDARD;
      refundTransaction.GatewayResponse = SUCCESS;
      refundTransaction.GatewayTransactionId = CoreUtility.GenerateRandomString(16);
      refundTransaction.GrossAmount = refundedOrder.Total;
      refundTransaction.NetAmount = 0.00M;
      refundTransaction.FeeAmount = 0.00M;
      refundTransaction.TransactionDate = DateTime.Now;
      //refundTransaction.Save(userName);
      refundedOrder.Save(userName);

      //set the orderid for the refund
      foreach(OrderItem orderItem in refundedOrder.OrderItemCollection) {
        orderItem.OrderId = refundedOrder.OrderId;
      }
      refundedOrder.OrderItemCollection.SaveAll(userName);
      //set the orderId to the refunded orderId
      refundTransaction.OrderId = refundedOrder.OrderId;
      refundTransaction.Save(userName);
      Guid userGuid = new Guid(Membership.GetUser(order.UserName).ProviderUserKey.ToString());
      DownloadCollection downloadCollection;
      foreach(OrderItem orderItem in refundedOrder.OrderItemCollection) {
        //put the stock back
        Sku sku = new Sku(Sku.Columns.SkuX, orderItem.Sku);
        sku.Inventory = sku.Inventory + orderItem.Quantity;
        sku.Save(userName);
        ProductCache.RemoveSKUFromCache(orderItem.Sku);
        //remove the access control
        downloadCollection = new ProductController().FetchAssociatedDownloadsByProductIdAndForPurchase(orderItem.ProductId);
        if (downloadCollection.Count > 0) {
          foreach (Download download in downloadCollection) {
            new DownloadAccessControlController().Delete(userGuid, download.DownloadId);
          }
        }

      }
      if(refundedOrder.Total == order.Total) {
        order.OrderStatusDescriptorId = (int)OrderStatus.OrderFullyRefunded;
      }
      else {
        order.OrderStatusDescriptorId = (int)OrderStatus.OrderPartiallyRefunded;
      }
      order.Save(userName);
      //Add an OrderNote
      OrderNote orderNote = new OrderNote();
      orderNote.OrderId = order.OrderId;
      orderNote.Note = Strings.ResourceManager.GetString(ORDER_REFUNDED);
      orderNote.Save(userName);
      //send off the notifications
      MessageService messageService = new MessageService();
      messageService.SendOrderRefundToCustomer(refundedOrder);
    }


    /// <summary>
    /// Authorizes this instance.
    /// </summary>
    /// <returns></returns>
    public static Transaction Authorize() {
      throw new NotImplementedException("Not implemented");
    }

    /// <summary>
    /// Charges the specified order.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <param name="userName">Name of the user.</param>
    /// <returns></returns>
    public static Transaction Charge(Order order, string userName) {
      //update the order with IP
      order.IPAddress = HttpContext.Current.Request.UserHostAddress == "::1" || HttpContext.Current.Request.UserHostAddress == "127.0.0.1" ? "127.0.0.1" : HttpContext.Current.Request.UserHostAddress;
      PaymentService paymentService = new PaymentService();
      Transaction transaction = paymentService.Charge(order);
      order.OrderStatusDescriptorId = (int)OrderStatus.ReceivedPaymentProcessingOrder;
      order.OrderTypeId = (int)OrderType.Purchase;
      order.Save(userName);
      Guid userGuid = new Guid(Membership.GetUser(userName).ProviderUserKey.ToString());
      try {
        //Add an OrderNote
        OrderNote orderNote = new OrderNote();
        orderNote.OrderId = order.OrderId;
        orderNote.Note = Strings.ResourceManager.GetString(ORDER_CHARGED);
        orderNote.Save(userName);
        Sku sku;
        DownloadCollection downloadCollection;
        DownloadAccessControlCollection downloadAccessControlCollection;
        DownloadAccessControl downloadAccessControl;
        foreach (OrderItem orderItem in order.OrderItemCollection) {
          //Adjust the Inventory
          sku = new Sku(SKU, orderItem.Sku);
          sku.Inventory = sku.Inventory - orderItem.Quantity;
          sku.Save(SYSTEM);
          ProductCache.RemoveSKUFromCache(orderItem.Sku);
          //Add access control for orderitems
          downloadCollection = new ProductController().FetchAssociatedDownloadsByProductIdAndForPurchase(orderItem.ProductId);
          if (downloadCollection.Count > 0) {
            foreach (Download download in downloadCollection) {
              Query query = new Query(DownloadAccessControl.Schema).
                AddWhere(DownloadAccessControl.Columns.UserId, Comparison.Equals, userGuid).
                AddWhere(DownloadAccessControl.Columns.DownloadId, Comparison.Equals, download.DownloadId);
              downloadAccessControlCollection = new DownloadAccessControlController().FetchByQuery(query);
              if (downloadAccessControlCollection.Count == 0) {
                downloadAccessControl = new DownloadAccessControl();
                downloadAccessControl.DownloadId = download.DownloadId;
                downloadAccessControl.UserId = userGuid;
                downloadAccessControl.Save(SYSTEM);
              }
            }
          }
        }

        //Send out the messages
        //Send these last in case something happens with the email
        MessageService messageService = new MessageService();
        messageService.SendOrderReceivedNotificationToCustomer(order);
        messageService.SendOrderReceivedNotificationToMerchant(order);
      }
      catch (Exception ex) {
        //swallow the exception here because the transaction is saved
        //and, while this is an inconvenience, it's not critical
        Logger.Error(typeof(OrderController).Name + ".Charge", ex);
      }
      return transaction;
    }

    /// <summary>
    /// Fetches the shipping options.
    /// </summary>
    /// <param name="userName">Name of the user.</param>
    /// <returns></returns>
    public static ShippingOptionCollection FetchShippingOptions(string userName) {
      Order order = new OrderController().FetchOrder(userName);
      ShippingService shippingService = new ShippingService();
      ShippingOptionCollection shippingOptionCollection = shippingService.GetShippingOptions(order);
      return shippingOptionCollection;
    }

    /// <summary>
    /// Fetches the shipping options.
    /// </summary>
    /// <param name="order">The Order</param>
    /// <returns></returns>
    public static ShippingOptionCollection FetchShippingOptions(Order order) {
      ShippingService shippingService = new ShippingService();
      ShippingOptionCollection shippingOptionCollection = shippingService.GetShippingOptions(order);
      return shippingOptionCollection;
    }

    /// <summary>
    /// Calculates the tax.
    /// </summary>
    /// <param name="userName">Name of the user.</param>
    public static void CalculateTax(string userName) {
      Order order = new OrderController().FetchOrder(userName);
      TaxService taxService = new TaxService();
      taxService.GetTaxRate(order);
      foreach(OrderItem orderItem in order.OrderItemCollection) {
        orderItem.Save(userName);
      }
      order.Save(userName);
    }

    /// <summary>
    /// Sets the shipping.
    /// </summary>
    /// <param name="userName">Name of the user.</param>
    /// <param name="shippingAmount">The shipping amount.</param>
    /// <param name="shippingMethod">The shipping method.</param>
    public static void SetShipping(string userName, decimal shippingAmount, string shippingMethod) {
      Order order = new OrderController().FetchOrder(userName);
      order.ShippingAmount = shippingAmount;
      order.ShippingMethod = shippingMethod;
      order.Save(userName);
    }

    /// <summary>
    /// Sets the express checkout.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <param name="returnUrl">The return URL.</param>
    /// <param name="cancelUrl">The cancel URL.</param>
    /// <param name="authorizeOnly">if set to <c>true</c> [authorize only].</param>
    /// <returns></returns>
    public static string SetExpressCheckout(Order order, string returnUrl, string cancelUrl, bool authorizeOnly) {
      PaymentService paymentService = new PaymentService();
      string token = paymentService.SetExpressCheckout(order, returnUrl, cancelUrl, authorizeOnly);
      return token;
    }

    /// <summary>
    /// Gets the express checkout.
    /// </summary>
    /// <param name="token">The token.</param>
    /// <returns></returns>
    public static PayPalPayer GetExpressCheckout(string token) {
      PaymentService paymentService = new PaymentService();
      PayPalPayer payPalPayer = paymentService.GetExpressCheckoutDetails(token);
      return payPalPayer;
    }

    /// <summary>
    /// Does the express checkout.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <param name="authorizeOnly">if set to <c>true</c> [authorize only].</param>
    /// <param name="userName">Name of the user.</param>
    /// <returns></returns>
    public static Transaction DoExpressCheckout(Order order, bool authorizeOnly, string userName) {
      PaymentService paymentService = new PaymentService();
      Transaction transaction = paymentService.DoExpressCheckout(order, authorizeOnly);
      order.OrderStatusDescriptorId = (int)OrderStatus.ReceivedPaymentProcessingOrder;
      order.Save(userName);

      try {
        //Adjust the Inventory
        Sku sku;
        foreach (OrderItem orderItem in order.OrderItemCollection) {
          sku = new Sku(SKU, orderItem.Sku);
          sku.Inventory = sku.Inventory - orderItem.Quantity;
          sku.Save(SYSTEM);
          ProductCache.RemoveSKUFromCache(orderItem.Sku);
        }
        //Send out the messages
        MessageService messageService = new MessageService();
        messageService.SendOrderReceivedNotificationToCustomer(order);
        messageService.SendOrderReceivedNotificationToMerchant(order);
      }
      catch (Exception ex) {
        //swallow the exception here because the transaction is saved
        //and, while this is an inconvenience, it's not critical
        Logger.Error(typeof(OrderController).Name + ".DoExpressCheckout", ex);
      }
      return transaction;
    }

    /// <summary>
    /// Creates the cart URL.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <param name="returnUrl">The return URL.</param>
    /// <param name="cancelUrl">The cancel URL.</param>
    /// <returns></returns>
    public static string CreateCartUrl(Order order, string returnUrl, string cancelUrl, string notifyUrl) {
      PaymentService paymentService = new PaymentService();
      string url = paymentService.CreateCartUrl(order, returnUrl, cancelUrl, notifyUrl);
      return url;
    }

    /// <summary>
    /// Synchronizes the specified args.
    /// </summary>
    /// <param name="args">The args.</param>
    /// <returns></returns>
    public static string Synchronize(params object[] args) {
      PaymentService paymentService = new PaymentService();
      string content = string.Format("&cmd=_notify-synch&tx={0}&at=", args[0]);
      string response = paymentService.Synchronize(content);
      return response;
    }

    /// <summary>
    /// Verifies the specified args.
    /// </summary>
    /// <param name="args">The args.</param>
    /// <returns></returns>
    public static string Verify(params object[] args) {
      PaymentService paymentService = new PaymentService();
      string content = string.Format("{0}&cmd=_notify-validate", args[0]);
      Logger.Information(string.Format("{0}::{1}", "VERIFY", content));
      string response = paymentService.Synchronize(content);
      return response;
    }

    /// <summary>
    /// Commits the standard transaction.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <param name="transactionId">The transaction id.</param>
    /// <param name="grossAmount">The gross amount.</param>
    /// <returns></returns>
    public static Transaction CommitStandardTransaction(Order order, string transactionId, decimal grossAmount) {
      order.OrderStatusDescriptorId = (int)OrderStatus.ReceivedPaymentProcessingOrder;
      order.Save(SYSTEM);
      Transaction transaction = new Transaction();
      transaction.OrderId = order.OrderId;
      transaction.TransactionTypeDescriptorId = (int)TransactionType.Charge;
      transaction.PaymentMethod = PAYPAL;
      transaction.GatewayName = PAYPAL_STANDARD;
      transaction.GatewayResponse = SUCCESS;
      transaction.GatewayTransactionId = transactionId;
      transaction.GrossAmount = grossAmount;
      transaction.TransactionDate = DateTime.UtcNow;
      transaction.Save(SYSTEM);

      try {
        //Adjust the Inventory
        Sku sku;
        foreach (OrderItem orderItem in order.OrderItemCollection) {
          sku = new Sku("Sku", orderItem.Sku);
          sku.Inventory = sku.Inventory - orderItem.Quantity;
          sku.Save("System");
          ProductCache.RemoveSKUFromCache(orderItem.Sku);
        }
        //Send out the messages
        MessageService messageService = new MessageService();
        messageService.SendOrderReceivedNotificationToCustomer(order);
        messageService.SendOrderReceivedNotificationToMerchant(order);
      }
      catch (Exception ex) {
        //swallow the exception here because the transaction is saved
        //and, while this is an inconvenience, it's not critical
        Logger.Error(typeof(OrderController).Name + ".CommitStandardTransaction", ex);
      }
      return transaction;
    }

    /// <summary>
    /// Migrates the cart.
    /// </summary>
    /// <param name="anonymousCartId">The anonymous cart id.</param>
    /// <param name="registeredCartId">The registered cart id.</param>
    public static void MigrateCart(string anonymousCartId, string registeredCartId) {
      Order anonymousOrder = new OrderController().FetchOrder(anonymousCartId);
      Order registeredOrder = new OrderController().FetchOrder(registeredCartId);

      //first see if there is an order for the now-recognized user
      if (string.IsNullOrEmpty(registeredOrder.OrderNumber) && !string.IsNullOrEmpty(anonymousOrder.OrderNumber)) {
        //if not, just update the old order with the new user's username
        anonymousOrder.UserName = registeredCartId;
        anonymousOrder.Save(registeredCartId);
      }
      else {
        //the logged-in user has an existing basket. 
        //if there is no basket from their anon session, 
        //we don't need to do anything
        if (!string.IsNullOrEmpty(anonymousOrder.OrderNumber)) {

          //in this case, there is an order (cart) from their anon session
          //and an order that they had open from their last session
          //need to marry the items.

          //this part is up to your business needs - some merchants
          //will want to replace the cart contents
          //others will want to synch them. We're going to assume that
          //this scenario will synch the existing items.

          //############### Synch the Cart Items
          if (registeredOrder.OrderItemCollection.Count > 0 && anonymousOrder.OrderItemCollection.Count > 0) {
            //there are items in both carts, move the old to the new
            //when synching, find matching items in both carts
            //update the quantities of the matching items in the logged-in cart
            //removing them from the anon cart

            //a switch to tell us if we need to update the from orders


            //1.) Find items that are the same between the two carts and add the anon quantity to the registered user quantity
            //2.) Mark found items as items to be removed from the anon cart.
            ArrayList toBeRemoved = new ArrayList(anonymousOrder.OrderItemCollection.Count);
            for (int i = 0; i < anonymousOrder.OrderItemCollection.Count; i++) {
              OrderItem foundItem = registeredOrder.OrderItemCollection.Find(delegate(OrderItem orderItemToFind) {
                                      return (orderItemToFind.Sku == anonymousOrder.OrderItemCollection[i].Sku) && (orderItemToFind.Attributes == anonymousOrder.OrderItemCollection[i].Attributes);
                                    });
              if (foundItem != null) {
                foundItem.Quantity += anonymousOrder.OrderItemCollection[i].Quantity;
                toBeRemoved.Add(i);
              }
            }
            //3.) Now remove any foundItems from the anon cart, but trim it up first
            toBeRemoved.TrimToSize();
            for (int i = 0; i < toBeRemoved.Count; i++) {
              anonymousOrder.OrderItemCollection.RemoveAt((int)toBeRemoved[i]);
            }

            //4.) Move over to the registered user cart any remaining items in the anon cart.
            foreach (OrderItem anonItem in anonymousOrder.OrderItemCollection) {
              //reset the orderID
              anonItem.OrderId = registeredOrder.OrderId;
              registeredOrder.OrderItemCollection.Add(anonItem);
            }

            //5.) Finally, save it down to the DB
            // (Since we know toOrder.Items.Count > 0 && fromOrder.Items.Count > 0, we know a Save needs to occur)
            registeredOrder.OrderItemCollection.SaveAll(registeredCartId);
            registeredOrder.Save(registeredCartId);
          }
          else if (registeredOrder.OrderItemCollection.Count == 0) {
            //items exist only in the anon cart
            //move the anon items to the new cart
            //then save the order and the order items.
            registeredOrder.IsNew = true;
            registeredOrder.OrderStatusDescriptorId = anonymousOrder.OrderStatusDescriptorId;
            registeredOrder.OrderGuid = anonymousOrder.OrderGuid;
            registeredOrder.UserName = registeredCartId;
            registeredOrder.OrderNumber = anonymousOrder.OrderNumber;
            registeredOrder.Save(registeredCartId);
            foreach (OrderItem item in anonymousOrder.OrderItemCollection) {
              //reset the orderID on each item
              item.OrderId = registeredOrder.OrderId;
              registeredOrder.OrderItemCollection.Add(item);
            }
            registeredOrder.OrderItemCollection.SaveAll(registeredCartId);
            registeredOrder.Save(registeredCartId);
          }
          else if (anonymousOrder.OrderItemCollection.Count == 0) {
            //no items in the old cart, do nothing
          }

          //finally, drop the anon order from the DB, we don't want to 
          //keep it
          OrderItem.Delete(OrderItem.Columns.OrderId, anonymousOrder.OrderId);
          Order.Delete(anonymousOrder.OrderId);
        }
      }
  
    }

    /// <summary>
    /// Normalizes the cart quantities.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <returns></returns>
    public static bool NormalizeCartQuantities(Order order) {
      bool changesMade = false;
      if (order.OrderId > 0) {
        List<OrderItem> itemsToRemove = new List<OrderItem>();
        foreach (OrderItem item in order.OrderItemCollection) {
          Product product = Product.FetchByID(item.ProductId);
          if (!product.AllowNegativeInventories) {
            SkuCollection skuCollection = new SkuCollection().Where(Sku.Columns.SkuX, SubSonic.Comparison.Equals, item.Sku).Load();
            if (skuCollection != null) {
              if (skuCollection.Count == 0 || skuCollection[0].Inventory == 0 || product.ProductStatusDescriptorId == (int)ProductStatus.Inactive) {
                itemsToRemove.Add(item);
                changesMade = true;
              }
              else if (item.Quantity > skuCollection[0].Inventory) {
                item.Quantity = skuCollection[0].Inventory;
                new OrderController().AdjustQuantity(order.OrderId, item.OrderItemId, item.Quantity, order.UserName);
                changesMade = true;
              }
            }
          }
        }
        foreach (OrderItem item in itemsToRemove) {
          new OrderController().RemoveItem(order.OrderId, item.OrderItemId, order.UserName);
          order.OrderItemCollection.Remove(item);
        }
        if (order.OrderItemCollection.Count == 0) {
          Order.Delete(order.OrderId);
        }
      }
      return changesMade;
    } 
    
    #region Private

    /// <summary>
    /// Resets the shipping and tax and discount.
    /// </summary>
    /// <param name="orderId">The order id.</param>
    /// <param name="userName">Name of the user.</param>
    private static void ResetShippingAndTaxAndDiscount(int orderId, string userName) {
      //Clear Shipping and Tax and Discount if in there
      Order order = new Order(orderId);
      if(order.OrderId > 0) {
        order.ShippingAmount = 0;
        order.ShippingMethod = string.Empty;
        foreach(OrderItem orderItem in order.OrderItemCollection) {
          orderItem.ItemTax = 0;
          orderItem.DiscountAmount = 0;
          orderItem.Save(userName);
        }
        order.Save(userName);
      }
    }
    
    /// <summary>
    /// Provisions the order.
    /// </summary>
    /// <param name="userName">Name of the user.</param>
    /// <returns></returns>
    private int ProvisionOrder(string userName) {
      int orderId = GetOrderId(userName);
      if(orderId == 0) {
        Order order = new Order();
        order.OrderGuid = Guid.NewGuid();
        //order.OrderNumber = CoreUtility.GenerateRandomString(ORDER_NUMBER_LENGTH);
        order.OrderNumber = CoreUtility.Generate4By4MaskedString();
        order.OrderStatusDescriptorId = (int)OrderStatus.NotProcessed;
        order.UserName = userName;
        order.IPAddress = HttpContext.Current.Request.UserHostAddress == "::1" || HttpContext.Current.Request.UserHostAddress == "127.0.0.1" ? "127.0.0.1" : HttpContext.Current.Request.UserHostAddress;
        order.Save(userName);
        orderId = order.OrderId;
      }
      return orderId;
    }
    
    #endregion

    #endregion
    
    #endregion
    
  }
}
