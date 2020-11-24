CREATE PROCEDURE [dbo].[GetAllActorByInitial]
	@initialFN char

AS Begin
	SELECT ActorId, FirstName, LastName
	FROM Actor 
	WHERE left(FirstName, 1) = @initialFN
end