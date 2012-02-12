<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="review.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.review" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server" EnablePartialRendering="true" />
    <div>
      <dashCommerce:Label ID="lblName" runat="server" CssClass="label" /><br /><br />
      <dashCommerce:Panel ID="pnlReview" runat="server">
        <dashCommerce:Label ID="lblYourRating" runat="server" CssClass="label" /><br />
        <asp:Rating ID="reviewRating" runat="server" SkinID="rating" /><br />
        <dashCommerce:Label ID="lblTitle" runat="server" CssClass="label" /><br />
        <asp:TextBox ID="txtTitle" runat="server" CssClass="longtextbox" /><br /><br />
        <dashCommerce:Label ID="lblReview" runat="server" CssClass="label" /><br />
        <asp:TextBox ID="txtReview" runat="server" CssClass="largemultilinetextbox" TextMode="MultiLine" /><br /><br />
        <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click"/>
      </dashCommerce:Panel>
      <dashCommerce:Label ID="lblReviewSaved" runat="server" CssClass="label" Visible="false" />
      <dashCommerce:Label ID="lblAlreadyReviewed" runat="server" CssClass="label" Visible="false" />      
    </div>
    </form>
</body>
</html>
