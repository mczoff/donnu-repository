GO
DROP PROCEDURE IF EXISTS SelectWorksByDate;

GO
CREATE PROC SelectWorksByDate
(
	@lastDateTime DATE = NULL
)
AS 
BEGIN
SET @lastDateTime = COALESCE(@lastDateTime, (SELECT MAX(Registrated) FROM Works))

SELECT * FROM Works WHERE CAST(Registrated AS DATE) = CAST(@lastDateTime AS DATE)
END

GO
EXEC [dbo].[SelectWorksByDate] @lastDateTime = '12/10/2018' 
