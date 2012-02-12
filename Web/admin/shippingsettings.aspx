<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="shippingsettings.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.shippingsettings" Title="Untitled Page" %>
<%@ Register TagPrefix="dashCommerce" TagName="ProviderSettings" Src="~/admin/controls/configuration/providersettings.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <dashCommerce:ProviderSettings ID="dcProviderSettings" runat="server" />
</asp:Content>
