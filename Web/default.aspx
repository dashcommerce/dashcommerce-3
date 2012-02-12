<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="MettleSystems.dashCommerce.Web._default" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/site.master" %>
<%@ Register TagPrefix="dashCommerce" TagName="CategoryNavigation" Src="~/controls/navigation/categoryNavigation.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="leftContent">
    <dashCommerce:CategoryNavigation ID="categoryNavigation" runat="server" />
  </div>
  <div id="mainContent">
    <asp:PlaceHolder ID="contentPlaceHolder" runat="server" />
  </div>
</asp:Content>
