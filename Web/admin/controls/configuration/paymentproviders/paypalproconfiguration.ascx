<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="paypalproconfiguration.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.configuration.paymentproviders.paypalproconfiguration" %>

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
  <asp:CollapsiblePanelExtender ID="cpeDescription" runat="server"  TargetControlID="pnlDescription" ExpandControlID="pnlDescriptionTitle" CollapseControlID="pnlDescriptionTitle" ImageControlID="imgToggle" ExpandDirection="Vertical" Collapsed="true" SkinID="withImage"  />
  <br />
  <dashCommerce:Label ID="lblApiUserName" runat="server" CssClass="label" /><br />
  <asp:TextBox ID="txtApiUserName" runat="server" CssClass="longtextbox" />&nbsp;<dashCommerce:HelpLink ID="helpApiUserName" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  <dashCommerce:Label ID="lblApiPassword" runat="server" CssClass="label" /><br />
  <asp:TextBox ID="txtApiPassword" runat="server" CssClass="textbox" />&nbsp;<dashCommerce:HelpLink ID="helpApiPassword" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  <dashCommerce:Label ID="lblSignature" runat="server" CssClass="label" /><br />
  <asp:TextBox ID="txtSignature" runat="server" CssClass="textbox" Width="500px" />&nbsp;<dashCommerce:HelpLink ID="helpApiSignature" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  <dashCommerce:Label ID="lblIsLive" runat="server" CssClass="label" /><br />
  <dashCommerce:CheckBox ID="chkIsLive" runat="server" />&nbsp;<dashCommerce:HelpLink ID="helpIsLive" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" />
  <dashCommerce:RequiredFieldValidator ID="rfvApiUserName" runat="server" Display="None" ControlToValidate="txtApiUserName"/>
  <dashCommerce:RequiredFieldValidator ID="rfvApiPassword" runat="server" Display="None" ControlToValidate="txtApiPassword"/>
  <dashCommerce:RequiredFieldValidator ID="rfvApiSignature" runat="server" Display="None" ControlToValidate="txtSignature"/>
</dashCommerce:Panel>
