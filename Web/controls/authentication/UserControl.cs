using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using MettleSystems.dashCommerce.Store;


namespace MettleSystems.dashCommerce.Web.controls.authentication {
  public class UserControl : System.Web.UI.UserControl {

    protected virtual void Page_Load(object sender, EventArgs e) {
      MettleSystems.dashCommerce.Controls.Label lblItemCount = this.FindControl("lblItemCount") as MettleSystems.dashCommerce.Controls.Label;
      if (lblItemCount != null) {
        lblItemCount.Text = GetItemCount();
      }
    }

    /// <summary>
    /// Gets the item count.
    /// </summary>
    /// <returns></returns>
    private string GetItemCount() {
      int orderItemCount = new OrderController().GetItemCountInOrder(WebUtility.GetUserName());
      return "(" + orderItemCount.ToString() + ")";
    }


  }
}
