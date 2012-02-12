<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.search" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/site.master" %>
<%@ Register TagPrefix="dashCommerce" TagName="Navigation" Src="~/controls/navigation/storenavigation.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="CatalogList" Src="~/controls/catalogList.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="Pager" Src="~/controls/paging.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="threeColumnLeftContent">
    <dashCommerce:Navigation ID="leftNavigation" runat="server" />
  </div>
  <div id="threeColumnRightContent">
  </div>
  <div id="threeColumnMainContent">
    <dashCommerce:Pager ID="topPager" runat="server" />
    <dashCommerce:CatalogList ID="catalogList" runat="server" />
    <dashCommerce:Pager ID="bottomPager" runat="server" />
  </div>
</asp:Content>