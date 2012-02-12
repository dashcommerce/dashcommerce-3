<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="images.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.product.images" %>


<dashCommerce:Panel ID="pnlProductImages" runat="server">
  <dashCommerce:Panel ID="pnlImageManagement" runat="server">
    <dashCommerce:Label ID="lblImageId" runat="server" Visible="false" />
    <dashCommerce:Label ID="lblImageFile" runat="server" CssClass="label" /><br />
    <asp:TextBox ID="txtImageFile" runat="server" CssClass="longtextbox" /><dashCommerce:RequiredFieldValidator ID="rfvImageFile" runat="server" ControlToValidate="txtImageFile" Display="None" />&nbsp;<dashCommerce:HyperLink ID="hlImageSelector" runat="server" SkinId="submodal-800-430" Text=". . ." />&nbsp;<dashCommerce:HelpLink ID="helpImageFile" runat="server" NavigateUrl="javascript:void(0);" />
    <dashCommerce:Button ID="btnDelete" runat="server" CssClass="button" OnClick="btnDelete_Click" /><br /><br />
    <div class="verticalalign">
      <dashCommerce:Label ID="lblImageCaption" runat="server" CssClass="label" />&nbsp;<dashCommerce:HelpLink ID="helpImageCaption" runat="server" NavigateUrl="javascript:void(0);" /><br />
    </div>
    <asp:TextBox ID="txtImageCaption" runat="server" TextMode="MultiLine" CssClass="multilinetextbox" /><br /><br />
    <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" />
  </dashCommerce:Panel>
  <br />
  <dashCommerce:Panel ID="pnlImages" runat="server">
    <dashCommerce:DataGrid ID="dgProductImages" runat="server" AutoGenerateColumns="false" SkinID="adminDataGrid">
	      <Columns>
	        <asp:TemplateColumn>
            <ItemTemplate>
              <dashCommerce:LinkButton ID="lbEdit" runat="server" CausesValidation="false" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ImageId") %>' OnCommand="lbEdit_Click" />
            </ItemTemplate>
          </asp:TemplateColumn>
	        <asp:TemplateColumn>
            <ItemTemplate>
              <asp:ImageButton ID="lbUp" runat="server" CausesValidation="false" CommandName="Up" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ImageId") %>' OnClick="Items_ItemReorder" SkinID="up" /> 
              <asp:ImageButton ID="lbDown" runat="server" CausesValidation="false" CommandName="Down" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ImageId") %>' OnClick="Items_ItemReorder" SkinID="down" />
            </ItemTemplate>
          </asp:TemplateColumn>
	        <asp:BoundColumn DataField="SortOrder" ItemStyle-HorizontalAlign="center" />
	        <asp:TemplateColumn>
	          <ItemTemplate>
	            <dashCommerce:HyperLink ID="hlImage" runat="server" NavigateUrl="javascript:void(0);"><asp:Image ID="productImage" runat="server" ImageUrl='<%# MettleSystems.dashCommerce.Core.ImageProcess.GetProductThumbnailUrl((string)Eval("ImageFile")) %>'  /></dashCommerce:HyperLink>
	          </ItemTemplate>
	        </asp:TemplateColumn>
	        <asp:BoundColumn DataField="Caption" />
	        <asp:TemplateColumn>
	          <ItemTemplate>
              <dashCommerce:LinkButton ID="lbDelete" runat="server" CausesValidation="false" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ImageId") %>' OnCommand="lbDelete_Click" />
	          </ItemTemplate>
	        </asp:TemplateColumn>
	      </Columns>
	  </dashCommerce:DataGrid>
  </dashCommerce:Panel>
</dashCommerce:Panel>