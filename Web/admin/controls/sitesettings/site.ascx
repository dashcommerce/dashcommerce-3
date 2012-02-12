<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="site.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.sitesettings.site" %>
<%@ Reference Control="~/admin/admin.master" %>

<dashCommerce:Panel ID="pnlSite" runat="server">
  <br />
  <dashCommerce:Label ID="lblStoreClosed" runat="server" CssClass="label" />
  <dashCommerce:CheckBox ID="chkStoreClosed" runat="server" />&nbsp;<dashCommerce:HelpLink ID="helpStoreClosed" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />

  <dashCommerce:Label ID="lblLogo" runat="server" CssClass="label" />
  <asp:TextBox ID="txtLogo" runat="server" CssClass="longtextbox" />&nbsp;&nbsp;<dashCommerce:HyperLink ID="hlImageSelector" runat="server" SkinId="submodal-800-430" /><dashCommerce:HelpLink ID="helpSiteLogo" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  
  <dashCommerce:Label ID="lblName" runat="server" CssClass="label" />
  <asp:TextBox ID="txtName" runat="server" CssClass="longtextbox" />&nbsp;<dashCommerce:HelpLink ID="helpSiteName" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  
  <dashCommerce:Label ID="lblTagLine" runat="server" CssClass="label" />
  <asp:TextBox ID="txtTagLine" runat="server" CssClass="longtextbox" />&nbsp;<dashCommerce:HelpLink ID="helpTagLine" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  
  <dashCommerce:Label ID="lblLoginRequirement" runat="server" CssClass="label" />
  <asp:DropDownList ID="ddlLoginRequirement" runat="server" CssClass="dropdownlist" />&nbsp;<dashCommerce:HelpLink ID="helpLoginRequirement" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  
  <dashCommerce:Label ID="lblRequireSsl" runat="server" CssClass="label" />
  <dashCommerce:CheckBox ID="chkRequireSsl" runat="server" />&nbsp;<dashCommerce:HelpLink ID="helpRequireSsl" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
    
  <dashCommerce:Label ID="lblDisplayRetailPrice" runat="server" CssClass="label" />
  <dashCommerce:CheckBox ID="chkDisplayRetailPrice" runat="server" />&nbsp;<dashCommerce:HelpLink ID="helpDisplayRetailPrice" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />

  <dashCommerce:Label ID="lblAddTaxToPrice" runat="server" CssClass="label" />
  <dashCommerce:CheckBox ID="chkAddTaxToPrice" runat="server" />&nbsp;<dashCommerce:HelpLink ID="helpAddTaxToPrice" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
    
  <dashCommerce:Label ID="lblDisplayRatings" runat="server" CssClass="label" />
  <dashCommerce:CheckBox ID="chkDisplayRatings" runat="server" />&nbsp;<dashCommerce:HelpLink ID="helpDisplayRatings" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  
  <dashCommerce:Label ID="lblShowShippingOnCart" runat="server" CssClass="label" />
  <dashCommerce:CheckBox ID="chkDisplayShippingOnCart" runat="server" />&nbsp;<dashCommerce:HelpLink ID="helpDisplayShippingOnCart" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
    
  <dashCommerce:Label ID="lblCategoryItems" runat="server" CssClass="label" />
  <asp:DropDownList ID="ddlCategoryItems" runat="server" CssClass="dropdownlist" />&nbsp;<dashCommerce:HelpLink ID="helpCategoryItems" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  
  <dashCommerce:Label ID="lblDefaultCategorySorting" runat="server" CssClass="label" />
  <asp:DropDownList ID="ddlDefaultSort" runat="server" CssClass="dropdownlist" /><br /><br />
  
  <dashCommerce:Label ID="lblMaximumProductsToAddToCart" runat="server" CssClass="label" />
  <asp:TextBox ID="txtMaximumProductsToAddToCart" runat="server" CssClass="textbox" /><asp:FilteredTextBoxExtender ID="ftbeMaximumProductsToAddToCart" runat="server" TargetControlId="txtMaximumProductsToAddToCart" FilterType="Numbers" />&nbsp;<dashCommerce:HelpLink ID="helpMaximumProductsToAddToCart" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  
  <dashCommerce:Label ID="lblTheme" runat="server" CssClass="label" />
  <asp:DropDownList ID="ddlTheme" runat="server" CssClass="dropdownlist" />&nbsp;<dashCommerce:HelpLink ID="helpTheme" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  
  <dashCommerce:Label ID="lblNewsFeedUrl" runat="server" CssClass="label" />
  <asp:TextBox ID="txtNewsFeedUrl" runat="server" CssClass="longtextbox" />&nbsp;&nbsp;<dashCommerce:HelpLink ID="helpNewsFeedUrl" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
  
  <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" />
</dashCommerce:Panel>