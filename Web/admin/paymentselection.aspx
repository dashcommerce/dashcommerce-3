<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="paymentselection.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.paymentselection" Title="Untitled Page" %>
<%@ Register TagPrefix="dashCommerce" TagName="PaymentSelection" Src="~/admin/controls/configuration/paymentproviders/paymentselection.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <dashCommerce:PaymentSelection ID="paymentSelection" runat="server" />
</asp:Content>
