<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.about" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="mainContentRegion">
  <div id="admin_centercontent">
    <div class="sectionHeader">
        <dashCommerce:Label ID="lblAbout" runat="server" />
        <div style="float: right;">
            <a href="https://twitter.com/dashcommerce" class="twitter-follow-button" data-show-count="false" data-size="large">Follow @dashcommerce</a>
            <script type="text/javascript">!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = "//platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } }(document, "script", "twitter-wjs");</script>
        </div>
    </div>
    <dashCommerce:HyperLink ID="hlLogo" runat="server" SkinID="logo" /><br />
    <dashCommerce:Label ID="lblVersion" runat="server" /><br /><br />
    <dashCommerce:Label ID="lblStoreNotice" runat="server" /><br /><br />
    <dashCommerce:Label ID="lblCopyright" runat="server" /><br /><br />
    <dashCommerce:Label ID="lblTrademark" runat="server" /><br /><br />
    <dashCommerce:Label ID="lblLicenseAgreement" runat="server" /><br /><br />
    <asp:TextBox ID="txtLicenseAgreement" runat="server" TextMode="MultiLine" Width="98%" Height="250px" ReadOnly="true" /><br /><br />
    <dashCommerce:Label ID="lblAssembliesTitle" runat="server" /><br /><br />
    <dashCommerce:DataGrid ID="dgAssemblies" runat="server" AutoGenerateColumns="false" SkinID="adminDataGridNoPage">
      <Columns>
        <asp:BoundColumn DataField="FullName" />
      </Columns>
    </dashCommerce:DataGrid>
  </div>
</div>
</asp:Content>
