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

using SubSonic;

namespace MettleSystems.dashCommerce.Store {
  public partial class ReviewController {

    #region Methods

    #region Public

    /// <summary>
    /// Fetch by product id.
    /// </summary>
    /// <param name="productId">The product id.</param>
    /// <returns></returns>
    public ReviewCollection FetchByProductId(int productId) {
      ReviewCollection reviewCollection = new ReviewCollection().
        Where(Review.Columns.ProductId, Comparison.Equals, productId).
        Load();
      return reviewCollection;
    }

    /// <summary>
    /// Fetch by product id and is approved.
    /// </summary>
    /// <param name="productId">The product id.</param>
    /// <returns></returns>
    public ReviewCollection FetchByProductIdAndIsApproved(int productId) {
      ReviewCollection reviewCollection = new ReviewCollection().
        Where(Review.Columns.ProductId, Comparison.Equals, productId).
        Where(Review.Columns.IsApproved, Comparison.Equals, true).
        Load();
      return reviewCollection;
    }

    /// <summary>
    /// Fetches by product id and user id.
    /// </summary>
    /// <param name="productId">The product id.</param>
    /// <param name="userId">The user id.</param>
    /// <returns></returns>
    public Review FetchByProductIdAndUserId(int productId, string userId) {
      Review review = null;
      ReviewCollection reviewCollection = new ReviewCollection().
        Where(Review.Columns.ProductId, productId).
        Where(Review.Columns.CreatedBy, userId).
        Load();
      if(reviewCollection.Count > 0) {
        review = reviewCollection[0];
      }
      return review;
    }

    #endregion

    #region Static Methods

    /// <summary>
    /// Checks if the user submitted a review for the passed in <see cref="productId"/>.
    /// </summary>
    /// <param name="productId">The product id.</param>
    /// <param name="userName">The Name of the user.</param>
    /// <returns>[True] if the user already submitted a review for <see cref="productId"/>.</returns>
    public static bool UserReviewedProduct(int productId, string userName) {
      return new Query(Review.Schema)
        .AddWhere(Review.Columns.ProductId, productId)
        .AddWhere(Review.Columns.CreatedBy, userName)
        .GetCount(Review.Columns.ReviewId) > 0;
    }

    #endregion

    #endregion

  }
}
