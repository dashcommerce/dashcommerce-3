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
