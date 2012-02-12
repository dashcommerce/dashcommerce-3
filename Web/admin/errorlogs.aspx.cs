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
using System.Web.UI.WebControls;
using System.Data;

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using SubSonic;

namespace MettleSystems.dashCommerce.Web.admin {
  public partial class errorlogs : MettleSystems.dashCommerce.Store.Web.AdminPage {

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        SetErrorLogsProperties();
        if (!Page.IsPostBack) {
          LoadLogLevels();
          LoadErrorLogs();
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(errorlogs).Name + ".Page_Load", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnSearch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void btnSearch_Click(object sender, EventArgs e) {
      try {
        LoadLogsByMessageType(ddlLogLevel.SelectedValue);
      }
      catch (Exception ex) {
        Logger.Error(typeof(errorlogs).Name + ".btnSearch_Click", ex);
        Master.MessageCenter.DisplayCriticalMessage(string.Format(LocalizationUtility.GetText("lblCriticalError"), ex.Message));
      }
    }

    /// <summary>
    /// Handles the Click event of the btnDeleteAll control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnDeleteAll_Click(object sender, EventArgs e) {
      try {
        LogController.DeleteAllLogs();
        LoadErrorLogs();
        Master.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblDeleteAllLogs"));
      }
      catch (Exception ex) {
        Logger.Error(typeof(errorlogs).Name + ".btnDeleteAll_Click", ex);
        Master.MessageCenter.DisplayCriticalMessage(string.Format(LocalizationUtility.GetText("lblCriticalError"), ex.Message));
      }
    }

    /// <summary>
    /// Handles the Paging event of the dgErrorLogListing control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridPageChangedEventArgs"/> instance containing the event data.</param>
    public void dgErrorLogListing_Paging(object sender, DataGridPageChangedEventArgs e) {
      dgErrorLogListing.CurrentPageIndex = e.NewPageIndex;
      LoadErrorLogs();
    }

    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Sets the error logs properties.
    /// </summary>
    private void SetErrorLogsProperties() {
      this.Title = LocalizationUtility.GetText("titleErrorLogs");
    }

    /// <summary>
    /// Loads the error logs.
    /// </summary>
    private void LoadErrorLogs() {
      Query query = new Query(Log.Schema.TableName)
                        .ORDER_BY(Log.Columns.LogDate, "DESC");
      LogCollection logCollection = new LogController().FetchByQuery(query);
      BindLogCollection(logCollection);
    }

    /// <summary>
    /// Loads the type of the logs by message.
    /// </summary>
    /// <param name="messageType">Type of the message.</param>
    private void LoadLogsByMessageType(string messageType) {
      Query query = new Query(Log.Schema.TableName)
                        .WHERE(Log.Columns.MessageType, Comparison.Equals, messageType)
                        .ORDER_BY(Log.Columns.LogDate, "DESC");
      LogCollection logCollection = new LogController().FetchByQuery(query);
      BindLogCollection(logCollection);
    }

    /// <summary>
    /// Binds the log collection.
    /// </summary>
    /// <param name="logCollection">The log collection.</param>
    private void BindLogCollection(LogCollection logCollection) {
      if (logCollection.Count > 0) {
        dgErrorLogListing.DataSource = logCollection;
        dgErrorLogListing.Columns[1].HeaderText = LocalizationUtility.GetText("hdrDetails");
        dgErrorLogListing.Columns[2].HeaderText = LocalizationUtility.GetText("hdrLogDate");
        dgErrorLogListing.Columns[3].HeaderText = LocalizationUtility.GetText("hdrLogLevel");
        dgErrorLogListing.Columns[4].HeaderText = LocalizationUtility.GetText("hdrScriptName");
        dgErrorLogListing.Columns[5].HeaderText = LocalizationUtility.GetText("hdrLogMessage");
        dgErrorLogListing.Columns[6].HeaderText = LocalizationUtility.GetText("hdrRemoteHost");
        HyperLinkColumn hlDetailsColumn = dgErrorLogListing.Columns[1] as HyperLinkColumn;
        if (hlDetailsColumn != null) {
          hlDetailsColumn.Text = LocalizationUtility.GetText("lblDetails");
        }
        dgErrorLogListing.DataBind();
      }
      else {
        pnlCurrentErrorLogs.Visible = false;
        Master.MessageCenter.DisplayInformationMessage(LocalizationUtility.GetText("lblNoErrorLogs"));
      }
    }

    /// <summary>
    /// Loads the log levels.
    /// </summary>
    private void LoadLogLevels() {
      Query query = new Query(Log.Schema.TableName);
      query.QueryType = QueryType.Select;
      query.SelectList = Log.Columns.MessageType;
      query.DISTINCT();
      query.ORDER_BY(Log.Columns.MessageType);
      IDataReader reader = query.ExecuteReader();
      while (reader.Read()) {
        ddlLogLevel.Items.Add(new ListItem(Enum.Parse(typeof(Logger.LogMessageType), reader[0].ToString()).ToString(), reader[0].ToString()));
      }
      ddlLogLevel.Items.Insert(0, new ListItem(LocalizationUtility.GetText("lblSelect")));
    }

    #endregion

    #endregion

  }
}
