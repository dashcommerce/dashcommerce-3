using System;
using System.Web;
using System.Web.UI;

using MettleSystems.dashCommerce.Content;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store.Web;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin.controls.content.html {
  public partial class edithtml : ProviderControl {

    #region Constants

    private const string CONTENT_PATH = @"~/repository/content/";

    #endregion
  
    #region Member Variables
    
    int regionId = -1;
    SimpleHtml _selectedSimpleHtml;
    
    #endregion

    #region Page Events

    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Init"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> object that contains the event data.</param>
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
      regionId = Utility.GetIntParameter("regionId");
      this.Page.Title = LocalizationUtility.GetText("titleAddEditRegion");
      if(regionId <= 0) {
        _selectedSimpleHtml = new SimpleHtml();
      }
      else {
        _selectedSimpleHtml = new SimpleHtml(SimpleHtml.Columns.RegionId, regionId);
      }
      if(!Page.IsPostBack) {
        txtHtml.Value = HttpUtility.HtmlDecode(_selectedSimpleHtml.Html);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e) {
      try {
        _selectedSimpleHtml.RegionId = base.RegionId;
        _selectedSimpleHtml.Html = HttpUtility.HtmlEncode(txtHtml.Value);
        _selectedSimpleHtml.Save(WebUtility.GetUserName());
        MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblPageSaved"));
      }
      catch(Exception ex) {
        MasterPage.MessageCenter.DisplayFailureMessage(string.Format(LocalizationUtility.GetText("lblCriticalError"), ex.Message));
      }
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the master page.
    /// </summary>
    /// <value>The master page.</value>
    public AdminMasterPage MasterPage
    {
        get
        {
            return this.Page.Master as AdminMasterPage;
        }
    }

    #endregion

  }
}