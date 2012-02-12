<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="license.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.install.controls.license" %>

<dashCommerce:Panel ID="pnlLicenseAgreement" runat="server">
 <dashCommerce:Label ID="lblLicenseAgreementInstructions" runat="server" /><br /><br />
  <asp:TextBox ID="txtLicenseAgreement" runat="server" TextMode="MultiLine" Width="98%" Height="250px" ReadOnly="true" />
  <br />
  <br />
  <dashCommerce:CheckBox ID="chkAgreeToLicense" runat="server" OnCheckedChanged="chkAgreeToLicense_Changed" AutoPostBack="true" Font-Bold="true" />
  <br />
  <br />
  <div class="rightAlign">
   <dashCommerce:Button ID="btnPrevious" runat="server" OnClick="btnPrevious_Click" CausesValidation="false"/>&nbsp;&nbsp;&nbsp;&nbsp;
   <dashCommerce:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Enabled="false" />
  </div>
</dashCommerce:Panel>