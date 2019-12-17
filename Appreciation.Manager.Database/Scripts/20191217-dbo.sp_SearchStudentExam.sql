CREATE PROCEDURE [dbo].[dbo.sp_SearchStudentExam]
	@schoolYearId BIGINT,
	@classroomId BIGINT,
	@examId BIGINT
AS  
BEGIN  
    SET NOCOUNT OFF;  

	DECLARE @sql VARCHAR(MAX) = ''
  
	SET @sql = N'
		SELECT se.[Id]
		  ,[StudentId]
		  ,[IsAbsent]
		  ,[Note]
		  ,[BehaviorId]
		  ,[ExamId]
		  ,[IsClosed]
		  ,[NoteEvaluate]
		  ,[BehaviorEvaluate]
		  ,[DateCreated]
	  FROM [dbo].[StudentExam] se
	  LEFT OUTER JOIN [dbo].[Student] st ON st.Id = se.StudentId
	  LEFT OUTER JOIN [dbo].[SchoolYear] sy ON (sy.Id = st.SchoolYearId)
	'

	IF @schoolYearId > 0
	BEGIN
		SET @sql = @sql + ' AND sy.[Id] = @paramSchoolYearId'
	END
END  