<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="paymentsolutions.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.paymentsolutionsignup" %>
<%@ Register TagPrefix="dashCommerce" TagName="PaymentSolution" Src="~/admin/controls/configuration/paymentproviders/paymentsolutions.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dashCommerce:PaymentSolution ID="paymentSolution" runat="server" />
</asp:Content>
