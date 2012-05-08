<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="paymentsolutions.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.configuration.paymentproviders.paymentsolutions" %>

<dashCommerce:Panel ID="pnlPaymentSolutions" runat="server">
  <br />
  <dashCommerce:Label ID="lblPaymentSolutions" runat="server" />
  <br />
  <br />
  <asp:HyperLink ID="hlPayPalPaymentSolution" Text="Sign Up for PayPal" runat="server" NavigateUrl="https://www.paypal.com/us/mrb/pal=NAG62FTSWGJ5W" Target="_blank"/>
  <br />
  <br />
  <asp:HyperLink ID="hlAuthorizeNetPaymentSolution" Text="Sign Up for Authorize.Net" runat="server" CssClass="submodal-800-600" NavigateUrl="https://ems.authorize.net/oap/home.aspx?SalesRepID=98&ResellerID=12191" />
  <br />
  <br />
  <div class="rightAlign">
    <dashCommerce:Button ID="btnNext" runat="server"/>
  </div>
</dashCommerce:Panel>