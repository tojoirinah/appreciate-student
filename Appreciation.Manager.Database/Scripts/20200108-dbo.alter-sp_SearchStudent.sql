ALTER PROCEDURE [dbo].[sp_SearchStudent]
	@schoolYearId BIGINT,
	@classroomId BIGINT
AS  
BEGIN  
    SET NOCOUNT OFF;  

	DECLARE @sql NVARCHAR(MAX) = ''
	  
	SET @sql = N'
		SELECT *
	  FROM dbo.VStudent 
	  WHERE [IsClosed] = 0
	'

	IF @schoolYearId > 0
	BEGIN
		SET @sql = @sql + ' AND [SchoolYearId] = ' + CONVERT(VARCHAR(5),@schoolYearId)
	END

	IF @classroomId > 0
	BEGIN	
		SET @sql = @sql + ' AND [ClassRoomId] = ' + CONVERT(VARCHAR(5),@classroomId)
	END


	PRINT @sql

	EXECUTE sp_Executesql @sql
END  