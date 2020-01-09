CREATE PROCEDURE [dbo].[sp_GetDashboardExam]
	@examIdParam BIGINT = 0
AS  
BEGIN  
    SET NOCOUNT OFF;  

	DECLARE @sql NVARCHAR(MAX) = ''

	SET @sql = N'
	IF OBJECT_ID(''tempdb..#tDashboardExam'') IS NOT NULL
		DROP TABLE #tDashboardExam

	CREATE TABLE #tDashboardExam(
		[Id] BIGINT IDENTITY(1, 1) primary key,
		[ExamId] BIGINT NOT NULL,
		[TotalStudents] INT,
		[TotalAbsents] INT,
		[TotalWaitingNonReseigne] INT,
		[PercentNoteRenseigne]  DECIMAL(5,2),
		[DateCreated] DATETIME NOT NULL
	)

	IF OBJECT_ID(''tempdb..#tExam'') IS NOT NULL
		DROP TABLE #tExam

	CREATE TABLE #tExam(Id BIGINT)
	'
	
	IF @examIdParam = 0
	BEGIN
		SET @sql = @sql + N'
		INSERT INTO #tExam(Id)
		(
			SELECT [Id] FROM dbo.[Exam]
		)
		
		'
	END
	ELSE
	BEGIN
		SET @sql = @sql + N'INSERT INTO #tExam(Id) VALUES (' + CONVERT(VARCHAR(5),@examIdParam) + N')'
	END

	SET @sql = @sql + N'
	DECLARE @TotalStudents INT = 0, @TotalAbsents INT = 0, @TotalWaitingNonReseigne INT = 0, @PercentNoteRenseigne INT = 0

	declare @examId BIGINT = (SELECT TOP 1 [Id] FROM #tExam)

	WHILE @examId  > 0
	BEGIN
	
		-- Generate Template
		INSERT INTO dbo.StudentExam(StudentId, IsAbsent, Note, BehaviorId, ExamId, IsClosed, NoteEvaluate, BehaviorEvaluate, DateCreated)
		(
			SELECT DISTINCT
				   s.[Id], -- StudentId
				   0, -- IsAbsent
				   NULL, -- Note
				(select top 1 Id from dbo.Behavior), -- BehaviorId
				@examId, -- ExamId
				0, -- IsClosed
				'''', -- NoteEvaluate
				'''', -- BehaviorEvaluate
				GETDATE()-- DateCreated
			
			FROM dbo.Student s
			INNER JOIN dbo.SchoolYear sy ON sy.[Id] = s.[SchoolYearId]
			INNER JOIN dbo.Exam e on e.SchoolYearId = sy.Id
			LEFT OUTER JOIN dbo.StudentExam se ON (s.[Id] = se.StudentId and se.ExamId = @examId)
			WHERE sy.[IsClosed] = 0
			AND se.[Id] IS NULL
		)

		-- Updating Template
		UPDATE se
		SET se.IsClosed = 1
		FROM  dbo.StudentExam se
		INNER JOIN dbo.Exam e on e.Id = se.ExamId
		INNER JOIN dbo.SchoolYear sy ON sy.Id = e.SchoolYearId
		WHERE sy.IsClosed = 1

		IF OBJECT_ID(''tempdb..#tStudentExam'') IS NOT NULL
			drop table #tStudentExam

		SELECT s.[Id], s.[IsAbsent], s.[Note], s.[ExamId]
			INTO #tStudentExam
			FROM dbo.StudentExam s
			INNER JOIN dbo.Exam e on e.Id = s.ExamId
			inner join dbo.SchoolYear sy on sy.Id = e.SchoolYearId
			where sy.IsClosed = 0
			AND s.IsClosed = 0

	
		SELECT @TotalStudents = count(*) FROM #tStudentExam where ExamId = @examId
		SELECT @TotalAbsents = count(*) FROM #tStudentExam WHERE ExamId = @examId AND IsAbsent = 1

		DECLARE @totalStudentsPresent INT = 0, @renseigne INT = 0

		SELECT @totalStudentsPresent = count(*) FROM #tStudentExam WHERE ExamId = @examId AND IsAbsent = 0
		SELECT @renseigne =  count(*) FROM #tStudentExam WHERE ExamId = @examId AND IsAbsent = 0  AND [Note] is not null
		SELECT @TotalWaitingNonReseigne =  count(*) FROM #tStudentExam WHERE ExamId = @examId AND IsAbsent = 0  AND [Note] is null

		SELECT @PercentNoteRenseigne = ROUND(@renseigne*100/@totalStudentsPresent,2) 

		INSERT INTO #tDashboardExam([ExamId] ,[TotalStudents] ,[TotalAbsents] ,[TotalWaitingNonReseigne] ,[PercentNoteRenseigne], [DateCreated]) VALUES
		(@examId, @TotalStudents, @TotalAbsents, @TotalWaitingNonReseigne, @PercentNoteRenseigne, GETDATE())

		SET @TotalStudents = 0
		SET @TotalAbsents = 0
		SET @TotalWaitingNonReseigne = 0
		SET @PercentNoteRenseigne = 0
		DELETE #tExam WHERE [Id] = @examId
		SET @examId = (SELECT TOP 1 [Id] FROM #tExam)
	END

	SELECT distinct
			t.*,
		   sy.[Id] [SchoolYearId],
		   sy.[Name] [SchoolYearName],
		   c.[Id] [ClassroomId],
		   c.[ClassNumber],
		   e.[Name] [ExamName]
	FROM #tDashboardExam t
	INNER JOIN dbo.[Exam] e ON e.Id = t.[ExamId]
	INNER JOIN dbo.[StudentExam] se on se.[ExamId] = e.[Id]
	INNER JOIN dbo.[Student] s on s.[Id] = se.[StudentId]
	INNER JOIN dbo.[Classroom] c on s.[ClassroomId] = c.[Id]
	INNER JOIN dbo.[SchoolYear] sy ON sy.Id = e.[SchoolYearId]
	'

	IF @examIdParam > 0
	BEGIN
		SET @sql = @sql + N'
		WHERE e.Id = ' + + CONVERT(VARCHAR(5),@examIdParam)
	END

	EXECUTE sp_Executesql @sql
END  
Go

GRANT EXECUTE ON [dbo].[sp_GetDashboardExam] TO public
GO