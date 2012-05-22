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
using System;
using System.Web;
using System.Web.UI;

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Core.Caching;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Web.Controls;
using MettleSystems.dashCommerce.Store.Services.TaxService;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin.controls.product {
  public partial class general : AdminControl {

    #region Constants

    private const string CONTENT_PATH = @"~/repository/content/";

    #endregion  

    #region Member Variables
    
    private int productId = 0;
    private string view = string.Empty;
    private Product product;
    
    #endregion
    
    #region Page Events

    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Init"></see> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> object that contains the event data.</param>
    protected override void OnInit(EventArgs e) {
      Session["FCKeditor:UserFilesPath"] = CONTENT_PATH;
      base.OnInit(e);
    }

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        productId = Utility.GetIntParameter("productId");
        view = Utility.GetParameter("view");
        if (view == "g") {
          SetGeneralProperties();
          SiteSettings siteSettings = SiteSettingCache.GetSiteSettings();
          if (productId > 0) {
            product = new Product(productId);
          }
          else {
            product = new Product();
          }

          if (!Page.IsPostBack) {
            LoadManufacturer();
            LoadProductStatus();
            LoadProductType();
            LoadShippingEstimate();
            LoadTaxRates();
            txtBaseSku.Text = product.BaseSku;
            txtName.Text = product.Name;
            txtShortDescription.Value = HttpUtility.HtmlDecode(product.ShortDescription);
            txtOurPrice.Text = StoreUtility.GetFormattedAmount(product.OurPrice, false);
            txtRetailPrice.Text = StoreUtility.GetFormattedAmount(product.RetailPrice, false);
            ddlManufacturer.SelectedValue = product.ManufacturerId.ToString();
            ddlStatus.SelectedValue = product.ProductStatusDescriptorId.ToString();
            ddlTaxRate.SelectedValue = product.TaxRateId.ToString();
            ddlProductType.SelectedValue = product.ProductTypeId.ToString();
            ddlShippingEstimate.SelectedValue = product.ShippingEstimateId.ToString();
            txtWeight.Text = product.Weight.ToString();
            txtLength.Text = product.Length.ToString();
            txtHeight.Text = product.Height.ToString();
            txtWidth.Text = product.Width.ToString();
          }
          lblOurPriceCurrencySymbol.Text = siteSettings.CurrencySymbol;
          lblRetailPriceCurrencySymbol.Text = siteSettings.CurrencySymbol;
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(general).Name + ".Page_Load", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnManufacturerAdd control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnManufacturerAdd_Click(object sender, EventArgs e) {
      if (!string.IsNullOrEmpty(txtManufacturerAdd.Text)) {
        Manufacturer manufacturer = new Manufacturer();
        manufacturer.Name = txtManufacturerAdd.Text.Trim();
        manufacturer.Save(WebUtility.GetUserName());
        txtManufacturerAdd.Text = string.Empty;
        LoadManufacturer();
        ddlManufacturer.SelectedIndex = ddlManufacturer.Items.Count - 1;
      }
    }

    /// <summary>
    /// Handles the Click event of the btnProductTypeAdd control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnProductTypeAdd_Click(object sender, EventArgs e) {
      if (!string.IsNullOrEmpty(txtProductTypeAdd.Text)) {
        ProductType productType = new ProductType();
        productType.Name = txtProductTypeAdd.Text.Trim();
        productType.Save(WebUtility.GetUserName());
        txtProductTypeAdd.Text = string.Empty;
        LoadProductType();
        ddlProductType.SelectedIndex = ddlProductType.Items.Count - 1;
      }
    }

    /// <summary>
    /// Handles the Click event of the btnPostSimilar control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnCopy_Click(object sender, EventArgs e) {
      this.btnSave_Click(null, EventArgs.Empty); //Save any changes first

      Product newProduct = new Product();
      newProduct.ProductGuid = Guid.NewGuid();
      newProduct.BaseSku = string.Empty;
      newProduct.Name = product.Name = txtName.Text.Trim() + " - Copy";
      newProduct.ShortDescription = product.ShortDescription;
      newProduct.OurPrice = product.OurPrice;
      newProduct.RetailPrice = product.RetailPrice;
      newProduct.ManufacturerId = product.ManufacturerId;
      newProduct.ProductStatusDescriptorId = product.ProductStatusDescriptorId;
      newProduct.ProductTypeId = product.ProductTypeId;
      newProduct.TaxRateId = product.TaxRateId;
      newProduct.ShippingEstimateId = product.ShippingEstimateId;
      newProduct.Weight = product.Weight;
      newProduct.Length = product.Length;
      newProduct.Height = product.Height;
      newProduct.Width = product.Width;
      newProduct.TotalRatingVotes = product.TotalRatingVotes;
      newProduct.RatingSum = product.RatingSum;
      newProduct.Save(WebUtility.GetUserName());

      if (newProduct.ProductId > 0) {
        foreach (Category cat in product.GetCategoryCollection()) {
          ProductCategoryMap map = new ProductCategoryMap();
          map.CategoryId = cat.CategoryId;
          map.ProductId = newProduct.ProductId;
          map.Save(WebUtility.GetUserName());
          Store.Caching.ProductCache.RemoveProductsByCategoryIdFromCache(cat.CategoryId);
        }

        AssociatedAttributeCollection productAttributes = Store.Caching.ProductCache.GetAssociatedAttributeCollectionByProduct(product.ProductId);
        foreach (AssociatedAttribute at in productAttributes) {          
          int sortOrder = 0;
          ProductAttributeMap map = new ProductAttributeMap();
          map.AttributeId = at.AttributeId;
          map.ProductId = newProduct.ProductId;
          map.SortOrder = sortOrder++;
          map.IsRequired = at.IsRequired;
          map.Save(WebUtility.GetUserName());
        }
        Response.Redirect(string.Format("~/admin/productedit.aspx?view=g&productId={0}", newProduct.ProductId.ToString()), false);
      }
      else {
        base.MasterPage.MessageCenter.DisplayFailureMessage(LocalizationUtility.GetText("lblProductNotSaved"));
      }
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e) {
      if(Page.IsValid) {
        try {
          int manufacturerId = 0;
          int.TryParse(ddlManufacturer.SelectedValue, out manufacturerId);
          int statusId = 0;
          int.TryParse(ddlStatus.SelectedValue, out statusId);
          int productTypeId = 0;
          int.TryParse(ddlProductType.SelectedValue, out productTypeId);
          int shippingEstimateId = 0;
          int.TryParse(ddlShippingEstimate.SelectedValue, out shippingEstimateId);
          int taxRateId = 0;
          int.TryParse(ddlTaxRate.SelectedValue, out taxRateId);

          decimal ourPrice = 0;
          decimal.TryParse(txtOurPrice.Text.Trim(), out ourPrice);
          decimal retailPrice = 0;
          decimal.TryParse(txtRetailPrice.Text.Trim(), out retailPrice);
          decimal weight = 0;
          decimal.TryParse(txtWeight.Text.Trim(), out weight);
          decimal length = 0;
          decimal.TryParse(txtLength.Text.Trim(), out length);
          decimal height = 0;
          decimal.TryParse(txtHeight.Text.Trim(), out height);
          decimal width = 0;
          decimal.TryParse(txtWidth.Text.Trim(), out width);
          //int listOrder = 0;
          //int.TryParse(txtListOrder.Text.Trim(), out listOrder);
          if(product.ProductId == 0) {
            product.ProductGuid = Guid.NewGuid();
          }
          product.BaseSku = txtBaseSku.Text.Trim();
          product.Name = txtName.Text.Trim();
          product.ShortDescription = HttpUtility.HtmlEncode(txtShortDescription.Value.Trim());
          product.OurPrice = ourPrice;
          product.RetailPrice = retailPrice;
          product.ManufacturerId = manufacturerId;
          product.ProductStatusDescriptorId = statusId;
          product.ProductTypeId = productTypeId;
          product.TaxRateId = taxRateId;
          product.ShippingEstimateId = shippingEstimateId;
          product.Weight = weight;
          product.Length = length;
          product.Height = height;
          product.Width = width;
          //default this to avoid division errors
          product.TotalRatingVotes = 1;
          product.RatingSum = 3;
          product.Save(WebUtility.GetUserName());
          Store.Caching.ProductCache.RemoveProductFromCache(product.ProductId);
          
          //refresh the cache
          foreach (Category item in product.GetCategoryCollection()) {
            Store.Caching.ProductCache.RemoveProductsByCategoryIdFromCache(item.CategoryId);
          }
          
          if(product.ProductId > 0) {
            Response.Redirect(string.Format("~/admin/productedit.aspx?view=g&productId={0}", product.ProductId.ToString()), false);
          }
          else {
            base.MasterPage.MessageCenter.DisplayFailureMessage(LocalizationUtility.GetText("lblProductNotSaved"));
          }
        }
        catch(Exception ex) {
          Logger.Error(typeof(general).Name + ".btnSave_Click", ex);
          base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
        }
      }
    }

    /// <summary>
    /// Handles the Click event of the btnDelete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void btnDelete_Click(object sender, EventArgs e) {
      try {
        Product.Delete(productId);
        base.MasterPage.MessageCenter.DisplayFailureMessage(LocalizationUtility.GetText("lblProductSaved"));
      }
      catch(Exception ex) {
        Logger.Error(typeof(general).Name + ".btnDelete_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }
    
    #endregion
    
    #region Methods
    
    #region Private

    /// <summary>
    /// Sets the general properties.
    /// </summary>
    private void SetGeneralProperties () {
      this.Page.Title = LocalizationUtility.GetText("titleProductEditGeneral");
      btnDelete.Attributes.Add("onclick", "return confirm(\"" + LocalizationUtility.GetText("lblConfirmDelete") + "\");return false;");
    }

    /// <summary>
    /// Loads the shipping estimate.
    /// </summary>
    private void LoadShippingEstimate () {
      ShippingEstimateCollection shippingEstimateCollection = new ShippingEstimateController().FetchAll();
      shippingEstimateCollection.OrderByAsc(ShippingEstimate.Columns.Name);
      ddlShippingEstimate.DataSource = shippingEstimateCollection;
      ddlShippingEstimate.DataTextField = ShippingEstimate.Columns.Name;
      ddlShippingEstimate.DataValueField = ShippingEstimate.Columns.ShippingEstimateId;
      ddlShippingEstimate.DataBind();
      ddlShippingEstimate.SelectedValue = product.ShippingEstimateId.ToString();
    }

    /// <summary>
    /// Loads the manufacturer.
    /// </summary>
    private void LoadManufacturer () {
      ManufacturerCollection manufacturerCollection = new ManufacturerController().FetchAll();
      manufacturerCollection.OrderByAsc(Manufacturer.Columns.Name);
      ddlManufacturer.DataSource = manufacturerCollection;
      ddlManufacturer.DataTextField = Manufacturer.Columns.Name;
      ddlManufacturer.DataValueField = Manufacturer.Columns.ManufacturerId;
      ddlManufacturer.DataBind();
    }

    /// <summary>
    /// Loads the product status.
    /// </summary>
    private void LoadProductStatus () {
      ProductStatusDescriptorCollection productStatusDescriptorCollection = new ProductStatusDescriptorController().FetchAll();
      productStatusDescriptorCollection.OrderByAsc(ProductStatusDescriptor.Columns.Name);
      ddlStatus.DataSource = productStatusDescriptorCollection;
      ddlStatus.DataTextField = ProductStatusDescriptor.Columns.Name;
      ddlStatus.DataValueField = ProductStatusDescriptor.Columns.ProductStatusDescriptorId;
      ddlStatus.DataBind();
      ddlStatus.SelectedValue = product.ProductStatusDescriptorId.ToString();
    }

    /// <summary>
    /// Loads the type of the product.
    /// </summary>
    private void LoadProductType () {
      ProductTypeCollection productTypeCollection = new ProductTypeController().FetchAll();
      productTypeCollection.OrderByAsc(ProductType.Columns.Name);
      ddlProductType.DataSource = productTypeCollection;
      ddlProductType.DataTextField = ProductType.Columns.Name;
      ddlProductType.DataValueField = ProductType.Columns.ProductTypeId;
      ddlProductType.DataBind();
    }


    /// <summary>
    /// Loads the tax rates.
    /// </summary>
    private void LoadTaxRates() {
      //MasterPage.SiteSettings.
      ITaxProvider taxProvider = TaxService.GetDefaultTaxProvider();
      if(taxProvider.IsProductLevelTaxProvider) {
        VatTaxRateCollection vatTaxRateCollection = new VatTaxRateController().FetchAll();
        ddlTaxRate.DataSource = vatTaxRateCollection;
        ddlTaxRate.DataTextField = VatTaxRate.Columns.Name;
        ddlTaxRate.DataValueField = VatTaxRate.Columns.VatTaxRateId;
        ddlTaxRate.DataBind();
      }
      else {
        ddlTaxRate.Visible = false;
      }
    }
    
    #endregion
    
    #endregion
    
  }
}
