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
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace MettleSystems.dashCommerce.Core {
  
  public class CoreUtility {

    private static readonly int DEFAULTTIMEOUT = 100000;

    #region Methods
  
    #region Public

    /// <summary>
    /// Makes the HTTPS URL.
    /// </summary>
    /// <param name="url">The URL.</param>
    /// <returns></returns>
    public static string MakeHttpsUrl(string url) {
      UriBuilder secureUri = new UriBuilder(url);
      secureUri.Scheme = "https";
      secureUri.Port = -1;
      return secureUri.Uri.ToString();
    }

    /// <summary>
    /// Strips the HTML.
    /// </summary>
    /// <param name="htmlString">The HTML string.</param>
    /// <param name="htmlPlaceHolder">The HTML place holder.</param>
    /// <returns></returns>
    public static string StripHtml(string htmlString, string htmlPlaceHolder) {
      string pattern = @"<(.|\n)*?>";
      string sOut = Regex.Replace(htmlString, pattern, htmlPlaceHolder);
      sOut = sOut.Replace("&nbsp;", "");
      sOut = sOut.Replace("&amp;", "&");
      sOut = sOut.Replace("&gt;", ">");
      sOut = sOut.Replace("&lt;", "<");
      return sOut;
    }

    /// <summary>
    /// Parses the camel cased string to proper.
    /// </summary>
    /// <param name="sIn">The s in.</param>
    /// <returns></returns>
    public static string ParseCamelToProper(string sIn) {
      char[] letters = sIn.ToCharArray();
      string sOut = "";
      foreach(char c in letters) {
        if(c.ToString() != c.ToString().ToLower()) {
          //it's uppercase, add a space
          sOut += " " + c.ToString();
        }
        else {
          sOut += c.ToString();
        }
      }
      return sOut;
    }

    /// <summary>
    /// Generates a random string.
    /// </summary>
    /// <param name="length">The length.</param>
    /// <returns></returns>
    public static string GenerateRandomString(int length) {
      string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
      string randomString = string.Empty;
      if (length > 0) {
        Random rnd = new Random();
        for (int i = 0; i < length; i++) {
          randomString += chars[rnd.Next(chars.Length)];
        }
      }
      return randomString;
    }



    /// <summary>
    /// Generates a 4 by 4 masked string.
    /// </summary>
    /// <returns></returns>
    public static string Generate4By4MaskedString() {
      string chars = "1234567890";
      string randomString = string.Empty;
      Random rnd = new Random();
      for (int i = 1; i <= 16; i++) {
        randomString += chars[rnd.Next(chars.Length)];
        if (i < 16 && i % 4 == 0) {
          randomString += "-";
        }
      }
      return randomString;
    }


    public static string SendRequestByPost(string serviceUrl, string postData)
    {
        return SendRequestByPost(serviceUrl, postData, null, DEFAULTTIMEOUT);
    }

    public static string SendRequestByPost(string serviceUrl, string postData, System.Net.WebProxy proxy, int timeout)
    {
        WebResponse resp = null;
        WebRequest req = null;
        StreamReader sr = null;
        Stream outStream = null;
        string response = string.Empty;
        byte[] reqBytes = null;

        try
        {
            reqBytes = Encoding.UTF8.GetBytes(postData);
            req = WebRequest.Create(serviceUrl);
            req.Method = "POST";
            req.ContentLength = reqBytes.Length;
            req.ContentType = "application/x-www-form-urlencoded";
            req.Timeout = timeout;
            if (proxy != null)
            {
                req.Proxy = proxy;
            }
            outStream = req.GetRequestStream();
            outStream.Write(reqBytes, 0, reqBytes.Length);
            outStream.Close();
            resp = req.GetResponse();
            sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8, true);
            response += sr.ReadToEnd();
            sr.Close();
        }
        catch
        {
            throw;
        }
        finally
        {
            if (outStream != null)
            {
                outStream.Dispose();
                outStream = null;
            }
            if (sr != null)
            {
                sr.Dispose();
                sr = null;
            }
        }
        return response;
    }

    #endregion

    #endregion

  }
}
