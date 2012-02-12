<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="storeclosed.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.storeclosed"
  Theme="dashCommerce" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>dashCommerce :: Store Closed</title>
</head>
<body>
  <form id="form1" runat="server">
  <div id="headerRegion">
    <dashCommerce:HyperLink ID="hlLogo" runat="server" SkinID="sitelogo" EnableViewState="false" />
    <hr />
  </div>
  <div id="content">
    <dashCommerce:Label ID="lblComeBackLater" runat="server" CssClass="label" /><br />
    <asp:Image ID="closed" runat="server" SkinID="closed" /><br /><br />
    <dashCommerce:Label ID="lblStoreClosedAdminLink" runat="server" CssClass="label" /><br /><br />
  </div>
  <div id="footer">
    <hr />
  </div>
  <a href="http://www.dashcommerce.org" style="float: left; color: #999999; font-size: .8em;">
    Powered by dashCommerce</a><br />
  <br />
  </form>
</body>
</html>
