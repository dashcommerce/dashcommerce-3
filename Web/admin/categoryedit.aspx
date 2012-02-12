<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="categoryedit.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.categoryedit" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/admin/admin.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="mainContentRegion">
  <div id="admin_centercontent">
    <div class="sectionHeader"><dashCommerce:Label ID="lblProductCategories" runat="server" /></div><br />
    <table id="categoryTable">
      <tr>
        <td width="50%">
          <dashCommerce:Panel ID="pnlCurrentCategories" runat="server">
            <asp:TreeView ID="tvCategory" runat="server" DataSourceID="xmlDataSource" OnSelectedNodeChanged="Category_Selected" CollapseImageUrl="~/App_Themes/dashCommerce/images/icons/folderopen.gif" ExpandImageUrl="~/App_Themes/dashCommerce/images/icons/folderclosed.gif" NoExpandImageUrl="~/App_Themes/dashCommerce/images/icons/folderclosed.gif" ExpandDepth="FullyExpand" >
              <DataBindings>
                <asp:TreeNodeBinding DataMember="MenuItem" NavigateUrlField="NavigateUrl" TextField="Text" ValueField="Value" ToolTipField="ToolTip" />
              </DataBindings>
            </asp:TreeView>
            <asp:XmlDataSource ID="xmlDataSource" TransformFile="~/transforms/categoryMenu.xslt" XPath="MenuItems/MenuItem" runat="server" />
          </dashCommerce:Panel>
          <br />
          <dashCommerce:Panel ID="pnlChildCategories" runat="server">
            <dashCommerce:DataGrid ID="dgChildren" runat="server" AutoGenerateColumns="false" SkinID="adminDataGridNoPage">
              <Columns>
                <asp:TemplateColumn>
                    <ItemTemplate>
                      <asp:ImageButton ID="lbUp" runat="server" CausesValidation="false" CommandName="Up" CommandArgument='<%# Eval("CategoryId") %>' OnClick="Items_ItemReorder" SkinID="up" /> 
                      <asp:ImageButton ID="lbDown" runat="server" CausesValidation="false" CommandName="Down" CommandArgument='<%# Eval("CategoryId") %>' OnClick="Items_ItemReorder" SkinID="down" />
                    </ItemTemplate>
                  </asp:TemplateColumn>
	                <asp:BoundColumn DataField="Name" />
                  <asp:BoundColumn DataField="SortOrder" />              
              </Columns>
            </dashCommerce:DataGrid>
          </dashCommerce:Panel>        
        </td>
        <td>
          <dashCommerce:Panel ID="pnlEditCategory" runat="server">
            <dashCommerce:Label ID="lblCategoryId" runat="server" Visible="false" />
            <dashCommerce:Label ID="lblParentCategory" runat="server" CssClass="label" /><br />
            <asp:DropDownList ID="ddlParentCategory" runat="server" CssClass="fwdropdownlist" />&nbsp;<dashCommerce:HelpLink ID="helpParentCategory" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
            <dashCommerce:Label ID="lblName" runat="server" CssClass="label" /><br />
            <asp:TextBox ID="txtName" runat="server" CssClass="textbox" />&nbsp;<dashCommerce:HelpLink ID="helpCategoryName" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
            <dashCommerce:Label ID="lblImageFile" runat="server" CssClass="label" /><br />
            <asp:TextBox ID="txtImageFile" runat="server" CssClass="longtextbox" />&nbsp;<dashCommerce:HyperLink ID="hlImageSelector" runat="server" CssClass="submodal-800-415" />&nbsp;<dashCommerce:HelpLink ID="helpCategoryImageFile" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
            <div class="verticalalign">
              <dashCommerce:Label ID="lblDescription" runat="server" CssClass="label" />&nbsp;<dashCommerce:HelpLink ID="helpCategoryDescription" runat="server" NavigateUrl="javascript:void(0);" /><br />
            </div>
            <asp:TextBox ID="txtDescription" runat="server" CssClass="multilinetextbox" MaxLength="250" TextMode="MultiLine" /><br /><br />
            <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click"/>&nbsp;&nbsp;<dashCommerce:Button ID="btnReset" runat="server" CssClass="button" OnClick="btnReset_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<dashCommerce:Button ID="btnDelete" runat="server" CssClass="button" Visible="false" OnClick="btnDelete_Click" />
          </dashCommerce:Panel>        
        </td>
      </tr>    
    </table>
  </div>
</div>
</asp:Content>
