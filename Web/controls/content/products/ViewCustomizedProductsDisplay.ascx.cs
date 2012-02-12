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
using MettleSystems.dashCommerce.Content;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Caching;

namespace MettleSystems.dashCommerce.Web.controls.content.products {
  public partial class ViewCustomizedProductsDisplay : ProviderControl {
 
    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      if (!Page.IsPostBack) {
        CustomizedProductDisplay cpd = new CustomizedProductDisplay(CustomizedProductDisplay.Columns.RegionId, base.RegionId);

        CustomizedProductDisplayTypeProductMapCollection cpdmColl = new CustomizedProductDisplayTypeProductMapCollection()
          .Where(CustomizedProductDisplayTypeProductMap.Columns.CustomizedProductDisplayTypeId, cpd.CustomizedProductDisplayTypeId)
          .Load();

        dlProducts.DataSource = cpdmColl;
        dlProducts.DataBind();
      }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Loads the product.
    /// </summary>
    /// <param name="productId">The product id.</param>
    /// <returns></returns>
    protected Product LoadProduct(int productId) {
      return ProductCache.GetProductByProductID(productId);
    }

    #endregion

  }
}