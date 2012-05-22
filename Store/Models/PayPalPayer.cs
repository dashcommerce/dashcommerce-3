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

namespace MettleSystems.dashCommerce.Store {
  
  public class PayPalPayer {

    #region Member Variables

    private string _payPalPayerId;
    private string _payPalToken;
    private Address _shippingAddress;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="T:PayPalPayer"/> class.
    /// </summary>
    public PayPalPayer() {
      _shippingAddress = new Address();
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the shipping address.
    /// </summary>
    /// <value>The shipping address.</value>
    public Address ShippingAddress {
      get {
        return _shippingAddress;
      }
      set {
        _shippingAddress = value;
      }
    }

    /// <summary>
    /// Gets or sets the pay pal token.
    /// </summary>
    /// <value>The pay pal token.</value>
    public string PayPalToken {
      get {
        return _payPalToken;
      }
      set {
        _payPalToken = value;
      }
    }

    /// <summary>
    /// Gets or sets the pay pal payer id.
    /// </summary>
    /// <value>The pay pal payer id.</value>
    public string PayPalPayerId {
      get {
        return _payPalPayerId;
      }
      set {
        _payPalPayerId = value;
      }
    }

    #endregion

  }
}
