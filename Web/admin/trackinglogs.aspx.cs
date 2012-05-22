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
using System.Data;

using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;

namespace MettleSystems.dashCommerce.Web.admin {
  public partial class trackinglogs : MettleSystems.dashCommerce.Store.Web.AdminPage {

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        SetTrackingLogsProperties();
        LoadCategoryBrowsingLog();
        LoadProductBrowsingLog();
      }
      catch (Exception ex) {
        Logger.Error(typeof(trackinglogs).Name + ".Page_Load", ex);
        Master.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }


    #endregion

    #region Methods

    #region Private

    /// <summary>
    /// Sets the tracking logs properties.
    /// </summary>
    private void SetTrackingLogsProperties() {
      this.Title = LocalizationUtility.GetText("titleTrackingLogs");
    }

    /// <summary>
    /// Loads the product browsing log.
    /// </summary>
    private void LoadProductBrowsingLog() {
      DataSet dsProducts = new BrowsingLogController().FetchProductBrowsingLog();
      dgProducts.DataSource = dsProducts;
      dgProducts.Columns[0].HeaderText = LocalizationUtility.GetText("hdrHits");
      dgProducts.Columns[1].HeaderText = LocalizationUtility.GetText("hdrName");
      dgProducts.DataBind();
    }

    /// <summary>
    /// Loads the category browsing log.
    /// </summary>
    private void LoadCategoryBrowsingLog() {
      DataSet dsCategories = new BrowsingLogController().FetchCategoryBrowsingLog();
      dgCategory.DataSource = dsCategories;
      dgCategory.Columns[0].HeaderText = LocalizationUtility.GetText("hdrHits");
      dgCategory.Columns[1].HeaderText = LocalizationUtility.GetText("hdrName");
      dgCategory.DataBind();
    }

    #endregion

    #endregion

  }
}
