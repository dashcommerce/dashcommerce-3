<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="simpleweightconfiguration.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.configuration.shippingproviders.simpleweightconfiguration" %>


<%@ Register TagPrefix="dashCommerce" TagName="SimpleWeightNavigation" Src="~/admin/controls/navigation/simpleweightshippingprovider.ascx" %>
<dashCommerce:SimpleWeightNavigation ID="dcSimpleWeightNavigation" runat="server" />
<asp:Panel ID="pnlConfiguration" runat="server">
  <dashCommerce:Panel ID="pnlSimpleWeightConfiguration" runat="server">
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
    <br />
    <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" />
  </dashCommerce:Panel><br />
</asp:Panel>
<dashCommerce:Panel ID="pnlData" runat="server" Visible="false">
  <dashCommerce:Panel ID="pnlAddService" runat="server">
    <br />
    <dashCommerce:Label ID="lblService" runat="server" CssClass="label" /><br />
    <asp:TextBox ID="txtService" runat="server" CssClass="textbox" />&nbsp;<dashCommerce:HelpLink ID="helpSimpleWeightService" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
    <dashCommerce:Label ID="lblAmountPerUnit" runat="server" CssClass="label" /><br />
    <asp:TextBox ID="txtAmountPerUnit" runat="server" CssClass="textbox" />&nbsp;<dashCommerce:HelpLink ID="helpSimpleWeightAmountPerUnit" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
    <dashCommerce:Button ID="btnAdd" runat="server" CssClass="button" OnClick="btnAdd_Click" />
    <dashCommerce:RequiredFieldValidator ID="rfvService" runat="server" Display="None" ControlToValidate="txtService" />
    <dashCommerce:RequiredFieldValidator ID="rfvAmountPerUnit" runat="server" Display="None" ControlToValidate="txtAmountPerUnit" />
  </dashCommerce:Panel>
  <br />
  <dashCommerce:Panel ID="pnlAvailableServices" runat="server">
    <br />
    <dashCommerce:DataGrid ID="dgSimpleWeight" runat="server" AutoGenerateColumns="False" SkinID="adminDataGrid" OnPageIndexChanged="dgSimpleWeight_PageIndexChanged">
        <Columns>
          <asp:BoundColumn DataField="Service" />
          <asp:BoundColumn DataField="AmountPerUnit" DataFormatString="{0:n}" />
          <asp:TemplateColumn>
            <ItemTemplate>
              <dashCommerce:LinkButton ID="lbDelete" runat="server" CommandName="mydelete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "SimpleWeightShippingRateId") %>' OnCommand="dgSimpleWeight_Delete" CausesValidation="false" />
            </ItemTemplate>
          </asp:TemplateColumn>
        </Columns>
    </dashCommerce:DataGrid>
  </dashCommerce:Panel>
</dashCommerce:Panel>