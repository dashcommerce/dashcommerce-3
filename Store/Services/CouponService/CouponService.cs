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

using MettleSystems.dashCommerce.Core.Serialization;

namespace MettleSystems.dashCommerce.Store.Services.CouponService {
  public class CouponService {
  
    #region Methods
    
    #region Public

    /// <summary>
    /// Applies the coupon.
    /// </summary>
    /// <param name="couponCode">The coupon code.</param>
    /// <param name="order">The order.</param>
    public void ApplyCoupon (string couponCode, Order order) {
      Coupon coupon = new Coupon(Coupon.Columns.CouponCode, couponCode);
      if(coupon.CouponId > 0) {
        if(coupon.ExpirationDate > DateTime.UtcNow) {
          ICouponProvider couponProvider = new Serializer().DeserializeObject(coupon.ValueX, coupon.Type) as ICouponProvider;
          couponProvider.ApplyCoupon(order);
        }
      }
    }
    
    #endregion
    
    #endregion
    
  }
}
