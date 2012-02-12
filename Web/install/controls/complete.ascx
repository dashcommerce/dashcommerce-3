<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="complete.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.install.controls.complete" %>

<dashCommerce:Panel ID="pnlComplete" runat="server">
 <dashCommerce:Label ID="lblCompleteInstructions" runat="server" CssClass="label" />
 <br />
 <br />
 <div class="rightAlign">
   <dashCommerce:Button ID="btnNext" runat="server" CssClass="button" OnClick="btnNext_Click"/>
 </div>
 </dashCommerce:Panel>