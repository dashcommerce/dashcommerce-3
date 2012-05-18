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
using MettleSystems.dashCommerce.Content;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Caching;
using MettleSystems.dashCommerce.Store.Services.MessageService;

namespace MettleSystems.dashCommerce.Web.controls.content {
  public partial class ContactUs : ProviderControl {

    /// <summary>
    /// Handles the Click event of the btnSend control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void btnSend_Click(object sender, EventArgs e) {
      MailSettings mail = MessagingCache.GetMailSettings(); //TODO: Cache?
      MailMessage mailMessage = new MailMessage();
      mailMessage.From = new MailAddress(txtEmail.Text.Trim(), txtName.Text.Trim());
      mailMessage.To.Add(new MailAddress(mail.Contact));
      mailMessage.Subject = txtSubject.Text.Trim();
      mailMessage.Body = txtMessage.Text.Trim();
      mailMessage.IsBodyHtml = false;

      Email email = new Email();
      email.Send(mailMessage);
      lblSent.Visible = true;
    }
  }
}