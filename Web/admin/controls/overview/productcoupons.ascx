<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="productcoupons.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.overview.productcoupons" %>


<dashCommerce:Panel ID="pnlProductCoupons" runat="server">
  <br />
  <dashCommerce:HyperLink ID="hlCoupons" runat="server" NavigateUrl="~/admin/coupons.aspx" CssClass="label" /><br />
  <dashCommerce:Label ID="lblCouponDescription" runat="server" CssClass="label" /><br /><br />

  <dashCommerce:HyperLink ID="hlManageCouponProviders" runat="server" NavigateUrl="~/admin/couponprovidermanagement.aspx" CssClass="label" /><br />
  <dashCommerce:Label ID="lblManageCouponProviderDescription" runat="server" CssClass="label" /><br /><br />

</dashCommerce:Panel>