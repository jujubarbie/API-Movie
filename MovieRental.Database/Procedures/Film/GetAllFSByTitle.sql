CREATE PROCEDURE [dbo].[GetAllFSByTitle]
	@Title NVARCHAR(255)
AS
BEGIN
	SELECT FilmId, Title, ReleaseYear
	FROM Film 
	WHERE Title like '%'+@Title+'%'
END
