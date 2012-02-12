<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="mail.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.overview.mail" %>


<dashCommerce:Panel ID="pnlMailConfiguration" runat="server">
  <br />
  <dashCommerce:HyperLink ID="hlNotifications" runat="server" NavigateUrl="~/admin/notifications.aspx" CssClass="label" /><br />
  <dashCommerce:Label ID="lblNotificationsDescription" runat="server" CssClass="label" /><br /><br />
  <dashCommerce:HyperLink ID="hlMailSettings" runat="server" NavigateUrl="~/admin/mailsettings.aspx" CssClass="label" /><br />
  <dashCommerce:Label ID="lblMailSettingsDescription" runat="server" CssClass="label" /><br /><br />
</dashCommerce:Panel>