<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="globalization.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.sitesettings.globalization" %>

<%@ Reference Control="~/admin/admin.master" %>
<dashCommerce:Panel ID="pnlGlobalization" runat="server">
  <br />
  <dashCommerce:Label ID="lblLanguage" runat="server" CssClass="label" /><br />
  <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="dropdownlist" />&nbsp;<dashCommerce:HelpLink ID="helpLanguage" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  <dashCommerce:Label ID="lblCurrency" runat="server" CssClass="label" /><br />
  <asp:DropDownList ID="ddlCurrency" runat="server" CssClass="dropdownlist" />&nbsp;<dashCommerce:HelpLink ID="helpCurrency" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  <div class="eventContainer">
    <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" />
  </div>  
</dashCommerce:Panel>