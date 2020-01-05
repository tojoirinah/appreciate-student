CREATE PROCEDURE [dbo].[sp_SearchNoteEvaluate]
	@noteCriteriaId BIGINT = 0
AS  
BEGIN  
    SET NOCOUNT OFF;  

	DECLARE @sql NVARCHAR(MAX) = ''
	  
	SET @sql = N'
		 SELECT *
	FROM [dbo].[VNoteEvaluate]
	WHERE [NoteEvaluateId] > 0
	'

	IF @noteCriteriaId > 0
	BEGIN
		SET @sql = @sql + ' AND [NoteCriteriaId] = ' + CONVERT(VARCHAR(5),@noteCriteriaId)
	END

	
	PRINT @sql

	EXECUTE sp_Executesql @sql
END  