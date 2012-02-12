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
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Services.TaxService;
using SubSonic.Utilities;
using Img = System.Drawing;
using System.IO;

namespace MettleSystems.dashCommerce.Web {
  public partial class product : MettleSystems.dashCommerce.Store.Web.SitePage {

    #region Member Variables

    private int productId;
    private Product _product;
    private List<System.Web.UI.WebControls.Image> imageList = new List<System.Web.UI.WebControls.Image>();

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      productId = Utility.GetIntParameter("pid");
      _product = new Product(productId);
      if (string.IsNullOrEmpty(_product.BaseSku) || _product.ProductStatusDescriptorId == 99) {
        throw new InvalidOperationException(string.Format("Invalid product. Product Id of {0} is not valid.", productId));
        //We should display alternative products.
      }

      SetProductProperties();
      LogProductBrowse();
      LoadProduct();
      LoadPageTitle();
      LoadProductImages();
      LoadDownloads();
      LoadDescriptors();
      LoadReviews();
      LoadCrossSells();
      SetSeoInformation();
      LoadBreadCrumbs();
      if (User.Identity.IsAuthenticated) {
        //only allow them to review if they haven't reviewed before (select even the non-approved reviews) 
        pnlReview.Visible = SiteSettings.DisplayRatings && !ReviewController.UserReviewedProduct(_product.ProductId, WebUtility.GetUserName());
      }
    }

    /// <summary>
    /// Handles the Click event of the btnAddToCart control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnAddToCart_Click(object sender, EventArgs e) {
      if (Master.SiteSettings.LoginRequirement == LoginRequirement.Add_To_Cart) {
        if (!User.Identity.IsAuthenticated) {
          Response.Redirect(string.Format("login.aspx?ReturnUrl={0}", Request.Url), true);
        }
      }
      int quantity;
      if (ddlQuantity.Visible) {
        int.TryParse(ddlQuantity.SelectedValue, out quantity);
      }
      else {
        int.TryParse(txtQuantity.Text.Trim(), out quantity);
      }
      if (quantity > 0) {
        string sku = productAttributes.GetSku();
        decimal pricePaid = _product.OurPrice;
        Store.AttributeCollection selectedAttributes = productAttributes.SelectedAttributes;
        foreach (Store.Attribute attribute in selectedAttributes) {
          foreach (AttributeItem attributeItem in attribute.AttributeItemCollection) {
            pricePaid += attributeItem.Adjustment;
          }
        }
        //string selectAttributesString = selectedAttributes.ToString();
        OrderController orderController = new OrderController();
        orderController.AddItemToOrder(WebUtility.GetUserName(), _product.ProductId, _product.Name, sku, quantity, pricePaid, _product.ItemTax, _product.Weight, selectedAttributes.ToString(), selectedAttributes.ExtentedProperties.ToXml());
        Response.Redirect("~/cart.aspx", true);
      }
    }

    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Loads the bread crumbs.
    /// </summary>
    private void LoadBreadCrumbs() {
      CategoryCollection category = Store.Caching.CategoryCache.FetchAssociatedCategoriesByProductId(productId);
      if (category != null && category.Count > 0) {
        DataSet breadCrumbs = Store.Caching.CategoryCache.FetchCategoryBreadCrumbs(category[0].CategoryId);
        xmlDataSource.EnableCaching = false;
        RewriteService.AddRewriteNameSpaceForXslt(xmlDataSource);
        xmlDataSource.Data = breadCrumbs.GetXml();
      }
      else
        categoryCrumbs.Visible = false;
    }

    /// <summary>
    /// Sets the seo information.
    /// </summary>
    private void SetSeoInformation() {
      string name = _product.Name;
      AddKeyWord(name);
      base.SetPageDescription(name);
    }

    /// <summary>
    /// Loads the cross sells.
    /// </summary>
    private void LoadCrossSells() {
      ProductCollection productCollection = Store.Caching.ProductCache.GetCrossSellCollectionByProduct(productId);
      if (productCollection == null || productCollection.Count == 0) {
        lblCrossSells.Visible = false;
        crossSells.Visible = false;
      }
      else {
        crossSells.ProductCollection = productCollection;
      }
    }

    /// <summary>
    /// Loads the downloads.
    /// </summary>
    private void LoadDownloads() {
      DownloadCollection downloadCollection = new ProductController().FetchAssociatedDownloadsByProductIdAndNotForPurchase(productId);
      if (downloadCollection.Count > 0) {
        dlDownloads.DataSource = downloadCollection;
        dlDownloads.ItemDataBound += new DataListItemEventHandler(dlFiles_ItemDataBound);
        dlDownloads.DataBind();
      }
      else {
        //turn stuff off
        pnlDownloadsTitle.Visible = false;
        pnlDownloads.Visible = false;
      }
    }

    /// <summary>
    /// Handles the ItemDataBound event of the dlFiles control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.DataListItemEventArgs"/> instance containing the event data.</param>
    void dlFiles_ItemDataBound(object sender, DataListItemEventArgs e) {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        Download download = e.Item.DataItem as Download;
        HyperLink hlDownload = e.Item.FindControl("hlDownload") as HyperLink;
        System.Web.UI.WebControls.Image imgIcon = e.Item.FindControl("imgIcon") as System.Web.UI.WebControls.Image;

        if (hlDownload != null) {
          hlDownload.Text = download.Title;
          hlDownload.NavigateUrl = string.Format("~/download.ashx?did={0}", download.DownloadId);
        }
        if (imgIcon != null) {
          imgIcon.ImageUrl = string.Format("~/App_Themes/dashCommerce/images/icons/{0}.gif", DownloadController.GetFileTypeIcon(Path.GetExtension(download.DownloadFile)));
        }
      }
    }


    /// <summary>
    /// Loads the descriptors.
    /// </summary>
    private void LoadDescriptors() {
      DescriptorCollection descriptorCollection = Store.Caching.ProductCache.GetDescriptorCollectionByProduct(_product).Clone();
      if (descriptorCollection != null && descriptorCollection.Count > 0) {
        descriptorCollection.Sort(Descriptor.Columns.SortOrder, true);
        AjaxControlToolkit.TabContainer tcDescriptors = new AjaxControlToolkit.TabContainer();
        tcDescriptors.ID = "tcDescriptors";
        tcDescriptors.Height = new Unit(200, UnitType.Pixel);
        tcDescriptors.ScrollBars = ScrollBars.Vertical;
        tcDescriptors.CssClass = "ajax__tab_technorati-theme";
        AjaxControlToolkit.TabPanel tabPanel;
        foreach (Descriptor descriptor in descriptorCollection) {
          tabPanel = new AjaxControlToolkit.TabPanel();
          tabPanel.HeaderText = descriptor.Title;
          tabPanel.Controls.Add(new LiteralControl(HttpUtility.HtmlDecode(descriptor.DescriptorX)));
          tcDescriptors.Tabs.Add(tabPanel);
        }
        tcDescriptors.ActiveTabIndex = 0;
        phDescriptors.Controls.Add(tcDescriptors);
      }
    }

    /// <summary>
    /// Loads the reviews.
    /// </summary>
    private void LoadReviews() {
      if (SiteSettings.DisplayRatings) {
        review.Product = _product;
        ReviewCollection reviewCollection = Store.Caching.ProductCache.GetReviewCollectionByProductID(productId);
        if (reviewCollection.Count > 0) {
          reviewCollection.Sort(Review.Columns.CreatedOn, false);
          rptrReviews.DataSource = reviewCollection;
          rptrReviews.DataBind();
        }
        else {
          lblNoReviews.Visible = true;
        }
      }
    }

    /// <summary>
    /// Loads the page title.
    /// </summary>
    private void LoadPageTitle() {
      string pageTitle = string.Format(WebUtility.MainTitleTemplate, Master.SiteSettings.SiteName, _product.Name);
      Page.Title = pageTitle;
      lblEdit.NavigateUrl = "~/admin/productedit.aspx?view=g&productId=" + productId;
    }

    /// <summary>
    /// Loads the product.
    /// </summary>
    private void LoadProduct() {
      _product = Store.Caching.ProductCache.GetProductByProductID(productId);
      productAttributes.Product = _product;
      lblProductName.Text = _product.Name;
      lblOurPriceAmount.Text = StoreUtility.GetFormattedAmount(_product.DisplayPrice, true);
      if(Master.SiteSettings.AddTaxToPrice && TaxService.GetDefaultTaxProvider().IsProductLevelTaxProvider) {
        lblTaxApplied.Visible = true;
      }
      ajaxRating.CurrentRating = _product.Rating;
      ajaxRating.Visible = SiteSettings.DisplayRatings;
      lblShortDescription.Text = HttpUtility.HtmlDecode(_product.ShortDescription);
      if (_product.RetailPrice != 0 && Master.SiteSettings.DisplayRetailPrice) {
        lblRetailPriceAmount.Text = StoreUtility.GetFormattedAmount(_product.RetailPrice, true);
        pnlRetailPrice.Visible = true;
        pnlYouSave.Visible = true;
        lblYouSaveAmount.Text = string.Format("{0}&nbsp;({1})", StoreUtility.GetFormattedAmount(_product.YouSaveAmount, true), _product.YouSavePercentage.ToString("p"));
      }
      if (!IsPostBack) {
        SkuCollection productSkus = _product.SkuRecords(); //TODO: Cache this?
        if (productSkus.Count > 0) {
          if (productSkus.Count == 1) {//there is only 1 Sku, so load the inventory
            productAttributes.GetInventory(productSkus[0].SkuX);
          }
          else {
            ddlQuantity.Enabled = false;
            btnAddToCart.Enabled = false;
          }
        }
      }
      if (_product.AllowNegativeInventories) {
        ddlQuantity.Visible = false;
        txtQuantity.Visible = true;
        rfvQuantity.Visible = true;
      }
    }

    /// <summary>
    /// Sets the product properties.
    /// </summary>
    private void SetProductProperties() {
      ajaxRating.GroupingText = LocalizationUtility.GetText("lblAverageRating");
    }

    /// <summary>
    /// Logs the product browse.
    /// </summary>
    private void LogProductBrowse() {
      if (Master.SiteSettings.CollectBrowsingProduct) {
        BrowsingLogController.LogBrowsingInfo(productId, BrowsingBehaviour.Browsing_Product, Request.Url.ToString().PadRight(255).Substring(0, 254).Trim(), WebUtility.SessionId(), WebUtility.GetUserName());
      }
    }

    /// <summary>
    /// Loads the product images.
    /// </summary>
    private void LoadProductImages() {
      ImageCollection imageCollection = Store.Caching.ProductCache.GetImageCollectionByProduct(_product).Clone();
      if (imageCollection.Count > 0) {
        imageCollection.Sort("SortOrder", true);
        Img.Image drawnImage;
        System.Web.UI.WebControls.Image displayImage;
        foreach (Store.Image image in imageCollection) {
          DisplayImage(ImageProcess.GetProductThumbnailUrl(image.ImageFile), image, out drawnImage, out displayImage);
        }
        imageList.TrimExcess();
        dlImages.DataSource = imageList;
        dlImages.DataBind();
      }
    }

    /// <summary>
    /// Displays the image
    /// </summary>
    private void DisplayImage(string thumbnail, Store.Image image, out Img.Image drawnImage, out System.Web.UI.WebControls.Image displayImage) {
      drawnImage = Img.Image.FromFile(Server.MapPath(thumbnail));
      displayImage = new System.Web.UI.WebControls.Image();
      displayImage.ImageUrl = thumbnail;
      displayImage.Attributes.Add("BigImageUrl", Page.ResolveUrl(image.ImageFile));
      displayImage.Attributes.Add("rel", productId.ToString());
      displayImage.Attributes.Add("title", image.Caption);
      imageList.Add(displayImage);
    }

    #endregion

    #endregion

    #region Properties

    /// <summary>
    /// Gets the update panel.
    /// </summary>
    /// <value>The update panel.</value>
    public UpdatePanel UpdatePanel {
      get {
        return upCart;
      }
    }

    /// <summary>
    /// Gets the quantity.
    /// </summary>
    /// <value>The quantity.</value>
    public DropDownList Quantity {
      get {
        return ddlQuantity;
      }
    }

    /// <summary>
    /// Gets or sets the product.
    /// </summary>
    /// <value>The product.</value>
    public Product Product {
      get {
        return _product;
      }
      set {
        _product = value;
      }
    }

    /// <summary>
    /// Gets the add to cart.
    /// </summary>
    /// <value>The add to cart.</value>
    public Button AddToCart {
      get {
        return btnAddToCart;
      }
    }

    #endregion

  }
}
