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
using System.Net.Mail;
using System.Web;
using MettleSystems.dashCommerce.Core.Caching;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Store.Services.MessageService {
  public class MessageService {
  
    #region Methods
    
    #region Public

    /// <summary>
    /// Sends the order received notification to merchant.
    /// </summary>
    /// <param name="order">The order.</param>
    public void SendOrderReceivedNotificationToMerchant(Order order) {
      Notification notification = new Notification((int)SystemNotifications.OrderReceivedToMerchant);
      string notificationBody = HttpUtility.HtmlDecode(notification.NotificationBody);
      if (!string.IsNullOrEmpty(notificationBody)) {
        notificationBody = ReplaceConstantsInNotification(order, notificationBody, notification);
        Email email = new Email();
        email.Send(notification.FromEmail, notification.ToList, notification.Subject, notificationBody, true);
      }
    }

    /// <summary>
    /// Sends the order received notification to customer.
    /// </summary>
    /// <param name="order">The order.</param>
    public void SendOrderReceivedNotificationToCustomer(Order order) {
      SendNotificationToCustomer(order, SystemNotifications.OrderReceivedToCustomer);
    }

    /// <summary>
    /// Sends the shipping notification to customer.
    /// </summary>
    /// <param name="order">The order.</param>
    public void SendShippingNotificationToCustomer(Order order) {
      SendNotificationToCustomer(order, SystemNotifications.ShippingNotificationToCustomer);
    }

    /// <summary>
    /// Sends the order cancellation to customer.
    /// </summary>
    /// <param name="order">The order.</param>
    public void SendOrderCancellationToCustomer(Order order) {
      SendNotificationToCustomer(order, SystemNotifications.OrderCancellationToCustomer);
    }

    /// <summary>
    /// Sends the order refund to customer.
    /// </summary>
    /// <param name="order">The order.</param>
    public void SendOrderRefundToCustomer(Order order) {
      SendNotificationToCustomer(order, SystemNotifications.OrderRefundToCustomer);
    }

    /// <summary>
    /// Sends the specified mail message.
    /// </summary>
    /// <param name="mailMessage">The mail message.</param>
    public void Send(MailMessage mailMessage) {
      Email email = new Email();
      email.Send(mailMessage);      
    }

    /// <summary>
    /// Sends the notification to customer.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <param name="systemNotification">The system notification.</param>
    private void SendNotificationToCustomer(Order order, SystemNotifications systemNotification) {

      Notification notification = new Notification((int)systemNotification);

      string notificationBody = HttpUtility.HtmlDecode(notification.NotificationBody);
      if (!string.IsNullOrEmpty(notificationBody)) {
        //run the tag replacements
        notificationBody = ReplaceConstantsInNotification(order, notificationBody, notification);
        Email email = new Email();
        email.Send(notification.FromEmail, order.BillingAddress.Email, notification.CcList, notification.Subject, notificationBody, true);
      }
    }
    
    #endregion
    
    #region Private

    /// <summary>
    /// Replaces the constants in notification.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <param name="notificationBody">The notification body.</param>
    /// <param name="notification">The notification.</param>
    /// <returns></returns>
    private string ReplaceConstantsInNotification(Order order, string notificationBody, Notification notification) {
      //#NAME#
      if(order.BillingAddress != null) {
        notificationBody = notificationBody.Replace("#NAME#", order.BillingAddress.FirstName + " " + order.BillingAddress.LastName);
      }

      //#ORDERNUMBER#
      notificationBody = notificationBody.Replace("#ORDERNUMBER#", order.OrderNumber);

      //#ORDERDATE#
      notificationBody = notificationBody.Replace("#ORDERDATE#", order.TransactionCollection[0].TransactionDate.ToShortDateString());

      //#DATE#
      notificationBody = notificationBody.Replace("#DATE#", DateTime.UtcNow.ToShortDateString());

      //#TRACKINGNUMBER#
      notificationBody = notificationBody.Replace("#TRACKINGNUMBER#", order.ShippingTrackingNumber);

      //#ORDER#
      notificationBody = notificationBody.Replace("#ORDER#", order.ToHtml());

      //#TAGLINE#
      SiteSettings siteSettings = SiteSettingCache.GetSiteSettings(); ;
      notificationBody = notificationBody.Replace("#TAGLINE#", siteSettings.TagLine);

      //#ADMINPRODUCTLINK#
      notificationBody = notificationBody.Replace("#ADMINPRODUCTLINK#", Utility.GetSiteRoot() + "/admin/orders.aspx?oid=" + order.OrderId);

      //#SITELINK#
      notificationBody = notificationBody.Replace("#SITELINK#", Utility.GetSiteRoot());

      //#STOREEMAIL#
      notificationBody = notificationBody.Replace("#STOREEMAIL#", "<a href='mailto:" + notification.FromEmail + "'>" + notification.FromEmail + "</a>");

      return notificationBody;
    }
    
    #endregion
    
    #endregion
    
  }
}
