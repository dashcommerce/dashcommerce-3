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

namespace MettleSystems.dashCommerce.Core.ApplicationSettings {
  [Serializable]
  public class SeoSettings {

    #region Member Variables

    //private bool useSeoFeatures = true;
    private bool _showDCCopyright = true;
    private string _copyrightText;
    private string _siteDescription;
    private string _siteKeywords;

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets a value indicating whether [show DC copyright].
    /// </summary>
    /// <value><c>true</c> if [show DC copyright]; otherwise, <c>false</c>.</value>
    #warning Obsolete - will be removed in next release.
    public bool ShowDCCopyright {
      get {
        return _showDCCopyright;
      }
      set {
        _showDCCopyright = value;
      }
    }

    /// <summary>
    /// Gets or sets the main site keywords.
    /// </summary>
    /// <value>The main site keywords.</value>
    public string SiteKeywords {
      get {
        return _siteKeywords;
      }
      set {
        _siteKeywords = value;
      }
    }

    /// <summary>
    /// Gets or sets the main site description.
    /// </summary>
    /// <value>The main site description.</value>
    public string SiteDescription {
      get {
        return _siteDescription;
      }
      set {
        _siteDescription = value;
      }
    }

    /// <summary>
    /// Gets or sets the copyright.
    /// </summary>
    /// <value>The copyright.</value>
    public string CopyrightText {
      get {
        return _copyrightText;
      }
      set {
        _copyrightText = value;
      }
    }

    #endregion

  }
}