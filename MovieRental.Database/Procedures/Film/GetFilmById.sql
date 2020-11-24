CREATE PROCEDURE [dbo].[GetFilmById]
	@FilmId int
AS begin
	select * from V_Film where FilmId = @FilmId
end
