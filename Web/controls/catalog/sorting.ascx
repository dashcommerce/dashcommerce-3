<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sorting.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.controls.catalog.sorting" EnableViewState="false" %>


<dashCommerce:Panel ID="pnlSortBy" runat="server" CssClass="widget">
    <dashCommerce:HyperLink ID="hlSortCheapest" runat="server" /><br />
    <dashCommerce:HyperLink ID="hlSortExpensive" runat="server" /><br />
    <dashCommerce:HyperLink ID="hlSortNewset" runat="server" /><br />
    <dashCommerce:HyperLink ID="hlSortOldest" runat="server" /><br />
    <dashCommerce:HyperLink ID="hlSortTitleAsc" runat="server" /><br />
    <dashCommerce:HyperLink ID="hlSortTitleDesc" runat="server" />
</dashCommerce:Panel>