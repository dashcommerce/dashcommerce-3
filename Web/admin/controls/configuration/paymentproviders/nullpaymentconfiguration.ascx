<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="nullpaymentconfiguration.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.configuration.paymentproviders.nullpaymentconfiguration" %>



<dashCommerce:Panel ID="pnlSettings" runat="server">
  <br />
  <dashCommerce:Panel ID="pnlDescriptionTitle" runat="server" CssClass="accordionHeaderGray">
    <div class="cpeTitle">
      <dashCommerce:Label ID="lblDescriptionTitle" runat="server" />
    </div>
    <div class="cpeImage">
      <asp:Image ID="imgToggle" runat="server" />
    </div>
  </dashCommerce:Panel>
  <dashCommerce:Panel ID="pnlDescription" runat="server" Width="97%">
    <br />
    <asp:Literal ID="ltDescription" runat="server" />
  </dashCommerce:Panel>
  <asp:CollapsiblePanelExtender ID="cpeDescription" runat="server"  TargetControlID="pnlDescription" ExpandControlID="pnlDescriptionTitle" CollapseControlID="pnlDescriptionTitle" ImageControlID="imgToggle" ExpandDirection="Vertical" Collapsed="true" SkinID="withImage"  />
  <br />
  <dashCommerce:Button ID="btnSave" runat="server" OnClick="btnSave_Click" />
</dashCommerce:Panel>
