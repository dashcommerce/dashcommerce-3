<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="notifications.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.notifications" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/admin/admin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="mainContentRegion">
    <div id="admin_centercontent">
      <div class="sectionHeader"><dashCommerce:Label ID="lblNotificationList" runat="server" /></div><br />
      <dashCommerce:Panel ID="pnlGrid" runat="server">
        <dashCommerce:DataGrid ID="dgNotifications" runat="server" AutoGenerateColumns="false" SkinID="adminDataGrid">
          <Columns>
            <asp:TemplateColumn>
              <ItemTemplate>
                <dashCommerce:HyperLink ID="hlEditLink" runat="server" NavigateUrl='<%# FormatEditUrl(Eval("NotificationId").ToString()) %>' />
              </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="Name" />
            <asp:BoundColumn DataField="IsSystemNotification" />
          </Columns>
        </dashCommerce:DataGrid>
      </dashCommerce:Panel>
    </div>
  </div>
</asp:Content>
