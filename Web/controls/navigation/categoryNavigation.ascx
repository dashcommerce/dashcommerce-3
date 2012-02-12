<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="categoryNavigation.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.controls.categoryNavigation" EnableViewState="false" %>
<asp:Menu runat="server" ID="categoryMenu" Orientation="Vertical" StaticDisplayLevels="1" DataSourceID="xmlDataSource" CssClass="categoryMenu" >
  <DynamicMenuStyle CssClass="dynamicMenuStyle" />
  <LevelMenuItemStyles>
    <asp:MenuItemStyle CssClass="categoryLevel1" />
    <asp:MenuItemStyle CssClass="categoryLevel1" />
    <asp:MenuItemStyle CssClass="categoryLevel1" />
    <asp:MenuItemStyle CssClass="categoryLevel1" />
  </LevelMenuItemStyles>
  <DataBindings>
    <asp:MenuItemBinding DataMember="MenuItem" NavigateUrlField="NavigateUrl" TextField="Text" ValueField="Value" ToolTipField="ToolTip" />
  </DataBindings>
</asp:Menu>
<asp:XmlDataSource ID="xmlDataSource" TransformFile="~/transforms/catalogNavigation.xslt" XPath="MenuItems/MenuItem" runat="server" />  
