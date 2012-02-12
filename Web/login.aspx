<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" Codebehind="login.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.login" Title="Untitled Page" EnableViewState="false" %>
<%@ MasterType VirtualPath="~/site.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="mainContentRegion">
    <div id="centercontent">
      <asp:Login ID="llogin" runat="server" 
                 PasswordRecoveryUrl="~/passwordrecover.aspx" 
                 CreateUserUrl="~/register.aspx" 
                 TitleTextStyle-CssClass="sectionHeader" 
                 LoginButtonStyle-CssClass="button" OnLoggedIn="SetCookie" >
        <TitleTextStyle CssClass="sectionHeader" />
      </asp:Login>
    </div>
  </div>
</asp:Content>
