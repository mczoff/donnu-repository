DECLARE CURSOR1 SCROLL CURSOR FOR (SELECT * FROM [HFWDB].[dbo].[TypeContact])
DECLARE @Id INT, @Name NVARCHAR(50)

OPEN CURSOR1 
CLOSE CURSOR1
DEALLOCATE CURSOR1