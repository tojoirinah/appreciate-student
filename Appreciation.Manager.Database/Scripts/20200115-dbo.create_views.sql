CREATE VIEW dbo.view_VNoteCriteria
AS  
SELECT DISTINCT nc.*,
	   CAST(CASE WHEN be.Id IS NULL THEN 1 ELSE 0 END AS BIT) [CanDelete]
  FROM [dbo].[NoteCriteria] nc
  LEFT OUTER JOIN [dbo].[BehaviorEvaluate] be ON be.[NoteCriteriaId] = nc.Id
GO

CREATE VIEW dbo.view_VBehavior
AS 
	SELECT DISTINCT b.*,
			CAST(CASE WHEN be.Id IS NULL THEN 1 ELSE 0 END AS BIT) [CanDelete]
	FROM [dbo].[Behavior] b
	LEFT OUTER JOIN [dbo].[BehaviorEvaluate] be ON be.[BehaviorId] = b.Id
GO

CREATE VIEW dbo.view_VClassroom
AS 
	SELECT DISTINCT c.*, 
		CAST(CASE WHEN s.Id IS NULL AND e.Id IS NULL THEN 1 ELSE 0 END AS BIT) [CanDelete]
	FROM [dbo].[Classroom] c 
	LEFT OUTER JOIN [dbo].[Student] s ON s.ClassRoomId = c.Id
	LEFT OUTER JOIN [dbo].[Exam] e ON e.ClassroomId = c.Id
GO

CREATE VIEW dbo.view_VExam
AS 
	SELECT DISTINCT e.*, 
		CAST(CASE WHEN se.Id IS NULL THEN 1 ELSE 0 END AS BIT) [CanDelete]
	FROM [dbo].[Exam] e 
	LEFT OUTER JOIN [dbo].[StudentExam] se ON se.ExamId = e.Id
GO

CREATE VIEW dbo.view_VSchoolYear
AS
	SELECT DISTINCT sy.*,
		CAST(CASE WHEN s.Id IS NULL 
				  AND e.Id IS NULL 
				  AND c.Id IS NULL 
				  THEN 1
				  ELSE 0
			 END AS BIT) [CanDelete]
	FROM [dbo].[SchoolYear] sy
	LEFT OUTER JOIN [dbo].[Student] s ON s.SchoolYearId = sy.Id
	LEFT OUTER JOIN [dbo].[Exam] e ON e.SchoolYearId = sy.Id
	LEFT OUTER JOIN [dbo].[Classroom] c ON c.SchoolYearId = sy.Id
GO