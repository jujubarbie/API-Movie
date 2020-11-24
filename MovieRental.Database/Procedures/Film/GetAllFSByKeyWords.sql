CREATE PROCEDURE [dbo].[GetAllFSByKeyWords]

	@KeyWords varchar(255) 

AS
BEGIN
	
	
SELECT F.FilmId, F.Title, F.ReleaseYear, F.[Description], F.Title From Film F 
where F.[Description] Like '%'+@KeyWords+'%'
OR F.Title Like '%'+@KeyWords+'%'


END
