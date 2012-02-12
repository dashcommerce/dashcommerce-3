<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="errorlogdetails.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.errorlogdetails" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/admin/admin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="mainContentRegion">
  <div id="admin_centercontent">
    <div class="sectionHeader"><dashCommerce:Label ID="lblErrorLogDetail" runat="server" />&nbsp;&nbsp;<dashCommerce:HelpLink ID="helpBackToErrorLogListing" runat="server" SkinId="back" NavigateUrl="~/admin/errorlogs.aspx" /></div><br />
    <dashCommerce:Panel ID="pnlErrorLogDetail" runat="server">
      <b><dashCommerce:Label ID="lblLogDate" runat="server" CssClass="label" /></b> <dashCommerce:Label ID="lblLogDateDisplay" runat="server" CssClass="label" /><br />
      <b><dashCommerce:Label ID="lblLogLevel" runat="server" CssClass="label" /></b> <dashCommerce:Label ID="lblLogLevelDisplay" runat="server" CssClass="label" /><br />
      <b><dashCommerce:Label ID="lblLogMessage" runat="server" CssClass="label" /></b> <dashCommerce:Label ID="lblLogMessageDisplay" runat="server" CssClass="label" /><br />
      <hr />
      <b><dashCommerce:Label ID="lblRemoteHost" runat="server" CssClass="label" />:</b> <dashCommerce:Label ID="lblRemoteHostDisplay" runat="server" CssClass="label" /><br /> 
      <b><dashCommerce:Label ID="lblAuthenticatedUser" runat="server" CssClass="label" />:</b> <dashCommerce:Label ID="lblAuthenticatedUserDisplay" runat="server" CssClass="label" /><br />
      <b><dashCommerce:Label ID="lblReferrer" runat="server" CssClass="label" />:</b> <dashCommerce:Label ID="lblReferrerDisplay" runat="server" CssClass="label" /><br />
      <b><dashCommerce:Label ID="lblUserAgent" runat="server" CssClass="label" />:</b> <dashCommerce:Label ID="lblUserAgentDisplay" runat="server" CssClass="label" /><br />
      <hr />      
      <b><dashCommerce:Label ID="lblLogScriptName" runat="server" CssClass="label" />:</b> <dashCommerce:Label ID="lblLogScriptNameDisplay" runat="server" CssClass="label" /><br />
      <b><dashCommerce:Label ID="lblQueryStringData" runat="server" CssClass="label" />:</b> <dashCommerce:Label ID="lblQueryStringDataDisplay" runat="server" CssClass="label" /><br />
      <b><dashCommerce:Label ID="lblExceptionMessage" runat="server" CssClass="label" />:</b> <dashCommerce:Label ID="lblExceptionMessageDisplay" runat="server" CssClass="label" /><br />
      <b><dashCommerce:Label ID="lblExceptionType" runat="server" CssClass="label" />:</b> <dashCommerce:Label ID="lblExceptionTypeDisplay" runat="server" CssClass="label" /><br /><br />
      <b><dashCommerce:Label ID="lblLogInfo" runat="server" CssClass="label" /></b><br />
      <asp:TextBox ID="txtLogInfoDisplay" runat="server" TextMode="MultiLine" Rows="12" Columns="115" ReadOnly="True" /><br />      
    </dashCommerce:Panel>
  </div>
</div>
</asp:Content>