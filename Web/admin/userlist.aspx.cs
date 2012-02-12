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
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;

namespace MettleSystems.dashCommerce.Web.admin {
  public partial class userlist : MettleSystems.dashCommerce.Store.Web.AdminPage {

    #region Member Variables

    MembershipUserCollection membershipUserCollection;

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        SetUserListProperties();
        LoadUsers();
      }
      catch (Exception ex) {
        Logger.Error(typeof(userlist).Name + ".Page_Load", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnSearch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnSearch_Click(object sender, EventArgs e) {
      try {
        if (!string.IsNullOrEmpty(txtSearchBy.Text.Trim())) {
          string text = txtSearchBy.Text.Trim();
          text = text.Replace("*", "%");
          text = text.Replace("?", "_");
          if (ddlSearchBy.SelectedIndex == 0 /* userID */) {
            membershipUserCollection = Membership.FindUsersByName(text);
          }
          else {
            membershipUserCollection = Membership.FindUsersByEmail(text);
          }
          BindMembershipUserCollection(membershipUserCollection);
          hlShowAll.Visible = true;
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(userlist).Name + ".btnSearch_Click", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Enableds the changed.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    public void EnabledChanged(object sender, EventArgs e) {
      try {
        string userID = null;
        CheckBox checkBox = sender as CheckBox;
        if (checkBox == null)
          return;

        if (!string.IsNullOrEmpty(checkBox.Attributes["Value"]))
          userID = checkBox.Attributes["Value"];

        if (userID == null)
          return;

        MembershipUser user = Membership.FindUsersByName(userID)[userID];
        user.IsApproved = checkBox.Checked;

        Membership.UpdateUser(user);
      }
      catch (Exception ex) {
        Logger.Error(typeof(userlist).Name + ".EnabledChanged", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the lbDelete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.CommandEventArgs"/> instance containing the event data.</param>
    protected void lbDelete_Click(object sender, CommandEventArgs e) {
      try {
        if (e.CommandName.Equals("mydelete")) {
          string userName = (string)e.CommandArgument;
          Membership.DeleteUser(userName);
          Response.Redirect("~/admin/userlist.aspx", false);
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(userlist).Name + ".lbDelete_Click", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the dgUserList control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.DataGridPageChangedEventArgs"/> instance containing the event data.</param>
    protected void dgUserList_PageIndexChanging(object sender, DataGridPageChangedEventArgs e) {
      dgUserList.CurrentPageIndex = e.NewPageIndex;
      dgUserList.DataBind();
    }

    /// <summary>
    /// Handles the ItemDataBound event of the dgUserList control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.DataGridItemEventArgs"/> instance containing the event data.</param>
    void dgUserList_ItemDataBound(object sender, DataGridItemEventArgs e) {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        LinkButton lbDelete = e.Item.Cells[5].FindControl("lbDelete") as LinkButton;
        if (lbDelete != null) {
          lbDelete.Text = LocalizationUtility.GetText("lbDelete");
        }
      }
    }

    #endregion

    #region Methods

    #region Protected

    /// <summary>
    /// Formats the edit URL.
    /// </summary>
    /// <param name="userName">Name of the user.</param>
    /// <returns></returns>
    protected string FormatEditUrl(string userName) {
      return string.Format("useredit.aspx?userName={0}", userName);
    }

    #endregion

    #region Private

    /// <summary>
    /// Sets the user list properties.
    /// </summary>
    private void SetUserListProperties() {
      this.Title = LocalizationUtility.GetText("titleUserAdministration");
      if (!Page.IsPostBack) {
        ddlSearchBy.Items.Add(new ListItem(LocalizationUtility.GetText("lblUserName")));
        ddlSearchBy.Items.Add(new ListItem(LocalizationUtility.GetText("lblEmailAddress")));
      }
    }

    /// <summary>
    /// Binds the membership user collection.
    /// </summary>
    private void BindMembershipUserCollection(MembershipUserCollection membershipUserCollection) {
      dgUserList.DataSource = membershipUserCollection;
      dgUserList.ItemDataBound += new DataGridItemEventHandler(dgUserList_ItemDataBound);
      dgUserList.Columns[0].HeaderText = LocalizationUtility.GetText("hdrActive");
      dgUserList.Columns[1].HeaderText = LocalizationUtility.GetText("hdrUserName");
      dgUserList.Columns[2].HeaderText = LocalizationUtility.GetText("hdrEmailAddress");
      dgUserList.Columns[3].HeaderText = LocalizationUtility.GetText("hdrCreatedOn");
      dgUserList.Columns[4].HeaderText = LocalizationUtility.GetText("hdrLastLogin");
      dgUserList.Columns[5].HeaderText = LocalizationUtility.GetText("hdrDelete");
      dgUserList.DataBind();
      lblNumberOfTotalUsers.Text = membershipUserCollection.Count.ToString();
    }

    private void LoadUsers() {
      BindMembershipUserCollection(Membership.GetAllUsers());
    }

    #endregion

    #endregion

  }
}
