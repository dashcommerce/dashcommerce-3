using System;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.controls.catalog {
  public partial class sorting : System.Web.UI.UserControl {

    #region Properties

    private Category category;
    public Category Category {
      get {
        return category;
      }
      set {
        category = value;
      }
    }

    private ProductCollection productCollection;
    public ProductCollection ProductCollection {
      get {
        return productCollection;
      }
      set {
        productCollection = value;
      }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e) {
      hlSortCheapest.Text = LocalizationUtility.GetText("lblPriceASC");
      hlSortExpensive.Text = LocalizationUtility.GetText("lblPriceDESC");
      hlSortNewset.Text = LocalizationUtility.GetText("lblNewest");
      hlSortOldest.Text = LocalizationUtility.GetText("lblOldest");
      hlSortTitleAsc.Text = LocalizationUtility.GetText("lblTitleASC");
      hlSortTitleDesc.Text = LocalizationUtility.GetText("lblTitleDESC");

      hlSortCheapest.NavigateUrl = RewriteService.BuildCatalogUrl(Category.CategoryId.ToString(), Category.Name, WebUtility.AddRemoveFromQueryString(Request.QueryString, "SortBy", ((int)CatalogSortBy.PriceAscending).ToString(), "cid", "p"));
      hlSortExpensive.NavigateUrl = RewriteService.BuildCatalogUrl(Category.CategoryId.ToString(), Category.Name, WebUtility.AddRemoveFromQueryString(Request.QueryString, "SortBy", ((int)CatalogSortBy.PriceDescending).ToString(), "cid", "p"));
      hlSortNewset.NavigateUrl = RewriteService.BuildCatalogUrl(Category.CategoryId.ToString(), Category.Name, WebUtility.AddRemoveFromQueryString(Request.QueryString, "SortBy", ((int)CatalogSortBy.DateCreatedDescending).ToString(), "cid", "p"));
      hlSortOldest.NavigateUrl = RewriteService.BuildCatalogUrl(Category.CategoryId.ToString(), Category.Name, WebUtility.AddRemoveFromQueryString(Request.QueryString, "SortBy", ((int)CatalogSortBy.DateCreatedAscending).ToString(), "cid", "p"));
      hlSortTitleAsc.NavigateUrl = RewriteService.BuildCatalogUrl(Category.CategoryId.ToString(), Category.Name, WebUtility.AddRemoveFromQueryString(Request.QueryString, "SortBy", ((int)CatalogSortBy.TitleAscending).ToString(), "cid", "p"));
      hlSortTitleDesc.NavigateUrl = RewriteService.BuildCatalogUrl(Category.CategoryId.ToString(), Category.Name, WebUtility.AddRemoveFromQueryString(Request.QueryString, "SortBy", ((int)CatalogSortBy.TitleDescending).ToString(), "cid", "p"));

      SortProducts(ProductCollection, (CatalogSortBy)Utility.GetIntParameter("SortBy"));
    }

    /// <summary>
    /// Will sort the product collection passed in depending on the sort by.
    /// </summary>
    /// <param name="products">The product collection to sort.</param>
    /// <param name="sortBy">The type of sorting.</param>
    public static void SortProducts(ProductCollection products, CatalogSortBy sortBy) {
      switch (sortBy) {
        case CatalogSortBy.PriceAscending:
          products.Sort(delegate(Product p1, Product p2) {
            return p1.OurPrice.CompareTo(p2.OurPrice);
          });
          break;
        case CatalogSortBy.PriceDescending:
          products.Sort(delegate(Product p1, Product p2) {
            return p2.OurPrice.CompareTo(p1.OurPrice);
          });
          break;
        case CatalogSortBy.TitleAscending:
          products.Sort(delegate(Product p1, Product p2) {
            return p1.Name.CompareTo(p2.Name);
          });
          break;
        case CatalogSortBy.TitleDescending:
          products.Sort(delegate(Product p1, Product p2) {
            return p2.Name.CompareTo(p1.Name);
          });
          break;
        case CatalogSortBy.DateUpdatedAscending:
          products.Sort(delegate(Product p1, Product p2) {
            return p2.CreatedOn.CompareTo(p1.CreatedOn);
          });
          break;
        case CatalogSortBy.DateCreatedAscending:
          products.Sort(delegate(Product p1, Product p2) {
            return p1.CreatedOn.CompareTo(p2.CreatedOn);
          });
          break;
        case CatalogSortBy.DateCreatedDescending:
          products.Sort(delegate(Product p1, Product p2) {
            return p2.ModifiedOn.CompareTo(p1.ModifiedOn);
          });
          break;
        case CatalogSortBy.DateUpdatedDescending:
          products.Sort(delegate(Product p1, Product p2) {
            return p1.ModifiedOn.CompareTo(p2.ModifiedOn);
          });
          break;
      }
    }
  }
}