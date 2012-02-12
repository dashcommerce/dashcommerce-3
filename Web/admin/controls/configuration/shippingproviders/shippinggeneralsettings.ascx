<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="shippinggeneralsettings.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.configuration.shippingproviders.shippinggeneralsettings" %>


<dashCommerce:Panel ID="pnlGeneralSettings" runat="server">
  <br />
  <dashCommerce:Label ID="lblUseShipping" runat="server" EnableViewState="false" CssClass="label" /><br />
  <dashCommerce:CheckBox ID="chkUseShipping" runat="server" TabIndex="1" CssClass="textbox" />&nbsp;<dashCommerce:HelpLink
    ID="helpUseShipping" runat="server" EnableViewState="false" NavigateUrl="javascript:void(0);" /><br />
  <br />
  <dashCommerce:Label ID="lblShipFromZip" runat="server" EnableViewState="false" CssClass="label" /><br />
  <asp:TextBox ID="txtShipFromZip" runat="server" TabIndex="2" CssClass="textbox" />&nbsp;<dashCommerce:HelpLink
    ID="helpShipFromZip" runat="server" EnableViewState="false" NavigateUrl="javascript:void(0);" /><br />
  <br />
  <dashCommerce:Label ID="lblShipFromCountry" runat="server" EnableViewState="false" CssClass="label" /><br />
  <asp:DropDownList ID="ddlShipFromCountry" runat="server" TabIndex="3" CssClass="dropdownlist" />&nbsp;<dashCommerce:HelpLink
    ID="helpShipFromCountry" runat="server" EnableViewState="false" NavigateUrl="javascript:void(0);" /><br />
  <br />
  <dashCommerce:Label ID="lblShippingBuffer" runat="server" EnableViewState="false" CssClass="label" /><br />
  <dashCommerce:Label ID="lblShippingBufferCurrencySymbol" runat="server" CssClass="label"/>&nbsp;<asp:TextBox ID="txtShippingBuffer" runat="server" TabIndex="4" CssClass="textbox" />&nbsp;<dashCommerce:HelpLink
    ID="helpShippingBuffer" runat="server" EnableViewState="false" NavigateUrl="javascript:void(0);" /><br />
  <br />
  <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" /></dashCommerce:Panel>
