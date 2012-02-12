<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="paymentconfiguration.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.paymentconfiguration" Title="Untitled Page" %>
<%@ Register TagPrefix="dashCommerce" TagName="ProviderConfiguration" Src="~/admin/controls/configuration/providerconfiguration.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <dashCommerce:ProviderConfiguration id="dcProviderConfiguration" runat="server" />
</asp:Content>
