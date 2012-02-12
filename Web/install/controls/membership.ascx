<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="membership.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.install.controls.membership" %>


<dashCommerce:Panel ID="pnlMembershipSetup" runat="server">
 <dashCommerce:Label ID="lblMembershipInstructions" runat="server" CssClass="label" />
  <table border="0">
    <tr>
      <td>
        <dashCommerce:Label ID="lblUsername" runat="server" Text="Username:" /><br />
        <asp:TextBox ID="txtUsername" runat="server" CssClass="textbox" Width="150px" TabIndex="1" /><br />
        <br />
      </td>
      <td>
        <dashCommerce:Label ID="lblEmail" runat="server" Text="Email:" /><br />
        <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" Width="150px"  TabIndex="4"/><br />
        <br />
      </td>
    </tr>
    <tr>
      <td>
        <dashCommerce:Label ID="lblPassword" runat="server" Text="Password:" /><br />
        <asp:TextBox ID="txtPassword" runat="server" CssClass="textbox" Width="150px" TabIndex="2" /><br />
        <br />
      </td>
      <td>
        <dashCommerce:Label ID="lblConfirmEmail" runat="server" Text="Confirm Email:"></dashCommerce:Label><br />
        <asp:TextBox ID="txtConfirmEmail" runat="server" CssClass="textbox" Width="150px" TabIndex="5"/><br />
        <br />
      </td>
    </tr>
    <tr>
      <td>
        <dashCommerce:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:" /><br />
        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="textbox" Width="150px" TabIndex="3" /><br />
        <br />
      </td>
      <td>
        <dashCommerce:Label ID="lblSecurityQuestion" runat="server" Text="Security Question:"></dashCommerce:Label><br />
        <asp:TextBox ID="txtSecurityQuestion" runat="server" CssClass="textbox" Width="150px"  TabIndex="6"/><br />
        <br />
      </td>
    </tr>
    <tr>
      <td>
      </td>
      <td>
        <dashCommerce:Label ID="lblSecurityAnswer" runat="server" Text="Security Answer:"></dashCommerce:Label><br />
        <asp:TextBox ID="txtSecurityAnswer" runat="server" CssClass="textbox" Width="150px"  TabIndex="7"/><br />
        <br />
      </td>
    </tr>
  </table>
  <dashCommerce:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername"
  ErrorMessage="Please supply a Username." Display="None" />
  <dashCommerce:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
  ErrorMessage="Please supply a Password." Display="None" />
  <dashCommerce:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
  ErrorMessage="Please supply a Confirm Password." Display="None" />
  <dashCommerce:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
  ErrorMessage="Please supply an Email." Display="None" />
  <dashCommerce:RequiredFieldValidator ID="rfvConfirmEmail" runat="server" ControlToValidate="txtConfirmEmail"
  ErrorMessage="Please supply a Confirm Email." Display="None" />
  <dashCommerce:RequiredFieldValidator ID="rfvSecurityQuestion" runat="server" ControlToValidate="txtSecurityQuestion"
  ErrorMessage="Please supply a Security Question." Display="None" />
  <dashCommerce:RequiredFieldValidator ID="rfvSecurityAnswer" runat="server" ControlToValidate="txtSecurityAnswer"
  ErrorMessage="Please supply a Security Answer." Display="None" />
  <asp:CompareValidator ID="cmpPassword" runat="server" ControlToValidate="txtPassword"
  ControlToCompare="txtConfirmPassword" ErrorMessage="Passwords do not match." Display="None" />
  <asp:CompareValidator ID="cmpEmail" runat="server" ControlToValidate="txtEmail"
  ControlToCompare="txtConfirmEmail" ErrorMessage="Emails do not match." Display="None" />            
 <div class="rightAlign">
   <dashCommerce:Button ID="btnPrevious" runat="server" CssClass="button" OnClick="btnPrevious_Click" CausesValidation="false"/>&nbsp;&nbsp;&nbsp;&nbsp;<dashCommerce:Button ID="btnNext" runat="server" CssClass="button" OnClick="btnNext_Click"/>
 </div>
</dashCommerce:Panel>