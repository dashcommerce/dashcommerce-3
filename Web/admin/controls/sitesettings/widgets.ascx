<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widgets.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.sitesettings.widgets" %>


<dashCommerce:Panel ID="pnlWidgets" runat="server">
  <br />
  <dashCommerce:Label ID="lblDisplayNarrowByManufacturer" runat="server" CssClass="label" /><br />
  <dashCommerce:CheckBox ID="chkDisplayNarrowByManufacturer" runat="server" />&nbsp;<dashCommerce:HelpLink ID="helpDisplayNarrowByManufacturer" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  <dashCommerce:Label ID="lblDisplayNarrowByPrice" runat="server" CssClass="label" /><br />
  <dashCommerce:CheckBox ID="chkDisplayNarrowByPrice" runat="server" />&nbsp;<dashCommerce:HelpLink ID="helpDisplayNarrowByPrice" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  <dashCommerce:Label ID="lblDisplaySortBy" runat="server" CssClass="label" /><br />
  <dashCommerce:CheckBox ID="chkDisplaySortBy" runat="server" />&nbsp;<dashCommerce:HelpLink ID="helpDisplaySortBy" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  <dashCommerce:Label ID="lblDisplayNarrowCategory" runat="server" CssClass="label" /><br />
  <dashCommerce:CheckBox ID="chkDisplayNarrowCategory" runat="server" />&nbsp;<dashCommerce:HelpLink ID="helpDisplayNarrowByCategory" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" />
</dashCommerce:Panel>
