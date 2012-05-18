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
using MettleSystems.dashCommerce.Store;

namespace MettleSystems.dashCommerce.Web.controls {
  public partial class addressdisplay : System.Web.UI.UserControl {

    #region Member Variables

    private Address _address;

    #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
      try {
        DisplayAddress();
      }
      catch (Exception ex) {
        Logger.Error(typeof(addressdisplay).Name + ".Page_Load", ex);
      }
    }

    #endregion

    #region Methods

    #region Public

    /// <summary>
    /// Displays the address.
    /// </summary>
    public void DisplayAddress() {
      if(_address != null) {
        address.InnerHtml = _address.FullAddress;
      }
    }

    #endregion

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the address.
    /// </summary>
    /// <value>The address.</value>
    public Address Address {
      get {
        return _address;
      }
      set {
        _address = value;
      }
    }
	
    #endregion

  }
}