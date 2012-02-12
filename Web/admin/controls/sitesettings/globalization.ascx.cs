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
using System.Globalization;
using System.Web.UI;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Core.Globalization;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;

namespace MettleSystems.dashCommerce.Web.admin.controls.sitesettings {
  public partial class globalization : SiteSettingsControl {

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected override void Page_Load(object sender, EventArgs e) {
      try {
        base.Page_Load(sender, e);
        if (view.Equals("gl")) {
          SetGlobalizationSettingsProperties();
          if (!Page.IsPostBack) {
            SetLanguageSelections();
            SetCurrencySelections();
            ddlLanguage.SelectedValue = SiteSettings.Language;
            ddlCurrency.SelectedValue = SiteSettings.CurrencyCode;
          }
        }
      }
      catch (Exception ex) {
        Logger.Error(typeof(globalization).Name + ".Page_Load", ex);
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
        SiteSettings.Language = ddlLanguage.SelectedValue;
        SiteSettings.CurrencyCode = ddlCurrency.SelectedValue;
        base.Save(SiteSettings);
      }
      catch (Exception ex) {
        Logger.Error(typeof(browsinglog).Name + ".btnSave_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Sets the language selections.
    /// </summary>
    private void SetLanguageSelections() {
      CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
      Array.Sort(cultures, new CultureComparer()) ;
      ddlLanguage.DataSource = cultures;
      ddlLanguage.DataValueField = "Name";
      ddlLanguage.DataTextField = "DisplayName";
      ddlLanguage.DataBind();
    }

    /// <summary>
    /// Sets the currency selections.
    /// </summary>
    private void SetCurrencySelections() {
      CurrencyCollection currencyCollection = new CurrencyController().FetchAll().OrderByAsc("Description");
      ddlCurrency.DataSource = currencyCollection;
      ddlCurrency.DataValueField = "Code";
      ddlCurrency.DataTextField = "Description";
      ddlCurrency.DataBind();
    }

    /// <summary>
    /// Sets the globalization settings properties.
    /// </summary>
    private void SetGlobalizationSettingsProperties() {
      this.Page.Title = LocalizationUtility.GetText("titleSiteSettingsGlobalization");
    }

    #endregion

    #endregion

  }
}