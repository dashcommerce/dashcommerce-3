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

namespace MettleSystems.dashCommerce.Store {

  public enum OrderType : int {
    Purchase = 1,
    Refund = 2
  }

  //NOTE: The intent of TransactionType needs to be kept in sync with the Ids 
  //in dashCommerce_Store_TransactionTypeDescriptor - dashCommerce_Store_TransactionTypeDescriptor 
  //may hold localized values for reports, display grids, etc.
  public enum TransactionType : int {
    Authorization = 1,
    Charge = 2,
    Refund = 3
  }

  //NOTE: The intent of ProductStatus needs to be kept in sync with the Ids 
  //in dashCommerce_Store_Status - dashCommerce_Store_Status 
  //may hold localized values for reports, display grids, etc.
  public enum ProductStatus : int {
    Active = 1,
    Inactive = 99
  }

  //NOTE: The intent of SystemNotifications needs to be kept in sync with the Ids 
  //in dashCommerce_Store_Notifications - dashCommerce_Store_Notifications 
  //may hold localized values for reports, display grids, etc.
  public enum SystemNotifications : int {
    OrderReceivedToMerchant = 1,
    OrderReceivedToCustomer = 2,
    ShippingNotificationToCustomer = 3,
    OrderCancellationToCustomer = 4,
    OrderRefundToCustomer = 5
  }
  
  //NOTE: The intent of OrderStatus needs to be kept in sync with the Ids 
  //in dashCommerce_Store_OrderStatusDescriptor - dashCommerce_Store_OrderStatusDescriptor 
  //may hold localized values for reports, display grids, etc.
  public enum OrderStatus : int {
    ReceivedPaymentProcessingOrder = 100,
    GatheringItemsFromInventory = 200,
    PartialShipment = 300,
    CompleteShipment = 400,
    OrderFullyRefunded = 500,
    OrderPartiallyRefunded = 600,
    NotProcessed = 9999
  }

  public enum BrowsingBehaviour : int {
    Browsing_Category = 1,
    Browsing_Product = 2,
    Clicking_On_Ad = 3,
    Clicking_On_Crosssell = 4,
    Search = 5,
    Adding_Item_To_Basket = 6,
    Checking_Out = 7,
    Paying = 8,
    Viewing_Receipt = 9,
    Removing_Item_From_Basket = 10,
    Adjusting_Quantity = 11,
    Logging_In = 12,
    Logging_Out = 13
  }

  public enum ProviderType {
    PaymentProvider = 1,
    TaxProvider,
    ShippingProvider,
    CouponProvider
  }

  public enum CreditCardType {
    MasterCard,
    VISA,
    Amex,
    Discover,
    PayPal,
    Maestro,
    Solo
  }

  public enum AddressType : int {
    BillingAddress = 1,
    ShippingAddress = 2
  }
  
  public enum CatalogSortBy {
    None = 0,
    PriceAscending = 1,
    PriceDescending = 2,
    DateCreatedAscending = 3,
    DateCreatedDescending = 4,
    DateUpdatedAscending = 5,
    DateUpdatedDescending = 6,
    TitleAscending = 7,
    TitleDescending = 8
  }
}