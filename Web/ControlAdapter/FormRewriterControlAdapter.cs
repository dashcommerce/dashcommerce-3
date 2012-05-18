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
/*
 * From ScottGu's Blog - Url="http://weblogs.asp.net/scottgu/archive/2007/02/26/tip-trick-url-rewriting-with-asp-net.aspx"
 * This will replace the forms action tag to be rewriten to the new url.
 */

using System.Web;

namespace MettleSystems.dashCommerce.Web.ControlAdapter {
  public class FormRewriterControlAdapter : System.Web.UI.Adapters.ControlAdapter {
    /// <summary>
    /// Generates the target-specific markup for the control to which the control adapter is attached.
    /// </summary>
    /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter"/> to use to render the target-specific output.</param>
    protected override void Render(System.Web.UI.HtmlTextWriter writer) {
      base.Render(new RewriteFormHtmlTextWriter(writer));
    }
  }

  public class RewriteFormHtmlTextWriter : System.Web.UI.HtmlTextWriter {
    
    /// <summary>
    /// Initializes a new instance of the <see cref="RewriteFormHtmlTextWriter"/> class.
    /// </summary>
    /// <param name="writer">The writer.</param>
    public RewriteFormHtmlTextWriter(System.IO.TextWriter writer)
      : base(writer) {
      base.InnerWriter = writer;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RewriteFormHtmlTextWriter"/> class.
    /// </summary>
    /// <param name="writer">The writer.</param>
    public RewriteFormHtmlTextWriter(System.Web.UI.HtmlTextWriter writer)
      : base(writer) {
      this.InnerWriter = writer.InnerWriter;
    }

    /// <summary>
    /// Writes the specified markup attribute and value to the output stream, and, if specified, writes the value encoded.
    /// </summary>
    /// <param name="name">The markup attribute to write to the output stream.</param>
    /// <param name="value">The value assigned to the attribute.</param>
    /// <param name="fEncode">true to encode the attribute and its assigned value; otherwise, false.</param>
    public override void WriteAttribute(string name, string value, bool fEncode) {
      // If the attribute we are writing is the "action" attribute, and we are not on a sub-control, 
      // then replace the value to write with the raw URL of the request - which ensures that we'll
      // preserve the PathInfo value on postback scenarios
      if (name == "action") {
        HttpContext Context;
        Context = HttpContext.Current;
        if (Context.Items["ActionAlreadyWritten"] == null) {
          // Because we are using the UrlRewriting.net HttpModule, we will use the 
          // Request.RawUrl property within ASP.NET to retrieve the origional URL
          // before it was re-written.  You'll want to change the line of code below
          // if you use a different URL rewriting implementation.
          value = Context.Request.RawUrl;

          // Indicate that we've already rewritten the <form>'s action attribute to prevent
          // us from rewriting a sub-control under the <form> control
          Context.Items["ActionAlreadyWritten"] = true;
        }
      }
      base.WriteAttribute(name, value, fEncode);
    }
  }
}