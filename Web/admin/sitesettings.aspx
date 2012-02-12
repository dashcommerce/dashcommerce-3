<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="sitesettings.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.sitesettings" Title="Untitled Page" ValidateRequest="false" %>
<%@ MasterType VirtualPath="~/admin/admin.master" %>

<%@ Register TagPrefix="dashCommerce" TagName="SiteSettingsNavigation" Src="~/admin/controls/navigation/sitesettings.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="GlobalizationSettings" Src="~/admin/controls/sitesettings/globalization.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="Site" Src="~/admin/controls/sitesettings/site.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="Widgets" Src="~/admin/controls/sitesettings/widgets.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="BrowsingLog" Src="~/admin/controls/sitesettings/browsinglog.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="CacheSettings" Src="~/admin/controls/sitesettings/caching.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="Analytics" Src="~/admin/controls/sitesettings/analytics.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="Images" Src="~/admin/controls/sitesettings/images.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="SeoSettings" Src="~/admin/controls/sitesettings/seosettings.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="mainContentRegion">
    <div id="admin_centercontent">
      <div class="sectionHeader"><dashCommerce:Label ID="lblSiteSettings" runat="server" /></div><br />
      <dashCommerce:SiteSettingsNavigation ID="dcSiteSettingsNavigation" runat="server" />
      <dashCommerce:Site ID="dcSite" runat="server" Visible="false" />
      <dashCommerce:GlobalizationSettings ID="dcGlobalizationSettings" runat="server" Visible="false" />
      <dashCommerce:Widgets ID="dcWidgets" runat="server" Visible="false" />
      <dashCommerce:BrowsingLog ID="dcBrowsingLog" runat="server" Visible="false" />
      <dashCommerce:CacheSettings ID="dcCachingSettings" runat="server" Visible="false" />
      <dashCommerce:Analytics ID="dcAnalytics" runat="server" Visible="false" />
      <dashCommerce:Images ID="dcImagesSettings" runat="server" Visible="false" />
      <dashCommerce:SeoSettings ID="dcSeoSettings" runat="server" Visible="false" />
    </div>
  </div>
</asp:Content>
