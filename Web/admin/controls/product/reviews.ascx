<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="reviews.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.product.reviews" %>


<dashCommerce:Panel ID="pnlProductReviews" runat="server">
  <dashCommerce:Panel ID="pnlGrid" runat="server">
    <dashCommerce:DataGrid ID="dgReviews" runat="server" AutoGenerateColumns="false" SkinID="adminDataGrid">
      <Columns>
        <asp:TemplateColumn>
          <ItemTemplate>
            <dashCommerce:LinkButton ID="lbEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("ReviewId") %>' OnCommand="lbEdit_Click" />
          </ItemTemplate>
        </asp:TemplateColumn>  
        <asp:TemplateColumn>
          <ItemTemplate>
            <dashCommerce:Label ID="lblApproved" runat="server" Text='<%# Eval("IsApproved") %>' />
          </ItemTemplate>
        </asp:TemplateColumn>
        <asp:BoundColumn DataField="Title" />
        <asp:TemplateColumn>
          <ItemTemplate>
            <dashCommerce:Label ID="lblBody" runat="server" Text='<%# GetBodySample(Eval("Body").ToString()) %>' />
          </ItemTemplate>
        </asp:TemplateColumn>
        <asp:BoundColumn DataField="CreatedBy" />
        <asp:BoundColumn DataField="CreatedOn" />
        <asp:TemplateColumn>
          <ItemTemplate>
            <dashCommerce:LinkButton ID="lbDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("ReviewId") %>' OnCommand="lbDelete_Click" />
          </ItemTemplate>
        </asp:TemplateColumn>  
      </Columns>
    </dashCommerce:DataGrid>
  </dashCommerce:Panel><br />
  <dashCommerce:Panel ID="pnlReview" runat="server" Visible="false">
    <dashCommerce:Label ID="lblReviewId" runat="server" Visible="false" />
    <dashCommerce:Label ID="lblTitle" runat="server" CssClass="label" /><br />
    <asp:TextBox ID="txtTitle" runat="server" CssClass="textbox" Enabled="false" /><br /><br />
    <dashCommerce:Label ID="lblReview" runat="server" CssClass="label" /><br />
    <div id="txtReview" runat="server" style="overflow:auto;width:50%;height:105px;" />
    <dashCommerce:Label ID="lblRating" runat="server" CssClass="label" /><br />
    <dashCommerce:Label ID="lblRatingText" runat="server" CssClass="label" /><br /><br />
    <dashCommerce:Label ID="lblIsApproved" runat="server" CssClass="label" /><br />
    <dashCommerce:CheckBox ID="chkIsApproved" runat="server" /><br /><br />
    <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" />
  </dashCommerce:Panel>
</dashCommerce:Panel>
