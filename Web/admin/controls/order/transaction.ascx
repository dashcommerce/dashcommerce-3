<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="transaction.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.order.transaction" %>


<asp:Repeater ID="rptrTransactions" runat="server">
  <ItemTemplate>
    <strong><%# Eval("TransactionTypeDescriptor.Name") %>&nbsp;-&nbsp;<%# Eval("TransactionDate") %></strong><br />
    <dashCommerce:Label ID="lblTransactionId" runat="server" CssClass="label" />&nbsp;<dashCommerce:Label ID="txtTransactionId" runat="server" CssClass="label" Text='<%# Eval("TransactionId") %>' /><br />
    <dashCommerce:Label ID="lblTransactionType" runat="server" CssClass="label" />&nbsp;<dashCommerce:Label ID="txtTransactionType" runat="server" CssClass="label" Text='<%# Eval("TransactionTypeDescriptor.Name") %>' /><br />
    <dashCommerce:Label ID="lblPaymentMethod" runat="server" CssClass="label" />&nbsp;<dashCommerce:Label ID="txtPaymentMethod" runat="server" CssClass="label" Text='<%# Eval("PaymentMethod") %>' /><br />
    <dashCommerce:Label ID="lblGatewayName" runat="server" CssClass="label" />&nbsp;<dashCommerce:Label ID="txtGatewayName" runat="server" CssClass="label" Text='<%# Eval("GatewayName") %>' /><br />
    <div class="verticalalign">
    <dashCommerce:Label ID="lblGatewayResponse" runat="server" CssClass="label" />&nbsp;<dashCommerce:Label ID="txtGatewayResponse" runat="server" CssClass="label" Text='<%# Eval("GatewayResponse") %>' />&nbsp;<dashCommerce:HelpLink ID="helpPayPalPending" runat="server" NavigateUrl="javascript:void(0);" Visible="false" /><br />
    </div>
    <dashCommerce:Label ID="lblGatewayTransactionId" runat="server" CssClass="label" />&nbsp;<dashCommerce:Label ID="txtGatewayTransactionId" runat="server" CssClass="label" Text='<%# Eval("GatewayTransactionId") %>' /><br />
    <dashCommerce:Label ID="lblAVSCode" runat="server" CssClass="label" />&nbsp;<dashCommerce:Label ID="txtAVSCode" runat="server" CssClass="label" Text='<%# Eval("AVSCode") %>' /><br />
    <dashCommerce:Label ID="lblCVV2Code" runat="server" CssClass="label" />&nbsp;<dashCommerce:Label ID="txtCVV2Code" runat="server" CssClass="label" Text='<%# Eval("CVV2Code") %>' /><br />
    <dashCommerce:Label ID="lblGrossAmount" runat="server" CssClass="label" />&nbsp;<dashCommerce:Label ID="txtGrossAmount" runat="server" CssClass="label" Text='<%# GetFormattedAmount(Eval("GrossAmount").ToString()) %>' /><br />
    <dashCommerce:Label ID="lblNetAmount" runat="server" CssClass="label" />&nbsp;<dashCommerce:Label ID="txtNetAmount" runat="server" CssClass="label" Text='<%# GetFormattedAmount(Eval("NetAmount").ToString()) %>' /><br />
    <dashCommerce:Label ID="lblFeeAmount" runat="server" CssClass="label" />&nbsp;<dashCommerce:Label ID="txtFeeAmount" runat="server" CssClass="label" Text='<%# GetFormattedAmount(Eval("FeeAmount").ToString()) %>' /><br />
    <dashCommerce:Label ID="lblTransactionDate" runat="server" CssClass="label" />&nbsp;<dashCommerce:Label ID="txtTransactionDate" runat="server" CssClass="label" Text='<%# Eval("TransactionDate") %>' /><br />
    <dashCommerce:Label ID="lblGatewayErrors" runat="server" CssClass="label" />&nbsp;<dashCommerce:Label ID="txtGatewayErrors" runat="server" CssClass="label" Text='<%# Eval("GatewayErrors") %>' /><br /><hr /><br />
  </ItemTemplate>
</asp:Repeater>