<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="seosettings.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.sitesettings.seosettings" %>
<%@ Reference Control="~/admin/admin.master" %>

<dashCommerce:Panel ID="pnlSeo" runat="server">
  <br />
  <div class="verticalalign">
    <dashCommerce:Label ID="lblSiteKeywords" runat="server" CssClass="label" />&nbsp;<dashCommerce:HelpLink ID="helpSiteKeywords" runat="server" NavigateUrl="javascript:void(0);" /><br />
  </div>
  <asp:TextBox ID="txtSiteKeywords" runat="server" CssClass="multilinetextbox" /><br /><br />
  <div class="verticalalign">
    <dashCommerce:Label ID="lblSiteDescription" runat="server" CssClass="label" />&nbsp;<dashCommerce:HelpLink ID="helpSiteDescription" runat="server" NavigateUrl="javascript:void(0);" /><br />
  </div>
  <asp:TextBox ID="txtSiteDescription" runat="server" CssClass="multilinetextbox" /><br /><br />
  <dashCommerce:Label ID="lblCopyrightText" runat="server" CssClass="label" /><br />
  <asp:TextBox ID="txtCopyrightText" runat="server" CssClass="longtextbox" />&nbsp;<dashCommerce:HelpLink ID="helpCopyrightText" runat="server" NavigateUrl="javascript:void(0);" /><br />
    <br />
  <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" />
</dashCommerce:Panel>