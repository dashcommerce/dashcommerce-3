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
using System.Collections;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MettleSystems.dashCommerce.Content.Caching;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Content {

  public partial class PageBuilder : System.Web.UI.Page {

    #region Member Variables

    int pageId = 0;
    Page _page;
    protected HtmlMeta htmlMetaKeywords = new HtmlMeta();
    protected HtmlMeta htmlMetaDescription = new HtmlMeta();
    private string _title;

    #endregion

    protected override void OnInit(EventArgs e) {
      pageId = Utility.GetIntParameter("pageId");
      if (pageId > 0) {
        _page = PageCache.GetPageByID(pageId);
      }
      else {
        _page = PageCache.GetDefaultPage();
      }
      if (_page != null) {

        this._title = _page.Title;

        htmlMetaKeywords.Attributes.Add("name", "keywords");
        htmlMetaKeywords.Attributes.Add("content", _page.Keywords);
        Page.Header.Controls.Add(htmlMetaKeywords);

        htmlMetaDescription.Attributes.Add("name", "description");
        htmlMetaDescription.Attributes.Add("content", _page.Description);
        Page.Header.Controls.Add(htmlMetaDescription);

        Template template = new Template(_page.TemplateId);
        if (template.TemplateId > 0) {
          if (!string.IsNullOrEmpty(template.StyleSheet)) {
            Header.Controls.Add(new LiteralControl("<link ID=\"stylesheet\" rel=\"stylesheet\" type=\"text/css\" href=\"" + Page.ResolveUrl(template.StyleSheet) + "\" />"));
          }
        }

        //now get the template regions for this page
        TemplateRegionCollection templateRegionCollection = new TemplateRegionController().FetchByTemplateId(_page.TemplateId);
        //now get the regions for the page
        RegionCollection regionCollection = new RegionController().FetchRegionsByPageId(_page.PageId);
        regionCollection.OrderByAsc("SortOrder");
        HtmlGenericControl templateRegionControl;
        HtmlGenericControl regionControl;
        HtmlGenericControl regionTitleControl;
        foreach (TemplateRegion templateRegion in templateRegionCollection) {
          //1st, add the region
          templateRegionControl = new HtmlGenericControl("div");
          templateRegionControl.Attributes.Add("id", templateRegion.Name.Replace(" ", string.Empty).ToString());
          ((PlaceHolder)this.Placeholders["contentPlaceHolder"]).Controls.Add(templateRegionControl);
          //2nd, add the regions that belong in this control
          foreach (Region _region in regionCollection) {
            if (_region.TemplateRegionId == templateRegion.TemplateRegionId) { //then it belongs in this TemplateRegion 
              regionControl = new HtmlGenericControl("div");
              regionControl.Attributes.Add("class", "contentGroup");
              if (_region.ShowTitle) {
                regionTitleControl = new HtmlGenericControl("div");
                regionTitleControl.Attributes.Add("class", "contentGroupHeader");
                regionTitleControl.InnerHtml = "<span class=\"contentGroupHeaderText\">" + _region.Title + "</span>";
                regionControl.Controls.Add(regionTitleControl);
              }
              templateRegionControl.Controls.Add(regionControl);
              Provider _provider = new Content.Provider(_region.ProviderId);
              if (!string.IsNullOrEmpty(_provider.StyleSheet)) {
                Header.Controls.Add(new LiteralControl("<link ID=\"stylesheet\" rel=\"stylesheet\" type=\"text/css\" href=\"" + Page.ResolveUrl(_provider.StyleSheet) + "\" />"));
              }
              ProviderControl _providerControl = Page.LoadControl(_provider.ViewControl) as ProviderControl;
              _providerControl.PageId = _page.PageId;
              _providerControl.RegionId = _region.RegionId;
              _providerControl.ProviderId = _provider.ProviderId;
              regionControl.Controls.Add(_providerControl);
            }
          }
        }
      }

      base.OnInit(e);
    }

    public new string Title {
      get {
        return _title;
      }
      set {
        _title = value;
      }
    }


    public Hashtable Placeholders {
      get {
        Hashtable placeholders = new Hashtable();
        foreach (Control ctrl in Master.FindControl("ContentPlaceHolder1").Controls) {
          if (ctrl is PlaceHolder) {
            placeholders.Add(ctrl.ID, ctrl);
          }
        }
        return placeholders;
      }
    }

  }
}
