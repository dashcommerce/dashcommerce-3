<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="configuration.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.overview.configuration" %>


<dashCommerce:Panel ID="pnlConfigurationOverview" runat="server">
  <br />
  <dashCommerce:HyperLink ID="hlMailConfiguration" runat="server" NavigateUrl="~/admin/overview.aspx?view=mc" CssClass="label" /><br />
  <dashCommerce:Label ID="lblMailConfigurationDescription" runat="server" CssClass="label" /><br /><br />
  <dashCommerce:HyperLink ID="hlPaymentConfiguration" runat="server" NavigateUrl="~/admin/overview.aspx?view=pc" CssClass="label" /><br />
  <dashCommerce:Label ID="lblPaymentConfigurationDescription" runat="server" CssClass="label" /><br /><br />
  <dashCommerce:HyperLink ID="hlTaxConfiguration" runat="server" NavigateUrl="~/admin/overview.aspx?view=tc" CssClass="label" /><br />
  <dashCommerce:Label ID="lblTaxConfigurationDescription" runat="server" CssClass="label" /><br /><br />
  <dashCommerce:HyperLink ID="hlShippingConfiguration" runat="server" NavigateUrl="~/admin/overview.aspx?view=sc" CssClass="label" /><br />
  <dashCommerce:Label ID="lblShippingConfigurationDescription" runat="server" CssClass="label" /><br /><br />
</dashCommerce:Panel>