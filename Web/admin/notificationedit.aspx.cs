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
using System.Web;
using System.Web.UI;

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin {
  public partial class notificationedit : MettleSystems.dashCommerce.Store.Web.AdminPage {

    #region Member Variables

    private int notificationId = 0;
    private Notification notification;
    
    #endregion
    
    #region Page Events

    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Init"></see> event to initialize the page.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected override void OnInit(EventArgs e) {
      Session["FCKeditor:UserFilesPath"] = @"~/repository/content/";
      base.OnInit(e);
    }

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load (object sender, EventArgs e) {
      try {
      notificationId = Utility.GetIntParameter("notificationId");
      notification = new Notification(notificationId);
      SetNotificationEditProperties();
      if (!Page.IsPostBack) {
        if (notificationId > 0) {
          chkIsSystemNotification.Checked = notification.IsSystemNotification;
          txtName.Text = notification.Name;
          txtToList.Text = notification.ToList;
          txtCcList.Text = notification.CcList;
          txtFromName.Text = notification.FromName;
          txtFromEmail.Text = notification.FromEmail;
          txtSubject.Text = notification.Subject;
          chkIsHtml.Checked = notification.IsHTML;
          txtNotificationBody.Value = HttpUtility.HtmlDecode(notification.NotificationBody);
          lblNotificationEdit.Text = LocalizationUtility.GetText("lblNotificationEdit") + " >> " + notification.Name;
        }
      }
      }
      catch (Exception ex){
        Logger.Error(typeof(notificationedit).Name + ".Page_Load", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click (object sender, EventArgs e) {
      try {
        notification.Name = txtName.Text;
        notification.ToList = txtToList.Text;
        notification.CcList = txtCcList.Text;
        notification.FromName = txtFromName.Text;
        notification.FromEmail = txtFromEmail.Text;
        notification.Subject = txtSubject.Text;
        notification.IsHTML = chkIsHtml.Checked;
        notification.NotificationBody = HttpUtility.HtmlEncode(txtNotificationBody.Value);
        notification.Save(WebUtility.GetUserName());
        Master.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblNotificationSaved"));
      }
      catch (Exception ex) {
        Logger.Error(typeof(notificationedit).Name + ".btnSave_Click", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }
    
    #endregion
    
    #region Methods
    
    #region Private

    /// <summary>
    /// Sets the notification edit properties.
    /// </summary>
    private void SetNotificationEditProperties () {
      this.Title = LocalizationUtility.GetText("titleEditNotification");
    }

    #endregion
    
    #endregion

  }
}
