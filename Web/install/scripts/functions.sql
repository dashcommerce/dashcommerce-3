SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoryHierarchy]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE FUNCTION [dbo].[CategoryHierarchy] (@CategoryId int) 
RETURNS @Result TABLE (CategoryId int, ParentId int, Level smallint) 
AS 
BEGIN 
DECLARE @Level smallint 
-- get the top level node (magic requirement) 
-- get starting node 
SET @Level = 1 
INSERT @Result 
SELECT CategoryId, ParentId, @Level FROM dashCommerce_Store_Category WHERE CategoryId = @CategoryId 
WHILE @Level < 1000 BEGIN -- weak condition to catch infinite recursion 
-- get child nodes of current level''s nodes 
INSERT @Result 
SELECT t.CategoryId, t.ParentId, @Level + 1 FROM dashCommerce_Store_Category t 
JOIN @Result r ON t.ParentId = r.CategoryId AND @Level = r.Level 
-- no child nodes ==&gt; all done 
IF @@ROWCOUNT = 0 BREAK 
-- advance one level 
SET @Level = @Level + 1 
END 
RETURN 
END 

' 
END
GO
