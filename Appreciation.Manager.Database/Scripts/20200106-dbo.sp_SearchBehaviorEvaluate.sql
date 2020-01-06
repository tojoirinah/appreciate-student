CREATE PROCEDURE [dbo].[sp_SearchBehaviorEvaluate]
	@noteCriteriaId BIGINT = 0,
	@behaviorId BIGINT = 0
AS  
BEGIN  
    SET NOCOUNT OFF;  

	DECLARE @sql NVARCHAR(MAX) = ''
	  
	SET @sql = N'
		 SELECT *
	FROM [dbo].[VBehaviorEvaluate]
	WHERE [BehaviorEvaluateId] > 0
	'

	IF @noteCriteriaId > 0
	BEGIN
		SET @sql = @sql + ' AND [NoteCriteriaId] = ' + CONVERT(VARCHAR(5),@noteCriteriaId)
	END

	IF @behaviorId > 0
	BEGIN
		SET @sql = @sql + ' AND [BehaviorId] = ' + CONVERT(VARCHAR(5),@behaviorId)
	END
	
	PRINT @sql

	EXECUTE sp_Executesql @sql
END  