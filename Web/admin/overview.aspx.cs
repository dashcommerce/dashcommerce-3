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
using System.Web.UI;

using MettleSystems.dashCommerce.Localization;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin {
  public partial class overview : MettleSystems.dashCommerce.Store.Web.AdminPage {

    #region Member Variables

    private string view;
    private string title;
    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e) {
      view = Utility.GetParameter("view");
      title = LocalizationUtility.GetText("titleOverview");
      switch(view) {
        case "si": //Site Settings
          siteSettingsOverview.Visible = true;
          Page.Title = string.Format(title, LocalizationUtility.GetText("pnlSiteOverview"));
          break;
        case "sec": //Security
          security.Visible = true;
          Page.Title = string.Format(title, LocalizationUtility.GetText("pnlSecurity"));
          break;
        case "s": //Sales
          sales.Visible = true;
          Page.Title = string.Format(title, LocalizationUtility.GetText("pnlSales"));
          break;
        case "pm": //Product Management
          productmanagement.Visible = true;
          Page.Title = string.Format(title, LocalizationUtility.GetText("pnlProductManagement"));
          break;
        case "pco": //Product Coupons
          productcoupons.Visible = true;
          Page.Title = string.Format(title, LocalizationUtility.GetText("pnlProductCoupons"));
          break;
        case "c": //Configuration
          configuration.Visible = true;
          Page.Title = string.Format(title, LocalizationUtility.GetText("pnlConfigurationOverview"));
          break;
        case "mc": //Mail Configuration
          mailConfiguration.Visible = true;
          Page.Title = string.Format(title, LocalizationUtility.GetText("pnlMailConfiguration"));          
          break;
        case "pc": //Payment Configuration
          providers.Visible = true;
          Page.Title = string.Format(title, LocalizationUtility.GetText("pnlPaymentConfiguration"));          
          break;
        case "tc": //Tax Configuration
          providers.Visible = true;
          Page.Title = string.Format(title, LocalizationUtility.GetText("pnlTaxConfiguration"));          
          break;
        case "sc": //Shipping Configuration
          providers.Visible = true;
          Page.Title = string.Format(title, LocalizationUtility.GetText("pnlShippingConfiguration"));          
          break;
        case "cs"://customer service
          customerService.Visible = true;
          Page.Title = string.Format(title, LocalizationUtility.GetText("pnlCustomerServiceConfiguration"));
          break;
        case "help":
          help.Visible = true;
          Page.Title = string.Format(title, LocalizationUtility.GetText("pnlHelp"));
          break;
        default:
          lblNotDone.Visible = true;
          break;
      }
    }

    #endregion

  }
}
