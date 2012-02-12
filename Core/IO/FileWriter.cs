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
