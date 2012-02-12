<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="downloadedit.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.downloadedit" Title="Untitled Page" %>



<%@ MasterType VirtualPath="~/admin/admin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="mainContentRegion">
    <div id="admin_centercontent">
      <div class="sectionHeader"><dashCommerce:Label ID="lblDownloadAdministration" runat="server" /></div><br />
        <dashCommerce:Panel ID="pnlDownloads" runat="server">&nbsp;
          <dashCommerce:DataGrid ID="dgDownloads" runat="server" AutoGenerateColumns="false" SkinId="adminDataGridNoPage" DataKeyField="DownloadId" OnDeleteCommand="Delete_Download" OnEditCommand="Edit_Download">
            <Columns>
              <asp:TemplateColumn>
                <ItemTemplate>
                  <asp:LinkButton ID="lbEdit" runat="server" CausesValidation="false" CommandName="Edit" />
                </ItemTemplate>
              </asp:TemplateColumn>
              <asp:BoundColumn DataField="ForPurchaseOnly" />
              <asp:BoundColumn DataField="Title" />
              <asp:BoundColumn DataField="DownloadFile" />
              <asp:TemplateColumn>
                <ItemTemplate>
                  <asp:LinkButton ID="lbDelete" runat="server" CausesValidation="false" CommandName="Delete" />
                </ItemTemplate>
              </asp:TemplateColumn>
            </Columns>
          </dashCommerce:DataGrid>
        </dashCommerce:Panel>
        <br />
        <br />
        <dashCommerce:Panel ID="pnlAddDownload" runat="server">
          <br />
          <asp:TabContainer ID="tcFile" runat="server" Height="325px" ScrollBars="Vertical">
            <asp:TabPanel ID="tpFile" runat="server">
              <ContentTemplate>
                <dashCommerce:Label ID="lblDownloadId" runat="server" Visible="false" />
                <dashCommerce:Checkbox ID="chkForPurchaseOnly" runat="server" />&nbsp;<dashCommerce:HelpLink ID="helpForPurchaseOnly" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
                <dashCommerce:Label ID="lblFile" runat="server" CssClass="label" /><br />
                <asp:FileUpload ID="fuFile" runat="server" CssClass="button" /><br /><br />
                <dashCommerce:Label ID="lblTitle" runat="server" CssClass="label" /><br />
                <asp:TextBox ID="txtTitle" runat="server" CssClass="longtextbox" />&nbsp;<dashCommerce:HelpLink ID="helpDownloadTitleHelp" runat="server" NavigateUrl="javascript:void(0);" /><br /><br />
                <div class="verticalalign">
                  <dashCommerce:Label ID="lblDescription" runat="server" CssClass="label" />&nbsp;<dashCommerce:HelpLink ID="helpDownloadDescriptionHelp" runat="server" NavigateUrl="javascript:void(0);" /><br />
                </div>
                <FCKeditorV2:FCKeditor ID="txtDescriptor" BasePath="~/FCKeditor/" runat="server" Height="150"
                 Width="80%" UseBROnCarriageReturn="true" ToolbarStartExpanded="false" />
              </ContentTemplate>
            </asp:TabPanel>
          </asp:TabContainer>
          <br />
          <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" />
        </dashCommerce:Panel>
      </div>
    </div>
</asp:Content>
