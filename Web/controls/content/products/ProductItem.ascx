<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ProductItem.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.controls.content.products.ProductItem" EnableViewState="false" %>


<div class="productBox">
  <div class="productImageContainer">
    <dashCommerce:HyperLink ID="hlImageLink" runat="server" NavigateUrl='<%# GetNavigateUrl(CurrentProduct.ProductId.ToString(), CurrentProduct.Name) %>' SkinID="noDefaultImage" />
  </div>
  <dashCommerce:HyperLink ID="hlProduct" runat="server" NavigateUrl='<%#GetNavigateUrl(CurrentProduct.ProductId.ToString(), CurrentProduct.Name) %>' Text='<%#CurrentProduct.Name %>' CssClass="catalogProductName" /><br />
  <dashCommerce:Label ID="lblRetailPrice" runat="server" CssClass="retailPrice" /><dashCommerce:Label ID="lblOurPrice" runat="server" CssClass="ourPrice" /><br />
  <asp:Rating ID="ajaxRating" runat="server" SkinID="rating" ReadOnly="true" />
</div>
