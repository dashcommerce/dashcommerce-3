<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" Codebehind="userlist.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.userlist" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/admin/admin.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="mainContentRegion">
    <div id="admin_centercontent">
      <div class="sectionHeader"><dashCommerce:Label ID="lblUserAdministration" runat="server" /></div><br />
      <dashCommerce:Panel ID="pnlUserSearch" runat="server">
        <dashCommerce:Label ID="lblSearchBy" runat="server" CssClass="label" /><br />
        <asp:DropDownList ID="ddlSearchBy" runat="server" CssClass="dropdownlist" />&nbsp;
        <asp:TextBox ID="txtSearchBy" runat="server" CssClass="textbox" />&nbsp;
        <dashCommerce:Button ID="btnSearch" runat="server" CssClass="button" OnClick="btnSearch_Click" />
      </dashCommerce:Panel>
      <br />
      <dashCommerce:Panel ID="pnlUserList" runat="server">
        <dashCommerce:Label ID="lblTotalUsers" runat="server" CssClass="label"/>&nbsp;<dashCommerce:Label ID="lblNumberOfTotalUsers" runat="server" />&nbsp;&nbsp;<dashCommerce:HyperLink ID="hlAddUser" runat="server" NavigateUrl="~/admin/useredit.aspx" CssClass="submodal-400-500" SkinID="addnew" /><br /><br />
        <dashCommerce:DataGrid ID="dgUserList" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanged="dgUserList_PageIndexChanging" SkinID="adminDataGrid">
          <Columns>
            <asp:TemplateColumn>
              <HeaderStyle HorizontalAlign="center" />
              <ItemStyle HorizontalAlign="center" />
              <ItemTemplate>
                <dashCommerce:CheckBox runat="server" ID="chkActive" OnCheckedChanged="EnabledChanged" 
                              AutoPostBack="true" Checked='<%#DataBinder.Eval(Container.DataItem, "IsApproved")%>' 
                              Value='<%#DataBinder.Eval(Container.DataItem, "UserName")%>' />
              </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn>
              <ItemTemplate>
               <dashCommerce:HyperLink ID="hlUserEdit" runat="server" 
                               NavigateUrl='<%# FormatEditUrl(DataBinder.Eval(Container.DataItem, "UserName").ToString()) %>' 
                               Text='<%# Eval("UserName") %>' SkinId="submodal-640-500"  />
              </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn>
              <ItemTemplate>
                <dashCommerce:HyperLink ID="EmailLink" runat="server" 
                               NavigateUrl='<%# Eval("Email", "mailto:{0}") %>' 
                               Text='<%# Eval("Email") %>' />
              </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="CreationDate" ReadOnly="True" SortExpression="CreationDate" />
            <asp:BoundColumn DataField="LastLoginDate" SortExpression="LastLoginDate" />
            <asp:TemplateColumn>
              <ItemTemplate>
                <dashCommerce:LinkButton runat="server" ID="lbDelete" CommandName="mydelete"
                                CommandArgument='<%#DataBinder.Eval(Container.DataItem, "UserName")%>' 
                                OnCommand="lbDelete_Click" />
              </ItemTemplate>
            </asp:TemplateColumn>
          </Columns>
        </dashCommerce:DataGrid>
        <br />
        <dashCommerce:HyperLink ID="hlShowAll" runat="server" NavigateUrl="~/admin/userlist.aspx"
          SkinID="showAll" Visible="false" />
      </dashCommerce:Panel>
    </div>
  </div>
</asp:Content>
