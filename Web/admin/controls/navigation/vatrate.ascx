<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="vatrate.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.navigation.vatrate" %>
<asp:Menu ID="vatMenu" runat="server" Orientation="Horizontal" DataSourceID="vatDataSource" StaticDisplayLevels="2" StaticSubMenuIndent="0px" CssClass="navigationTable">
  <StaticItemTemplate>
  <div id="left"></div><div id="mid"><span id="text"><%# DataBinder.Eval(Container.DataItem, "Text") %></span></div><div id="right"></div>
 </StaticItemTemplate>
 <StaticMenuItemStyle CssClass="menuItem" />
 <StaticSelectedStyle CssClass="menuItemSelected" />
</asp:Menu>
<hr class="navigationRule" />
<asp:SiteMapDataSource ID="vatDataSource" runat="server" SiteMapProvider="VatXmlSiteMapProvider" />