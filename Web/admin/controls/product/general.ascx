<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="general.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.product.general" %>

<dashCommerce:Panel ID="pnlGeneralProductInformation" runat="server">
    <br />
    <dashCommerce:Label ID="lblBaseSku" runat="server" CssClass="label" /><br />
    <asp:TextBox ID="txtBaseSku" runat="server" CssClass="textbox" />&nbsp;<dashCommerce:HelpLink ID="helpBaseSku" runat="server" NavigateUrl="javascript:void(0);" />&nbsp;<dashCommerce:RequiredFieldValidator ID="rfvBaseSku" runat="server" ControlToValidate="txtBaseSku" /><br /><br />
    <dashCommerce:Label ID="lblName" runat="server" CssClass="label" /><br />
    <asp:TextBox ID="txtName" runat="server" CssClass="longtextbox" />&nbsp;<dashCommerce:HelpLink ID="helpName" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
    <div class="verticalalign">
      <dashCommerce:Label ID="lblShortDescription" runat="server" CssClass="label" />&nbsp;<dashCommerce:HelpLink ID="helpShortDescription" runat="server" NavigateUrl="javascript:void(0);" /><br />
    </div>
    <FCKeditorV2:FCKeditor ID="txtShortDescription" BasePath="~/FCKeditor/" runat="server" Height="200"
    Width="100%" UseBROnCarriageReturn="true" ToolbarStartExpanded="false" /><br />
    <dashCommerce:Label ID="lblOurPrice" runat="server" CssClass="label" /><br />
    <dashCommerce:Label ID="lblOurPriceCurrencySymbol" runat="server" CssClass="label"/>&nbsp;</dashCommerce:Label><asp:TextBox ID="txtOurPrice" runat="server" CssClass="textbox" />&nbsp;<dashCommerce:HelpLink ID="helpOurPrice" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
    <dashCommerce:Label ID="lblRetailPrice" runat="server" CssClass="label" /><br />
    <dashCommerce:Label ID="lblRetailPriceCurrencySymbol" runat="server" CssClass="label"/>&nbsp;<asp:TextBox ID="txtRetailPrice" runat="server" CssClass="textbox" />&nbsp;<dashCommerce:HelpLink ID="helpRetailPrice" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
    <dashCommerce:Label ID="lblManufacturer" runat="server" CssClass="label" /><br />
    <div class="verticalalign"><asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline"><ContentTemplate><asp:DropDownList ID="ddlManufacturer" runat="server" CssClass="dropdownlist" />&nbsp;<dashCommerce:HelpLink ID="helpManufacturer" runat="server" NavigateUrl="javascript:void(0);" />&nbsp;<asp:TextBox ID="txtManufacturerAdd" runat="server" CssClass="textbox" />&nbsp;<dashCommerce:Button ID="btnManufacturerAdd" runat="server" CssClass="button" OnClick="btnManufacturerAdd_Click" CausesValidation="false" /></ContentTemplate></asp:UpdatePanel></div><br />
    <dashCommerce:Label ID="lblProductType" runat="server" CssClass="label" /><br />
    <div class="verticalalign"><asp:UpdatePanel ID="productTypeUpdate" runat="server" RenderMode="Inline"><ContentTemplate><asp:DropDownList ID="ddlProductType" runat="server" CssClass="dropdownlist" />&nbsp;<dashCommerce:HelpLink ID="helpProductType" runat="server" NavigateUrl="javascript:void(0);" />&nbsp;<asp:TextBox ID="txtProductTypeAdd" runat="server" CssClass="textbox" />&nbsp;<dashCommerce:Button ID="btnProductTypeAdd" runat="server" CssClass="button" OnClick="btnProductTypeAdd_Click" CausesValidation="false" /></ContentTemplate></asp:UpdatePanel></div><br />
    <dashCommerce:Label ID="lblTaxRate" runat="server" CssClass="label" /><br />
    <asp:DropDownList ID="ddlTaxRate" runat="server" CssClass="dropdownlist" />&nbsp;<dashCommerce:HelpLink ID="helpTaxRate" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />    
    <dashCommerce:Label ID="lblStatus" runat="server" CssClass="label" /><br />
    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="dropdownlist" />&nbsp;<dashCommerce:HelpLink ID="helpStatus" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
    <dashCommerce:Label ID="lblShippingEstimate" runat="server" CssClass="label" /><br />
    <asp:DropDownList ID="ddlShippingEstimate" runat="server" CssClass="dropdownlist" />&nbsp;<dashCommerce:HelpLink ID="helpShippingEstimate" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
    <dashCommerce:Label ID="lblWeight" runat="server" CssClass="label" /><br />
    <asp:TextBox ID="txtWeight" runat="server" CssClass="textbox" />&nbsp;<dashCommerce:HelpLink ID="helpWeight" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
    <dashCommerce:Label ID="lblDimensions" runat="server" CssClass="label" /><br />
    <dashCommerce:Label ID="lblLength" runat="server" CssClass="label" />&nbsp;<asp:TextBox ID="txtLength" runat="server" CssClass="textbox" />&nbsp;<dashCommerce:HelpLink ID="helpProductLength" runat="server" NavigateUrl="javascript:void(0);" /><br />
    <dashCommerce:Label ID="lblWidth" runat="server" CssClass="label" />&nbsp;&nbsp;<asp:TextBox ID="txtWidth" runat="server" CssClass="textbox" />&nbsp;<dashCommerce:HelpLink ID="helpProductWidth" runat="server" NavigateUrl="javascript:void(0);" /><br />
    <dashCommerce:Label ID="lblHeight" runat="server" CssClass="label" />&nbsp;<asp:TextBox ID="txtHeight" runat="server" CssClass="textbox" />&nbsp;<dashCommerce:HelpLink ID="helpProductHeight" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
    <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <dashCommerce:Button ID="btnCopy" runat="server" CssClass="button" OnClick="btnCopy_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <dashCommerce:Button ID="btnDelete" runat="server" CssClass="button" OnClick="btnDelete_Click" />
</dashCommerce:Panel>