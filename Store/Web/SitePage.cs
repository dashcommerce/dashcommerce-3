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
using System.Collections.Generic;

namespace MettleSystems.dashCommerce.Store.Web {
  public class SitePage : dashCommercePage {

    #region Member Variables

    private SiteMasterPage _masterPage;

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the name of the style sheet applied to this page.
    /// </summary>
    /// <value></value>
    /// <returns>The name of the style sheet applied to this page.</returns>
    /// <exception cref="T:System.InvalidOperationException">The <see cref="P:System.Web.UI.Page.StyleSheetTheme"/> property is set before the <see cref="E:System.Web.UI.Control.Init"/> event completes.</exception>
    public override string StyleSheetTheme {
      get {
        return SiteSettings.Theme;
      }
    }

    /// <summary>
    /// Gets the get master page.
    /// </summary>
    /// <value>The get master page.</value>
    private SiteMasterPage GetMasterPage { get { return Master as SiteMasterPage; } }

    /// <summary>
    /// Gets the base master page.
    /// </summary>
    /// <value>The base master page.</value>
    public SiteMasterPage BaseMasterPage {
      get {
        if (_masterPage == null)
          _masterPage = GetMasterPage;
        return _masterPage;
      }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Adds the key word.
    /// </summary>
    /// <param name="keyword">The keyword.</param>
    public void AddKeyWord(string keyword) {
      BaseMasterPage.KeyWords.AddRange(keyword.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
    }

    /// <summary>
    /// Adds the key word.
    /// </summary>
    /// <param name="keyword">The keyword.</param>
    public void AddKeyWord(IEnumerable<string> keyword) {
      BaseMasterPage.KeyWords.AddRange(keyword);
    }

    /// <summary>
    /// Sets the page description.
    /// </summary>
    /// <param name="description">The description.</param>
    public void SetPageDescription(string description) {
      BaseMasterPage.Description = description;
    }

    #endregion
  }
}
