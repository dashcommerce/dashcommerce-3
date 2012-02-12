<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="notes.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.order.notes" %>


<dashCommerce:Panel ID="pnlNoteList" runat="server">
<br />
<asp:Repeater ID="rptrNotes" runat="server">
  <ItemTemplate>
    <%# Eval("Note") %>&nbsp;&nbsp;<%# Eval("CreatedBy") %>&nbsp;&nbsp;<%# Eval("CreatedOn") %><br />
  </ItemTemplate>
</asp:Repeater>
</dashCommerce:Panel>
<br />
<dashCommerce:Panel ID="pnlAddNote" runat="server">
  <br />
  <dashCommerce:Label ID="lblAddNote" runat="server" CssClass="label" /><br />
  <asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine" CssClass="multilinetextbox" /><br /><br />
  <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" />
</dashCommerce:Panel>