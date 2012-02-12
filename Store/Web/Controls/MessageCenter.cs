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
using System.Web.UI;
using System.Web.UI.WebControls;

//using MettleSystems.dashCommerce.Localization;

namespace MettleSystems.dashCommerce.Controls {
  public class MessageCenter : WebControl {
  
    #region Member Variables

    protected Panel pnlMessageCenter = new Panel();
    protected Panel pnlValidation;

    protected ValidationSummary validationSummary;

    protected Panel pnlSuccess;
    protected System.Web.UI.WebControls.Image imgSuccess;
    protected Label lblSuccessMessage;

    protected Panel pnlInformation;
    protected System.Web.UI.WebControls.Image imgInformation;
    protected Label lblInformationMessage;

    protected Panel pnlFailure;
    protected System.Web.UI.WebControls.Image imgFailure;
    protected Label lblFailureMessage;

    protected Panel pnlCritical;
    protected System.Web.UI.WebControls.Image imgCritical;
    protected Label lblCriticalMessage;
    
    #endregion

    #region Constructors

    public MessageCenter() {
 
    }

    #endregion

    #region Methods

    #region Public

    /// <summary>
    /// Displays the information message.
    /// </summary>
    /// <param name="message">The message.</param>
    public void DisplayInformationMessage(string message) {
      EnsureChildControls();
      ResetPanelsVisibility();
      pnlInformation.Visible = true;
      lblInformationMessage.Text = message;
    }

    /// <summary>
    /// Displays the success message.
    /// </summary>
    /// <param name="message">The message.</param>
    public void DisplaySuccessMessage(string message) {
      EnsureChildControls();
      ResetPanelsVisibility();
      pnlSuccess.Visible = true;
      lblSuccessMessage.Text = message;
    }

    /// <summary>
    /// Displays the failure message.
    /// </summary>
    /// <param name="message">The message.</param>
    public void DisplayFailureMessage(string message) {
      EnsureChildControls();
      ResetPanelsVisibility();
      pnlFailure.Visible = true;
      lblFailureMessage.Text = message;
    }

    /// <summary>
    /// Displays the critical message.
    /// </summary>
    /// <param name="message">The message.</param>
    public void DisplayCriticalMessage(string message) {
      EnsureChildControls();
      ResetPanelsVisibility();
      pnlCritical.Visible = true;
      lblCriticalMessage.Text = string.Format(Store.Strings.lblCriticalError, message);
    }

    /// <summary>
    /// Resets the panels visibility.
    /// </summary>
    public void ResetPanelsVisibility() {
      EnsureChildControls();
      pnlValidation.Visible = true;
      pnlInformation.Visible = false;
      pnlSuccess.Visible = false;
      pnlFailure.Visible = false;
      pnlCritical.Visible = false;
    }
    
    #endregion
    
    #region Protected

    /// <summary>
    /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
    /// </summary>
    protected override void CreateChildControls() {
      Controls.Clear();

      pnlValidation = new Panel();
      pnlValidation.Controls.Add(new LiteralControl("&nbsp;"));
      validationSummary = new ValidationSummary();
      validationSummary.DisplayMode = ValidationSummaryDisplayMode.BulletList;
      validationSummary.CssClass = "validationSummary";
      pnlValidation.Controls.Add(validationSummary);

      pnlSuccess = new Panel();
      pnlSuccess.Visible = false;
      pnlSuccess.CssClass = "messagecenterSuccess";
      imgSuccess = new System.Web.UI.WebControls.Image();
      imgSuccess.SkinID = "success";
      lblSuccessMessage = new Label();
      lblSuccessMessage.CssClass = "label";
      pnlSuccess.Controls.Add(new LiteralControl("<div class=\"verticalalign\">"));
      pnlSuccess.Controls.Add(imgSuccess);
      pnlSuccess.Controls.Add(new LiteralControl("&nbsp;"));
      pnlSuccess.Controls.Add(lblSuccessMessage);
      pnlSuccess.Controls.Add(new LiteralControl("</div>"));

      pnlFailure = new Panel();
      pnlFailure.Visible = false;
      pnlFailure.CssClass = "messagecenterFailure";
      imgFailure = new System.Web.UI.WebControls.Image();
      imgFailure.SkinID = "error";
      lblFailureMessage = new Label();
      lblFailureMessage.CssClass = "label";
      pnlFailure.Controls.Add(new LiteralControl("<div class=\"verticalalign\">"));
      pnlFailure.Controls.Add(imgFailure);
      pnlFailure.Controls.Add(new LiteralControl("&nbsp;"));
      pnlFailure.Controls.Add(lblFailureMessage);
      pnlFailure.Controls.Add(new LiteralControl("</div>"));

      pnlInformation = new Panel();
      pnlInformation.Visible = false;
      pnlInformation.CssClass = "messagecenterInformation";
      imgInformation = new System.Web.UI.WebControls.Image();
      imgInformation.SkinID = "information";
      lblInformationMessage = new Label();
      lblInformationMessage.CssClass = "label";
      pnlInformation.Controls.Add(new LiteralControl("<div class=\"verticalalign\">"));
      pnlInformation.Controls.Add(imgInformation);
      pnlInformation.Controls.Add(new LiteralControl("&nbsp;"));
      pnlInformation.Controls.Add(lblInformationMessage);
      pnlInformation.Controls.Add(new LiteralControl("</div>"));

      pnlCritical = new Panel();
      pnlCritical.Visible = false;
      pnlCritical.CssClass = "messagecenterCritical";
      imgCritical = new System.Web.UI.WebControls.Image();
      imgCritical.SkinID = "critical";
      lblCriticalMessage = new Label();
      lblCriticalMessage.CssClass = "label";
      pnlCritical.Controls.Add(new LiteralControl("<div class=\"verticalalign\">"));
      pnlCritical.Controls.Add(imgCritical);
      pnlCritical.Controls.Add(new LiteralControl("&nbsp;"));
      pnlCritical.Controls.Add(lblCriticalMessage);
      pnlCritical.Controls.Add(new LiteralControl("</div>"));

      pnlMessageCenter.Controls.Add(pnlInformation);
      pnlMessageCenter.Controls.Add(pnlSuccess);
      pnlMessageCenter.Controls.Add(pnlFailure);
      pnlMessageCenter.Controls.Add(pnlCritical);
      pnlMessageCenter.Controls.Add(pnlValidation);

      this.Controls.Add(pnlMessageCenter);
      base.CreateChildControls();
    }


    /// <summary>
    /// Renders the control to the specified HTML writer.
    /// </summary>
    /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter"></see> object that receives the control content.</param>
    protected override void Render(HtmlTextWriter writer) {
      base.Render(writer);
    }
    
    #endregion
    
    #endregion
    
    #region Properties

    /// <summary>
    /// Gets a <see cref="T:System.Web.UI.ControlCollection"></see> object that represents the child controls for a specified server control in the UI hierarchy.
    /// </summary>
    /// <value></value>
    /// <returns>The collection of child controls for the specified server control.</returns>
    public override ControlCollection Controls {
      get {
        EnsureChildControls();
        return base.Controls;
      }
    }    

    /// <summary>
    /// Sets the title.
    /// </summary>
    /// <value>The title.</value>
    public string Title {
      set {
        pnlMessageCenter.GroupingText = value;
      }
    }

    #endregion

  }
}
