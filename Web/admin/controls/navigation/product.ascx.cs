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
using System.Web.UI;
using System.Web.UI.WebControls;

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Store.Web.Controls;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin.controls.navigation {
  public partial class product : AdminControl {
    
    #region Member Variables
    
    int productId = 0;
    string view = string.Empty;
    
    #endregion
    
    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        productId = Utility.GetIntParameter("productId");
        view = Utility.GetParameter("view");
        productMenu.MenuItemDataBound += new MenuEventHandler(productMenu_MenuItemDataBound);
        productMenu.DataBound += new EventHandler(productMenu_DataBound);
      }
      catch(Exception ex) {
        Logger.Error(typeof(product).Name + ".Page_Load", ex);
        MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the DataBound event of the productMenu control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    void productMenu_DataBound(object sender, EventArgs e) {
      switch(view) {
        case "g":
          productMenu.Items[0].Selected = true;
          break;
        case "d":
          productMenu.Items[0].ChildItems[0].Selected = true;
          break;
        case "c":
          productMenu.Items[0].ChildItems[1].Selected = true;
          break;
        case "a":
          productMenu.Items[0].ChildItems[2].Selected = true;
          break;
        case "i":
          productMenu.Items[0].ChildItems[3].Selected = true;
          break;
        case "s":
          productMenu.Items[0].ChildItems[4].Selected = true;
          break;
        case "dl":
          productMenu.Items[0].ChildItems[5].Selected = true;
          break;
        case "cs":
          productMenu.Items[0].ChildItems[6].Selected = true;
          break;
        case "r":
          productMenu.Items[0].ChildItems[7].Selected = true;
          break;
        case "n":
          productMenu.Items[0].ChildItems[8].Selected = true;
          break;
        default:
          productMenu.Items[0].Selected = true;
          break;
      }
    }

    /// <summary>
    /// Handles the MenuItemDataBound event of the productMenu control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.MenuEventArgs"/> instance containing the event data.</param>
    void productMenu_MenuItemDataBound(object sender, MenuEventArgs e) {
      e.Item.NavigateUrl = e.Item.NavigateUrl + string.Format("&productId={0}", productId);
    }

    #endregion
    
  }
}