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
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MettleSystems.dashCommerce.Web {
  public class OrderProgressTemplate : TemplateControl, ITemplate {
    
    #region Member Variables
    
    private string _template;
    private List<Control> _controlCollection;
    
    #endregion
    
    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="T:OrderProgressTemplate"/> class.
    /// </summary>
    public OrderProgressTemplate() {
      _controlCollection = new List<Control>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:OrderProgressTemplate"/> class.
    /// </summary>
    /// <param name="template">The template.</param>
    public OrderProgressTemplate(string template) {
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
      Label lblUpdatingOrder = new Label();
      lblUpdatingOrder.ID = "lblUpdatingOrder";
      lblUpdatingOrder.Text = Localization.LocalizationUtility.GetText("lblUpdatingOrder");
      lblUpdatingOrder.CssClass = "label";
      LiteralControl endLoadingBox = new LiteralControl("</div>");

      _controlCollection.Add(loadingBox);
      _controlCollection.Add(spinner);
      _controlCollection.Add(spacer);
      _controlCollection.Add(lblUpdatingOrder);
      _controlCollection.Add(endLoadingBox);
    }
    
    #endregion
    
    #endregion
    
  }
}
