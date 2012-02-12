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
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Web.Controls;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin.controls.product {
  public partial class reviews : AdminControl {

    #region Member Variables

    private int productId = 0;
    private string view = string.Empty;

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
        if(view == "r") {
          SetReviewProperties();
          if(!Page.IsPostBack) {
            LoadReviews();
          }
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(reviews).Name + ".Page_Load", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the lbEdit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.CommandEventArgs"/> instance containing the event data.</param>
    protected void lbEdit_Click(object sender, CommandEventArgs e) {
      try {
        int reviewId = 0;
        bool isParsed = int.TryParse(e.CommandArgument.ToString(), out reviewId);
        if (isParsed) {
          pnlReview.Visible = true;
          Review review = new Review(reviewId);
          lblReviewId.Text = review.ReviewId.ToString();
          txtTitle.Text = review.Title;
          txtReview.InnerText = review.Body;
          lblRatingText.Text = review.Rating.ToString();
          chkIsApproved.Checked = review.IsApproved;
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(reviews).Name + ".lbEdit_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the lbDelete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.CommandEventArgs"/> instance containing the event data.</param>
    protected void lbDelete_Click(object sender, CommandEventArgs e) {
      try {
        int reviewId = 0;
        bool isParsed = int.TryParse(e.CommandArgument.ToString(), out reviewId);
        if(isParsed) {
          Review.Delete(reviewId);
          LoadReviews();
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(reviews).Name + ".lbDelete_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e) {
      try {
        int reviewId = 0;
        int.TryParse(lblReviewId.Text, out reviewId);
        if (reviewId > 0) {
          Review review = new Review(reviewId);
          review.IsApproved = chkIsApproved.Checked;
          review.Save(WebUtility.GetUserName());
          Product product = new Product(productId);
          product.RatingSum = product.RatingSum + review.Rating;
          product.TotalRatingVotes = product.TotalRatingVotes + 1;
          product.Save(WebUtility.GetUserName());
          Store.Caching.ProductCache.RemoveReviewCollectionFromCache(productId);
          LoadReviews();
          Reset();
          base.MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblReviewSaved"));
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(reviews).Name + ".btnSave_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the ItemDataBound event of the dgReviews control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridItemEventArgs"/> instance containing the event data.</param>
    void dgReviews_ItemDataBound(object sender, DataGridItemEventArgs e) {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        LinkButton editButton = e.Item.Cells[0].FindControl("lbEdit") as LinkButton;
        if (editButton != null) {
          editButton.Text = LocalizationUtility.GetText("lblEdit");
        }
        LinkButton deleteButton = e.Item.Cells[6].FindControl("lbDelete") as LinkButton;
        if(deleteButton != null) {
          deleteButton.Text = LocalizationUtility.GetText("lblDelete");
          deleteButton.Attributes.Add("onclick", "return confirm(\"" + LocalizationUtility.GetText("lblConfirmDelete") + "\");return false;");
        }
      }
    }

    #endregion

    #region Methods

    #region Protected

    /// <summary>
    /// Gets the body sample.
    /// </summary>
    /// <param name="bodyText">The body text.</param>
    /// <returns></returns>
    protected string GetBodySample(string bodyText) {
      string paddedBodyText = bodyText.PadRight(50);
      return paddedBodyText.Substring(0, 49);
    }

    #endregion

    #region Private

    /// <summary>
    /// Sets the review properties.
    /// </summary>
    private void SetReviewProperties() {
      this.Page.Title = LocalizationUtility.GetText("titleProductEditReviews");    
    }

    /// <summary>
    /// Loads the reviews.
    /// </summary>
    private void LoadReviews() {
      ReviewCollection reviewCollection = new ReviewController().FetchByProductId(productId);
      if(reviewCollection.Count > 0) {
        dgReviews.Visible = true;
        dgReviews.DataSource = reviewCollection;
        dgReviews.ItemDataBound += new DataGridItemEventHandler(dgReviews_ItemDataBound);
        dgReviews.Columns[0].HeaderText = LocalizationUtility.GetText("hdrEdit");
        dgReviews.Columns[1].HeaderText = LocalizationUtility.GetText("hdrApproved");
        dgReviews.Columns[2].HeaderText = LocalizationUtility.GetText("hdrTitle");
        dgReviews.Columns[3].HeaderText = LocalizationUtility.GetText("hdrReviewSample");
        dgReviews.Columns[4].HeaderText = LocalizationUtility.GetText("hdrCreatedBy");
        dgReviews.Columns[5].HeaderText = LocalizationUtility.GetText("hdrCreatedDate");
        dgReviews.Columns[6].HeaderText = LocalizationUtility.GetText("hdrDelete");
        dgReviews.DataBind();
      }
      else {
        dgReviews.Visible = false;
        base.MasterPage.MessageCenter.DisplayInformationMessage(LocalizationUtility.GetText("lblNoReviews"));
      }
    }

    /// <summary>
    /// Resets this instance.
    /// </summary>
    private void Reset() {
      lblReviewId.Text = string.Empty;
      txtTitle.Text = string.Empty;
      lblRatingText.Text = string.Empty;
      chkIsApproved.Checked = false;
      pnlReview.Visible = false;
    }

    #endregion

    #endregion

  }
}
