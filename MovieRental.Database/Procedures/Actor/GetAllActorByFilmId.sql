CREATE PROCEDURE [dbo].[GetAllActorByFilmId]
	@IdFilm int
AS
BEGIN
	select A.ActorId, A.FirstName, A.LastName from Film F
	inner join FilmActor FA on (F.FilmId = FA.FilmId)
	inner join Actor A on (FA.ActorId = A.ActorId)
	where F.FilmId = @IdFilm
END
