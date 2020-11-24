CREATE PROCEDURE [dbo].[GetAllFilmShort]

AS BEGIN
	SELECT FilmId, Title, ReleaseYear  from Film
END
