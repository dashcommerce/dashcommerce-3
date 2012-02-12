<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="paymentselection.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.configuration.paymentproviders.paymentselection" %>
  
<dashCommerce:Panel ID="pnlPaymentSelection" runat="server">
  <br />
  <dashCommerce:Panel ID="pnlCardProcessing" runat="server" Visible="false">
    <dashCommerce:RadioButton ID="rbCreditCardsWithPayPal" runat="server" Checked="true" GroupName="selectedPayment" AutoPostBack="true" OnCheckedChanged="radiobutton_CheckedChanged" /><br />
    <asp:Image ID="Image0" runat="server" SkinID="visa" AlternateText="Visa" />
    <asp:Image ID="Image1" runat="server" SkinID="mc" AlternateText="MasterCard" />
    <asp:Image ID="Image2" runat="server" SkinID="amex" AlternateText="Amex" />
    <asp:Image ID="Image3" runat="server" SkinID="discover" AlternateText="Discover" />
    <asp:Image ID="Image4" runat="server" SkinID="paypal" AlternateText="Paypal" /><br /><br />
    <dashCommerce:RadioButton ID="rbCreditCards" runat="server" GroupName="selectedPayment" AutoPostBack="true" OnCheckedChanged="radiobutton_CheckedChanged" /><br />
    <asp:Image ID="Image5" runat="server" SkinID="visa" AlternateText="Visa" />
    <asp:Image ID="Image6" runat="server" SkinID="mc" AlternateText="MasterCard" />
    <asp:Image ID="Image7" runat="server" SkinID="amex" AlternateText="Amex" />
    <asp:Image ID="Image8" runat="server" SkinID="discover" AlternateText="Discover" />
    <br /><br />
    <dashCommerce:Label ID="lblAdditionalPaymentMethods" runat="server" />
    <div class="rightAlign">
      <dashCommerce:Button ID="btnNext" runat="server" OnClick="btnNext_Click" />
    </div>
  </dashCommerce:Panel>
  
  <dashCommerce:Panel ID="pnlAcceptCreditCardsWithPayPal" runat="server" Visible="false">
    <table border="0" id="paymentselection">
      <tr>
        <td valign="top" width="50%" >
          <dashCommerce:Panel ID="pnlPayPalWebsitePaymentsStandard" runat="server">
            <br />
            <div class="hilite">
              <dashCommerce:Label ID="lblPayPalWebsitePaymentsStandard" runat="server" Font-Size="Medium" />
            </div>
            <ul>
              <li>Accept Visa, MasterCard, American Express, Discover, PayPal and more at one low rate.</li>
              <li>Buyers enter credit card information on secure PayPal pages and immediately return to your site. Your buyers <i>do not</i> need a PayPal account.</li>
              <li>Start selling as soon as you sign up.</li>
            </ul>
            <u>Pricing:</u>
            <ul>
              <li>No monthly fees.</li>
              <li>No setup of cancellation fees.</li>
              <li>Transaction Fees: 1.9% - 2.9% + $0.30 USD (based on sales volume)</li>
            </ul>
            <br />
            <br />
            <br />
            <div class="rightAlign">
              <dashCommerce:HyperLink ID="hlPayPalWebsitePaymentsStandard" runat="server" NavigateUrl="~/admin/paymentselection.aspx?step=2&selection=wps" SkinID="biglink" />
            </div>
          </dashCommerce:Panel>
        </td>
        <td valign="top" width="50%">
          <dashCommerce:Panel ID="pnlPayPalPro" runat="server">
            <br />
            <div class="hilite">
              <dashCommerce:Label ID="lblPayPalPro" runat="server" Font-Size="Medium" />
            </div>
            <ul>
              <li>Accept Visa, MasterCard, American Express, Discover, PayPal and more at one low rate.</li>
              <li>Buyers enter credit card information on secure PayPal pages and immediately return to your site. Your buyers <i>do not</i> need a PayPal account.</li>
              <li>Business credit application required to start selling. Decision usually comes withing 24 hours.</li>
              <li>Includes Virtual Terminal - accept payment for orders taken via the phone, fax and email.</li>
            </ul>
            <u>Pricing:</u>
            <ul>
              <li>$30 per month.</li>
              <li>No setup of cancellation fees.</li>
              <li>Transaction Fees: 2.2% - 2.9% + $0.30 USD (based on sales volume)</li>
            </ul>
            <div class="rightAlign">
              <dashCommerce:HyperLink ID="hlPayPalPro" runat="server" NavigateUrl="~/admin/paymentselection.aspx?step=2&selection=pro" SkinID="biglink" />
            </div>                        
          </dashCommerce:Panel>
        </td>        
      </tr>
    </table>
  </dashCommerce:Panel>
  
  <dashCommerce:Panel ID="pnlAcceptCreditCardsWithoutPayPal" runat="server" Visible="false">
    <dashCommerce:RadioButton ID="rbAllInOne" runat="server" GroupName="acceptCreditCards" AutoPostBack="true" OnCheckedChanged="acceptCreditCards_CheckedChanged" /><br />
    &nbsp;<asp:RadioButtonList ID="rblAllInOne" runat="server" SkinId="smallradiobuttonlist"/><br />
    <dashCommerce:RadioButton ID="rbExisting" runat="server" GroupName="acceptCreditCards" AutoPostBack="true" OnCheckedChanged="acceptCreditCards_CheckedChanged" /><br />
    &nbsp;<asp:RadioButtonList ID="rblExisting" runat="server" SkinId="smallradiobuttonlist"/><br />
    <br /><br />
    <div class="rightAlign">
      <dashCommerce:Button ID="btnPrevious" runat="server" OnClick="btnPrevious1_Click" />&nbsp;<dashCommerce:Button ID="btnNext1" runat="server" OnClick="btnNext1_Click" />
    </div>
  </dashCommerce:Panel>
  
</dashCommerce:Panel>
