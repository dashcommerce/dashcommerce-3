<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="orderedit.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.orderedit" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/admin/admin.master" %>
<%@ Register TagPrefix="dashCommerce" TagName="Navigation" Src="~/admin/controls/navigation/order.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="Receipt" Src="~/admin/controls/order/receipt.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="Transaction" Src="~/admin/controls/order/transaction.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="Actions" Src="~/admin/controls/order/actions.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="Shipping" Src="~/admin/controls/order/shipping.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="Notes" Src="~/admin/controls/order/notes.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="mainContentRegion">
    <div id="admin_centercontent">
      <div class="sectionHeader"><dashCommerce:Label ID="lblOrderEdit" runat="server" /></div><br />
      <dashCommerce:Navigation ID="navigation" runat="server" />
      <dashCommerce:Receipt ID="receipt" runat="server" Visible="false" />
      <dashCommerce:Transaction ID="transaction" runat="server" Visible="false" />
      <dashCommerce:Actions ID="actions" runat="server" Visible="false" />
      <dashCommerce:Shipping ID="shipping" runat="server" Visible="false" />
      <dashCommerce:Notes ID="notes" runat="server" Visible="false" />
    </div>
  </div>
</asp:Content>
