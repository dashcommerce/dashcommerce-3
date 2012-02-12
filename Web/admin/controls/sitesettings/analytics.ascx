<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="analytics.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.sitesettings.analytics" %>

<dashCommerce:Panel ID="pnlAnalytics" runat="server">
  <br />
  <div class="verticalalign">
    <dashCommerce:Label ID="lblAnalytics" runat="server" CssClass="label" />&nbsp;<dashCommerce:HelpLink ID="helpAnalytics" runat="server" NavigateUrl="javascript:void(0);" /><br />
  </div>
  <asp:TextBox ID="txtAnalytics" runat="server" CssClass="largemultilinetextbox" TextMode="MultiLine"/><br /><br />
  <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" />
</dashCommerce:Panel>
