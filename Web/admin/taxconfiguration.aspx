<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="taxconfiguration.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.taxconfiguration" Title="Untitled Page" %>
<%@ Register TagPrefix="dashCommerce" TagName="ProviderConfiguration" Src="~/admin/controls/configuration/providerconfiguration.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <dashCommerce:ProviderConfiguration id="dcProviderConfiguration" runat="server" />
</asp:Content>
