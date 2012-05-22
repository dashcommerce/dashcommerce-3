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
using System.Web;
using MettleSystems.dashCommerce.Core.Caching;
using MettleSystems.dashCommerce.Store;

namespace MettleSystems.dashCommerce.Web {

  public class StoreCloser : IHttpModule {
    /// <summary>
    /// You will need to configure this module in the web.config file of your
    /// web and register it with IIS before being able to use it. For more information
    /// see the following link: http://go.microsoft.com/?linkid=8101007
    /// </summary>
    #region IHttpModule Members

    public void Dispose() {
      //clean-up code here.
    }

    /// <summary>
    /// Initializes a module and prepares it to handle requests.
    /// </summary>
    /// <param name="context">An <see cref="T:System.Web.HttpApplication"/> that provides access to the methods, properties, and events common to all application objects within an ASP.NET application</param>
    public void Init(HttpApplication context) {
      context.PostAuthenticateRequest += new EventHandler(context_PostAuthenticateRequest);
    }

    /// <summary>
    /// Handles the PostAuthenticateRequest event of the context control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    void context_PostAuthenticateRequest(object sender, EventArgs e) {
      HttpContext context = ((HttpApplication)sender).Context;
      SiteSettings siteSettings = null;
      try {
        siteSettings = SiteSettingCache.GetSiteSettings();
      }
      catch (Exception) {
        //swallow it - probably no connection string during install
      }
      if (siteSettings != null) {
        if (siteSettings.IsStoreClosed && !context.User.IsInRole("Administrator") &&
            !context.Request.Url.ToString().Contains("login.aspx")) {
          context.RewritePath("~/storeclosed.aspx");
        }
      }
    }

    #endregion

  }
}
