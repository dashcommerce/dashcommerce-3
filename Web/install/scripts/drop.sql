/****** Object:  ForeignKey [FK_dashCommerce_Store_DownloadAccessControl_aspnet_Users]    Script Date: 05/30/2009 19:33:40 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_DownloadAccessControl_aspnet_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_DownloadAccessControl]'))
ALTER TABLE [dbo].[dashCommerce_Store_DownloadAccessControl] DROP CONSTRAINT [FK_dashCommerce_Store_DownloadAccessControl_aspnet_Users]
GO
/****** Object:  ForeignKey [FK_dashCommerce_Store_DownloadAccessControl_dashCommerce_Store_Download]    Script Date: 05/30/2009 19:33:40 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_DownloadAccessControl_dashCommerce_Store_Download]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_DownloadAccessControl]'))
ALTER TABLE [dbo].[dashCommerce_Store_DownloadAccessControl] DROP CONSTRAINT [FK_dashCommerce_Store_DownloadAccessControl_dashCommerce_Store_Download]
GO
/****** Object:  ForeignKey [FK_dashCommerce_Store_Product_Download_Map_dashCommerce_Store_Download]    Script Date: 05/30/2009 19:33:40 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_Product_Download_Map_dashCommerce_Store_Download]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Product_Download_Map]'))
ALTER TABLE [dbo].[dashCommerce_Store_Product_Download_Map] DROP CONSTRAINT [FK_dashCommerce_Store_Product_Download_Map_dashCommerce_Store_Download]
GO
/****** Object:  ForeignKey [FK_dashCommerce_Store_Product_Download_Map_dashCommerce_Store_Product]    Script Date: 05/30/2009 19:33:40 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_Product_Download_Map_dashCommerce_Store_Product]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Product_Download_Map]'))
ALTER TABLE [dbo].[dashCommerce_Store_Product_Download_Map] DROP CONSTRAINT [FK_dashCommerce_Store_Product_Download_Map_dashCommerce_Store_Product]
GO
/****** Object:  Default [DF_dashCommerce_Store_Download_CreatedOn]    Script Date: 05/30/2009 19:33:40 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_dashCommerce_Store_Download_CreatedOn]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Download]'))
Begin
ALTER TABLE [dbo].[dashCommerce_Store_Download] DROP CONSTRAINT [DF_dashCommerce_Store_Download_CreatedOn]
End
GO
/****** Object:  Default [DF_dashCommerce_Store_Download_ModifiedOn]    Script Date: 05/30/2009 19:33:40 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_dashCommerce_Store_Download_ModifiedOn]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Download]'))
Begin
ALTER TABLE [dbo].[dashCommerce_Store_Download] DROP CONSTRAINT [DF_dashCommerce_Store_Download_ModifiedOn]
End
GO
/****** Object:  Default [DF_dashCommerce_Store_Version_CreatedOn]    Script Date: 05/30/2009 19:33:40 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_dashCommerce_Store_Version_CreatedOn]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Version]'))
Begin
ALTER TABLE [dbo].[dashCommerce_Store_Version] DROP CONSTRAINT [DF_dashCommerce_Store_Version_CreatedOn]
End
GO
/****** Object:  Default [DF_dashCommerce_Store_Version_ModifiedOn]    Script Date: 05/30/2009 19:33:40 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_dashCommerce_Store_Version_ModifiedOn]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Version]'))
Begin
ALTER TABLE [dbo].[dashCommerce_Store_Version] DROP CONSTRAINT [DF_dashCommerce_Store_Version_ModifiedOn]
End
GO
/****** Object:  StoredProcedure [dbo].[dashCommerce_Store_FetchAssociatedDownloadsByProductIdAndNotForPurchase]    Script Date: 05/30/2009 19:33:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchAssociatedDownloadsByProductIdAndNotForPurchase]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchAssociatedDownloadsByProductIdAndNotForPurchase]
GO
/****** Object:  StoredProcedure [dbo].[dashCommerce_Store_FetchAssociatedDownloadsByProductIdAndForPurchase]    Script Date: 05/30/2009 19:33:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchAssociatedDownloadsByProductIdAndForPurchase]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchAssociatedDownloadsByProductIdAndForPurchase]
GO
/****** Object:  StoredProcedure [dbo].[dashCommerce_Store_FetchAssociatedDownloadsByProductId]    Script Date: 05/30/2009 19:33:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchAssociatedDownloadsByProductId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchAssociatedDownloadsByProductId]
GO
/****** Object:  StoredProcedure [dbo].[dashCommerce_Store_FetchAvailableDownloadsByProductId]    Script Date: 05/30/2009 19:33:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchAvailableDownloadsByProductId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchAvailableDownloadsByProductId]
GO
/****** Object:  StoredProcedure [dbo].[dashCommerce_Store_FetchPurchasedDownloadsByUserId]    Script Date: 05/30/2009 19:33:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchPurchasedDownloadsByUserId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchPurchasedDownloadsByUserId]
GO
/****** Object:  Table [dbo].[dashCommerce_Store_Product_Download_Map]    Script Date: 05/30/2009 19:33:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Product_Download_Map]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_Product_Download_Map]
GO
/****** Object:  Table [dbo].[dashCommerce_Store_DownloadAccessControl]    Script Date: 05/30/2009 19:33:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_DownloadAccessControl]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_DownloadAccessControl]
GO
/****** Object:  Table [dbo].[dashCommerce_Store_Version]    Script Date: 05/30/2009 19:33:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Version]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_Version]
GO
/****** Object:  Table [dbo].[dashCommerce_Store_Download]    Script Date: 05/30/2009 19:33:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Download]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_Download]
GO
/******** MODS ********/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Core_StateOrRegion_dashCommerce_Core_Country]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Core_StateOrRegion]'))
ALTER TABLE [dbo].[dashCommerce_Core_StateOrRegion] DROP CONSTRAINT [FK_dashCommerce_Core_StateOrRegion_dashCommerce_Core_Country]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Content_Region_dashCommerce_Content_TemplateRegion]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_Region]'))
ALTER TABLE [dbo].[dashCommerce_Content_Region] DROP CONSTRAINT [FK_dashCommerce_Content_Region_dashCommerce_Content_TemplateRegion]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Content_Page_Region_Map_dashCommerce_Content_Page]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_Page_Region_Map]'))
ALTER TABLE [dbo].[dashCommerce_Content_Page_Region_Map] DROP CONSTRAINT [FK_dashCommerce_Content_Page_Region_Map_dashCommerce_Content_Page]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Content_Page_Region_Map_dashCommerce_Content_Region]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_Page_Region_Map]'))
ALTER TABLE [dbo].[dashCommerce_Content_Page_Region_Map] DROP CONSTRAINT [FK_dashCommerce_Content_Page_Region_Map_dashCommerce_Content_Region]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Content_Template_TemplateRegion_Map_dashCommerce_Content_Template]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_Template_TemplateRegion_Map]'))
ALTER TABLE [dbo].[dashCommerce_Content_Template_TemplateRegion_Map] DROP CONSTRAINT [FK_dashCommerce_Content_Template_TemplateRegion_Map_dashCommerce_Content_Template]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Content_Template_TemplateRegion_Map_dashCommerce_Content_TemplateRegion]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_Template_TemplateRegion_Map]'))
ALTER TABLE [dbo].[dashCommerce_Content_Template_TemplateRegion_Map] DROP CONSTRAINT [FK_dashCommerce_Content_Template_TemplateRegion_Map_dashCommerce_Content_TemplateRegion]
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_dashCommerce_Store_ToDo_CreatedOn]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_ToDo]'))
ALTER TABLE [dbo].[dashCommerce_Store_ToDo] DROP CONSTRAINT [DF_dashCommerce_Store_ToDo_CreatedOn]
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_dashCommerce_Store_ToDo_ModifiedOn]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_ToDo]'))
ALTER TABLE [dbo].[dashCommerce_Store_ToDo] DROP CONSTRAINT [DF_dashCommerce_Store_ToDo_ModifiedOn]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_ProductImages_dashCommerce_Products]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Image]'))
ALTER TABLE [dbo].[dashCommerce_Store_Image] DROP CONSTRAINT [FK_dashCommerce_ProductImages_dashCommerce_Products]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_Review_dashCommerce_Store_Product]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Review]'))
ALTER TABLE [dbo].[dashCommerce_Store_Review] DROP CONSTRAINT [FK_dashCommerce_Store_Review_dashCommerce_Store_Product]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_ProductDescriptor_dashCommerce_Store_Product]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Descriptor]'))
ALTER TABLE [dbo].[dashCommerce_Store_Descriptor] DROP CONSTRAINT [FK_dashCommerce_Store_ProductDescriptor_dashCommerce_Store_Product]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_Sku_dashCommerce_Store_Product]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Sku]'))
ALTER TABLE [dbo].[dashCommerce_Store_Sku] DROP CONSTRAINT [FK_dashCommerce_Store_Sku_dashCommerce_Store_Product]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_AttributeItem_dashCommerce_Store_Attribute]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_AttributeItem]'))
ALTER TABLE [dbo].[dashCommerce_Store_AttributeItem] DROP CONSTRAINT [FK_dashCommerce_Store_AttributeItem_dashCommerce_Store_Attribute]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_OrderNote_dashCommerce_Store_Order]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_OrderNote]'))
ALTER TABLE [dbo].[dashCommerce_Store_OrderNote] DROP CONSTRAINT [FK_dashCommerce_Store_OrderNote_dashCommerce_Store_Order]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_OrderTransactions_dashCommerce_OrderTransactionTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Transaction]'))
ALTER TABLE [dbo].[dashCommerce_Store_Transaction] DROP CONSTRAINT [FK_dashCommerce_OrderTransactions_dashCommerce_OrderTransactionTypes]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_Transaction_dashCommerce_Store_Order]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Transaction]'))
ALTER TABLE [dbo].[dashCommerce_Store_Transaction] DROP CONSTRAINT [FK_dashCommerce_Store_Transaction_dashCommerce_Store_Order]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_OrderItem_dashCommerce_Store_Order]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_OrderItem]'))
ALTER TABLE [dbo].[dashCommerce_Store_OrderItem] DROP CONSTRAINT [FK_dashCommerce_Store_OrderItem_dashCommerce_Store_Order]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_Order_dashCommerce_Store_OrderStatusDescriptor]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Order]'))
ALTER TABLE [dbo].[dashCommerce_Store_Order] DROP CONSTRAINT [FK_dashCommerce_Store_Order_dashCommerce_Store_OrderStatusDescriptor]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_aspnet_Roles_aspnet_Applications]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Roles]'))
ALTER TABLE [dbo].[aspnet_Roles] DROP CONSTRAINT [FK_aspnet_Roles_aspnet_Applications]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Products_Categories_dashCommerce_ProductCategories]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Product_Category_Map]'))
ALTER TABLE [dbo].[dashCommerce_Store_Product_Category_Map] DROP CONSTRAINT [FK_dashCommerce_Products_Categories_dashCommerce_ProductCategories]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Products_Categories_dashCommerce_Products]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Product_Category_Map]'))
ALTER TABLE [dbo].[dashCommerce_Store_Product_Category_Map] DROP CONSTRAINT [FK_dashCommerce_Products_Categories_dashCommerce_Products]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_Attribute_dashCommerce_Store_AttributeType]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Attribute]'))
ALTER TABLE [dbo].[dashCommerce_Store_Attribute] DROP CONSTRAINT [FK_dashCommerce_Store_Attribute_dashCommerce_Store_AttributeType]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_aspnet_Membership_aspnet_Applications]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Membership]'))
ALTER TABLE [dbo].[aspnet_Membership] DROP CONSTRAINT [FK_aspnet_Membership_aspnet_Applications]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_aspnet_Membership_aspnet_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Membership]'))
ALTER TABLE [dbo].[aspnet_Membership] DROP CONSTRAINT [FK_aspnet_Membership_aspnet_Users]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_aspnet_PersonalizationPerUser_aspnet_Paths]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationPerUser]'))
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] DROP CONSTRAINT [FK_aspnet_PersonalizationPerUser_aspnet_Paths]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_aspnet_PersonalizationPerUser_aspnet_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationPerUser]'))
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] DROP CONSTRAINT [FK_aspnet_PersonalizationPerUser_aspnet_Users]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_aspnet_Profile_aspnet_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Profile]'))
ALTER TABLE [dbo].[aspnet_Profile] DROP CONSTRAINT [FK_aspnet_Profile_aspnet_Users]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_aspnet_UsersInRoles_aspnet_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles]'))
ALTER TABLE [dbo].[aspnet_UsersInRoles] DROP CONSTRAINT [FK_aspnet_UsersInRoles_aspnet_Roles]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_aspnet_UsersInRoles_aspnet_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles]'))
ALTER TABLE [dbo].[aspnet_UsersInRoles] DROP CONSTRAINT [FK_aspnet_UsersInRoles_aspnet_Users]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_aspnet_PersonalizationAllUsers_aspnet_Paths]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAllUsers]'))
ALTER TABLE [dbo].[aspnet_PersonalizationAllUsers] DROP CONSTRAINT [FK_aspnet_PersonalizationAllUsers_aspnet_Paths]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_Product_Attribute_Map_dashCommerce_Store_Attribute]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Product_Attribute_Map]'))
ALTER TABLE [dbo].[dashCommerce_Store_Product_Attribute_Map] DROP CONSTRAINT [FK_dashCommerce_Store_Product_Attribute_Map_dashCommerce_Store_Attribute]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_Product_Attribute_Map_dashCommerce_Store_Product]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Product_Attribute_Map]'))
ALTER TABLE [dbo].[dashCommerce_Store_Product_Attribute_Map] DROP CONSTRAINT [FK_dashCommerce_Store_Product_Attribute_Map_dashCommerce_Store_Product]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Promo_Product_CrossSell_Map_dashCommerce_Store_Product]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_CrossSell]'))
ALTER TABLE [dbo].[dashCommerce_Store_CrossSell] DROP CONSTRAINT [FK_dashCommerce_Promo_Product_CrossSell_Map_dashCommerce_Store_Product]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Promo_Product_CrossSell_Map_dashCommerce_Store_Product1]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_CrossSell]'))
ALTER TABLE [dbo].[dashCommerce_Store_CrossSell] DROP CONSTRAINT [FK_dashCommerce_Promo_Product_CrossSell_Map_dashCommerce_Store_Product1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Products_dashCommerce_Manufacturers]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Product]'))
ALTER TABLE [dbo].[dashCommerce_Store_Product] DROP CONSTRAINT [FK_dashCommerce_Products_dashCommerce_Manufacturers]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Products_dashCommerce_ProductStatus]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Product]'))
ALTER TABLE [dbo].[dashCommerce_Store_Product] DROP CONSTRAINT [FK_dashCommerce_Products_dashCommerce_ProductStatus]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Products_dashCommerce_ProductType]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Product]'))
ALTER TABLE [dbo].[dashCommerce_Store_Product] DROP CONSTRAINT [FK_dashCommerce_Products_dashCommerce_ProductType]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Products_dashCommerce_ShipEstimates]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Product]'))
ALTER TABLE [dbo].[dashCommerce_Store_Product] DROP CONSTRAINT [FK_dashCommerce_Products_dashCommerce_ShipEstimates]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_aspnet_Users_aspnet_Applications]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Users]'))
ALTER TABLE [dbo].[aspnet_Users] DROP CONSTRAINT [FK_aspnet_Users_aspnet_Applications]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_aspnet_Paths_aspnet_Applications]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Paths]'))
ALTER TABLE [dbo].[aspnet_Paths] DROP CONSTRAINT [FK_aspnet_Paths_aspnet_Applications]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CustomizedProductDisplayType_Product_Map_dashCommerce_Store_Product]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_CustomizedProductDisplayType_Product_Map]'))
ALTER TABLE [dbo].[dashCommerce_Store_CustomizedProductDisplayType_Product_Map] DROP CONSTRAINT [FK_CustomizedProductDisplayType_Product_Map_dashCommerce_Store_Product]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_CustomizedProductDisplayType_Product_Map_dashCommerce_Store_CustomizedProductDisplayTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_CustomizedProductDisplayType_Product_Map]'))
ALTER TABLE [dbo].[dashCommerce_Store_CustomizedProductDisplayType_Product_Map] DROP CONSTRAINT [FK_dashCommerce_Store_CustomizedProductDisplayType_Product_Map_dashCommerce_Store_CustomizedProductDisplayTypes]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_SimpleHtml]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Content_SimpleHtml]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_Provider]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Content_Provider]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_Page]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Content_Page]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_Template]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Content_Template]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_Region]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Content_Region]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_TemplateRegion]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Content_TemplateRegion]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_Page_Region_Map]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Content_Page_Region_Map]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_Template_TemplateRegion_Map]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Content_Template_TemplateRegion_Map]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_ToDo]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_ToDo]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Image]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_Image]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_VatTaxRate]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_VatTaxRate]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchRefundedOrderItems]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchRefundedOrderItems]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchAssociatedOrders]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchAssociatedOrders]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchAssociatedOrderTransactions]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchAssociatedOrderTransactions]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_FetchRegionsByPageId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Content_FetchRegionsByPageId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_FetchRegionsByPageIdAndTemplateRegionId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Content_FetchRegionsByPageIdAndTemplateRegionId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_JoinRegionToPage]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Content_JoinRegionToPage]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_FetchTemplateRegionsByTemplateId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Content_FetchTemplateRegionsByTemplateId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Roles_CreateRole]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Roles_CreateRole]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Review]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_Review]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Core_ConfigurationData]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Core_ConfigurationData]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Page]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_Page]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Descriptor]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_Descriptor]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Sku]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_Sku]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Setup_RemoveAllRoleMembers]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Setup_RemoveAllRoleMembers]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAdministration_FindState]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_PersonalizationAdministration_FindState]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchAllProductsByCategoryId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchAllProductsByCategoryId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_RegionCodeTaxRate]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_RegionCodeTaxRate]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_ProductSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_ProductSearch]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchBrowsingLogSearchTerms]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchBrowsingLogSearchTerms]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Core_Country]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Core_Country]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Provider]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_Provider]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_AttributeItem]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_AttributeItem]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_UpdateUserInfo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_UpdateUserInfo]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_UnlockUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_UnlockUser]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_SimpleWeightShippingRate]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_SimpleWeightShippingRate]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_AnyDataInTables]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_AnyDataInTables]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_ResetPassword]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_ResetPassword]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_GetUserByEmail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_GetUserByEmail]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_ChangePasswordQuestionAndAnswer]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_ChangePasswordQuestionAndAnswer]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Profile_DeleteProfiles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Profile_DeleteProfiles]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_UpdateUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_UpdateUser]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Coupon]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_Coupon]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_SetPassword]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_SetPassword]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_GetUserByName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_GetUserByName]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Users_DeleteUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Users_DeleteUser]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Notification]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_Notification]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_GetPasswordWithFormat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_GetPasswordWithFormat]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_GetNumberOfUsersOnline]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_GetNumberOfUsersOnline]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_GetPassword]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_GetPassword]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchCategoryBrowsingLog]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchCategoryBrowsingLog]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchProductBrowsingLog]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchProductBrowsingLog]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchFavoriteCategories]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchFavoriteCategories]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Setup_RestorePermissions]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Setup_RestorePermissions]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Currency]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_Currency]
GO
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_aspnet_MembershipUsers]'))
DROP VIEW [dbo].[vw_aspnet_MembershipUsers]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_GetUserByUserId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_GetUserByUserId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles_FindUsersInRole]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_UsersInRoles_FindUsersInRole]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles_GetUsersInRoles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_UsersInRoles_GetUsersInRoles]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles_AddUsersToRoles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_UsersInRoles_AddUsersToRoles]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Profile_GetProperties]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Profile_GetProperties]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Profile_DeleteInactiveProfiles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Profile_DeleteInactiveProfiles]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Profile_GetNumberOfInactiveProfiles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Profile_GetNumberOfInactiveProfiles]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Roles_DeleteRole]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Roles_DeleteRole]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_GetAllUsers]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_GetAllUsers]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Roles_RoleExists]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Roles_RoleExists]
GO
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_aspnet_Applications]'))
DROP VIEW [dbo].[vw_aspnet_Applications]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles_RemoveUsersFromRoles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_UsersInRoles_RemoveUsersFromRoles]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles_IsUserInRole]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_UsersInRoles_IsUserInRole]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles_GetRolesForUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_UsersInRoles_GetRolesForUser]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_FindUsersByEmail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_FindUsersByEmail]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Profile_GetProfiles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Profile_GetProfiles]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_FindUsersByName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_FindUsersByName]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Roles_GetAllRoles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Roles_GetAllRoles]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_CheckSchemaVersion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_CheckSchemaVersion]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_RegisterSchemaVersion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_RegisterSchemaVersion]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_UnRegisterSchemaVersion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_UnRegisterSchemaVersion]
GO
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_aspnet_Profiles]'))
DROP VIEW [dbo].[vw_aspnet_Profiles]
GO
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_aspnet_UsersInRoles]'))
DROP VIEW [dbo].[vw_aspnet_UsersInRoles]
GO
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_aspnet_WebPartState_User]'))
DROP VIEW [dbo].[vw_aspnet_WebPartState_User]
GO
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_aspnet_WebPartState_Shared]'))
DROP VIEW [dbo].[vw_aspnet_WebPartState_Shared]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_WebEvent_LogEvent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_WebEvent_LogEvent]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchAssociatedAttributesByProductId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchAssociatedAttributesByProductId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchAvailableAttributesByProductId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchAvailableAttributesByProductId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchAssociatedCategoriesByProductId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchAssociatedCategoriesByProductId]
GO
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_aspnet_Roles]'))
DROP VIEW [dbo].[vw_aspnet_Roles]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchCategoryBreadCrumbs]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchCategoryBreadCrumbs]
GO
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_aspnet_WebPartState_Paths]'))
DROP VIEW [dbo].[vw_aspnet_WebPartState_Paths]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Core_DeleteAllLogs]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Core_DeleteAllLogs]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_CreateUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_CreateUser]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchMostPopularProducts]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchMostPopularProducts]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchFavoriteProducts]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchFavoriteProducts]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchProductCrossSells]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchProductCrossSells]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchRandomProducts]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchRandomProducts]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchProductsByCategoryIdAndManufacturerId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchProductsByCategoryIdAndManufacturerId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchProductsByCategoryId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchProductsByCategoryId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchProductsByCategoryIdAndPriceRange]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchProductsByCategoryIdAndPriceRange]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_OrderNote]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_OrderNote]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchCategoryPriceRanges]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchCategoryPriceRanges]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_FetchCategoryManufacturers]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_FetchCategoryManufacturers]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Profile_SetProperties]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Profile_SetProperties]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAdministration_ResetUserState]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_PersonalizationAdministration_ResetUserState]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Transaction]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_Transaction]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAdministration_DeleteAllState]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_PersonalizationAdministration_DeleteAllState]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationPerUser_ResetPageSettings]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_PersonalizationPerUser_ResetPageSettings]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAdministration_GetCountOfState]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_PersonalizationAdministration_GetCountOfState]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationPerUser_SetPageSettings]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_PersonalizationPerUser_SetPageSettings]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_ProductRating]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_ProductRating]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationPerUser_GetPageSettings]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_PersonalizationPerUser_GetPageSettings]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAllUsers_GetPageSettings]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_PersonalizationAllUsers_GetPageSettings]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAllUsers_SetPageSettings]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_PersonalizationAllUsers_SetPageSettings]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_OrderItem]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_OrderItem]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAdministration_ResetSharedState]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_PersonalizationAdministration_ResetSharedState]
GO
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_aspnet_Users]'))
DROP VIEW [dbo].[vw_aspnet_Users]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAllUsers_ResetPageSettings]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_PersonalizationAllUsers_ResetPageSettings]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_OrderStatusDescriptor]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_OrderStatusDescriptor]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_ProductStatusDescriptor]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_ProductStatusDescriptor]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_ShippingEstimate]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_ShippingEstimate]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_ProductType]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_ProductType]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_AttributeType]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_AttributeType]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Order]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_Order]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_TransactionTypeDescriptor]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_TransactionTypeDescriptor]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Roles]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_Roles]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Applications_CreateApplication]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Applications_CreateApplication]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoryHierarchy]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[CategoryHierarchy]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Product_Category_Map]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_Product_Category_Map]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Attribute]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_Attribute]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Browsing_Log]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_Browsing_Log]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Core_Log]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Core_Log]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_Membership]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationPerUser]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_PersonalizationPerUser]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_WebEvent_Events]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_WebEvent_Events]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Profile]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_Profile]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_UsersInRoles]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Manufacturer]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_Manufacturer]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_SchemaVersions]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_SchemaVersions]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAllUsers]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_PersonalizationAllUsers]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Product_Attribute_Map]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_Product_Attribute_Map]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Users_CreateUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Users_CreateUser]
GO
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_dashCommerce_NotInActiveAndLocked_Products]'))
DROP VIEW [dbo].[vw_dashCommerce_NotInActiveAndLocked_Products]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_CrossSell]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_CrossSell]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Personalization_GetApplicationId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Personalization_GetApplicationId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Paths_CreatePath]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Paths_CreatePath]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Product]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_Product]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Category]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_Category]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Users]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_Users]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Paths]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_Paths]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Applications]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_Applications]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_CustomizedProductDisplay]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Content_CustomizedProductDisplay]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Core_StateOrRegion]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Core_StateOrRegion]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_CustomizedProductDisplayType_Product_Map]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_CustomizedProductDisplayType_Product_Map]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_CustomizedProductDisplayTypes]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_CustomizedProductDisplayTypes]
GO
/****** Object:  Table [dbo].[dashCommerce_Store_CustomizedProductDisplayType]    Script Date: 05/30/2009 20:33:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_CustomizedProductDisplayType]') AND type in (N'U'))
DROP TABLE [dbo].[dashCommerce_Store_CustomizedProductDisplayType]
GO
/****** Object:  StoredProcedure [dbo].[dashCommerce_Core_FetchStateOrRegionByCountryCode]    Script Date: 07/25/2009 20:38:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Core_FetchStateOrRegionByCountryCode]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Core_FetchStateOrRegionByCountryCode]
