
ALTER TABLE [dbo].[HobbyBridge] DROP CONSTRAINT [FK_dbo.Profiles_dbo.Hobbies_HobbiesID]
ALTER TABLE [dbo].[HobbyBridge] DROP CONSTRAINT [FK_dbo.Profiles_dbo.Profile_ProfileID]


DROP TABLE [dbo].[Profile]
DROP TABLE [dbo].[Hobbies]
DROP TABLE [dbo].[HobbyBridge]