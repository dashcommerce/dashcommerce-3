<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="manufacturers.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.manufacturers" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/admin/admin.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="mainContentRegion">
    <div id="admin_centercontent">
      <div class="sectionHeader"><dashCommerce:Label ID="lblManufacturerAdministration" runat="server" /></div><br />
      <dashCommerce:Panel ID="pnlManufacturerList" runat="server" DefaultButton="btnSave">
        <dashCommerce:DataGrid ID="dgManufacturers" runat="server" AutoGenerateColumns="false" SkinID="adminDataGrid" OnPageIndexChanged="dgManufacturer_PageIndexChanging">
          <Columns>
            <asp:TemplateColumn>
              <ItemTemplate>
                <dashCommerce:LinkButton ID="lbDelete" runat="server" CausesValidation="false" CommandName="mydelete" CommandArgument='<%# Eval("ManufacturerId") %>' OnCommand="lbDelete_Click" />
              </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="Name" />
           </Columns>
        </dashCommerce:DataGrid>
      </dashCommerce:Panel>
      <br />
      <dashCommerce:Panel ID="pnlAddManufacturer" runat="server">
        <dashCommerce:Label ID="lblName" runat="server" CssClass="label" /><br />
        <asp:TextBox ID="txtName" runat="server" CssClass="textbox" />&nbsp;<dashCommerce:HelpLink ID="helpManufacturerName" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
        <dashCommerce:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="button" />
        <dashCommerce:RequiredFieldValidator ID="rfvName" runat="server" Display="None" ControlToValidate="txtName" />
      </dashCommerce:Panel>
    </div>
  </div>
</asp:Content>
