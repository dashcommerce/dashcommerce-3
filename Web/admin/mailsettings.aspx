<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="mailsettings.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.mailconfiguration" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/admin/admin.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="mainContentRegion">
  <div id="admin_centercontent">
    <div class="sectionHeader"><dashCommerce:Label ID="lblMailConfiguration" runat="server" /></div><br />
    <dashCommerce:Panel ID="pnlMailSettings" runat="server">
      <dashCommerce:Label ID="lblFrom" runat="server" CssClass="label"/><br />
      <asp:TextBox ID="txtFrom" runat="server" CssClass="longtextbox" />&nbsp;<dashCommerce:HelpLink ID="helpMailSettingsFrom" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
      <dashCommerce:Label ID="lblHost" runat="server" CssClass="label"/><br />
      <asp:TextBox ID="txtHost" runat="server" CssClass="longtextbox"/>&nbsp;<dashCommerce:HelpLink ID="helpMailSettingsHost" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
      <dashCommerce:Label ID="lblRequireAuthentication" runat="server" CssClass="label" /><br />
      <dashCommerce:CheckBox ID="chkRequireAuthentication" runat="server" CssClass="checkbox" />&nbsp;<dashCommerce:HelpLink ID="helpRequireAuthentication" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
      <dashCommerce:Label ID="lblUserName" runat="server" CssClass="label"/><br />
      <asp:TextBox ID="txtUserName" runat="server" CssClass="longtextbox"/>&nbsp;<dashCommerce:HelpLink ID="helpMailSettingsUserName" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
      <dashCommerce:Label ID="lblPassword" runat="server" CssClass="label"/><br />
      <asp:TextBox ID="txtPassword" runat="server" CssClass="longtextbox"/>&nbsp;<dashCommerce:HelpLink ID="helpMailSettingsPassword" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
      <dashCommerce:Label ID="lblRequireSsl" runat="server" CssClass="label" /><br />
      <dashCommerce:CheckBox ID="chkRequireSsl" runat="server" CssClass="checkbox" />&nbsp;<dashCommerce:HelpLink ID="helpMailRequireSsl" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
      <dashCommerce:Label ID="lblPort" runat="server" CssClass="label"/><br />
      <asp:TextBox ID="txtPort" runat="server" />&nbsp;<dashCommerce:HelpLink ID="helpMailSettingsPort" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
      <dashCommerce:Button ID="btnTest" runat="server" CssClass="button" OnClick="btnTestSmtp_Click" />
      <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" /><br />
    </dashCommerce:Panel>
  </div>
</div>
</asp:Content>
