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
using System.Web.UI;
using System.Web.UI.WebControls;

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;

namespace MettleSystems.dashCommerce.Web.admin {
  public partial class notifications : MettleSystems.dashCommerce.Store.Web.AdminPage {

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        SetNotificationsProperties();
        if (!Page.IsPostBack) {
          LoadNotifications();
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(notifications).Name + ".Page_Load", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the ItemDataBound event of the dgNotifications control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridItemEventArgs"/> instance containing the event data.</param>
    void dgNotifications_ItemDataBound(object sender, DataGridItemEventArgs e) {
      if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        HyperLink hlEdit = e.Item.Cells[0].FindControl("hlEditLink") as HyperLink;
        if(hlEdit != null) {
          hlEdit.Text = LocalizationUtility.GetText("lblEdit");
        }
      }
    }

    #endregion

    #region Methods

    #region Protected

    /// <summary>
    /// Formats the edit URL.
    /// </summary>
    /// <param name="notificationId">The notification id.</param>
    /// <returns></returns>
    protected string FormatEditUrl(string notificationId) {
      return string.Format("~/admin/notificationedit.aspx?notificationId={0}", notificationId);
    }

    #endregion

    #region Private

    /// <summary>
    /// Loads the notifications.
    /// </summary>
    private void LoadNotifications() {
      NotificationCollection notificationCollection = new NotificationController().FetchAll();
      if (notificationCollection.Count > 0) {
        dgNotifications.DataSource = notificationCollection;
        dgNotifications.ItemDataBound += new DataGridItemEventHandler(dgNotifications_ItemDataBound);
        dgNotifications.Columns[0].HeaderText = LocalizationUtility.GetText("hdrEdit");
        dgNotifications.Columns[1].HeaderText = LocalizationUtility.GetText("hdrName");
        dgNotifications.Columns[2].HeaderText = LocalizationUtility.GetText("hdrSystemNotification");
        dgNotifications.DataBind();
      }
    }

    /// <summary>
    /// Sets the notifications properties.
    /// </summary>
    private void SetNotificationsProperties() {
      
      this.Title = LocalizationUtility.GetText("titleNotifications");
    }

    #endregion

    #endregion

  }
}
