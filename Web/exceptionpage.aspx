<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="exceptionpage.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.exceptionpage" Title="Untitled Page" %>

<%@ Register TagPrefix="dashCommerce" TagName="Navigation" Src="~/controls/navigation/storenavigation.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="threeColumnLeftContent">
    <dashCommerce:Navigation ID="leftNavigation" runat="server" />
  </div>
  <div id="threeColumnRightContent">
  </div>
  <div id="threeColumnMainContent">
    <div class="verticalalign">
      <asp:Image ID="imgCriticalError" runat="server" SkinID="critical" />&nbsp;<dashCommerce:Label ID="lblErrorMessage" runat="server" CssClass="label" />
    </div>
  </div>
</asp:Content>
