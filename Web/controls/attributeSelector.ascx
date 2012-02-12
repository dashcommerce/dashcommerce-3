<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="attributeSelector.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.controls.attributeSelector" EnableViewState="false" %>

<asp:UpdateProgress ID="upDisplay" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upAttributes" DisplayAfter="100" />
<asp:UpdatePanel ID="upAttributes" runat="server">
  <ContentTemplate>
    <dashCommerce:Panel ID="pnlProductAttributes" runat="server" />
  </ContentTemplate>
</asp:UpdatePanel>
