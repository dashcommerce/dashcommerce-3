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
  public partial class simpleweightshippingprovider : System.Web.UI.UserControl {

    #region Member Variables

    int providerId = 0;

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      providerId = Utility.GetIntParameter("providerId");
      simpleWeightShippingProviderMenu.MenuItemDataBound += new MenuEventHandler(simpleWeightShippingProviderMenu_MenuItemDataBound);
      simpleWeightShippingProviderMenu.PreRender += new EventHandler(simpleWeightShippingProviderMenu_PreRender);
    }

    /// <summary>
    /// Handles the MenuItemDataBound event of the simpleWeightShippingProviderMenu control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.MenuEventArgs"/> instance containing the event data.</param>
    void simpleWeightShippingProviderMenu_MenuItemDataBound(object sender, MenuEventArgs e) {
      e.Item.NavigateUrl = e.Item.NavigateUrl + string.Format("&providerId={0}", providerId);
    }

    /// <summary>
    /// Handles the PreRender event of the simpleWeightShippingProviderMenu control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    void simpleWeightShippingProviderMenu_PreRender(object sender, EventArgs e) {
      if (simpleWeightShippingProviderMenu.SelectedItem == null) {
        simpleWeightShippingProviderMenu.Items[0].Selected = true;
      }
    }

    #endregion

  }
}