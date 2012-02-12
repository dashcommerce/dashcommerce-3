<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="narrowcategory.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.controls.catalog.narrowcategory" EnableViewState="false" %>


<dashCommerce:Panel ID="pnlNarrowCatagory" runat="server" CssClass="widget" GroupingText="Filtering" Visible="false">
    <asp:Repeater ID="rptNarrowCatagory" runat="server">
        <ItemTemplate>
            » <dashCommerce:HyperLink ID="hlChildCatagory" runat="server" NavigateUrl='<%# MettleSystems.dashCommerce.Web.RewriteService.BuildCatalogUrl(Eval("CategoryId").ToString(), (string)Eval("Name")) %>' Text='<%# Eval("Name") %>' /><br /></li>
        </ItemTemplate>    
    </asp:Repeater>
</dashCommerce:Panel>