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
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Services.MessageService;
using MettleSystems.dashCommerce.Store.Web.Controls;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin.controls.order {
  public partial class shipping : AdminControl {
    
    #region Member Variables
    
    private int orderId = 0;
    private string view = string.Empty;

    #endregion
    
    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        orderId = Utility.GetIntParameter("orderId");
        view = Utility.GetParameter("view");
        if(orderId > 0 && view == "s") {
          SetShippingProperties();
          if(!Page.IsPostBack) {
            LoadShippingTrackingNumber();
          }       
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(shipping).Name + ".Page_Load", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e) {
      if(!string.IsNullOrEmpty(txtShippingTrackingNumber.Text)) {
        try {
          Order order = new Order(orderId);
          order.ShippingTrackingNumber = txtShippingTrackingNumber.Text;
          order.Save(WebUtility.GetUserName());
          MessageService messageService = new MessageService();
          messageService.SendShippingNotificationToCustomer(order);
          base.MasterPage.MessageCenter.DisplaySuccessMessage(LocalizationUtility.GetText("lblShippingSaved"));
        }
        catch(Exception ex) {
          Logger.Error(typeof(shipping).Name + ".btnSave_Click", ex);
          base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
        }
      }
    }

    #endregion

    #region Methods
    
    #region Private

    /// <summary>
    /// Loads the shipping tracking number.
    /// </summary>
    private void LoadShippingTrackingNumber() {
      Order order = new Order(orderId);
      txtShippingTrackingNumber.Text = order.ShippingTrackingNumber;
    }

    /// <summary>
    /// Sets the shipping properties.
    /// </summary>
    private void SetShippingProperties() {
      this.Page.Title = LocalizationUtility.GetText("titleOrderShipping");
    }    
    
    #endregion
    
    #endregion
    
  }
}