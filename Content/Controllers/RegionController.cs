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
  public partial class RegionController {

    public RegionCollection FetchRegionsByPageId(int pageId) {
      IDataReader reader = SPs.FetchRegionsByPageId(pageId).GetReader();
      RegionCollection regionCollection = new RegionCollection();
      regionCollection.LoadAndCloseReader(reader);
      return regionCollection;
    }

    public RegionCollection FetchRegionsByPageIdAndTemplateRegionId(int pageId, int templateRegionId) {
      IDataReader reader = SPs.FetchRegionsByPageIdAndTemplateRegionId(pageId, templateRegionId).GetReader();
      RegionCollection regionCollection = new RegionCollection();
      regionCollection.LoadAndCloseReader(reader);
      return regionCollection;
    }
    

    public int JoinToPage(int regionId, int pageId) {
      int rowsAffected = 0;
      int count = new Query(PageRegionMap.Schema).AddWhere(PageRegionMap.Columns.RegionId, Comparison.Equals, regionId).AddWhere(PageRegionMap.Columns.PageId, Comparison.Equals, pageId).GetCount(PageRegionMap.Columns.PageId);
      if(count == 0) {
        rowsAffected = SPs.JoinRegionToPage(regionId, pageId).Execute();
      }
      return rowsAffected;
    }    
  
  }
}
