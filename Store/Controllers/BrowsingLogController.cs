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

using System.Data;

namespace MettleSystems.dashCommerce.Store {
  
  public partial class BrowsingLogController {
  
    #region Methods
    
    #region Public

    /// <summary>
    /// Fetches the category browsing log.
    /// </summary>
    /// <returns></returns>
    public DataSet FetchCategoryBrowsingLog() {
      DataSet ds = SPs.FetchCategoryBrowsingLog().GetDataSet();
      return ds;
    }

    /// <summary>
    /// Fetches the product browsing log.
    /// </summary>
    /// <returns></returns>
    public DataSet FetchProductBrowsingLog() {
      DataSet ds = SPs.FetchProductBrowsingLog().GetDataSet();
      return ds;
    }

    /// <summary>
    /// Fetches the browsing log search terms.
    /// </summary>
    /// <returns></returns>
    public DataSet FetchBrowsingLogSearchTerms() {
      DataSet ds = SPs.FetchBrowsingLogSearchTerms().GetDataSet();
      return ds;
    }

    #endregion

    #region Static Methods

    /// <summary>
    /// Logs the users browsing information, used for site Statistics.
    /// </summary>
    /// <param name="searchTerm">The search term.</param>
    /// <param name="browsingBehaviour">The browsing behaviour.</param>
    /// <param name="url">The URL.</param>
    /// <param name="sessionId">The session id.</param>
    /// <param name="userName">Name of the user.</param>
    public static void LogBrowsingInfo(string searchTerm, BrowsingBehaviour browsingBehaviour, string url, string sessionId, string userName) {
        LogBrowsingInfo(null, searchTerm, browsingBehaviour, url, sessionId, userName);
    }

    /// <summary>
    /// Logs the users browsing information, used for site Statistics.
    /// </summary>
    /// <param name="relevantId">The relevant id.</param>
    /// <param name="browsingBehaviour">The browsing behaviour.</param>
    /// <param name="userName">Name of the user.</param>
    /// <param name="url">The URL.</param>
    /// <param name="sessionId">The session id.</param>
    public static void LogBrowsingInfo(int relevantId, BrowsingBehaviour browsingBehaviour, string url, string sessionId, string userName) {
      LogBrowsingInfo(relevantId, null, browsingBehaviour, url, sessionId, userName);
    }

    /// <summary>
    /// Logs the users browsing information, used for site Statistics.
    /// </summary>
    /// <param name="relevantId">The relevant id.</param>
    /// <param name="searchTerm">The search term.</param>
    /// <param name="browsingBehaviour">The browsing behaviour.</param>
    /// <param name="url">The URL.</param>
    /// <param name="sessionId">The session id.</param>
    /// <param name="userName">Name of the user.</param>
    public static void LogBrowsingInfo(int? relevantId, string searchTerm, BrowsingBehaviour browsingBehaviour, string url, string sessionId, string userName) {
        //if (SiteSettingCache.GetSiteSettings().CollectBrowsingCategory) {
            BrowsingLog browsingLog = new BrowsingLog();
            browsingLog.BrowsingBehaviorId = (int)browsingBehaviour;
            if (searchTerm != null) browsingLog.SearchTerms = searchTerm;
            if (relevantId != null) browsingLog.RelevantId = relevantId;
            browsingLog.UserName = userName;
            browsingLog.Url = url;
            browsingLog.SessionId = sessionId;
            browsingLog.Save("System");
        //}
    }

    #endregion

    #endregion

  }
}
