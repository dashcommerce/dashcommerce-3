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
using System.Collections.Generic;


namespace MettleSystems.dashCommerce.Store.Web {
  public class SiteMasterPage : dashCommerceMasterPage {

    #region Member Variables

    private bool hideSeoInformation;
    private List<string> _keyWords = new List<string>();
    private string _description;

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets a value indicating whether [hide seo information].
    /// </summary>
    /// <value><c>true</c> if [hide seo information]; otherwise, <c>false</c>.</value>
    public bool HideSeoInformation {
      get { return hideSeoInformation; }
      set { hideSeoInformation = value; }
    }

    /// <summary>
    /// Gets or sets the key words.
    /// </summary>
    /// <value>The key words.</value>
    public List<string> KeyWords {
      get { return _keyWords; }
      set { _keyWords = value; }
    }

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    /// <value>The description.</value>
    public string Description {
      get { return _description; }
      set { _description = value; }
    }

    #endregion

  }
}
