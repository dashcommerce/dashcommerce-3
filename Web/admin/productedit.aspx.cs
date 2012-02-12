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

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin {
  public partial class productedit : MettleSystems.dashCommerce.Store.Web.AdminPage {

    #region Member Variables

    private int productId = 0;
    private string view = string.Empty;
    private Product product;

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load (object sender, EventArgs e) {
      try {
        productId = Utility.GetIntParameter("productId");
        view = Utility.GetParameter("view");
        if (productId > 0) {
          product = new Product(productId);
          lblProductEdit.Text = LocalizationUtility.GetText("lblProductEdit") + " >> " + product.Name;
          if(!product.IsEnabled) {
            lblProductEdit.Text += " " + LocalizationUtility.GetText("lblProductNotEnabled");
          }
          productNavigation.Visible = true;
        }
        else {
          lblProductEdit.Text = LocalizationUtility.GetText("lblProductAdd");
        }
        switch (view) {
          case "g":
            generalInformation.Visible = true;
            break;
          case "d":
            descriptors.Visible = true;
            break;
          case "c":
            categories.Visible = true;
            break;
          case "a":
            attributes.Visible = true;
            break;
          case "i":
            images.Visible = true;
            break;
          case "s":
            skus.Visible = true;
            break;
          case "cs":
            crossSells.Visible = true;
            break;
          case "r":
            reviews.Visible = true;
            break;
          case "n":
            notes.Visible = true;
            break;
          case "dl":
            downloads.Visible = true;
            break;
          default:
            generalInformation.Visible = true;
            break;
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(productedit).Name + ".Page_Load", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    #endregion
    
  }
}
