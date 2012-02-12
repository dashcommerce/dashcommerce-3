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
