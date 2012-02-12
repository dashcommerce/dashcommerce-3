<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="permissions.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.install.controls.permissions" %>


<dashCommerce:Panel ID="pnlPermissions" runat="server">
  <dashCommerce:Label ID="lblPermissions" runat="server" CssClass="label" />
  <div class="rightAlign">
    <dashCommerce:Button ID="btnPrevious" runat="server" CssClass="button" OnClick="btnPrevious_Click" CausesValidation="false"/>&nbsp;&nbsp;&nbsp;&nbsp;<dashCommerce:Button ID="btnNext" runat="server" CssClass="button" OnClick="btnNext_Click"/>
  </div>  
</dashCommerce:Panel>
