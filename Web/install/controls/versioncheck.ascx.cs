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
using System.Configuration;

namespace MettleSystems.dashCommerce.Web.install.controls {

  public partial class versioncheck : InstallControl {

    #region Constants
    
    private string NOT_INSTALLED = "Not Installed";
    private string OH_OH_OH_OH = "0.0.0.0";
    private string THREE_OH_RC = "3.0 RC";
    private string THREE_OH_OH_OH = "3.0.0.0";
    private string THREE_OH_ONE_OH = "3.0.1.0";
    private string THREE_TWO_OH_OH = "3.2.0.0";
    private string THREE_THREE_OH_OH = "3.3.0.0";

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected override void Page_Load(object sender, EventArgs e) {
      base.Page_Load(sender, e);
      if (!Page.IsPostBack) {
        txtVersionNumber.Text = OH_OH_OH_OH;
        //Session["ConnectionString"] = ConfigurationManager.ConnectionStrings["dashCommerce"].ConnectionString;
      }
    }

    /// <summary>
    /// Handles the Click event of the btnTestVersion control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void btnTestVersion_Click(object sender, EventArgs e) {
      try {
        CheckVersion();
        if (txtVersionNumber.Text.Equals(THREE_TWO_OH_OH)) {
          chkReInstall.Visible = true;
        }
      }
      catch (Exception ex) {
        MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the chkReInstall control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void chkReInstall_Click(object sender, EventArgs e) {
      txtVersionNumber.Text = NOT_INSTALLED;
      Session["Version"] = NOT_INSTALLED;
      chkReInstall.Visible = true;
      btnNext.Enabled = true;
    }

    /// <summary>
    /// Handles the Click event of the btnNext control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected override void btnNext_Click(object sender, EventArgs e) {
      try {
        base.RunScripts(WebUtility.ConnectionString, Request.QueryString["selected_language"], Session["Version"].ToString());
        base.btnNext_Click(sender, e);
      }
      catch (Exception ex) {
        MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Checks the version.
    /// </summary>
    private void CheckVersion() {
      string version = OH_OH_OH_OH;
      string versionTable = "SELECT COUNT(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Version]') AND type in (N'U')";
      int count = (int)base.ExecuteStatement(versionTable, WebUtility.ConnectionString);
      if (count > 0) {
        string versionTableVersion = "SELECT CONVERT(nvarchar, Major) + '.' + CONVERT(nvarchar, Minor) + '.' + CONVERT(nvarchar, Build) + '.' + CONVERT(nvarchar, Revision) AS Version FROM dashCommerce_Store_Version";
        version = (string)base.ExecuteStatement(versionTableVersion, WebUtility.ConnectionString);
        //TODO: Not sure I like this . . 
        if (version == null) { //there is no version number in it, so something went screwy somewhere, so reinstall
          version = NOT_INSTALLED;  
        }
      }
      else {
        string dcexists = "SELECT COUNT(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Core_ConfigurationData]') AND type in (N'U')";
        count = (int)base.ExecuteStatement(dcexists, WebUtility.ConnectionString);
        if (count == 0) {
          version = NOT_INSTALLED;
        }
        else {
          string dc30 = "SELECT COUNT(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Core_StateOrRegion]') AND type in (N'U')";
          count = (int)base.ExecuteStatement(dc30, WebUtility.ConnectionString);
          if (count == 0) {
            version = THREE_OH_RC;
          }
          if (count == 1) {
            version = THREE_OH_OH_OH;
            string dc31 = "SELECT COUNT(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_CustomizedProductDisplay]') AND type in (N'U')";
            count = (int)base.ExecuteStatement(dc31, WebUtility.ConnectionString);
            if (count == 1) {
              version = THREE_OH_ONE_OH;
            }
          }
        }
      }
      if (!version.Equals(OH_OH_OH_OH)) {
        btnNext.Enabled = true;
      }
      txtVersionNumber.Text = version;
      Session["Version"] = version;
    }

    #endregion

    #endregion

  }

}