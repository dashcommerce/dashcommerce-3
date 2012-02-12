<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="caching.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.sitesettings.caching" %>
<%@ Reference Control="~/admin/admin.master" %>

<dashCommerce:Panel ID="pnlCaching" runat="server">
  <br />
  <dashCommerce:CheckBox ID="chkUseCache" runat="server" CssClass="label" />&nbsp;<dashCommerce:HelpLink ID="helpUseCache" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  <dashCommerce:Label ID="lblShortCache" runat="server" CssClass="label" /><br />
  <asp:TextBox ID="txtShortCache" runat="server" CssClass="textbox" />&nbsp;<dashCommerce:HelpLink ID="helpShortCache" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  <dashCommerce:Label ID="lblNormalCache" runat="server" CssClass="label" /><br />
  <asp:TextBox ID="txtNormalCache" runat="server" CssClass="textbox" />&nbsp;<dashCommerce:HelpLink ID="helpNormalCache" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  <dashCommerce:Label ID="lblLongCache" runat="server" CssClass="label" /><br />
  <asp:TextBox ID="txtLongCache" runat="server" CssClass="textbox" />&nbsp;<dashCommerce:HelpLink ID="helpLongCache" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  <dashCommerce:RequiredFieldValidator ID="rfvShortCache" runat="server" Display="None" ControlToValidate="txtShortCache"/>
  <dashCommerce:RequiredFieldValidator ID="rfvNormalCache" runat="server" Display="None" ControlToValidate="txtNormalCache"/>
  <dashCommerce:RequiredFieldValidator ID="rfvLongCache" runat="server" Display="None" ControlToValidate="txtLongCache"/>
  <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" />
  <dashCommerce:Button ID="btnRefreshCache" runat="server" CssClass="button" OnClick="btnRefreshCache_Click" />
  <dashCommerce:Button ID="btnClearCache" runat="server" CssClass="button" OnClick="btnClearCache_Click" />
</dashCommerce:Panel>
