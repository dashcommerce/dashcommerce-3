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
