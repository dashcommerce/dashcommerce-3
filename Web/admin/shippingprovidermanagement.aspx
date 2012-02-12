<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="shippingprovidermanagement.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.shippingprovidermanagement" Title="Untitled Page" ValidateRequest="false"%>
<%@ Register TagPrefix="dashCommerce" TagName="ProviderManagement" Src="~/admin/controls/configuration/providermanagement.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <dashCommerce:ProviderManagement ID="dcProviderManagement" runat="server" />
</asp:Content>
