GO
DROP PROCEDURE IF EXISTS InsertStampTags;

GO
CREATE PROC InsertStampTags
(
	@id uniqueidentifier,
	@tagtext nvarchar(50),
	@base nvarchar(50),
	@category int
)
AS 
BEGIN

INSERT INTO StampTags (Id, TagText, Base, Category) VALUES (@id, @tagtext, @base, @category)

END

GO
DECLARE @genid uniqueidentifier
SET @genid = NEWID()
EXEC [dbo].[InsertStampTags] @genid, 'Android', 'Mobile', 1
