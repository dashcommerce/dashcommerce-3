PRINT N'Altering dashCommerce_Store_Product'
GO
ALTER TABLE dashCommerce_Store_Product
ADD [TaxRateId] [int] NOT NULL CONSTRAINT [DF_dashCommerce_Store_Product_TaxRateId] DEFAULT ((0))
GO
PRINT N'Altering vw_dashCommerce_NotInActiveAndLocked_Products'
GO
ALTER VIEW [dbo].[vw_dashCommerce_NotInActiveAndLocked_Products]
AS
SELECT     ProductId, ManufacturerId, ProductStatusDescriptorId, ProductTypeId, ShippingEstimateId, BaseSku, ProductGuid, Name, ShortDescription, OurPrice, RetailPrice, TaxRateId, Weight, 
                      Length, Height, Width, SortOrder, RatingSum, TotalRatingVotes, AllowNegativeInventories, IsEnabled, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn, 
                      IsDeleted
FROM         dbo.dashCommerce_Store_Product
WHERE     (ProductStatusDescriptorId <> 99) AND (IsEnabled = 1) AND (IsDeleted = 0)
GO
PRINT N'Altering [dbo].[dashCommerce_Store_FetchMostPopularProducts]'
GO

-- ================================================================
-- Licensed Under the dashCommerce License 
-- http://dashcommerce.org/dashCommerce/license.aspx
-- Copyright (c) 2007 - 2008 Mettle Systems LLC, P.O. Box 181192 
-- Cleveland Heights, Ohio 44118, United States
-- ================================================================

ALTER PROCEDURE [dbo].[dashCommerce_Store_FetchMostPopularProducts]
  @BrowsingBehviorId int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    SELECT TOP 6 
        v.*
       ,COUNT(dashCommerce_Store_Browsing_Log.BrowsingLogId) AS ViewCount 
    FROM dashCommerce_Store_Browsing_Log 
    INNER JOIN vw_dashCommerce_NotInActiveAndLocked_Products v 
    ON dashCommerce_Store_Browsing_Log.RelevantId = v.ProductId
    WHERE dashCommerce_Store_Browsing_Log.BrowsingBehaviorId = @BrowsingBehviorId
    GROUP BY 
        v.ProductId
       ,v.ManufacturerId
       ,v.ProductStatusDescriptorId
       ,v.ProductTypeId
       ,v.ShippingEstimateId
       ,v.BaseSku
       ,v.ProductGuid
       ,v.[Name]
       ,v.ShortDescription
       ,v.OurPrice
       ,v.RetailPrice
	     ,v.TaxRateId
       ,v.Weight
       ,v.Length
       ,v.Height
       ,v.Width
       ,v.SortOrder
       ,v.RatingSum
       ,v.TotalRatingVotes
       ,v.IsEnabled
       ,v.AllowNegativeInventories
       ,v.CreatedBy
       ,v.CreatedOn
       ,v.ModifiedBy
       ,v.ModifiedOn
       ,v.IsDeleted
    ORDER BY ViewCount DESC
END
GO
PRINT N'Creating [dashCommerce_Store_VatTaxRate]'
GO
CREATE TABLE [dashCommerce_Store_VatTaxRate]
(
[VatTaxRateId] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (50) NOT NULL,
[Rate] [money] NOT NULL,
[CreatedBy] [nvarchar] (50) NULL,
[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_VatTaxRate_CreatedOn] DEFAULT (getutcdate()),
[ModifiedBy] [nvarchar] (50) NULL,
[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_dashCommerce_Store_VatTaxRate_ModifiedOn] DEFAULT (getutcdate())
) ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_dashCommerce_Store_VatTaxRate] on [dbo].[dashCommerce_Store_VatTaxRate]'
GO
ALTER TABLE [dbo].[dashCommerce_Store_VatTaxRate] ADD CONSTRAINT [PK_dashCommerce_Store_VatTaxRate] PRIMARY KEY CLUSTERED  ([VatTaxRateId]) ON [PRIMARY]
GO
/** Update the version number **/
UPDATE [dbo].[dashCommerce_Store_Version] SET [Major] = 3, [Minor] = 3, [Build] = 425, [Revision] = 0 WHERE [VersionId] = 1
GO
