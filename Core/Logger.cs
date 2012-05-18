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
using System.Text;
using System.Web;

namespace MettleSystems.dashCommerce.Core {
  public class Logger {

    #region Member Variables

    public enum LogMessageType {
      Error = 1,
      Warning = 2,
      Information = 3,
      DatabaseError = 4
    }

    #endregion

    #region Methods

    #region Public

    public static void Error(string message) {
      LogException(message, null, LogMessageType.Error, string.Empty);
    }

    [Obsolete("Use Error(string message, Exception ex)")]
    public static void Error(object message, Exception ex) {
      LogException(message as string, ex, LogMessageType.Error, string.Empty);
    }

    public static void Error(string message, Exception ex) {
      LogException(message, ex, LogMessageType.Error, string.Empty);
    }

    public static void Error(string message, Exception ex, LogMessageType messageType) {
      LogException(message, ex, messageType, string.Empty);
    }

    public static void Information(string message) {
      LogException(message, null, LogMessageType.Information, string.Empty);
    }

    #endregion

    #region Private


    /// <summary>
    /// Logs an exception
    /// </summary>
    /// <param name="msg">Descriptive message</param>
    /// <param name="ex">Current Exception</param>
    /// <param name="errorType">Error type</param>
    /// <returns>bool Success</returns>
    public static bool LogException(string msg, Exception ex, LogMessageType errorType) {
      return LogException(msg, ex, errorType, string.Empty);
    }

    /// <summary>
    /// Logs an exception
    /// </summary>
    /// <param name="msg">Descriptive message</param>
    /// <param name="ex">Current exception</param>
    /// <param name="authName">Current users authentication name</param>
    /// <param name="errorType">Error type</param>
    /// <returns>bool Success</returns>
    private static bool LogException(string msg, Exception ex, LogMessageType errorType, string authName) {
      bool Success = true;
      try {
        string exMessage = string.Empty;
        string exType = string.Empty;
        StringBuilder exSource = new StringBuilder();
        string exStackTrace = string.Empty;
        string scriptName;
        string userAgent = string.Empty;
        string referer = string.Empty;
        string remoteHost = string.Empty;
        string authUser = authName;
        string formData = string.Empty;
        string queryStringData = string.Empty;
        string cookiesData = string.Empty;

        if (ex != null) {
          while (ex != null) {
            if (ex.InnerException == null) {
              exMessage = ex.Message;
              exType = ex.GetType().ToString();
              exStackTrace = ex.StackTrace;
            }
            exSource.Append("[");
            exSource.Append(ex.Source);
            exSource.Append("]");

            ex = ex.InnerException;
          }
        }

        // Leave all HTTP-specific information out if this
        // method is being called from a Win/Console app.
        if (HttpContext.Current == null)
          scriptName = Environment.CommandLine;
        else {
          HttpContext thisContext = HttpContext.Current;
          HttpRequest thisRequest = thisContext.Request;

          scriptName = thisRequest.CurrentExecutionFilePath;
          userAgent = thisRequest.ServerVariables["HTTP_USER_AGENT"];
          referer = thisRequest.ServerVariables["HTTP_REFERER"];
          remoteHost = thisRequest.ServerVariables["HTTP_X_FORWARDED_FOR"];
          if (string.IsNullOrEmpty(remoteHost))
            remoteHost = thisRequest.ServerVariables["REMOTE_HOST"];
          authUser = thisRequest.ServerVariables["AUTH_USER"];
          formData = thisRequest.Form.ToString();
          queryStringData = thisRequest.QueryString.ToString();
          cookiesData = GetCookiesAsString(thisContext);
        }

        Log log = new Log();
        log.AuthUser = authUser;
        log.Referer = referer;
        log.RemoteHost = remoteHost;
        log.Message = msg ?? string.Empty;
        log.UserAgent = userAgent;
        log.ScriptName = scriptName;
        log.ExceptionMessage = exMessage;
        log.ExceptionSource = exSource.ToString();
        log.ExceptionStackTrace = exStackTrace;
        log.MachineName = Environment.MachineName;
        log.ExceptionType = exType;
        log.MessageType = (byte)errorType;
        log.CookiesData = cookiesData;
        log.FormData = formData;
        log.QueryStringData = queryStringData;
        log.LogDate = DateTime.UtcNow;
        log.Save();
      }
      catch {
        Success = false;
      }
      return Success;
    }

    /// <summary>
    /// Gets info from the server side cookie
    /// </summary>
    /// <param name="thisContext">cookie mix</param>
    /// <returns>cookies n crumbs</returns>
    private static string GetCookiesAsString(HttpContext thisContext) {
      HttpCookieCollection cookies = thisContext.Request.Cookies;
      int cookieCount = cookies.Count;
      StringBuilder sb = new StringBuilder();

      for (int i = 0; i < cookieCount; i++) {
        sb.Append(((i > 0) ? "&" : "") + thisContext.Server.UrlEncode(cookies[i].Name) + "=" + thisContext.Server.UrlEncode(cookies[i].Value));
      }
      return sb.ToString();
    }

    #endregion

    #endregion

  }
}
