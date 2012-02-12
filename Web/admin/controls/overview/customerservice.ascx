<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="customerservice.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.overview.customerservice" %>

<dashCommerce:Panel ID="pnlCustomerServiceOverview" runat="server">
  <br />
  <dashCommerce:HyperLink ID="hlCustomerInformation" runat="server" NavigateUrl="~/admin/customerinformation.aspx" /><br />
  <dashCommerce:Label ID="lblCustomerInformationDescription" runat="server" CssClass="label" /><br /><br />
</dashCommerce:Panel>