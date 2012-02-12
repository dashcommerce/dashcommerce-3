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
