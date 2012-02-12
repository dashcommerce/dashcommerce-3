<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="database.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.install.controls.database" %>


<dashCommerce:Panel ID="pnlDatabaseSetup" runat="server">
 <dashCommerce:Label ID="lblDatabaseInstructions" runat="server" CssClass="label" />
 <dashCommerce:CheckBox ID="chkUseConnectionStringConfig" runat="server" OnCheckedChanged="chkUseConnectionStringConfig_Changed" AutoPostBack="true" Font-Bold="true" /><br /><br />
 <dashCommerce:Panel ID="pnlDatabaseSettings" runat="server">
   <dashCommerce:Label ID="lblDatabaseServer" runat="server" CssClass="label" /><br />
   <asp:TextBox ID="txtDatabaseServer" runat="server" CssClass="longtextbox" TabIndex="1" />&nbsp;<dashCommerce:HelpLink ID="helpDatabaseServer" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
   <dashCommerce:Label ID="lblNewOrExistingDatabase" runat="server" /><br />
   <asp:RadioButtonList ID="rdoNewOrExistingDatabase" runat="server" TabIndex="2" RepeatDirection="Vertical" SkinID="smallradiobuttonlist">
    <asp:ListItem Text="Create a New Database" />
    <asp:ListItem Text="Use an Existing Database" />
   </asp:RadioButtonList><br />
   <dashCommerce:Label ID="lblDatabaseName" runat="server" CssClass="label" /><br />
   <asp:TextBox ID="txtDatabaseName" runat="server" CssClass="textbox" TabIndex="3" />&nbsp;<dashCommerce:HelpLink ID="helpDatabaseName" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
   <dashCommerce:RequiredFieldValidator ID="rfvDatabaseServer" runat="server" ControlToValidate="txtDatabaseServer" Display="None" />
   <dashCommerce:RequiredFieldValidator ID="rfvDatabaseName" runat="server" ControlToValidate="txtDatabaseName" Display="None" />
   <dashCommerce:RequiredFieldValidator ID="rfvNewOrExistingDatabase" runat="server" ControlToValidate="rdoNewOrExistingDatabase" Display="None" /> 
   <dashCommerce:CheckBox ID="chkWindowsAuth" runat="server" CssClass="label" OnCheckedChanged="chkWindowsAuth_CheckedChanged" AutoPostBack="true" /><br /><br />
   <dashCommerce:Label ID="lblDatabaseUserName" runat="server" CssClass="label" /><br />
   <asp:TextBox ID="txtDatabaseUserName" runat="server" CssClass="textbox" TabIndex="4" />&nbsp;<dashCommerce:HelpLink ID="helpDatabaseUserName" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
   <dashCommerce:Label ID="lblDatabasePassword" runat="server" CssClass="label" /><br />
   <asp:TextBox ID="txtDatabasePassword" runat="server" CssClass="textbox" TabIndex="5"/>&nbsp;<dashCommerce:HelpLink ID="helpDatabasePassword" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
   <dashCommerce:RequiredFieldValidator ID="rfvDatabaseUserName" runat="server" ControlToValidate="txtDatabaseUserName" Display="None" />
   <dashCommerce:RequiredFieldValidator ID="rfvDatabasePassword" runat="server" ControlToValidate="txtDatabasePassword" Display="None" />
 </dashCommerce:Panel>
 <dashCommerce:Label ID="lblLanguagePack" runat="server" CssClass="label" /><br /><br />
 <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="dropdownlist" TabIndex="6" /><br /><br />
 <div class="rightAlign">
   <dashCommerce:Button ID="btnPrevious" runat="server" CssClass="button" OnClick="btnPrevious_Click" CausesValidation="false"/>&nbsp;&nbsp;&nbsp;&nbsp;
   <dashCommerce:Button ID="btnNext" runat="server" CssClass="button" OnClick="btnNext_Click" CausesValidation="true" />
 </div>
</dashCommerce:Panel>