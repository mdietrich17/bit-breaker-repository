
ALTER TABLE [dbo].[HobbyBridge] DROP CONSTRAINT [FK_dbo.HobbyBridge_dbo.Hobbies_ID]
ALTER TABLE [dbo].[HobbyBridge] DROP CONSTRAINT [FK_dbo.HobbyBridge_dbo.Profile_ID]


DROP TABLE [dbo].[Profile]
DROP TABLE [dbo].[Hobbies]
DROP TABLE [dbo].[HobbyBridge]
DROP TABLE [dbo].[Events]
