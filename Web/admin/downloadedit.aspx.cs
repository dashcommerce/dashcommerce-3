using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.IO;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Core.IO;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;


namespace MettleSystems.dashCommerce.Web.admin {
  public partial class downloadedit : System.Web.UI.Page {
    #region Constants

    private const string CONTENT_PATH = @"~/repository/content/";
    private const string DOWNLOAD_PATH = @"~/repository/download/";

    #endregion

    #region Member Variables

    #endregion

    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Init"></see> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> object that contains the event data.</param>
    protected override void OnInit(EventArgs e) {
      Session["FCKeditor:UserFilesPath"] = CONTENT_PATH;
      base.OnInit(e);
    }

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        SetDownloadProperties();
        if (!Page.IsPostBack) {
          LoadDownloads();
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(downloadedit).Name + ".Page_Load", ex);
        Master.MessageCenter.DisplayCriticalMessage(LocalizationUtility.GetCriticalMessageText(ex.Message));
      }
    }

    /// <summary>
    /// Loads the downloads.
    /// </summary>
    private void LoadDownloads() {
      DownloadCollection artifactCollection = new DownloadController().FetchAll();//FetchByProductId(productId);
      dgDownloads.DataSource = artifactCollection;
      dgDownloads.ItemDataBound += new DataGridItemEventHandler(dgDownloads_ItemDataBound);
      dgDownloads.Columns[0].HeaderText = LocalizationUtility.GetText("hdrEdit");
      dgDownloads.Columns[1].HeaderText = LocalizationUtility.GetText("hdrForPurchaseOnly");
      dgDownloads.Columns[2].HeaderText = LocalizationUtility.GetText("hdrTitle");
      dgDownloads.Columns[3].HeaderText = LocalizationUtility.GetText("hdrPath");
      dgDownloads.Columns[4].HeaderText = LocalizationUtility.GetText("hdrDelete");
      dgDownloads.DataBind();
    }

    /// <summary>
    /// Handles the ItemDataBound event of the dgDownloads control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.DataGridItemEventArgs"/> instance containing the event data.</param>
    void dgDownloads_ItemDataBound(object sender, DataGridItemEventArgs e) {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
        LinkButton editButton = e.Item.Cells[0].FindControl("lbEdit") as LinkButton;
        if (editButton != null) {
          editButton.Text = LocalizationUtility.GetText("lblEdit");
        }
        LinkButton deleteButton = e.Item.Cells[4].FindControl("lbDelete") as LinkButton;
        if (deleteButton != null) {
          deleteButton.Text = LocalizationUtility.GetText("lblDelete");
          deleteButton.Attributes.Add("onclick", "return confirm(\"" + LocalizationUtility.GetText("lblConfirmDelete") + "\");return false;");
        }
      }
    }

    /// <summary>
    /// Handles the Download event of the Delete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.DataGridCommandEventArgs"/> instance containing the event data.</param>
    protected void Delete_Download(object sender, DataGridCommandEventArgs e) {
      try {
        int artifactId = 0;
        bool isParsed = int.TryParse(dgDownloads.DataKeys[e.Item.ItemIndex].ToString(), out artifactId);
        if (isParsed) {
          Download artifact = new Download(artifactId);
          File.Delete(Server.MapPath(artifact.DownloadFile));
          Download.Delete(artifactId);
        }
        LoadDownloads();
        txtTitle.Text = string.Empty;
        txtDescriptor.Value = string.Empty;
      }
      catch (Exception ex) {
        Logger.Error(typeof(downloadedit).Name + ".Delete_Download", ex);
        Master.MessageCenter.DisplayCriticalMessage(LocalizationUtility.GetCriticalMessageText(ex.Message));
      }
    }

    /// <summary>
    /// Handles the Download event of the Edit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.DataGridCommandEventArgs"/> instance containing the event data.</param>
    protected void Edit_Download(object sender, DataGridCommandEventArgs e) {
      try {
        int artifactId = 0;
        bool isParsed = int.TryParse(dgDownloads.DataKeys[e.Item.ItemIndex].ToString(), out artifactId);
        if (isParsed) {
          Download artifact = Download.FetchByID(artifactId);
          lblDownloadId.Text = artifact.DownloadId.ToString();
          txtTitle.Text = artifact.Title;
          txtDescriptor.Value = HttpUtility.HtmlDecode(artifact.Description);
          chkForPurchaseOnly.Checked = artifact.ForPurchaseOnly;
        }
        LoadDownloads();
      }
      catch (Exception ex) {
        Logger.Error(typeof(downloadedit).Name + ".Edit_Download", ex);
        Master.MessageCenter.DisplayCriticalMessage(LocalizationUtility.GetCriticalMessageText(ex.Message));
      }
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e) {
      try {
        HttpPostedFile file = fuFile.PostedFile;
        if (file.ContentLength > 0) {
          FileWriter fileWriter = new FileWriter();
          string finalPath = HttpContext.Current.Server.MapPath(DOWNLOAD_PATH) + fuFile.FileName;
          fileWriter.Write(finalPath, file.InputStream);
        }
        Download artifact = null;
        if (!string.IsNullOrEmpty(lblDownloadId.Text)) {
          artifact = new Download(lblDownloadId.Text.Trim());
        }
        else {
          artifact = new Download();
        }
        artifact.DownloadFile = (file.ContentLength > 0) ? DOWNLOAD_PATH + fuFile.FileName : artifact.DownloadFile;
        artifact.Title = txtTitle.Text;
        artifact.Description = HttpUtility.HtmlEncode(txtDescriptor.Value);
        artifact.ForPurchaseOnly = chkForPurchaseOnly.Checked;
        artifact.ContentType = (file.ContentLength > 0) ? file.ContentType : artifact.ContentType;
        artifact.Save(WebUtility.GetUserName());
        chkForPurchaseOnly.Checked = false;
        txtTitle.Text = string.Empty;
        txtDescriptor.Value = string.Empty;
        LoadDownloads();
        Master.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblDownloadSaved"));
      }
      catch (Exception ex) {
        Logger.Error(typeof(downloadedit).Name + ".btnSave_Click", ex);
        Master.MessageCenter.DisplayCriticalMessage(LocalizationUtility.GetCriticalMessageText(ex.Message));
      }
    }

    private void SetDownloadProperties() {
      this.Title = LocalizationUtility.GetText("titleProductDownloads");
      tpFile.HeaderText = LocalizationUtility.GetText("tpFile");
    }

  }
}
