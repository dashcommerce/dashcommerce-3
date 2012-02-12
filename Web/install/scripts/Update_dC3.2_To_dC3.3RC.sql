/****** Object:  StoredProcedure [dbo].[dashCommerce_Store_ProductSearch]    Script Date: 08/11/2009 20:47:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dashCommerce_Store_ProductSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dashCommerce_Store_ProductSearch]
GO

/** Now Drop the Full Text Indexes **/
IF OBJECTPROPERTY (object_id('dashCommerce_Store_Product'),'TableHasActiveFulltextIndex ') = 1
DROP FULLTEXT INDEX ON [dbo].[dashCommerce_Store_Product]
GO
IF EXISTS (SELECT * FROM sys.fulltext_catalogs WHERE name = N'dashCommerce_Catalog')
DROP FULLTEXT CATALOG dashCommerce_Catalog
GO

/****** Object:  StoredProcedure [dbo].[dashCommerce_Store_ProductSearch]    Script Date: 08/11/2009 20:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================================
-- Licensed Under the dashCommerce License 
-- http://dashcommerce.org/dashCommerce/license.aspx
-- Copyright (c) 2007 - 2008 Mettle Systems LLC, P.O. Box 181192 
-- Cleveland Heights, Ohio 44118, United States
-- ================================================================

CREATE PROCEDURE [dbo].[dashCommerce_Store_ProductSearch]
  @searchTerm nvarchar(100)
AS 
  BEGIN
    SET NOCOUNT ON
    
 	  SET @searchTerm = '%' + rtrim(ltrim(@searchTerm)) + '%'	

	  SELECT DISTINCT(p.ProductId) INTO #PRODUCTS
	  FROM 
	  dashCommerce_Store_Product p
	  LEFT OUTER JOIN
	  dashCommerce_Store_Descriptor d
	  ON p.ProductId = d.ProductId
	  WHERE 
	  patindex(@searchTerm, p.Name) > 0
	  OR
	  patindex(@searchTerm, isnull(p.ShortDescription, '')) > 0
	  OR
	  patindex(@searchTerm, d.Descriptor) > 0

	  SELECT p.* FROM  #PRODUCTS p2
	  INNER JOIN
	  vw_dashCommerce_NotInActiveAndLocked_Products p
	  ON p2.ProductId = p.ProductId

	  DROP TABLE #PRODUCTS    
  END
GO

/** Update the version number **/
UPDATE [dbo].[dashCommerce_Store_Version] SET [Major] = 3, [Minor] = 3, [Build] = 0, [Revision] = 0 WHERE [VersionId] = 1