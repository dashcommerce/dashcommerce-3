
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="welcome.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.install.controls.welcome" %>

<dashCommerce:Panel ID="pnlWelcome" runat="server">
 <dashCommerce:Label ID="lblWelcomeInstructions" runat="server" CssClass="label" />
 <div class="rightAlign">
   <dashCommerce:Button ID="btnNext" runat="server" CssClass="button" OnClick="btnNext_Click"/>
 </div>
</dashCommerce:Panel>