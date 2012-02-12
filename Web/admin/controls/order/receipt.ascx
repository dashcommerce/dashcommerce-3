<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="receipt.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.order.receipt" %>

<asp:Repeater ID="rptrReceipts" runat="server">
  <ItemTemplate>
    <dashCommerce:Label ID="lblReceipt" runat="server" />
    <br />
    <hr />
  </ItemTemplate>
</asp:Repeater>
