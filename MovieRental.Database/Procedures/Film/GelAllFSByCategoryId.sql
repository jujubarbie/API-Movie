CREATE PROCEDURE [dbo].[GelAllFSByCategoryId]
	@categoryId int

AS BEGIN
	SELECT F.FilmId, F.Title, F.ReleaseYear FROM FilmCategory FC
	inner JOIN Film F ON FC.FilmId = F.FilmId
	inner JOIN Category C ON FC.CategoryId = C.CategoryId
	WHERE C.CategoryId = @categoryId
END
