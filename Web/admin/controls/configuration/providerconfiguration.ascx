<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="providerconfiguration.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.configuration.providerconfiguration" %>

<div id="mainContentRegion">
  <div id="admin_centercontent">
    <div class="sectionHeader"><dashCommerce:Label ID="lblConfiguration" runat="server" /></div><br />
      <dashCommerce:Panel ID="pnlInstalledProviders" runat="server">
        <br />
        <dashCommerce:Label ID="lblInstalledProviders" runat="server" CssClass="label" /><br />
        <div class="verticalalign">
          <asp:DropDownList ID="ddlProviders" runat="server" />&nbsp;
          <dashCommerce:Button ID="btnSetProvider" runat="server" CssClass="button" OnClick="btnSetProvider_Click" CausesValidation="false" />
        </div>        
      </dashCommerce:Panel><br />
      <asp:Panel ID="pnlConfiguration" runat="server" />
    </div>
  </div>
