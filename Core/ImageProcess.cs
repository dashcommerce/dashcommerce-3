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
using System.IO;
using System.Web;
using MettleSystems.dashCommerce.Core.Caching;
using MettleSystems.dashCommerce.Store;

namespace MettleSystems.dashCommerce.Core {
  public class ImageProcess {    

    /// <summary>
    /// Gets the product thumbnail url if enabled
    /// </summary>
    /// <param name="imageUrl">url of the product image</param>
    /// <param name="server">instance of the HttpServerUtility</param>
    /// <returns>Thumbnail url</returns>
    public static string GetProductThumbnailUrl(string imageUrl) {
      SiteSettings siteSettings = SiteSettingCache.GetSiteSettings();
      if (siteSettings.GenerateThumbs) {
        string thumbnail = imageUrl.Replace("product/", string.Format("product/thumbs/{0}x{1}_", siteSettings.ThumbSmallWidth, siteSettings.ThumbSmallHeight));
        if (File.Exists(HttpContext.Current.Server.MapPath(thumbnail)))
          return thumbnail;
        else if (File.Exists(HttpContext.Current.Server.MapPath(imageUrl))) { //Thumbnails don't exist so lets generate them...
          try {
            using (FileStream fs = File.Open(HttpContext.Current.Server.MapPath(imageUrl), FileMode.Open, FileAccess.Read, FileShare.None)) {
              ImageProcess.ResizeAndSave(fs, Path.GetFileName(imageUrl), HttpContext.Current.Server.MapPath(@"~/repository/product/thumbs/"), siteSettings.ThumbSmallWidth, siteSettings.ThumbSmallHeight);
            }
          }
          catch {
            return imageUrl;
          }
          return thumbnail;
        }
      }
      return imageUrl;
    }

    /// <summary>
    /// Resizes images to the specified size.
    /// </summary>
    /// <param name="fileStream">The file stream.</param>
    /// <param name="fileName">Name of the file.</param>
    /// <param name="finalPath">Where to save the resized image</param>
    /// <param name="maxWidth">Maximum Width</param>
    /// <param name="maxHeight">Maximum Height</param>
    public static void ResizeAndSave(Stream fileStream, string fileName, string finalPath, int maxWidth, int maxHeight) {
      using (System.Drawing.Bitmap originalBMP = new System.Drawing.Bitmap(fileStream)) {
        // Calculate the new image dimensions
        int width = originalBMP.Width; //actual width
        int height = originalBMP.Height; //actual height
        int widthDiff = (width - maxWidth); //how far off maxWidth?
        int heightDiff = (height - maxHeight); //how far off maxHeight?
		
        //figure out which dimension is further outside the max size
        bool doWidthResize = (maxWidth > 0 && width > maxWidth && widthDiff > -1 && (widthDiff > heightDiff || maxHeight.Equals(0)));
        bool doHeightResize = (maxHeight > 0 && height > maxHeight && heightDiff > -1 && (heightDiff > widthDiff || maxWidth.Equals(0)));

        //only resize if the image is bigger than the max or where image is square, and the diffs are the same
        if (doWidthResize || doHeightResize || (width.Equals(height) && widthDiff.Equals(heightDiff))) {
          int iStart;
          Decimal divider;
          if (doWidthResize) {
            iStart = width;
            divider = Math.Abs((Decimal)iStart / (Decimal)maxWidth);
            width = maxWidth;
            height = (int)Math.Round((Decimal)(height / divider));
          } else {
            iStart = height;
            divider = Math.Abs((Decimal)iStart / (Decimal)maxHeight);
            height = maxHeight;
            width = (int)Math.Round((Decimal)(width / divider));
          }
        }

        using (System.Drawing.Bitmap newBMP = new System.Drawing.Bitmap(originalBMP, width, height)) {
          using (System.Drawing.Graphics oGraphics = System.Drawing.Graphics.FromImage(newBMP)) {
            oGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            oGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            oGraphics.DrawImage(originalBMP, 0, 0, width, height);
            newBMP.Save(string.Format("{0}{1}x{2}_{3}", finalPath, maxWidth, maxHeight, fileName));
          }
        }
      }
    }
  }
}
