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
