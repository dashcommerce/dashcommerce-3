<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="address.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.controls.address" %>
<table>
  <tr>
    <td colspan="2">
      <asp:DropDownList ID="ddlAddress" runat="server" CssClass="dropdownlist" /><dashCommerce:RequiredFieldValidator ID="rfvAddress" runat="server" Display="Dynamic" ControlToValidate="ddlAddress" ErrorMessage="*" />&nbsp;&nbsp;<dashCommerce:LinkButton ID="lbAddNew" runat="server" CssClass="button" OnClick="lbAddNew_Click" />
    </td>
  </tr>
</table>
<dashCommerce:Panel ID="pnlNewAddress" runat="server" Visible="false">
  <dashCommerce:Panel ID="pnlAddNew" runat="server">
    <dashCommerce:LinkButton ID="btnCancelAddNew" runat="server" OnClick="btnCancelAddNew_Click" CssClass="button" />
    <br />
    <br />
  </dashCommerce:Panel>
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
        <dashCommerce:Label ID="lblEmail" runat="server" CssClass="label" /><br />
        <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" /><dashCommerce:RequiredFieldValidator ID="rfvEmail" runat="server" Display="Dynamic" ControlToValidate="txtEmail" ErrorMessage="*" />    
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
        <asp:TextBox ID="txtStateOrRegion" runat="server" CssClass="textbox" /><dashCommerce:RequiredFieldValidator ID="rfvStateOrRegion" runat="server" Display="Dynamic" ControlToValidate="txtStateOrRegion" ErrorMessage="*" />
        <asp:DropDownList ID="ddlStateOrRegion" runat="server" CssClass="dropdownlist" Visible="false" />
      </td>
    </tr>
    <tr>
      <td>
        <dashCommerce:Label ID="lblPostalCode" runat="server" CssClass="label" /><br />
        <asp:TextBox ID="txtPostalCode" runat="server" CssClass="textbox" /><dashCommerce:RequiredFieldValidator ID="rfvPostalCode" runat="server" ControlToValidate="txtPostalCode" Display="Dynamic" ErrorMessage="*" />
      </td>
      <td>
        <dashCommerce:Label ID="lblCountry" runat="server" /><br />
        <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_Changed" /><dashCommerce:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry" Display="Dynamic" ErrorMessage="*" />
      </td>
    </tr>
  </table>
</dashCommerce:Panel>