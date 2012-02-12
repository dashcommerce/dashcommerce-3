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