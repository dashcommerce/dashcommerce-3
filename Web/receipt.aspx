<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="receipt.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.receipt" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/site.master" %>
<%@ Register TagPrefix="dashCommerce" TagName="Navigation" Src="~/controls/navigation/storenavigation.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="threeColumnLeftContent">
    <dashCommerce:Navigation ID="leftNavigation" runat="server" />
  </div>
  <div id="threeColumnRightContent">
  </div>
  <div id="threeColumnMainContent">
    <dashCommerce:Label ID="lblReceipt" runat="server" CssClass="label" />
  </div>
</asp:Content>
