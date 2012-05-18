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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Web.Controls;
using SubSonic;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin.controls.product {
  public partial class descriptors : AdminControl {
    
    #region Constants
    
    private const string CONTENT_PATH = @"~/repository/content/";
    
    #endregion

    #region Member Variables
    
    private int productId = 0;
    private string view = string.Empty;
    
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
        if(view == "d") {
          SetDescriptorsProperties();
          if(!Page.IsPostBack) {
            LoadDescriptors();
          }
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(descriptors).Name + ".Page_Load", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the ItemReorder event of the Items control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Items_ItemReorder(object sender, EventArgs e) {
      try {
        ImageButton theButton = sender as ImageButton;
        Query query = new Query(Descriptor.Schema).
          WHERE(Descriptor.Columns.ProductId, Comparison.Equals, productId).
          ORDER_BY(Descriptor.Columns.SortOrder);
        DescriptorCollection descriptorCollection = new DescriptorController().FetchByQuery(query);
        if(descriptorCollection != null) {
          int descriptorId = 0;
          int.TryParse(theButton.CommandArgument.ToString(), out descriptorId);
          if(descriptorId > 0) {
            Descriptor descriptorMoved = descriptorCollection.Find(delegate(Descriptor descriptor) {
              return descriptor.DescriptorId == descriptorId;
            });
            int index = descriptorCollection.IndexOf(descriptorMoved);
            descriptorCollection.RemoveAt(index);
            if(theButton.CommandName.ToLower() == "up") {
              descriptorCollection.Insert(index - 1, descriptorMoved);
            }
            else if(theButton.CommandName.ToLower() == "down") {
              descriptorCollection.Insert(index + 1, descriptorMoved);
            }
            int i = 1;
            foreach(Descriptor descriptor in descriptorCollection) {
              descriptor.SortOrder = i++;
            }
            descriptorCollection.SaveAll(WebUtility.GetUserName());
            LoadDescriptors();
          }
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(descriptors).Name + ".Items_ItemReorder", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Descriptor event of the Edit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridCommandEventArgs"/> instance containing the event data.</param>
    protected void Edit_Descriptor(object sender, DataGridCommandEventArgs e) {
      try {
        int descriptorId = 0;
        bool isParsed = int.TryParse(dgDescriptors.DataKeys[e.Item.ItemIndex].ToString(), out descriptorId);
        if(isParsed) {
          Descriptor descriptor = Descriptor.FetchByID(descriptorId);
          lblDescriptorId.Text = descriptor.DescriptorId.ToString();
          txtTitle.Text = descriptor.Title;
          txtDescriptor.Value = HttpUtility.HtmlDecode(descriptor.DescriptorX);
        }
        LoadDescriptors();
      }
      catch(Exception ex) {
        Logger.Error(typeof(descriptors).Name + ".Edit_Descriptor", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Descriptor event of the Delete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridCommandEventArgs"/> instance containing the event data.</param>
    protected void Delete_Descriptor(object sender, DataGridCommandEventArgs e) {
      try {
        int descriptorId = 0;
        if(int.TryParse(dgDescriptors.DataKeys[e.Item.ItemIndex].ToString(), out descriptorId)) {
          Descriptor.Delete(descriptorId);
          Store.Caching.ProductCache.RemoveDescriptorCollectionFromCache(productId);
        }
        LoadDescriptors();
        txtTitle.Text = string.Empty;
        txtDescriptor.Value = string.Empty;
      }
      catch(Exception ex) {
        Logger.Error(typeof(descriptors).Name + ".Delete_Descriptor", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e) {
      if(Page.IsValid){
        try {
          string descriptorId = lblDescriptorId.Text;
          Descriptor descriptor;
          Where where = new Where();
          where.ColumnName = Descriptor.Columns.ProductId;
          where.DbType = DbType.Int32;
          where.ParameterValue = productId;
          Query query = new Query(Descriptor.Schema);
          object strSortOrder = query.GetMax(Descriptor.Columns.SortOrder, where);
          int maxSortOrder = 0;
          int.TryParse(strSortOrder.ToString(), out maxSortOrder);
          if(!string.IsNullOrEmpty(descriptorId)) {
            descriptor = new Descriptor(descriptorId);
          }
          else {
            descriptor = new Descriptor();
            descriptor.SortOrder = maxSortOrder + 1;
          }
          descriptor.ProductId = productId;
          descriptor.Title = txtTitle.Text.Trim();
          descriptor.DescriptorX = HttpUtility.HtmlEncode(txtDescriptor.Value.Trim());
          descriptor.Save(WebUtility.GetUserName());
          Store.Caching.ProductCache.RemoveDescriptorCollectionFromCache(productId);
          LoadDescriptors();
          lblDescriptorId.Text = string.Empty;
          txtTitle.Text = string.Empty;
          txtDescriptor.Value = string.Empty;
          base.MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblDescriptorSaved"));
        }
        catch(Exception ex) {
          Logger.Error(typeof(descriptors).Name + "btnSave_Click", ex);
          base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
        }
      }
    }

    /// <summary>
    /// Handles the ItemDataBound event of the dgDescriptors control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridItemEventArgs"/> instance containing the event data.</param>
    private void dgDescriptors_ItemDataBound(object sender, DataGridItemEventArgs e) {
      if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        LinkButton editButton = e.Item.Cells[0].FindControl("lbEdit") as LinkButton;
        if(editButton != null) {
          editButton.Text = LocalizationUtility.GetText("lblEdit");
        }
        LinkButton deleteButton = e.Item.Cells[4].FindControl("lbDelete") as LinkButton;
        if(deleteButton != null) {
          deleteButton.Text = LocalizationUtility.GetText("lblDelete");
          deleteButton.Attributes.Add("onclick", "return confirm(\"" + LocalizationUtility.GetText("lblConfirmDelete") + "\");return false;");
        }
      }
    }
    
    #endregion
    
    #region Methods
    
    #region Protected

    /// <summary>
    /// Gets the stripped descriptor.
    /// </summary>
    /// <param name="descriptor">The descriptor.</param>
    /// <returns></returns>
    protected string GetStrippedDescriptor(string descriptor) {
      string strippedDescriptor = string.Empty;
      if(!string.IsNullOrEmpty(descriptor)) {
        strippedDescriptor = CoreUtility.StripHtml(HttpUtility.HtmlDecode(descriptor), string.Empty);
      }
      return strippedDescriptor;
    }    
    
    #endregion
    
    #region Private

    /// <summary>
    /// Loads the descriptors.
    /// </summary>
    private void LoadDescriptors() {
      Query query = new Query(Descriptor.Schema).
        WHERE(Descriptor.Columns.ProductId, Comparison.Equals, productId).
        ORDER_BY(Descriptor.Columns.SortOrder);
      DescriptorCollection descriptorCollection = new DescriptorController().FetchByQuery(query);
      if(descriptorCollection.Count > 0) {
        base.MasterPage.MessageCenter.ResetPanelsVisibility();
        pnlGrid.Visible = true;
        dgDescriptors.DataSource = descriptorCollection;
        dgDescriptors.ItemDataBound += new DataGridItemEventHandler(dgDescriptors_ItemDataBound);
        dgDescriptors.Columns[0].HeaderText = LocalizationUtility.GetText("hdrEdit");
        dgDescriptors.Columns[1].HeaderText = LocalizationUtility.GetText("hdrMove");
        dgDescriptors.Columns[2].HeaderText = LocalizationUtility.GetText("hdrTitle");
        dgDescriptors.Columns[3].HeaderText = LocalizationUtility.GetText("hdrSortOrder");
        dgDescriptors.Columns[4].HeaderText = LocalizationUtility.GetText("hdrDescriptor");
        dgDescriptors.Columns[5].HeaderText = LocalizationUtility.GetText("hdrDelete");
        dgDescriptors.DataBind();
        ImageButton lbUp = dgDescriptors.Items[0].Cells[1].FindControl("lbUp") as ImageButton;
        if(lbUp != null) {
          lbUp.Visible = false;
        }
        ImageButton lbDown = dgDescriptors.Items[dgDescriptors.Items.Count - 1].Cells[1].FindControl("lbDown") as ImageButton;
        if(lbDown != null) {
          lbDown.Visible = false;
        }
      }
      else {
        pnlGrid.Visible = false;
        base.MasterPage.MessageCenter.DisplayInformationMessage(LocalizationUtility.GetText("lblNoDescriptors"));
      }
    }

    /// <summary>
    /// Sets the descriptors properties.
    /// </summary>
    private void SetDescriptorsProperties() {
      this.Page.Title = LocalizationUtility.GetText("titleProductEditDescriptors");    
    }

    #endregion
    
    #endregion

  }
}
