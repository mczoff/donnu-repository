GO
DROP PROCEDURE IF EXISTS TestWorksByFreelancers;

GO
CREATE PROC TestWorksByFreelancers
AS 
BEGIN

DECLARE @count INT
SET @count = (SELECT COUNT(*) FROM Works LEFT JOIN Freelancers ON Freelancers.Id = Works.FreelancerId WHERE MainSpecialization IS NULL)

IF @count = 0
RETURN 1
ELSE
RETURN 0

END

GO
EXEC [dbo].[TestWorksByFreelancers] 
