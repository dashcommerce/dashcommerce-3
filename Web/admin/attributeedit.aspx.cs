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
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Core.Caching;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using SubSonic;

namespace MettleSystems.dashCommerce.Web.admin {
  public partial class attributeedit : MettleSystems.dashCommerce.Store.Web.AdminPage {

    #region Member Variables

    CultureInfo cultureInfo;

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        SiteSettings siteSettings = SiteSettingCache.GetSiteSettings();
        cultureInfo = new CultureInfo(siteSettings.Language);
        SetAttributeEditProperties();
        LoadAttributes();
        if (!Page.IsPostBack) {
          LoadAttributeTypes();
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(attributeedit).Name + ".Page_Load", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e) {
      try {
        Store.Attribute attribute;
        int attributeId = 0;
        int.TryParse(lblAttributeId.Text, out attributeId);
        if (attributeId > 0) {
          attribute = new Store.Attribute(attributeId);
        }
        else {
          attribute = new Store.Attribute();
        }

        attribute.Name = Server.HtmlEncode(txtName.Text.Trim());
        attribute.Label = Server.HtmlEncode(txtLabel.Text.Trim());
        int attributeTypeId = 0;
        int.TryParse(ddlAttributeType.SelectedValue, out attributeTypeId);
        attribute.AttributeTypeId = attributeTypeId;
        attribute.Save(WebUtility.GetUserName());
        lblAttributeId.Text = attribute.AttributeId.ToString();
        LoadAttributes();
        if (attributeId == 0) {
          pnlAttributeItems.Visible = true;
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(attributeedit).Name + ".btnSave_Click", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnAdd control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnAdd_Click(object sender, EventArgs e) {
      try {
        int attributeId = 0;
        int attributeItemId = 0;
        int.TryParse(lblAttributeId.Text, out attributeId);
        int.TryParse(lblAttributeItemId.Text, out attributeItemId);
        AttributeItem attributeItem;
        if (attributeId > 0) {
          Where where = new Where();
          where.ColumnName = AttributeItem.Columns.AttributeId;
          where.DbType = DbType.Int32;
          where.ParameterValue = attributeId;
          Query query = new Query(AttributeItem.Schema);
          object strSortOrder = query.GetMax(AttributeItem.Columns.SortOrder, where);
          int maxSortOrder = 0;
          int.TryParse(strSortOrder.ToString(), out maxSortOrder);

          if (attributeItemId > 0) {
            attributeItem = new AttributeItem(attributeItemId);
          }
          else {
            attributeItem = new AttributeItem();
            attributeItem.SortOrder = maxSortOrder + 1;
          }

          attributeItem.AttributeId = attributeId;
          attributeItem.Name = Server.HtmlEncode(txtAttributeItemName.Text.Trim());
          decimal adjustment = 0;
          decimal.TryParse(txtAdjustment.Text, out adjustment);
          attributeItem.Adjustment = adjustment;
          if (!string.IsNullOrEmpty(txtSkuSuffix.Text)) {
            attributeItem.SkuSuffix = txtSkuSuffix.Text;
          }
          else {
            attributeItem.SkuSuffix = CoreUtility.GenerateRandomString(3);
          }

          attributeItem.Save(WebUtility.GetUserName());
          LoadAttributeItems();
          ResetAttributeItem();
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(attributeedit).Name + ".btnAdd_Click", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the lbEdit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.CommandEventArgs"/> instance containing the event data.</param>
    protected void lbEdit_Click(object sender, CommandEventArgs e) {
      try {
        int attributeId = 0;
        int.TryParse(e.CommandArgument.ToString(), out attributeId);
        if (attributeId > 0) {
          Store.Attribute attribute = new Store.Attribute(attributeId);
          lblAttributeId.Text = attributeId.ToString();
          txtName.Text = attribute.Name;
          ddlAttributeType.SelectedValue = attribute.AttributeTypeId.ToString();
          txtLabel.Text = attribute.Label;
          pnlAttributeItems.Visible = true;
          LoadAttributeItems();
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(attributeedit).Name + ".lbEdit_Click", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the attribute item delete.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.CommandEventArgs"/> instance containing the event data.</param>
    protected void lbAttributeItemDelete(object sender, CommandEventArgs e) {
      try {
        int attributeItemId = 0;
        int.TryParse(e.CommandArgument.ToString(), out attributeItemId);
        if (attributeItemId > 0) {
          AttributeItem.Delete(attributeItemId);
          LoadAttributeItems();
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(attributeedit).Name + ".lbAttributeItemDelete", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the AttributeItem Edit.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.CommandEventArgs"/> instance containing the event data.</param>
    protected void lbAttributeItemEdit(object sender, CommandEventArgs e) {
      try {
        int attributeItemId = 0;
        int.TryParse(e.CommandArgument.ToString(), out attributeItemId);
        if (attributeItemId > 0) {
          AttributeItem attributeItem = new AttributeItem(attributeItemId);
          lblAttributeItemId.Text = attributeItem.AttributeItemId.ToString();
          txtAttributeItemName.Text = attributeItem.Name;
          txtAdjustment.Text = StoreUtility.GetFormattedAmount(attributeItem.Adjustment, false);
          txtSkuSuffix.Text = attributeItem.SkuSuffix;
          btnAdd.Text = LocalizationUtility.GetText("lblEdit");
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(attributeedit).Name + ".lbAttributeItemEdit", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the ItemReorder event of the Items control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Items_ItemReorder(object sender, EventArgs e) {
      try {
        int attributeId = 0;
        int.TryParse(lblAttributeId.Text, out attributeId);
        ImageButton theButton = sender as ImageButton;
        Query query = new Query(AttributeItem.Schema).
          WHERE(AttributeItem.Columns.AttributeId, Comparison.Equals, attributeId).
          ORDER_BY(AttributeItem.Columns.SortOrder);
        AttributeItemCollection attributeItemCollection = new AttributeItemController().FetchByQuery(query);
        if (attributeItemCollection != null) {
          int attributeItemId = 0;
          int.TryParse(theButton.CommandArgument.ToString(), out attributeItemId);
          if (attributeItemId > 0) {
            AttributeItem attributeItemMoved = attributeItemCollection.Find(delegate(AttributeItem attributeItem) {
              return attributeItem.AttributeItemId == attributeItemId;
            });
            int index = attributeItemCollection.IndexOf(attributeItemMoved);
            attributeItemCollection.RemoveAt(index);
            if (theButton.CommandName.ToLower() == "up") {
              attributeItemCollection.Insert(index - 1, attributeItemMoved);
            }
            else if (theButton.CommandName.ToLower() == "down") {
              attributeItemCollection.Insert(index + 1, attributeItemMoved);
            }
            int i = 1;
            foreach (AttributeItem attributeItem in attributeItemCollection) {
              attributeItem.SortOrder = i++;
            }
            attributeItemCollection.SaveAll(WebUtility.GetUserName());
            LoadAttributeItems();
          }
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(attributeedit).Name + ".Items_ItemReorder", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnReset control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnReset_Click(object sender, EventArgs e) {
      Response.Redirect("~/admin/attributeedit.aspx");
    }

    /// <summary>
    /// Handles the ItemDataBound event of the dgAttributes control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridItemEventArgs"/> instance containing the event data.</param>
    void dgAttributes_ItemDataBound(object sender, DataGridItemEventArgs e) {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        LinkButton linkbutton = e.Item.Cells[0].FindControl("lbEdit") as LinkButton;
        if (linkbutton != null) {
          linkbutton.Text = LocalizationUtility.GetText("lblEdit");
        }
      }
    }

    /// <summary>
    /// Handles the ItemDataBound event of the dgAttributeItems control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridItemEventArgs"/> instance containing the event data.</param>
    void dgAttributeItems_ItemDataBound(object sender, DataGridItemEventArgs e) {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {

        e.Item.Cells[3].Text = StoreUtility.GetFormattedAmount(DataBinder.Eval(e.Item.DataItem, "Adjustment").ToString(), true);

        LinkButton editButton = e.Item.Cells[0].FindControl("lbAttrbuteItemEdit") as LinkButton;
        if (editButton != null) {
          editButton.Text = LocalizationUtility.GetText("lblEdit");
        }
        LinkButton deleteButton = e.Item.Cells[5].FindControl("lbAttrbuteItemDelete") as LinkButton;
        if (deleteButton != null) {
          deleteButton.Text = LocalizationUtility.GetText("lblDelete");
          deleteButton.Attributes.Add("onclick", "return confirm(\"" + LocalizationUtility.GetText("lblConfirmDelete") + "\");return false;");
        }
      }
    }

    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Sets the attribute edit properties.
    /// </summary>
    private void SetAttributeEditProperties() {
      this.Title = LocalizationUtility.GetText("titleProductAttributes");
      lblAdjustmentCurrencySymbol.Text = cultureInfo.NumberFormat.CurrencySymbol;
    }

    /// <summary>
    /// Loads the attribute types.
    /// </summary>
    private void LoadAttributeTypes() {
      AttributeTypeCollection attributeTypeCollection = new AttributeTypeController().FetchAll();
      if(attributeTypeCollection.Count > 0) {
        ddlAttributeType.DataSource = attributeTypeCollection;
        ddlAttributeType.DataTextField = "Name";
        ddlAttributeType.DataValueField = "AttributeTypeId";
        ddlAttributeType.DataBind();
      }
    }

    /// <summary>
    /// Loads the attributes.
    /// </summary>
    private void LoadAttributes() {
      Store.AttributeCollection attributeCollection = new Store.AttributeController().FetchAll();
      if(attributeCollection.Count > 0) {
        pnlCurrentAttributes.Visible = true;
        dgAttributes.DataSource = attributeCollection;
        dgAttributes.ItemDataBound += new DataGridItemEventHandler(dgAttributes_ItemDataBound);
        dgAttributes.Columns[0].HeaderText = LocalizationUtility.GetText("hdrEdit");
        dgAttributes.Columns[1].HeaderText = LocalizationUtility.GetText("hdrName");
        dgAttributes.Columns[2].HeaderText = LocalizationUtility.GetText("hdrAttributeType");
        dgAttributes.DataBind();
      }
      else {
        pnlCurrentAttributes.Visible = false;
      }
    }

    /// <summary>
    /// Resets the attribute item.
    /// </summary>
    private void ResetAttributeItem() {
      lblAttributeItemId.Text = string.Empty;
      txtAttributeItemName.Text = string.Empty;
      txtAdjustment.Text = string.Empty;
      txtSkuSuffix.Text = string.Empty;
    }

    /// <summary>
    /// Loads the attribute items.
    /// </summary>
    private void LoadAttributeItems() {
      int attributeId = 0;
      int.TryParse(lblAttributeId.Text, out attributeId);
      AttributeItemCollection attributeItemCollection = new AttributeItemCollection().Where(AttributeItem.Columns.AttributeId, Comparison.Equals, attributeId).OrderByAsc("SortOrder").Load();
      dgAttributeItems.DataSource = attributeItemCollection;
      dgAttributeItems.ItemDataBound += new DataGridItemEventHandler(dgAttributeItems_ItemDataBound);
      dgAttributeItems.Columns[0].HeaderText = LocalizationUtility.GetText("hdrEdit");
      dgAttributeItems.Columns[1].HeaderText = LocalizationUtility.GetText("hdrMove");
      dgAttributeItems.Columns[2].HeaderText = LocalizationUtility.GetText("hdrName");
      dgAttributeItems.Columns[3].HeaderText = LocalizationUtility.GetText("hdrAdjustment");
      dgAttributeItems.Columns[4].HeaderText = LocalizationUtility.GetText("hdrSkuSuffix");
      dgAttributeItems.Columns[5].HeaderText = LocalizationUtility.GetText("hdrDelete");
      dgAttributeItems.DataBind();
      if(attributeItemCollection.Count > 0) {
        ImageButton lbUp = dgAttributeItems.Items[0].Cells[1].FindControl("lbUp") as ImageButton;
        if(lbUp != null) {
          lbUp.Visible = false;
        }
        ImageButton lbDown = dgAttributeItems.Items[dgAttributeItems.Items.Count - 1].Cells[1].FindControl("lbDown") as ImageButton;
        if(lbDown != null) {
          lbDown.Visible = false;
        }
      }
    }

    #endregion

    #endregion

  }
}
