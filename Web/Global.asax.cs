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
using System.Web.Profile;
using System.Web.Security;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Core.Caching;
using MettleSystems.dashCommerce.Store;

namespace MettleSystems.dashCommerce.Web {
  public class Global : System.Web.HttpApplication {

    /// <summary>
    /// Handles the Start event of the Application control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Application_Start(object sender, EventArgs e) { }

    /// <summary>
    /// Handles the End event of the Application control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Application_End(object sender, EventArgs e) { }

    protected void Application_Error(object sender, EventArgs e) {
      // Code that runs when an unhandled error occurs
      Logger.LogMessageType msgType = Logger.LogMessageType.Error;
      Exception exAppError = Server.GetLastError();
      bool logException = true;
      Exception baseException = exAppError.GetBaseException();
      if (baseException is System.Data.SqlClient.SqlException && baseException.Message.StartsWith("Timeout expired")) {
        msgType = Logger.LogMessageType.DatabaseError; //Database timeout error.
      }
      else if (baseException is System.Web.HttpException && baseException.Message.EndsWith("does not exist.")) {
        msgType = Logger.LogMessageType.Warning; //404 Errors not really and error but might be usefull to log them.
      }
      else if (baseException is System.Security.Cryptography.CryptographicException && baseException.Message.StartsWith("Padding is invalid")) {
        logException = false; //Googlebots can fire these exceptions it's safe to ignore them.
      }
      if (logException)
        Logger.Error(exAppError.Message, exAppError, msgType);
    }

    protected void Application_BeginRequest(object sender, EventArgs e) {
      if (!WebUtility.ConnectionStringExists) {
        InstallUtility.RedirectToInstall();
      }
    }
    
    /// <summary>
    /// Handles the PreRequestHandlerExecute event of the Application control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Application_PreRequestHandlerExecute(object sender, EventArgs e) {
      SiteSettings siteSettings = null;
      try {
        siteSettings = SiteSettingCache.GetSiteSettings();
      }
      catch (Exception) {
        //swallow it - probably no connection string during install
      }

      string cultureName = ""; //default this. TODO: Get this into installer?
      if (siteSettings != null) {
        cultureName = siteSettings.Language ?? cultureName;
      }
      System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(cultureName);
      System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
    }

    /// <summary>
    /// Handles the OnMigrateAnonymous event of the Profile control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="args">The <see cref="T:System.Web.Profile.ProfileMigrateEventArgs"/> instance containing the event data.</param>
    public void Profile_OnMigrateAnonymous(object sender, ProfileMigrateEventArgs args) {
      OrderController.MigrateCart(args.AnonymousID, WebProfile.Current.UserName);
      ProfileManager.DeleteProfile(args.AnonymousID);
      AnonymousIdentificationModule.ClearAnonymousIdentifier();
    }
  }
}
