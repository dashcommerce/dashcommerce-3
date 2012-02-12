INSERT [dbo].[dashCommerce_Store_Manufacturer] ([Name], [CreatedBy], [ModifiedBy]) VALUES (N'BrewHouse Coffee', N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Manufacturer] ([Name], [CreatedBy], [ModifiedBy]) VALUES (N'Preferred Cottons', N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Manufacturer] ([Name], [CreatedBy], [ModifiedBy]) VALUES (N'Tilda Coffee', N'sampleinstall', N'sampleinstall')

INSERT [dbo].[dashCommerce_Core_ConfigurationData] ([Name], [Type], [Value], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (N'mailSettings', N'MettleSystems.dashCommerce.Store.MailSettings, MettleSystems.dashCommerce.Store, Version=3.2.0.21515, Culture=neutral, PublicKeyToken=null', N'<?xml version="1.0"?>
<MailSettings xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <From>sampleinstall@dashcommerce.org</From>
  <Host>mail.dashcommerce.org</Host>
  <UserName>admin@dashcommerce.org</UserName>
  <Password>XiCtDUk6ik0WVKU98fS</Password>
  <Port>25</Port>
  <RequireSsl>false</RequireSsl>
  <RequireAuthentication>true</RequireAuthentication>
</MailSettings>', N'sampleinstall', N'sampleinstall', 0)
INSERT [dbo].[dashCommerce_Core_ConfigurationData] ([Name], [Type], [Value], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (N'shippingServiceSettings', N'MettleSystems.dashCommerce.Store.Services.ShippingService.ShippingServiceSettings, MettleSystems.dashCommerce.Store, Version=3.2.0.21515, Culture=neutral, PublicKeyToken=null', N'<?xml version="1.0"?>
<ShippingServiceSettings xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" DefaultProvider="SimpleWeightShippingProvider" UseShipping="true" ShipFromZip="44118" ShipFromCountryCode="US" ShippingBuffer="0">
  <ProviderSettingsCollection>
    <ProviderSettings Name="SimpleWeightShippingProvider" Type="MettleSystems.dashCommerce.Store.Services.ShippingService.SimpleWeightShippingProvider, MettleSystems.dashCommerce.Store, Version=3.2.0.21515, Culture=neutral, PublicKeyToken=null" />
  </ProviderSettingsCollection>
</ShippingServiceSettings>', N'sampleinstall', N'sampleinstall', 0)
INSERT [dbo].[dashCommerce_Core_ConfigurationData] ([Name], [Type], [Value], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES ('taxServiceSettings', N'MettleSystems.dashCommerce.Store.Services.TaxService.TaxServiceSettings, MettleSystems.dashCommerce.Store, Version=3.2.0.21515, Culture=neutral, PublicKeyToken=null', N'<?xml version="1.0"?>
<TaxServiceSettings xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" DefaultProvider="RegionCodeTaxProvider">
  <ProviderSettingsCollection>
    <ProviderSettings Name="RegionCodeTaxProvider" Type="MettleSystems.dashCommerce.Store.Services.TaxService.RegionCodeTaxProvider, MettleSystems.dashCommerce.Store, Version=3.2.0.21515, Culture=neutral, PublicKeyToken=null" DefaultRate=".08" />
  </ProviderSettingsCollection>
</TaxServiceSettings>', N'sampleinstall', N'sampleinstall', 0)

INSERT [dbo].[dashCommerce_Store_SimpleWeightShippingRate] ([Service], [AmountPerUnit], [CreatedBy], [ModifiedBy]) VALUES (N'Ground', 1.0000, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_SimpleWeightShippingRate] ([Service], [AmountPerUnit], [CreatedBy], [ModifiedBy]) VALUES (N'Express', 2.0000, N'sampleinstall',  N'sampleinstall')

INSERT [dbo].[dashCommerce_Store_Category] ([CategoryGuid], [ParentId], [Name], [ImageFile], [Description], [SortOrder], [CreatedBy], [ModifiedBy]) VALUES ('e809ca3b-cfa8-42bf-8fdc-e929326d0f1a', 0, N'Drinks', N'', N'Try our lovely selection of drinks!', 0, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Category] ([CategoryGuid], [ParentId], [Name], [ImageFile], [Description], [SortOrder], [CreatedBy], [ModifiedBy]) VALUES (N'4db75124-9314-4f6c-88e7-8a4e93f1f099', 1, N'Coffee', N'', N'mmmmmmm COFFEE!', 1, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Category] ([CategoryGuid], [ParentId], [Name], [ImageFile], [Description], [SortOrder], [CreatedBy], [ModifiedBy]) VALUES (N'498f6d5b-1633-4d99-8ab7-2ac70ce0e7ce', 0, N'Clothing', N'', N'Let everybody know about your preferred coffees!', 0, N'sampleinstall', N'sampleinstall')

INSERT [dbo].[dashCommerce_Store_Product] ([ManufacturerId], [ProductStatusDescriptorId], [ProductTypeId], [ShippingEstimateId], [BaseSku], [ProductGuid], [Name], [ShortDescription], [OurPrice], [RetailPrice], [Weight], [Length], [Height], [Width], [SortOrder], [RatingSum], [TotalRatingVotes], [AllowNegativeInventories], [IsEnabled], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (1, 1, 1, 1, N'COFFEE', N'bb60729b-5b78-4ed9-8efa-a97a97b7956b', N'Java Blend', N'This blend of coffee was created by our Roastmaster after 3 years of careful trial and error for the best morning blend. Take one sip and you will begin to understand what perseverence is all about.&lt;br /&gt;
&lt;br /&gt;
The aroma''s of the coffee bean fields will permeate your kitchen in the morning when you brew this lovely blend.', 15.0000, 0.0000, CAST(1.0000 AS Numeric(19, 4)), CAST(4 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), 0, 3, 1, 1, 1, N'sampleinstall', N'sampleinstall', 0)
INSERT [dbo].[dashCommerce_Store_Product] ([ManufacturerId], [ProductStatusDescriptorId], [ProductTypeId], [ShippingEstimateId], [BaseSku], [ProductGuid], [Name], [ShortDescription], [OurPrice], [RetailPrice], [Weight], [Length], [Height], [Width], [SortOrder], [RatingSum], [TotalRatingVotes], [AllowNegativeInventories], [IsEnabled], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (3, 1, 1, 1, N'KUMERA', N'ea40567c-88f4-4639-9c6e-403e11709a4d', N'Kumera Coffee', N'&amp;nbsp;From the mountain-side fields of Columbia, the beans for Kumera Blend offer a depth and savoriness seldon seen in decafinated coffees.', 20.0000, 0.0000, CAST(1.0000 AS Numeric(19, 4)), CAST(4 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), 0, 3, 1, 1, 1, N'sampleinstall', N'sampleinstall', 0)
INSERT [dbo].[dashCommerce_Store_Product] ([ManufacturerId], [ProductStatusDescriptorId], [ProductTypeId], [ShippingEstimateId], [BaseSku], [ProductGuid], [Name], [ShortDescription], [OurPrice], [RetailPrice], [Weight], [Length], [Height], [Width], [SortOrder], [RatingSum], [TotalRatingVotes], [AllowNegativeInventories], [IsEnabled], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (1, 1, 1, 1, N'T-SHIRT', N'221c064e-ebe3-4d2f-ab48-2ade317f3266', N'Brew House T-Shirt', N'&amp;nbsp;Let everyone know how much you love Brew House cofffee with this cotton blend t-shirt.', 20.0000, 0.0000, CAST(2.0000 AS Numeric(19, 4)), CAST(8 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), 0, 3, 1, 0, 1, N'sampleinstall', N'sampleinstall', 0)
INSERT [dbo].[dashCommerce_Store_Product] ([ManufacturerId], [ProductStatusDescriptorId], [ProductTypeId], [ShippingEstimateId], [BaseSku], [ProductGuid], [Name], [ShortDescription], [OurPrice], [RetailPrice], [Weight], [Length], [Height], [Width], [SortOrder], [RatingSum], [TotalRatingVotes], [AllowNegativeInventories], [IsEnabled], [CreatedBy], [ModifiedBy], [IsDeleted]) VALUES (1, 1, 1, 1, N'POLO', N'7ac08f7c-212c-408e-9c9d-6d22d2f53784', N'Brew House Polo', N'&amp;nbsp;The Brew House Polo is great for the office or the golf outing. Let everyone know about your favorite coffee!', 25.0000, 0.0000, CAST(3.0000 AS Numeric(19, 4)), CAST(8 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), 0, 3, 1, 0, 1, N'sampleinstall', N'sampleinstall', 0)

INSERT [dbo].[dashCommerce_Store_Attribute] ([AttributeTypeId], [Name], [Label]) VALUES (1, N'CoffeeSizes', N'Sizes:')
INSERT [dbo].[dashCommerce_Store_Attribute] ([AttributeTypeId], [Name], [Label]) VALUES (1, N'ShirtSize', N'Size:')
INSERT [dbo].[dashCommerce_Store_Attribute] ([AttributeTypeId], [Name], [Label]) VALUES (1, N'Color', N'Color:')
INSERT [dbo].[dashCommerce_Store_Attribute] ([AttributeTypeId], [Name], [Label]) VALUES (1, N'Gender', N'Gender:')

INSERT [dbo].[dashCommerce_Store_Product_Attribute_Map] ([AttributeId], [ProductId], [SortOrder], [IsRequired]) VALUES (1, 1, 1, 1)
INSERT [dbo].[dashCommerce_Store_Product_Attribute_Map] ([AttributeId], [ProductId], [SortOrder], [IsRequired]) VALUES (1, 2, 1, 1)
INSERT [dbo].[dashCommerce_Store_Product_Attribute_Map] ([AttributeId], [ProductId], [SortOrder], [IsRequired]) VALUES (2, 3, 3, 1)
INSERT [dbo].[dashCommerce_Store_Product_Attribute_Map] ([AttributeId], [ProductId], [SortOrder], [IsRequired]) VALUES (2, 4, 3, 1)
INSERT [dbo].[dashCommerce_Store_Product_Attribute_Map] ([AttributeId], [ProductId], [SortOrder], [IsRequired]) VALUES (3, 3, 1, 1)
INSERT [dbo].[dashCommerce_Store_Product_Attribute_Map] ([AttributeId], [ProductId], [SortOrder], [IsRequired]) VALUES (3, 4, 1, 1)
INSERT [dbo].[dashCommerce_Store_Product_Attribute_Map] ([AttributeId], [ProductId], [SortOrder], [IsRequired]) VALUES (4, 3, 2, 1)
INSERT [dbo].[dashCommerce_Store_Product_Attribute_Map] ([AttributeId], [ProductId], [SortOrder], [IsRequired]) VALUES (4, 4, 2, 1)

INSERT [dbo].[dashCommerce_Store_AttributeItem] ([AttributeId], [Name], [Adjustment], [SortOrder], [SkuSuffix]) VALUES (1, N'12 oz', 0.0000, 1, N'12')
INSERT [dbo].[dashCommerce_Store_AttributeItem] ([AttributeId], [Name], [Adjustment], [SortOrder], [SkuSuffix]) VALUES (1, N'24 oz', 5.0000, 2, N'24')
INSERT [dbo].[dashCommerce_Store_AttributeItem] ([AttributeId], [Name], [Adjustment], [SortOrder], [SkuSuffix]) VALUES (1, N'36 oz', 10.0000, 3, N'36')
INSERT [dbo].[dashCommerce_Store_AttributeItem] ([AttributeId], [Name], [Adjustment], [SortOrder], [SkuSuffix]) VALUES (2, N'Small', 0.0000, 1, N'S')
INSERT [dbo].[dashCommerce_Store_AttributeItem] ([AttributeId], [Name], [Adjustment], [SortOrder], [SkuSuffix]) VALUES (2, N'Medium', 0.0000, 2, N'M')
INSERT [dbo].[dashCommerce_Store_AttributeItem] ([AttributeId], [Name], [Adjustment], [SortOrder], [SkuSuffix]) VALUES (2, N'Large', 0.0000, 3, N'L')
INSERT [dbo].[dashCommerce_Store_AttributeItem] ([AttributeId], [Name], [Adjustment], [SortOrder], [SkuSuffix]) VALUES (2, N'Extra Large', 10.0000, 4, N'XL')
INSERT [dbo].[dashCommerce_Store_AttributeItem] ([AttributeId], [Name], [Adjustment], [SortOrder], [SkuSuffix]) VALUES (3, N'Red', 0.0000, 1, N'red')
INSERT [dbo].[dashCommerce_Store_AttributeItem] ([AttributeId], [Name], [Adjustment], [SortOrder], [SkuSuffix]) VALUES (3, N'Yellow', 0.0000, 2, N'yel')
INSERT [dbo].[dashCommerce_Store_AttributeItem] ([AttributeId], [Name], [Adjustment], [SortOrder], [SkuSuffix]) VALUES (3, N'Blue', 0.0000, 3, N'blu')
INSERT [dbo].[dashCommerce_Store_AttributeItem] ([AttributeId], [Name], [Adjustment], [SortOrder], [SkuSuffix]) VALUES (4, N'Male', 5.0000, 1, N'M')
INSERT [dbo].[dashCommerce_Store_AttributeItem] ([AttributeId], [Name], [Adjustment], [SortOrder], [SkuSuffix]) VALUES (4, N'Femail', 0.0000, 2, N'F')

INSERT [dbo].[dashCommerce_Store_Product_Category_Map] ([ProductId], [CategoryId], [CreatedBy], [ModifiedBy]) VALUES (1, 2, N'sampleinstall',  N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Product_Category_Map] ([ProductId], [CategoryId], [CreatedBy], [ModifiedBy]) VALUES (2, 2, N'sampleinstall',  N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Product_Category_Map] ([ProductId], [CategoryId], [CreatedBy], [ModifiedBy]) VALUES (3, 3, N'sampleinstall',  N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Product_Category_Map] ([ProductId], [CategoryId], [CreatedBy], [ModifiedBy]) VALUES (4, 3, N'sampleinstall',  N'sampleinstall')

SET IDENTITY_INSERT [dbo].[dashCommerce_Store_Sku] ON
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (1, 1, N'COFFEE-12', 0, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (2, 1, N'COFFEE-24', -2, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (3, 1, N'COFFEE-36', 0, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (4, 2, N'KUMERA-12', 0, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (5, 2, N'KUMERA-24', 0, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (6, 2, N'KUMERA-36', 0, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (7, 3, N'T-SHIRT-red-M-S', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (8, 3, N'T-SHIRT-red-M-M', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (9, 3, N'T-SHIRT-red-M-L', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (10, 3, N'T-SHIRT-red-M-XL', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (11, 3, N'T-SHIRT-red-F-S', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (12, 3, N'T-SHIRT-red-F-M', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (13, 3, N'T-SHIRT-red-F-L', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (14, 3, N'T-SHIRT-red-F-XL', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (15, 3, N'T-SHIRT-yel-M-S', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (16, 3, N'T-SHIRT-yel-M-M', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (17, 3, N'T-SHIRT-yel-M-L', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (18, 3, N'T-SHIRT-yel-M-XL', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (19, 3, N'T-SHIRT-yel-F-S', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (20, 3, N'T-SHIRT-yel-F-M', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (21, 3, N'T-SHIRT-yel-F-L', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (22, 3, N'T-SHIRT-yel-F-XL', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (23, 3, N'T-SHIRT-blu-M-S', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (24, 3, N'T-SHIRT-blu-M-M', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (25, 3, N'T-SHIRT-blu-M-L', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (26, 3, N'T-SHIRT-blu-M-XL', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (27, 3, N'T-SHIRT-blu-F-S', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (28, 3, N'T-SHIRT-blu-F-M', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (29, 3, N'T-SHIRT-blu-F-L', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (30, 3, N'T-SHIRT-blu-F-XL', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (31, 4, N'POLO-red-M-S', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (32, 4, N'POLO-red-M-M', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (33, 4, N'POLO-red-M-L', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (34, 4, N'POLO-red-M-XL', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (35, 4, N'POLO-red-F-S', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (36, 4, N'POLO-red-F-M', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (37, 4, N'POLO-red-F-L', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (38, 4, N'POLO-red-F-XL', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (39, 4, N'POLO-yel-M-S', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (40, 4, N'POLO-yel-M-M', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (41, 4, N'POLO-yel-M-L', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (42, 4, N'POLO-yel-M-XL', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (43, 4, N'POLO-yel-F-S', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (44, 4, N'POLO-yel-F-M', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (45, 4, N'POLO-yel-F-L', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (46, 4, N'POLO-yel-F-XL', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (47, 4, N'POLO-blu-M-S', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (48, 4, N'POLO-blu-M-M', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (49, 4, N'POLO-blu-M-L', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (50, 4, N'POLO-blu-M-XL', 19, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (51, 4, N'POLO-blu-F-S', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (52, 4, N'POLO-blu-F-M', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (53, 4, N'POLO-blu-F-L', 20, N'sampleinstall', N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Sku] ([SkuId], [ProductId], [Sku], [Inventory], [CreatedBy], [ModifiedBy]) VALUES (54, 4, N'POLO-blu-F-XL', 20, N'sampleinstall', N'sampleinstall')
SET IDENTITY_INSERT [dbo].[dashCommerce_Store_Sku] OFF


INSERT [dbo].[dashCommerce_Store_Descriptor] ([ProductId], [Title], [Descriptor], [SortOrder], [CreatedBy], [ModifiedBy]) VALUES (1, N'Brewing Instructions', N'&amp;nbsp;For the perfect cup, follow these instructions:&lt;br /&gt;
&lt;br /&gt;
&lt;table width=&quot;200&quot; border=&quot;1&quot; cellpadding=&quot;1&quot; cellspacing=&quot;1&quot;&gt;
    &lt;tbody&gt;
        &lt;tr&gt;
            &lt;td&gt;Scoops&lt;/td&gt;
            &lt;td&gt;2&lt;/td&gt;
        &lt;/tr&gt;
        &lt;tr&gt;
            &lt;td&gt;Temperature&lt;/td&gt;
            &lt;td&gt;150 degrees&lt;/td&gt;
        &lt;/tr&gt;
        &lt;tr&gt;
            &lt;td&gt;Filter&lt;/td&gt;
            &lt;td&gt;Fine&lt;/td&gt;
        &lt;/tr&gt;
    &lt;/tbody&gt;
&lt;/table&gt;
&lt;br type=&quot;_moz&quot; /&gt;', 1, N'sampleinstall',  N'sampleinstall')
INSERT [dbo].[dashCommerce_Store_Descriptor] ([ProductId], [Title], [Descriptor], [SortOrder], [CreatedBy], [ModifiedBy]) VALUES (1, N'Ingredients', N'Coffee Beans&lt;br /&gt;
Preservatives&lt;br /&gt;
Cherry Juice&lt;br /&gt;
Pomegranate Juice', 2, N'sampleinstall',  N'sampleinstall')
