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