DECLARE @variable INT;

SET @variable = (SELECT Min(CAST([Identificator] AS INT))
  FROM [HFWDB].[dbo].[Employers])

SELECT @variable