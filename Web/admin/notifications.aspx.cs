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
