<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="security.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.overview.security" %>


<dashCommerce:Panel ID="pnlSecurity" runat="server">
  <br />
  <dashCommerce:HyperLink ID="hlUserAdministration" runat="server" NavigateUrl="~/admin/userlist.aspx" CssClass="label"/><br />
  <dashCommerce:Label ID="lblUserAdministrationDescription" runat="server" CssClass="label" /><br /><br />
  
  <dashCommerce:HyperLink ID="hlRoleAdministration" runat="server" NavigateUrl="~/admin/rolelist.aspx" CssClass="label"/><br />
  <dashCommerce:Label ID="lblRoleAdministrationDescription" runat="server" CssClass="label" /><br /><br />
</dashCommerce:Panel>