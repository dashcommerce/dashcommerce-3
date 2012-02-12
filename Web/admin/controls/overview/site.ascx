<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="site.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.overview.site" %>


<dashCommerce:Panel ID="pnlSiteOverview" runat="server">
  <br />
  <dashCommerce:HyperLink ID="hlSiteSettings" runat="server" NavigateUrl="~/admin/sitesettings.aspx" CssClass="label" /><br />
  <dashCommerce:Label ID="lblSiteSettingsDescription" runat="server" CssClass="label" /><br /><br />

  <dashCommerce:HyperLink ID="hlContentManagement" runat="server" NavigateUrl="~/admin/contentedit.aspx" CssClass="label" /><br />
  <dashCommerce:Label ID="lblContentManagementDescription" runat="server" CssClass="label" /><br /><br />

  <dashCommerce:HyperLink ID="hlSecurity" runat="server" NavigateUrl="~/admin/overview.aspx?view=sec" CssClass="label" /><br />
  <dashCommerce:Label ID="lblSecurityDescription" runat="server" CssClass="label" /><br /><br />

  <dashCommerce:HyperLink ID="hlTrackingLogs" runat="server" NavigateUrl="~/admin/trackinglogs.aspx" CssClass="label"/><br />
  <dashCommerce:Label ID="lblTrackingLogsDescription" runat="server" CssClass="label" /><br /><br />

  <dashCommerce:HyperLink ID="hlErrorLogs" runat="server" NavigateUrl="~/admin/errorlogs.aspx" CssClass="label"/><br />
  <dashCommerce:Label ID="lblErrorLogsDescription" runat="server" CssClass="label" /><br /><br />
</dashCommerce:Panel>