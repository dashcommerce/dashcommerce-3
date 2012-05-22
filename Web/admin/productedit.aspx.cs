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
