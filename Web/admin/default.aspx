<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin._default" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/admin/admin.master" %>
<%@ Register TagPrefix="dashCommerce" TagName="News" Src="~/admin/controls/rsslist.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" height="550px" border="0">
  <tr>
    <td valign="top" width="75%">
      <dashCommerce:Panel ID="pnlPendingOrders" runat="server">
        <br />
        <dashCommerce:DataGrid ID="dgOrders" runat="server" AutoGenerateColumns="false" SkinID="adminDataGridNoPageSmall">
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
    </td>
    <td valign="top">
      <dashCommerce:Panel ID="pnlNews" runat="server">
        <dashCommerce:News ID="news" runat="server" />
      </dashCommerce:Panel>    
    </td>
  </tr>
  <tr>
    <td valign="top" width="75%">
      <dashCommerce:Panel ID="pnlToDo" runat="server">
        <br />
        <asp:UpdateProgress ID="upDisplay" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="up" DisplayAfter="100" />
        <asp:UpdatePanel ID="up" runat="server" RenderMode="Inline"><ContentTemplate>
          <div class="verticalalign">
            <asp:TextBox ID="txtToDo" runat="server" CssClass="longtextbox" />&nbsp;&nbsp;<dashCommerce:Button ID="btnAdd" runat="server" CssClass="button" OnClick="btnAdd_Click" />
          </div>
          <br />
          <dashCommerce:DataGrid ID="dgToDo" runat="server" AutoGenerateColumns="false" SkinID="adminDataGridNoPage">
            <Columns>
              <asp:BoundColumn DataField="ToDoX" />
              <asp:TemplateColumn>
                <ItemTemplate>
                  <dashCommerce:LinkButton ID="lbDelete" runat="server" CommandArgument='<%# Eval("ToDoId") %>' OnCommand="lbDelete_Click" />
                </ItemTemplate>
              </asp:TemplateColumn>
            </Columns>
          </dashCommerce:DataGrid>
        </ContentTemplate></asp:UpdatePanel>
      </dashCommerce:Panel>    
    </td>
    <td valign="top">
      <dashCommerce:Panel ID="pnlQuickStats" runat="server">
        <br />
        <dashCommerce:Panel ID="pnlSearchTerms" runat="server" Visible="false">
          <dashCommerce:Label ID="lblSearchTerms" runat="server" CssClass="label" />
          <dashCommerce:DataGrid ID="dgSearchTerms" runat="server" AutoGenerateColumns="false" SkinID="adminDataGridNoPage">
            <Columns>
              <asp:BoundColumn  DataField="SearchTerms"/>
              <asp:BoundColumn DataField="ViewCount"/>
            </Columns>
          </dashCommerce:DataGrid>
        </dashCommerce:Panel>
      </dashCommerce:Panel>    
    </td>
  </tr>
  <tr height="33%">
    <td colspan="4">
      <br />
    </td>
  </tr>
</table>
</asp:Content>