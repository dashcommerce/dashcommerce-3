<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="providersettings.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.configuration.providersettings" %>

<%@ Register TagPrefix="dashCommerce" TagName="ShippingGeneralSettings" Src="~/admin/controls/configuration/shippingproviders/shippinggeneralsettings.ascx" %>
<div id="mainContentRegion">
  <div id="admin_centercontent">
    <div class="sectionHeader"><dashCommerce:Label ID="lblProviderSettings" runat="server" /></div><br />
      <dashCommerce:ShippingGeneralSettings ID="dcShippingGeneralSettings" runat="server" Visible="false" />
      <dashCommerce:Panel ID="pnlConfiguredProviders" runat="server">
        <br />
        <dashCommerce:Label ID="lblDefaultProviderInstructions" runat="server" CssClass="label" /><br />
        <asp:RadioButtonList ID="rblConfiguredProviders" runat="server" CssClass="label" /><br />
        <dashCommerce:Button ID="btnSetDefaultProvider" runat="server" CssClass="button" OnClick="btnSetDefaultProvider_Click" />&nbsp;&nbsp;&nbsp;
        <dashCommerce:Button ID="btnRemoveProvider" runat="server" CssClass="button" OnClick="btnRemoveProvider_Click" />
      </dashCommerce:Panel>
  </div>
</div>