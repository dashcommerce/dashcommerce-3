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
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MettleSystems.dashCommerce.Core;

namespace MettleSystems.dashCommerce.Store.Web {
  public partial class dashCommerceMasterPage : MasterPage {

    #region Member Variables

    private SiteSettings _siteSettings;

    #endregion

    #region Page Events

    protected override void Render(HtmlTextWriter writer) {
      try {
        HtmlGenericControl allContent = null;
        if (this.Master != null) {
          allContent = this.Master.FindControl("allContent") as HtmlGenericControl;
        }
        else {
          allContent = this.FindControl("allContent") as HtmlGenericControl;
        }

        HyperLink hlpwdby = new HyperLink();
        hlpwdby.Text = this.GetText;
        hlpwdby.NavigateUrl = this.GetLink;
        hlpwdby.Attributes.Add("style", this.GetStyle);
        hlpwdby.Target = this.GetTarget;
        hlpwdby.EnableViewState = false;

        allContent.Controls.Add(hlpwdby);
        allContent.Controls.Add(new LiteralControl("<br/><br/>"));

        HttpContext.Current.Response.Headers.Add(this.HeaderTitle, this.ApplicationName);

        var htmlMeta = new HtmlMeta();
        htmlMeta.Name = this.MetaGen;
        htmlMeta.Content = this.ApplicationName;
        this.Page.Header.Controls.Add(htmlMeta);

        base.Render(writer);
      }
      catch (Exception ex) {
        Logger.Error("MasterPage.Render", ex);
      }
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the site settings.
    /// </summary>
    /// <value>The site settings.</value>
    public SiteSettings SiteSettings {
      get {
        if (_siteSettings == null)
          _siteSettings = Core.Caching.SiteSettingCache.GetSiteSettings();
        return _siteSettings;
      }
    }

    private string GetText {
      get {
        ASCIIEncoding encoding = new ASCIIEncoding();
        byte[] characters = new byte[23] { 80, 111, 119, 101, 114, 101, 100, 32, 98, 121, 32, 100, 97, 115, 104, 67, 111, 109, 109, 101, 114, 99, 101};
        string text = encoding.GetString(characters);
        return text;
      } 
    }

    private string GetLink {
      get {
        ASCIIEncoding encoding = new ASCIIEncoding();
        byte[] characters = new byte[27] { 104, 116, 116, 112, 58, 47, 47, 119, 119, 119, 46, 100, 97, 115, 104, 99, 111, 109, 109, 101, 114, 99, 101, 46, 111, 114, 103 };
        string link = encoding.GetString(characters);
        return link;
      }
    }

    private string GetTarget {
      get {
        ASCIIEncoding encoding = new ASCIIEncoding();
        byte[] characters = new byte[4] { 95, 110, 101, 119 };
        string target = encoding.GetString(characters);
        return target;        
      }
    }

    private string GetStyle {
      get {
        ASCIIEncoding encoding = new ASCIIEncoding();
        byte[] characters = new byte[40] { 102, 108, 111, 97, 116, 58, 108, 101, 102, 116, 59, 99, 111, 108, 111, 114, 58, 35, 57, 57, 57, 57, 57, 57, 59, 102, 111, 110, 116, 45, 115, 105, 122, 101, 58, 46, 56, 101, 109, 59 };
        string style = encoding.GetString(characters);
        return style;  
      }
    }

    private string HeaderTitle {
        get {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] characters = new byte[12] { 088, 045, 080, 111, 119, 101, 114, 101, 100, 045, 066, 121 };
            string headerTitle = encoding.GetString(characters);
            return headerTitle;
        }
    }

    private string ApplicationName {
        get {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] characters = new byte[12] { 100, 097, 115, 104, 067, 111, 109, 109, 101, 114, 099, 101 };
            string applicationName = encoding.GetString(characters);
            return applicationName;

        }
    }

    private string MetaGen
    {
        get
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] characters = new byte[9] { 103, 101, 110, 101, 114, 097, 116, 111, 114 };
            string metaGen = encoding.GetString(characters);
            return metaGen;

        }
    }
    #endregion
  }
}
