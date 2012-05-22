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
using System.Text;

using System.Data;
using System.Collections;


namespace MettleSystems.dashCommerce.Store {
  public partial class DownloadController {

    public DownloadCollection FetchPurchasedDownloadsByUserId(Guid userId) {
      IDataReader reader = SPs.FetchPurchasedDownloadsByUserId(userId).GetReader();
      DownloadCollection downloadCollection = new DownloadCollection();
      downloadCollection.LoadAndCloseReader(reader);
      return downloadCollection;
    }

    private static Hashtable fileTypeMap;


    public static string GetFileTypeIcon(string extension) {
      if (fileTypeMap == null) {
        InitMap();
      }
      string iconName = "file";
      if (fileTypeMap[extension] != null) {
        iconName = fileTypeMap[extension].ToString();
      }
      return iconName;
    }

    private static void InitMap() {
      fileTypeMap = new Hashtable();
      fileTypeMap.Add(".asf", "mpg");
      fileTypeMap.Add(".avi", "mpg");
      fileTypeMap.Add(".bmp", "bmp");
      fileTypeMap.Add(".chm", "chm");
      fileTypeMap.Add(".cs", "cs");
      fileTypeMap.Add(".doc", "doc");
      fileTypeMap.Add(".dot", "doc");
      fileTypeMap.Add(".exe", "exe");
      fileTypeMap.Add(".gif", "gif");
      fileTypeMap.Add(".gz", "zip");
      fileTypeMap.Add(".gzip", "zip");
      fileTypeMap.Add(".htm", "htm");
      fileTypeMap.Add(".html", "htm");
      fileTypeMap.Add(".jpg", "jpg");
      fileTypeMap.Add(".jpeg", "jpg");
      fileTypeMap.Add(".mdb", "mdb");
      fileTypeMap.Add(".mov", "mpg");
      fileTypeMap.Add(".mp3", "wav");
      fileTypeMap.Add(".mpg", "mpg");
      fileTypeMap.Add(".mpeg", "mpg");
      fileTypeMap.Add(".pdf", "pdf");
      fileTypeMap.Add(".ppt", "ppt");
      fileTypeMap.Add(".rar", "zip");
      fileTypeMap.Add(".rtf", "doc");
      fileTypeMap.Add(".tgz", "zip");
      fileTypeMap.Add(".txt", "txt");
      fileTypeMap.Add(".wav", "wav");
      fileTypeMap.Add(".wma", "wav");
      fileTypeMap.Add(".xls", "xls");
      fileTypeMap.Add(".xml", "xml");
      fileTypeMap.Add(".zip", "zip");
    }

  }
}
