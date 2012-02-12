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