<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sku.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.product.sku" %>



<dashCommerce:Panel ID="pnlSkuListing" runat="server">
  <br />
  <dashCommerce:Panel ID="pnlSkuList" runat="server">
    <dashCommerce:Label ID="lblSkuDescription" runat="server" CssClass="label" /><br/><br />
    <dashCommerce:Label ID="lblTotalSkuCountText" runat="server" CssClass="label" />&nbsp;<dashCommerce:Label ID="lblTotalSkuCount" runat="server" CssClass="label" /><br /><br />
    <asp:DataList ID="dlSkus" runat="server" RepeatColumns="3" RepeatDirection="Vertical" CssClass="adminTable">
      <ItemTemplate>
        <%# Container.DataItem.ToString() %>
      </ItemTemplate>
    </asp:DataList>
    <br />
    <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click"/>  
  </dashCommerce:Panel>
  <dashCommerce:Panel ID="pnlSkuInventory" runat="server">
    <dashCommerce:CheckBox ID="chkAllowNegativeInventories" runat="server" />&nbsp;<dashCommerce:HelpLink ID="helpAllowNegativeInventories" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
    <dashCommerce:DataGrid ID="dgSkuInventory" runat="server" AutoGenerateColumns="false" DataKeyField="SkuId" SkinID="adminDataGridNoPage">
      <Columns>
        <asp:BoundColumn DataField="SkuX" />
        <asp:TemplateColumn>
          <ItemTemplate>
            <asp:TextBox ID="txtInventory" runat="server" CssClass="smalltextbox" Text='<%#Eval("Inventory") %>'/>
            <asp:FilteredTextBoxExtender ID="ftbeInventory" runat="server" TargetControlId="txtInventory" FilterType="Numbers" />
          </ItemTemplate>
        </asp:TemplateColumn>
      </Columns>
    </dashCommerce:DataGrid>
    <br />
    <dashCommerce:Button ID="btnSaveInventory" runat="server" CssClass="button" OnClick="btnSaveInventory_Click" />
  </dashCommerce:Panel>
</dashCommerce:Panel>
