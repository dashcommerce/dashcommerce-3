using System;
using System.Data;
using MettleSystems.dashCommerce.Store;

namespace MettleSystems.dashCommerce.Web.controls.catalog {
  public partial class narrowmanufacturer : System.Web.UI.UserControl {

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
        DataSet ds = new CategoryController().FetchCategoryManufacturers(category.CategoryId);
        if (ds.Tables[0].Rows.Count > 0) {
          rptrNarrowByManufacturer.DataSource = ds;
          rptrNarrowByManufacturer.DataBind();
        }
      }
    }

    /// <summary>
    /// Gets the manufacturer URL.
    /// </summary>
    /// <param name="manufacturerId">The manufacturer id.</param>
    protected string GetManufacturerUrl(string manufacturerId) {
      return RewriteService.BuildCatalogUrl(Category.CategoryId.ToString(), Category.Name, string.Concat("?mid=", manufacturerId));
    }
  }
}