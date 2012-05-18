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
using System.Collections.Generic;
using System.Web.UI.WebControls;
using MettleSystems.dashCommerce.Content;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Web;

namespace MettleSystems.dashCommerce.Web.admin.controls.content.products {
  public partial class EditCustomizedProductsDisplay : ProviderControl {

    #region Member Variables

    int regionId = -1;
    private CustomizedProductDisplay _currentDisplay;
    ProductCollection _products;

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      if (base.RegionId == 0)
        regionId = SubSonic.Sugar.Web.QueryString<int>("regionId");
      else
        regionId = base.RegionId;

      if (!IsPostBack) {
        _currentDisplay = LoadCustomizedProductDisplay();
        LoadDropDownMenu();
        ddlDisplayTypes.SelectedValue = _currentDisplay.CustomizedProductDisplayTypeId.ToString();
        LoadProducts();
      }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlDisplayTypes control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void ddlDisplayTypes_SelectedIndexChanged(object sender, EventArgs e) {
      _currentDisplay = new CustomizedProductDisplay(CustomizedProductDisplay.Columns.CustomizedProductDisplayTypeId, ddlDisplayTypes.SelectedValue);
      ClearListBoxes();
      LoadProducts();
    }

    /// <summary>
    /// Handles the Click event of the btnAddContent control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void btnAddContent_Click(object sender, EventArgs e) {
      if (string.IsNullOrEmpty(txtContent.Text))
        return;
      CustomizedProductDisplayType displayType = new CustomizedProductDisplayType();
      displayType.Name = txtContent.Text;
      displayType.Save();
      LoadDropDownMenu();
      ClearListBoxes();
      LoadProducts();
    }

    /// <summary>
    /// Handles the Click event of the btnAddToList control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void btnAddToList_Click(object sender, EventArgs e) {
      MoveToListBox(lbAllItems, lbAddedItems);
    }

    /// <summary>
    /// Handles the Click event of the btnRemoveFromList control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void btnRemoveFromList_Click(object sender, EventArgs e) {
      MoveToListBox(lbAddedItems, lbAllItems);
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e) {
      //Select all the items in the Added list so that SaveProductMap will insert them into the the map table.
      foreach (ListItem item in lbAddedItems.Items) {
        item.Selected = true;
      }
      CustomizedProductDisplayType.SaveProductMap(int.Parse(ddlDisplayTypes.SelectedValue), lbAddedItems.Items);
      if (_currentDisplay == null)
        _currentDisplay = LoadCustomizedProductDisplay();

      try {
        _currentDisplay.RegionId = regionId;
        _currentDisplay.CustomizedProductDisplayTypeId = int.Parse(ddlDisplayTypes.SelectedValue);
        _currentDisplay.Save();
        MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblPageSaved"));
      }
      catch (Exception ex) {
        MasterPage.MessageCenter.DisplayFailureMessage(string.Format(LocalizationUtility.GetText("lblCriticalError"), ex.Message));
      }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Loads the customized product display.
    /// </summary>
    /// <returns></returns>
    private CustomizedProductDisplay LoadCustomizedProductDisplay() {
      CustomizedProductDisplay customizedProductDisplay;
      if (regionId <= 0)
        customizedProductDisplay = new CustomizedProductDisplay();
      else
        customizedProductDisplay = new CustomizedProductDisplay(CustomizedProductDisplay.Columns.RegionId, regionId);
      return customizedProductDisplay;
    }

    /// <summary>
    /// Loads the products.
    /// </summary>
    private void LoadProducts() {
      SetButtonState(ddlDisplayTypes.Items.Count > 0);
      if (ddlDisplayTypes.Items.Count <= 0)
        return;

      lbAllItems.DataSource = new Store.ProductCollection()
        .Where(Product.Columns.IsEnabled, true)
        .Load();
      lbAllItems.DataBind();

      _products = CustomizedProductDisplayType.GetProductCollection(int.Parse(ddlDisplayTypes.SelectedValue));
      foreach (Product item in _products) {
        lbAddedItems.Items.Add(new ListItem(item.Name, item.ProductId.ToString()));
        ListItem itemToRemove = null;
        foreach (ListItem litem in lbAllItems.Items) {
          if (litem.Value == item.ProductId.ToString()) {
            itemToRemove = litem;
            break;
          }
        }
        if (itemToRemove != null)
          lbAllItems.Items.Remove(itemToRemove);
      }
    }

    /// <summary>
    /// Sets the state of the button.
    /// </summary>
    private void SetButtonState(bool enable) {
      if (!enable) {
        btnAddToList.Enabled = false;
        btnRemoveFromList.Enabled = false;
        btnSave.Enabled = false;
      }
      else {
        btnAddToList.Enabled = true;
        btnRemoveFromList.Enabled = true;
        btnSave.Enabled = true;
      }
    }

    /// <summary>
    /// Loads the drop down menu.
    /// </summary>
    private void LoadDropDownMenu() {
      ddlDisplayTypes.DataSource = new CustomizedProductDisplayTypeCollection().Load();
      ddlDisplayTypes.DataBind();
    }

    /// <summary>
    /// Clears the list boxes.
    /// </summary>
    private void ClearListBoxes() {
      lbAddedItems.Items.Clear();
      lbAllItems.Items.Clear();
    }

    /// <summary>
    /// Moves to list box.
    /// </summary>
    /// <param name="moveFrom">The move from.</param>
    /// <param name="moveTo">The move to.</param>
    private void MoveToListBox(ListBox moveFrom, ListBox moveTo) {
      List<ListItem> itemToRemove = new List<ListItem>();
      foreach (ListItem item in moveFrom.Items) {
        if (item.Selected) {
          moveTo.Items.Add(item);
          itemToRemove.Add(item);
        }
      }
      foreach (ListItem items in itemToRemove) {
        moveFrom.Items.Remove(items);
      }
    }

    /// <summary>
    /// Setups the text.
    /// </summary>
    public void SetupText() {
      
      
      
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the master page.
    /// </summary>
    /// <value>The master page.</value>
    public AdminMasterPage MasterPage {
      get {
        return this.Page.Master as AdminMasterPage;
      }
    }

    #endregion

  }
}