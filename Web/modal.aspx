<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modal.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.modal" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <dashCommerce:Panel ID="pnlException" runat="server" Visible="false">
      <div class="verticalalign">
        <asp:Image ID="imgCriticalError" runat="server" SkinID="critical" />&nbsp;<dashCommerce:Label ID="lblErrorMessage" runat="server" CssClass="label" />
      </div>
    </dashCommerce:Panel>
    </form>
</body>
</html>
