#region dashCommerce License
/*

The dashCommerce Core (MIT License):
 
The dashCommerce Core (MIT License) covers the MettleSystems.dashCommerce.Core.dll and the 
MettleSystems.dashCommerce.Localization.dll and the files associated with the Core folder / project 
and the Localization folder / project.
 
Copyright (c) 2007 - 2008 Mettle Systems LLC, 2310 Superior Avenue, Suite 270 
Cleveland, Ohio 44114, United States
 
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and 
associated documentation files (the "Software"), to deal in the Software without restriction, 
including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
and / or sell copies of the Software, and to permit persons to whom the Software is furnished to do 
so, subject to the following conditions:
 
The above copyright notice and this permission notice shall be included in all copies or substantial 
portions of the Software.
 
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT 
LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN 
NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 
The dashCommerce Store License:

The dashCommerce Store License covers the MettleSystems.dashCommerce.Store.dll and the 
MettleSystems.dashCommerce.Web.dll and the MettleSystems.dashCommerce.Content.dll and the files associated with the Store folder / project and 
the Web folder / project and the Content folder / project.
 
The dashCommerce Store License below applies to the dashCommerce software version 3.
 
Any version of the dashCommerce software prior to version 3 is not covered by this license. 
Please refer to the license document in such prior versions of the dashCommerce software to find the 
relevant license information.
 
Please note that regarding the dashCommerce Core the dashCommerce Core License applies.
 
Please also note that for the dashCommerce Store the dashCommerce Store Commercial License is also available.
 
The dashCommerce Store software is Copyright (c) 2007 - 2008 Mettle Systems LLC, 2310 Superior Avenue, Suite 270 
Cleveland, Ohio 44114, United States
 
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
documentation files (the "Software"), to deal in the Software, including the rights to use, copy, modify, 
merge, publish, distribute, sublicense, and / or sell copies of the Software, and to permit persons to whom 
the Software is furnished to do so, subject to the following conditions:
 
The above copyright notice and this permission notice shall be included in all copies or substantial portions 
of the Software. To the extent the Software contains the dashCommerce name, trademark, brand and / or the 
dashCommerce logo, any copy, modification, merger, publication, distribution or equivalent use of the Software 
shall retain any such names, trademarks, brand and / or logos intact and plainly visible.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESSED OR IMPLIED, INCLUDING BUT NOT 
LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN 
NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGE OR OTHER LIABILITY, WHETHER 
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE 
OR OTHER DEALINGS IN THE SOFTWARE.

Any non-compliance with this license agreement is to be considered a full and unconditional agreement of the 
dashCommerce Store Commercial License.
 
Any dispute which may arise between the parties, concerning this license and / or use of the software, is to 
be brought before the United States Courts in the State of Ohio at the venue of Mettle Systems LLC. This license 
shall be governed and construed in accordance with the laws of the United States.

*/
#endregion

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using SubSonic.Utilities;

namespace MettleSystems.dashCommerce.Web.admin.controls.navigation {
  public partial class vatrate : System.Web.UI.UserControl {

	  #region Member Variables

	  string view = string.Empty;
	  int providerId = 0;

	  #endregion

    #region Page Events

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {
		 view = Utility.GetParameter("view");
		 providerId = Utility.GetIntParameter("providerId");
		 vatMenu.MenuItemDataBound += new MenuEventHandler(vatMenu_MenuItemDataBound);
		 vatMenu.DataBound += new EventHandler(vatMenu_DataBound);
		 vatMenu.PreRender += new EventHandler(vatMenu_PreRender);
    }

	 void vatMenu_DataBound(object sender, EventArgs e)
	 {
		 switch (view) {
			 case "c":
				 vatMenu.Items[0].Selected = true;
				 break;
			 case "d":
				 vatMenu.Items[0].ChildItems[0].Selected = true;
				 break;
			 default:
				 vatMenu.Items[0].Selected = true;
				 break;
		 }
	 }

	 void vatMenu_MenuItemDataBound(object sender, MenuEventArgs e)
	 {
		 e.Item.NavigateUrl = e.Item.NavigateUrl + string.Format("&providerId={0}", providerId);
	 }

    /// <summary>
    /// Handles the PreRender event of the vatMenu control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    void vatMenu_PreRender(object sender, EventArgs e) {
      if(vatMenu.SelectedItem == null) {
          vatMenu.Items[0].Selected = true;
      }
    }
    
    #endregion
    
  }
}