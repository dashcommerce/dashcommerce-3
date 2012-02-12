<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="paypalcheckout.aspx.cs" Inherits="MettleSystems.dashCommerce.Web.paypalcheckout" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/site.master" %>
<%@ Register TagPrefix="dashCommerce" TagName="Navigation" Src="~/controls/navigation/storenavigation.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="AddressDisplay" Src="~/controls/addressdisplay.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="Address" Src="~/controls/address.ascx" %>
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
        <dashCommerce:Panel ID="pnlBillingAddressDisplayTitle" runat="server" SkinId="accordionHeader">
          <dashCommerce:Label ID="lblBillingAddressTitle" runat="server" />
        </dashCommerce:Panel>
        <span />
        <dashCommerce:Panel ID="pnlBillingAddressDisplay" runat="server" SkinId="checkoutRightPanel">
          <dashCommerce:AddressDisplay ID="billingAddressDisplay" runat="server" />
        </dashCommerce:Panel>
        <dashCommerce:Panel ID="pnlShippingAddressDisplayTitle" runat="server" SkinId="accordionHeader">
          <dashCommerce:Label ID="lblShippingAddressTitle" runat="server" />
        </dashCommerce:Panel>
        <span />
        <dashCommerce:Panel ID="pnlShippingAddressDisplay" runat="server" SkinId="checkoutRightPanel">
          <dashCommerce:AddressDisplay ID="shippingAddressDisplay" runat="server" />
        </dashCommerce:Panel>
        <dashCommerce:Panel ID="pnlShippingMethodDisplayTitle" runat="server" SkinId="accordionHeader">
          <dashCommerce:Label ID="lblShippingMethodTitle" runat="server" />
        </dashCommerce:Panel>
        <span />
        <dashCommerce:Panel ID="pnlShippingMethodDisplay" runat="server" SkinId="checkoutRightPanel">
          <dashCommerce:Label ID="lblShippingMethodDisplay" runat="server" />
        </dashCommerce:Panel>
        <dashCommerce:Panel ID="pnlCouponInformationDisplayTitle" runat="server" SkinId="accordionHeader">
          <dashCommerce:Label ID="lblCouponInformationTitle" runat="server" />
        </dashCommerce:Panel>
        <span />
        <dashCommerce:Panel ID="pnlCouponInformationDisplay" runat="server" SkinId="checkoutRightPanel">
          <dashCommerce:Label ID="lblCouponInformationDisplay" runat="server" />
        </dashCommerce:Panel>
        <asp:CollapsiblePanelExtender ID="cpeBillingAddressDisplay" BehaviorID="cpeBillingAddressDisplay" runat="server" TargetControlID="pnlBillingAddressDisplay" ExpandControlID="pnlBillingAddressDisplayTitle" CollapseControlID="pnlBillingAddressDisplayTitle" ExpandDirection="Vertical" Collapsed="true" CollapsedSize="0" AutoExpand="false" />
        <asp:CollapsiblePanelExtender ID="cpeShippingAddressDisplay" BehaviorID="cpeShippingAddressDisplay" runat="server" TargetControlID="pnlShippingAddressDisplay" ExpandControlID="pnlShippingAddressDisplayTitle" CollapseControlID="pnlShippingAddressDisplayTitle" ExpandDirection="Vertical" Collapsed="true" CollapsedSize="0" AutoExpand="false" />
        <asp:CollapsiblePanelExtender ID="cpeShippingMethodDisplay" BehaviorID="cpeShippingMethodDisplay" runat="server" TargetControlID="pnlShippingMethodDisplay" ExpandControlID="pnlShippingMethodDisplayTitle" CollapseControlID="pnlShippingMethodDisplayTitle" ExpandDirection="Vertical" Collapsed="true" CollapsedSize="0" AutoExpand="false" />
        <asp:CollapsiblePanelExtender ID="cpeCouponInformationDisplay" BehaviorID="cpeCouponInformationDisplay" runat="server" TargetControlID="pnlCouponInformationDisplay" ExpandControlID="pnlCouponInformationDisplayTitle" CollapseControlID="pnlCouponInformationDisplayTitle" ExpandDirection="Vertical" Collapsed="true" CollapsedSize="0" AutoExpand="false" />
      </div>
      <div id="threeColumnMainContent">
        <asp:Accordion ID="acCheckout" runat="server" FadeTransitions="true" TransitionDuration="750" FramesPerSecond="50" 
            RequireOpenedPane="true" HeaderCssClass="accordionHeader" ContentCssClass="accordionContent" Width="100%">
          <Panes>
            <asp:AccordionPane ID="acpBillingAddress" runat="server">
              <Header>
                  <dashCommerce:Label ID="lblBillingInformation" runat="server" />
              </Header>
              <Content>
                <dashCommerce:Address ID="billingAddress" runat="server" AddressType="BillingAddress" />
                <dashCommerce:CheckBox ID="chkUseForShipping" runat="server" CssClass="label" />
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
                  <dashCommerce:Button ID="btnShippingAddress" runat="server" OnClick="btnShippingAddress_Click" CausesValidation="true" ValidationGroup="shippingAddress" />
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
                  <dashCommerce:Button ID="btnShippingMethod" runat="server" CssClass="button" OnClick="btnShippingMethod_Click" />
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
            <asp:AccordionPane ID="acpOrderReview" runat="server">
              <Header>
                <dashCommerce:Label ID="lblOrderReview" runat="server" />
              </Header>
              <Content>
                <dashCommerce:OrderSummary ID="orderSummary" runat="server" IsEditable="false" />
                <hr />
                <div class="rightAlign">
                  <dashCommerce:Button ID="btnProcessOrder" runat="server" OnClick="btnProcessOrder_Click" CssClass="button" OnClientClick="this.style.display='none'" Enabled="false"/>
                </div>
              </Content>
            </asp:AccordionPane>        
          </Panes>
        </asp:Accordion>
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
