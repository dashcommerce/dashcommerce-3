<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="providers.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.overview.providers" %>


<dashCommerce:Panel ID="pnlConfiguration" runat="server">
  <br />
  <dashCommerce:HyperLink ID="hlGeneralSettings" runat="server" NavigateUrl="~/admin/paymentsettings.aspx" CssClass="label" /><br />
  <dashCommerce:Label ID="lblGeneralSettingsDescription" runat="server" CssClass="label" /><br /><br />
  <dashCommerce:HyperLink ID="hlConfigureProviders" runat="server" NavigateUrl="~/admin/paymentconfiguration.aspx" CssClass="label" /><br />
  <dashCommerce:Label ID="lblConfigureProvidersDescription" runat="server" CssClass="label" /><br /><br />
  <dashCommerce:HyperLink ID="hlManageProviders" runat="server" NavigateUrl="~/admin/paymentprovidermanagement.aspx" CssClass="label" /><br />
  <dashCommerce:Label ID="lblManageProvidersDescription" runat="server" CssClass="label" /><br /><br />
</dashCommerce:Panel>