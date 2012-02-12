<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="downloads.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.product.downloads" %>


<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <dashCommerce:Panel ID="pnlProductDownloads" runat="server">
        <table id="categoryTable">
          <tr>
            <td width="50%">
              <dashCommerce:Panel ID="pnlCurrentDownloads" runat="server">
                <dashCommerce:DataGrid ID="dgDownloads" runat="server" AutoGenerateColumns="false" SkinID="adminDataGridNoPage">
                  <Columns>
                    <asp:BoundColumn DataField="Title" />
                    <asp:BoundColumn DataField="DownloadFile" />
                    <asp:TemplateColumn>
                      <ItemTemplate>
                        <asp:LinkButton ID="lbAdd" runat="server" CausesValidation="false" CommandName="Add" CommandArgument='<%# Eval("DownloadId") %>' OnCommand="lbAdd_Click" />
                      </ItemTemplate>
                    </asp:TemplateColumn>
                  </Columns>
                </dashCommerce:DataGrid>
              </dashCommerce:Panel>        
            </td>
            <td width="50%">
              <dashCommerce:Panel ID="pnlAssociatedDownloads" runat="server">
                <dashCommerce:DataGrid ID="dgProductDownloads" runat="server" AutoGenerateColumns="false" SkinID="adminDataGrid">
                  <Columns>
                    <asp:BoundColumn DataField="Title" />
	                  <asp:TemplateColumn>
                      <ItemTemplate>
                        <asp:LinkButton ID="lbDelete" runat="server" CausesValidation="false" CommandName="myDelete" CommandArgument='<%# Eval("DownloadId") %>' OnCommand="lbDelete_Click" />
                      </ItemTemplate>
                    </asp:TemplateColumn>
                  </Columns>
                </dashCommerce:DataGrid>
              </dashCommerce:Panel>
            </td>
          </tr>
        </table>
    </dashCommerce:Panel>
  </ContentTemplate>  
</asp:UpdatePanel>