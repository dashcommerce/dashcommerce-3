<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sales.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.overview.sales" %>


<dashCommerce:Panel ID="pnlSales" runat="server">
  <br />
  <dashCommerce:HyperLink ID="hlOrderSearch" runat="server" NavigateUrl="~/admin/orders.aspx" CssClass="label" /><br />
  <dashCommerce:Label ID="lblOrderSearchDescription" runat="server" CssClass="label" /><br /><br />
</dashCommerce:Panel>