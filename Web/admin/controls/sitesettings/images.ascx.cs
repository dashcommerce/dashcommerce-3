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
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;

namespace MettleSystems.dashCommerce.Web.admin.controls.sitesettings {
    public partial class images : SiteSettingsControl {

    #region Page Events

      /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected override void Page_Load(object sender, EventArgs e) {
      try {
        base.Page_Load(sender, e);
        if (view.Equals("i")) {
          SetImageSettingsProperties();
          if(!Page.IsPostBack) {
            chkGenerateThumbs.Checked = SiteSettings.GenerateThumbs;
            txtSmallWidth.Text = SiteSettings.ThumbSmallWidth.ToString();
            txtSmallHeight.Text = SiteSettings.ThumbSmallHeight.ToString();
          }
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(images).Name + ".Page_Load", ex);
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
        SiteSettings.GenerateThumbs = chkGenerateThumbs.Checked;
        SiteSettings.ThumbSmallWidth = int.Parse(txtSmallWidth.Text);
        SiteSettings.ThumbSmallHeight = int.Parse(txtSmallHeight.Text);
        base.Save(SiteSettings);
      }
      catch(Exception ex) {
        Logger.Error(typeof(images).Name + ".btnSave_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Sets the general settings properties.
    /// </summary>
    private void SetImageSettingsProperties() {
      this.Page.Title = LocalizationUtility.GetText("titleSiteSettingsImages");
    }

    #endregion

    #endregion

  }
}