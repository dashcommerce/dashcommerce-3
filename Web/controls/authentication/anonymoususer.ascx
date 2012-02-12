<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="anonymoususer.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.controls.authentication.anonymoususer" EnableViewState="false" %>
<%@ Register TagPrefix="dashCommerce" TagName="Search" Src="~/controls/search.ascx" %>

<div class="loginView">
  <a href="<%=Page.ResolveUrl("~/cart.aspx")%>"><asp:Image ID="imgCart" runat="server" SkinID="cart" /> <dashCommerce:Label ID="lblCart" runat="server" /> <dashCommerce:Label ID="lblItemCount" runat="server" /></a> | <dashCommerce:HyperLink ID="hlLogin" runat="server" NavigateUrl="~/login.aspx" /> | <dashCommerce:HyperLink ID="hlRegister" runat="server" NavigateUrl="~/register.aspx" /> | <dashCommerce:Search ID="dcSearch" runat="server" />
</div>