<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edithtml.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.content.html.edithtml" %>

<dashCommerce:Panel ID="pnlSimpleHtml" runat="server">
  <FCKeditorV2:FCKeditor ID="txtHtml" BasePath="~/FCKeditor/" runat="server" Height="280" Width="100%" UseBROnCarriageReturn="true" ToolbarStartExpanded="false" /><br /><br />
  <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" />
</dashCommerce:Panel>