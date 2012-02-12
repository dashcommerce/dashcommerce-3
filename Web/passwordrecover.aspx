<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="passwordrecover.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.passwordrecover" Title="Untitled Page" EnableViewState="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="mainContentRegion">
  <div id="centercontent">
      <asp:PasswordRecovery ID="prPasswordRecover" 
                            runat="server" 
                            CssClass="login" 
                            TitleTextStyle-CssClass="sectionHeader" SubmitButtonStyle-CssClass="button" OnSendingMail="prPasswordRecover_SendingMail">
        <FailureTextStyle CssClass="errorbox" />
        <InstructionTextStyle CssClass="plainbox" />
        <LabelStyle CssClass="checkoutlabel" />
      </asp:PasswordRecovery>
  </div>
</div>

</asp:Content>
