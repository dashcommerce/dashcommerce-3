SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_ShippingEstimate]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_ShippingEstimate](
	[ShippingEstimateId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_ShippingEstimate_createdOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_ShippingEstimate_modifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_ShipEstimates] PRIMARY KEY CLUSTERED 
(
	[ShippingEstimateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_ProductType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_ProductType](
	[ProductTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_ProductType_createdOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_ProductType_modifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_ProductType] PRIMARY KEY CLUSTERED 
(
	[ProductTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_AttributeType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_AttributeType](
	[AttributeTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NULL CONSTRAINT [DF_dashCommerce_Store_AttributeType_createdOn]  DEFAULT (getdate()),
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL CONSTRAINT [DF_dashCommerce_Store_AttributeType_modifiedOn]  DEFAULT (getdate()),
	[ModifiedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_dashCommerce_ProductAttributeTypes] PRIMARY KEY CLUSTERED 
(
	[AttributeTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Core_ConfigurationData]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Core_ConfigurationData](
	[ConfigurationDataId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Type] [nvarchar](300) NOT NULL,
	[Value] [ntext] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Core_ConfigurationData_CreatedDate]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Core_ConfigurationData_ModifiedDate]  DEFAULT (getutcdate()),
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_dashCommerce_Core_ConfigurationData] PRIMARY KEY CLUSTERED 
(
	[ConfigurationDataId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_ProductStatusDescriptor]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_ProductStatusDescriptor](
	[ProductStatusDescriptorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_ProductStatus_createdOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_ProductStatus_modifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_ProductStatus] PRIMARY KEY CLUSTERED 
(
	[ProductStatusDescriptorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_RegionCodeTaxRate]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_RegionCodeTaxRate](
	[RegionCodeTaxRateId] [int] IDENTITY(1,1) NOT NULL,
	[Rate] [money] NOT NULL,
	[RegionCode] [nvarchar](50) NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Tax_Rate_createdOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Tax_Rate_modifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_Taxes] PRIMARY KEY CLUSTERED 
(
	[RegionCodeTaxRateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Core_Country]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Core_Country](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](2) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_dashCommerce_Util_Country] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Core_StateOrRegion]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Core_StateOrRegion](
	[StateOrRegionId] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Abbreviation] [nvarchar](6) NOT NULL,
 CONSTRAINT [PK_dashCommerce_Core_StateOrRegion] PRIMARY KEY CLUSTERED 
(
	[StateOrRegionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_TransactionTypeDescriptor]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_TransactionTypeDescriptor](
	[TransactionTypeDescriptorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_TransactionType_createdOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_TransactionType_modifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_OrderTransactionTypes] PRIMARY KEY CLUSTERED 
(
	[TransactionTypeDescriptorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_OrderStatusDescriptor]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_OrderStatusDescriptor](
	[OrderStatusDescriptorId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_OrderStatusDescriptor_CreatedOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_OrderStatusDescriptor_ModifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_Store_OrderStatusDescriptor] PRIMARY KEY CLUSTERED 
(
	[OrderStatusDescriptorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Currency]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_Currency](
	[codeID] [int] IDENTITY(1,1) NOT NULL,
	[code] [char](3) NOT NULL,
	[description] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_dashCommerce_Util_Currency] PRIMARY KEY CLUSTERED 
(
	[codeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_SimpleWeightShippingRate]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_SimpleWeightShippingRate](
	[SimpleWeightShippingRateId] [int] IDENTITY(1,1) NOT NULL,
	[Service] [varchar](50) NOT NULL,
	[AmountPerUnit] [money] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Shipping_Rate_createdOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Shipping_Rate_modifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_ShippingRates] PRIMARY KEY CLUSTERED 
(
	[SimpleWeightShippingRateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Coupon]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_Coupon](
	[CouponId] [int] IDENTITY(1,1) NOT NULL,
	[CouponCode] [nvarchar](50) NOT NULL,
	[ExpirationDate] [datetime] NULL,
	[IsSingleUse] [bit] NOT NULL,
	[Type] [nvarchar](300) NOT NULL,
	[Value] [ntext] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Coupon_CreatedOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_dashCommerce_Store_Coupon] PRIMARY KEY CLUSTERED 
(
	[CouponId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Category]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryGuid] [uniqueidentifier] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Category_categoryGUID]  DEFAULT (newid()),
	[ParentId] [int] NOT NULL CONSTRAINT [DF_dashCommerce_ProductCategories_parentID]  DEFAULT ((0)),
	[Name] [nvarchar](100) NOT NULL,
	[ImageFile] [nvarchar](255) NULL,
	[Description] [nvarchar](500) NULL,
	[SortOrder] [int] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Category_createdOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Category_modifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_ProductCategories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Notification]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_Notification](
	[NotificationId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ToList] [nvarchar](500) NULL,
	[CcList] [nvarchar](500) NULL,
	[FromName] [nvarchar](50) NOT NULL,
	[FromEmail] [nvarchar](50) NOT NULL,
	[Subject] [nvarchar](50) NOT NULL,
	[NotificationBody] [ntext] NOT NULL,
	[IsHTML] [bit] NOT NULL CONSTRAINT [DF_dashCommerce_Mailers_isHTML]  DEFAULT ((0)),
	[IsSystemNotification] [bit] NOT NULL CONSTRAINT [DF_dashCommerce_Messaging_Mailer_isSystemMailer]  DEFAULT ((0)),
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Messaging_Mailer_createdOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Messaging_Mailer_modifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_Mailers] PRIMARY KEY CLUSTERED 
(
	[NotificationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Manufacturer]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_Manufacturer](
	[ManufacturerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Manufacturer_createdOn]  DEFAULT (getdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Manufacturer_modifiedOn]  DEFAULT (getdate()),
 CONSTRAINT [PK_dashCommerce_Manufacturers] PRIMARY KEY CLUSTERED 
(
	[ManufacturerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Provider]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_Provider](
	[ProviderId] [int] IDENTITY(1,1) NOT NULL,
	[ProviderTypeId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ConfigurationControlPath] [nvarchar](255) NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Provider_CreatedDate]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Provider_ModifiedDate]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_Store_Providers] PRIMARY KEY CLUSTERED 
(
	[ProviderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Core_Log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Core_Log](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_Script_Message_Log_Log_Date]  DEFAULT (getdate()),
	[Message] [text] NULL,
	[MessageType] [tinyint] NOT NULL,
	[UserAgent] [varchar](256) NULL,
	[RemoteHost] [varchar](256) NULL,
	[AuthUser] [varchar](64) NULL,
	[Referer] [varchar](512) NULL,
	[MachineName] [varchar](32) NULL,
	[FormData] [text] NULL,
	[QueryStringData] [varchar](512) NULL,
	[CookiesData] [varchar](2048) NULL,
	[ExceptionType] [varchar](256) NULL,
	[ScriptName] [varchar](256) NULL,
	[ExceptionMessage] [varchar](512) NULL,
	[ExceptionSource] [varchar](256) NULL,
	[ExceptionStackTrace] [varchar](2048) NULL,
 CONSTRAINT [PK__dashCommerce_Cor__457F2FDE] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_Template]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Content_Template](
	[TemplateId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[StyleSheet] [nvarchar](250) NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime]  NOT NULL CONSTRAINT [DF_dashCommerce_Content_Template_createdOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Content_Template_modifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_Content_Template] PRIMARY KEY CLUSTERED 
(
	[TemplateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_TemplateRegion]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Content_TemplateRegion](
	[TemplateRegionId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Content_TemplateRegion_createdOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Content_TemplateRegion_modifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_Content_TemplateRegion] PRIMARY KEY CLUSTERED 
(
	[TemplateRegionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_Page]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Content_Page](
	[PageId] [int] IDENTITY(1,1) NOT NULL,
	[PageGuid] [uniqueidentifier] NOT NULL,
	[ParentId] [int] NOT NULL CONSTRAINT [DF_dashCommerce_Content_Page_ParentId]  DEFAULT ((0)),
	[Title] [nvarchar](250) NOT NULL,
	[MenuTitle] [nvarchar](50) NOT NULL,
	[Keywords] [nvarchar](500) NULL,
	[Description] [nvarchar](500) NULL,
	[SortOrder] [int] NOT NULL CONSTRAINT [DF_dashCommerce_Content_Page_SortOrder]  DEFAULT ((0)),
	[TemplateId] [int] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Content_Page_CreatedOn_1]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Content_Page_ModifiedOn_1]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_Content_Page_1] PRIMARY KEY CLUSTERED 
(
	[PageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_SimpleHtml]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Content_SimpleHtml](
	[SimpleHtmlId] [int] IDENTITY(1,1) NOT NULL,
	[RegionId] [int] NOT NULL,
	[Html] [nvarchar](max) NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Content_SimpleHtml_CreatedOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Content_SimpleHtml_ModifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_Content_SimpleHtml] PRIMARY KEY CLUSTERED 
(
	[SimpleHtmlId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_ProductRating]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_ProductRating](
	[ProductRatingId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[Rating] [int] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Rating_createdOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Rating_modifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_ProductRating] PRIMARY KEY CLUSTERED 
(
	[ProductRatingId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_Provider]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Content_Provider](
	[ProviderId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ViewControl] [nvarchar](250) NOT NULL,
	[EditControl] [nvarchar](250) NOT NULL,
	[StyleSheet] [nvarchar](250) NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Content_Provider_createdOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Content_Provider_modifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_Content_Provider] PRIMARY KEY CLUSTERED 
(
	[ProviderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Browsing_Log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_Browsing_Log](
	[BrowsingLogId] [int] IDENTITY(1,1) NOT NULL,
	[BrowsingBehaviorId] [int] NOT NULL,
	[RelevantId] [int] NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Url] [nvarchar](255) NULL,
	[SearchTerms] [nvarchar](150) NULL,
	[SessionId] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Stats_Tracker_createdOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Stats_Tracker_modifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_STATS_Tracker] PRIMARY KEY CLUSTERED 
(
	[BrowsingLogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_OrderNote]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_OrderNote](
	[OrderNoteId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[Note] [nvarchar](1500) NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_OrderNote_createdOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_OrderNote_modifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_OrderNotes] PRIMARY KEY CLUSTERED 
(
	[OrderNoteId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Transaction]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_Transaction](
	[TransactionId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[TransactionTypeDescriptorId] [int] NOT NULL CONSTRAINT [DF_dashCommerce_OrderTransactions_transationTypeID]  DEFAULT ((1)),
	[PaymentMethod] [nvarchar](50) NOT NULL,
	[GatewayName] [nvarchar](50) NOT NULL,
	[GatewayResponse] [nvarchar](50) NOT NULL,
	[GatewayTransactionId] [nvarchar](100) NOT NULL,
	[AVSCode] [nvarchar](20) NOT NULL,
	[CVV2Code] [nvarchar](20) NOT NULL,
	[GrossAmount] [money] NOT NULL CONSTRAINT [DF_dashCommerce_OrderTransactions_amount]  DEFAULT ((0)),
	[NetAmount] [money] NOT NULL,
	[FeeAmount] [money] NOT NULL,
	[TransactionDate] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_OrderTransactions_transactionDate]  DEFAULT (getdate()),
	[GatewayErrors] [nvarchar](500) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Transaction_createdOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Transaction_modifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_Store_Transaction] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_OrderItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_OrderItem](
	[OrderItemId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Sku] [nvarchar](100) NULL,
	[Quantity] [int] NOT NULL,
	[PricePaid] [money] NOT NULL,
	[Attributes] [nvarchar](100) NULL,
	[AdditionalProperties] [nvarchar](2000) NULL,
	[Weight] [numeric](18, 0) NOT NULL,
	[ItemTax] [money] NOT NULL,
	[DiscountAmount] [money] NOT NULL CONSTRAINT [DF_dashCommerce_Store_OrderItem_DiscountAmount]  DEFAULT ((0)),
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_OrderItem_createdOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_OrderItem_modifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_OrderItems] PRIMARY KEY CLUSTERED 
(
	[OrderItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Product]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ManufacturerId] [int] NOT NULL CONSTRAINT [DF_dashCommerce_Products_manufacturerID]  DEFAULT ((1)),
	[ProductStatusDescriptorId] [int] NOT NULL CONSTRAINT [DF_dashCommerce_Products_statusID]  DEFAULT ((1)),
	[ProductTypeId] [int] NOT NULL CONSTRAINT [DF_dashCommerce_Products_productTypeID]  DEFAULT ((1)),
	[ShippingEstimateId] [int] NOT NULL CONSTRAINT [DF_dashCommerce_Products_shipTimeID]  DEFAULT ((1)),
	[BaseSku] [nvarchar](50) NULL,
	[ProductGuid] [uniqueidentifier] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Product_productGUID]  DEFAULT (newid()),
	[Name] [nvarchar](150) NOT NULL,
	[ShortDescription] [nvarchar](max) NULL,
	[OurPrice] [money] NOT NULL,
	[RetailPrice] [money] NOT NULL,
	[TaxRateId] [int] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Product_TaxRateId] DEFAULT ((0)),
	[Weight] [numeric](19, 4) NOT NULL CONSTRAINT [DF_dashCommerce_Products_weight]  DEFAULT ((0)),
	[Length] [numeric](18, 0) NOT NULL CONSTRAINT [DF_dashCommerce_Products_length]  DEFAULT ((0)),
	[Height] [numeric](18, 0) NOT NULL CONSTRAINT [DF_dashCommerce_Products_height]  DEFAULT ((0)),
	[Width] [numeric](18, 0) NOT NULL CONSTRAINT [DF_dashCommerce_Products_width]  DEFAULT ((0)),
	[SortOrder] [int] NOT NULL CONSTRAINT [DF_dashCommerce_Products_listOrder]  DEFAULT ((1)),
	[RatingSum] [int] NOT NULL CONSTRAINT [DF_dashCommerce_Products_RatingSum]  DEFAULT ((4)),
	[TotalRatingVotes] [int] NOT NULL CONSTRAINT [DF_dashCommerce_Products_totalRatingSum]  DEFAULT ((1)),
	[AllowNegativeInventories] [bit] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Product_AllowNegativeInventories]  DEFAULT ((0)),
	[IsEnabled] [bit] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Product_IsLocked]  DEFAULT ((0)),
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Product_createdOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Product_modifiedOn]  DEFAULT (getutcdate()),
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_dashCommerce_Products_isDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_dashCommerce_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Attribute]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_Attribute](
	[AttributeId] [int] IDENTITY(1,1) NOT NULL,
	[AttributeTypeId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Label] [nvarchar](150) NULL,
 CONSTRAINT [PK_dashCommerce_Store_Attribute] PRIMARY KEY CLUSTERED 
(
	[AttributeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Order]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderGuid] [uniqueidentifier] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Order_orderGuid]  DEFAULT (newid()),
	[OrderNumber] [varchar](50) NULL,
	[OrderTypeId] [int] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Order_OrderTypeId]  DEFAULT ((1)),
	[OrderParentId] [int] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Order_OrderParentId]  DEFAULT ((0)),
	[OrderStatusDescriptorId] [int] NOT NULL CONSTRAINT [DF_dashCommerce_Orders_OrderStatusDescriptorId]  DEFAULT ((0)),
	[UserName] [varchar](100) NOT NULL,
	[ShippingAmount] [money] NOT NULL CONSTRAINT [DF_dashCommerce_Orders_Shipping_1]  DEFAULT ((0)),
	[ShippingMethod] [nvarchar](100) NULL,
	[HandlingAmount] [money] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Order_HandlingAmount]  DEFAULT ((0)),
	[BillToAddress] [nvarchar](1500) NULL,
	[ShipToAddress] [nvarchar](1500) NULL,
	[IPAddress] [nvarchar](50) NOT NULL,
	[PaymentMethod] [nvarchar](50) NULL,
	[ShippingTrackingNumber] [nvarchar](150) NULL,
	[AdditionalProperties] [nvarchar](2000) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Order_createdOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Order_modifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_Store_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Product_Category_Map]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_Product_Category_Map](
	[ProductId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Product_Category_Map_createdOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Product_Category_Map_modifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_Products_Categories] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_Page_Region_Map]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Content_Page_Region_Map](
	[RegionId] [int] NOT NULL,
	[PageId] [int] NOT NULL,
 CONSTRAINT [PK_dashCommerce_Content_Page_Region_Map] PRIMARY KEY CLUSTERED 
(
	[RegionId] ASC,
	[PageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Product_Attribute_Map]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_Product_Attribute_Map](
	[AttributeId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[SortOrder] [int] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Product_Attribute_Map_SortOrder]  DEFAULT ((0)),
	[IsRequired] [bit] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Product_Attribute_Map_IsRequired]  DEFAULT ((0)),
 CONSTRAINT [PK_dashCommerce_Store_Product_Attribute_Map] PRIMARY KEY CLUSTERED 
(
	[AttributeId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_CrossSell]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_CrossSell](
	[ProductId] [int] NOT NULL,
	[CrossProductId] [int] NOT NULL,
 CONSTRAINT [PK_dashCommerce_Promo_Product_CrossSell_Map] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[CrossProductId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Sku]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_Sku](
	[SkuId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Sku] [nvarchar](100) NOT NULL,
	[Inventory] [int] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Sku_Inventory]  DEFAULT ((0)),
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [nvarchar](50) NOT NULL CONSTRAINT [DF_dashCommerce_Store_Sku_CreatedOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [nvarchar](50) NOT NULL CONSTRAINT [DF_dashCommerce_Store_Sku_ModifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_Store_Sku] PRIMARY KEY CLUSTERED 
(
	[SkuId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Descriptor]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_Descriptor](
	[DescriptorId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Descriptor] [nvarchar](4000) NOT NULL,
	[SortOrder] [int] NOT NULL CONSTRAINT [DF_dashCommerce_Store_ProductDescriptor_listOrder]  DEFAULT ((1)),
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_ProductDescriptor_CreatedOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_ProductDescriptor_ModifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_Store_ProductDescriptor] PRIMARY KEY CLUSTERED 
(
	[DescriptorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Image]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_Image](
	[ImageId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[ImageFile] [nvarchar](500) NULL,
	[SortOrder] [int] NOT NULL CONSTRAINT [DF_dashCommerce_ProductImages_isDefault]  DEFAULT ((0)),
	[Caption] [nvarchar](500) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Image_createdOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Image_modifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_ProductImages] PRIMARY KEY CLUSTERED 
(
	[ImageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Review]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_Review](
	[ReviewId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Title] [nvarchar](100) NOT NULL CONSTRAINT [DF_dashCommerce_Reviews_Title]  DEFAULT (''),
	[Body] [ntext] NOT NULL CONSTRAINT [DF_dashCommerce_Reviews_Body]  DEFAULT (''),
	[Rating] [int] NOT NULL CONSTRAINT [DF_dashCommerce_ProductReviews_Rating]  DEFAULT ((0)),
	[IsApproved] [bit] NOT NULL CONSTRAINT [DF_dashCommerce_Reviews_IsApproved]  DEFAULT ((0)),
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Review_createdOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Review_modifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_Reviews] PRIMARY KEY CLUSTERED 
(
	[ReviewId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_Template_TemplateRegion_Map]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Content_Template_TemplateRegion_Map](
	[TemplateId] [int] NOT NULL,
	[TemplateRegionId] [int] NOT NULL,
 CONSTRAINT [PK_dashCommerce_Content_Template_TemplateRegion_Map] PRIMARY KEY CLUSTERED 
(
	[TemplateId] ASC,
	[TemplateRegionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_Region]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Content_Region](
	[RegionId] [int] IDENTITY(1,1) NOT NULL,
	[RegionGuid] [uniqueidentifier] NOT NULL,
	[ProviderId] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[TemplateRegionId] [int] NOT NULL,
	[SortOrder] [int] NOT NULL,
	[ShowTitle] [bit] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Content_Region_createdOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Content_Region_ModifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_Content_Region] PRIMARY KEY CLUSTERED 
(
	[RegionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_AttributeItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_AttributeItem](
	[AttributeItemId] [int] IDENTITY(1,1) NOT NULL,
	[AttributeId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Adjustment] [money] NOT NULL,
	[SortOrder] [int] NOT NULL,
	[SkuSuffix] [nvarchar](50) NULL,
 CONSTRAINT [PK_dashCommerce_Store_AttributeItem] PRIMARY KEY CLUSTERED 
(
	[AttributeItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_ToDo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_ToDo](
	[ToDoId] [int] IDENTITY(1,1) NOT NULL,
	[ToDo] [nvarchar](50) NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](50) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_dashCommerce_Store_ToDo] PRIMARY KEY CLUSTERED 
(
	[ToDoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[dashCommerce_Store_VatTaxRate]    Script Date: 11/24/2009 18:03:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dashCommerce_Store_VatTaxRate](
	[VatTaxRateId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Rate] [money] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_VatTaxRate_CreatedOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_VatTaxRate_ModifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_Store_VatTaxRate] PRIMARY KEY CLUSTERED 
(
	[VatTaxRateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dashCommerce_Store_Download]    Script Date: 05/16/2009 13:24:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Download]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_Download](
	[DownloadId] [int] IDENTITY(1,1) NOT NULL,
	[DownloadFile] [nvarchar](255) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ForPurchaseOnly] [bit] NOT NULL,
	[ContentType] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](50) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_dashCommerce_Store_Download] PRIMARY KEY CLUSTERED 
(
	[DownloadId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[dashCommerce_Store_DownloadAccessControl]    Script Date: 05/16/2009 13:24:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_DownloadAccessControl]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_DownloadAccessControl](
	[UserId] [uniqueidentifier] NOT NULL,
	[DownloadId] [int] NOT NULL,
 CONSTRAINT [PK_dashCommerce_Store_DownloadAccessControl] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[DownloadId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Default [DF_dashCommerce_Store_Download_ForPurchaseOnly]    Script Date: 05/16/2009 13:24:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_dashCommerce_Store_Download_ForPurchaseOnly]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Download]'))
Begin
ALTER TABLE [dbo].[dashCommerce_Store_Download] ADD  CONSTRAINT [DF_dashCommerce_Store_Download_ForPurchaseOnly]  DEFAULT ((1)) FOR [ForPurchaseOnly]

End
GO
/****** Object:  Default [DF_dashCommerce_Store_Download_CreatedOn]    Script Date: 05/16/2009 13:24:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_dashCommerce_Store_Download_CreatedOn]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Download]'))
Begin
ALTER TABLE [dbo].[dashCommerce_Store_Download] ADD  CONSTRAINT [DF_dashCommerce_Store_Download_CreatedOn]  DEFAULT (getutcdate()) FOR [CreatedOn]

End
GO
/****** Object:  Default [DF_dashCommerce_Store_Download_ModifiedOn]    Script Date: 05/16/2009 13:24:30 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_dashCommerce_Store_Download_ModifiedOn]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Download]'))
Begin
ALTER TABLE [dbo].[dashCommerce_Store_Download] ADD  CONSTRAINT [DF_dashCommerce_Store_Download_ModifiedOn]  DEFAULT (getutcdate()) FOR [ModifiedOn]

End
GO
/****** Object:  ForeignKey [FK_dashCommerce_Store_DownloadAccessControl_dashCommerce_Store_Download]    Script Date: 05/16/2009 13:24:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_DownloadAccessControl_dashCommerce_Store_Download]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_DownloadAccessControl]'))
ALTER TABLE [dbo].[dashCommerce_Store_DownloadAccessControl]  WITH CHECK ADD  CONSTRAINT [FK_dashCommerce_Store_DownloadAccessControl_dashCommerce_Store_Download] FOREIGN KEY([DownloadId])
REFERENCES [dbo].[dashCommerce_Store_Download] ([DownloadId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_DownloadAccessControl] CHECK CONSTRAINT [FK_dashCommerce_Store_DownloadAccessControl_dashCommerce_Store_Download]
GO
/****** Object:  Table [dbo].[dashCommerce_Store_Product_Download_Map]    Script Date: 05/17/2009 13:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dashCommerce_Store_Product_Download_Map](
	[ProductId] [int] NOT NULL,
	[DownloadId] [int] NOT NULL,
 CONSTRAINT [PK_dashCommerce_Store_Product_Download_Map] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[DownloadId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[dashCommerce_Store_Product_Download_Map]  WITH CHECK ADD  CONSTRAINT [FK_dashCommerce_Store_Product_Download_Map_dashCommerce_Store_Download] FOREIGN KEY([DownloadId])
REFERENCES [dbo].[dashCommerce_Store_Download] ([DownloadId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_Product_Download_Map] CHECK CONSTRAINT [FK_dashCommerce_Store_Product_Download_Map_dashCommerce_Store_Download]
GO
ALTER TABLE [dbo].[dashCommerce_Store_Product_Download_Map]  WITH CHECK ADD  CONSTRAINT [FK_dashCommerce_Store_Product_Download_Map_dashCommerce_Store_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[dashCommerce_Store_Product] ([ProductId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_Product_Download_Map] CHECK CONSTRAINT [FK_dashCommerce_Store_Product_Download_Map_dashCommerce_Store_Product]
GO
/****** Object:  Table [dbo].[dashCommerce_Store_Version]    Script Date: 05/16/2009 13:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Version]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_Version](
	[VersionId] [int] IDENTITY(1,1) NOT NULL,
	[Major] [int] NOT NULL,
	[Minor] [int] NOT NULL,
	[Build] [int] NOT NULL,
	[Revision] [int] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Version_CreatedOn] DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Version_ModifiedOn] DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_Store_Version] PRIMARY KEY CLUSTERED 
(
	[VersionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_CustomizedProductDisplay]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Content_CustomizedProductDisplay](
	[CustomizedProductDisplayId] [int] IDENTITY(1,1) NOT NULL,
	[CustomizedProductDisplayTypeId] [int] NOT NULL,
	[RegionId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Content_CustomizedProductsDisplay_CreatedOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Content_CustomizedProductsDisplay_ModifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_Content_CustomizedProductsDisplay] PRIMARY KEY CLUSTERED 
(
	[CustomizedProductDisplayId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_CustomizedProductDisplayType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_CustomizedProductDisplayType](
	[CustomizedProductDisplayTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Content_CustomizedProductsDisplayType_CreatedOn]  DEFAULT (getutcdate()),
	[ModifiedBy] [nvarchar](50) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Content_CustomizedProductsDisplayType_ModifiedOn]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_dashCommerce_Content_CustomizedProductsDisplayType] PRIMARY KEY CLUSTERED 
(
	[CustomizedProductDisplayTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_CustomizedProductDisplayType_Product_Map]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dashCommerce_Store_CustomizedProductDisplayType_Product_Map](
	[CustomizedProductDisplayTypeId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_CustomizedProductsDisplayType_Product_Map] PRIMARY KEY CLUSTERED 
(
	[CustomizedProductDisplayTypeId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_dashCommerce_Store_ToDo_CreatedOn]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_ToDo]'))
ALTER TABLE [dbo].[dashCommerce_Store_ToDo] ADD  CONSTRAINT [DF_dashCommerce_Store_ToDo_CreatedOn]  DEFAULT (getutcdate()) FOR [CreatedOn]
GO
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_dashCommerce_Store_ToDo_ModifiedOn]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_ToDo]'))
ALTER TABLE [dbo].[dashCommerce_Store_ToDo] ADD  CONSTRAINT [DF_dashCommerce_Store_ToDo_ModifiedOn]  DEFAULT (getutcdate()) FOR [ModifiedOn]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_OrderNote_dashCommerce_Store_Order]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_OrderNote]'))
ALTER TABLE [dbo].[dashCommerce_Store_OrderNote]  WITH NOCHECK ADD  CONSTRAINT [FK_dashCommerce_Store_OrderNote_dashCommerce_Store_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[dashCommerce_Store_Order] ([OrderId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_OrderNote] CHECK CONSTRAINT [FK_dashCommerce_Store_OrderNote_dashCommerce_Store_Order]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_OrderTransactions_dashCommerce_OrderTransactionTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Transaction]'))
ALTER TABLE [dbo].[dashCommerce_Store_Transaction]  WITH NOCHECK ADD  CONSTRAINT [FK_dashCommerce_OrderTransactions_dashCommerce_OrderTransactionTypes] FOREIGN KEY([TransactionTypeDescriptorId])
REFERENCES [dbo].[dashCommerce_Store_TransactionTypeDescriptor] ([TransactionTypeDescriptorId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_Transaction] CHECK CONSTRAINT [FK_dashCommerce_OrderTransactions_dashCommerce_OrderTransactionTypes]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_Transaction_dashCommerce_Store_Order]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Transaction]'))
ALTER TABLE [dbo].[dashCommerce_Store_Transaction]  WITH NOCHECK ADD  CONSTRAINT [FK_dashCommerce_Store_Transaction_dashCommerce_Store_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[dashCommerce_Store_Order] ([OrderId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_Transaction] CHECK CONSTRAINT [FK_dashCommerce_Store_Transaction_dashCommerce_Store_Order]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_OrderItem_dashCommerce_Store_Order]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_OrderItem]'))
ALTER TABLE [dbo].[dashCommerce_Store_OrderItem]  WITH NOCHECK ADD  CONSTRAINT [FK_dashCommerce_Store_OrderItem_dashCommerce_Store_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[dashCommerce_Store_Order] ([OrderId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_OrderItem] CHECK CONSTRAINT [FK_dashCommerce_Store_OrderItem_dashCommerce_Store_Order]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Products_dashCommerce_Manufacturers]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Product]'))
ALTER TABLE [dbo].[dashCommerce_Store_Product]  WITH NOCHECK ADD  CONSTRAINT [FK_dashCommerce_Products_dashCommerce_Manufacturers] FOREIGN KEY([ManufacturerId])
REFERENCES [dbo].[dashCommerce_Store_Manufacturer] ([ManufacturerId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_Product] CHECK CONSTRAINT [FK_dashCommerce_Products_dashCommerce_Manufacturers]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Products_dashCommerce_ProductStatus]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Product]'))
ALTER TABLE [dbo].[dashCommerce_Store_Product]  WITH NOCHECK ADD  CONSTRAINT [FK_dashCommerce_Products_dashCommerce_ProductStatus] FOREIGN KEY([ProductStatusDescriptorId])
REFERENCES [dbo].[dashCommerce_Store_ProductStatusDescriptor] ([ProductStatusDescriptorId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_Product] CHECK CONSTRAINT [FK_dashCommerce_Products_dashCommerce_ProductStatus]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Products_dashCommerce_ProductType]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Product]'))
ALTER TABLE [dbo].[dashCommerce_Store_Product]  WITH NOCHECK ADD  CONSTRAINT [FK_dashCommerce_Products_dashCommerce_ProductType] FOREIGN KEY([ProductTypeId])
REFERENCES [dbo].[dashCommerce_Store_ProductType] ([ProductTypeId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_Product] CHECK CONSTRAINT [FK_dashCommerce_Products_dashCommerce_ProductType]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Products_dashCommerce_ShipEstimates]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Product]'))
ALTER TABLE [dbo].[dashCommerce_Store_Product]  WITH NOCHECK ADD  CONSTRAINT [FK_dashCommerce_Products_dashCommerce_ShipEstimates] FOREIGN KEY([ShippingEstimateId])
REFERENCES [dbo].[dashCommerce_Store_ShippingEstimate] ([ShippingEstimateId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_Product] CHECK CONSTRAINT [FK_dashCommerce_Products_dashCommerce_ShipEstimates]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_Attribute_dashCommerce_Store_AttributeType]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Attribute]'))
ALTER TABLE [dbo].[dashCommerce_Store_Attribute]  WITH NOCHECK ADD  CONSTRAINT [FK_dashCommerce_Store_Attribute_dashCommerce_Store_AttributeType] FOREIGN KEY([AttributeTypeId])
REFERENCES [dbo].[dashCommerce_Store_AttributeType] ([AttributeTypeId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_Attribute] CHECK CONSTRAINT [FK_dashCommerce_Store_Attribute_dashCommerce_Store_AttributeType]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_Order_dashCommerce_Store_OrderStatusDescriptor]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Order]'))
ALTER TABLE [dbo].[dashCommerce_Store_Order]  WITH NOCHECK ADD  CONSTRAINT [FK_dashCommerce_Store_Order_dashCommerce_Store_OrderStatusDescriptor] FOREIGN KEY([OrderStatusDescriptorId])
REFERENCES [dbo].[dashCommerce_Store_OrderStatusDescriptor] ([OrderStatusDescriptorId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_Order] CHECK CONSTRAINT [FK_dashCommerce_Store_Order_dashCommerce_Store_OrderStatusDescriptor]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Products_Categories_dashCommerce_ProductCategories]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Product_Category_Map]'))
ALTER TABLE [dbo].[dashCommerce_Store_Product_Category_Map]  WITH NOCHECK ADD  CONSTRAINT [FK_dashCommerce_Products_Categories_dashCommerce_ProductCategories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[dashCommerce_Store_Category] ([CategoryId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_Product_Category_Map] CHECK CONSTRAINT [FK_dashCommerce_Products_Categories_dashCommerce_ProductCategories]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Products_Categories_dashCommerce_Products]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Product_Category_Map]'))
ALTER TABLE [dbo].[dashCommerce_Store_Product_Category_Map]  WITH NOCHECK ADD  CONSTRAINT [FK_dashCommerce_Products_Categories_dashCommerce_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[dashCommerce_Store_Product] ([ProductId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_Product_Category_Map] CHECK CONSTRAINT [FK_dashCommerce_Products_Categories_dashCommerce_Products]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Content_Page_Region_Map_dashCommerce_Content_Page]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_Page_Region_Map]'))
ALTER TABLE [dbo].[dashCommerce_Content_Page_Region_Map]  WITH CHECK ADD  CONSTRAINT [FK_dashCommerce_Content_Page_Region_Map_dashCommerce_Content_Page] FOREIGN KEY([PageId])
REFERENCES [dbo].[dashCommerce_Content_Page] ([PageId])
GO
ALTER TABLE [dbo].[dashCommerce_Content_Page_Region_Map] CHECK CONSTRAINT [FK_dashCommerce_Content_Page_Region_Map_dashCommerce_Content_Page]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Content_Page_Region_Map_dashCommerce_Content_Region]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_Page_Region_Map]'))
ALTER TABLE [dbo].[dashCommerce_Content_Page_Region_Map]  WITH CHECK ADD  CONSTRAINT [FK_dashCommerce_Content_Page_Region_Map_dashCommerce_Content_Region] FOREIGN KEY([RegionId])
REFERENCES [dbo].[dashCommerce_Content_Region] ([RegionId])
GO
ALTER TABLE [dbo].[dashCommerce_Content_Page_Region_Map] CHECK CONSTRAINT [FK_dashCommerce_Content_Page_Region_Map_dashCommerce_Content_Region]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_Product_Attribute_Map_dashCommerce_Store_Attribute]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Product_Attribute_Map]'))
ALTER TABLE [dbo].[dashCommerce_Store_Product_Attribute_Map]  WITH NOCHECK ADD  CONSTRAINT [FK_dashCommerce_Store_Product_Attribute_Map_dashCommerce_Store_Attribute] FOREIGN KEY([AttributeId])
REFERENCES [dbo].[dashCommerce_Store_Attribute] ([AttributeId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_Product_Attribute_Map] CHECK CONSTRAINT [FK_dashCommerce_Store_Product_Attribute_Map_dashCommerce_Store_Attribute]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_Product_Attribute_Map_dashCommerce_Store_Product]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Product_Attribute_Map]'))
ALTER TABLE [dbo].[dashCommerce_Store_Product_Attribute_Map]  WITH NOCHECK ADD  CONSTRAINT [FK_dashCommerce_Store_Product_Attribute_Map_dashCommerce_Store_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[dashCommerce_Store_Product] ([ProductId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_Product_Attribute_Map] CHECK CONSTRAINT [FK_dashCommerce_Store_Product_Attribute_Map_dashCommerce_Store_Product]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Promo_Product_CrossSell_Map_dashCommerce_Store_Product]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_CrossSell]'))
ALTER TABLE [dbo].[dashCommerce_Store_CrossSell]  WITH NOCHECK ADD  CONSTRAINT [FK_dashCommerce_Promo_Product_CrossSell_Map_dashCommerce_Store_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[dashCommerce_Store_Product] ([ProductId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_CrossSell] CHECK CONSTRAINT [FK_dashCommerce_Promo_Product_CrossSell_Map_dashCommerce_Store_Product]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Promo_Product_CrossSell_Map_dashCommerce_Store_Product1]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_CrossSell]'))
ALTER TABLE [dbo].[dashCommerce_Store_CrossSell]  WITH NOCHECK ADD  CONSTRAINT [FK_dashCommerce_Promo_Product_CrossSell_Map_dashCommerce_Store_Product1] FOREIGN KEY([CrossProductId])
REFERENCES [dbo].[dashCommerce_Store_Product] ([ProductId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_CrossSell] CHECK CONSTRAINT [FK_dashCommerce_Promo_Product_CrossSell_Map_dashCommerce_Store_Product1]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_Sku_dashCommerce_Store_Product]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Sku]'))
ALTER TABLE [dbo].[dashCommerce_Store_Sku]  WITH NOCHECK ADD  CONSTRAINT [FK_dashCommerce_Store_Sku_dashCommerce_Store_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[dashCommerce_Store_Product] ([ProductId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_Sku] CHECK CONSTRAINT [FK_dashCommerce_Store_Sku_dashCommerce_Store_Product]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_ProductDescriptor_dashCommerce_Store_Product]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Descriptor]'))
ALTER TABLE [dbo].[dashCommerce_Store_Descriptor]  WITH NOCHECK ADD  CONSTRAINT [FK_dashCommerce_Store_ProductDescriptor_dashCommerce_Store_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[dashCommerce_Store_Product] ([ProductId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_Descriptor] CHECK CONSTRAINT [FK_dashCommerce_Store_ProductDescriptor_dashCommerce_Store_Product]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_ProductImages_dashCommerce_Products]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Image]'))
ALTER TABLE [dbo].[dashCommerce_Store_Image]  WITH NOCHECK ADD  CONSTRAINT [FK_dashCommerce_ProductImages_dashCommerce_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[dashCommerce_Store_Product] ([ProductId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_Image] CHECK CONSTRAINT [FK_dashCommerce_ProductImages_dashCommerce_Products]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_Review_dashCommerce_Store_Product]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_Review]'))
ALTER TABLE [dbo].[dashCommerce_Store_Review]  WITH NOCHECK ADD  CONSTRAINT [FK_dashCommerce_Store_Review_dashCommerce_Store_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[dashCommerce_Store_Product] ([ProductId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_Review] CHECK CONSTRAINT [FK_dashCommerce_Store_Review_dashCommerce_Store_Product]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Content_Template_TemplateRegion_Map_dashCommerce_Content_Template]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_Template_TemplateRegion_Map]'))
ALTER TABLE [dbo].[dashCommerce_Content_Template_TemplateRegion_Map]  WITH CHECK ADD  CONSTRAINT [FK_dashCommerce_Content_Template_TemplateRegion_Map_dashCommerce_Content_Template] FOREIGN KEY([TemplateId])
REFERENCES [dbo].[dashCommerce_Content_Template] ([TemplateId])
GO
ALTER TABLE [dbo].[dashCommerce_Content_Template_TemplateRegion_Map] CHECK CONSTRAINT [FK_dashCommerce_Content_Template_TemplateRegion_Map_dashCommerce_Content_Template]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Content_Template_TemplateRegion_Map_dashCommerce_Content_TemplateRegion]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_Template_TemplateRegion_Map]'))
ALTER TABLE [dbo].[dashCommerce_Content_Template_TemplateRegion_Map]  WITH CHECK ADD  CONSTRAINT [FK_dashCommerce_Content_Template_TemplateRegion_Map_dashCommerce_Content_TemplateRegion] FOREIGN KEY([TemplateRegionId])
REFERENCES [dbo].[dashCommerce_Content_TemplateRegion] ([TemplateRegionId])
GO
ALTER TABLE [dbo].[dashCommerce_Content_Template_TemplateRegion_Map] CHECK CONSTRAINT [FK_dashCommerce_Content_Template_TemplateRegion_Map_dashCommerce_Content_TemplateRegion]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Content_Region_dashCommerce_Content_TemplateRegion]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Content_Region]'))
ALTER TABLE [dbo].[dashCommerce_Content_Region]  WITH CHECK ADD  CONSTRAINT [FK_dashCommerce_Content_Region_dashCommerce_Content_TemplateRegion] FOREIGN KEY([TemplateRegionId])
REFERENCES [dbo].[dashCommerce_Content_TemplateRegion] ([TemplateRegionId])
GO
ALTER TABLE [dbo].[dashCommerce_Content_Region] CHECK CONSTRAINT [FK_dashCommerce_Content_Region_dashCommerce_Content_TemplateRegion]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_AttributeItem_dashCommerce_Store_Attribute]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_AttributeItem]'))
ALTER TABLE [dbo].[dashCommerce_Store_AttributeItem]  WITH NOCHECK ADD  CONSTRAINT [FK_dashCommerce_Store_AttributeItem_dashCommerce_Store_Attribute] FOREIGN KEY([AttributeId])
REFERENCES [dbo].[dashCommerce_Store_Attribute] ([AttributeId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_AttributeItem] CHECK CONSTRAINT [FK_dashCommerce_Store_AttributeItem_dashCommerce_Store_Attribute]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CustomizedProductDisplayType_Product_Map_dashCommerce_Store_Product]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_CustomizedProductDisplayType_Product_Map]'))
ALTER TABLE [dbo].[dashCommerce_Store_CustomizedProductDisplayType_Product_Map]  WITH CHECK ADD  CONSTRAINT [FK_CustomizedProductDisplayType_Product_Map_dashCommerce_Store_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[dashCommerce_Store_Product] ([ProductId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_CustomizedProductDisplayType_Product_Map] CHECK CONSTRAINT [FK_CustomizedProductDisplayType_Product_Map_dashCommerce_Store_Product]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dashCommerce_Store_CustomizedProductDisplayType_Product_Map_dashCommerce_Store_CustomizedProductDisplayType]') AND parent_object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_CustomizedProductDisplayType_Product_Map]'))
ALTER TABLE [dbo].[dashCommerce_Store_CustomizedProductDisplayType_Product_Map]  WITH CHECK ADD  CONSTRAINT [FK_dashCommerce_Store_CustomizedProductDisplayType_Product_Map_dashCommerce_Store_CustomizedProductDisplayType] FOREIGN KEY([CustomizedProductDisplayTypeId])
REFERENCES [dbo].[dashCommerce_Store_CustomizedProductDisplayType] ([CustomizedProductDisplayTypeId])
GO
ALTER TABLE [dbo].[dashCommerce_Store_CustomizedProductDisplayType_Product_Map] CHECK CONSTRAINT [FK_dashCommerce_Store_CustomizedProductDisplayType_Product_Map_dashCommerce_Store_CustomizedProductDisplayType]
GO
