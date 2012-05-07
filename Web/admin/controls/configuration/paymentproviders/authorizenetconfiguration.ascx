<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="authorizenetconfiguration.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.configuration.paymentproviders.authorizenetconfiguration" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Panel ID="pnlSettings" runat="server">
  <br />
  <asp:Panel ID="pnlDescriptionTitle" runat="server" CssClass="accordionHeaderGray">
    <div class="cpeTitle">
      <asp:Label ID="lblDescriptionTitle" runat="server" />
    </div>
    <div class="cpeImage">
      <asp:Image ID="imgToggle" runat="server" />
    </div>
  </asp:Panel>
  <asp:Panel ID="pnlDescription" runat="server">
    <br />
    <asp:Literal ID="ltDescription" runat="server" />
  </asp:Panel>
  <asp:CollapsiblePanelExtender ID="cpeDescription" runat="server"  TargetControlID="pnlDescription" ExpandControlID="pnlDescriptionTitle" CollapseControlID="pnlDescriptionTitle" ImageControlID="imgToggle" ExpandDirection="Vertical" Collapsed="true" SkinID="withImage"  />
  <br />
  <asp:Label ID="lblApiUserName" runat="server" CssClass="label" /><br />
  <asp:TextBox ID="txtApiUserName" runat="server" CssClass="textbox" />&nbsp;<asp:HyperLink ID="hlApiUserNameHelp" runat="server" NavigateUrl="javascript:void(0);"><asp:Image ID="imgApiUserNameHelp" runat="server" SkinID="help" /></asp:HyperLink><br /><br />
  <asp:Label ID="lblApiTransactionKey" runat="server" CssClass="label" /><br />
  <asp:TextBox ID="txtApiTransactionKey" runat="server" CssClass="textbox" />&nbsp;<asp:HyperLink ID="hlApiTransactionKeyHelp" runat="server" NavigateUrl="javascript:void(0);"><asp:Image ID="Image1" runat="server" SkinID="help" /></asp:HyperLink><br /><br />
  <asp:Label ID="lblIsInTestMode" runat="server" CssClass="label" /><br />
  <asp:CheckBox ID="chkIsInTestMode" runat="server" />&nbsp;<asp:HyperLink ID="hlIsInTestModeHelp" runat="server" NavigateUrl="javascript:void(0);"><asp:Image ID="Image2" runat="server" SkinID="help" /></asp:HyperLink><br /><br />
  <asp:Label ID="lblIsLive" runat="server" CssClass="label" /><br />
  <asp:CheckBox ID="chkIsLive" runat="server" />&nbsp;<asp:HyperLink ID="hlIsLiveHelp" runat="server" NavigateUrl="javascript:void(0);"><asp:Image ID="Image3" runat="server" SkinID="help" /></asp:HyperLink><br /><br />
  <asp:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" />
  <asp:RequiredFieldValidator ID="rfvApiUserName" runat="server" Display="None" ControlToValidate="txtApiUserName" ErrorMessage="Please provide an API UserName."/>
  <asp:RequiredFieldValidator ID="rfvApiTransactionKey" runat="server" Display="None" ControlToValidate="txtApiTransactionKey" ErrorMessage="Please provide an API Transaction Key."/>
</asp:Panel>
