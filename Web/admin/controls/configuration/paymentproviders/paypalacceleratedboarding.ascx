<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="paypalacceleratedboarding.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.configuration.paymentproviders.paypalacceleratedboarding" %>

<asp:UpdateProgress ID="upDisplay" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="up" DisplayAfter="100" />
<br />
<dashCommerce:Panel ID="pnlPayPalAcceleratedBoarding" runat="server">
  <dashCommerce:CheckBox ID="chkPayPalAcceleratedBoarding" runat="server" Font-Bold="true" Checked="true" Enabled="false" />
  <br />
  <br />
  <dashCommerce:Label ID="lblPayPalAcceleratedInstructions" runat="server" />
  <br />
  <br />
  <dashCommerce:Label ID="lblPayPaAcceleratedNote" runat="server" />
  <br />
  <br />
  <dashCommerce:HyperLink ID="hlPayPalAcceleratedDemo" runat="server" NavigateUrl="" />&nbsp;&nbsp;<dashCommerce:HyperLink ID="hlPayPalAcceleratedSetup" runat="server" NavigateUrl="" />
  <br />
  <br />
  <asp:UpdatePanel ID="up" runat="server" UpdateMode="Always" >
    <ContentTemplate>
      <dashCommerce:Panel ID="pnlPayPalAcceleratedBoardingSetup" runat="server">
        <dashCommerce:RadioButton ID="rbProductionMode" runat="server" GroupName="Mode" AutoPostBack="true" OnCheckedChanged="ModeChecked_Changed"/><br />
        <dashCommerce:RadioButton ID="rbSandboxMode" runat="server" GroupName="Mode" AutoPostBack="true" OnCheckedChanged="ModeChecked_Changed"/>
        <br />
        <br />
        <dashCommerce:RadioButton ID="rbEmailAddress" runat="server" GroupName="Api" AutoPostBack="true" OnCheckedChanged="ApiChecked_Changed"/>&nbsp;&nbsp;<asp:TextBox ID="txtEmailAddress" runat="server" /><dashCommerce:RequiredFieldValidator ID="rfvEmailAddress" runat="server" Display="None" ControlToValidate="txtEmailAddress" ValidationGroup="accleratedBoarding"/><br />
        <dashCommerce:RadioButton ID="rbAPICredentials" runat="server" GroupName="Api" AutoPostBack="true" OnCheckedChanged="ApiChecked_Changed"/>
        <br />
        <br />
        <dashCommerce:Panel ID="pnlPayPalApiCredentials" runat="server" Enabled="false">
          <dashCommerce:Label ID="lblApiUserName" runat="server" CssClass="label" /><br />
          <asp:TextBox ID="txtApiUserName" runat="server" CssClass="longtextbox" />&nbsp;<dashCommerce:HelpLink ID="helpApiUserName" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
          <dashCommerce:Label ID="lblApiPassword" runat="server" CssClass="label" /><br />
          <asp:TextBox ID="txtApiPassword" runat="server" CssClass="textbox" />&nbsp;<dashCommerce:HelpLink ID="helpApiPassword" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
          <dashCommerce:Label ID="lblSignature" runat="server" CssClass="label" /><br />
          <asp:TextBox ID="txtSignature" runat="server" CssClass="textbox" Width="500px" />&nbsp;<dashCommerce:HelpLink ID="helpApiSignature" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
          <dashCommerce:RequiredFieldValidator ID="rfvApiUserName" runat="server" Display="None" ControlToValidate="txtApiUserName" Enabled="false" ValidationGroup="accleratedBoarding"/>
          <dashCommerce:RequiredFieldValidator ID="rfvApiPassword" runat="server" Display="None" ControlToValidate="txtApiPassword" Enabled="false" ValidationGroup="accleratedBoarding"/>
          <dashCommerce:RequiredFieldValidator ID="rfvApiSignature" runat="server" Display="None" ControlToValidate="txtSignature" Enabled="false" ValidationGroup="accleratedBoarding"/>
        </dashCommerce:Panel>
      </dashCommerce:Panel>
    </ContentTemplate>
  </asp:UpdatePanel>
  <br />
  <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" ValidationGroup="accleratedBoarding" />
</dashCommerce:Panel>