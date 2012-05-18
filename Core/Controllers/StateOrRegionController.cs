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

using System.Data;

namespace MettleSystems.dashCommerce.Core {

  public partial class StateOrRegionController {

    #region Methods

    #region Public

    /// <summary>
    /// Fetches the state or region by country code.
    /// </summary>
    /// <param name="code">The code.</param>
    /// <returns></returns>
    public StateOrRegionCollection FetchStateOrRegionByCountryCode(string code) {
      IDataReader reader = SPs.FetchStateOrRegionByCountryCode(code).GetReader();
      StateOrRegionCollection stateOrRegionCollection = new StateOrRegionCollection();
      stateOrRegionCollection.LoadAndCloseReader(reader);
      return stateOrRegionCollection;
    }

    #endregion

    #endregion

  }
}
