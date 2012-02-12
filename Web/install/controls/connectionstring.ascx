<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="connectionstring.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.install.controls.connectionstring" %>

<dashCommerce:Panel ID="pnlConnectionStringSetup" runat="server">
 <dashCommerce:Label ID="lblConnectionStringInstructions" runat="server" CssClass="label" />
 <span style="font-family: Courier New;color: red;">
  <dashCommerce:Label ID="lblConnectionString" runat="server" />
 </span>
 <br />
 <br />
 <div class="rightAlign">
   <dashCommerce:Button ID="btnPrevious" runat="server" CssClass="button" OnClick="btnPrevious_Click" CausesValidation="false"/>&nbsp;&nbsp;&nbsp;&nbsp;<dashCommerce:Button ID="btnNext" runat="server" CssClass="button" OnClick="btnNext_Click"/>
 </div>
</dashCommerce:Panel>