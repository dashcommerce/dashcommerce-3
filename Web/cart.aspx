<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.cart" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/site.master" %>

<%@ Register TagPrefix="dashCommerce" TagName="Navigation" Src="~/controls/navigation/storenavigation.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="CatalogList" Src="~/controls/catalogList.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="OrderSummary" Src="~/controls/ordersummary.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="twoColumnLeftContent">
    <dashCommerce:Navigation ID="navigation" runat="server" />
  </div>
  <div id="twoColumnMainContent">
  <dashCommerce:MessageCenter ID="messageCenter" runat="server" Visible="false" />
  <dashCommerce:Panel ID="pnlCart" runat="server">
    <table class="cartSubTotal">
      <tr>
        <td class="itemName"><dashCommerce:HyperLink ID="hlCheckout1" runat="server" SkinId="proceedToCheckout" /></td>
        <td class="subTotal"><dashCommerce:Label ID="lblSubTotalTop" runat="server" /></td>
        <td class="subTotalAmount"><dashCommerce:Label ID="lblSubTotalAmountTop" runat="server" /></td>
      </tr>
    </table>
    <br />
    <dashCommerce:LinkButton ID="lbUpdate" runat="server" OnClick="lbUpdate_Click" />
    <br />
    <br />
    <dashCommerce:OrderSummary ID="orderSummary" runat="server" IsEditable="true" />
    <hr />
    <div>
      <dashCommerce:HyperLink ID="hlCheckout2" runat="server" SkinId="proceedToCheckout" />
    </div>
    <br />
    <br />
    <dashCommerce:Panel ID="pnlExpressCheckout" runat="server" Visible="false">
      <asp:ImageButton ID="imgPayPal" runat="server" ImageUrl="https://www.paypal.com/en_US/i/btn/btn_xpressCheckout.gif" OnClick="imgPayPal_Click" CausesValidation="False" />
    </dashCommerce:Panel>
  </dashCommerce:Panel>
  <dashCommerce:Panel ID="pnlNoCart" runat="server">
    <dashCommerce:Label ID="lblNoCart" runat="server" CssClass="label" /><br /><br />
    <hr />
    <dashCommerce:CatalogList ID="catalogList" runat="server" />
  </dashCommerce:Panel>
  </div>
</asp:Content>
