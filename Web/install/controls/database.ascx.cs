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
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MettleSystems.dashCommerce.Core.Globalization;
using MettleSystems.dashCommerce.Localization;

namespace MettleSystems.dashCommerce.Web.install.controls {
  public partial class database : InstallControl {

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected override void Page_Load(object sender, EventArgs e) {
      try {
        base.Page_Load(sender, e);
        Page.Form.DefaultButton = btnNext.UniqueID;
        SetLanguageSelections();
        SetDatabaseProperties();
        if (!WebUtility.ConnectionStringExists) {
          chkUseConnectionStringConfig.Visible = false;
        }
      }
      catch(Exception ex) {
        MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnNext control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected override void btnNext_Click(object sender, EventArgs e) {
      try {
        if (rdoNewOrExistingDatabase.SelectedItem.Text.Equals("Create a New Database")) {
            InstallUtility.CreateDatabase(txtDatabaseName.Text.Trim(), GetMasterConnectionString());
        }
        if (!chkUseConnectionStringConfig.Checked) {
          string connectionString = GetConnectionString();
          InstallUtility.SetConnectionString("dashCommerce", connectionString);
        }
        else {
          base.Step++;
        }
        Response.Redirect(string.Format("~/install/install.aspx?step={0}&selected_language={1}", this.Step + 1, ddlLanguage.SelectedValue), true);
      }
      catch(Exception ex) {
        MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click even of the btnTestConnection control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    //protected void btnTestConnection_Click(object sender, EventArgs e) {
    //  if (!Page.IsValid)
    //    return;

    //  try {
    //    using (SqlConnection conn = new SqlConnection(GetConnectionString())) {
    //      conn.Open();
    //      conn.Close();
    //      MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblTestDatabaseConnection"));
    //    }
    //  }
    //  catch (Exception ex) {
    //    MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
    //  }
    //}

    /// <summary>
    /// Handles the Click event of the chkWindowsAuth control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void chkWindowsAuth_CheckedChanged(object sender, EventArgs e) {
      rfvDatabaseUserName.Enabled = rfvDatabasePassword.Enabled = txtDatabaseUserName.Enabled = txtDatabasePassword.Enabled = !chkWindowsAuth.Checked;
    }

    /// <summary>
    /// Handles the Changed event of the chkUseConnectionStringConfig control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void chkUseConnectionStringConfig_Changed(object sender, EventArgs e) {
      pnlDatabaseSettings.Enabled = !chkUseConnectionStringConfig.Checked;
      //need to turn off validation controls
      foreach (Control ctrl in pnlDatabaseSettings.Controls) {
        if (ctrl is WebControl)
          ((WebControl)ctrl).Enabled = pnlDatabaseSettings.Enabled;
      }
      if (!chkUseConnectionStringConfig.Checked) return;
      if (!WebUtility.ConnectionStringExists) {
        MasterPage.MessageCenter.DisplayCriticalMessage(LocalizationUtility.GetText("lblConnectionStringDoesNotExist"));
      }
    }


    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Gets the connection string.
    /// </summary>
    /// <returns></returns>
    private string GetConnectionString() {
      if (chkUseConnectionStringConfig.Checked) {
        return WebUtility.ConnectionString;
      }
      else {
        return string.Format("Server={0};Initial Catalog={1};{2}", txtDatabaseServer.Text.Trim(), txtDatabaseName.Text.Trim(),
         chkWindowsAuth.Checked ? "Trusted_Connection=Yes;" : string.Format("User Id={0};Password={1};", txtDatabaseUserName.Text.Trim(), txtDatabasePassword.Text.Trim()));
      }
    }

    private string GetMasterConnectionString() {
      return string.Format("Server={0};Initial Catalog={1};{2}", txtDatabaseServer.Text.Trim(), "master",
        chkWindowsAuth.Checked ? "Trusted_Connection=Yes;" : string.Format("User Id={0};Password={1};", txtDatabaseUserName.Text.Trim(), txtDatabasePassword.Text.Trim()));
    }

    /// <summary>
    /// Sets the language selections.
    /// </summary>
    private void SetLanguageSelections() {
      CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
      Array.Sort(cultures, new CultureComparer());
      ddlLanguage.DataSource = cultures;
      ddlLanguage.DataValueField = "Name";
      ddlLanguage.DataTextField = "DisplayName";
      ddlLanguage.DataBind();
      //get UI culture of current thread to set default
      CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentUICulture;
      if(!string.IsNullOrEmpty(cultureInfo.Name)) {//Invariant Culture
        ddlLanguage.SelectedValue = cultureInfo.Name;
      }
      else {
        ddlLanguage.SelectedValue = "en-US";
      }
    }

    /// <summary>
    /// Sets the database properties.
    /// </summary>
    private void SetDatabaseProperties() {
      chkWindowsAuth.Text = LocalizationUtility.GetText("lblWindowsAuth");
    }

    #endregion

    #endregion

  }
}