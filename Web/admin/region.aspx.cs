using System;
using System.Web.UI;

using MettleSystems.dashCommerce.Content;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin {
  public partial class region : MettleSystems.dashCommerce.Store.Web.AdminPage {
    
    #region Member Variables
    
    int pageId = -1;
    int regionId = -1;
    private Region _selectedRegion;
    #endregion
  
    protected void Page_Load(object sender, EventArgs e) {
      try {
        pageId = Utility.GetIntParameter("pageId");
        regionId = Utility.GetIntParameter("regionId");
        //TODO: CMC - set page title here
        this.Title = LocalizationUtility.GetText("titleAddEditRegion"); 
        if(regionId <= 0) {
          _selectedRegion = new Region();
          _selectedRegion.RegionGuid = Guid.NewGuid();
        }
        else {
          _selectedRegion = new Region(regionId);
        }
        if(!Page.IsPostBack) {
          Content.Page _selectedPage = new Content.Page(pageId);
        
          ProviderCollection providerCollection = new ProviderController().FetchAll();
          ddlProvider.DataSource = providerCollection;
          ddlProvider.DataValueField = "ProviderId";
          ddlProvider.DataTextField = "Name";
          ddlProvider.DataBind();

          TemplateRegionCollection templateRegionCollection = new TemplateRegionController().FetchByTemplateId(_selectedPage.TemplateId);
          ddlTemplateRegion.DataSource = templateRegionCollection;
          ddlTemplateRegion.DataValueField = "TemplateRegionId";
          ddlTemplateRegion.DataTextField = "Name";
          ddlTemplateRegion.DataBind();
        
          txtTitle.Text = _selectedRegion.Title;
          chkShowTitle.Checked = _selectedRegion.ShowTitle;
          txtSortOrder.Text = _selectedRegion.SortOrder.ToString();
          ddlProvider.SelectedValue = _selectedRegion.ProviderId.ToString();
          ddlTemplateRegion.SelectedValue = _selectedRegion.TemplateRegionId.ToString();
        
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(region).Name, ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    protected void btnSave_Click(object sender, EventArgs e) {
      try {
        //1st save off the region
        _selectedRegion.Title = txtTitle.Text.Trim();
        _selectedRegion.ProviderId = int.Parse(ddlProvider.SelectedValue);
        _selectedRegion.TemplateRegionId = int.Parse(ddlTemplateRegion.SelectedValue);
        int sortOrder = 1;
        int.TryParse(txtSortOrder.Text, out sortOrder);
        _selectedRegion.SortOrder = sortOrder;
        _selectedRegion.ShowTitle = chkShowTitle.Checked;
        _selectedRegion.Save(WebUtility.GetUserName());

        //2nd join it up with the page
        int rowsAffected = new RegionController().JoinToPage(_selectedRegion.RegionId, pageId);

        Provider provider = new Provider(int.Parse(ddlProvider.SelectedValue));
        Response.Redirect(string.Format("~/admin/provider.aspx?pageId={0}&regionId={1}&providerId={2}", pageId, _selectedRegion.RegionId, provider.ProviderId), true);
      }
      catch (System.Threading.ThreadAbortException) {
          throw;
      }
      catch(Exception ex) {
        Logger.Error(typeof(region).Name, ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }


  }
}
