<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="errorlogs.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.errorlogs" Title="Untitled Page" %>
<%@ Import Namespace="MettleSystems.dashCommerce.Core"%>
<%@ MasterType VirtualPath="~/admin/admin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="mainContentRegion">
  <div id="admin_centercontent">
    <div class="sectionHeader"><dashCommerce:Label ID="lblErrorLogListing" runat="server" /></div><br />
    <dashCommerce:Panel ID="pnlErrorLogSearch" runat="server">
      <dashCommerce:Label ID="lblLogLevel" runat="server" CssClass="label" /><br />
      <asp:DropDownList ID="ddlLogLevel" runat="server" CssClass="fwdropdownlist" /><br /><br />
      <dashCommerce:Button ID="btnSearch" runat="server" CssClass="button" OnClick="btnSearch_Click" />
    </dashCommerce:Panel>
    <br />
    <dashCommerce:Panel ID="pnlCurrentErrorLogs" runat="server">
      <br />
      <dashCommerce:DataGrid ID="dgErrorLogListing" runat="server" AutoGenerateColumns="False" DataKeyField="LogId" OnPageIndexChanged="dgErrorLogListing_Paging" SkinID="adminDataGrid">
        <HeaderStyle CssClass="adminTableHeader" />
        <Columns>
   			  <asp:BoundColumn DataField="LogId" Visible="False" />
			    <asp:HyperLinkColumn DataNavigateUrlField="LogId" DataNavigateUrlFormatString="~/admin/errorlogdetails.aspx?logId={0}" />   			
          <asp:BoundColumn DataField="LogDate" />
          <asp:TemplateColumn>
              <ItemTemplate><%# ((Logger.LogMessageType)Convert.ToInt32(Eval("MessageType").ToString())).ToString() %></ItemTemplate>
          </asp:TemplateColumn>
          <asp:BoundColumn DataField="ScriptName" />
          <asp:BoundColumn DataField="Message" />          
          <asp:BoundColumn DataField="RemoteHost" />
        </Columns>
        <PagerStyle Mode="NumericPages" />
      </dashCommerce:DataGrid>
      <br />
      <dashCommerce:Button ID="btnDeleteAll" runat="server" CssClass="rightbutton" OnClick="btnDeleteAll_Click" />
    </dashCommerce:Panel>
  </div>
</div>
</asp:Content>