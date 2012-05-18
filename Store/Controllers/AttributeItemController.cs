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

  public partial class AttributeItemController {
  
    #region Methods
    
    #region Public

    /// <summary>
    /// Fetches the selected attribute item.
    /// </summary>
    /// <param name="attributeId">The attribute id.</param>
    /// <param name="skuSuffix">The sku suffix.</param>
    /// <returns></returns>
    public AttributeItem FetchSelectedAttributeItem(int attributeId, string skuSuffix) {
      Query query = new Query(Store.AttributeItem.Schema).
        AddWhere(Store.AttributeItem.Columns.AttributeId, attributeId).
        AddWhere(Store.AttributeItem.Columns.SkuSuffix, skuSuffix);
      IDataReader reader = query.ExecuteReader();
      AttributeItemCollection attributeItemCollection = new AttributeItemCollection();
      attributeItemCollection.LoadAndCloseReader(reader);
      if(attributeItemCollection.Count > 0) {
        return attributeItemCollection[0];
      }
      else {
        return null;
      }
    }
    
    #endregion
    
    #endregion
    
  }
}
