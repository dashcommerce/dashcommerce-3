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
using MettleSystems.dashCommerce.Core.Caching;
using MettleSystems.dashCommerce.Store;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin {
  public partial class sitesettings : MettleSystems.dashCommerce.Store.Web.AdminPage {

    #region Member Variables

    private string view = string.Empty;
    private SiteSettings siteSettings = null;

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        view = Utility.GetParameter("view");
        
        LoadSiteSettings();

        switch (view) {
          case "w":
            dcWidgets.Visible = true;
            dcWidgets.SiteSettings = siteSettings;
            break;
            
          case "b":
            dcBrowsingLog.Visible = true;
            dcBrowsingLog.SiteSettings = siteSettings;
            break;
          
          case "c":
            dcCachingSettings.Visible = true;
            dcCachingSettings.SiteSettings = siteSettings;
            break;

          case "gl":
            dcGlobalizationSettings.Visible = true;
            dcGlobalizationSettings.SiteSettings = siteSettings;
            break;

          case "i":
            dcImagesSettings.Visible = true;
            dcImagesSettings.SiteSettings = siteSettings;
            break;

          case "a":
            dcAnalytics.Visible = true;
            dcAnalytics.SiteSettings = siteSettings;
            break;

          case "seo":
            dcSeoSettings.Visible = true;
            dcSeoSettings.SiteSettings = siteSettings;
            break;

          case "s":
          default:
            dcSite.Visible = true;
            dcSite.SiteSettings = siteSettings;
            break;
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(sitesettings).Name + ".Page_Load", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Loads the site settings.
    /// </summary>
    private void LoadSiteSettings() {
      siteSettings = SiteSettingCache.GetSiteSettings(); ;
    }

    #endregion

    #endregion

  }
}
