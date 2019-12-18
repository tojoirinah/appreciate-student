CREATE PROCEDURE [dbo].[sp_GenerateComment]
AS  
BEGIN  
    SET NOCOUNT OFF;  
  
   

	BEGIN TRANSACTION transStudentExam
    BEGIN TRY
		DECLARE @last_school_year_id BIGINT = 0
		SELECT TOP 1 @last_school_year_id = [Id] FROM [dbo].[SchoolYear] WHERE [IsClosed] = 0 ORDER BY [Id] DESC

		CREATE TABLE #tStudentExam
		(
			Id BIGINT NOT NULL,
			NoteEvaluate VARCHAR(MAX) NULL,
			BehaviorEvaluate VARCHAR(MAX) NULL,
			DateCreated DATETIME NOT NULL
		)
        
		IF @last_school_year_id <> 0
		BEGIN
			INSERT INTO #tStudentExam(Id,NoteEvaluate,BehaviorEvaluate,DateCreated)
			(
				SELECT DISTINCT
					se.Id,
					ne.Evaluation + ' .'+ ne.Advice,
					be.Evaluation,
					GETDATE()
				FROM [dbo].[Student] st
				INNER JOIN [dbo].[StudentExam] se ON se.[StudentId] = st.[Id]
				INNER JOIN [dbo].[NoteCriteria] nc ON (nc.[Min] <= se.Note AND se.Note <= nc.Max)
				INNER JOIN [dbo].[NoteEvaluate] ne ON ne.NoteCriteriaId = nc.Id
				INNER JOIN [dbo].[BehaviorEvaluate] be ON (be.[BehaviorId] = se.[BehaviorId] AND be.NoteCriteriaId = ne.NoteCriteriaId)
				WHERE st.[SchoolYearId] = @last_school_year_id
				AND se.[IsClosed] = 0
			)

			IF EXISTS(SELECT 1 FROM #tStudentExam)
			BEGIN
				UPDATE se
				SET se.NoteEvaluate = tmp.NoteEvaluate,
				se.BehaviorEvaluate = tmp.BehaviorEvaluate,
				se.DateCreated = tmp.DateCreated
				FROM [dbo].[StudentExam] se 
				INNER JOIN #tStudentExam tmp ON tmp.[Id] = se.[Id]

			END
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