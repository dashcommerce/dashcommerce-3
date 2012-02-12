<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewCustomizedProductsDisplay.ascx.cs"
    Inherits="MettleSystems.dashCommerce.Web.controls.content.products.ViewCustomizedProductsDisplay" %>
<%@ Register Src="~/controls/content/products/ProductItem.ascx" TagName="ProductItem"
    TagPrefix="dashCommerce" %>
<asp:DataList ID="dlProducts" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
    <ItemTemplate>
        <dashCommerce:ProductItem ID="ProductItem1" runat="server" CurrentProduct='<%# LoadProduct((int)Eval("ProductId"))%>' />
    </ItemTemplate>
</asp:DataList>
