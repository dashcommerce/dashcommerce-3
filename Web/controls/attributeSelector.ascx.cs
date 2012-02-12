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
using System.Web.UI;
using System.Web.UI.WebControls;
using MettleSystems.dashCommerce.Core.Caching;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Caching;

namespace MettleSystems.dashCommerce.Web.controls {
  public partial class attributeSelector : System.Web.UI.UserControl {

    #region Member Variables

    protected AssociatedAttributeCollection associatedAttributeCollection;
    private Product _product;

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the PreRender event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_PreRender(object sender, EventArgs e) {
      upDisplay.ProgressTemplate = new UpdatingProgressTemplate();
    }

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      if (_product != null) {
        associatedAttributeCollection = Store.Caching.ProductCache.GetAssociatedAttributeCollectionByProduct(_product.ProductId);
        if (associatedAttributeCollection.Count > 0) {
          Label lblAttributeName;
          TextBox textBox;
          AttributeItemCollection attributeItemCollection;
          foreach (AssociatedAttribute associatedAttribute in associatedAttributeCollection) {
            lblAttributeName = new Label();
            lblAttributeName.CssClass = "attributeLabel";
            lblAttributeName.Text = associatedAttribute.Label;
            pnlProductAttributes.Controls.Add(lblAttributeName);
            pnlProductAttributes.Controls.Add(new LiteralControl("&nbsp;"));
            Label label = new Label();
            label.ID = associatedAttribute.Name;
            label.CssClass = "attribute";
            ThisPage.UpdatePanel.ContentTemplateContainer.Controls.Add(label);
            AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
            trigger.ControlID = associatedAttribute.Name;
            trigger.EventName = "OnSelectedIndexChanged";
            ThisPage.UpdatePanel.Triggers.Add(trigger);
            
            switch (associatedAttribute.AttributeTypeId) {
              case 1:// Single Select List
                DropDownList dropDownList = new DropDownList();
                dropDownList.ID = associatedAttribute.Name;
                dropDownList.CssClass = "attributeDropdownList";

                attributeItemCollection = associatedAttribute.AttributeItemCollection;
                attributeItemCollection.Sort("SortOrder", true);
                dropDownList.DataSource = attributeItemCollection;
                dropDownList.DataTextField = "FormattedAmount";
                dropDownList.DataValueField = "SkuSuffix";
                dropDownList.DataBind();

                dropDownList.SelectedIndexChanged += new EventHandler(dropDownList_SelectedIndexChanged);
                dropDownList.AutoPostBack = true;
                dropDownList.Items.Insert(0, new ListItem(LocalizationUtility.GetText("lblSelect"), string.Empty));

                //CMC: ?? Sku's are not made up of just BaseSku + 1 attribute, it's the combination of
                //BaseSku and ALL attributes.

                //foreach (AttributeItem item in associatedAttribute.AttributeItemCollection) {
                //  if (!_product.AllowNegativeInventories) {
                //    Sku sku = ProductCache.GetSKU(_product.BaseSku + "-" + item.SkuSuffix);
                //    if (sku.SkuId > 0 && sku.Inventory > 0)
                //      dropDownList.Items.Add(new ListItem(item.FormattedAmount, item.SkuSuffix));
                //  }
                //  else
                //    dropDownList.Items.Add(new ListItem(item.FormattedAmount, item.SkuSuffix));
                //}

                if (associatedAttribute.IsRequired) {
                  RequiredFieldValidator rfv = new RequiredFieldValidator();
                  rfv.ControlToValidate = dropDownList.ID;
                  rfv.Display = ValidatorDisplay.None;
                  rfv.ErrorMessage = string.Format(LocalizationUtility.GetText("lblPleaseSelect"), associatedAttribute.Name);
                  pnlProductAttributes.Controls.Add(rfv);
                }
                pnlProductAttributes.Controls.Add(dropDownList);
                break;
              case 2: //Singleline Input
                textBox = new TextBox();
                textBox.ID = associatedAttribute.AttributeItemCollection[0].SkuSuffix;
                textBox.TextMode = TextBoxMode.SingleLine;
                textBox.CssClass = "textbox";
                if (associatedAttribute.IsRequired) {
                  RequiredFieldValidator rfv = new RequiredFieldValidator();
                  rfv.ControlToValidate = textBox.ID;
                  rfv.Display = ValidatorDisplay.None;
                  rfv.ErrorMessage = string.Format(LocalizationUtility.GetText("lblPleaseSupply"), associatedAttribute.Name);
                  pnlProductAttributes.Controls.Add(rfv);
                }
                pnlProductAttributes.Controls.Add(textBox);
                break;
              case 3: //Multiline Input
                textBox = new TextBox();
                textBox.ID = associatedAttribute.AttributeItemCollection[0].SkuSuffix;
                textBox.TextMode = TextBoxMode.MultiLine;
                textBox.CssClass = "multilinetextbox";
                if (associatedAttribute.IsRequired) {
                  RequiredFieldValidator rfv = new RequiredFieldValidator();
                  rfv.ControlToValidate = textBox.ID;
                  rfv.Display = ValidatorDisplay.None;
                  rfv.ErrorMessage = string.Format(LocalizationUtility.GetText("lblPleaseSupply"), associatedAttribute.Name);
                  pnlProductAttributes.Controls.Add(rfv);
                }
                pnlProductAttributes.Controls.Add(textBox);
                break;
            }
            pnlProductAttributes.Controls.Add(new LiteralControl("<br/>"));
          }
        }
        else {
          if (!Page.IsPostBack) {
            GetInventory(_product.BaseSku);
          }
        }
      }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the dropDownList control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    void dropDownList_SelectedIndexChanged(object sender, EventArgs e) {
      DropDownList dropDownList = sender as DropDownList;
      if (dropDownList != null) {
        Label label = ThisPage.UpdatePanel.ContentTemplateContainer.FindControl(dropDownList.ID) as Label;
        if (label != null) {
          label.Text = string.Format("<strong>{0}:</strong>&nbsp;{1}<br/>", dropDownList.ID, dropDownList.SelectedItem.Text);
        }
      }
      string skuId = GetSku();
      GetInventory(skuId);
    }

    #endregion

    #region Methods

    #region Public

    /// <summary>
    /// Gets the sku.
    /// </summary>
    /// <returns></returns>
    public string GetSku() {
      string sku = _product.BaseSku;

      foreach (AssociatedAttribute associatedAttribute in associatedAttributeCollection) {
        switch (associatedAttribute.AttributeTypeId) {
          case 1:
            DropDownList dropDownList = pnlProductAttributes.FindControl(associatedAttribute.Name) as DropDownList;
            if (dropDownList != null) {
              if (!string.IsNullOrEmpty(dropDownList.SelectedValue)) {
                sku += "-" + dropDownList.SelectedValue;
              }
            }
            break;
          case 2://let it fall through
          case 3:
            TextBox textBox = pnlProductAttributes.FindControl(associatedAttribute.AttributeItemCollection[0].SkuSuffix) as TextBox;
            if (textBox != null) {
              sku += "-" + textBox.ID;
            }
            break;
        }
      }
      return sku;
    }

    #endregion

    #region Private

    /// <summary>
    /// Gets the inventory.
    /// </summary>
    /// <param name="skuId">The sku id.</param>
    public void GetInventory(string skuId) {
      if (ThisPage.Product.AllowNegativeInventories) {
        ThisPage.AddToCart.Enabled = true;
      }
      else {
        Sku sku = ProductCache.GetSKU(skuId);
        if (sku.SkuId > 0 && sku.Inventory > 0) {
          string previouslySelectedValue = ThisPage.Quantity.SelectedValue;
          ThisPage.AddToCart.Enabled = true;
          ThisPage.Quantity.Enabled = true;
          ThisPage.Quantity.Items.Clear();

          if (sku.Inventory < SiteSettingCache.GetSiteSettings().MaxProductsAddToCart) {
            for (int i = 1; i <= sku.Inventory; i++) {
              ThisPage.Quantity.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
          }
          else {
            for (int i = 1; i <= SiteSettingCache.GetSiteSettings().MaxProductsAddToCart; i++) {
              ThisPage.Quantity.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
          }

          //If they selected a quantity and the quantity is valid for the new selection then keep it selected
          //Otherwise, select the first one.
          if (ThisPage.Quantity.Items.FindByValue(previouslySelectedValue) != null) {
            ThisPage.Quantity.SelectedValue = previouslySelectedValue;
          }
          else {
            ThisPage.Quantity.SelectedIndex = 0;
          }
        }
        else {
          ThisPage.Quantity.Enabled = false;
          ThisPage.AddToCart.Enabled = false;
        }
      }
    }

    #endregion

    #endregion

    #region Properties

    /// <summary>
    /// Gets this page.
    /// </summary>
    /// <value>The this page.</value>
    public MettleSystems.dashCommerce.Web.product ThisPage {
      get {
        return this.Page as product;
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
    /// Gets the selected attributes.
    /// </summary>
    /// <value>The selected attributes.</value>
    public Store.AttributeCollection SelectedAttributes {
      get {
        Store.AttributeCollection attributeCollection = new Store.AttributeCollection();
        Store.Attribute attribute;
        Store.AttributeItem attributeItem;
        AttributeItemController attributeItemController;
        foreach (AssociatedAttribute associatedAttribute in associatedAttributeCollection) {
          switch (associatedAttribute.AttributeTypeId) {
            case 1:
              DropDownList dropDownList = pnlProductAttributes.FindControl(associatedAttribute.Name) as DropDownList;
              attribute = new Store.Attribute();
              attribute.AttributeId = associatedAttribute.AttributeId;
              attribute.Name = associatedAttribute.Name;
              attribute.Label = associatedAttribute.Label;
              attributeItemController = new AttributeItemController();
              attributeItem = attributeItemController.FetchSelectedAttributeItem(associatedAttribute.AttributeId, dropDownList.SelectedValue);
              attribute.AttributeItemCollection.Add(attributeItem);
              attributeCollection.Add(attribute);
              break;
            case 2://let it fall through
            case 3:
              TextBox textBox = pnlProductAttributes.FindControl(associatedAttribute.AttributeItemCollection[0].SkuSuffix) as TextBox;
              attribute = new Store.Attribute();
              attribute.AttributeId = associatedAttribute.AttributeId;
              attribute.Name = associatedAttribute.Name;
              attribute.Label = associatedAttribute.Label;
              attributeItemController = new AttributeItemController();
              attributeItem = attributeItemController.FetchSelectedAttributeItem(associatedAttribute.AttributeId, textBox.ID);
              attributeItem.Name = textBox.Text;//overwrite the attributeItem.Name with the value from the form
              attribute.AttributeItemCollection.Add(attributeItem);
              attributeCollection.Add(attribute);
              break;
          }
        }
        return attributeCollection;
      }
    }

    #endregion
  }
}
