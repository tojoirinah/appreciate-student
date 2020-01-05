CREATE VIEW dbo.VNoteEvaluate
AS   
SELECT ne.[Id]
		,ne.[Id] as [NoteEvaluateId]
		,ne.[DateCreated]
      ,[NoteCriteriaId]
      ,[Evaluation]
      ,[Advice]
	  , Description
	  , nc.[Min] as [NoteMin]
	  , nc.[Max] as [NoteMax]
  FROM [dbo].[NoteEvaluate] ne
  INNER JOIN [dbo].[NoteCriteria] nc ON nc.Id = ne.NoteCriteriaId
GO