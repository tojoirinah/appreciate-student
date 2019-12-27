CREATE VIEW dbo.VStudent
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
		cast(coalesce(sy.IsClosed,1) as bit) as IsClosed
FROM  dbo.Student s
INNER JOIN dbo.[User] u ON s.[UserId] = u.[Id]
LEFT OUTER JOIN dbo.[SchoolYear] sy ON sy.[Id] = s.[SchoolYearId]
LEFT OUTER JOIN dbo.[Classroom] c ON c.[Id] = s.[ClassroomId]
WHERE u.[RoleId] = 2 
GO