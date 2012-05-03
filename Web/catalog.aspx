<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="catalog.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.catalog" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/site.master" %>
<%@ Register TagPrefix="dashCommerce" TagName="Navigation" Src="~/controls/navigation/storenavigation.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="Pager" Src="~/controls/paging.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="CatalogList" Src="~/controls/catalogList.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="threeColumnLeftContent">
    <dashCommerce:Navigation ID="leftNavigation" runat="server" />
  </div>
  <div id="threeColumnRightContent">
    <asp:PlaceHolder ID="phRightSideWidgets" runat="server"></asp:PlaceHolder>
  </div>  
  <div id="threeColumnMainContent">
    <table class="defaultTable">
      <tr>
        <td>
          <asp:Menu ID="categoryCrumbs" runat="server" SkinID="breadcrumbs" DataSourceID="xmlDataSource" Orientation="Horizontal" StaticDisplayLevels="1" RenderingMode="Table">
            <DataBindings>
              <asp:MenuItemBinding DataMember="MenuItem" NavigateUrlField="NavigateUrl" TextField="Text" ValueField="Value" ToolTipField="ToolTip" />
            </DataBindings>
          </asp:Menu>
          <asp:XmlDataSource ID="xmlDataSource" TransformFile="~/transforms/catalogNavigation.xslt" XPath="MenuItems/MenuItem" runat="server" />
        </td>
        <td>
          <dashCommerce:HyperLink ID="hlCategory" runat="server" SkinId="noCategoryImage"/>
        </td>
      </tr>
    </table>
    <dashCommerce:Pager ID="topPager" runat="server" />
    <dashCommerce:CatalogList ID="catalogList" runat="server" />
    <dashCommerce:Pager ID="bottomPager" runat="server" />
  </div>
</asp:Content>