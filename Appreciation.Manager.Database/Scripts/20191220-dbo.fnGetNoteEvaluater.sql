if(object_id(N'[dbo].[fnGetNoteEvaluate]', N'FN')) is not null
    drop function [dbo].[fnGetNoteEvaluate];
GO

CREATE FUNCTION dbo.fnGetNoteEvaluate (@studentId BIGINT,@noteEvaluate VARCHAR(MAX))
RETURNS VARCHAR(MAX)
AS BEGIN
    DECLARE @Work VARCHAR(MAX) = @noteEvaluate
	DECLARE @userFirstName VARCHAR(100) = '', @pronom VARCHAR(5) = ''
	

	SELECT @userFirstName = FirstName,
		   @pronom = (CASE WHEN s.Civility = 1 THEN 'Il' ELSE 'Elle' END)
		FROM [dbo].[User] u 
		INNER JOIN [dbo].[Student] s ON s.[UserId] = u.[Id]
		WHERE s.[Id] = @studentId

	IF @userFirstName <> ''
	BEGIN
		SET @Work = REPLACE(@Work, '_name_', @userFirstName)
		SET @Work = REPLACE(@Work, '_pronom_', @pronom)
	END
    RETURN @work
END