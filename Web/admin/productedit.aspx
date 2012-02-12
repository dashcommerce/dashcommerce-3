<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="productedit.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.productedit" Title="Untitled Page" ValidateRequest="false" %>

<%@ MasterType VirtualPath="~/admin/admin.master" %>
<%@ Register TagPrefix="dashCommerce" TagName="ProductNavigation" Src="~/admin/controls/navigation/product.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="GeneralProductInformation" Src="~/admin/controls/product/general.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="ProductDescriptors" Src="~/admin/controls/product/descriptors.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="ProductCategories" Src="~/admin/controls/product/categories.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="ProductAttributes" Src="~/admin/controls/product/attributes.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="ProductDownloads" Src="~/admin/controls/product/downloads.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="ProductImages" Src="~/admin/controls/product/images.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="Skus" Src="~/admin/controls/product/sku.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="CrossSells" Src="~/admin/controls/product/crosssells.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="Reviews" Src="~/admin/controls/product/reviews.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="Notes" Src="~/admin/controls/product/notes.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="mainContentRegion">
    <div id="admin_centercontent">
      <div class="sectionHeader"><dashCommerce:Label ID="lblProductEdit" runat="server" />&nbsp;<dashCommerce:HelpLink ID="helpProductEnabled" runat="server" NavigateUrl="javascript:void(0);" /></div><br />
      <dashCommerce:ProductNavigation ID="productNavigation" runat="server" Visible="false"/>
      <dashCommerce:GeneralProductInformation ID="generalInformation" runat="server" Visible="false" />
      <dashCommerce:ProductDescriptors ID="descriptors" runat="server" Visible="false" />
      <dashCommerce:ProductCategories ID="categories" runat="server" Visible="false" />
      <dashCommerce:ProductAttributes ID="attributes" runat="server" Visible="false" />
      <dashCommerce:ProductDownloads ID="downloads" runat="server" Visible="false" />
      <dashCommerce:ProductImages ID="images" runat="server" Visible="false" />
      <dashCommerce:Skus ID="skus" runat="server" Visible="false" />
      <dashCommerce:CrossSells ID="crossSells" runat="server" Visible="false" />
      <dashCommerce:Reviews ID="reviews" runat="server" Visible="false" />
      <dashCommerce:Notes ID="notes" runat="server" Visible="false" />
    </div>
  </div>
</asp:Content>
