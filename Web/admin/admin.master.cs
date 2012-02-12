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
