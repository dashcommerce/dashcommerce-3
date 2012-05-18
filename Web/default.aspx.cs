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
using System.Web.UI;

using MettleSystems.dashCommerce.Content;
using MettleSystems.dashCommerce.Store;

namespace MettleSystems.dashCommerce.Web {
  public partial class _default : PageBuilder {

    #region Member Variables

    private SiteSettings _siteSettings;

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      Page.Title = string.Format(WebUtility.MainTitleTemplate, Master.SiteSettings.SiteName, base.Title);
      Master.HideSeoInformation = true;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the name of the style sheet applied to this page.
    /// </summary>
    /// <value></value>
    /// <returns>The name of the style sheet applied to this page.</returns>
    /// <exception cref="T:System.InvalidOperationException">The <see cref="P:System.Web.UI.Page.StyleSheetTheme"/> property is set before the <see cref="E:System.Web.UI.Control.Init"/> event completes.</exception>
    public override string StyleSheetTheme {
      get {
        return SiteSettings.Theme;
      }
    }

    /// <summary>
    /// Gets the site settings.
    /// </summary>
    /// <value>The site settings.</value>
    public SiteSettings SiteSettings {
      get {
        if (_siteSettings == null)
          _siteSettings = MettleSystems.dashCommerce.Core.Caching.SiteSettingCache.GetSiteSettings();
        return _siteSettings;
      }
    }

    #endregion

  }
}
