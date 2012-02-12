<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="attributeedit.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.attributeedit" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/admin/admin.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="mainContentRegion">
    <div id="admin_centercontent">
      <div class="sectionHeader"><dashCommerce:Label ID="lblAttributeAdministration" runat="server" /></div><br />
        <table id="categoryTable">
          <tr>
            <td>
              <dashCommerce:Panel ID="pnlCurrentAttributes" runat="server" Visible="false">
                <dashCommerce:DataGrid ID="dgAttributes" runat="server" AutoGenerateColumns="false" SkinID="adminDataGridNoPage">
                  <Columns>
                    <asp:TemplateColumn>
                      <ItemTemplate>
                        <dashCommerce:LinkButton ID="lbEdit" runat="server" CommandArgument='<%# Eval("AttributeId") %>' OnCommand="lbEdit_Click" />
                      </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="Name" />
                    <asp:BoundColumn DataField="AttributeType" />
                  </Columns>
                </dashCommerce:DataGrid>
              </dashCommerce:Panel>        
            </td>
            <td>
              <dashCommerce:Panel ID="pnlEditAttribute" runat="server">
                <dashCommerce:Label ID="lblAttributeId" runat="server" Visible="false" />
                <dashCommerce:Label ID="lblName" runat="server" CssClass="label" /><br />
                <asp:TextBox ID="txtName" runat="server" CssClass="textbox"/><br /><br />
                <dashCommerce:Label ID="lblAttributeType" runat="server" CssClass="label" /><br />
                <asp:DropDownList ID="ddlAttributeType" runat="server" CssClass="dropdownlist" /><br /><br />
                <dashCommerce:Label ID="lblLabel" runat="server" CssClass="label"></dashCommerce:Label><br />
                <asp:TextBox ID="txtLabel" runat="server" CssClass="longtextbox" /><br /><br />
                <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;<dashCommerce:Button ID="btnReset" runat="server" OnClick="btnReset_Click" CssClass="button" /><br /><br />               
                <dashCommerce:Panel ID="pnlAttributeItems" runat="server" Visible="false">
                  <dashCommerce:Label ID="lblAttributeItemId" runat="server" Visible="false" />
                  <dashCommerce:Label ID="lblAttributeItemName" runat="server" CssClass="label"/><br />
                  <asp:TextBox ID="txtAttributeItemName" runat="server" CssClass="textbox"/><br /><br />
                  <dashCommerce:Label ID="lblAdjustment" runat="server" CssClass="label"/><br />
                  <dashCommerce:Label ID="lblAdjustmentCurrencySymbol" runat="server" CssClass="label"/>&nbsp;<asp:TextBox ID="txtAdjustment" runat="server" CssClass="textbox"/><br /><br />
                  <dashCommerce:Label ID="lblSkuSuffix" runat="server" CssClass="label" /><br />
                  <asp:TextBox ID="txtSkuSuffix" runat="server" CssClass="textbox"/><br /><br />
                  <dashCommerce:Button ID="btnAdd" runat="server" CssClass="button" OnClick="btnAdd_Click"/><br /><br />
                  <dashCommerce:DataGrid ID="dgAttributeItems" runat="server" AutoGenerateColumns="false" SkinID="adminDataGridNoPage">
                    <Columns>
                      <asp:TemplateColumn>
                        <ItemTemplate>
                          <dashCommerce:LinkButton ID="lbAttrbuteItemEdit" runat="server" CommandArgument='<%# Eval("AttributeItemId") %>' OnCommand="lbAttributeItemEdit" />
                        </ItemTemplate>
                      </asp:TemplateColumn>
	                    <asp:TemplateColumn>
                        <ItemTemplate>
                          <asp:ImageButton ID="lbUp" runat="server" CausesValidation="false" CommandName="Up" CommandArgument='<%# Eval("AttributeItemId") %>' OnClick="Items_ItemReorder" SkinID="up" /> 
                          <asp:ImageButton ID="lbDown" runat="server" CausesValidation="false" CommandName="Down" CommandArgument='<%# Eval("AttributeItemId") %>' OnClick="Items_ItemReorder" SkinID="down" />
                        </ItemTemplate>
                      </asp:TemplateColumn>
                      <asp:BoundColumn DataField="Name" />
                      <asp:BoundColumn DataField="Adjustment" />
                      <asp:BoundColumn DataField="SkuSuffix" />
                      <asp:TemplateColumn>
                        <ItemTemplate>
                          <dashCommerce:LinkButton ID="lbAttrbuteItemDelete" runat="server" CommandArgument='<%# Eval("AttributeItemId") %>' OnCommand="lbAttributeItemDelete" />
                        </ItemTemplate>
                      </asp:TemplateColumn>
                    </Columns>
                  </dashCommerce:DataGrid>
                </dashCommerce:Panel>
              </dashCommerce:Panel>
            </td>
          </tr>
        </table>
    </div>
  </div>
</asp:Content>
