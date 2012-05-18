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
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin {
  public partial class useredit : MettleSystems.dashCommerce.Store.Web.AdminPage {

    #region Member Variables

    string userName = string.Empty;
    bool isEditMode = false;
    MembershipUser membershipUser = null;

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        userName = Utility.GetParameter("userName");
        isEditMode = !string.IsNullOrEmpty(userName);
        SetUserEditProperties();
        if (isEditMode) {
          pnlAddUser.Visible = false;
          pnlEditUser.Visible = true;
          membershipUser = Membership.GetUser(userName);
        }
        else {
          pnlAddUser.Visible = true;
          cuwRegister.CreatedUser += new EventHandler(cuwRegister_CreatedUser);
          pnlEditUser.Visible = false;
        }
        if (!Page.IsPostBack) {
          BindRoles();
          if (isEditMode) {
            if (membershipUser != null) {
              txtUserName.Enabled = false;
              txtUserName.Text = membershipUser.UserName;
              txtEmail.Text = membershipUser.Email;
              chkActive.Checked = membershipUser.IsApproved;
            }
            else {
              this.Master.MessageCenter.DisplayFailureMessage(string.Format(LocalizationUtility.GetText("lblUserNotFound"), userName));
              pnlEditUser.Visible = false;
            }
          }
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(useredit).Name + ".Page_Load", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e) {
      try {
        if (isEditMode) {
          UpdateUser();
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(useredit).Name + ".btnSave_Click", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the CreatedUser event of the cuwRegister control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    void cuwRegister_CreatedUser(object sender, EventArgs e) {
      Response.Redirect(string.Format("~/admin/useredit.aspx?userName={0}", cuwRegister.UserName), true);
    }

    #endregion

    #region Methods

    #region Protected

    /// <summary>
    /// Determines whether [is user in role] [the specified role name].
    /// </summary>
    /// <param name="roleName">Name of the role.</param>
    /// <returns>
    /// 	<c>true</c> if [is user in role] [the specified role name]; otherwise, <c>false</c>.
    /// </returns>
    protected bool IsUserInRole(string roleName) {
      if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(roleName)) {
        return false;
      }
      return Roles.IsUserInRole(userName, roleName);
    }

    #endregion

    #region Private

    /// <summary>
    /// Sets the user edit properties.
    /// </summary>
    private void SetUserEditProperties() {
      if (isEditMode) {
        Page.Title = LocalizationUtility.GetText("titleEditUser");
      }
      else {
        Page.Title = LocalizationUtility.GetText("titleAddUser");
      }
    }

    /// <summary>
    /// Binds the roles.
    /// </summary>
    private void BindRoles() {
      if (Roles.Enabled) {
        rptrRoles.DataSource = Roles.GetAllRoles();
        rptrRoles.DataBind();
      }
    }

    /// <summary>
    /// Updates the user.
    /// </summary>
    private void UpdateUser() {
      if (Page.IsValid) {
        membershipUser.Email = txtEmail.Text.Trim();
        membershipUser.IsApproved = chkActive.Checked;
        Membership.UpdateUser(membershipUser);
        UpdateRoleMembership();
        this.Master.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblUserUpdated"));
      }
    }

    /// <summary>
    /// Updates the role membership.
    /// </summary>
    private void UpdateRoleMembership() {
      foreach (RepeaterItem repeaterItem in rptrRoles.Items) {
        CheckBox checkBox = repeaterItem.FindControl("checkbox1") as CheckBox;
        if (checkBox != null) {
          if (checkBox.Checked && !Roles.IsUserInRole(userName, checkBox.Text)) {
            Roles.AddUserToRole(userName, checkBox.Text);
          }
          if (!checkBox.Checked && Roles.IsUserInRole(userName, checkBox.Text)) {
            Roles.RemoveUserFromRole(userName, checkBox.Text);
          }
        }
      }
    }

    #endregion

    #endregion

  }
}
