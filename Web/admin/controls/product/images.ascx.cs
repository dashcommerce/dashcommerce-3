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
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store.Web.Controls;
using SubSonic;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin.controls.product {
  public partial class images : AdminControl {
  
    #region Member Variables

    private int productId = 0;
    private string view = string.Empty;
    
    #endregion
    
    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        productId = Utility.GetIntParameter("productId");
        view = Utility.GetParameter("view");
        if (view == "i") {
          SetImagesProperties();
          if (!Page.IsPostBack) {
            LoadProductImages();
          }
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(images).Name + ".Page_Load", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
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
          string imageId = lblImageId.Text;
          Where where = new Where();
          where.ColumnName = Store.Image.Columns.ProductId;
          where.DbType = DbType.Int32;
          where.ParameterValue = productId;
          Query query = new Query(Store.Image.Schema);
          object strSortOrder = query.GetMax(Store.Image.Columns.SortOrder, where);
          int maxSortOrder = 0;
          int.TryParse(strSortOrder.ToString(), out maxSortOrder);
          Store.Image image;
          if(!string.IsNullOrEmpty(imageId)) {
            image = new Store.Image(imageId);
          }
          else {
            image = new Store.Image();
            image.SortOrder = maxSortOrder + 1;
          }
          image.ProductId = productId;
          image.ImageFile = txtImageFile.Text.Trim();
          image.Caption = txtImageCaption.Text.Trim();
          image.Save(WebUtility.GetUserName());
          Store.Caching.ProductCache.RemoveImageCollectionFromCache(productId);
          Reset();
          LoadProductImages();
          base.MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblProductImageSaved"));
        }
        catch(Exception ex) {
          Logger.Error(typeof(images).Name + ".btnSave_Click", ex);
          base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
        }
      }
    }
    
    /// <summary>
    /// Handles the click event for deleting an image from server
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e) {
      string fileName = Path.GetFileName(txtImageFile.Text);
      File.Delete(Server.MapPath("~/repository/product/" + fileName));
      MasterPage.MessageCenter.DisplaySuccessMessage(string.Format("{0} {1}", fileName, LocalizationUtility.GetText("lblDeletedFromServer")));
      txtImageFile.Text = string.Empty;
    }

    /// <summary>
    /// Handles the Click event of the lbDelete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.CommandEventArgs"/> instance containing the event data.</param>
    protected void lbDelete_Click(object sender, CommandEventArgs e) {
      try {
        int imageId = 0;
        bool isParsed = int.TryParse(e.CommandArgument.ToString(), out imageId);
        if(isParsed) {
          Store.Image.Delete(imageId);
          Store.Caching.ProductCache.RemoveImageCollectionFromCache(productId);
          LoadProductImages();
          base.MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblProductImageDeleted"));
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(images).Name + ".lbDelete_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the lbEdit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.CommandEventArgs"/> instance containing the event data.</param>
    protected void lbEdit_Click(object sender, CommandEventArgs e) {
      try {
        int imageId = 0;
        bool isParsed = int.TryParse(e.CommandArgument.ToString(), out imageId);
        if(isParsed) {
          Store.Image image = new Store.Image(imageId);
          lblImageId.Text = image.ImageId.ToString();
          txtImageFile.Text = image.ImageFile;
          txtImageCaption.Text = image.Caption;
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(images).Name + ".lbEdit_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the ItemReorder event of the Items control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Items_ItemReorder(object sender, EventArgs e) {
      ImageButton theButton = sender as ImageButton;
      Query query = new Query(Store.Image.Schema).WHERE(Store.Image.Columns.ProductId, productId).ORDER_BY(Store.Image.Columns.SortOrder);
      Store.ImageCollection imageCollection = new Store.ImageController().FetchByQuery(query);
      if (imageCollection != null) {
        int imageId = 0;
        int.TryParse(theButton.CommandArgument, out imageId);
        if (imageId > 0) {
          Store.Image imageMoved = imageCollection.Find(delegate(Store.Image image) {
            return image.ImageId == imageId;
          });
          int index = imageCollection.IndexOf(imageMoved);
          imageCollection.RemoveAt(index);
          if (theButton.CommandName.ToLower() == "up") {
            imageCollection.Insert(index - 1, imageMoved);
          }
          else if (theButton.CommandName.ToLower() == "down") {
            imageCollection.Insert(index + 1, imageMoved);
          }
          int i = 1;
          foreach (Store.Image image in imageCollection) {
            image.SortOrder = i++;
          }
          imageCollection.SaveAll(WebUtility.GetUserName());
          LoadProductImages();
        }
      }
    }
    
    #endregion
    
    #region Events

    /// <summary>
    /// Handles the ItemDataBound event of the dgProductImages control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Web.UI.WebControls.DataGridItemEventArgs"/> instance containing the event data.</param>
    void dgProductImages_ItemDataBound(object sender, DataGridItemEventArgs e) {
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

        System.Web.UI.WebControls.Image image = e.Item.Cells[3].FindControl("productImage") as System.Web.UI.WebControls.Image;
        if(image != null) {
          string mappedPath = HttpContext.Current.Server.MapPath(image.ImageUrl);
          if (File.Exists(mappedPath)) {
            using (System.Drawing.Image drawnImage = System.Drawing.Image.FromFile(mappedPath)) {
              //do a little simple scaling
              //landscape
              if (drawnImage.Width > drawnImage.Height) {
                if (drawnImage.Width > 90) {
                  image.Width = 90;
                  image.Height = drawnImage.Height * 90 / drawnImage.Width;
                }
              }
              else { //portrait
                if (drawnImage.Height > 90) {
                  image.Height = 90;
                  image.Width = drawnImage.Width * 90 / drawnImage.Height;
                }
              }
            }
            HyperLink hoverlink = e.Item.Cells[3].FindControl("hlImage") as HyperLink;
            if (hoverlink != null) {
              LocalizationUtility.AddHoverHtml(hoverlink, string.Format("<img border=\"0\" src=\"{0}\"/>", Page.ResolveUrl(image.ImageUrl)));
            }
          }
        }
      }
    }    
    
    #endregion
    
    #region Methods
    
    #region Private

    /// <summary>
    /// Sets the images properties.
    /// </summary>
    private void SetImagesProperties() {
      this.Page.Title = LocalizationUtility.GetText("titleProductEditImages");    
      hlImageSelector.NavigateUrl = string.Format("~/admin/imageselector.aspx?view=p&controlId={0}", txtImageFile.ClientID);
    }

    /// <summary>
    /// Resets this instance.
    /// </summary>
    private void Reset() {
      txtImageFile.Text = string.Empty;
      txtImageCaption.Text = string.Empty;
    }

    /// <summary>
    /// Loads the product images.
    /// </summary>
    private void LoadProductImages() {
      Query query = new Query(Store.Image.Schema).WHERE(Store.Image.Columns.ProductId, productId).ORDER_BY(Store.Image.Columns.SortOrder);
      Store.ImageCollection imageCollection = new Store.ImageController().FetchByQuery(query);
      dgProductImages.DataSource = imageCollection;
      dgProductImages.ItemDataBound += new DataGridItemEventHandler(dgProductImages_ItemDataBound);
      dgProductImages.Columns[0].HeaderText = LocalizationUtility.GetText("hdrEdit");
      dgProductImages.Columns[1].HeaderText = LocalizationUtility.GetText("hdrMove");
      dgProductImages.Columns[2].HeaderText = LocalizationUtility.GetText("hdrSortOrder");
      dgProductImages.Columns[3].HeaderText = LocalizationUtility.GetText("hdrImage");
      dgProductImages.Columns[4].HeaderText = LocalizationUtility.GetText("hdrImageCaption");
      dgProductImages.Columns[5].HeaderText = LocalizationUtility.GetText("hdrDelete");
      dgProductImages.DataBind();
      if (dgProductImages.Items.Count > 0) {
        ImageButton lbUp = dgProductImages.Items[0].Cells[0].FindControl("lbUp") as ImageButton;
        if(lbUp != null) {
            lbUp.Visible = false;
        }
        ImageButton lbDown = dgProductImages.Items[dgProductImages.Items.Count - 1].Cells[0].FindControl("lbDown") as ImageButton;
        if(lbDown != null) {
            lbDown.Visible = false;
        }
      }
    }

    #endregion
    
    #endregion

  }
}
