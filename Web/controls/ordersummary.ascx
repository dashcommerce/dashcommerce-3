<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ordersummary.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.controls.ordersummary" %>


<div class="controlHeader"><dashCommerce:Label ID="lblOrderSummary" runat="server" /></div>
<br />
<table class="orderSummaryTable">
  <tr><th class="itemSku"><dashCommerce:Label ID="lblItemSku" runat="server" /></th><th class="itemName"><dashCommerce:Label ID="lblItem" runat="server" /></th><th class="itemQuantity"><dashCommerce:Label ID="lblQuantity" runat="server" /></th><th class="itemAmount"><dashCommerce:Label ID="lblPrice" runat="server" /></th><th class="extendedAmount"><dashCommerce:Label ID="lblExtendedAmount" runat="server" /></th></tr>
    <asp:Repeater ID="rptrCart" runat="server">
      <ItemTemplate>
        <tr class="itemRow">
            <td class="itemSku"><dashCommerce:Label ID="lblSku" runat="server" Text='<%# Eval("Sku") %>' /></td>
            <td class="itemName"><dashCommerce:Label ID="lblOrderItemId" runat="server" Visible="false" Text='<%# Eval("OrderItemId") %>' />
                                 <dashCommerce:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' /><br />
                                 <dashCommerce:Label ID="lblAttributes" runat="server" Text='<%# Eval("Attributes") %>' /><br /><br /></td>
            <td class="itemQuantity">
              <asp:TextBox ID="txtQuantity" runat="server" CssClass="quantitytextbox" />
              <asp:FilteredTextBoxExtender ID="ftbeQuantity" runat="server" TargetControlId="txtQuantity" FilterType="Numbers" />
              <asp:DropDownList ID="ddlQuantity" runat="server" />
            </td>
            <td class="itemAmount"><%# GetFormattedAmount(Eval("PricePaid").ToString()) %></td>
            <td class="extendedAmount"><%# GetFormattedAmount(Eval("ExtendedPrice").ToString()) %></td>
            <% if(IsEditable) { //TODO: Get this logic out of here%>
            <td class="editArea"><asp:ImageButton ID="lbDelete" runat="server" CommandArgument='<%# Eval("OrderItemId") %>' AlternateText='<%# GetDeleteText() %>' OnCommand="lbDelete_Click" SkinId="delete"/></td>
            <%} %>
        </tr>
      </ItemTemplate>
    </asp:Repeater>
  <tr>
    <td colspan="4" class="subTotal"><dashCommerce:Label ID="lblSubTotal" runat="server" /></td>
    <td class="subTotalAmount"><dashCommerce:Label ID="lblSubTotalAmount" runat="server" /></td>
  </tr>
  <tr id="trCoupon" runat="server">
    <td colspan="4" class="subTotal"><dashCommerce:Label ID="lblCoupon" runat="server" /></td>
    <td class="subTotalAmount"><dashCommerce:Label ID="lblCouponAmount" runat="server" /></td>
  </tr>
  <tr id="trTax" runat="server">
    <td colspan="4" class="subTotal"><dashCommerce:Label ID="lblTax" runat="server" /></td>
    <td class="subTotalAmount"><dashCommerce:Label ID="lblTaxAmount" runat="server" /></td>
  </tr>
  <tr>
    <td colspan="4" class="subTotal">
      <dashCommerce:Label ID="lblShipping" runat="server" />

      <asp:DropDownList ID="ddlShipping" runat="server" Visible="false" OnSelectedIndexChanged="ddlShipping_SelectedIndexChanged" AutoPostBack="true" />   
    </td>
    <td class="subTotalAmount"><dashCommerce:Label ID="lblShippingAmount" runat="server" /></td>
  </tr>
  <tr><td colspan="4" class="total"><dashCommerce:Label ID="lblTotal" runat="server" /></td><td class="totalAmount"><dashCommerce:Label ID="lblTotalAmount" runat="server" /></td></tr>
</table>
