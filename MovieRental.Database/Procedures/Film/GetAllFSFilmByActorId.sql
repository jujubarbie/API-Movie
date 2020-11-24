CREATE PROCEDURE [dbo].[GetAllFSFilmByActorId]
	@ActorId int

AS begin
	select F.FilmId, F.Title, F.ReleaseYear from FilmActor FA
	inner join Film F on (F.FilmId = FA.FilmId)
	where FA.ActorId = @ActorId
end
