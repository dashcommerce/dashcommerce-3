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
using System.Web;
using MettleSystems.dashCommerce.Core;
using MettleSystems.dashCommerce.Core.Serialization;
using MettleSystems.dashCommerce.Localization;
using MettleSystems.dashCommerce.Store;
using MettleSystems.dashCommerce.Store.Services.CouponService;
using MettleSystems.dashCommerce.Store.Web.Controls;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin.controls.configuration.couponproviders {
  public partial class percentoffconfiguration : CouponConfigurationControl {
  
    #region Member Variables
    
    private int couponId = 0;
    
    #endregion

    #region Page Events
        
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        SetPercentOffConfigurationProperties();
        couponId = Utility.GetIntParameter("couponId");
        if(couponId > 0) {
          Coupon coupon = new Coupon(couponId);
          Serializer serializer = new Serializer();
          PercentOffCouponProvider percentOffCouponProvider = serializer.DeserializeObject(coupon.ValueX, coupon.Type) as PercentOffCouponProvider;
          lblCouponId.Text = coupon.CouponId.ToString();
          txtCouponCode.Text = coupon.CouponCode;
          txtExpirationDate.Text = coupon.ExpirationDate.ToString();
          txtPercentOff.Text = percentOffCouponProvider.PercentOff.ToString();
          chkIsSingleUse.Checked = coupon.IsSingleUse;
        }
      }
      catch(Exception ex) {
        Logger.Error(typeof(percentoffconfiguration).Name + ".Page_Load", ex);
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
        int couponId = 0;
        int.TryParse(lblCouponId.Text, out couponId);
        Coupon coupon;
        if(couponId == 0) {
          coupon = new Coupon();
        }
        else {
          coupon = new Coupon(couponId);
        }
        
        PercentOffCouponProvider percentOffCouponProvider = new PercentOffCouponProvider();
        decimal percentOff = 0M;
        decimal.TryParse(txtPercentOff.Text, out percentOff);
        percentOffCouponProvider.PercentOff = percentOff;
        if (string.IsNullOrEmpty(txtCouponCode.Text)) {
          coupon.CouponCode = CoreUtility.GenerateRandomString(8);
        }
        else {
          coupon.CouponCode = txtCouponCode.Text;
        }
        DateTime expirationDate = DateTime.UtcNow;
        DateTime.TryParse(txtExpirationDate.Text, out expirationDate);
        coupon.ExpirationDate = expirationDate;
        coupon.IsSingleUse = chkIsSingleUse.Checked;
        coupon.Type = percentOffCouponProvider.GetType().AssemblyQualifiedName;
        coupon.ValueX = new Serializer().SerializeObject(percentOffCouponProvider, typeof(PercentOffCouponProvider));
        coupon.Save(WebUtility.GetUserName());
        Response.Redirect("~/admin/coupons.aspx", true);
      }
      catch(Exception ex) {
        Logger.Error(typeof(percentoffconfiguration).Name + ".btnSave_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnGenerate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void btnGenerate_Click(object sender, EventArgs e) {
      try {
        txtCouponCode.Text = CoreUtility.GenerateRandomString(8);
      }
      catch(Exception ex) {
        Logger.Error(typeof(percentoffconfiguration).Name + ".btnGenerate_Click", ex);
        base.MasterPage.MessageCenter.DisplayCriticalMessage(ex.Message);
      }     
    }
    
    #endregion
    
    #region Methods
    
    #region Private

    /// <summary>
    /// Sets the percent off control configuration properties.
    /// </summary>
    private void SetPercentOffConfigurationProperties() {
      ltDescription.Text = HttpUtility.HtmlDecode(base.Provider.Description);
      lblDescriptionTitle.Text = LocalizationUtility.GetText("lblPercentOffCouponDescriptionTitle");
      pnlSettings.GroupingText = LocalizationUtility.GetText("pnlPercentOffCouponConfiguration");

    }    
    
    #endregion
    
    #endregion
    
  }
}