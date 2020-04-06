
ALTER TABLE [dbo].[HobbyBridge] DROP CONSTRAINT [FK_dbo.HobbyBridge_dbo.Hobbies_ID]
ALTER TABLE [dbo].[HobbyBridge] DROP CONSTRAINT [FK_dbo.HobbyBridge_dbo.Profile_ID]
ALTER TABLE [dbo].[Posts] DROP CONSTRAINT [FK_dbo.Posts_dbo.Profile_ID]
ALTER TABLE [DBO].[Images] DROP Constraint [FK_dbo.Images_dbo.Profile_ID]
ALTER TABLE [dbo].[Profile] DROP CONSTRAINT [FK_dbo.Profile_dbo.AspNetUsers_ID]

DROP TABLE [dbo].[Hobbies]
DROP TABLE [dbo].[Events]
DROP TABLE [dbo].[Posts]
DROP TABLE [dbo].[HobbyBridge]
DROP TABLE [dbo].[Profile]

/** UPLOADING PHOTO STUFF BELOW **/
DROP TABLE [dbo].[Images]
DROP PROCEDURE spUploadImage 
DROP PROCEDURE spGetImageById

