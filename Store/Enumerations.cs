#region dashCommerce License
/*
The MIT License

Copyright (c) 2008 - 2010 Mettle Systems LLC, P.O. Box 181192 Cleveland Heights, Ohio 44118, United States

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
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