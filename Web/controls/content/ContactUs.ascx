<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.controls.content.ContactUs" %>


<div id="contentRegion" class="contentRegion" style="width:100px">
    <table>
        <tr>
            <td>
                <dashCommerce:Label ID="lblName" runat="server" AssociatedControlID="txtName" CssClass="label"></dashCommerce:Label>
                <asp:TextBox ID="txtName" runat="server"  CssClass="longtextbox"></asp:TextBox><br />
            </td>
        </tr>
        <tr>
            <td>
                <dashCommerce:Label ID="lblEmailAddress" runat="server" AssociatedControlID="txtEmail" CssClass="label"></dashCommerce:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="longtextbox"></asp:TextBox>
                <dashCommerce:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="*" /><br />
            </td>
        </tr>
        <tr>
            <td>
                <dashCommerce:Label ID="lblSubject" runat="server" AssociatedControlID="txtSubject" CssClass="label"></dashCommerce:Label>
                <asp:TextBox ID="txtSubject" runat="server" CssClass="longtextbox"></asp:TextBox>
                <dashCommerce:RequiredFieldValidator ID="rfvSubject" runat="server" ControlToValidate="txtSubject" Display="Dynamic" ErrorMessage="*" /><br />
            </td>
        </tr>
        <tr>
            <td>
                <dashCommerce:Label ID="lblEmail" runat="server" AssociatedControlID="txtMessage" CssClass="label"></dashCommerce:Label><br />
                <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" CssClass="largemultilinetextbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <dashCommerce:Button ID="btnSend" runat="server" OnClick="btnSend_Click"/> 
                <span style="color:Red; font-weight:bold"><dashCommerce:Label ID="lblSent" runat="server" Visible="false" /></span>
            </td>   
        </tr>
    </table>
</div>