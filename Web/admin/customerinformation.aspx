<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="customerinformation.aspx.cs" EnableEventValidation="true" Inherits="MettleSystems.dashCommerce.Web.admin.customerinformation" %>
<%@ MasterType VirtualPath="~/admin/admin.master" %>
<%@ Register TagPrefix="dashCommerce" TagName="AddressDisplay" Src="~/controls/addressdisplay.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="mainContentRegion">
    <div id="admin_centercontent">
      <div class="sectionHeader"><dashCommerce:Label ID="lblCustomerInformation" runat="server" /></div><br />
      <asp:UpdatePanel ID="upWrapper" runat="server" UpdateMode="Always" RenderMode="Inline" >
          <ContentTemplate>
            <div><dashCommerce:Label ID="lblCustomerId" runat="server" CssClass="label" />
                 <asp:DropDownList ID="ddlCustomer" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged" ></asp:DropDownList>
            </div>
            <br />
              <asp:TabContainer ID="tcMyAccount" runat="server" Height="300px" ScrollBars="Vertical" CssClass="ajax__tab_technorati-theme" Visible="false">
                <asp:TabPanel ID="tpUserInfo" runat="server" HeaderText="About" >
                  <ContentTemplate>                    
                      <dashCommerce:Panel ID="pnlUser" runat="server">
                      <dashCommerce:Label ID="lblUserName" runat="server" CssClass="label" /><br />
                      <dashCommerce:Label ID="lblUserNameDisplay" runat="server" CssClass="label" /><br /><br />
                      <dashCommerce:Label ID="lblPassword" runat="server" CssClass="label" /><br />
                      <dashCommerce:LinkButton ID="lbChangePassword" runat="server" CssClass="label" OnClick="lbChangePassword_Click" /><br /><br />
                      <dashCommerce:Label ID="lblEmail" runat="server" CssClass="label" /><br />
                      <dashCommerce:Label ID="lblEmailDisplay" runat="server" CssClass="label" />&nbsp;&nbsp;<dashCommerce:LinkButton ID="lbChangeEmail" runat="server" CssClass="label" OnClick="lbChangeEmail_Click" /><br /><br />
                    </dashCommerce:Panel>
                    <!-- //TODO: CMC - This control needs localization -->
                    <dashCommerce:Panel ID="pnlChangePassword" runat="server" Visible="false">
                      <asp:ChangePassword ID="cpChangePassword" runat="server" OnCancelButtonClick="HideChangePassword" OnContinueButtonClick="HideChangePassword" >
                        <CancelButtonStyle CssClass="button" />
                        <ContinueButtonStyle CssClass="button" />
                        <ChangePasswordButtonStyle CssClass="button" />
                      </asp:ChangePassword>
                    </dashCommerce:Panel>
                    <dashCommerce:Panel ID="pnlChangeEmail" runat="server" Visible="false">
                      <dashCommerce:Label ID="lblPasswordChange" runat="server" CssClass="label" /><br />
                      <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="textbox" /><dashCommerce:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" /><br /><br />
                      <dashCommerce:Label ID="lblEmailChange" runat="server" CssClass="label" /><br />
                      <asp:TextBox ID="txtEmail" TextMode="SingleLine" runat="server" CssClass="textbox" /><dashCommerce:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="*" /><br /><br />
                      <dashCommerce:Label ID="lblEmailConfirmation" runat="server" CssClass="label" /><br />
                      <asp:TextBox ID="txtEmailConfirmation" TextMode="SingleLine" runat="server" CssClass="textbox" /><dashCommerce:RequiredFieldValidator ID="rfvEmailConfirmation" runat="server" ControlToValidate="txtEmailConfirmation" ErrorMessage="*" /><br /><br />
                      <asp:CompareValidator ID="cvEmailAddresses" runat="server" ControlToCompare="txtEmailConfirmation" ControlToValidate="txtEmail" Type="String" CssClass="label" />
                      <dashCommerce:Button ID="btnCancel" runat="server" CssClass="button" CausesValidation="False" OnClick="btnEmailCancel_Click" />&nbsp;
                      <dashCommerce:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnEmailSave_Click" />
                    </dashCommerce:Panel>            
                  </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="tpMyOrders" runat="server"  HeaderText="My Orders">
                  <ContentTemplate>
                   <dashCommerce:Panel ID="pnlMyOrders" runat="server">
                      <dashCommerce:DataGrid ID="dgOrders" runat="server" AutoGenerateColumns="false" SkinID="adminDataGridNoPage" Width="95%">
                        <Columns>
                          <asp:TemplateColumn>
                            <ItemTemplate>
                              <dashCommerce:HyperLink ID="hlEditLink" runat="server" NavigateUrl='<%# FormatEditUrl(Eval("OrderId").ToString()) %>'  />
                            </ItemTemplate>
                          </asp:TemplateColumn>
                          <asp:BoundColumn DataField="OrderNumber" />
                          <asp:TemplateColumn>
                            <ItemTemplate>
                              <%# GetFormattedAmount(Eval("Total").ToString()) %>
                            </ItemTemplate>
                          </asp:TemplateColumn>
                          <asp:TemplateColumn>
                            <ItemTemplate>
                              <%# (Eval("OrderStatusDescriptor.Name")) %>
                            </ItemTemplate>
                          </asp:TemplateColumn>
                          <asp:BoundColumn DataField="CreatedOn" ItemStyle-Font-Size="XX-Small" />            
                        </Columns>
                      </dashCommerce:DataGrid>
                    </dashCommerce:Panel>
                  </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="tpAddresses" runat="server" HeaderText="My Addresses">
                  <ContentTemplate>
                    <dashCommerce:Panel ID="pnlBillingAddresses" runat="server" CssClass="billingAddresses">&nbsp;    
                      <asp:Repeater ID="rptrBillingAddresses" runat="server" OnItemCommand="BillingEdits">
                        <ItemTemplate>
                          <dashCommerce:AddressDisplay ID="dcBillingAddress" runat="server" />
                          <div>
                            <dashCommerce:LinkButton ID="lbEditBilling" CommandName="Edit" runat="server" CommandArgument='<%# Eval("AddressId") %>' CssClass="button" Text="Edit"  CausesValidation="false" /> | 
                            <dashCommerce:LinkButton ID="lbDeleteBilling" CommandName="Delete" runat="server" CommandArgument='<%# Eval("AddressId") %>' CssClass="button" Text="Delete"  CausesValidation="false" />
                          </div>
                          <hr />
                        </ItemTemplate>
                      </asp:Repeater>
                    </dashCommerce:Panel>
                    <dashCommerce:Panel ID="pnlShippingAddresses" runat="server" CssClass="shippingAddresses">&nbsp;    
                      <asp:Repeater ID="rptrShippingAddresses" runat="server" OnItemCommand="ShippingEdits" >
                        <ItemTemplate>
                          <dashCommerce:AddressDisplay ID="dcShippingAddress" runat="server"  />
                          <div>
                            <dashCommerce:LinkButton ID="lbEditShipping" CommandName="Edit" CommandArgument='<%# Eval("AddressId") %>' runat="server" CssClass="button" Text="Edit" CausesValidation="false" /> | 
                            <dashCommerce:LinkButton ID="lbDeleteShipping" CommandName="Delete" CommandArgument='<%# Eval("AddressId") %>' runat="server" CssClass="button" Text="Delete" CausesValidation="false" />
                          </div>
                          <hr />
                        </ItemTemplate>
                      </asp:Repeater>
                    </dashCommerce:Panel>
                    <dashCommerce:Panel ID="pnlEditAddress" runat="server" Visible="false" CssClass="twelve">
                    <table>
                        <tr>
                          <td>
                            <dashCommerce:Label ID="lblAddressId" runat="server" Visible="false" />
                            <dashCommerce:Label ID="lblFirstName" runat="server" CssClass="label" /><br />
                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="textbox" /><dashCommerce:RequiredFieldValidator ID="rfvFirstName" runat="server" Display="Dynamic" ControlToValidate="txtFirstName" ErrorMessage="*" />
                          </td>
                          <td>
                            <dashCommerce:Label ID="lblLastName" runat="server" CssClass="label" /><br />
                            <asp:TextBox ID="txtLastName" runat="server" CssClass="textbox" /><dashCommerce:RequiredFieldValidator ID="rfvLastName" runat="server" Display="Dynamic" ControlToValidate="txtLastName" ErrorMessage="*" />    
                          </td>
                        </tr>
                        <tr>
                          <td>
                            <dashCommerce:Label ID="lblPhone" runat="server" CssClass="label" /><br />
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="textbox" /><dashCommerce:RequiredFieldValidator ID="rfvPhone" runat="server" Display="Dynamic" ControlToValidate="txtPhone" ErrorMessage="*" />
                          </td>
                          <td>
                            <dashCommerce:Label ID="lblEmailEdit" runat="server" CssClass="label" /><br />
                            <asp:TextBox ID="txtEmailEdit" runat="server" CssClass="textbox" /><dashCommerce:RequiredFieldValidator ID="rfvEmailEdit" runat="server" Display="Dynamic" ControlToValidate="txtEmailEdit" ErrorMessage="*" />    
                          </td>
                        </tr>
                        <tr>
                          <td colspan="2">
                            <dashCommerce:Label ID="lblAddress" runat="server" CssClass="label" /><br />
                            <asp:TextBox ID="txtAddress1" runat="server" CssClass="longtextbox" /><dashCommerce:RequiredFieldValidator ID="rfvAddress1" runat="server" Display="Dynamic" ControlToValidate="txtAddress1" ErrorMessage="*" />    
                          </td>
                        </tr>
                        <tr>
                          <td>
                            <asp:TextBox ID="txtAddress2" runat="server" CssClass="longtextbox" />    
                          </td>
                        </tr>
                        <tr>
                          <td>
                            <dashCommerce:Label ID="lblCity" runat="server" CssClass="label" /><br />
                            <asp:TextBox ID="txtCity" runat="server" CssClass="textbox" /><dashCommerce:RequiredFieldValidator ID="rfvCity" runat="server" Display="Dynamic" ControlToValidate="txtCity" ErrorMessage="*" />
                          </td>
                          <td>
                            <dashCommerce:Label ID="lblStateOrRegion" runat="server" CssClass="label" /><br />
                            <asp:TextBox ID="txtStateOrRegion" runat="server" CssClass="textbox" Visible="false" /><dashCommerce:RequiredFieldValidator ID="rfvStateOrRegion" runat="server" Display="Dynamic" ControlToValidate="txtStateOrRegion" ErrorMessage="*" Enabled="false" />
                            <asp:DropDownList ID="ddlStateOrRegion" runat="server" CssClass="dropdownlist" Visible="true" />
                          </td>
                        </tr>
                        <tr>
                          <td>
                            <dashCommerce:Label ID="lblPostalCode" runat="server" CssClass="label" /><br />
                            <asp:TextBox ID="txtPostalCode" runat="server" CssClass="textbox" /><dashCommerce:RequiredFieldValidator ID="rfvPostalCode" runat="server" ControlToValidate="txtPostalCode" Display="Dynamic" ErrorMessage="*" />
                          </td>
                          <td>
                            <dashCommerce:Label ID="lblCountry" runat="server" CssClass="label" /><br />
                            <asp:DropDownList ID="ddlCountry" runat="server" CssClass="dropdownlist" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_Changed" /><dashCommerce:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry" Display="Dynamic" ErrorMessage="*" />    
                          </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:HiddenField ID="hfAddressId" runat="server" />
                                <asp:HiddenField ID="hfAddressType" runat="server" />
                                <dashCommerce:LinkButton ID="lbUpdateAddress" runat="server" CssClass="button" OnClick="lbUpdateAddress_Click" Text="Update" /> |
                                <dashCommerce:LinkButton ID="lbCancelAddressEdit" runat="server" CssClass="button" OnClick="lbCancelAddressEdit_Click" Text="Cancel" />                            
                            </td>
                        </tr>
                      </table>
                    </dashCommerce:Panel>
                  </ContentTemplate>
                </asp:TabPanel>
              </asp:TabContainer>
          </ContentTemplate>
      </asp:UpdatePanel>
    </div>
  </div>  
</asp:Content>
