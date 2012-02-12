<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="rolelist.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.rolelist" Title="" %>
<%@ MasterType VirtualPath="~/admin/admin.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="mainContentRegion">
    <div id="admin_centercontent">
      <div class="sectionHeader"><dashCommerce:Label ID="lblRoleAdministration" runat="server" /></div><br />
      <dashCommerce:Panel ID="pnlRoleList" runat="server">
        <dashCommerce:DataGrid ID="dgRoles" runat="server" AutoGenerateColumns="false" SkinID="adminDataGrid">
          <Columns>
            <asp:TemplateColumn>
              <ItemTemplate>
                <dashCommerce:LinkButton ID="lbDelete" runat="server" CommandName="mydelete" CommandArgument='<%# Container.DataItem %>' OnCommand="lbDelete_Click" />
              </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn>
              <ItemTemplate>
                <%# Container.DataItem %>
              </ItemTemplate>
            </asp:TemplateColumn>
          </Columns>
        </dashCommerce:DataGrid>
      </dashCommerce:Panel>
      <br />
      <dashCommerce:Panel ID="pnlAddRole" runat="server">
        <dashCommerce:Label ID="lblRoleName" runat="server" CssClass="label"/><br />
        <asp:TextBox ID="txtRoleName" runat="server" CssClass="textbox" /><br /><br />
        <dashCommerce:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="button" />
      </dashCommerce:Panel>
    </div>
  </div>
</asp:Content>
