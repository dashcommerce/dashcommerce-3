<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="trackinglogs.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.trackinglogs" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/admin/admin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="mainContentRegion">
  <div id="admin_centercontent">
    <div class="sectionHeader"><dashCommerce:Label ID="lblBrowsingLogListing" runat="server" /></div><br />
    <dashCommerce:Label ID="lblCategoryListing" runat="server" CssClass="label" />
    <dashCommerce:Panel ID="pnlCategoryBrowsingLogs" runat="server" CssClass="scrollDiv">
      <dashCommerce:DataGrid ID="dgCategory" runat="server" AutoGenerateColumns="false" SkinID="adminDataGridNoPage">
        <Columns>
          <asp:BoundColumn DataField="Hits" ItemStyle-Width="20%"  />
          <asp:BoundColumn DataField="Name" />
        </Columns>
      </dashCommerce:DataGrid>
    </dashCommerce:Panel>
    <br /><br />
    <dashCommerce:Label ID="lblProductListing" runat="server" CssClass="label" />
    <dashCommerce:Panel ID="pnlProductBrowsingLogs" runat="server" CssClass="scrollDiv">
      <dashCommerce:DataGrid ID="dgProducts" runat="server" AutoGenerateColumns="false" SkinID="adminDataGridNoPage">
        <Columns>
          <asp:BoundColumn DataField="Hits" ItemStyle-Width="20%" />
          <asp:BoundColumn DataField="Name" />
        </Columns>
      </dashCommerce:DataGrid>
    </dashCommerce:Panel>
  </div>
</div>
</asp:Content>