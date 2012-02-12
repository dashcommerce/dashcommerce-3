<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="contentedit.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.contentedit" Title="Untitled Page" ValidateRequest="false"%>
<%@ MasterType VirtualPath="~/admin/admin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="mainContentRegion">
  <div id="admin_centercontent">
    <div class="sectionHeader"><dashCommerce:Label ID="lblContentManagement" runat="server" /></div><br />
    <table id="pageTable">
      <tr>
        <td valign="top">
          <dashCommerce:Panel ID="pnlCurrentPages" runat="server">
            <asp:TreeView ID="tvPages" runat="server" DataSourceID="xmlDataSource" ShowLines="true" OnSelectedNodeChanged="Page_Selected" ExpandDepth="FullyExpand" NodeStyle-ImageUrl="~/App_Themes/dashCommerce/images/icons/page.gif">
              <DataBindings>
                <asp:TreeNodeBinding DataMember="MenuItem" NavigateUrlField="NavigateUrl" TextField="Text" ValueField="Value" ToolTipField="ToolTip" />
              </DataBindings>
            </asp:TreeView>
            <asp:XmlDataSource ID="xmlDataSource" TransformFile="~/transforms/pageMenu.xslt" XPath="MenuItems/MenuItem" runat="server" />
          </dashCommerce:Panel>
          <br />
          <dashCommerce:Panel ID="pnlChildPages" runat="server">
            <dashCommerce:DataGrid ID="dgChildren" runat="server" AutoGenerateColumns="false" SkinID="adminDataGridNoPage">
              <Columns>
                <asp:TemplateColumn>
                    <ItemTemplate>
                      <asp:ImageButton ID="lbUp" runat="server" CausesValidation="false" CommandName="Up" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PageId") %>' OnClick="Items_ItemReorder" SkinID="up" /> 
                      <asp:ImageButton ID="lbDown" runat="server" CausesValidation="false" CommandName="Down" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PageId") %>' OnClick="Items_ItemReorder" SkinID="down" />
                    </ItemTemplate>
                  </asp:TemplateColumn>
	                <asp:BoundColumn DataField="Title" />
                  <asp:BoundColumn DataField="SortOrder" />              
              </Columns>
            </dashCommerce:DataGrid>
          </dashCommerce:Panel>        
        </td>
        <td valign="top">
          <dashCommerce:Panel ID="pnlEditPage" runat="server">
            <dashCommerce:Label ID="lblPageId" runat="server" Visible="false" />
            <dashCommerce:Label ID="lblParentPage" runat="server" CssClass="label" /><br />
            <asp:DropDownList ID="ddlParentPage" runat="server" CssClass="fwdropdownlist" />&nbsp;<dashCommerce:HelpLink ID="helpParentPage" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
            <dashCommerce:Label ID="lblTitle" runat="server" CssClass="label" /><br />
            <asp:TextBox ID="txtTitle" runat="server" CssClass="longtextbox" />&nbsp;<dashCommerce:HelpLink ID="helpTitle" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
            <dashCommerce:Label ID="lblMenuTitle" runat="server" CssClass="label" /><br />
            <asp:TextBox ID="txtMenuTitle" runat="server" CssClass="textbox" />&nbsp;<dashCommerce:HelpLink ID="helpMenuTitle" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
            <div class="verticalalign">
              <dashCommerce:Label ID="lblKeywords" runat="server" CssClass="label" />&nbsp;<dashCommerce:HelpLink ID="helpKeywords" runat="server" NavigateUrl="javascript:void(0);" /><br />
            </div>
            <asp:TextBox ID="txtKeywords" runat="server" CssClass="multilinetextbox" MaxLength="250" TextMode="MultiLine" /><br /><br />
            <div class="verticalalign">
              <dashCommerce:Label ID="lblDescription" runat="server" CssClass="label" />&nbsp;<dashCommerce:HelpLink ID="helpDescription" runat="server" NavigateUrl="javascript:void(0);" /><br />
            </div>
            <asp:TextBox ID="txtDescription" runat="server" CssClass="multilinetextbox" MaxLength="250" TextMode="MultiLine" /><br /><br />
            <dashCommerce:Label ID="lblPageTemplate" runat="server" CssClass="label" /><br />
            <asp:DropDownList ID="ddlPageTemplate" runat="server" CssClass="fwdropdownlist" />&nbsp;<dashCommerce:HelpLink ID="helpPageTemplate" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
            <dashCommerce:Panel ID="pnlRegions" runat="server" Visible="false">
              <dashCommerce:DataGrid ID="dgRegions" runat="server" AutoGenerateColumns="false" SkinID="adminDataGridNoPage">
                <Columns>
<%--                  <asp:TemplateColumn>
                    <ItemTemplate>
                      <asp:ImageButton ID="lbRegionUp" runat="server" CausesValidation="false" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "RegionId") %>' OnClick="Regions_ItemReorder" SkinID="up" /> 
                      <asp:ImageButton ID="lbRegionDown" runat="server" CausesValidation="false" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "RegionId") %>' OnClick="Regions_ItemReorder" SkinID="down" />
                    </ItemTemplate>
                  </asp:TemplateColumn>--%>
                  <asp:TemplateColumn>
                    <ItemTemplate>
                      <dashCommerce:HyperLink ID="hlEditRegion" runat="server" SkinId="submodal-640-500" />
                    </ItemTemplate>
                  </asp:TemplateColumn>
                  <asp:TemplateColumn>
                    <ItemTemplate>
                      <%# Eval("TemplateRegion.Name") %>  
                    </ItemTemplate>
                  </asp:TemplateColumn>
                  <asp:BoundColumn DataField="Title" />
                  <asp:BoundColumn DataField="SortOrder" />
                  <asp:TemplateColumn>
                    <ItemTemplate>
                      <dashCommerce:HyperLink ID="hlEdit" runat="server" SkinId="submodal-640-500" />
                    </ItemTemplate>
                  </asp:TemplateColumn>
                  <asp:TemplateColumn>
                    <ItemTemplate>
                      <dashCommerce:LinkButton ID="lbDelete" runat="server" CommandArgument='<%# Eval("RegionId") %>' OnCommand="lbDelete_Click" />
                    </ItemTemplate>
                  </asp:TemplateColumn>
                </Columns>
              </dashCommerce:DataGrid>
              <br />
              <br />
              <dashCommerce:HyperLink ID="hlAddRegion" runat="server" SkinId="submodal-640-500" />              
            </dashCommerce:Panel>
            <br />
            <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click"/>&nbsp;&nbsp;<dashCommerce:Button ID="btnReset" runat="server" CssClass="button" OnClick="btnReset_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<dashCommerce:Button ID="btnDelete" runat="server" CssClass="button" Visible="false" OnClick="btnDelete_Click" />
          </dashCommerce:Panel>        
        </td>
      </tr>    
    </table>
  </div>
</div>
</asp:Content>
