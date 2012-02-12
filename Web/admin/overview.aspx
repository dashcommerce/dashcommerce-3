<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="overview.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.overview" Title="Untitled Page" %>
<%@ Register TagPrefix="dashCommerce" TagName="SiteSettingsOverview" Src="~/admin/controls/overview/site.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="Security" Src="~/admin/controls/overview/security.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="Sales" Src="~/admin/controls/overview/sales.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="ProductManagement" Src="~/admin/controls/overview/productmanagement.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="ProductCoupons" Src="~/admin/controls/overview/productcoupons.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="Configuration" Src="~/admin/controls/overview/configuration.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="MailConfiguration" Src="~/admin/controls/overview/mail.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="Providers" Src="~/admin/controls/overview/providers.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="CustomerService" Src="~/admin/controls/overview/customerservice.ascx"  %>
<%@ Register TagPrefix="dashCommerce" TagName="Help" Src="~/admin/controls/overview/help.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <dashCommerce:SiteSettingsOverview ID="siteSettingsOverview" runat="server" Visible="false" />
  <dashCommerce:Security ID="security" runat="server" Visible="false" />
  <dashCommerce:Sales ID="sales" runat="server" Visible="false" />
  <dashCommerce:ProductManagement ID="productmanagement" runat="server" Visible="false" />
  <dashCommerce:ProductCoupons ID="productcoupons" runat="server" Visible="false" />
  <dashCommerce:Configuration ID="configuration" runat="server" Visible="false" />
  <dashCommerce:MailConfiguration ID="mailConfiguration" runat="server" Visible="false" />
  <dashCommerce:Providers ID="providers" runat="server" Visible="false" />
  <dashCommerce:CustomerService ID="customerService" runat="server" Visible="false" />
  <dashCommerce:Help ID="help" runat="server" Visible="false" />
  <dashCommerce:Label ID="lblNotDone" runat="server" Visible="false" Text="not done yet!" />
</asp:Content>
