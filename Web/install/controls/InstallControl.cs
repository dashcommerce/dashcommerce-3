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
using System.IO;

using System.Data.SqlClient;


using MettleSystems.dashCommerce.Store.Web.Controls;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.install.controls {

  public class InstallControl : AdminControl {

    #region Constants

    private const string SCRIPT_DROP = "~/install/scripts/drop.sql";
    private const string SCRIPT_TABLES = "~/install/scripts/tables.sql";
    private const string SCRIPT_FULL_TEXT_CATALOG = "~/install/scripts/fulltextcatalog.sql";
    private const string SCRIPT_FUNCTIONS = "~/install/scripts/functions.sql";
    private const string SCRIPT_VIEWS = "~/install/scripts/views.sql";
    private const string SCRIPT_SPS = "~/install/scripts/storedprocedures.sql";
    private const string SCRIPT_BASE_DATA = "~/install/scripts/basedata.sql";
    private const string SCRIPT_MEMBERSHIP_SCHEMA = "~/install/scripts/membership.sql";
    private const string SCRIPT_BASE_MEMBERSHIP_DATA = "~/install/scripts/basemembershipdata.sql";

    private const string SCRIPT_UPGRADE_3RC_TO_300 = "~/install/scripts/Update_dc3.0RC1_To_dC3.0.sql";
    private const string SCRIPT_UPGRADE_300_TO_301 = "~/install/scripts/Update_dC3.0_To_dC3.0.1.sql";
    private const string SCRIPT_UPGRADE_301_TO_320RC = "~/install/scripts/Update_dC3.0.1_To_dC3.2RC.sql";
    private const string SCRIPT_UPGRADE_32RC_TO_320 = "~/install/scripts/Update_dC3.2RC_To_dC3.2.sql";
    private const string SCRIPT_UPGRADE_320_TO_330RC = "~/install/scripts/Update_dC3.2_To_dC3.3RC.sql";
    private const string SCRIPT_UPGRADE_33RC_TO_33 = "~/install/scripts/Update_dC3.3RC_To_dC3.3.sql";
    private const string SCRIPT_UPGRADE_33_TO_34 = "~/install/scripts/Update_dC3.3_To_dC3.4.sql";


    #endregion

    #region Member Variables

    private int _step;

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected virtual void Page_Load(object sender, EventArgs e) {
      _step = Utility.GetIntParameter("step");
    }

    /// <summary>
    /// Handles the Click event of the btnPrevious control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected virtual void btnPrevious_Click(object sender, EventArgs e) {
      try {
        Response.Redirect(string.Format("~/install/install.aspx?step={0}", this.Step - 1), true);
      }
      catch (Exception ex) {
        MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnNext control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected virtual void btnNext_Click(object sender, EventArgs e) {
      try {
        Response.Redirect(string.Format("~/install/install.aspx?step={0}", this.Step + 1), true);
      }
      catch (Exception ex) {
        MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Runs the scripts.
    /// </summary>
    /// <param name="connectionString">The connection string.</param>
    protected void RunScripts(string connectionString, string selectedLanguage, string version) {
      switch (version) {
        case "Not Installed":
          //Drop
          string[] dropStatements = GetScriptStatements(File.ReadAllText(Server.MapPath(SCRIPT_DROP), new System.Text.UTF8Encoding()));
          ExecuteStatements(dropStatements, connectionString);
          //Tables
          string[] tableStatements = GetScriptStatements(File.ReadAllText(Server.MapPath(SCRIPT_TABLES), new System.Text.UTF8Encoding()));
          ExecuteStatements(tableStatements, connectionString);
          //Full Text Catalog
          //string[] fullTextStatements = GetScriptStatements(File.ReadAllText(Server.MapPath(SCRIPT_FULL_TEXT_CATALOG), new System.Text.UTF8Encoding()));
          //ExecuteStatements(fullTextStatements, connectionString);
          //Functions
          string[] functionStatements = GetScriptStatements(File.ReadAllText(Server.MapPath(SCRIPT_FUNCTIONS), new System.Text.UTF8Encoding()));
          ExecuteStatements(functionStatements, connectionString);
          //Views
          string[] viewStatements = GetScriptStatements(File.ReadAllText(Server.MapPath(SCRIPT_VIEWS), new System.Text.UTF8Encoding()));
          ExecuteStatements(viewStatements, connectionString);
          //Stored Procedures
          string[] storedProcedureStatements = GetScriptStatements(File.ReadAllText(Server.MapPath(SCRIPT_SPS), new System.Text.UTF8Encoding()));
          ExecuteStatements(storedProcedureStatements, connectionString);
          //Base Data
          string baseDataFileName = string.Format("~/install/scripts/basedata.{0}.sql", selectedLanguage);
          if (!File.Exists(Server.MapPath(baseDataFileName))) {
            baseDataFileName = SCRIPT_BASE_DATA;
          }
          string[] baseDataStatements = GetScriptStatements(File.ReadAllText(Server.MapPath(baseDataFileName), new System.Text.UTF8Encoding()));
          ExecuteStatements(baseDataStatements, connectionString);
          //Membership
          string[] membershipStatements = GetScriptStatements(File.ReadAllText(Server.MapPath(SCRIPT_MEMBERSHIP_SCHEMA), new System.Text.UTF8Encoding()));
          ExecuteStatements(membershipStatements, connectionString);
          //Base Membership Data
          string[] baseMembershipDataStatements = GetScriptStatements(File.ReadAllText(Server.MapPath(SCRIPT_BASE_MEMBERSHIP_DATA), new System.Text.UTF8Encoding()));
          ExecuteStatements(baseMembershipDataStatements, connectionString);
          break;
        case "3.0 RC":
          Upgrade30RCTo30(connectionString);
          Upgrade30To301(connectionString);
          Upgrade301To320RC(connectionString);
          Upgrade320RCTo32Final(connectionString);
          Upgrade32To33RC(connectionString);
          Upgrade33RCTo33(connectionString);
          Upgrade33To34(connectionString);
          break;
        case "3.0.0.0":
          Upgrade30To301(connectionString);
          Upgrade301To320RC(connectionString);
          Upgrade320RCTo32Final(connectionString);
          Upgrade32To33RC(connectionString);
          Upgrade33RCTo33(connectionString);
          Upgrade33To34(connectionString);
          break;
        case "3.0.1.0":
          Upgrade301To320RC(connectionString);
          Upgrade320RCTo32Final(connectionString);
          Upgrade32To33RC(connectionString);
          Upgrade33RCTo33(connectionString);
          Upgrade33To34(connectionString);
          break;
        case "3.2.0.0":
          Upgrade320RCTo32Final(connectionString);
          Upgrade32To33RC(connectionString);
          Upgrade33RCTo33(connectionString);
          Upgrade33To34(connectionString);
          break;
        case "3.3.0.0":
          Upgrade33RCTo33(connectionString);
          Upgrade33To34(connectionString);
          break;
        case "3.3.425.0":
          Upgrade33To34(connectionString);
          break;
      }
    }

    private void Upgrade33To34(string connectionString) {
      string[] dC33TodC34Statements = GetScriptStatements(File.ReadAllText(Server.MapPath(SCRIPT_UPGRADE_33_TO_34), new System.Text.UTF8Encoding()));
      ExecuteStatements(dC33TodC34Statements, connectionString);
    }

    private void Upgrade33RCTo33(string connectionString) {
      string[] dC33RCTodC33Statements = GetScriptStatements(File.ReadAllText(Server.MapPath(SCRIPT_UPGRADE_33RC_TO_33), new System.Text.UTF8Encoding()));
      ExecuteStatements(dC33RCTodC33Statements, connectionString);
    }

    private void Upgrade32To33RC(string connectionString) {
      string[] dc32To33RCStatements = GetScriptStatements(File.ReadAllText(Server.MapPath(SCRIPT_UPGRADE_320_TO_330RC), new System.Text.UTF8Encoding()));
      ExecuteStatements(dc32To33RCStatements, connectionString);
    }

    private void Upgrade320RCTo32Final(string connectionString) {
      string[] dc32RCTo32Statements = GetScriptStatements(File.ReadAllText(Server.MapPath(SCRIPT_UPGRADE_32RC_TO_320), new System.Text.UTF8Encoding()));
      ExecuteStatements(dc32RCTo32Statements, connectionString);
    }

    private void Upgrade301To320RC(string connectionString) {
      string[] dc301To320Statements = GetScriptStatements(File.ReadAllText(Server.MapPath(SCRIPT_UPGRADE_301_TO_320RC), new System.Text.UTF8Encoding()));
      ExecuteStatements(dc301To320Statements, connectionString);
    }

    private void Upgrade30To301(string connectionString) {
      string[] dc300To301Statements = GetScriptStatements(File.ReadAllText(Server.MapPath(SCRIPT_UPGRADE_300_TO_301), new System.Text.UTF8Encoding()));
      ExecuteStatements(dc300To301Statements, connectionString);
    }

    private void Upgrade30RCTo30(string connectionString) {
      string[] dcRcTo30Statements = GetScriptStatements(File.ReadAllText(Server.MapPath(SCRIPT_UPGRADE_3RC_TO_300), new System.Text.UTF8Encoding()));
      ExecuteStatements(dcRcTo30Statements, connectionString);
    }

    /// <summary>
    /// Gets the script statements.
    /// </summary>
    /// <param name="p">The p.</param>
    /// <returns></returns>
    protected string[] GetScriptStatements(string p) {
      string[] statements = p.Split(new string[] { "GO\r\n" }, StringSplitOptions.RemoveEmptyEntries);
      return statements;
    }

    /// <summary>
    /// Executes the statements.
    /// </summary>
    /// <param name="statements">The statements.</param>
    /// <param name="connectionString">The connection string.</param>
    protected void ExecuteStatements(string[] statements, string connectionString) {
      if (statements.Length > 0) {
        using (SqlConnection conn = new SqlConnection()) {
          conn.ConnectionString = connectionString;
          conn.Open();
          using (SqlCommand command = new SqlCommand(string.Empty, conn)) {
            foreach (string statement in statements) {
              command.CommandText = statement;
              command.ExecuteNonQuery();
            }
          }
        }
      }
    }

    /// <summary>
    /// Executes the statement.
    /// </summary>
    /// <param name="statement">The statement.</param>
    /// <param name="connectionString">The connection string.</param>
    /// <returns></returns>
    protected object ExecuteStatement(string statement, string connectionString) {
      object value;
      using (SqlConnection conn = new SqlConnection()) {
        conn.ConnectionString = connectionString;
        conn.Open();
        using (SqlCommand command = new SqlCommand(string.Empty, conn)) {
          command.CommandText = statement;
          value = command.ExecuteScalar();
        }
      }
      return value;
    }


    #endregion

    #region Properties

    public int Step {
      get {
        return _step;
      }
      set {
        _step = value;
      }
    }

    #endregion

  }
}
