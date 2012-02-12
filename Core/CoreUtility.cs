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
using System.Text.RegularExpressions;

namespace MettleSystems.dashCommerce.Core {
  
  public class CoreUtility {
  
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

    #endregion

    #endregion

  }
}
