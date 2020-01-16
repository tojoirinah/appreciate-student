CREATE PROCEDURE [dbo].[sp_GenerateStudentExam]
AS  
BEGIN  
    SET NOCOUNT OFF;  

	-- Generate Template
		INSERT INTO dbo.StudentExam(StudentId, IsAbsent, Note, BehaviorId, ExamId, IsClosed, NoteEvaluate, BehaviorEvaluate, DateCreated)
		(
			SELECT DISTINCT
				   s.[Id], -- StudentId
				   0, -- IsAbsent
				   NULL, -- Note
				(select top 1 Id from dbo.Behavior), -- BehaviorId
				e.[Id], -- ExamId
				0, -- IsClosed
				'''', -- NoteEvaluate
				'''', -- BehaviorEvaluate
				GETDATE()-- DateCreated
			
			FROM dbo.Student s
			INNER JOIN dbo.SchoolYear sy ON sy.[Id] = s.[SchoolYearId]
			INNER JOIN dbo.Classroom c ON (c.[Id] = s.[ClassRoomId] AND c.[SchoolYearId] = sy.[Id])
			INNER JOIN dbo.Exam e on (e.SchoolYearId = sy.Id AND e.ClassroomId = c.Id)
			LEFT OUTER JOIN dbo.StudentExam se ON (s.[Id] = se.StudentId)
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

		UPDATE se
		SET se.IsClosed = 0
		FROM  dbo.StudentExam se
		INNER JOIN dbo.Exam e on e.Id = se.ExamId
		INNER JOIN dbo.SchoolYear sy ON sy.Id = e.SchoolYearId
		WHERE sy.IsClosed = 0
END
Go

GRANT EXECUTE ON [dbo].[sp_GenerateStudentExam] TO public
GO
