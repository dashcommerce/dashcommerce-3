using System;
using System.Collections.Generic;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Caching;

namespace MettleSystems.dashCommerce.Web.controls.catalog {
  public partial class narrowcategory : System.Web.UI.UserControl {

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
        List<Category> cat = CategoryCache.AllCategories().FindAll(delegate(Category c) { return c.ParentId == Category.CategoryId; });
        if (cat.Count > 0) {
          pnlNarrowCatagory.Visible = true;
          pnlNarrowCatagory.GroupingText = category.Name;
          rptNarrowCatagory.DataSource = cat;
          rptNarrowCatagory.DataBind();
        }
      }
    }
  }
}