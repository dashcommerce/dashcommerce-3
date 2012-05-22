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

using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web {
  public partial class review : MettleSystems.dashCommerce.Store.Web.SitePage {

    #region Member Variables

    private int productId = 0;
    Product _product;

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      productId = Utility.GetIntParameter("pid");
      if (productId > 0) {
        SetReviewProperties();
        _product = new Product(productId);
        if (!ReviewController.UserReviewedProduct(_product.ProductId, WebUtility.GetUserName())) {
          lblName.Text = _product.Name;
        }
        else {
          pnlReview.Visible = false;
          lblAlreadyReviewed.Visible = true;
        }
        Page.Title = string.Format(LocalizationUtility.GetText("titleReview"), _product.Name.PadRight(30).Substring(0, 30).Trim());
      }
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e) {
      if (!string.IsNullOrEmpty(txtTitle.Text) && !string.IsNullOrEmpty(txtReview.Text)) {
        //Check again just in case the user submitted a review from a second window.
        if (ReviewController.UserReviewedProduct(_product.ProductId, WebUtility.GetUserName())) {
          lblAlreadyReviewed.Visible = true;
        }
        else {
          Review review = new Review();
          review.ProductId = _product.ProductId;
          review.Rating = reviewRating.CurrentRating;
          review.Title = txtTitle.Text.Trim();
          review.Body = txtReview.Text;
          review.Save(WebUtility.GetUserName());
          lblReviewSaved.Visible = true;
        }
        pnlReview.Visible = false;
      }
    }

    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Sets the review properties.
    /// </summary>
    private void SetReviewProperties() {
      
      
      
      
      
    }

    #endregion

    #endregion

  }
}
