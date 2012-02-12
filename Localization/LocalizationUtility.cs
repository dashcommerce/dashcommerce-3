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
using System.Web.UI.WebControls;

using MettleSystems.dashCommerce.Localization.resources;

namespace MettleSystems.dashCommerce.Localization {

  public class LocalizationUtility {
  
    #region Methods
    
    #region Public

    /// <summary>
    /// Adds the hover HTML.
    /// </summary>
    /// <param name="hyperlink">The hyperlink.</param>
    /// <param name="html">The HTML.</param>
    public static void AddHoverHtml(HyperLink hyperlink, string html) {
      hyperlink.Attributes.Add("onmouseover", string.Format(Overlib.SIMPLE, html));
      hyperlink.Attributes.Add("onmouseout", Overlib.MOUSEOUT);
    }


    /// <summary>
    /// Adds the image alternate text.
    /// </summary>
    /// <param name="image">The image.</param>
    public static void AddImageAlternateText(System.Web.UI.WebControls.Image image) {
      image.AlternateText = labels.ResourceManager.GetString(image.ID);
    }

    /// <summary>
    /// Gets the text.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns></returns>
    public static string GetText(string name) {
      return labels.ResourceManager.GetString(name);
    }

    /// <summary>
    /// Gets the help text.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns></returns>
    public static string GetHelpText(string name) {
      return help.ResourceManager.GetString(name);
    }

    /// <summary>
    /// Gets the critical message text.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <returns></returns>
    public static string GetCriticalMessageText(string message) {
      return string.Format(GetText("lblCriticalError"), message);
    }

    /// <summary>
    /// Gets the payment provider error text.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <returns></returns>
    public static string GetPaymentProviderErrorText(string message) {
      return string.Format(GetText("lblPaymentProviderError"), message);
    }
    
    #endregion
    
    #endregion
      
  }
}
