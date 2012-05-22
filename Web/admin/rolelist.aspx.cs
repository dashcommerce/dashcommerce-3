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
