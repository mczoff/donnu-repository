DECLARE CURSOR1 SCROLL INSENSITIVE CURSOR FOR (SELECT * FROM [HFWDB].[dbo].[TypeContact])
DECLARE @Id INT, @Name NVARCHAR(50), @INDEX INT
SET @INDEX = 0;

OPEN CURSOR1 

FETCH FIRST FROM CURSOR1 INTO @Id, @Name
WHILE @@FETCH_STATUS = 0
BEGIN
FETCH NEXT FROM CURSOR1 INTO @Id, @Name 
	SET @INDEX = @INDEX + 1

	IF(@INDEX = 5)
	BEGIN 
		PRINT @Id
		PRINT @Name
	END
END

CLOSE CURSOR1
DEALLOCATE CURSOR1