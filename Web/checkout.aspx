<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" Codebehind="checkout.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.checkout" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/site.master" %>
<%@ Register TagPrefix="dashCommerce" TagName="Navigation" Src="~/controls/navigation/storenavigation.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="Address" Src="~/controls/address.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="AddressDisplay" Src="~/controls/addressdisplay.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="OrderSummary" Src="~/controls/ordersummary.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <script language="javascript" type="text/javascript">
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_initializeRequest(InitializeRequest);
    prm.add_endRequest(EndRequest);
    
    var trigger;
    
    function InitializeRequest(sender, args){
      trigger = args.get_postBackElement().id;
    }
    
    function EndRequest(sender, args) {
      if(args.get_error() != undefined) {
        var errorMessage = args.get_error().message;
        args.set_errorHandled(true);
        var btnProcessOrder = document.getElementById("<%= btnProcessOrder.ClientID %>");
        if(btnProcessOrder != null) {
          if(btnProcessOrder.disabled) {
            btnProcessOrder.disabled = false;
          }
        }
        showPopWin("modal.aspx?isEx=true", 450, 150, null, true);
      }
      else {
        switch(trigger){
          case "<%= btnBillingAddress.ClientID %>":
            if(<%= shippingService.ShippingServiceSettings.UseShipping.ToString().ToLower() %>) {
              changeCollapse("<%= cpeBillingAddressDisplay.ID %>");      
              checkUseForShipping("<%= cpeShippingAddressDisplay.ID %>");
            }
            else {
              changeCollapse("<%= cpeBillingAddressDisplay.ID %>");
            }
            break;
          case "<%= btnShippingAddress.ClientID %>":
            changeCollapse("<%= cpeShippingAddressDisplay.ID %>");
            break;
          case "<%= btnShippingMethod.ClientID %>":
            changeCollapse("<%= cpeShippingMethodDisplay.ID %>");
            break;
          case "<%= btnCoupon.ClientID %>":
            changeCollapse("<%= cpeCouponInformationDisplay.ID %>");
            break;
          case "<%= btnPaymentMethod.ClientID %>":
            changeCollapse("<%= cpePaymentInformationDisplay.ID %>");
            break;
        }
      }
    }

    function changeIndex() {
      //TODO: CMC - try/catch
      var accHost = $find('<%= acCheckout.ClientID %>_AccordionExtender');
      var i = accHost.get_SelectedIndex() + 1;
      accHost.set_SelectedIndex(i);
    }
    
    function changeCollapse(thename){
      //TODO: CMC - try/catch
      $find(thename).set_Collapsed(false);
    }
    
    function checkUseForShipping(thename){
      var obj = document.getElementById("<%= chkUseForShipping.ClientID %>");
      if(obj != null) {
        if(obj.checked){
          changeCollapse(thename);
        }
      }
    }
  </script>
  <div id="threeColumnLeftContent">
    <dashCommerce:Navigation ID="leftNavigation" runat="server" />
  </div>
  <asp:UpdateProgress ID="upDisplay" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upCheckout" DisplayAfter="100" />
  <asp:UpdatePanel ID="upCheckout" runat="server">
    <ContentTemplate>
    <div id="threeColumnRightContent">
      <dashCommerce:Panel ID="pnlBillingAddressDisplayTitle" runat="server" CssClass="accordionHeader">
        <dashCommerce:Label ID="lblBillingAddressTitle" runat="server" />
      </dashCommerce:Panel>
      <span />
      <dashCommerce:Panel ID="pnlBillingAddressDisplay" runat="server" CssClass="checkoutRightPanel">
        <dashCommerce:AddressDisplay ID="billingAddressDisplay" runat="server" />
      </dashCommerce:Panel>
      <dashCommerce:Panel ID="pnlShippingAddressDisplayTitle" runat="server" CssClass="accordionHeader">
        <dashCommerce:Label ID="lblShippingAddressTitle" runat="server" />
      </dashCommerce:Panel>
      <span />
      <dashCommerce:Panel ID="pnlShippingAddressDisplay" runat="server" CssClass="checkoutRightPanel">
        <dashCommerce:AddressDisplay ID="shippingAddressDisplay" runat="server" />
      </dashCommerce:Panel>
      <dashCommerce:Panel ID="pnlShippingMethodDisplayTitle" runat="server" CssClass="accordionHeader">
        <dashCommerce:Label ID="lblShippingMethodTitle" runat="server" />
      </dashCommerce:Panel>
      <span />
      <dashCommerce:Panel ID="pnlShippingMethodDisplay" runat="server" CssClass="checkoutRightPanel">
        <dashCommerce:Label ID="lblShippingMethodDisplay" runat="server" />
      </dashCommerce:Panel>
      <dashCommerce:Panel ID="pnlCouponInformationDisplayTitle" runat="server" CssClass="accordionHeader">
        <dashCommerce:Label ID="lblCouponInformationTitle" runat="server" />
      </dashCommerce:Panel>
      <span />
      <dashCommerce:Panel ID="pnlCouponInformationDisplay" runat="server" CssClass="checkoutRightPanel">
        <dashCommerce:Label ID="lblCouponInformationDisplay" runat="server" />
      </dashCommerce:Panel>
      <dashCommerce:Panel ID="pnlPaymentInformationDisplayTitle" runat="server" CssClass="accordionHeader">
        <dashCommerce:Label ID="lblPaymentInformationTitle" runat="server" />
      </dashCommerce:Panel>
      <span />
      <dashCommerce:Panel ID="pnlPaymentInformationDisplay" runat="server" CssClass="checkoutRightPanel">
        <dashCommerce:Label ID="lblCreditCardType" runat="server" /><br />
        <dashCommerce:Panel ID="pnlCreditCardInfo" runat="server">
          <dashCommerce:Label ID="lblMaskedCreditCardNumber" runat="server" /><br />
          <dashCommerce:Label ID="lblCreditCardExpirationDate" runat="server" />
        </dashCommerce:Panel>
      </dashCommerce:Panel>
          
      <asp:CollapsiblePanelExtender  ID="cpeBillingAddressDisplay" BehaviorID="cpeBillingAddressDisplay" runat="server" TargetControlID="pnlBillingAddressDisplay" ExpandControlID="pnlBillingAddressDisplayTitle" CollapseControlID="pnlBillingAddressDisplayTitle" ExpandDirection="Vertical" Collapsed="true" CollapsedSize="0" AutoExpand="false" />
      <asp:CollapsiblePanelExtender  ID="cpeShippingAddressDisplay" BehaviorID="cpeShippingAddressDisplay" runat="server" TargetControlID="pnlShippingAddressDisplay" ExpandControlID="pnlShippingAddressDisplayTitle" CollapseControlID="pnlShippingAddressDisplayTitle" ExpandDirection="Vertical" Collapsed="true" CollapsedSize="0" AutoExpand="false" />
      <asp:CollapsiblePanelExtender  ID="cpeShippingMethodDisplay" BehaviorID="cpeShippingMethodDisplay" runat="server" TargetControlID="pnlShippingMethodDisplay" ExpandControlID="pnlShippingMethodDisplayTitle" CollapseControlID="pnlShippingMethodDisplayTitle" ExpandDirection="Vertical" Collapsed="true" CollapsedSize="0" AutoExpand="false" />
      <asp:CollapsiblePanelExtender  ID="cpeCouponInformationDisplay" BehaviorID="cpeCouponInformationDisplay" runat="server" TargetControlID="pnlCouponInformationDisplay" ExpandControlID="pnlCouponInformationDisplayTitle" CollapseControlID="pnlCouponInformationDisplayTitle" ExpandDirection="Vertical" Collapsed="true" CollapsedSize="0" AutoExpand="false" />
      <asp:CollapsiblePanelExtender  ID="cpePaymentInformationDisplay" BehaviorID="cpePaymentInformationDisplay" runat="server" TargetControlID="pnlPaymentInformationDisplay" ExpandControlID="pnlPaymentInformationDisplayTitle" CollapseControlID="pnlPaymentInformationDisplayTitle" ExpandDirection="Vertical" Collapsed="true" CollapsedSize="0" AutoExpand="false" />
    </div>
    <div id="threeColumnMainContent">
          <asp:Accordion ID="acCheckout" runat="server" FadeTransitions="true" TransitionDuration="450" FramesPerSecond="50" 
            RequireOpenedPane="true" HeaderCssClass="accordionHeader" ContentCssClass="accordionContent" Width="99%">
            <Panes>
              <asp:AccordionPane ID="acpBillingAddress" runat="server">
                <Header>
                    <dashCommerce:Label ID="lblBillingInformation" runat="server" />
                </Header>
                <Content>
                  <dashCommerce:Address ID="billingAddress" runat="server" AddressType="BillingAddress" />
                  <dashCommerce:CheckBox ID="chkUseForShipping" runat="server" />
                  <hr />
                  <div class="rightAlign">
                    <dashCommerce:Button ID="btnBillingAddress" runat="server" CssClass="button" OnClick="btnBillingAddress_Click" CausesValidation="true" ValidationGroup="billingAddress" />
                  </div>
                </Content>
              </asp:AccordionPane>
              <asp:AccordionPane ID="acpShippingAddress" runat="server">
                <Header>
                  <dashCommerce:Label ID="lblShippingInformation" runat="server" />
                </Header>
                <Content>
                  <dashCommerce:Address ID="shippingAddress" runat="server" AddressType="ShippingAddress" />
                  <hr />
                  <div class="rightAlign">
                    <dashCommerce:Button ID="btnShippingAddress" runat="server" CssClass="button" OnClick="btnShippingAddress_Click" CausesValidation="true" ValidationGroup="shippingAddress" />
                  </div>
                </Content>
              </asp:AccordionPane>
              <asp:AccordionPane ID="acpShippingMethod" runat="server">
                <Header>
                  <dashCommerce:Label ID="lblShippingMethod" runat="server" />
                </Header>
                <Content>
                  <asp:RadioButtonList ID="rblShippingOptions" runat="server" CssClass="label" />
                  <hr />
                  <div class="rightAlign">
                    <dashCommerce:Button ID="btnShippingMethod" runat="server" CssClass="button" OnClick="btnShippingMethod_Click" CausesValidation="false" />
                  </div>
                </Content>
              </asp:AccordionPane>
              <asp:AccordionPane ID="acpCoupon" runat="server">
                <Header>
                  <dashCommerce:Label ID="lblCouponInformation" runat="server" />
                </Header>
                <Content>
                  <dashCommerce:Label ID="lblCouponCode" runat="server" CssClass="label" /><br />
                  <asp:TextBox ID="txtCouponCode" runat="server" CssClass="textbox" />
                  <hr />
                  <div class="rightAlign">
                    <dashCommerce:Button ID="btnCoupon" runat="server" CssClass="button" OnClick="btnCoupon_Click" />
                  </div>
                </Content>
              </asp:AccordionPane>
              <asp:AccordionPane ID="acpPaymentInformation" runat="server">
                <Header>
                  <dashCommerce:Label ID="lblPaymentInformation" runat="server" />
                </Header>
                <Content>
                  <div style="line-height:1.7em">
                    <dashCommerce:Label ID="lblPaymentMethod" runat="server" CssClass="label" />
                    <asp:DropDownList ID="ddlCreditCardType" runat="server" OnSelectedIndexChanged="toggleCreditCardInfo" AutoPostBack="true">
                      <asp:ListItem Value="0" Selected="true">MasterCard</asp:ListItem>
                      <asp:ListItem Value="1">Visa</asp:ListItem>
                      <asp:ListItem Value="2">AMEX</asp:ListItem>
                      <asp:ListItem Value="3">Discover</asp:ListItem>
                      <asp:ListItem Value="4">PayPal</asp:ListItem>
                      <asp:ListItem Value="5">Maestro/Switch</asp:ListItem>
                      <asp:ListItem Value="6">Solo</asp:ListItem>
                    </asp:DropDownList><br />
                    <dashCommerce:Panel ID="pnlCreditCardInformation" runat="server">
                      <dashCommerce:Label ID="lblCreditCardNumber" runat="server" CssClass="label" />
                      <asp:TextBox runat="server" ID="txtCreditCardNumber" CssClass="longtextbox" />
                      <dashCommerce:RequiredFieldValidator ValidationGroup="CreditCard" ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCreditCardNumber" ErrorMessage="*" />
                      <% if(Request.IsSecureConnection || HttpContext.Current.Request.ServerVariables["HTTP_CLUSTER_HTTPS"] != "on") {%>
                        <asp:Image ID="imgSSL" runat="server" SkinID="ssl" CssClass="sslLogo" />
                      <%}%><br />
                      <dashCommerce:Label ID="lblCreditCardSecurityNumber" runat="server" CssClass="label" />
                      <asp:TextBox runat="server" ID="txtCreditCardSecurityNumber" CssClass="smalltextbox" />
                      <dashCommerce:RequiredFieldValidator ValidationGroup="CreditCard" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCreditCardSecurityNumber" ErrorMessage="*" /><br />
                      <dashCommerce:Panel ID="pnlDebitCardInformation" runat="server" Visible="false">
                        <dashCommerce:Label ID="lblIssueNumber" runat="server" CssClass="label" />
                        <asp:TextBox runat="server" ID="txtDebitCardIssueNumber" CssClass="smalltextbox" /><br />
                        <dashCommerce:Label ID="lblStart" runat="server" CssClass="label" />
                        <asp:DropDownList ID="ddlDebitCardStartMonth" runat="server" CssClass="dropdownlist" />&nbsp;<asp:DropDownList ID="ddlDebitCardStartYear" runat="server" CssClass="dropdownlist" /><br />
                      </dashCommerce:Panel>
                      <dashCommerce:Label ID="lblExpiration" runat="server" CssClass="label" />
                      <asp:DropDownList ID="ddlCreditCardExpirationMonth" runat="server" CssClass="dropdownlist" />&nbsp;<asp:DropDownList ID="ddlCreditCardExpirationYear" runat="server" CssClass="dropdownlist" />
                    </dashCommerce:Panel>
                    <hr />
                    <div class="rightAlign">
                      <dashCommerce:Button ValidationGroup="CreditCard" ID="btnPaymentMethod" runat="server" CssClass="button" OnClick="btnPaymentMethod_Click" />
                    </div>
                  </div>
                </Content>
              </asp:AccordionPane>
              <asp:AccordionPane ID="acpOrderReview" runat="server">
                <Header>
                  <dashCommerce:Label ID="lblOrderReview" runat="server" />
                </Header>
                <Content>
                  <dashCommerce:OrderSummary ID="orderSummary" runat="server" IsEditable="false" />
                  <hr />
                  <div class="rightAlign">
                    <dashCommerce:Button ID="btnProcessOrder" runat="server" OnClick="btnProcessOrder_Click" CssClass="button" OnClientClick="this.style.display='none'" Enabled="false"/><br />
                  <asp:Image ID="imgError" runat="server" SkinID="error" Visible="false" />&nbsp;<dashCommerce:Label ID="lblError" runat="server" CssClass="label" />
                  </div>
                </Content>
              </asp:AccordionPane>
            </Panes>
          </asp:Accordion>
    </div>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
