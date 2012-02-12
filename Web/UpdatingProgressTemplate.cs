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
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MettleSystems.dashCommerce.Web {
  public class UpdatingProgressTemplate : TemplateControl, ITemplate {
  
    #region Member Variables
    
    private string _template;
    private List<Control> _controlCollection;
    
    #endregion
    
    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="T:UpdatingProgressTemplate"/> class.
    /// </summary>
    public UpdatingProgressTemplate() {
      _controlCollection = new List<Control>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:UpdatingProgressTemplate"/> class.
    /// </summary>
    /// <param name="template">The template.</param>
    public UpdatingProgressTemplate(string template) {
      _template = template;
    }
    
    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the control collection.
    /// </summary>
    /// <value>The control collection.</value>
    public List<Control> ControlCollection {
      get {
        return _controlCollection;
      }
      set {
        _controlCollection = value;
      }
    }
    
    #endregion
  
    #region ITemplate Members

    /// <summary>
    /// When implemented by a class, defines the <see cref="T:System.Web.UI.Control"></see> object that child controls and templates belong to. These child controls are in turn defined within an inline template.
    /// </summary>
    /// <param name="container">The <see cref="T:System.Web.UI.Control"></see> object to contain the instances of controls from the inline template.</param>
    public void InstantiateIn(Control container) {
      if(_template != null) {
        LiteralControl control = new LiteralControl(_template);
        container.Controls.Add(control);
      }
      else {
        if(_controlCollection.Count == 0) {
          BuildDefaultTemplate();
        }
        foreach(Control control in _controlCollection) {
          container.Controls.Add(control);
        }
      }
    }

    #endregion
    
    #region Methods
    
    #region Private

    /// <summary>
    /// Builds the default template.
    /// </summary>
    private void BuildDefaultTemplate() {
      LiteralControl loadingBox = new LiteralControl("<div class=\"loadingbox\">");
      Image spinner = new Image();
      spinner.ID = "imgSpinner";
      spinner.ImageUrl = "~/App_Themes/dashCommerce/images/spinner.gif"; //Ugh, not sure why the theme isn't catching.
      spinner.SkinID = "spinner";
      LiteralControl spacer = new LiteralControl("&nbsp;&nbsp;");
      Label lblUpdating = new Label();
      lblUpdating.ID = "lblUpdating";
      lblUpdating.Text = Localization.LocalizationUtility.GetText("lblUpdating");
      lblUpdating.CssClass = "label";
      LiteralControl endLoadingBox = new LiteralControl("</div>");

      _controlCollection.Add(loadingBox);
      _controlCollection.Add(spinner);
      _controlCollection.Add(spacer);
      _controlCollection.Add(lblUpdating);
      _controlCollection.Add(endLoadingBox);
    }
    
    #endregion
    
    #endregion  

  }
}
