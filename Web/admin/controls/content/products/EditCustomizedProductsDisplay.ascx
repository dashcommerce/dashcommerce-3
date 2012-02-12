<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditCustomizedProductsDisplay.ascx.cs"
    Inherits="MettleSystems.dashCommerce.Web.admin.controls.content.products.EditCustomizedProductsDisplay" %>
    

<div>
    <dashCommerce:Label ID="lblSelectDisplayCategory" runat="server" Text="Select a Display Category"></dashCommerce:Label>
    <br />
<%--    <asp:UpdatePanel runat="server" UpdateMode="Always" ChildrenAsTriggers="true" RenderMode="Inline">
        <ContentTemplate>
--%>            <asp:DropDownList ID="ddlDisplayTypes" runat="server" AutoPostBack="True" DataTextField="Name"
                DataValueField="CustomizedProductDisplayTypeId" Height="20px" OnSelectedIndexChanged="ddlDisplayTypes_SelectedIndexChanged"
                Width="200px">
            </asp:DropDownList>
            &nbsp;
            <asp:TextBox ID="txtContent" runat="server" Width="139px"></asp:TextBox>
            &nbsp;<dashCommerce:Button ID="btnAddCustomizedProductDisplayType" runat="server" OnClick="btnAddContent_Click"
                Text="Add Display Type" />
            <br />
            </div>
            <div>
                <table>
                    <tr>
                        <td>
                            <asp:ListBox ID="lbAllItems" runat="server" Height="177px" Width="250px" DataTextField="Name"
                                DataValueField="ProductId" SelectionMode="Multiple"></asp:ListBox>
                        </td>
                        <td>
                            <div style="text-align: center;">
                                <dashCommerce:Button ID="btnAddToList" runat="server" OnClick="btnAddToList_Click" Text=">>" />
                                <br />
                                <dashCommerce:Button ID="btnRemoveFromList" runat="server" OnClick="btnRemoveFromList_Click"
                                    Text="<<" /></div>
                        </td>
                        <td>
                            <asp:ListBox ID="lbAddedItems" SelectionMode="Multiple" runat="server" Height="177px"
                                Width="250px"></asp:ListBox>
                        </td>
                    </tr>
                </table>
                <dashCommerce:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
<%--        </ContentTemplate>
        <Triggers><asp:PostBackTrigger ControlID="btnSave" /></Triggers>
    </asp:UpdatePanel>
--%></div>
