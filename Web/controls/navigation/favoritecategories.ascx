<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="favoritecategories.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.controls.navigation.favoritecategories" EnableViewState="false" %>

<dashCommerce:Panel ID="pnlFavoriteCategories" runat="server" CssClass="widget">
  <asp:Repeater ID="rptrFavoriteCategories" runat="server">
    <ItemTemplate>
      <div class="favoriteCategory">
        <dashCommerce:HyperLink ID="hlFavoriteCategory" runat="server" NavigateUrl='<%# GetCatalogUrl(Eval("CategoryId").ToString(), Eval("Name").ToString()) %>' Text='<%# Eval("Name") %>' />
      </div>
    </ItemTemplate>
  </asp:Repeater>
</dashCommerce:Panel>
