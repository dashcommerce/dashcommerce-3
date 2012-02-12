<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="attributes.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.product.attributes" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <table id="attributeTable" runat="server">
      <tr>
        <td width="50%" valign="top">
          <dashCommerce:Panel ID="pnlAvailableAttributes" runat="server">
            <dashCommerce:DataGrid ID="dgAvailableAttributes" runat="server" AutoGenerateColumns="false" SkinID="adminDataGridNoPage">
              <Columns>
                <asp:TemplateColumn>
                  <ItemTemplate>
                    <dashCommerce:LinkButton ID="lbAdd" runat="server" CausesValidation="false" CommandArgument='<%# Eval("AttributeId") %>' OnCommand="lbAdd_Click" />
                  </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="Name" />
              </Columns>
            </dashCommerce:DataGrid>            
          </dashCommerce:Panel>
        </td>
        <td width="50%" valign="top">
          <dashCommerce:Panel ID="pnlAssociatedAttributes" runat="server">
            <dashCommerce:DataGrid ID="dgAssociatedAttributes" runat="server" DataKeyField="AttributeId" AutoGenerateColumns="false" SkinID="adminDataGridNoPage">
              <Columns>
	              <asp:TemplateColumn>
                  <ItemTemplate>
                    <asp:ImageButton ID="lbUp" runat="server" CausesValidation="false" CommandName="Up" CommandArgument='<%# Eval("AttributeId") %>' OnClick="Items_ItemReorder" SkinID="up" /> 
                    <asp:ImageButton ID="lbDown" runat="server" CausesValidation="false" CommandName="Down" CommandArgument='<%# Eval("AttributeId") %>' OnClick="Items_ItemReorder" SkinID="down" />
                  </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="Name" />
                <asp:TemplateColumn>
                  <ItemTemplate>
                    <dashCommerce:CheckBox ID="chkIsRequired" runat="server" Checked='<%# Eval("IsRequired") %>' AutoPostBack="true" OnCheckedChanged="IsRequired_Click" />
                  </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                  <ItemTemplate>
                    <dashCommerce:LinkButton ID="lbDelete" runat="server" CausesValidation="false" CommandArgument='<%# Eval("AttributeId") %>' OnCommand="lbDelete_Click" />
                  </ItemTemplate>
                </asp:TemplateColumn>
              </Columns>
            </dashCommerce:DataGrid>
          </dashCommerce:Panel>
        </td>
      </tr>
    </table>
    <dashCommerce:Panel ID="pnlAttributesLocked" runat="server" Visible="false">
      <br />
      <dashCommerce:DataGrid ID="dgAttributesLocked" runat="server" AutoGenerateColumns="false" SkinID="adminDataGridNoPage">
        <Columns>
          <asp:BoundColumn DataField="SortOrder" />
          <asp:BoundColumn DataField="Name" />
          <asp:TemplateColumn>
            <ItemTemplate>
              <dashCommerce:CheckBox ID="chkIsRequired" runat="server" Checked='<%# Eval("IsRequired") %>' Enabled="false" />
            </ItemTemplate>
          </asp:TemplateColumn>
        </Columns>
      </dashCommerce:DataGrid>
    </dashCommerce:Panel>
  </ContentTemplate>
</asp:UpdatePanel>