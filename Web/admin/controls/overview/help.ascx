<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="help.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.overview.help" %>

<dashCommerce:Panel ID="pnlHelp" runat="server">
  <br />
  <dashCommerce:HyperLink ID="hlCommunityForums" runat="server" NavigateUrl="http://dashcommerce.org/forums" CssClass="label" /><br />
  <dashCommerce:Label ID="lblCommunityForumsDescription" runat="server" CssClass="label" /><br /><br />

  <dashCommerce:HyperLink ID="hlDocumentation" runat="server" NavigateUrl="http://dashcommerce.org/files/14/default.aspx" CssClass="label" /><br />
  <dashCommerce:Label ID="lblDocumentationDescription" runat="server" CssClass="label" /><br /><br />

  <dashCommerce:HyperLink ID="hlDashCommerceOrg" runat="server" NavigateUrl="http://dashcommerce.org" CssClass="label" /><br />
  <dashCommerce:Label ID="lblDashCommerceOrgDescription" runat="server" CssClass="label" /><br /><br />

  <dashCommerce:HyperLink ID="hlDashCommerceCom" runat="server" NavigateUrl="http://dashcommerce.com" CssClass="label" /><br />
  <dashCommerce:Label ID="lblDashCommerceComDescription" runat="server" CssClass="label" /><br /><br />

  <dashCommerce:HyperLink ID="hlAbout" runat="server" NavigateUrl="~/admin/about.aspx" CssClass="label" /><br />
  <dashCommerce:Label ID="lblAboutDescription" runat="server" CssClass="label" /><br /><br />
</dashCommerce:Panel>