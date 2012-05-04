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
using System.Configuration;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml.Xsl;

namespace MettleSystems.dashCommerce.Web {
  public class RewriteService {

    #region Const

    private const string REWRITE_URL_TEMPLATE = "{0}/{1}/{2}{3}";
    private const string REWRITE_URL_CONFIG_NAME = "rewriteUrlTemplate";
    //private const bool USE_REWRITE = true;//TODO: Move to SiteSettings
    private const string REWRITE_REPLACE_SPACES = "-";//TODO: Move to SiteSettings
    private const char REWRITE_REPLACE_INVALID = ' ';
    private const string INVALID_URLS_CHARS = "?\\/><$!%^*&:\"{}[|#";

    #endregion

    #region Member Variables

    private static RewriteService _rewriteService;
    private static string _rewriteUrlTemplate;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the rewrite URL template.
    /// </summary>
    /// <value>The rewrite URL template.</value>
    private static string RewriteUrlTemplate {
      get {
        if (string.IsNullOrEmpty(_rewriteUrlTemplate)) {
          if (ConfigurationManager.AppSettings[REWRITE_URL_CONFIG_NAME] != null)
            _rewriteUrlTemplate = ConfigurationManager.AppSettings[REWRITE_URL_CONFIG_NAME];
          //else if (ConfigurationManager.AppSettings["rewirteUrlTemplate"] != null)
          //    _rewriteUrlTemplate = ConfigurationManager.AppSettings["rewirteUrlTemplate"];
          else
            _rewriteUrlTemplate = REWRITE_URL_TEMPLATE;
        }
        return _rewriteUrlTemplate;
      }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Builds the product URL.
    /// </summary>
    /// <param name="productId">The product id.</param>
    /// <param name="userFriendlyName">A user friendly name.</param>
    /// <returns></returns>
    public static string BuildProductUrl(string productId, string userFriendlyName) {
      return BuildGenericRewriteUrl("Product", userFriendlyName, productId, "pid", "product");
    }

    /// <summary>
    /// Builds the catalog URL.
    /// </summary>
    /// <param name="categoryId">The category id.</param>
    /// <param name="userFriendlyName">A user friendly name.</param>
    /// <returns></returns>
    public static string BuildCatalogUrl(string categoryId, string userFriendlyName) {
      return BuildGenericRewriteUrl("Catalog", userFriendlyName, categoryId, "cid", "catalog");
    }

    /// <summary>
    /// Builds the catalog URL.
    /// </summary>
    /// <param name="categoryId">The category id.</param>
    /// <param name="userFriendlyName">Name of the user friendly.</param>
    /// <param name="additionalQueryStrings">The additional query strings.</param>
    /// <returns></returns>
    public static string BuildCatalogUrl(string categoryId, string userFriendlyName, string additionalQueryStrings) {
      return BuildGenericRewriteUrl("Catalog", userFriendlyName, categoryId, "cid", "catalog", additionalQueryStrings);
    }

    /// <summary>
    /// Builds the content page URL.
    /// </summary>
    /// <param name="pageId">The page id.</param>
    /// <param name="userFriendlyName">A user friendly name.</param>
    /// <returns></returns>
    public static string BuildContentPageUrl(string pageId, string userFriendlyName) {
      return BuildGenericRewriteUrl("Page", userFriendlyName, pageId, "pageId", "default");
    }

    /// <summary>
    /// Builds a generic rewrite URL with the Template from <see cref="REWRITE_URL_TEMPLATE"/>.
    /// </summary>
    /// <param name="pageName">Name of the page.</param>
    /// <param name="userFriendlyName">Name of the user friendly.</param>
    /// <param name="itemId">The item id.</param>
    /// <param name="itemQueryStringName">Name of the item query string.</param>
    /// <param name="originalPage">The original page.</param>
    /// <returns></returns>
    public static string BuildGenericRewriteUrl(string pageName, string userFriendlyName, string itemId, string itemQueryStringName, string originalPage) {
      return BuildGenericRewriteUrl(pageName, userFriendlyName, itemId, itemQueryStringName, originalPage, null);
    }

    /// <summary>
    /// Builds the generic rewrite URL.
    /// </summary>
    /// <param name="pageName">Name of the page.</param>
    /// <param name="userFriendlyName">Name of the user friendly.</param>
    /// <param name="itemId">The item id.</param>
    /// <param name="itemQueryStringName">Name of the item query string.</param>
    /// <param name="originalPage">The original page.</param>
    /// <param name="additionalQueryStrings">The additional query strings.</param>
    /// <returns></returns>
    public static string BuildGenericRewriteUrl(string pageName, string userFriendlyName, string itemId, string itemQueryStringName, string originalPage, string additionalQueryStrings) {
      string queryString = string.Empty;

      //if (USE_REWRITE) {
        if (!string.IsNullOrEmpty(additionalQueryStrings))
          queryString = additionalQueryStrings.StartsWith("?") ? additionalQueryStrings : string.Concat("?", additionalQueryStrings);
        return "~/" + string.Format(RewriteUrlTemplate, pageName, CleanRewriteUrl(userFriendlyName), itemId, queryString);
      //}
      //else {
      //  if (additionalQueryStrings != null)
      //    queryString = additionalQueryStrings.StartsWith("?") ? additionalQueryStrings.Replace("?", "&") : string.Concat("&", additionalQueryStrings);
      //  return string.Concat(string.Format("~/{0}.aspx?{1}={2}", originalPage, itemQueryStringName, itemId), queryString);
      //}
    }

    /// <summary>
    /// Adds the rewrite namespace so that it can be used from within XSLT.
    /// </summary>
    /// <param name="xmlDataSource">The XML data source.</param>
    public static void AddRewriteNameSpaceForXslt(XmlDataSource xmlDataSource) {
      if (_rewriteService == null)
        _rewriteService = new RewriteService();
      if (xmlDataSource.TransformArgumentList == null)
        xmlDataSource.TransformArgumentList = new XsltArgumentList();

      xmlDataSource.TransformArgumentList.AddExtensionObject("dc:urlRewrite", _rewriteService);
    }

    /// <summary>
    /// Cleans the rewrite URL from invalid Char's.
    /// </summary>
    /// <param name="urlToClean">The URL to clean.</param>
    /// <returns></returns>
    private static string CleanRewriteUrl(string urlToClean) {
      if (string.IsNullOrEmpty(urlToClean))
        return urlToClean;
      //maybe just this one line:) should work?
      //return SubSonic.Sugar.Strings.Squeeze(String.Join(REWRITE_REPLACE_INVALID.ToString(), urlToClean.Replace("'", "").Split(INVALID_URLS_CHARS.ToCharArray()))).Replace(" ", REWRITE_REPLACE_SPACES);

      StringBuilder sb = new StringBuilder(urlToClean);
      sb.Replace("'", "");
      for (int i = 0; i < INVALID_URLS_CHARS.Length; i++) {
        sb.Replace(INVALID_URLS_CHARS[i], REWRITE_REPLACE_INVALID);
      }
      return SubSonic.Sugar.Strings.Squeeze(sb.ToString()).Replace(" ", REWRITE_REPLACE_SPACES);
    }

    #endregion

    #region Instance Class Members (Used for XSLT)

    /// <summary>
    /// Products the URL.
    /// </summary>
    /// <param name="productId">The product id.</param>
    /// <param name="userFriendlyName">Name of the user friendly.</param>
    /// <returns></returns>
    public string ProductUrl(string productId, string userFriendlyName) {
      return RewriteService.BuildProductUrl(productId, userFriendlyName);
    }

    /// <summary>
    /// Catalogs the URL.
    /// </summary>
    /// <param name="categoryId">The category id.</param>
    /// <param name="userFriendlyName">Name of the user friendly.</param>
    /// <returns></returns>
    public string CatalogUrl(string categoryId, string userFriendlyName) {
      return RewriteService.BuildCatalogUrl(categoryId, userFriendlyName);
    }

    /// <summary>
    /// Catalogs the URL.
    /// </summary>
    /// <param name="categoryId">The category id.</param>
    /// <param name="userFriendlyName">Name of the user friendly.</param>
    /// <param name="additionalQueryStrings">The additional query strings.</param>
    /// <returns></returns>
    public string CatalogUrl(string categoryId, string userFriendlyName, string additionalQueryStrings) {
      return RewriteService.BuildCatalogUrl(categoryId, userFriendlyName, additionalQueryStrings);
    }

    /// <summary>
    /// Contents the page URL.
    /// </summary>
    /// <param name="pageId">The page id.</param>
    /// <param name="userFriendlyName">Name of the user friendly.</param>
    /// <returns></returns>
    public string ContentPageUrl(string pageId, string userFriendlyName) {
      return RewriteService.BuildContentPageUrl(pageId, userFriendlyName);
    }

    #endregion
  }
}
