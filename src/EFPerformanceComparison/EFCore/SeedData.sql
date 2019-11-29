DELETE FROM [Copy] WHERE 1=1
DELETE FROM Books WHERE 1=1
DELETE FROM Authors WHERE 1=1

GO

SET NOCOUNT ON

INSERT INTO [dbo].[Authors] ([FullName])
VALUES (CONVERT(varchar(255), NEWID()))

GO 1000

SELECT
	MIN(AuthorId) AS [Lower],
	MAX(AuthorId) AS [Upper]
INTO #TempAuthorId
FROM Authors

GO

DECLARE @MinAuthors AS INT
DECLARE @MaxAuthors AS INT

SELECT
	 @MinAuthors = [Lower],
	 @MaxAuthors = [Upper]
FROM #TempAuthorId

INSERT INTO [dbo].[Books] ([Name],[AuthorId])
VALUES (CONVERT(varchar(255), NEWID()),ROUND(((@MaxAuthors - @MinAuthors -1) * RAND() + @MinAuthors), 0))

GO 10000

SELECT
	MIN(BookId) AS [Lower],
	MAX(BookId) AS [Upper]
INTO #TempBookId
FROM Books

GO

DECLARE @MinBooks AS INT
DECLARE @MaxBooks AS INT

SELECT
	 @MinBooks = [Lower],
	 @MaxBooks = [Upper]
FROM #TempBookId

INSERT INTO [Copy] (BookId,Price)
VALUES (ROUND(((@MaxBooks - @MinBooks -1) * RAND() + @MinBooks), 0),ROUND(((100 - 10 -1) * RAND() + 10), 0))

GO 1000000

DROP TABLE #TempAuthorId
DROP TABLE #TempBookId