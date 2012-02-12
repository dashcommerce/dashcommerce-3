<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="shipping.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.order.shipping" %>


<dashCommerce:Panel ID="pnlShipping" runat="server">
  <br />
  <dashCommerce:Label ID="lblShippingTrackingNumber" runat="server" CssClass="label" /><br />
  <asp:TextBox ID="txtShippingTrackingNumber" runat="server" TextMode="MultiLine" CssClass="multilinetextbox" /><br /><br />
  <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" />
</dashCommerce:Panel>