<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="paymentsolutions.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.configuration.paymentproviders.paymentsolutions" %>

<dashCommerce:Panel ID="pnlPaymentSolutions" runat="server">
  <br />
  <dashCommerce:Label ID="lblPaymentSolutions" runat="server" />
  <br />
  <br />
  <a href="https://www.paypal.com/us/mrb/pal=NAG62FTSWGJ5W" target="_blank" onmouseover="window.status='Sign Up for PayPal!';return true;" onmouseout="window.status=''; return true;">Sign Up for PayPal</a>
  <br />
  <br />
  <a href="https://ems.authorize.net/oap/home.aspx?SalesRepID=98&ResellerID=12191" target="_blank" onmouseover="window.status='Sign Up for Authorize.Net!';return true;" onmouseout="window.status=''; return true;">Sign Up for Authorize.Net</a>
  <br />
  <br />
  <div class="rightAlign">
    <dashCommerce:Button ID="btnNext" runat="server"/>
  </div>
</dashCommerce:Panel>