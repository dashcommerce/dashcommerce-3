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
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MettleSystems.dashCommerce.Content;

namespace MettleSystems.dashCommerce.Web.controls.content.html {
  public partial class viewhtml : ProviderControl {
    
    protected void Page_Load(object sender, EventArgs e) {
      HtmlGenericControl divControl = new HtmlGenericControl("div");
      divControl.ID = "contentRegion";
      divControl.Attributes.Add("class", "contentRegion");
      Literal htmlControl = new Literal();
      SimpleHtml simpleHtml = new SimpleHtml("RegionId", base.RegionId);
      if(simpleHtml != null) {
        htmlControl.Text = HttpUtility.HtmlDecode(simpleHtml.Html);
      }
      else {
        htmlControl.Text = string.Empty;
      }
      divControl.Controls.Add(htmlControl);
      this.Controls.Add(divControl);
    }
  }
}