<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="orders.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.orders" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/admin/admin.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="mainContentRegion">
    <div id="admin_centercontent">
      <div class="sectionHeader"><dashCommerce:Label ID="lblOrderList" runat="server" /></div><br />
      <dashCommerce:Panel ID="pnlOrderSearch" runat="server">
        <br />
        <dashCommerce:Label ID="lblOrderNumber" runat="server" CssClass="label" /><br />
        <asp:TextBox ID="txtOrderNumber" runat="server" CssClass="textbox" /><br /><br />
        <dashCommerce:Button ID="btnSearch" runat="server" CssClass="button" OnClick="btnSearch_Click"/>
      </dashCommerce:Panel>
      <br />
      <dashCommerce:Panel ID="pnlOrderList" runat="server">
        <br />
        <dashCommerce:DataGrid ID="dgOrders" runat="server" AutoGenerateColumns="false" SkinID="adminDataGrid" OnPageIndexChanged="dgOrders_PageIndexChanging">
          <Columns>
            <asp:TemplateColumn>
              <ItemTemplate>
                <dashCommerce:HyperLink ID="hlEditLink" runat="server" NavigateUrl='<%# FormatEditUrl(Eval("OrderId").ToString()) %>' />
              </ItemTemplate>            
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="OrderNumber" />
            <asp:TemplateColumn>
              <ItemTemplate>
                <%# (Eval("OrderStatusDescriptor.Name")) %>
              </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn ItemStyle-HorizontalAlign="Right">
              <ItemTemplate>
                <%# GetFormattedAmount(Eval("Total").ToString()) %>
              </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="ModifiedOn" ItemStyle-HorizontalAlign="Right" />
          </Columns>
        </dashCommerce:DataGrid>
      </dashCommerce:Panel>
    </div>
  </div>
</asp:Content>
