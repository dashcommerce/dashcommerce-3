<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="catalogList.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.controls.catalogList" EnableViewState="false" %>


<asp:DataList ID="dlCatalog" runat="server" SkinId="catalogList">
  <ItemTemplate>
    <div class="productBox">
      <div class="productImageContainer">
        <dashCommerce:HyperLink ID="hlImageLink" runat="server" NavigateUrl='<%# GetNavigateUrl(Eval("ProductId").ToString(), Eval("Name").ToString()) %>' SkinID="noDefaultImage" />
      </div>
      <dashCommerce:HyperLink ID="hlProduct" runat="server" NavigateUrl='<%# GetNavigateUrl(Eval("ProductId").ToString(), Eval("Name").ToString()) %>' Text='<%#Eval("Name") %>' CssClass="catalogProductName" /><br />
      <dashCommerce:Label ID="lblRetailPrice" runat="server" CssClass="retailPrice" /><dashCommerce:Label ID="lblOurPrice" runat="server" CssClass="ourPrice" />&nbsp;&nbsp;<dashCommerce:Label ID="lblTaxApplied" Visible="false" runat="server" /><br />
      <asp:Rating ID="ajaxRating" runat="server" SkinID="rating" ReadOnly="true" />
    </div>
  </ItemTemplate>
</asp:DataList>
