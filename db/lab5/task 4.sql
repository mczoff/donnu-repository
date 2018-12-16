GO
DROP PROCEDURE IF EXISTS GetExpFreelancers;

GO
CREATE PROC GetExpFreelancers
(
	@minExp int,
	@maxExp int,
	@country nvarchar(50) = NULL
)
AS 
BEGIN

IF @country IS NULL
SELECT * FROM Freelancers WHERE Experience > @minExp AND Experience < @maxExp
ELSE
SELECT * FROM Freelancers WHERE Experience > @minExp AND Experience < @maxExp AND Country = @country
END

GO
EXEC [dbo].GetExpFreelancers -1, 2, 'Russia'
