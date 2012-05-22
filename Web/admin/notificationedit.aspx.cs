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
