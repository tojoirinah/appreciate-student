CREATE VIEW [dbo].[view_VStudentChart]
AS  
	select distinct
		ISNULL(se.Note,0) [Note],
		e.Name [Exam],
	    e.Id [ExamId],
		se.[StudentId],
	    se.[Id],
		se.[DateCreated]
	from dbo.StudentExam se
	LEFT JOIN dbo.Exam e on e.Id = se.ExamId
GO