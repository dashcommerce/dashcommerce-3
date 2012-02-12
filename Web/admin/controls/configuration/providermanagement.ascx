<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="providermanagement.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.configuration.providermanagement" %>



<div id="mainContentRegion">
  <div id="admin_centercontent">
    <div class="sectionHeader"><dashCommerce:Label ID="lblProviderManagement" runat="server" /></div><br />
    <dashCommerce:Panel ID="pnlProviderList" runat="server">
      <br />
      <dashCommerce:DataGrid ID="dgProviders" runat="server" AutoGenerateColumns="false" DataKeyField="ProviderId" OnDeleteCommand="Delete_Provider" SkinID="adminDataGrid">
        <Columns>
          <asp:HyperLinkColumn DataNavigateUrlField="ProviderId" />
          <asp:BoundColumn DataField="Name" />
          <asp:BoundColumn DataField="ConfigurationControlPath" />
          <asp:ButtonColumn ButtonType="LinkButton" CommandName="Delete" />
        </Columns>
      </dashCommerce:DataGrid>
    </dashCommerce:Panel>
    <br />
    <dashCommerce:Panel ID="pnlSettings" runat="server">
      <br />
      <dashCommerce:Label ID="lblName" runat="server" CssClass="label" /><br />
      <asp:TextBox ID="txtName" runat="server" CssClass="longtextbox" />&nbsp;<dashCommerce:HelpLink ID="helpProviderName" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
      <div class="verticalalign">
        <dashCommerce:Label ID="lblDescription" runat="server" CssClass="label" />&nbsp;<dashCommerce:HelpLink ID="helpProviderDescription" runat="server" NavigateUrl="javascript:void(0);" /><br />
      </div>
      <FCKeditorV2:FCKeditor ID="txtDescription" BasePath="~/FCKeditor/" runat="server" Height="250"
        Width="100%" UseBROnCarriageReturn="true" ToolbarStartExpanded="false" /><br />
      <dashCommerce:Label ID="lblConfigurationControlPath" runat="server" CssClass="label" /><br />
      <asp:TextBox ID="txtConfigurationControlPath" runat="server" CssClass="textbox" Width="300" />&nbsp;<dashCommerce:HelpLink ID="helpProviderConfigurationControlPath" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
      <div class="eventContainer">
        <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" />
      </div>  
    </dashCommerce:Panel>
  </div>
</div>

