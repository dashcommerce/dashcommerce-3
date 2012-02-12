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

  public partial class rolelist : MettleSystems.dashCommerce.Store.Web.AdminPage {

    #region Constants

    private const string REDIRECT_PAGE = "~/admin/rolelist.aspx";
    private const string LB_DELETE = "lbDelete";
    private const string CMD_MYDELETE = "mydelete";

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        string[] roles = Roles.GetAllRoles();
        dgRoles.DataSource = roles;
        dgRoles.ItemDataBound += new DataGridItemEventHandler(dgRoles_ItemDataBound);
        dgRoles.DataBind();
        SetRoleListProperties();
      }
      catch (Exception ex) {
        Logger.Error(typeof(rolelist).Name + ".Page_Load", ex);
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
        if (e.CommandName.Equals(CMD_MYDELETE)) {
          string roleName = e.CommandArgument as string;
          Roles.DeleteRole(roleName);
          Response.Redirect(REDIRECT_PAGE, false);
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(rolelist).Name + ".lbDelete_Click", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e) {
      if (Page.IsValid) {
        try {
          Roles.CreateRole(txtRoleName.Text.Trim());
          Response.Redirect(REDIRECT_PAGE, false);
        }
        catch (Exception ex) {
          Logger.Error(typeof(rolelist).Name + ".btnSave_Click", ex);
          Master.MessageCenter.DisplayCriticalMessage(ex.Message);
        }
      }
    }

    /// <summary>
    /// Handles the ItemDataBound event of the dgRoles control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridItemEventArgs"/> instance containing the event data.</param>
    private void dgRoles_ItemDataBound(object sender, DataGridItemEventArgs e) {
      if (e.Item.ItemType == ListItemType.Header) { //TODO: Move these to after setting the datasource
        e.Item.Cells[0].Text = LocalizationUtility.GetText("hdrDelete");
        e.Item.Cells[1].Text = LocalizationUtility.GetText("hdrRoleName");
      }
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        LinkButton linkButton = e.Item.Cells[0].FindControl(LB_DELETE) as LinkButton;
        if (linkButton != null) {
          linkButton.Text = LocalizationUtility.GetText("lblDelete");
        }
      }
    }

    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Sets the role list properties.
    /// </summary>
    private void SetRoleListProperties() {
      Page.Title = LocalizationUtility.GetText("titleRoleAdministration");
    }

    #endregion

    #endregion

  }
}
