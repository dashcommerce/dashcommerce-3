<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.register" Title="Untitled Page" EnableViewState="false" %>
<%@ MasterType VirtualPath="~/site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div id="mainContentRegion">
    <div id="centercontent">
    <asp:CreateUserWizard ID="cuwRegister" 
                          runat="server" 
                          CssClass="login" 
                          ContinueDestinationPageUrl="~/default.aspx" 
                          CancelDestinationPageUrl="~/default.aspx" 
                          TitleTextStyle-CssClass="sectionHeader" 
                          CancelButtonStyle-CssClass="button" 
                          ContinueButtonStyle-CssClass="button" 
                          FinishCompleteButtonStyle-CssClass="button" 
                          CreateUserButtonStyle-CssClass="button" 
                          OnCreatedUser="CreatedUser"
                          />
    <dashCommerce:Label ID="lblBeforeRegisterUserName" runat="server" Visible="false" />
  </div>
</div>
</asp:Content>
