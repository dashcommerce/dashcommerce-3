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
