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
using SubSonic;

namespace MettleSystems.dashCommerce.Content {
  public partial class PageController {

    #region Constants

    private const string MENUS = "Menus";
    private const string MENU = "Menu";
    private const string PARENT_CHILD = "ParentChild";
    private const string ASC = "ASC";
    private const string PAGE_ID = "PageId";
    private const string PARENT_ID = "ParentId";

    #endregion

    #region Methods

    #region Public

    /// <summary>
    /// Fetches the page list.
    /// </summary>
    /// <returns></returns>
    public DataSet FetchPageList() {
      DataSet ds = new Query(Page.Schema).ORDER_BY(Page.Columns.SortOrder, ASC).ExecuteDataSet();
      ds.DataSetName = MENUS;
      ds.Tables[0].TableName = MENU;
      DataRelation relation = new DataRelation(PARENT_CHILD, ds.Tables[MENU].Columns[PAGE_ID], ds.Tables[MENU].Columns[PARENT_ID], false);
      relation.Nested = true;
      ds.Relations.Add(relation);
      return ds;
    }

    /// <summary>
    /// Fetches the default page.
    /// </summary>
    /// <returns></returns>
    public Page FetchDefaultPage() {
      Query query = new Query(Page.Schema).AddWhere(Page.Columns.ParentId, Comparison.Equals, 0).AddWhere(Page.Columns.SortOrder, Comparison.Equals, 1);
      PageCollection pageCollection = new PageController().FetchByQuery(query);
      Page page = null;
      if(pageCollection.Count > 0) {
        page = pageCollection[0];
      }
      return page;
    }

    #endregion

    #endregion

  }
}
