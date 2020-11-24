CREATE PROCEDURE [dbo].[GetAllActorInitials]

AS
BEGIN
	SELECT distinct 
		left(FirstName, 1) as InitialFirstName
	FROM Actor A
END
