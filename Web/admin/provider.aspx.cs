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
using System.Web.UI;

using MettleSystems.dashCommerce.Content;
using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin {
  public partial class provider : MettleSystems.dashCommerce.Store.Web.AdminPage {
    
    #region Member Variables

    int pageId = 0;
    int regionId = 0;
    int providerId = 0;
    
    #endregion
  
    protected void Page_Load(object sender, EventArgs e) {
      pageId = Utility.GetIntParameter("pageId");
      regionId = Utility.GetIntParameter("regionId");
      providerId = Utility.GetIntParameter("providerId");

      Content.Page _selectedPage = new Content.Page(pageId);
      Provider provider = new Provider(providerId);
      if(provider.EditControl != null) {
        if(provider.EditControl.Length > 0) {
          ProviderControl editControl = Page.LoadControl(provider.EditControl) as ProviderControl;
          editControl.PageId = pageId;
          editControl.RegionId = regionId;
          editControl.ProviderId = providerId;
          providerContent.Controls.Add(editControl);
        }
      }


    }
  }
}
