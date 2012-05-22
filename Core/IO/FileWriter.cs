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

namespace MettleSystems.dashCommerce.Core.IO {
  
  public class FileWriter {
  
    #region Constants
    
    private const string PATH = "path";
    private const string FILE_EXISTS = "The file already exists.";
    private const string DIRECTORY_DOES_NOT_EXIST = "Directory does not exist: {0}";
    
    #endregion
    
    #region Methods
    
    #region Public

    public void Write(string path, Stream stream) {
      Validator.ValidateStringArgumentIsNotNullOrEmptyString(path, PATH);
      if(File.Exists(path)) {
        throw new ArgumentException(FILE_EXISTS, PATH);
      }

      string directoryName = Path.GetDirectoryName(path);
      if(!Directory.Exists(directoryName)) {
        throw new DirectoryNotFoundException(string.Format(DIRECTORY_DOES_NOT_EXIST, directoryName));
      }

      FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
      byte[] buffer = new byte[4096];
      int bytesRead;
      while((bytesRead = stream.Read(buffer, 0, 4096)) > 0) {
        fileStream.Write(buffer, 0, bytesRead);
      }
      fileStream.Flush();
      fileStream.Close();
    }
    
    #endregion
    
    #endregion
    
  }
}
