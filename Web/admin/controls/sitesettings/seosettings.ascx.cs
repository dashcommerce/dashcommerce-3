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
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;

namespace MettleSystems.dashCommerce.Web.admin.controls.sitesettings {
  public partial class seosettings : SiteSettingsControl {

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected override void Page_Load(object sender, EventArgs e) {
      try {
        base.Page_Load(sender, e);
        if(view.Equals("seo")) {
          SetGeneralSettingsProperties();
          if(!Page.IsPostBack) {
            txtCopyrightText.Text = SiteSettings.SeoSetting.CopyrightText;
            txtSiteDescription.Text = SiteSettings.SeoSetting.SiteDescription;
            txtSiteKeywords.Text = SiteSettings.SeoSetting.SiteKeywords;
          }
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(seosettings).Name + ".Page_Load", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e) {
      try {
        SiteSettings.SeoSetting.CopyrightText = txtCopyrightText.Text;
        SiteSettings.SeoSetting.SiteDescription = txtSiteDescription.Text;
        SiteSettings.SeoSetting.SiteKeywords = txtSiteKeywords.Text;
        base.Save(SiteSettings);
      }
      catch(Exception ex) {
        Logger.Error(typeof(seosettings).Name + ".btnSave_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }


    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Sets the general settings properties.
    /// </summary>
    private void SetGeneralSettingsProperties() {
      this.Page.Title = LocalizationUtility.GetText("titleSiteSettingsSeo");
    }

    #endregion

    #endregion

  }
}
