<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="actions.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.order.actions" %>



<dashCommerce:Panel ID="pnlOrderStatus" runat="server">
  <dashCommerce:Label ID="lblOrderStatus" runat="server" CssClass="label" /><br />
  <asp:DropDownList ID="ddlOrderStatus" runat="server" CssClass="dropdownlist" /><br /><br />
  <dashCommerce:Button ID="btnOrderStatus" runat="server" CssClass="button" OnClick="btnOrderStatus_Click" />
</dashCommerce:Panel>
<br />
<br />
<dashCommerce:Panel ID="pnlRefund" runat="server">
  <dashCommerce:Label ID="lblActionMessage" runat="server" CssClass="label" /><br /><br />
  <dashCommerce:DataGrid ID="dgOrderItems" runat="server" AutoGenerateColumns="false" SkinID="adminDataGridNoPage" DataKeyField="OrderItemId">
    <Columns>
      <asp:BoundColumn DataField="OrderItemId" Visible="false" />
      <asp:TemplateColumn>
        <ItemTemplate>
          <asp:TextBox ID="txtRefundQuantity" runat="server" CssClass="smalltextbox" /><asp:FilteredTextBoxExtender ID="ftbeQuantity" runat="server" TargetControlId="txtRefundQuantity" FilterType="Numbers" />
          <asp:RangeValidator ID="rvRefundQuantity" runat="server" ControlToValidate="txtRefundQuantity" Type="Integer" Display="None" />
        </ItemTemplate>
      </asp:TemplateColumn>
      <asp:BoundColumn DataField="Sku" />
      <asp:TemplateColumn ItemStyle-HorizontalAlign="Right" >
        <ItemTemplate>
          <dashCommerce:Label ID="lblNetAmount" runat="server" />
        </ItemTemplate>
      </asp:TemplateColumn>    
      <asp:BoundColumn DataField="Name" />
      <asp:TemplateColumn ItemStyle-HorizontalAlign="Right" >
        <ItemTemplate>
          <%# GetFormattedAmount(Eval("PricePaid").ToString()) %>
        </ItemTemplate>
      </asp:TemplateColumn>
      <asp:TemplateColumn ItemStyle-HorizontalAlign="Right" >
        <ItemTemplate>
          <%# GetFormattedAmount(Eval("ItemTax").ToString()) %>
        </ItemTemplate>
      </asp:TemplateColumn>
      <asp:TemplateColumn ItemStyle-HorizontalAlign="Right" >
        <ItemTemplate>
          <%# GetFormattedAmount(Eval("DiscountAmount").ToString()) %>
        </ItemTemplate>
      </asp:TemplateColumn>    
    </Columns>
  </dashCommerce:DataGrid>
  <dashCommerce:Label ID="lblAdditionalRefundAmount" runat="server" CssClass="label" /><br />
  <asp:TextBox ID="txtAdditionalRefundAmount" runat="server" CssClass="textbox" /><br /><br />
  <dashCommerce:Button ID="btnRefundTransaction" runat="server" CssClass="button" OnClick="btnRefundTransaction_Click" />
</dashCommerce:Panel>
<br />
<br />
<dashCommerce:Panel ID="pnlManualTransaction" runat="server">
  <dashCommerce:Label ID="lblManualTransaction" runat="server" CssClass="label" /><br /><br />
  <dashCommerce:Label ID="lblTransactionId" runat="server" CssClass="label" /><br />
  <asp:TextBox ID="txtTransactionId" runat="server" CssClass="textbox" /><br /><br />
  <dashCommerce:Button ID="btnManualTransaction" runat="server" CssClass="button" OnClick="btnManualTransaction_Click" />
</dashCommerce:Panel>
