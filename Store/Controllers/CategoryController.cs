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

namespace MettleSystems.dashCommerce.Store {
  
  public partial class CategoryController {
  
    #region Constants
    
    private const string MENUS = "Menus";
    private const string MENU = "Menu";
    private const string PARENT_CHILD = "ParentChild";
    private const string ASC = "ASC";
    private const string CATEGORY_ID = "CategoryId";
    private const string PARENT_ID = "ParentId";
    
    #endregion
    
    #region Methods
    
    #region Public

    /// <summary>
    /// Fetches the category list.
    /// </summary>
    /// <returns></returns>
    public DataSet FetchCategoryList() {
      DataSet ds = new Query(Category.Schema).ORDER_BY(Category.Columns.SortOrder, ASC).ExecuteDataSet();
      ds.DataSetName = MENUS;
      ds.Tables[0].TableName = MENU;
      DataRelation relation = new DataRelation(PARENT_CHILD, ds.Tables[MENU].Columns[CATEGORY_ID], ds.Tables[MENU].Columns[PARENT_ID], false);
      relation.Nested = true;
      ds.Relations.Add(relation);
      return ds;    
    }

    /// <summary>
    /// Fetches the category bread crumbs.
    /// </summary>
    /// <param name="categoryId">The category id.</param>
    /// <returns></returns>
    public DataSet FetchCategoryBreadCrumbs(int categoryId) {
      DataSet ds = SPs.FetchCategoryBreadCrumbs(categoryId).GetDataSet();
      ds.DataSetName = MENUS;
      ds.Tables[0].TableName = MENU;
      return ds;
    }

    /// <summary>
    /// Fetches the category manufacturers.
    /// </summary>
    /// <param name="categoryId">The category id.</param>
    /// <returns></returns>
    public DataSet FetchCategoryManufacturers(int categoryId) {
      DataSet ds = SPs.FetchCategoryManufacturers(categoryId).GetDataSet();
      return ds;
    }

    /// <summary>
    /// Fetches the category price ranges.
    /// </summary>
    /// <param name="categoryId">The category id.</param>
    /// <returns></returns>
    public DataSet FetchCategoryPriceRanges(int categoryId) {
      DataSet ds = SPs.FetchCategoryPriceRanges(categoryId).GetDataSet();
      return ds;
    }

    /// <summary>
    /// Fetches the favorite categories.
    /// </summary>
    /// <param name="userName">Name of the user.</param>
    /// <returns></returns>
    public DataSet FetchFavoriteCategories(string userName) {
      DataSet ds = SPs.FetchFavoriteCategories(userName, (int)BrowsingBehaviour.Browsing_Category).GetDataSet();
      return ds;
    }
    
    #endregion
    
    #endregion

  }
}
