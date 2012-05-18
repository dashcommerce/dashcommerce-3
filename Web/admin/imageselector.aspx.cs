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
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Core.IO;
using MettleSystems.dashCommerce.Localization;
using SubSonic.Utilities;
using Img = System.Drawing;

namespace MettleSystems.dashCommerce.Web.admin {
  public partial class imageselector : MettleSystems.dashCommerce.Store.Web.AdminPage {

    #region Constants

    private const string CATEGORY_IMAGE_PATH = @"~/repository/category/";
    private const string PRODUCT_IMAGE_PATH = @"~/repository/product/";
    private const string PRODUCT_IMAGE_THUMB_PATH = @"~/repository/product/thumbs/";
    private const string SITE_IMAGE_PATH = @"~/repository/site/";

    #endregion

    #region Member Variables

    private string view = string.Empty;
    private string controlId = string.Empty;
    private List<Image> imageList = new List<Image>();
    private string path = string.Empty;
    private string pathToThumb = string.Empty;
    private string[] acceptedFileTypes = new string[] {".jpg", ".jpeg", ".jpe", ".gif", ".bmp", ".png"};

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        controlId = Utility.GetParameter("controlId");
        view = Utility.GetParameter("view");
        SetImageSelectorProperties();
        switch(view) {
          case "c":
            pnlImages.GroupingText = LocalizationUtility.GetText("lblProductCategoryImages");
            path = CATEGORY_IMAGE_PATH;
            break;
          case "p":
            pnlImages.GroupingText = LocalizationUtility.GetText("lblProductImages");
            path = PRODUCT_IMAGE_PATH;
            break;
          case "s":
            pnlImages.GroupingText = LocalizationUtility.GetText("lblSiteImages");
            path = SITE_IMAGE_PATH;
            break;
        }
        if(!Page.IsPostBack) {
          LoadImageList();
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(imageselector).Name + ".Page_Load", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnUpload control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnUpload_Click(object sender, EventArgs e) {
      try {
        HttpPostedFile file = fuFile.PostedFile;
        fuFile.Dispose();
        if (!IsValidFileType(Path.GetExtension(file.FileName))) {
          throw new ArgumentOutOfRangeException("file", "File is not of valid type.");
        }
        if(file.ContentLength > 0) {
          FileWriter fileWriter = new FileWriter();
          string finalPath = HttpContext.Current.Server.MapPath(path) + fuFile.FileName;
          fileWriter.Write(finalPath, file.InputStream);

          if (SiteSettings.GenerateThumbs) {
            ImageProcess.ResizeAndSave(fuFile.FileContent, fuFile.FileName, HttpContext.Current.Server.MapPath(PRODUCT_IMAGE_THUMB_PATH), SiteSettings.ThumbSmallWidth, SiteSettings.ThumbSmallHeight);
          }
          LoadImageList();
          Master.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblImageSaved"));
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(imageselector).Name + ".btnUpload_Click", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }    

    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Loads the image list.
    /// </summary>
    private void LoadImageList() {
      FetchImageList(path);
      dlImages.DataSource = imageList;
      dlImages.DataBind();
    }

    /// <summary>
    /// Fetches the image list.
    /// </summary>
    /// <param name="path">The path.</param>
    private void FetchImageList(string path) {
      string mappedPath = HttpContext.Current.Server.MapPath(path);
      string[] images = Directory.GetFiles(mappedPath);
      bool mediumTrust = false;
      FileInfo fileInfo;
      try {
        fileInfo = new FileInfo(path);
      }
      catch (System.Security.SecurityException) {
        mediumTrust = true;
      }
      foreach(string img in images) {
        if (IsValidFileType(Path.GetExtension(img))) {
          Image image = new Image();
          image.ImageUrl = ImageProcess.GetProductThumbnailUrl(path + Path.GetFileName(img));
          image.Attributes.Add("ondblclick", "javascript:window.top.document.getElementById(\'" + controlId + "\').value=\"" + path + Path.GetFileName(img) + "\";window.top.hidePopWin(true);");
          if (!mediumTrust) {
            fileInfo = new FileInfo(img);
            image.Attributes.Add("created", fileInfo.LastWriteTimeUtc.ToString());
          }
          using (Img.Image drawnImage = Img.Image.FromFile(img)) {
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
          imageList.Add(image);
        }
      }
      if (!mediumTrust)
        imageList.Sort(delegate(Image a, Image b) { return Convert.ToDateTime(b.Attributes["created"]).CompareTo(Convert.ToDateTime(a.Attributes["created"])); });
    }

    /// <summary>
    /// Sets the image selector properties.
    /// </summary>
    private void SetImageSelectorProperties() {
      this.Title = LocalizationUtility.GetText("titleImageSelector");
    }

    /// <summary>
    /// Determines whether [is valid file type] [the specified extension].
    /// </summary>
    /// <param name="extension">The extension.</param>
    /// <returns>
    /// 	<c>true</c> if [is valid file type] [the specified extension]; otherwise, <c>false</c>.
    /// </returns>
    private bool IsValidFileType(string extension) {
      Predicate<string> match = delegate(string extensionToMatch) { return string.Equals(extensionToMatch, extension, StringComparison.OrdinalIgnoreCase); };
      return Array.Exists(acceptedFileTypes, match);
    }

    #endregion

    #endregion

  }
}
