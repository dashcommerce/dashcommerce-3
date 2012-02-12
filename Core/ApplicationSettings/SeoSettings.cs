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