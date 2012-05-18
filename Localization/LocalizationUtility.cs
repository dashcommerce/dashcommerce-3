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
