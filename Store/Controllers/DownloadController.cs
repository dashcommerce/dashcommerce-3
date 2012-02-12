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
