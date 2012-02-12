<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="categories.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.product.categories" %>


<asp:UpdateProgress ID="upDisplay" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="up" DisplayAfter="100" />
<asp:UpdatePanel ID="up" runat="server">
  <ContentTemplate>
    <dashCommerce:Panel ID="pnlProductCategories" runat="server">
        <table id="categoryTable">
          <tr>
            <td>
              <dashCommerce:Panel ID="pnlCurrentCategories" runat="server">
                <asp:TreeView ID="tvCategory" runat="server" DataSourceID="xmlDataSource" ShowLines="true" OnSelectedNodeChanged="Add_Category" ExpandDepth="FullyExpand">
                  <DataBindings>
                    <asp:TreeNodeBinding DataMember="MenuItem" NavigateUrlField="NavigateUrl" TextField="Text" ValueField="Value" ToolTipField="ToolTip" />
                  </DataBindings>
                </asp:TreeView>
                <asp:XmlDataSource ID="xmlDataSource" TransformFile="~/transforms/categoryMenu.xslt" XPath="MenuItems/MenuItem" runat="server" />
              </dashCommerce:Panel>        
            </td>
            <td>
              <dashCommerce:Panel ID="pnlAssociatedCategories" runat="server">
                <dashCommerce:DataGrid ID="dgProductCategories" runat="server" AutoGenerateColumns="false" SkinID="adminDataGrid">
                  <HeaderStyle CssClass="adminTableHeader" />
                  <Columns>
                    <asp:BoundColumn DataField="Name" />
	                  <asp:TemplateColumn>
                      <ItemTemplate>
                        <dashCommerce:LinkButton ID="lbDelete" runat="server" CausesValidation="false" CommandName="myDelete" CommandArgument='<%# Eval("CategoryId") %>' OnCommand="lbDelete_Click" />
                      </ItemTemplate>
                    </asp:TemplateColumn>
                  </Columns>
                </dashCommerce:DataGrid>
              </dashCommerce:Panel>
            </td>
          </tr>
        </table>
    </dashCommerce:Panel>
  </ContentTemplate>  
</asp:UpdatePanel>
