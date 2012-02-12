<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="paging.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.controls.paging" EnableViewState="false" %>

<div class="paging">
  <div class="pagingLeft"></div>
  <div class="pagingMid">
    <span class="totals">
      <dashCommerce:Label ID="lblShowingTotals" runat="server" CssClass="label" />
    </span>
    <span class="links">
      <dashCommerce:HyperLink ID="hlPrevious" runat="server" SkinID="previous" />   
      <span id="pageLinks" class="pageLinks" runat="server" />
      <dashCommerce:HyperLink ID="hlNext" runat="server" SkinID="next" />
    </span>
  </div>
  <div class="pagingRight"></div>
</div>
<br />