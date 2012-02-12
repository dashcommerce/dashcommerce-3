<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="favoriteproducts.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.controls.navigation.favoriteproducts" EnableViewState="false" %>

<dashCommerce:Panel ID="pnlFavoriteProducts" runat="server" CssClass="widget">
  <asp:Repeater ID="rptrFavoriteProducts" runat="server">
    <ItemTemplate>
      <div class="favoriteProduct">
        <dashCommerce:HyperLink ID="hlFavoriteProduct" runat="server" NavigateUrl='<%# GetProductUrl(Eval("ProductId").ToString(), Eval("Name").ToString()) %>' Text='<%# Eval("Name") %>' />
      </div>
    </ItemTemplate>
  </asp:Repeater>
</dashCommerce:Panel>
