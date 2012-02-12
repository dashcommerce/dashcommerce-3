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

using System.Data;

namespace MettleSystems.dashCommerce.Store {

  public partial class ProductController {

    #region Methods
    
    #region Public

    /// <summary>
    /// Fetches the available downloads by product id.
    /// </summary>
    /// <param name="productId">The product id.</param>
    /// <returns></returns>
    public DownloadCollection FetchAvailableDownloadsByProductId(int productId) {
      IDataReader reader = SPs.FetchAvailableDownloadsByProductId(productId).GetReader();
      DownloadCollection artifactCollection = new DownloadCollection();
      artifactCollection.LoadAndCloseReader(reader);
      return artifactCollection;
    }

    /// <summary>
    /// Fetches the associated downloads by product id.
    /// </summary>
    /// <param name="productId">The product id.</param>
    /// <returns></returns>
    public DownloadCollection FetchAssociatedDownloadsByProductId(int productId) {
      IDataReader reader = SPs.FetchAssociatedDownloadsByProductId(productId).GetReader();
      DownloadCollection artifactCollection = new DownloadCollection();
      artifactCollection.LoadAndCloseReader(reader);
      return artifactCollection;
    }

    /// <summary>
    /// Fetches the associated downloads by product id and for purchase.
    /// </summary>
    /// <param name="productId">The product id.</param>
    /// <returns></returns>
    public DownloadCollection FetchAssociatedDownloadsByProductIdAndForPurchase(int productId) {
      IDataReader reader = SPs.FetchAssociatedDownloadsByProductIdAndForPurchase(productId).GetReader();
      DownloadCollection artifactCollection = new DownloadCollection();
      artifactCollection.LoadAndCloseReader(reader);
      return artifactCollection;
    }

    /// <summary>
    /// Fetches the associated downloads by product id and not for purchase.
    /// </summary>
    /// <param name="productId">The product id.</param>
    /// <returns></returns>
    public DownloadCollection FetchAssociatedDownloadsByProductIdAndNotForPurchase(int productId) {
      IDataReader reader = SPs.FetchAssociatedDownloadsByProductIdAndNotForPurchase(productId).GetReader();
      DownloadCollection artifactCollection = new DownloadCollection();
      artifactCollection.LoadAndCloseReader(reader);
      return artifactCollection;
    }


    /// <summary>
    /// Fetches the available attributes by product id.
    /// </summary>
    /// <param name="productId">The product id.</param>
    /// <returns></returns>
    public AttributeCollection FetchAvailableAttributesByProductId(int productId) {
      IDataReader reader = SPs.FetchAvailableAttributesByProductId(productId).GetReader();
      AttributeCollection attributeCollection = new AttributeCollection();
      attributeCollection.LoadAndCloseReader(reader);
      return attributeCollection;
    }

    /// <summary>
    /// Fetches the associated attributes by product id.
    /// </summary>
    /// <param name="productId">The product id.</param>
    /// <returns></returns>
    public AssociatedAttributeCollection FetchAssociatedAttributesByProductId(int productId) {
      IDataReader reader = SPs.FetchAssociatedAttributesByProductId(productId).GetReader();
      AssociatedAttributeCollection associatedAttributeCollection = new AssociatedAttributeCollection();
      associatedAttributeCollection.Load(reader);
      reader.Close();
      reader.Dispose();
      return associatedAttributeCollection;
    }

    /// <summary>
    /// Fetches the associated categories by product id.
    /// </summary>
    /// <param name="productId">The product id.</param>
    /// <returns></returns>
    public CategoryCollection FetchAssociatedCategoriesByProductId(int productId) {
      IDataReader reader = SPs.FetchAssociatedCategoriesByProductId(productId).GetReader();
      CategoryCollection categoryCollection = new CategoryCollection();
      categoryCollection.LoadAndCloseReader(reader);
      return categoryCollection;
    }

    /// <summary>
    /// Fetches the products by category id.
    /// </summary>
    /// <param name="categoryId">The category id.</param>
    /// <returns></returns>
    public ProductCollection FetchProductsByCategoryId(int categoryId) {
      IDataReader reader = SPs.FetchProductsByCategoryId(categoryId).GetReader();
      ProductCollection productCollection = new ProductCollection();
      productCollection.LoadAndCloseReader(reader);
      return productCollection;
    }

    /// <summary>
    /// Fetches the products by category id and manufacturer id.
    /// </summary>
    /// <param name="categoryId">The category id.</param>
    /// <param name="manufacturerId">The manufacturer id.</param>
    /// <returns></returns>
    public ProductCollection FetchProductsByCategoryIdAndManufacturerId(int categoryId, int manufacturerId) {
      IDataReader reader = SPs.FetchProductsByCategoryIdAndManufacturerId(categoryId, manufacturerId).GetReader();
      ProductCollection productCollection = new ProductCollection();
      productCollection.LoadAndCloseReader(reader);
      return productCollection;
    }

    /// <summary>
    /// Fetches the products by category id and price range.
    /// </summary>
    /// <param name="categoryId">The category id.</param>
    /// <param name="priceStart">The price start.</param>
    /// <param name="priceEnd">The price end.</param>
    /// <returns></returns>
    public ProductCollection FetchProductsByCategoryIdAndPriceRange(int categoryId, decimal priceStart, decimal priceEnd) {
      IDataReader reader = SPs.FetchProductsByCategoryIdAndPriceRange(categoryId, priceStart, priceEnd).GetReader();
      ProductCollection productCollection = new ProductCollection();
      productCollection.LoadAndCloseReader(reader);
      return productCollection;    
    }

    /// <summary>
    /// Fetches the product cross sells.
    /// </summary>
    /// <param name="productId">The product id.</param>
    /// <returns></returns>
    public ProductCollection FetchProductCrossSells(int productId) {
      IDataReader reader = SPs.FetchProductCrossSells(productId).GetReader();
      ProductCollection productCollection = new ProductCollection();
      productCollection.LoadAndCloseReader(reader);
      return productCollection;
    }

    /// <summary>
    /// Fetches the favorite products.
    /// </summary>
    /// <param name="userName">Name of the user.</param>
    /// <returns></returns>
    public DataSet FetchFavoriteProducts(string userName) {
      DataSet ds = SPs.FetchFavoriteProducts(userName, (int)BrowsingBehaviour.Browsing_Product).GetDataSet();
      return ds;
    }

    /// <summary>
    /// Fetches the most popular products.
    /// </summary>
    /// <returns></returns>
    public ProductCollection FetchMostPopularProducts() {
      IDataReader reader = SPs.FetchMostPopularProducts((int)BrowsingBehaviour.Browsing_Product).GetReader();
      ProductCollection productCollection = new ProductCollection();
      productCollection.LoadAndCloseReader(reader);
      return productCollection;
    }

    /// <summary>
    /// Fetches the random products.
    /// </summary>
    /// <returns></returns>
    public ProductCollection FetchRandomProducts() {
      IDataReader reader = SPs.FetchRandomProducts().GetReader();
      ProductCollection productCollection = new ProductCollection();
      productCollection.LoadAndCloseReader(reader);
      return productCollection;
    }

    /// <summary>
    /// Fetches all products by category id.
    /// </summary>
    /// <param name="categoryId">The category id.</param>
    /// <returns></returns>
    public ProductCollection FetchAllProductsByCategoryId(int categoryId) {
      IDataReader reader = SPs.FetchAllProductsByCategoryId(categoryId).GetReader();
      ProductCollection productCollection = new ProductCollection();
      productCollection.LoadAndCloseReader(reader);
      return productCollection;
    }

    /// <summary>
    /// Searches the products.
    /// </summary>
    /// <param name="searchTerm">The search term.</param>
    /// <returns></returns>
    public ProductCollection SearchProducts(string searchTerm) {
      IDataReader reader = SPs.ProductSearch(searchTerm).GetReader();
      ProductCollection productCollection = new ProductCollection();
      productCollection.LoadAndCloseReader(reader);
      return productCollection;
    }
    
    #endregion
    
    #endregion

  }
}
