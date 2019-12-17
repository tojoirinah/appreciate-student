BEGIN TRY
        BEGIN TRANSACTION;
			--CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool]
			--GO
			--EXEC sp_addrolemember 'db_datareader', 'IIS APPPOOL\DefaultAppPool'
			--GO
			--EXEC sp_addrolemember 'db_datawriter', 'IIS APPPOOL\DefaultAppPool'
			--GO

			SET IDENTITY_INSERT [dbo].[Role] ON
			INSERT INTO [dbo].[Role]
					   ([Id],[RoleName],[DateCreated])
				 VALUES
					   (1,'Admin',Getdate()),
					   (2,'Student',Getdate())
			SET IDENTITY_INSERT [dbo].[Role] OFF
			

			SET IDENTITY_INSERT [dbo].[User] ON
			INSERT INTO [dbo].[User]
					   ([Id]
					   ,[Name]
					   ,[FirstName]
					   ,[UserName]
					   ,[Security_salt]
					   ,[Password]
					   ,[RoleId]
					   ,[DateCreated])
				 VALUES
					   (1
					   ,'Administrator'
					   ,''
					   ,'admin'
					   ,'bMjKQVV8|G5ZAe9M0wj8X|LIXFZps0CBbfDRhTY32GYPB7PxTnMbHhkX4mumNrlmH9yoaBmBERG4S2hYUC1fnb|zY0KUZ8MNJ0miBfBxsbl3UAMfbf0wlVg8GF8tumrcxD3cgtfTtkIDcEeynFtUevC|--GOLF5APPLEegg9MUSIC0walmartjack8XBOX|c5UjOhAYYi3Z12TKxYNsnwp2zuRbw3xPnBv9ejH80jlWLgpE2mYjCfFlnYpzu9C4|qmmYgTgNQOWeKxptfnEkdNMH2JRKzNk1GNg9Yv7hFKxtNBaUJ1ThZXzC8e52c1Td'
					   ,'51402fc81279c47ad6c14f335e1348847ec601ad31d2bcb61c0ce2dfa5313f53'
					   ,1
					   ,getdate())
			SET IDENTITY_INSERT [dbo].[User] OFF
			--GO


			-- Exam
			SET IDENTITY_INSERT [dbo].[Exam] ON
			INSERT INTO [dbo].[Exam] ([Id],[Name],[DateCreated]) VALUES
			(1,'Contrôle continue Octobre',GETDATE()),
			(2,'Contrôle continue Décembre',GETDATE())
			SET IDENTITY_INSERT [dbo].[Exam] OFF
			--GO

			-- Classroom
			SET IDENTITY_INSERT [dbo].[Classroom] ON
			INSERT INTO [dbo].[Classroom] ([Id],[ClassNumber],[DateCreated]) VALUES
			(1,'4 ème 1',GETDATE()),
			(2,'4 ème 2',GETDATE()),
			(3,'4 ème 3',GETDATE())
			SET IDENTITY_INSERT [dbo].[Classroom] OFF
			--GO

			-- SchoolYear
			SET IDENTITY_INSERT [dbo].[SchoolYear] ON
			INSERT INTO [dbo].[SchoolYear] ([Id],[Name],[DateCreated],[IsClosed]) VALUES
			(1, '2019-2020',getdate(),0)
			SET IDENTITY_INSERT [dbo].[SchoolYear] OFF
			--GO

			-- Behavior
			SET IDENTITY_INSERT [dbo].[Behavior] ON
			INSERT INTO [dbo].[Behavior] ([Id],[Value] ,[Description] ,[DateCreated]) VALUES
			(1,0,'Mauvais comportement',getdate()),
			(2,10,'Comportement correct',getdate()),
			(3,20,'Bon comportement',getdate())
			SET IDENTITY_INSERT [dbo].[Behavior] OFF
			--GO

			-- Note criteria
			SET IDENTITY_INSERT [dbo].[NoteCriteria] ON
			INSERT INTO [dbo].[NoteCriteria] ([Id], [Min],[Max],[DateCreated] ,[Description]) VALUES
			(1,0,0,GETDATE(),'Absent'),
			(2,0,9,GETDATE(),'Insuffisant'),
			(3,9,12,GETDATE(),'Correct'),
			(4,12,15,GETDATE(),'Assez bien'),
			(5,15,20,GETDATE(),'Très bien')
			SET IDENTITY_INSERT [dbo].[NoteCriteria] OFF
			--GO

			-- Behavior evaluate
			SET IDENTITY_INSERT [dbo].[BehaviorEvaluate] ON
			INSERT INTO [dbo].[BehaviorEvaluate] ([Id], [BehaviorId],[NoteCriteriaId],[Evaluation],[DateCreated]) VALUES
			-- Mauvais comportement, absent
			(1,1,1,'Mauvais comportement, absent',GETDATE()),
			-- Mauvais comportement, note insuffisant
			(2,1,2,'Mauvais comportement, note insuffisant',GETDATE()),
			-- Mauvais comportement, Correct
			(3,1,3,'Mauvais comportement, Correct',GETDATE()),
			-- Mauvais comportement, Assez bien
			(4,1,4,'Mauvais comportement, Assez bien',GETDATE()),
			-- Mauvais comportement, Très bien
			(5,1,5,'Mauvais comportement, Très bien',GETDATE()),

			-- Comportement correct, absent
			(6,2,1,'Comportement correct, absent',GETDATE()),
			-- Comportement correct, note insuffisant
			(7,2,2,'Comportement correct, note insuffisant',GETDATE()),
			-- Comportement correct, Correct
			(8,2,3,'Comportement correct, Correct',GETDATE()),
			-- Comportement correct, Assez bien
			(9,2,4,'Comportement correct, Assez bien',GETDATE()),
			-- Comportement correct, Très bien
			(10,2,5,'Comportement correct, Très bien',GETDATE())


			SET IDENTITY_INSERT [dbo].[BehaviorEvaluate] OFF
			--GO

			SET IDENTITY_INSERT [dbo].[NoteEvaluate] ON
			INSERT INTO [dbo].[NoteEvaluate] ([Id],[NoteCriteriaId],[Evaluation],[Advice],[DateCreated]) VALUES
			-- Absent
			(1,1,'Evaluation absent 1','Conseil absent 1',getdate()),
			-- Insuffisant
			(2,2,'Evaluation insuffisant 1','Conseil insuffisant 1',getdate()),
			-- Correct
			(3,3,'Evaluation correct 1','Conseil correct 1',getdate()),
			-- Assez bien
			(4,4,'Evaluation assez bien 1','Conseil assez bien 1',getdate()),
			-- Très bien
			(5,5,'Evaluation très bien 1','Conseil très bien 1',getdate()),

			-- Absent
			(6,1,'Evaluation absent 2','Conseil absent 2',getdate()),
			-- Insuffisant
			(7,2,'Evaluation insuffisant 2','Conseil insuffisant 2',getdate()),
			-- Correct
			(8,3,'Evaluation correct 2','Conseil correct 2',getdate()),
			-- Assez bien
			(9,4,'Evaluation assez bien 2','Conseil assez bien 2',getdate()),
			-- Très bien
			(10,5,'Evaluation très bien 2','Conseil très bien 2',getdate())
			SET IDENTITY_INSERT [dbo].[NoteEvaluate] OFF
			--GO
			-- Behavior
			--SET IDENTITY_INSERT [dbo].[Behavior] ON
			--INSERT INTO [dbo].[Behavior]
			--           ([Id]
			--		   ,[Value]
			--           ,[Description]
			--           ,[DateCreated])
			--     VALUES
			--           (1,0,'Votre comportement est inadmissible',getdate()),
			--		   (2,5,'L''ensemble de vos professeurs s''accordent pour dire que votre attitude en classe ne vous permet pas de progresser',getdate()),
			--		   (3,10,'L''ensemble de vos professeurs souligne un manque d''investissement',getdate()),
			--		   (4,15,'Ce trimestre est correct, mais laisse une impression d''inachevé',getdate()),
			--		   (5,20,'Votre comportement exemplaire',getdate()),
			--		   --
			--		   (6,0,'Votre attitude en classe est pénible',getdate()),
			--		   (7,5,'L''attitude en classe manque de sérieux dans certaines disciplines',getdate()),
			--		   (8,10,'Classe agréable même si de nombreux bavardages et de remarques déplacées ont marqué cette fin de trimestre',getdate()),
			--		   (9,15,'L''attitude en classe manque de constance',getdate()),
			--		   (10,20,'Votre sérieux est souligné par l''ensemble de vos professeur',getdate()),
			--		   --
			--		   (11,0,'Votre attitude pose encore de problème dans de nombreuses matières, malgré quelques efforts en débuts de trimestre',getdate()),
			--		   (12,5,'L''attitude en classe manque de consistance et de sérieux',getdate()),
			--		   (13,10,'Le déficit d''attention de certains élèves ralentit toujours leur progression',getdate()),
			--		   (14,15,'L''attitude en classe est positive et sérieuse',getdate()),
			--		   (15,20,'Vous avez su maintenir une attitude sérieuse',getdate())
			--SET IDENTITY_INSERT [dbo].[Behavior] OFF
			----GO

			-- Note criteria
			--SET IDENTITY_INSERT [dbo].[NoteCriteria] ON
			--INSERT INTO [dbo].[NoteCriteria]
			--           ([Id]
			--		   ,[Min]
			--           ,[Max]
			--           ,[Evaluate]
			--		   ,[Conseils]
			--           ,[DateCreated])
			--     VALUES
			--           (1,0,9,'Trimestre décevant. ','Vous êtes capable d''obtenir de meilleurs résultats',getdate()),
			--		   (2,9,12,'Ensemble trop juste. ','Vous êtes sérieux et motivé. De ce fait, vous êtes capable d''obtenir de bons résultats en s''investissant dans votre travail. Je vous encourage',getdate()),
			--		   (3,12,20,'Bon trimestre. ','Vous êtes sérieux et motivé. Une bonne participation à continuer dans ce sens.',getdate()),
			--		   --
			--		   (4,0,9,'Résultats insuffisants. ','Vous devez redoubler d''efforts pour progresser.',getdate()),
			--		   (5,9,12,'Ensemble convenable. ','Vous êtes un élève sérieux mais vous devez participer davantage en classe. Vous devez fournir plus d''effort au prochain trimestre.',getdate()),
			--		   (6,12,20,'Bon trimestre. ','Vous êtes sérieux et motivé. Une bonne participation à continuer au prochain trimestre.',getdate()),
			--		   --
			--		   (7,0,9,'Résultats insuffisants. ','Vous êtes un élève sérieux mais manque de maturité dans votre travail.',getdate()),
			--		   (8,9,12,'Assez bon dans l''ensemble. ','Vous devez continuer à vous investir davantage dans votre travail et de participer plus en classe.',getdate()),
			--		   (9,12,20,'Très bon ensemble. ','Très bonne participation et je vous félicite et vous encourage à continuer.',getdate())
			--SET IDENTITY_INSERT [dbo].[NoteCriteria] OFF
			----GO


        COMMIT TRANSACTION;  
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION; 
	THROW
END CATCH









