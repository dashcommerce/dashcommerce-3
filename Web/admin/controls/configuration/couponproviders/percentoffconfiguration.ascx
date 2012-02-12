<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="percentoffconfiguration.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.configuration.couponproviders.percentoffconfiguration" %>

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
  <asp:CollapsiblePanelExtender ID="cpeDescription" runat="server"  TargetControlID="pnlDescription" ExpandControlID="pnlDescriptionTitle" CollapseControlID="pnlDescriptionTitle" ImageControlID="imgToggle" ExpandDirection="Vertical" Collapsed="true" SkinID="withImage" />
  <br />
  <dashCommerce:Label ID="lblCouponId" runat="server" Visible="false" />
  <dashCommerce:Label ID="lblCouponCode" runat="server" CssClass="label" /><br />
  <div class="verticalalign">
  <asp:TextBox ID="txtCouponCode" runat="server" CssClass="textbox" />&nbsp;<dashCommerce:Button ID="btnGenerate" runat="server" CssClass="button" OnClick="btnGenerate_Click" />&nbsp;<dashCommerce:HelpLink ID="helpCouponCode" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  </div>
  <dashCommerce:Label ID="lblExpirationDate" runat="server" CssClass="label" /><br />
  <asp:TextBox ID="txtExpirationDate" runat="server" CssClass="textbox" />&nbsp;<dashCommerce:HelpLink ID="helpCouponExpirationDate" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  <dashCommerce:Label ID="lblPercentOff" runat="server" CssClass="label" /><br />
  <asp:TextBox ID="txtPercentOff" runat="server" CssClass="textbox" />&nbsp;<dashCommerce:HelpLink ID="helpCouponPercentOff" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  <dashCommerce:Label ID="lblIsSingleUse" runat="server" CssClass="label" /><br />
  <dashCommerce:CheckBox ID="chkIsSingleUse" runat="server" CssClass="lcheckbox" />&nbsp;<dashCommerce:HelpLink ID="helpCouponIsSingleUse" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" />
</dashCommerce:Panel>