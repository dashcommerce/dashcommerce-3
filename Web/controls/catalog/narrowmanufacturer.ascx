<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="narrowmanufacturer.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.controls.catalog.narrowmanufacturer" EnableViewState="false" %>


<dashCommerce:Panel ID="pnlNarrowByManufacturer" runat="server" CssClass="widget">
  <asp:Repeater ID="rptrNarrowByManufacturer" runat="server">
    <ItemTemplate>
      <dashCommerce:HyperLink ID="hlNarrowByManufacturer" runat="server" NavigateUrl='<%# GetManufacturerUrl(Eval("ManufacturerId").ToString()) %>' Text='<%# Eval("Name") %>' /><br />
    </ItemTemplate>
  </asp:Repeater>
</dashCommerce:Panel>