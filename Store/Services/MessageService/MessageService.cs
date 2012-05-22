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
