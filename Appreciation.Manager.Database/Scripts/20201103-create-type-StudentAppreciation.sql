CREATE TYPE dbo.StudentAppreciation AS TABLE
(
    Genre NVARCHAR(10), 
    LastName NVARCHAR(100),
    FirstName NVARCHAR(100),
    SchoolYear NVARCHAR(10),
    ClassNumber NVARCHAR(20)
);
GO

GRANT EXEC ON [dbo].[StudentAppreciation] TO PUBLIC
GO

CREATE PROCEDURE [dbo].[sp_ImportDatas]
    @student dbo.StudentAppreciation READONLY
AS  
BEGIN  
    SET NOCOUNT OFF;  

	BEGIN TRANSACTION imports
    BEGIN TRY

		DECLARE @imported INT = 0;

		IF OBJECT_ID('tempdb..#tmp_Student_Appreciation') IS NOT NULL
			DROP TABLE #tmp_Student_Appreciation

		CREATE TABLE #tmp_Student_Appreciation (
			[Id] BIGINT IDENTITY(1, 1) primary key,
			[Genre] NVARCHAR(10), 
			[LastName] NVARCHAR(100),
			[FirstName] NVARCHAR(100),
			[SchoolYear] NVARCHAR(10),
			[ClassNumber] NVARCHAR(20)
		)

		IF OBJECT_ID('tempdb..#tmp_Student_Appreciation_Single') IS NOT NULL
			DROP TABLE #tmp_Student_Appreciation_Single

		CREATE TABLE #tmp_Student_Appreciation_Single (
			[Id] BIGINT,
			[Genre] NVARCHAR(10), 
			[LastName] NVARCHAR(100),
			[FirstName] NVARCHAR(100),
			[SchoolYear] NVARCHAR(10),
			[ClassNumber] NVARCHAR(20)
		)

		INSERT INTO #tmp_Student_Appreciation([Genre],[LastName],[FirstName],[SchoolYear],[ClassNumber])
		(
			SELECT [Genre],[LastName],[FirstName],[SchoolYear],[ClassNumber] FROM @student
		)


		DECLARE @rowCount INT = 0 
		 INSERT INTO #tmp_Student_Appreciation_Single([Id], [Genre],[LastName],[FirstName],[SchoolYear],[ClassNumber])
		(
			SELECT TOP 1 [Id], [Genre],[LastName],[FirstName],[SchoolYear],[ClassNumber] FROM #tmp_Student_Appreciation
		)
		SET @rowCount = @@ROWCOUNT

		WHILE @rowCount > 0
		BEGIN
		
			DECLARE @schoolyear NVARCHAR(10) = '', @classnumber NVARCHAR(20) = '', @lastName NVARCHAR(100) = '', @firstName NVARCHAR(100) = '', @genre NVARCHAR(10) = ''

			SELECT @schoolyear = t.[SchoolYear], @classnumber = t.[ClassNumber], @lastName = t.[LastName],
			@firstName = t.[FirstName], @genre = t.Genre
			FROM #tmp_Student_Appreciation_Single t

			-- #------------------------ SCHOOL YEAR ----------------------- # --
			DECLARE @schoolyearId BIGINT = 0
			SELECT @schoolyearId = [Id] FROM [dbo].[SchoolYear] WHERE [Name] = @schoolyear
			IF @schoolyearId = 0
			BEGIN
				INSERT INTO [dbo].[SchoolYear] ([Name],[IsClosed],[DateCreated])
				VALUES (@schoolyear, 1, GETDATE())

				set @schoolyearId = SCOPE_IDENTITY()
			END
			-- #------------------------ SCHOOL YEAR ----------------------- # --

			-- #------------------------ CLASSROOM ----------------------- # --
			DECLARE @classroomId BIGINT = 0
			SELECT @classroomId = [Id] FROM [dbo].[Classroom] WHERE [ClassNumber] = @classnumber AND [SchoolYearId] = @schoolyearId

			IF @classroomId = 0
			BEGIN
				INSERT INTO [dbo].[Classroom] ([ClassNumber],[DateCreated],[SchoolYearId]) VALUES
				(@classnumber, GETDATE(), @schoolyearId)

				set @classroomId = SCOPE_IDENTITY()
			END
			-- #------------------------ CLASSROOM ----------------------- # --

			-- #------------------------ USER--------------------- # --
			DECLARE @userId BIGINT = 0
			SELECT @userId = u.[Id] FROM [dbo].[User] u
			INNER JOIN [dbo].[Student] st ON st.[UserId] = u.Id
			INNER JOIN [dbo].[SchoolYear] sy ON sy.Id = st.[SchoolYearId]
			INNER JOIN [dbo].[Classroom] c ON c.Id = st.[ClassRoomId]
			WHERE u.[Name] = @lastName AND [FirstName] = @firstName
			AND sy.[Id] = @schoolyearId AND c.[Id] = @classroomId
			IF @userId = 0
			BEGIN 
				DECLARE @securitySalt NVARCHAR(MAX) = 'O0k0mRM6|G5ZAe9M0wj8X|RAhV72nnUW99JrQTK6fHBAHPJdTSzUPu4PYSPxbdNHF9mHDlr2cyMysryWL0HZSa|GKczx5es4BYYZHDc8ib6swhe4HZyLF0tufXbFJStxp2K8ywqSJ29yUnPD53pdKGW|GOLF5APPLEegg9MUSIC0walmartjack8XBOX|RAhV72nnUW99JrQTK6fHBAHPJdTSzUPu4PYSPxbdNHF9mHDlr2cyMysryWL0HZSa|GKczx5es4BYYZHDc8ib6swhe4HZyLF0tufXbFJStxp2K8ywqSJ29yUnPD53pdKGW'
				DECLARE @password NVARCHAR(MAX) = 'f3e5f63482162977fb46b327960a7cbd0d1e966c46550a87821a32785df5c84a'

				INSERT INTO [dbo].[User] ([Name],[FirstName],[UserName],[SecuritySalt],[Password],[RoleId],[DateCreated])
				VALUES
				(@lastName, @firstName, '', @securitySalt, @password, 2,GETDATE())

				set @userId = SCOPE_IDENTITY()
			END
			-- #------------------------ USER ----------------------- # --

			-- #------------------------ STUDENT ----------------------- # --
			DECLARE @studentId BIGINT  = 0
			SELECT @studentId = [Id] FROM [dbo].[Student]
			WHERE [UserId] = @userId AND [SchoolYearId] = @schoolyearId
			AND [ClassRoomId] = @classroomId
			IF @studentId = 0
			BEGIN
				INSERT INTO [dbo].[Student] ([SchoolYearId],[ClassRoomId],[Age],[Civility],[UserId],[DateCreated])
				VALUES
				(@schoolyearId, @classroomId, 0, CASE WHEN lower(@genre) = 'male' THEN 1 ELSE 2 END, @userId, GETDATE())

				SET @imported = @imported + 1
			END
			-- #------------------------ STUDENT ----------------------- # --


			DELETE t1 FROM #tmp_Student_Appreciation t1
			INNER JOIN #tmp_Student_Appreciation_Single t2 ON t1.Id = t2.Id

			TRUNCATE TABLE #tmp_Student_Appreciation_Single

			INSERT INTO #tmp_Student_Appreciation_Single([Id], [Genre],[LastName],[FirstName],[SchoolYear],[ClassNumber])
			(
				SELECT TOP 1 [Id], [Genre],[LastName],[FirstName],[SchoolYear],[ClassNumber] FROM #tmp_Student_Appreciation
			)

			SET @rowCount = @@ROWCOUNT
		END

		DROP TABLE #tmp_Student_Appreciation_Single
		DROP TABLE #tmp_Student_Appreciation

		COMMIT TRANSACTION imports
		PRINT CONVERT(varchar(5), @imported) + ' students imported'
		
	END TRY
	BEGIN CATCH 
        SELECT
            ERROR_NUMBER() AS ErrorNumber,
            ERROR_SEVERITY() AS ErrorSeverity,
            ERROR_STATE() AS ErrorState,
            ERROR_PROCEDURE() AS ErrorProcedure,
            ERROR_LINE() AS ErrorLine,
            ERROR_MESSAGE() AS ErrorMessage

            ROLLBACK TRANSACTION imports

    END CATCH
END
go

GRANT EXEC ON [dbo].[sp_ImportDatas] TO PUBLIC