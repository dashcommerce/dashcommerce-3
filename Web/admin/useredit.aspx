<%@ Page Language="C#" MasterPageFile="~/admin/modal.master" AutoEventWireup="true" CodeBehind="useredit.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.useredit" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/admin/modal.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <dashCommerce:Panel ID="pnlAddUser" runat="server" Visible="false">
    <asp:CreateUserWizard ID="cuwRegister" 
                          runat="server" 
                          CssClass="login" 
                          TitleTextStyle-CssClass="sectionHeader" 
                          Width="100%" 
                          CreateUserButtonStyle-CssClass="button"
                          />  
  </dashCommerce:Panel>
  <dashCommerce:Panel ID="pnlEditUser" runat="server" Visible="false">
    <div class="verticalalign">
      <dashCommerce:Label ID="lblUserName" runat="server" CssClass="label" />&nbsp;<dashCommerce:HelpLink ID="helpUserName" runat="server" NavigateUrl="javascript:void(0);" /><br />
    </div>
    <asp:TextBox ID="txtUserName" runat="server" CssClass="textbox" /><br /><br />
    <div class="verticalalign">
      <dashCommerce:Label ID="lblEmail" runat="server" CssClass="label" />&nbsp;<dashCommerce:HelpLink ID="helpEmail" runat="server" NavigateUrl="javascript:void(0);" /><br />
    </div>
    <asp:TextBox ID="txtEmail" runat="server" CssClass="longtextbox" /><br /><br />
    <div class="verticalalign">
      <dashCommerce:CheckBox ID="chkActive" runat="server" CssClass="label" />&nbsp;<dashCommerce:HelpLink ID="helpActive" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
    </div>
    <dashCommerce:Panel ID="pnlRoles" runat="server">
      <asp:Repeater ID="rptrRoles" runat="server">
        <ItemTemplate>
          <dashCommerce:CheckBox runat="server" id="checkBox1" text='<%# Container.DataItem.ToString()%>' checked='<%# IsUserInRole(Container.DataItem.ToString())%>' CssClass="label"/>
          <br/>
        </ItemTemplate>
      </asp:Repeater>
    </dashCommerce:Panel>
    <br />
    <dashCommerce:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="modalbutton" />
  </dashCommerce:Panel>
</asp:Content>
