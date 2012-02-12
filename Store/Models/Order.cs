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
using System;
using System.Text;

using System.Web;
using MettleSystems.dashCommerce.Core;

namespace MettleSystems.dashCommerce.Store {

  public partial class Order {
  
    #region Member Variables

    private OrderItemCollection _orderItemCollection;
    private Address _billingAddress;
    private Address _shippingAddress;
    private TransactionCollection _transactionCollection;
    private ExtendedProperties _extendedProperties;
    
    
    #endregion
    
    #region Constructors
    
    public Order (Order order, string userName) {
      this.OrderId = 0;
      this.OrderGuid = Guid.NewGuid();
      this.OrderNumber = order.OrderNumber;
      this.OrderTypeId = (int)OrderType.Refund;
      this.OrderParentId = order.OrderId;
      this.OrderStatusDescriptorId = (int)OrderStatus.OrderPartiallyRefunded;
      this.UserName = order.UserName;
      this.ShippingAmount = 0;
      this.ShippingMethod = string.Empty;
      this.HandlingAmount = 0;
      this.BillToAddress = order.BillToAddress;
      this.ShipToAddress = order.ShipToAddress;
      this.IPAddress = HttpContext.Current.Request.UserHostAddress;
      this.PaymentMethod = order.PaymentMethod;
      this.ShippingTrackingNumber = string.Empty;
      this.AdditionalProperties = order.AdditionalProperties;
      this.CreatedBy = userName;
      this.CreatedOn = DateTime.UtcNow;
      this.ModifiedBy = userName;
      this.ModifiedOn = DateTime.UtcNow;
    }
    
    #endregion
    
    #region Properties

    /// <summary>
    /// Gets the order item collection.
    /// </summary>
    /// <value>The order item collection.</value>
    public OrderItemCollection OrderItemCollection {
      get {
        if(_orderItemCollection == null) {
          _orderItemCollection = this.OrderItemRecords();
        }
        return _orderItemCollection;
      }
    }

    /// <summary>
    /// Gets the transaction collection.
    /// </summary>
    /// <value>The transaction collection.</value>
    public TransactionCollection TransactionCollection {
      get {
        if(_transactionCollection == null) {
          _transactionCollection = this.TransactionRecords();
        }
        return _transactionCollection;
      }
    }

    /// <summary>
    /// Gets the sub total.
    /// </summary>
    /// <value>The sub total.</value>
    public decimal SubTotal {
      get {
        decimal _subTotal = 0;
        foreach(OrderItem orderItem in this.OrderItemCollection) {
          _subTotal += (orderItem.ExtendedPrice);
        }
        return _subTotal;
      }
    }

    /// <summary>
    /// Gets the tax total.
    /// </summary>
    /// <value>The tax total.</value>
    public decimal TaxTotal {
      get {
        decimal _taxTotal = 0;
        foreach(OrderItem orderItem in this.OrderItemCollection) {
          _taxTotal += orderItem.TotalItemTax;
        }
        return _taxTotal;
      }
    }

    /// <summary>
    /// Gets the discount amount.
    /// </summary>
    /// <value>The discount amount.</value>
    public decimal DiscountAmount {
      get {
        decimal _discountAmount = 0;
        foreach(OrderItem orderItem in this.OrderItemCollection) {
          _discountAmount += orderItem.TotalItemDiscount;
        }
        return _discountAmount;
      }
    }

    /// <summary>
    /// Gets the total.
    /// </summary>
    /// <value>The total.</value>
    public decimal Total {
      get {
        return this.SubTotal + this.ShippingAmount + this.TaxTotal + this.HandlingAmount - this.DiscountAmount;
      }
    }

    /// <summary>
    /// Gets the total weight.
    /// </summary>
    /// <value>The total weight.</value>
    public decimal TotalWeight {
      get {
        decimal _totalWeight = 0;
        foreach(OrderItem item in this.OrderItemCollection) {
          _totalWeight += (item.Weight * item.Quantity);
        }
        return _totalWeight;
      }
    }

    /// <summary>
    /// Gets the shipping address.
    /// </summary>
    /// <value>The shipping address.</value>
    public Address ShippingAddress {
      get {
        if(!string.IsNullOrEmpty(this.ShipToAddress)) {
          _shippingAddress = new Address().NewFromXml(this.ShipToAddress) as Address;
        }
        return _shippingAddress;
      }
    }

    /// <summary>
    /// Gets the billing address.
    /// </summary>
    /// <value>The billing address.</value>
    public Address BillingAddress {
      get {
        if(_billingAddress == null) {
          if(!string.IsNullOrEmpty(this.BillToAddress)) {
            _billingAddress = new Address().NewFromXml(this.BillToAddress) as Address;
          }
        }
        return _billingAddress;
      }
    }

    /// <summary>
    /// Gets the extended properties.
    /// </summary>
    /// <value>The extended properties.</value>
    public ExtendedProperties ExtendedProperties {
      get {
        if(_extendedProperties == null) {
          if(!string.IsNullOrEmpty(this.AdditionalProperties)) {
            _extendedProperties = new ExtendedProperties().NewFromXml(this.AdditionalProperties) as ExtendedProperties;
          }
          else {
            _extendedProperties = new ExtendedProperties();
          }
        }
        return _extendedProperties;
      }
    }
	
	  #endregion

    #region "Credit Card Information"

    [NonSerialized(), System.Xml.Serialization.XmlIgnore()]
    private string _creditCardNumber;
    [NonSerialized(), System.Xml.Serialization.XmlIgnore()]
    private int _crediCardExpirationYear;
    [NonSerialized(), System.Xml.Serialization.XmlIgnore()]
    private int _creditCardExpirationMonth;
    [NonSerialized(), System.Xml.Serialization.XmlIgnore()]
    private int _crediCardStartYear;
    [NonSerialized(), System.Xml.Serialization.XmlIgnore()]
    private int _creditCardStartMonth;
    [NonSerialized(), System.Xml.Serialization.XmlIgnore()]
    private string _creditCardIssueNumber;
    [NonSerialized(), System.Xml.Serialization.XmlIgnore()]
    private string _creditCardSecurityNumber;
    [NonSerialized(), System.Xml.Serialization.XmlIgnore()]
    private CreditCardType _creditCardType;

    /// <summary>
    /// Gets or sets the credit card number.
    /// </summary>
    /// <value>The credit card number.</value>
    [System.Xml.Serialization.XmlIgnore()]
    public string CreditCardNumber {
      get {
        return _creditCardNumber;
      }
      set {
        _creditCardNumber = value;
      }
    }

    /// <summary>
    /// Gets or sets the credit card expiration year.
    /// </summary>
    /// <value>The credit card expiration year.</value>
    [System.Xml.Serialization.XmlIgnore()]
    public int CreditCardExpirationYear {
      get {
        return _crediCardExpirationYear;
      }
      set {
        _crediCardExpirationYear = value;
      }
    }

    /// <summary>
    /// Gets or sets the credit card expiration month.
    /// </summary>
    /// <value>The credit card expiration month.</value>
    [System.Xml.Serialization.XmlIgnore()]
    public int CreditCardExpirationMonth {
      get {
        return _creditCardExpirationMonth;
      }
      set {
        _creditCardExpirationMonth = value;
      }
    }

          /// <summary>
    /// Gets or sets the credit card expiration year.
    /// </summary>
    /// <value>The credit card start year.</value>
    [System.Xml.Serialization.XmlIgnore()]
    public int CreditCardStartYear {
      get {
        return _crediCardStartYear;
      }
      set {
        _crediCardStartYear = value;
      }
    }

    /// <summary>
    /// Gets or sets the credit card expiration month.
    /// </summary>
    /// <value>The credit card start month.</value>
    [System.Xml.Serialization.XmlIgnore()]
    public int CreditCardStartMonth {
      get {
        return _creditCardStartMonth;
      }
      set {
        _creditCardStartMonth = value;
      }
    }

    /// <summary>
    /// Gets or sets the debit card issue number.
    /// </summary>
    /// <value>The credit card issue number.</value>
    [System.Xml.Serialization.XmlIgnore()]
    public string CreditCardIssueNumber {
      get {
        return _creditCardIssueNumber;
      }
      set {
        _creditCardIssueNumber = value;
      }
    }

    /// <summary>
    /// Gets or sets the credit card security number.
    /// </summary>
    /// <value>The credit card security number.</value>
    [System.Xml.Serialization.XmlIgnore()]
    public string CreditCardSecurityNumber {
      get {
        return _creditCardSecurityNumber;
      }
      set {
        _creditCardSecurityNumber = value;
      }
    }


    /// <summary>
    /// Gets or sets the type of the credit card.
    /// </summary>
    /// <value>The type of the credit card.</value>
    [System.Xml.Serialization.XmlIgnore()]
    public CreditCardType CreditCardType {
      get {
        return _creditCardType;
      }
      set {
        _creditCardType = value;
      }
    }


    #endregion

    #region String Methods

    /// <summary>
    /// To HTML.
    /// </summary>
    /// <returns></returns>
    public string ToHtml() {
      StringBuilder sb = new StringBuilder();
      sb.Append("<table class=\"receiptTable\">");
      sb.Append(string.Format("<tr><td colspan=\"2\">{0}&nbsp;{1}</td></tr>", Strings.ResourceManager.GetString("OrderNumber"), this.OrderNumber));
      sb.Append(string.Format("<tr><td colspan=\"2\">{0}&nbsp;{1}</td></tr>", Strings.ResourceManager.GetString("OrderStatus"), CoreUtility.ParseCamelToProper(Enum.GetName(typeof(OrderStatus), (int)this.OrderStatusDescriptorId))));
      if(this.TransactionCollection.Count > 0) {
        sb.Append(string.Format("<tr><td colspan=\"2\">{0}&nbsp;{1}&nbsp;{2}</td></tr>", Strings.ResourceManager.GetString("OrderDate"), this.TransactionCollection[0].TransactionDate.ToLongDateString(), this.TransactionCollection[0].TransactionDate.ToLongTimeString()));
        sb.Append("<tr><td colspan=\"2\">&nbsp;</td></tr>");
        sb.Append(string.Format("<tr><td colspan=\"2\">{0}</td></tr>", Strings.ResourceManager.GetString("PaymentInformation")));
        sb.Append(string.Format("<tr><td colspan=\"2\">{0}&nbsp;{1}</td></tr>", Strings.ResourceManager.GetString("PaymentMethod"), this.TransactionCollection[0].PaymentMethod));
        sb.Append(string.Format("<tr><td colspan=\"2\">{0}&nbsp;{1}</td></tr>", Strings.ResourceManager.GetString("TransactionCode"), this.TransactionCollection[0].GatewayTransactionId));
      }
      sb.Append(string.Format("<tr><td colspan=\"2\">{0}</td></tr>", Strings.ResourceManager.GetString("ShippingAndBilling")));
      sb.Append(string.Format("<tr><td colspan=\"2\">{0}&nbsp;{1}</td></tr>", Strings.ResourceManager.GetString("ShippingMethod"), this.ShippingMethod));
      sb.Append("<tr><td colspan=\"2\">&nbsp;</td></tr>");
      sb.Append(string.Format("<tr><td valign=\"top\">{0}<br>{1}</td><td valign=\"top\">{2}<br>{3}<br><br><br><br></td></tr>", Strings.ResourceManager.GetString("BillTo"), this.BillingAddress != null ? this.BillingAddress.ToHtmlString() : string.Empty, Strings.ResourceManager.GetString("ShipTo"), this.ShippingAddress != null ? this.ShippingAddress.ToHtmlString() : string.Empty));
      sb.Append(string.Format("<tr><td colspan=\"2\">{0}</td></tr>", Strings.ResourceManager.GetString("OrderItems")));
      sb.Append("<tr><td colspan=\"2\">&nbsp;</td></tr>");
      sb.Append(string.Format("<tr><td colspan=\"2\">{0}</td></tr>", this.ItemsToString()));
      sb.Append("</table>");

      return sb.ToString();

    }

    /// <summary>
    /// Items to string.
    /// </summary>
    /// <returns></returns>
    public string ItemsToString() {

      StringBuilder sb = new StringBuilder();
      sb.Append("<table class=\"receiptTable\">");
      sb.Append(string.Format("<tr><th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th></tr>", Strings.ResourceManager.GetString("hdrItemNumber"), Strings.ResourceManager.GetString("hdrItemName"), Strings.ResourceManager.GetString("hdrQuantity"), Strings.ResourceManager.GetString("hdrPrice"), Strings.ResourceManager.GetString("hdrExtendedPrice")));

      string appendFormat = "<tr><td class=\"itemSku\">{0}</td><td class=\"itemName\">{1}</td><td class=\"itemQuantity\" align=\"right\">{2}</td><td class=\"itemAmount\" align=\"right\">{3}</td><td class=\"itemAmount\" align=\"right\">{4}</td></tr>";
      string appendAltFormat = "<tr><td class=\"itemSku\">{0}</td><td class=\"itemName\">{1}</td><td class=\"itemQuantity\" align=\"right\">{2}</td><td class=\"itemAmount\" align=\"right\">{3}</td><td class=\"itemAmount\" align=\"right\">{4}</td></tr>";
      string formatToUse = appendFormat;

      bool isEven = true;

      foreach(OrderItem item in this.OrderItemCollection) {

        if(isEven) {
          formatToUse = appendFormat;
        }
        else {
          formatToUse = appendAltFormat;
        }
        string attSelections = "";
        if(item.Attributes != string.Empty) {
          attSelections = "<br>" + item.Attributes;
        }

        sb.AppendFormat(formatToUse, item.Sku, item.Name + " " + attSelections, item.Quantity.ToString(), StoreUtility.GetFormattedAmount(item.PricePaid, true), StoreUtility.GetFormattedAmount(item.ExtendedPrice, true));
        isEven = !isEven;
      }

      sb.Append(string.Format("<tr><td colspan=\"4\" class=\"subTotal\" align=\"right\">{0}</td><td class=\"subTotalAmount\" align=\"right\">{1}</td></tr>", Strings.ResourceManager.GetString("Subtotal"), StoreUtility.GetFormattedAmount(this.SubTotal, true)));
      if(this.DiscountAmount > 0) {
        sb.Append(string.Format("<tr><td colspan=\"4\" class=\"subTotal\" align=\"right\">{0}</td><td class=\"subTotalAmount\" align=\"right\">- {1}</td></tr>", Strings.ResourceManager.GetString("Coupon"), StoreUtility.GetFormattedAmount(this.DiscountAmount, true)));
      }
      else {
        sb.Append(string.Format("<tr><td colspan=\"4\" class=\"subTotal\" align=\"right\">{0}</td><td class=\"subTotalAmount\" align=\"right\">{1}</td></tr>", Strings.ResourceManager.GetString("Coupon"), StoreUtility.GetFormattedAmount(this.DiscountAmount, true)));
      }
      sb.Append(string.Format("<tr><td colspan=\"4\" class=\"subTotal\" align=\"right\">{0}</td><td class=\"subTotalAmount\" align=\"right\">{1}</td></tr>", Strings.ResourceManager.GetString("Tax"), StoreUtility.GetFormattedAmount(this.TaxTotal, true)));
      sb.Append(string.Format("<tr><td colspan=\"4\" class=\"subTotal\" align=\"right\">{0}</td><td class=\"subTotalAmount\" align=\"right\">{1}</td></tr>", Strings.ResourceManager.GetString("ShippingAndHandling"), StoreUtility.GetFormattedAmount(this.ShippingAmount, true)));
      sb.Append(string.Format("<tr><td colspan=\"4\" class=\"total\" align=\"right\">{0}</td><td class=\"totalAmount\" align=\"right\">{1}</td></tr>", Strings.ResourceManager.GetString("Total"), StoreUtility.GetFormattedAmount(this.Total, true)));

      sb.Append("</table>");
      return sb.ToString();
    }


    #endregion

  }
}
