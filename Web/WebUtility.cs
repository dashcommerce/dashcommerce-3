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
using System.Configuration;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Store;
//using MettleSystems.dashCommerce.Store.Profile;

namespace MettleSystems.dashCommerce.Web {
  public class WebUtility {

    #region Const

    private const string MAIN_TITLE_TEMPLATE = "{0} :: {1}";

    #endregion

    #region Methods

    #region Public

    /// <summary>
    /// Gets the name of the user.
    /// If the User didn't login it will return a Anonymous ID.
    /// If its the first Request to the site then it will give the user an Anonymous ID.
    /// </summary>
    /// <returns></returns>
    public static string GetUserName() {
      string userName = HttpContext.Current.Profile.UserName;
      if (HttpContext.Current.User.Identity.IsAuthenticated) {
        userName = HttpContext.Current.User.Identity.Name;
      }
      if (!HttpContext.Current.User.Identity.IsAuthenticated) {
        HttpCookie cookie = HttpContext.Current.Response.Cookies.Get(FormsAuthentication.FormsCookieName);
        if (cookie != null) {
          if (!string.IsNullOrEmpty(cookie.Value)) {
            userName = FormsAuthentication.Decrypt(cookie.Value).Name;
          }
        }
      }
      return userName;
    }

    /// <summary>
    /// Gets the Current Session id.
    /// </summary>
    /// <returns>The SessionID of the current request.</returns>
    public static string SessionId() {
      return System.Web.HttpContext.Current.Session.SessionID;
    }

    /// <summary>
    /// Ensures that the browser is connected using SSL if not it redirects the browser to https://CURRENT_URL.
    /// It does not redirect if the request is coming from the same IP as the site (development mode (i.e. localhost)).
    /// </summary>
    public static void EnsureSsl() {
      Uri currentUrl = HttpContext.Current.Request.Url;
      if (!currentUrl.IsLoopback) {//Don't check when in development mode (i.e. localhost)
        if (!currentUrl.Scheme.Equals("https", StringComparison.CurrentCultureIgnoreCase) && HttpContext.Current.Request.ServerVariables["HTTP_CLUSTER_HTTPS"] != "on") {
          UriBuilder uriBuilder = new UriBuilder(currentUrl);
          uriBuilder.Scheme = "https";
          uriBuilder.Port = -1;
          HttpContext.Current.Response.Redirect(uriBuilder.Uri.ToString(), true);
        }
      }
    }

    public static string CurrentUrl {
      get {
        return HttpContext.Current.Request.Url.ToString();
      }
    }

    /// <summary>
    /// Removes the QueryString from the URL of the Current Request.
    /// </summary>
    /// <returns></returns>
    public static string ScrubUrl() {
      string url = HttpContext.Current.Request.Url.ToString();
      int resultPosition = url.IndexOf("?");
      if (resultPosition > -1) {
        url = url.Substring(0, resultPosition);
      }
      return url;
    }

    //Many thanks to Paul Ingles for this Code
    //http://www.codeproject.com/aspnet/creditcardvalidator.asp
    //Modified by Spook, 3/2006
    /// <summary>
    /// Determines whether <see cref="cardNumber"/> is a valid for the <see cref="cardType"/>.
    /// </summary>
    /// <param name="cardNumber">The card number.</param>
    /// <param name="cardType">Type of the card.</param>
    /// <returns>
    /// 	<c>true</c> if [is valid card type] [the specified card number]; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsValidCardType(string cardNumber, CreditCardType cardType) {
      bool validCardType = true;

      // AMEX -- 34 or 37 -- 15 length
      if (Regex.IsMatch(cardNumber, "^(34|37)") && (cardType == CreditCardType.Amex))
        validCardType = 15 == cardNumber.Length;

      // MasterCard -- 51 through 55 -- 16 length
      else if (Regex.IsMatch(cardNumber, "^(51|52|53|54|55)") && (cardType == CreditCardType.MasterCard))
        validCardType = 16 == cardNumber.Length;

      // VISA -- 4 -- 13 and 16 length
      else if (Regex.IsMatch(cardNumber, "^(4)") && (cardType == CreditCardType.VISA))
        validCardType = 13 == cardNumber.Length || 16 == cardNumber.Length;

      // Discover -- 6011 -- 16 length
      else if (Regex.IsMatch(cardNumber, "^(6011)") && (cardType == CreditCardType.Discover))
        validCardType = 16 == cardNumber.Length;

      return validCardType;
    }

    /// <summary>
    /// Adds and removes keys from the QueryString using the passed in values.
    /// Adding/Updating the <see cref="keyToAdd"/> in the result.
    /// Removing the values that are in <see cref="keysToRemove"/> from the result.
    /// </summary>
    /// <param name="queryString">The query string.</param>
    /// <param name="keyToAdd">The key to add.</param>
    /// <param name="valueToAdd">The value to add.</param>
    /// <param name="keysToRemove">The keys to remove.</param>
    /// <returns>Return a string formated as a QueryString</returns>
    public static string AddRemoveFromQueryString(NameValueCollection queryString, string keyToAdd, string valueToAdd, params string[] keysToRemove) {
      StringBuilder queryStringText = new StringBuilder("?");
      const string QUERYSTRING_FORMAT = "{0}={1}";
      string currentKey;
      List<string> removeStrings = new List<string>(keysToRemove);

      for (int i = 0; i < queryString.Count; i++) {
        currentKey = queryString.GetKey(i);
        if (removeStrings.Contains(currentKey) || currentKey == keyToAdd)
          continue;
        queryStringText.Append(string.Format(QUERYSTRING_FORMAT, queryString.GetKey(i), queryString.Get(i)));
        queryStringText.Append("&");
      }
      queryStringText.Append(string.Format(QUERYSTRING_FORMAT, keyToAdd, valueToAdd));
      return queryStringText.ToString();
    }

    /// <summary>
    /// Gets and creates thumbnail.
    /// </summary>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    /// <param name="imagePath">The image path.</param>
    /// <returns></returns>
    public static string GetAndCreateProductThumbnail(int width, int height, string imagePath) {
      string thumbnail = imagePath.Replace("product/", string.Format("product/thumbs/{0}x{1}_", width, height));
      HttpServerUtility server = CurrentHttpContext.Server;
      if (!File.Exists(server.MapPath(thumbnail))) {
        if (File.Exists(server.MapPath(imagePath))) {
          //Thumbnails don't exist so lets generate them...
          string fileName = imagePath.Substring(imagePath.LastIndexOf("/") + 1);
          using (FileStream fs = File.Open(server.MapPath(imagePath), FileMode.Open, FileAccess.Read, FileShare.None)) {
            ImageProcess.ResizeAndSave(fs, fileName, server.MapPath(@"~/repository/product/thumbs/"), width, height);
          }
        }
        else {
          return imagePath;
        }
      }
      return thumbnail;
    }

    #endregion

    #endregion

    #region Properties

    /// <summary>
    /// Gets the main title template.
    /// </summary>
    /// <value>The main title template.</value>
    public static string MainTitleTemplate {
      get {
        //Get this from a Resource language file or from the SiteSettings.
        return MAIN_TITLE_TEMPLATE;
      }
    }

    /// <summary>
    /// Gets the current HTTP context.
    /// </summary>
    /// <value>The current HTTP context.</value>
    public static HttpContext CurrentHttpContext {
      get {
        return HttpContext.Current;
      }
    }

    public static bool ConnectionStringExists {
      get {
        //return !string.IsNullOrEmpty(ConfigurationManager.ConnectionStrings["dashCommerce"].ConnectionString);
        bool connectionStringExists = false;
        //this is a hack because the AspNetSqlRoleProvider is throwing an error if it's "" (empty);
        if (string.IsNullOrEmpty(ConfigurationManager.ConnectionStrings["dashCommerce"].ConnectionString) || ConfigurationManager.ConnectionStrings["dashCommerce"].ConnectionString.ToUpper().Equals("SOMETEXT")) {
          return connectionStringExists;
        }
        else {
          return true;
        }
      }
    }

    public static string ConnectionString {
      get {
        return ConfigurationManager.ConnectionStrings["dashCommerce"].ConnectionString;
      }
    }
    #endregion

  }
}
