<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="browsinglog.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.sitesettings.browsinglog" %>


<dashCommerce:Panel ID="pnlBrowsingLog" runat="server">
  <br />
  <dashCommerce:Label ID="lblBrowsingCategory" runat="server" CssClass="label" /><br />
  <dashCommerce:CheckBox ID="chkBrowsingCategory" runat="server" />&nbsp;<dashCommerce:HelpLink ID="helpBrowsingCategory" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  <dashCommerce:Label ID="lblBrowsingProduct" runat="server" CssClass="label" /><br />
  <dashCommerce:CheckBox ID="chkBrowsingProduct" runat="server" />&nbsp;<dashCommerce:HelpLink ID="helpBrowsingProduct" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  <dashCommerce:Label ID="lblCollectSearchTerms" runat="server" CssClass="label" /><br />
  <dashCommerce:CheckBox ID="chkCollectSearchTerms" runat="server" />&nbsp;<dashCommerce:HelpLink ID="helpCollectSearchTerms" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  
  <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" />
  
</dashCommerce:Panel>