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

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;

namespace MettleSystems.dashCommerce.Web.controls.navigation {
  public partial class review : System.Web.UI.UserControl {

    #region Member Variables

    private Product product;
    public Product Product {
      get {
        return product;
      }
      set {
        product = value;
      }
    }

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        if (product != null) {
          hlReview.NavigateUrl = string.Format("~/review.aspx?pid={0}{1}", product.ProductId, "&KeepThis=true&TB_iframe=true&height=450&width=400");
          hlReview.ToolTip = string.Format(LocalizationUtility.GetText("titleReview"), product.Name.PadRight(30).Substring(0, 30).Trim());
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(review).Name + "Page_Load", ex);
      }
    }

    #endregion

  }
}