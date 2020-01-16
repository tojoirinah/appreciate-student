ALTER PROCEDURE [dbo].[sp_GenerateComment]
	@examId BIGINT
AS  
BEGIN  
    SET NOCOUNT OFF;  
  
   

	BEGIN TRANSACTION transStudentExam
    BEGIN TRY
		--select * from dbo.BehaviorEvaluate where NoteCriteriaId in (2, 7)

		IF OBJECT_ID('tempdb..#tStudentExam') IS NOT NULL
			DROP TABLE #tStudentExam

		CREATE TABLE #tStudentExam
		(
			Id BIGINT NOT NULL,
			NoteEvaluate VARCHAR(MAX) NULL,
			BehaviorEvaluate VARCHAR(MAX) NULL,
			DateCreated DATETIME NOT NULL
		)

		IF OBJECT_ID('tempdb..#t1') IS NOT NULL
			DROP TABLE #t1

		SELECT se.*
		INTO #t1
		FROM [dbo].[StudentExam] se
		INNER JOIN [dbo].[Student] st ON st.[Id] = se.[StudentId]
		INNER JOIN [dbo].[SchoolYear] sy ON sy.[Id] = st.[SchoolYearId]
		WHERE se.[IsClosed] = 0 AND sy.[IsClosed] = 0 AND se.[IsAbsent] = 0
		AND se.[ExamId] = @examId
		AND (se.NoteEvaluate is null OR 
			se.NoteEvaluate = '' OR 
			se.BehaviorEvaluate is null OR 
			se.BehaviorEvaluate = '')

		declare @seid BIGINT = 0
		SELECT top 1 @seid = Id from #t1

		while @@ROWCOUNT > 0
		begin

			declare @id bigint = 0, @note decimal(5,2) = 0, @behaviorid bigint = 0, @studentid bigint = 0
			select @id = Id,  @note = [Note], @behaviorid = BehaviorId, @studentid = StudentId FROM #t1 WHERE [Id] = @seid

			declare @noteevaluate varchar(max) = '', @advice varchar(max) = '', @behaviorevaluate varchar(max) = ''
			declare @notecriterid bigint = 0

			SELECT TOP 1 @notecriterid = Id from dbo.NoteCriteria nc where (nc.Min <= @note and @note <= nc.Max)  order by newid()

			select top 1 @noteevaluate = Evaluation, @advice = Advice 
			from dbo.NoteEvaluate where NoteCriteriaId = @notecriterid order by newid()

			select top 1 @behaviorevaluate = Evaluation from dbo.BehaviorEvaluate where BehaviorId = @behaviorid
			and NoteCriteriaId = @notecriterid order by newid()

			INSERT INTO #tStudentExam (	Id,NoteEvaluate , BehaviorEvaluate , DateCreated) values
			(@id, dbo.fnGetNoteEvaluate(@studentid,@noteevaluate + ' '+ @advice), dbo.fnGetNoteEvaluate(@studentid,@behaviorevaluate), getdate())
			delete from #t1 where Id = @seid
			SELECT top 1 @seid = Id from #t1
		end

		IF EXISTS(SELECT 1 FROM #tStudentExam)
		BEGIN
			UPDATE se
			SET se.NoteEvaluate = tmp.NoteEvaluate,
			se.BehaviorEvaluate = tmp.BehaviorEvaluate,
			se.DateCreated = tmp.DateCreated
			FROM [dbo].[StudentExam] se 
			INNER JOIN #tStudentExam tmp ON tmp.[Id] = se.[Id]

		--	select * from #tStudentExam

		END

		COMMIT TRANSACTION transStudentExam
	END TRY
	BEGIN CATCH 
        SELECT
            ERROR_NUMBER() AS ErrorNumber,
            ERROR_SEVERITY() AS ErrorSeverity,
            ERROR_STATE() AS ErrorState,
            ERROR_PROCEDURE() AS ErrorProcedure,
            ERROR_LINE() AS ErrorLine,
            ERROR_MESSAGE() AS ErrorMessage

            ROLLBACK TRANSACTION transStudentExam

    END CATCH

END
GO


