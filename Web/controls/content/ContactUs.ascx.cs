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