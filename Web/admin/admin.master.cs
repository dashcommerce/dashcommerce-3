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
using System.Web;
using System.Web.UI.WebControls;

using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store.Web;

namespace MettleSystems.dashCommerce.Web.admin {
  public partial class admin : AdminMasterPage {

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      base.MessageCenter.Title = LocalizationUtility.GetText("pnlMessageCenter");
      divMessageCenter.Controls.Add(base.MessageCenter);
    }

    /// <summary>
    /// Called when [menu item data bound].
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.MenuEventArgs"/> instance containing the event data.</param>
    protected void OnMenuItemDataBound(object sender, MenuEventArgs e) {
      SiteMapNode siteMapNode =  (SiteMapNode)e.Item.DataItem;
      string target = siteMapNode["target"];
      string tooltip = siteMapNode["tooltip"];
      if (!string.IsNullOrEmpty(target)) {
        e.Item.Target = target;
      }
      if (!string.IsNullOrEmpty(tooltip)) {
        e.Item.ToolTip = tooltip;
      }
    }

    #endregion

  }
}
