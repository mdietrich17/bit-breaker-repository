
ALTER TABLE [dbo].[HobbyBridge] DROP CONSTRAINT [FK_dbo.HobbyBridge_dbo.Hobbies_ID]
ALTER TABLE [dbo].[HobbyBridge] DROP CONSTRAINT [FK_dbo.HobbyBridge_dbo.Profile_ID]
ALTER TABLE [dbo].[PostBridge] DROP CONSTRAINT [FK_dbo.PostBridge_dbo.Posts_ID]
ALTER TABLE [dbo].[PostBridge] DROP CONSTRAINT [FK_dbo.PostBridge_dbo.Profile_ID]

DROP TABLE [dbo].[Profile]
DROP TABLE [dbo].[Hobbies]
DROP TABLE [dbo].[HobbyBridge]
DROP TABLE [dbo].[Events]
DROP TABLE [dbo].[Posts]
DROP TABLE [dbo].[PostBridge]
