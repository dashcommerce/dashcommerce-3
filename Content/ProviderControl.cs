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

using System.Web.UI;

namespace MettleSystems.dashCommerce.Content {
  public partial class ProviderControl : UserControl {

    private int _pageId;

    public int PageId {
      get {
        return _pageId;
      }
      set {
        _pageId = value;
      }
    }


    private int _regionId;
    public int RegionId {
      get {
        return _regionId;
      }
      set {
        _regionId = value;
      }
    }

    private int _providerId;
    public int ProviderId {
      get {
        return _providerId;
      }
      set {
        _providerId = value;
      }
    }

  }
}
