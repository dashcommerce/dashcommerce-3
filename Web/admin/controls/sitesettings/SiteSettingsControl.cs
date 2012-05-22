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
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Core.Caching;
using MettleSystems.dashCommerce.Core.Configuration;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Web.Controls;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin.controls.sitesettings {
  public class SiteSettingsControl : AdminControl {

    #region Member Variables

    private SiteSettings _siteSettings;
    protected string view;

    #endregion

    #region Page Events

    protected virtual void Page_Load(object sender, EventArgs e) {
      view = Utility.GetParameter("view");
    }


    #endregion

    #region Properties

    /// <summary>
    /// Gets the panel.
    /// </summary>
    /// <value>The panel.</value>
    //public Panel Panel {
    //  get {
    //    return this.FindControl("pnlSettings") as Panel;
    //  }
    //}

    /// <summary>
    /// Gets or sets the site settings.
    /// </summary>
    /// <value>The site settings.</value>
    public SiteSettings SiteSettings {
      get {
        return _siteSettings;
      }
      set {
        _siteSettings = value;
      }
    }

    #endregion

    #region Methods

    #region Public

    /// <summary>
    /// Saves the specified site settings.
    /// </summary>
    /// <param name="siteSettings">The site settings.</param>
    public void Save(SiteSettings siteSettings) {
      try {
        DatabaseConfigurationProvider databaseConfigurationProvider = new DatabaseConfigurationProvider();
        int id = databaseConfigurationProvider.SaveConfiguration(SiteSettings.SECTION_NAME, siteSettings, WebUtility.GetUserName());
        SiteSettingCache.RemoveSiteSettingsFromCache();
        if (id > 0) {
          MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblSiteSettingsSaved"));
        }
        else {
          MasterPage.MessageCenter.DisplayFailureMessage(LocalizationUtility.GetText("lblSiteSettingsNotSaved"));
        }
      }
      catch(Exception ex) {
        Logger.Error("Save", ex);
        MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    #endregion

    #endregion

  }
}
