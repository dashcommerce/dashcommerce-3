<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="descriptors.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.product.descriptors" %>

<asp:UpdateProgress ID="upDisplay" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="up" DisplayAfter="100" />
<dashCommerce:Panel ID="pnlProductDescriptors" runat="server">
   <asp:UpdatePanel ID="up" runat="server" UpdateMode="Always" >
      <ContentTemplate>      
        <dashCommerce:Panel ID="pnlGrid" runat="server">
          <dashCommerce:DataGrid ID="dgDescriptors" runat="server" AutoGenerateColumns="false" DataKeyField="DescriptorId" OnEditCommand="Edit_Descriptor" OnDeleteCommand="Delete_Descriptor" SkinId="adminDataGrid">
	          <HeaderStyle CssClass="adminTableHeader" />
	            <Columns>
	              <asp:TemplateColumn>
                  <ItemTemplate>
                    <dashCommerce:LinkButton ID="lbEdit" runat="server" CausesValidation="false" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "DescriptorId") %>' />
                  </ItemTemplate>
                </asp:TemplateColumn>
	              <asp:TemplateColumn>
                  <ItemTemplate>
                    <asp:ImageButton ID="lbUp" runat="server" CausesValidation="false" CommandName="Up" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "DescriptorId") %>' OnClick="Items_ItemReorder" SkinID="up" /> 
                    <asp:ImageButton ID="lbDown" runat="server" CausesValidation="false" CommandName="Down" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "DescriptorId") %>' OnClick="Items_ItemReorder" SkinID="down" />
                  </ItemTemplate>
                </asp:TemplateColumn>
	              <asp:BoundColumn DataField="Title" />
                <asp:BoundColumn DataField="SortOrder" />                
	              <asp:TemplateColumn>
				          <ItemTemplate>
	                  <%# GetStrippedDescriptor(DataBinder.Eval(Container.DataItem, "DescriptorX").ToString()) %>
				          </ItemTemplate>
	              </asp:TemplateColumn>
	              <asp:TemplateColumn>
                  <ItemTemplate>
                    <dashCommerce:LinkButton ID="lbDelete" runat="server" CausesValidation="false" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "DescriptorId") %>' />
                  </ItemTemplate>
                </asp:TemplateColumn>
	            </Columns>
	        </dashCommerce:DataGrid>
          <br />
          <br />
        </dashCommerce:Panel>
        <dashCommerce:Label ID="lblDescriptorId" runat="server" Visible="false" />
        <dashCommerce:Label ID="lblTitle" runat="server" CssClass="label" /><br />
        <asp:TextBox ID="txtTitle" runat="server" CssClass="longtextbox" />&nbsp;<dashCommerce:HelpLink ID="helpDescriptorTitle" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
        <div class="verticalalign">
          <dashCommerce:Label ID="lblDescription" runat="server" CssClass="label" />&nbsp;<dashCommerce:HelpLink ID="helpDescriptorDescription" runat="server" NavigateUrl="javascript:void(0);" /><br />
        </div>
        <FCKeditorV2:FCKeditor ID="txtDescriptor" BasePath="~/FCKeditor/" runat="server" Height="200"
         Width="100%" UseBROnCarriageReturn="true" ToolbarStartExpanded="false" /><br />
    </ContentTemplate>
  </asp:UpdatePanel>
    <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" />
    <dashCommerce:RequiredFieldValidator ID="rfvTitle" runat="server" Display="None" ControlToValidate="txtTitle" />
</dashCommerce:Panel>
  