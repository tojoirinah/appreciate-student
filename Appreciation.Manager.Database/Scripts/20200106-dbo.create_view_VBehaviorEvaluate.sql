CREATE VIEW dbo.VBehaviorEvaluate
AS   
SELECT 
	be.Id,
	be.Id as [BehaviorEvaluateId],
	be.[DateCreated],
	be.[Evaluation],
	be.[BehaviorId],
	be.[NoteCriteriaId],
	b.[Description] as [BehaviorDescription],
	nc.[Description] as [NoteCriteriaDescription],
	nc.[Min] as [NoteMin],
	nc.[Max] as [NoteMax]
FROM dbo.BehaviorEvaluate be
INNER JOIN dbo.Behavior b ON b.Id = be.BehaviorId
INNER JOIN dbo.NoteCriteria nc ON nc.Id = be.NoteCriteriaId
GO