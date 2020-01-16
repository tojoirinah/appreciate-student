create VIEW dbo.VStudent
AS   
SELECT s.[Id],
		s.[Id] as StudentId,
		s.DateCreated,
        u.Name as LastName,
        u.FirstName,
		s.Civility,
		sy.Id as SchoolYearId,
		c.Id as ClassroomId,
		u.[Id] as UserId,
		coalesce(sy.Name,'') as SchoolYear,
		coalesce(c.ClassNumber,'') as Classroom,
		cast(coalesce(sy.IsClosed,1) as bit) as IsClosed,
		CAST(CASE WHEN se.[Id] IS NULL THEN 1 ELSE 0 END AS BIT)[CanDelete]
FROM  dbo.Student s
INNER JOIN dbo.[User] u ON s.[UserId] = u.[Id]
LEFT OUTER JOIN dbo.[SchoolYear] sy ON sy.[Id] = s.[SchoolYearId]
LEFT OUTER JOIN dbo.[Classroom] c ON c.[Id] = s.[ClassroomId]
LEFT OUTER JOIN dbo.[StudentExam] se ON se.[StudentId] = s.[Id]
WHERE u.[RoleId] = 2 
GO