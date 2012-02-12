<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="coupons.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.coupons" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/admin/admin.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="mainContentRegion">
  <div id="admin_centercontent">
    <div class="sectionHeader"><dashCommerce:Label ID="lblCouponManagement" runat="server" /></div><br />
    <dashCommerce:Panel ID="pnlAvailableCoupons" runat="server">
      <br />
      <dashCommerce:DataGrid ID="dgCoupons" runat="server" AutoGenerateColumns="false" DataKeyField="CouponId" SkinID="adminDataGrid" OnDeleteCommand="Delete_Coupon">
        <Columns>
          <asp:HyperLinkColumn DataNavigateUrlField="CouponId" />
          <asp:BoundColumn DataField="CouponCode" />
          <asp:BoundColumn DataField="ExpirationDate" />
          <asp:BoundColumn DataField="Type" />
          <asp:ButtonColumn ButtonType="LinkButton" CommandName="Delete" />
        </Columns>
      </dashCommerce:DataGrid>
    </dashCommerce:Panel>
    <br />
    <dashCommerce:Panel ID="pnlCouponConfiguration" runat="server">
      <br />
      <div class="verticalalign">
        <asp:DropDownList ID="ddlProviders" runat="server" CssClass="dropdownlist" />&nbsp;<dashCommerce:Button ID="btnCreateNew" runat="server" CssClass="button" OnClick="btnCreateNew_Click" /><br /><br />
      </div>
      <asp:Panel ID="pnlConfiguration" runat="server" />
    </dashCommerce:Panel>    
  </div>
</div>
</asp:Content>
