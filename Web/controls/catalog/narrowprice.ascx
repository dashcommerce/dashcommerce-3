<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="narrowprice.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.controls.catalog.narrowprice" EnableViewState="false" %>


<dashCommerce:Panel ID="pnlNarrowByPrice" runat="server" CssClass="widget">
  <asp:Repeater ID="rptrNarrowByPrice" runat="server">
    <ItemTemplate>
      <dashCommerce:HyperLink ID="hlNarrowByPrice" runat="server" NavigateUrl='<%# GetPriceRangeUrl(Eval("lowRange").ToString(), Eval("hiRange").ToString()) %>' Text='<%# GetFormattedPriceRange(Eval("lowRange").ToString(), Eval("hiRange").ToString()) %>' /><br />
    </ItemTemplate>
  </asp:Repeater>
</dashCommerce:Panel>