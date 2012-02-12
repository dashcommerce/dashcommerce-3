<%@ Page Language="C#" MasterPageFile="~/admin/modal.master" AutoEventWireup="true" CodeBehind="region.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.region" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/admin/modal.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<dashCommerce:Panel ID="pnlAddRegion" runat="server">
    <dashCommerce:Label ID="lblRegionTitle" runat="server" CssClass="label" /><br />
    <asp:TextBox ID="txtTitle" runat="server" MaxLength="100" CssClass="textbox" />&nbsp;<dashCommerce:HelpLink ID="helpRegionTitle" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
    <dashCommerce:Label ID="lblShowTitle" runat="server" CssClass="label" /><br />
    <dashCommerce:CheckBox ID="chkShowTitle" runat="server" />&nbsp;<dashCommerce:HelpLink ID="helpShowTitle" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
    <dashCommerce:Label ID="lblSortOrder" runat="server" CssClass="label" /><br />
    <asp:TextBox ID="txtSortOrder" runat="server" MaxLength="100" CssClass="smalltextbox" />&nbsp;<dashCommerce:HelpLink ID="helpSortOrder" runat="server" NavigateUrl="javascript:void(0);" /><asp:FilteredTextBoxExtender ID="ftbeQuantity" runat="server" TargetControlId="txtSortOrder" FilterType="Numbers" /><br /><br />
    <dashCommerce:Label ID="lblProvider" runat="server" CssClass="label" /><br />
    <asp:DropDownList ID="ddlProvider" runat="server" CssClass="dropdownlist" />&nbsp;<dashCommerce:HelpLink ID="helpProvider" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
    <dashCommerce:Label ID="lblTemplateRegion" runat="server" CssClass="label" /><br />
    <asp:DropDownList ID="ddlTemplateRegion" runat="server" CssClass="dropdownlist" />&nbsp;<dashCommerce:HelpLink ID="helpTemplateRegion" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
    <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click"/>    
</dashCommerce:Panel>
</asp:Content>