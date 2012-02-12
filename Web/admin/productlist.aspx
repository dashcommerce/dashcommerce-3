<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="productlist.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.productlist" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/admin/admin.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="mainContentRegion">
    <div id="admin_centercontent">
      <div class="sectionHeader"><dashCommerce:Label ID="lblProductList" runat="server" /></div><br />
      <dashCommerce:Panel ID="pnlProductSearch" runat="server">
        <dashCommerce:Label ID="lblCategory" runat="server" CssClass="label" /><br />
        <asp:DropDownList ID="ddlParentCategory" runat="server" CssClass="fwdropdownlist" /><br /><br />
        <dashCommerce:Button ID="btnSearch" runat="server" CssClass="button" OnClick="btnSearch_Click" />
      </dashCommerce:Panel>
      <br />
      <dashCommerce:Panel ID="pnlProductList" runat="server">
        <dashCommerce:Label ID="lblTotalProducts" runat="server" CssClass="label"/>&nbsp;<dashCommerce:Label ID="lblNumberOfTotalProducts" runat="server" CssClass="label"/>&nbsp;&nbsp;<dashCommerce:HelpLink ID="helpAddProduct" runat="server" NavigateUrl="~/admin/productedit.aspx?view=g&productId=-1" SkinId="addnew" /><br /><br />
        <dashCommerce:DataGrid ID="dgProducts" runat="server" AutoGenerateColumns="false" SkinID="adminDataGrid" OnPageIndexChanged="dgProduct_PageIndexChanging">
          <Columns>
            <asp:TemplateColumn>
              <ItemTemplate>
                <dashCommerce:HyperLink ID="hlEditLink" runat="server" NavigateUrl='<%# FormatEditUrl(DataBinder.Eval(Container.DataItem, "ProductId").ToString()) %>' />
              </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="BaseSku" />
            <asp:BoundColumn DataField="Name" />
            <asp:BoundColumn DataField="IsEnabled" />
            <asp:BoundColumn DataField="IsDeleted" />
          </Columns>
        </dashCommerce:DataGrid>
      </dashCommerce:Panel>
    </div>
  </div>
</asp:Content>