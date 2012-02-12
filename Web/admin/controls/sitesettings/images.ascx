<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="images.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.sitesettings.images" %>
<%@ Reference Control="~/admin/admin.master" %>



<dashCommerce:Panel ID="pnlImages" runat="server">
    <br />
    <dashCommerce:CheckBox ID="chkGenerateThumbs" runat="server" CssClass="label" />
    <dashCommerce:HelpLink ID="helpGenerateThumbs" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
    <dashCommerce:Label ID="lblSmallSize" runat="server" CssClass="label" />
    <asp:TextBox ID="txtSmallWidth" runat="server" CssClass="textbox" Width="30px" /> x <asp:TextBox ID="txtSmallHeight" runat="server" CssClass="textbox" Width="30px" /><br /><br />
    <asp:FilteredTextBoxExtender ID="ftbeSmallWidth" runat="server" TargetControlId="txtSmallWidth" FilterType="Numbers" />
    <asp:FilteredTextBoxExtender ID="ftbeSmallHeight" runat="server" TargetControlId="txtSmallHeight" FilterType="Numbers" />
    <dashCommerce:RequiredFieldValidator ID="rfvSmallWidth" runat="server" Display="None" ControlToValidate="txtSmallWidth"/>
    <dashCommerce:RequiredFieldValidator ID="rfvSmallHeight" runat="server" Display="None" ControlToValidate="txtSmallHeight"/>
    <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" />
</dashCommerce:Panel>