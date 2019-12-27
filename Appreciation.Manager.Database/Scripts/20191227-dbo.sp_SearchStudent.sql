CREATE PROCEDURE [dbo].[sp_SearchStudent]
	@schoolYearId BIGINT,
	@classroomId BIGINT
AS  
BEGIN  
    SET NOCOUNT OFF;  

	DECLARE @sql NVARCHAR(MAX) = ''
	  
	SET @sql = N'
		SELECT st.*,
			   u.*
	  FROM [dbo].[Student] st
	  INNER JOIN [dbo].[User] u ON u.[Id] = st.[UserId]
	  LEFT OUTER JOIN [dbo].[SchoolYear] sy ON st.[SchoolYearId] = sy.[Id]
	  LEFT OUTER JOIN [dbo].[Classroom] c ON c.[Id] = st.[ClassRoomId]
	  WHERE u.[RoleId] = 2
	'

	IF @schoolYearId > 0
	BEGIN
		SET @sql = @sql + ' AND sy.[Id] = ' + CONVERT(VARCHAR(5),@schoolYearId)
	END

	IF @classroomId > 0
	BEGIN	
		SET @sql = @sql + ' AND st.[ClassRoomId] = ' + CONVERT(VARCHAR(5),@classroomId)
	END


	PRINT @sql

	EXECUTE sp_Executesql @sql
END  