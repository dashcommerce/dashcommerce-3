<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="product.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.navigation.product" %>
<asp:Menu ID="productMenu" runat="server" Orientation="Horizontal" DataSourceID="productDataSource" StaticDisplayLevels="2" StaticSubMenuIndent="0px" CssClass="navigationTable">
  <StaticItemTemplate>
  <div id="left"></div><div id="mid"><span id="text"><%# DataBinder.Eval(Container.DataItem, "Text") %></span></div><div id="right"></div>
 </StaticItemTemplate>
 <StaticMenuItemStyle CssClass="menuItem" />
 <StaticSelectedStyle CssClass="menuItemSelected" />
</asp:Menu>
<hr class="navigationRule" />
<asp:SiteMapDataSource ID="productDataSource" runat="server" SiteMapProvider="ProductXmlSiteMapProvider" />