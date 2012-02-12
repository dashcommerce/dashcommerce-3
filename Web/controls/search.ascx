<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="search.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.controls.search" EnableViewState="false" %>

<span class="searchBox">
  <asp:TextBox ID="txtSearchTerms" runat="server" CssClass="label" />&nbsp;<dashCommerce:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" CausesValidation="false"/>
</span>