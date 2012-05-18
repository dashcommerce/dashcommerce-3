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
using System.Web.UI.WebControls;

using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin.controls.navigation {
  public partial class regioncode : System.Web.UI.UserControl {

    #region Member Variables

    string view = string.Empty;
    int providerId = 0;

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      view = Utility.GetParameter("view");
      providerId = Utility.GetIntParameter("providerId");
      regionCodeMenu.MenuItemDataBound += new MenuEventHandler(regionCodeMenu_MenuItemDataBound);
      regionCodeMenu.DataBound += new EventHandler(regionCodeMenu_DataBound);
      regionCodeMenu.PreRender += new EventHandler(regionCodeMenu_PreRender);
    }

    void regionCodeMenu_DataBound(object sender, EventArgs e) {
      switch (view) {
        case "c":
          regionCodeMenu.Items[0].Selected = true;
          break;
        case "d":
          regionCodeMenu.Items[0].ChildItems[0].Selected = true;
          break;
        default:
          regionCodeMenu.Items[0].Selected = true;
          break;
      }
    }

    /// <summary>
    /// Handles the MenuItemDataBound event of the regionCodeMenu control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.MenuEventArgs"/> instance containing the event data.</param>
    void regionCodeMenu_MenuItemDataBound(object sender, MenuEventArgs e) {
      e.Item.NavigateUrl = e.Item.NavigateUrl + string.Format("&providerId={0}", providerId);
    }

    /// <summary>
    /// Handles the PreRender event of the regionCodeMenu control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    void regionCodeMenu_PreRender(object sender, EventArgs e) {
      if(regionCodeMenu.SelectedItem == null) {
        regionCodeMenu.Items[0].Selected = true;
      }
    }
    
    #endregion
    
  }
}