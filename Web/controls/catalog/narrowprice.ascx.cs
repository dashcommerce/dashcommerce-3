using System;
using System.Data;
using MettleSystems.dashCommerce.Store;

namespace MettleSystems.dashCommerce.Web.controls.catalog {
  public partial class narrowprice : System.Web.UI.UserControl {

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

    #endregion

    protected void Page_Load(object sender, EventArgs e) {
      if (Category != null && Category.CategoryId > 0) {
        DataSet ds = new CategoryController().FetchCategoryPriceRanges(Category.CategoryId);
        if (ds.Tables[0].Rows.Count > 0) {
          rptrNarrowByPrice.DataSource = ds;
          rptrNarrowByPrice.DataBind();
        }
      }
    }

    /// <summary>
    /// Gets the price range URL.
    /// </summary>
    /// <param name="lowRange">The low range.</param>
    /// <param name="hiRange">The hi range.</param>
    protected string GetPriceRangeUrl(string lowRange, string hiRange) {
      return RewriteService.BuildCatalogUrl(Category.CategoryId.ToString(), Category.Name, string.Format("ps={0}&pe={1}", lowRange, hiRange));
    }

    /// <summary>
    /// Gets the formatted price range.
    /// </summary>
    /// <param name="lowRange">The low range.</param>
    /// <param name="hiRange">The hi range.</param>
    protected string GetFormattedPriceRange(string lowRange, string hiRange) {
      return string.Format("{0} - {1}", StoreUtility.GetFormattedAmount(lowRange, true), StoreUtility.GetFormattedAmount(hiRange, true));
    }
  }
}