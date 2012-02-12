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