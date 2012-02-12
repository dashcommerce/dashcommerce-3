<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="versioncheck.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.install.controls.versioncheck" %>

<dashCommerce:Panel ID="pnlVersionCheckSetup" runat="server">
  <dashCommerce:Label ID="lblVersionCheckInstructions" runat="server" />
  <br />
  <br />
  <div class="verticalalign">
  <dashCommerce:Label ID="lblVersionCheck" runat="server" />&nbsp;&nbsp;<asp:TextBox ID="txtVersionNumber" runat="server" ReadOnly="true" />
  <dashCommerce:Button ID="btnTestVersion" runat="server" OnClick="btnTestVersion_Click" /><br /><br />
  <dashCommerce:CheckBox ID="chkReInstall" runat="server" OnCheckedChanged="chkReInstall_Click" AutoPostBack="true" Visible="false" />
  </div>
  <br /><br />
  <div class="rightAlign">
   <dashCommerce:Button ID="btnPrevious" runat="server" OnClick="btnPrevious_Click" CausesValidation="false"/>&nbsp;&nbsp;&nbsp;&nbsp;
   <dashCommerce:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Enabled="false" />
  </div>
</dashCommerce:Panel>
