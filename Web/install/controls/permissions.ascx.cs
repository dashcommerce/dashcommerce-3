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
using System.Web.UI;


namespace MettleSystems.dashCommerce.Web.install.controls {
  public partial class permissions : InstallControl {

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected override void Page_Load(object sender, EventArgs e) {
      try {
        base.Page_Load(sender, e);
        Page.Form.DefaultButton = btnNext.UniqueID;
        CheckPermissions();        
      }
      catch (Exception ex) {
        MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Checks file write and delete permissions on the repository folder
    /// </summary>
    private void CheckPermissions() {
      try {
        //Testing Write Permissions
        File.Create(Server.MapPath(@"~\repository\installtest.txt")).Close();
        //Testing Delete Permissions
        File.Delete(Server.MapPath(@"~\repository\installtest.txt"));        
        //It's all good so lets skip this step.
        base.btnNext_Click(new object(), EventArgs.Empty); 
      }
      catch (Exception e) {
        MasterPage.MessageCenter.DisplayCriticalMessage(e.Message);
      }
    }

    #endregion

    #endregion

  }
}