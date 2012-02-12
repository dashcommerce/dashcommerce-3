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
        string connectionString = GetConnectionString();
        InstallUtility.SetConnectionString("dashCommerce", connectionString);
        //Session["ConnectionString"] = connectionString;
        //if (chkUseConnectionStringConfig.Checked) {
        //  base.Step++;
        //}
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