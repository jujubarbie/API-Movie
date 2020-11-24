CREATE PROCEDURE [dbo].[GetAllFSByLanguageId]
	@LanguageId int
AS
BEGIN
	SELECT FilmId, Title, ReleaseYear
	FROM Film 
	WHERE LanguageId = @LanguageId
END