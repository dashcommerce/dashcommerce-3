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
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Store.Caching;

namespace MettleSystems.dashCommerce.Store.Services.MessageService {

  public class Email {
  
    #region Constants
    
    private const string SUBJECT = "subject";
    private const string FROM = "from";
    private const string TO = "to";
    private const string BODY = "body";
    
    #endregion

    #region Member Variables
    
    private SmtpClient smtpClient;
    private MailSettings mailSettings;
    
    #endregion
    
    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Email"/> class.
    /// </summary>
    public Email() {
      mailSettings = MessagingCache.GetMailSettings();
      smtpClient = new SmtpClient(mailSettings.Host, mailSettings.Port);
      if (mailSettings.RequireAuthentication) {
        smtpClient.Credentials = new NetworkCredential(mailSettings.UserName, mailSettings.Password);
      }
      if (mailSettings.RequireSsl) {
        smtpClient.EnableSsl = true;
      }
    }
    
    #endregion
    
    #region Methods
    
    #region Public

    /// <summary>
    /// Sends the specified mail message.
    /// </summary>
    /// <param name="mailMessage">The mail message.</param>
    public void Send(MailMessage mailMessage) {
      try {
        smtpClient.Send(mailMessage);
      }
      catch(Exception ex) {
        Logger.Error(typeof(Email).FullName + ".Send", ex);
      }
    }

    /// <summary>
    /// Sends the specified from.
    /// </summary>
    /// <param name="from">From.</param>
    /// <param name="toList">To list.</param>
    /// <param name="ccList">The cc list.</param>
    /// <param name="bccList">The BCC list.</param>
    /// <param name="subject">The subject.</param>
    /// <param name="body">The body.</param>
    /// <param name="attachmentPaths">The attachment paths.</param>
    /// <param name="isHtml">if set to <c>true</c> [is HTML].</param>
    /// <param name="mailPriority">The mail priority.</param>
    public void Send(string from, string toList, string ccList, string bccList, string subject, string body, string[] attachmentPaths, bool isHtml, MailPriority mailPriority) {
      MailMessage message = BuildMailMessage(from, toList, ccList, bccList, subject, body, attachmentPaths, isHtml, mailPriority);
      try {
        Send(message);
      }
      catch (Exception ex) {
        Logger.Error(typeof(Email).FullName + ".Send", ex);
      }
    }

    /// <summary>
    /// Sends the specified from.
    /// </summary>
    /// <param name="from">From.</param>
    /// <param name="toList">To list.</param>
    /// <param name="ccList">The cc list.</param>
    /// <param name="subject">The subject.</param>
    /// <param name="body">The body.</param>
    /// <param name="isHtml">if set to <c>true</c> [is HTML].</param>
    public void Send(string from, string toList, string ccList, string subject, string body, bool isHtml) {
      Send(from, toList, ccList, null, subject, body, null, isHtml, MailPriority.Normal);
    }

    /// <summary>
    /// Sends the specified from.
    /// </summary>
    /// <param name="from">From.</param>
    /// <param name="toList">To list.</param>
    /// <param name="subject">The subject.</param>
    /// <param name="body">The body.</param>
    /// <param name="isHtml">if set to <c>true</c> [is HTML].</param>
    public void Send(string from, string toList, string subject, string body, bool isHtml) {
      Send(from, toList, null, null, subject, body, null, isHtml, MailPriority.Normal);
    }

    /// <summary>
    /// Builds the mail message.
    /// </summary>
    /// <param name="from">From.</param>
    /// <param name="to">To.</param>
    /// <param name="cc">The cc.</param>
    /// <param name="bcc">The BCC.</param>
    /// <param name="subject">The subject.</param>
    /// <param name="body">The body.</param>
    /// <param name="attachmentPaths">The attachment paths.</param>
    /// <param name="isHtml">if set to <c>true</c> [is HTML].</param>
    /// <param name="mailPriority">The mail priority.</param>
    /// <returns></returns>
    private MailMessage BuildMailMessage(string from, string to, string cc, string bcc, string subject, string body, string[] attachmentPaths, bool isHtml, MailPriority mailPriority) {
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(subject, SUBJECT);
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(from, FROM);
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(to, TO);
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(body, BODY);

      MailMessage message = new MailMessage();
      message.From = new MailAddress(from);
      string[] toList = to.Split(';');
      for(int i = 0; i < toList.Length; i++){
        if(!string.IsNullOrEmpty(toList[i])){
          message.To.Add(new MailAddress(toList[i]));
        }
      }
      if (!string.IsNullOrEmpty(cc)) {
        string[] ccList = cc.Split(';');
        for(int i = 0; i < ccList.Length; i++){
          if(!string.IsNullOrEmpty(ccList[i])){
            message.CC.Add(new MailAddress(ccList[i]));
          }
        }
      }
      if (!string.IsNullOrEmpty(bcc)) {
        string[] bccList = bcc.Split(';');
        for (int i = 0; i < bccList.Length; i++) {
          if (!string.IsNullOrEmpty(bccList[i])) {
            message.Bcc.Add(new MailAddress(bccList[i]));
          }
        }
      }
      message.Subject = subject;
      message.IsBodyHtml = isHtml;
      message.Priority = mailPriority;
      message.Body = body;

      // Create attachments
      if ((attachmentPaths != null) && (attachmentPaths.Length > 0)) {
        foreach (string attachmentPath in attachmentPaths) {
          // MailAttachment likes fully-qualified file names, use FileInfo to 
          // get them.
          FileInfo fileInfo = new FileInfo(attachmentPath);

          if (fileInfo.Exists) {
            message.Attachments.Add(new Attachment(fileInfo.FullName));
          }
          else {
            Logger.Error(string.Format("Attachment not found: {0}", fileInfo.FullName));
          }
        }
      }
      return message;
    }

    #endregion
    
    #endregion

  }
}
