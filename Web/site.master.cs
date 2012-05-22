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
using System.IO;
using System.Web;
using System.Web.UI;
using MettleSystems.dashCommerce.Content.Caching;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Web;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web {
  public partial class site : SiteMasterPage {

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      if (!this.IsPostBack) {
        if (!string.IsNullOrEmpty(SiteSettings.SiteLogo)) {
          if (File.Exists(Server.MapPath(SiteSettings.SiteLogo))) {
            hlLogo.ImageUrl = SiteSettings.SiteLogo;
          }
        }
        hlLogo.NavigateUrl = Utility.GetSiteRoot();
        litAnalytics.Text = HttpUtility.HtmlDecode(SiteSettings.Analytics);
        LoadSeoContent();
      }
      LoadNavigation();
    }

    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Loads the navigation.
    /// </summary>
    private void LoadNavigation() {
      xmlDataSource.EnableCaching = false;
      xmlDataSource.CacheDuration = 0;
      RewriteService.AddRewriteNameSpaceForXslt(xmlDataSource);
      xmlDataSource.Data = PageMenuCache.GetPageMenu();
    }

    /// <summary>
    /// Loads the SEO Meta Tags.
    /// </summary>
    private void LoadSeoContent() {
      try {
        GeneratorTag.Content = "dashCommerce";
        if (SiteSettings.SeoSetting.SiteKeywords != null) {
          KeyWords.InsertRange(0, SiteSettings.SeoSetting.SiteKeywords.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
          KeyWords.Add("dashCommerce");
          KeyWords.Add("dC");
        }

        string text = LocalizationUtility.GetText("CopyrightTemplate");
        CopyrightTag.Content = string.Format(string.IsNullOrEmpty(text) ? "Copyright (c) {0} by {1}" : text, DateTime.Now.Year,
          string.IsNullOrEmpty(SiteSettings.SeoSetting.CopyrightText)
                ? SiteSettings.SiteName : SiteSettings.SeoSetting.CopyrightText);

        if (HideSeoInformation) {
          DescriptionTag.Visible = false;
          KeywordsTag.Visible = false;
          return;
        }

        if (string.IsNullOrEmpty(Description))
          Description = SiteSettings.SeoSetting.SiteDescription;
        DescriptionTag.Content = string.Concat(SiteSettings.SeoSetting.SiteDescription, " ", Description);
        //if there is no description then hide the meta tag.
        DescriptionTag.Visible = !string.IsNullOrEmpty(Description);

        if (KeyWords.Count > 0) {
          KeywordsTag.Content = string.Join(",", KeyWords.ToArray()).Replace(",,", ",");
          if (KeywordsTag.Content.StartsWith(",", StringComparison.InvariantCulture))
            KeywordsTag.Content = KeywordsTag.Content.Remove(0, 1);
        }
        //if there is no keywords then hide the meta tag.
        KeywordsTag.Visible = !string.IsNullOrEmpty(KeywordsTag.Content.Trim());
      }
      catch (Exception ex) {
        Logger.Error(typeof(site).Name + ".LoadSeoContent", ex);
        throw;
      }
    }

    #endregion

    #endregion

    #region Properties

    /// <summary>
    /// Gets the script manager.
    /// </summary>
    /// <value>The script manager.</value>
    public ScriptManager ScriptManager {
      get {
        return scriptManager;
      }
    }

    #endregion

  }
}
