<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="productmanagement.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.overview.productmanagement" %>


<dashCommerce:Panel ID="pnlProductManagement" runat="server">
  <br />
  <dashCommerce:HyperLink ID="hlProductListing" runat="server" NavigateUrl="~/admin/productlist.aspx" CssClass="label" /><br />
  <dashCommerce:Label ID="lblProductListingDescription" runat="server" CssClass="label" /><br /><br />

  <dashCommerce:HyperLink ID="hlProductCategories" runat="server" NavigateUrl="~/admin/categoryedit.aspx" CssClass="label" /><br />
  <dashCommerce:Label ID="lblProductCategoriesDescription" runat="server" CssClass="label" /><br /><br />

  <dashCommerce:HyperLink ID="hlProductManufacturers" runat="server" NavigateUrl="~/admin/manufacturers.aspx" CssClass="label" /><br />
  <dashCommerce:Label ID="lblProductManufacturersDescription" runat="server" CssClass="label" /><br /><br />

  <dashCommerce:HyperLink ID="hlProductAttributes" runat="server" NavigateUrl="~/admin/attributeedit.aspx" CssClass="label" /><br />
  <dashCommerce:Label ID="lblProductAttributesDescription" runat="server" CssClass="label" /><br /><br />

  <dashCommerce:HyperLink ID="hlProductCoupons" runat="server" NavigateUrl="~/admin/overview.aspx?view=pco" CssClass="label" /><br />
  <dashCommerce:Label ID="lblProductCouponsDescription" runat="server" CssClass="label" /><br /><br />

</dashCommerce:Panel>