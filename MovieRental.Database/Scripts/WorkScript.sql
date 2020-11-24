select ActorId, concat(left(FirstName,1),left(LastName,1)) as [initialActor],
		FirstName, LastName
from Actor
select ActorId, [dbo].[DatabaseScalarInitialActor](FirstName, LastName) as [initialActor],
		FirstName, LastName
from Actor

select dbo.DatabaseScalarInitialActor(FirstName,LastName) from Actor


exec[dbo].[DatabaseScalarInitialActor('ttt','tttt')]


select A.FirstName, A.LastName from Film F
inner join FilmActor FA on (F.FilmId = FA.FilmId)
inner join Actor A on (FA.ActorId = A.ActorId)
where F.FilmId = 44


select ActorId, FirstName, LastName
from Actor
where 'DT' = concat(left(FirstName,1),left(LastName,1))


select * from Category


SELECT ActorId, FirstName, LastName
FROM Actor 
WHERE SUBSTRING(FirstName, 1, 1) = 'A' AND SUBSTRING(LastName, 1, 1) = 'B'

	SELECT ActorId, FirstName, LastName
	FROM Actor 
	WHERE	left(FirstName, 1) = left('MM' , 1)
	AND		left(LastName, 1) = right('MM', 1)


SELECT SUBSTRING(FirstName, 1, 1) as FirstName, SUBSTRING(LastName, 1, 1) as LastName 
FROM Actor 
WHERE FirstName = 'DAN' AND LastName = 'TORN'


SELECT 
	ActorId, 
	left(FirstName, 1) as InitialFirstName, 
	left(LastName, 1) as InitialLastName
/*	concat(left(FirstName, 1), left(LastName, 1)) as Initials*/
FROM Actor A
WHERE FirstName = 'DAN' AND LastName = 'TORN'


SELECT ActorId as Id, CONCAT(FirstName, ' ', LastName) as [Name] FROM Actor


SELECT CategoryId as Id, * FROM Category


SELECT FilmId as Id, * FROM Film


SELECT * FROM Film WHERE FilmId = 1


SELECT * FROM Film WHERE Title like 'ACADEMY DINOSAUR'


SELECT * FROM FilmActor 
inner JOIN Film on FilmActor.FilmId = Film.FilmId
inner JOIN Actor on FilmActor.ActorId = Actor.ActorId
WHERE FirstName = 'DAN' AND LastName = 'TORN'


SELECT F.FilmId, F.Title, F.ReleaseYear FROM FilmCategory FC
inner JOIN Film F ON FC.FilmId = F.FilmId
inner JOIN Category C ON FC.CategoryId = C.CategoryId
WHERE C.CategoryId = 1

INSERT INTO Rental (CustomerId) OUTPUT inserted.RentalId VAlUES (@CustomerId)
INSERT INTO RentalDetail (FilmId, RentalPrice) OUTPUT inserted.RentalId VALUES (@FilmId, @RentalPrice)

SELECT RentalId as Id, * FROM Rental
SELECT RentalId as Id, * FROm RentalDetail


SELECT [FilmId]
      ,[Title]
      ,[Description]
      ,[ReleaseYear]
      ,[F].[LanguageId]
	  ,[L].[Name]
      ,[RentalDuration]
      ,[RentalPrice]
      ,[Length]
      ,[ReplacementCost]
	  ,[F].[RatingId]
      ,[Rating]

  FROM [Film] AS [F]
  JOIN [Rating] AS [R] ON [F].[RatingId] = [R].[RatingId]
  JOIN [Language] AS [L] ON [F].[LanguageId] = [L].[LanguageId]


exec [dbo].[GetAllActorByInitials('DT')]

select count(*) from Film WHERE LanguageId=2 


SELECT F.FilmId, F.Title, F.ReleaseYear FROM FilmCategory FC
inner JOIN Film F ON FC.FilmId = F.FilmId
inner JOIN Category C ON FC.CategoryId = C.CategoryId
WHERE C.CategoryId = 1


set varchar Titlee
set @Titlee = 'DIVINE'
	SELECT Title, [Description], ReleaseYear, RentalPrice, [Length] 
	FROM Film 
	WHERE Title like '%'+'DIVINE'+'%'

exec [dbo].[GetAllFSByTitle('DIVINE')]


	SELECT FilmId, Title, [Description], ReleaseYear, RentalPrice, [Length] 
	FROM Film 
	WHERE LanguageId = 1


	select * from Rental
	select * from RentalDetail


		SELECT * from V_Film where FilmId = 4




	SELECT distinct 
		left(FirstName, 1) as InitialFirstName
	FROM Actor A



	select * from actor
	where left(FirstName,1) ='M'

	select * from film
	select * from Language
	select * from V_Film
SELECT [FilmId]
      ,[Title]
      ,[Description]
      ,[ReleaseYear]
      ,[F].[LanguageId]
	  ,[L].[Name]
      ,[RentalDuration]
      ,[RentalPrice]
      ,[Length]
      ,[ReplacementCost]
	  ,[F].[RatingId]
      ,[Rating]
  FROM [Film] AS [F]
  JOIN [Rating] AS [R] ON [F].[RatingId] = [R].[RatingId]
  JOIN [Language] AS [L] ON [F].[LanguageId] = [L].[LanguageId]



select * from Category

select * from Film F
inner join FilmActor FA on (FA.FilmId = F.FilmId)
inner join FilmCategory FC on (FC.FilmId = F.FilmId)
where ActorId=1 and Fc.CategoryId=10

select A.FirstName, A.LastName from Film F
inner join FilmActor FA on (F.FilmId = FA.FilmId)
inner join Actor A on (FA.ActorId = A.ActorId)
where F.Title = 'ELEPHANT TROJAN'

select distinct A.ActorId, A.FirstName, A.LastName from Film F 
inner join FilmCategory FC on ( F.FilmId = FC.FilmId )
inner join Category C on (FC.CategoryId = C.CategoryId)
inner join FilmActor FA on (FA.FilmId = F.FilmId)
inner join Actor A on (A.ActorId = FA.ActorId)
where C.Name = 'Horror'
order by (A.FirstName)





select *  from Film where Title like '%story' or Description like '%story%'




select * from V_Film where FilmId = 44
select * from film where FilmId = 44
select * from Language

select * from [Film] F
inner join [Language] L on (F.LanguageId = L.LanguageId)
inner join [Rating] R on(F.RatingId = R.RatingId)


select * from film where FilmId = 25



select F.FilmId, F.Title, F.ReleaseYear from FilmActor FA
inner join Film F on (F.FilmId = FA.FilmId)
where FA.ActorId = 1






