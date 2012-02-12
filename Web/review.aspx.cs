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
