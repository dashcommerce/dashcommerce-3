using System;
using MettleSystems.dashCommerce.Localization;

namespace MettleSystems.dashCommerce.Web.submodal {
  public partial class loading : MettleSystems.dashCommerce.Store.Web.SitePage {
    protected void Page_Load(object sender, EventArgs e) {
      this.Title = LocalizationUtility.GetText("titleLoading");
    }
  }
}
