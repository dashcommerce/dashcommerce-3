<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditContactUs.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.content.EditContactUs" %>

<dashCommerce:Label ID="lblEmail" runat="server" CssClass="label"/><br />
<asp:TextBox ID="txtEmail" runat="server" CssClass="longtextbox" />&nbsp;<dashCommerce:HelpLink ID="helpMailSettingTo" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
<dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" /><br />
