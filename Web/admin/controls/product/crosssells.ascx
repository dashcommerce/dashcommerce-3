<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="crosssells.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.product.crosssells" %>


<dashCommerce:Panel ID="pnlCrossSells" runat="server">
  <dashCommerce:DataGrid ID="dgCrossSells" runat="server" AutoGenerateColumns="false" SkinId="adminDataGrid" DataKeyField="ProductId" OnPageIndexChanged="dgCrossSells_PageIndexChanging">
    <HeaderStyle CssClass="adminTableHeader" />
    <Columns>
      <asp:TemplateColumn>
        <ItemTemplate>
          <dashCommerce:CheckBox ID="chkCrossSell" runat="server" OnCheckedChanged="crossSell_Clicked" AutoPostBack="true" />
        </ItemTemplate>
      </asp:TemplateColumn>
      <asp:BoundColumn DataField="Name" />
    </Columns>
    <PagerStyle Mode="NumericPages" />
  </dashCommerce:DataGrid>
</dashCommerce:Panel>