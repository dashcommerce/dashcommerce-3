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
