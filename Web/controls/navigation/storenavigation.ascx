<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="storenavigation.ascx.cs" Inherits="MettleSystems.dashCommerce.Web.controls.navigation.leftnavigation" EnableViewState="false" %>
<%@ Register TagPrefix="dashCommerce" TagName="CategoryNavigation" Src="~/controls/navigation/categoryNavigation.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="FavoriteProducts" Src="~/controls/navigation/favoriteproducts.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="FavoriteCategories" Src="~/controls/navigation/favoritecategories.ascx" %>
<%@ Register TagPrefix="dashCommerce" TagName="AcceptedPayment" Src="~/controls/navigation/acceptedPayment.ascx" %>

<dashCommerce:CategoryNavigation ID="categoryNavigation" runat="server" />
<dashCommerce:FavoriteProducts ID="favoriteProducts" runat="server" />
<dashCommerce:FavoriteCategories ID="favoriteCategories" runat="server" />
<dashCommerce:AcceptedPayment ID="acceptedPayment" runat="server" />
