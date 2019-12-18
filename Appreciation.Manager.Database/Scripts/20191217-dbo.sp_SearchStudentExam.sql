CREATE PROCEDURE [dbo].[sp_SearchStudentExam]
	@schoolYearId BIGINT,
	@classroomId BIGINT,
	@examId BIGINT
AS  
BEGIN  
    SET NOCOUNT OFF;  

	DECLARE @sql NVARCHAR(MAX) = ''
	  
	SET @sql = N'
		SELECT se.[Id]
		  ,[StudentId]
		  ,[IsAbsent]
		  ,[Note]
		  ,[BehaviorId]
		  ,[ExamId]
		  ,se.[IsClosed]
		  ,[NoteEvaluate]
		  ,[BehaviorEvaluate]
		  ,se.[DateCreated]
	  FROM [dbo].[StudentExam] se
	  LEFT OUTER JOIN [dbo].[Student] st ON st.Id = se.StudentId
	  LEFT OUTER JOIN [dbo].[SchoolYear] sy ON (sy.Id = st.SchoolYearId)
	  WHERE se.[IsClosed] = 0
	'

	IF @schoolYearId > 0
	BEGIN
		SET @sql = @sql + ' AND sy.[Id] = ' + CONVERT(VARCHAR(5),@schoolYearId)
	END

	IF @classroomId > 0
	BEGIN	
		SET @sql = @sql + ' AND st.[ClassRoomId] = ' + CONVERT(VARCHAR(5),@classroomId)
	END

	IF @examId > 0
	BEGIN
		SET @sql = @sql + ' AND se.[ExamId] = ' + CONVERT(VARCHAR(5),@examId)
	END

	PRINT @sql

	EXECUTE sp_Executesql @sql
END  