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