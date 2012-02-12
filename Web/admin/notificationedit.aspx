<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="notificationedit.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.notificationedit" Title="Untitled Page" ValidateRequest="false" %>

<%@ MasterType VirtualPath="~/admin/admin.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="mainContentRegion">
    <div id="admin_centercontent">
      <div class="sectionHeader"><dashCommerce:Label ID="lblNotificationEdit" runat="server" /></div><br />
      <dashCommerce:Panel ID="pnlNotificationDetails" runat="server">
        <dashCommerce:Label ID="lblIsSystemNotification" runat="server" CssClass="label" /><br />
        <dashCommerce:CheckBox ID="chkIsSystemNotification" runat="server" Enabled="false"/><br /><br />
        <dashCommerce:Label ID="lblName" runat="server" CssClass="label" /><br />
        <asp:TextBox ID="txtName" runat="server" CssClass="longtextbox" /><br /><br />
        <dashCommerce:Label ID="lblToList" runat="server" CssClass="label" /><br />
        <asp:TextBox ID="txtToList" runat="server" CssClass="longmultilinetextbox" TextMode="MultiLine" /><br /><br />
        <dashCommerce:Label ID="lblCcList" runat="server" CssClass="label" /><br />
        <asp:TextBox ID="txtCcList" runat="server" CssClass="longmultilinetextbox" TextMode="MultiLine" /><br /><br />
        <dashCommerce:Label ID="lblFromName" runat="server" CssClass="label" /><br />
        <asp:TextBox ID="txtFromName" runat="server" CssClass="longtextbox" /><br /><br />
        <dashCommerce:Label ID="lblFromEmail" runat="server" CssClass="label" /><br />
        <asp:TextBox ID="txtFromEmail" runat="server" CssClass="longtextbox" /><br /><br />
        <dashCommerce:Label ID="lblSubject" runat="server" CssClass="label" /><br />
        <asp:TextBox ID="txtSubject" runat="server" CssClass="longtextbox" /><br /><br />
        <dashCommerce:Label ID="lblIsHtml" runat="server" CssClass="label" /><br />
        <dashCommerce:CheckBox ID="chkIsHtml" runat="server" /><br /><br />
        <dashCommerce:Label ID="lblNotificationBody" runat="server" CssClass="label" /><br />
        <FCKeditorV2:FCKeditor ID="txtNotificationBody" runat="server" BasePath="~/FCKeditor/"
          Height="400" ToolbarStartExpanded="false" UseBROnCarriageReturn="true" Width="100%" /><br />
        <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" />
      </dashCommerce:Panel>
    </div>
  </div>
</asp:Content>
