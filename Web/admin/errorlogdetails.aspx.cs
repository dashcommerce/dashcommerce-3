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

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin {

  public partial class errorlogdetails : MettleSystems.dashCommerce.Store.Web.AdminPage {

    #region Member Variables

    private int logId = 0;

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        logId = Utility.GetIntParameter("logId");
        if (logId > 0) {
          SetErrorLogDetailsProperties();
          Log log = new Log(logId);
          lblLogDateDisplay.Text = log.LogDate.ToLongDateString();
          lblLogLevelDisplay.Text = ((Logger.LogMessageType)Convert.ToInt32(log.MessageType.ToString())).ToString();
          lblLogMessageDisplay.Text = log.Message;
          lblLogScriptNameDisplay.Text = log.ScriptName;
          lblAuthenticatedUserDisplay.Text = log.AuthUser;
          lblRemoteHostDisplay.Text = log.RemoteHost;
          lblUserAgentDisplay.Text = log.UserAgent;
          lblReferrerDisplay.Text = log.Referer;
          lblExceptionTypeDisplay.Text = log.ExceptionType;
          lblExceptionMessageDisplay.Text = log.ExceptionMessage;
          lblQueryStringDataDisplay.Text = log.QueryStringData;
          txtLogInfoDisplay.Text = log.ExceptionStackTrace;
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(errorlogdetails).Name + ".Page_Load", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Sets the error log details properties.
    /// </summary>
    private void SetErrorLogDetailsProperties() {
      
      
      
      
      
      lblLogScriptName.Text = LocalizationUtility.GetText("hdrScriptName");
      lblReferrer.Text = LocalizationUtility.GetText("hdrReferrer");
      lblUserAgent.Text = LocalizationUtility.GetText("hdrUserAgent");
      lblAuthenticatedUser.Text = LocalizationUtility.GetText("hdrAuthenticatedUser");
      lblRemoteHost.Text = LocalizationUtility.GetText("hdrRemoteHost");
      lblExceptionType.Text = LocalizationUtility.GetText("hdrExceptionType");
      lblExceptionMessage.Text = LocalizationUtility.GetText("hdrExceptionMessage");
      lblQueryStringData.Text = LocalizationUtility.GetText("hdrQueryStringData");
    }

    #endregion

    #endregion

  }
}
