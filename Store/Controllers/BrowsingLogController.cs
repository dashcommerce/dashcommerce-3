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
