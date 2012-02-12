<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="vattaxconfiguration.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.configuration.taxproviders.vattaxconfiguration" %>
<%@ Register TagPrefix="dashCommerce" TagName="RegionCodeNavigation" Src="~/admin/controls/navigation/regioncode.ascx" %>

<dashCommerce:RegionCodeNavigation ID="dcRegionCodeNavigation" runat="server" />
<dashCommerce:Panel ID="pnlVatTaxConfiguration" runat="server">
  <br />
  <dashCommerce:Panel ID="pnlDescriptionTitle" runat="server" CssClass="accordionHeaderGray">
    <div class="cpeTitle">
      <dashCommerce:Label ID="lblDescriptionTitle" runat="server" />
    </div>
    <div class="cpeImage">
      <asp:Image ID="imgToggle" runat="server" />
    </div>
  </dashCommerce:Panel>
  <dashCommerce:Panel ID="pnlDescription" runat="server">
    <br />
    <asp:Literal ID="ltDescription" runat="server" />
  </dashCommerce:Panel>
  <asp:CollapsiblePanelExtender ID="cpeDescription" runat="server"  TargetControlID="pnlDescription" ExpandControlID="pnlDescriptionTitle" CollapseControlID="pnlDescriptionTitle" ImageControlID="imgToggle" ExpandDirection="Vertical" Collapsed="true" CollapsedImage="~/App_Themes/dashCommerce/images/icons/down.gif" ExpandedImage="~/App_Themes/dashCommerce/images/icons/up.gif" />
  <!--<br />
  <dashCommerce:Label ID="lblDefaultRate" runat="server" /><br />
  <asp:TextBox ID="txtDefaultRate" runat="server" />&nbsp;<dashCommerce:HelpLink ID="helpDefaultRate" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />-->
  <br /><br />
  <dashCommerce:Button ID="btnSave" runat="server" OnClick="btnSave_Click" />
</dashCommerce:Panel>
<dashCommerce:Panel ID="pnlVatTaxData" runat="server" Visible="false">
    <dashCommerce:Panel ID="pnlAddVatTax" runat="server">
      <dashCommerce:Label ID="lblName" runat="server" /><br />
      <asp:TextBox ID="txtName" runat="server" />&nbsp;<dashCommerce:HelpLink ID="helpVatTax" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
      <dashCommerce:Label ID="lblRate" runat="server" /><br />
      <asp:TextBox ID="txtRate" runat="server" />&nbsp;<dashCommerce:HelpLink ID="helpRate" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
      <dashCommerce:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" />
      <dashCommerce:RequiredFieldValidator ID="rfvName" runat="server" Display="None" ControlToValidate="txtName" />
      <dashCommerce:RequiredFieldValidator ID="rfvRate" runat="server" Display="None" ControlToValidate="txtRate" />
    </dashCommerce:Panel>
    <br />
    <dashCommerce:Panel ID="pnlAvailableVatTax" runat="server">
    <dashCommerce:DataGrid ID="dgVatTax" runat="server" AutoGenerateColumns="False" SkinId="adminDataGridNoPage">
        <Columns>
          <asp:BoundColumn DataField="Name" />
          <asp:BoundColumn DataField="Rate" />
          <asp:TemplateColumn>
            <ItemTemplate>
              <dashCommerce:LinkButton ID="lbDelete" runat="server" CommandName="mydelete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "VatTaxRateId") %>'  OnCommand="dgVatTax_Delete" CausesValidation="false" />
            </ItemTemplate>
          </asp:TemplateColumn>
        </Columns>
    </dashCommerce:DataGrid>
    </dashCommerce:Panel>
</dashCommerce:Panel>