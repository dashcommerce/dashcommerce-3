<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="rsslist.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.admin.controls.rsslist" %>
<%@ OutputCache Duration="3600" VaryByParam="none" %>

<dashCommerce:Label ID="lblFeedTitle" runat="server" SkinID="smalllabel" />&nbsp;::&nbsp;<dashCommerce:Label ID="lblFeedDescription" runat="server" SkinID="smalllabel" />
<br />
<br />
<div id="news">
  <table class="feedTable">
  <asp:Repeater ID="Repeater1" runat="server">
      <ItemTemplate>
          <tr>
              <td class="rssFeedLink">
                  <a target="article" href='<%# DataBinder.Eval(Container.DataItem, "link") %>'>
                   <%# DataBinder.Eval(Container.DataItem, "title") %> </a>
               </td>

          </tr>
          <tr>
               <td class="rssFeedDescription">
                  <span><%# DataBinder.Eval(Container.DataItem, "description") %></span>
               </td>
          </tr>
      </ItemTemplate>
  </asp:Repeater>
  </table>
</div>
<div class="rightAlign">
  <dashCommerce:HyperLink ID="rssLink" runat="server" NavigateUrl=""><asp:Image ID="rssImage" runat="server" SkinID="rssReflect" /></dashCommerce:HyperLink>
</div>

