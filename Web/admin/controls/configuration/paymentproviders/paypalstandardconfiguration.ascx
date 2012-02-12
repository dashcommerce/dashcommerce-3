<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="paypalstandardconfiguration.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.configuration.paymentproviders.paypalstandardconfiguration" %>

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
  <dashCommerce:Panel ID="pnlDescription" runat="server">
    <br />
    <asp:Literal ID="ltDescription" runat="server" />
  </dashCommerce:Panel>
  <asp:CollapsiblePanelExtender ID="cpeDescription" runat="server"  TargetControlID="pnlDescription" ExpandControlID="pnlDescriptionTitle" CollapseControlID="pnlDescriptionTitle" ImageControlID="imgToggle" ExpandDirection="Vertical" Collapsed="true" CollapsedImage="~/App_Themes/dashCommerce/images/icons/down.gif" ExpandedImage="~/App_Themes/dashCommerce/images/icons/up.gif" />
  <br />
  <dashCommerce:Label ID="lblBusinessEmail" runat="server" CssClass="label" /><br />
  <asp:TextBox ID="txtBusinessEmail" runat="server" CssClass="longtextbox" />&nbsp;<dashCommerce:HelpLink ID="helpBusinessEmail" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  <dashCommerce:Label ID="lblPdtId" runat="server" CssClass="label" /><br />
  <asp:TextBox ID="txtPdtId" runat="server" CssClass="textbox" Width="500" />&nbsp;<dashCommerce:HelpLink ID="helpPdtId" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  <dashCommerce:Label ID="lblIsLive" runat="server" CssClass="label" /><br />
  <dashCommerce:CheckBox ID="chkIsLive" runat="server" />&nbsp;<dashCommerce:HelpLink ID="helpIsLive" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" />
  <dashCommerce:RequiredFieldValidator ID="rfvBusinessEmail" runat="server" Display="None" ControlToValidate="txtBusinessEmail" />
  <dashCommerce:RequiredFieldValidator ID="rfvPdtId" runat="server" Display="None" ControlToValidate="txtPdtId" />
</dashCommerce:Panel>