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
