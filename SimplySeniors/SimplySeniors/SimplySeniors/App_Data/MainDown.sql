
ALTER TABLE [dbo].[HobbyBridge] DROP CONSTRAINT [FK_dbo.HobbyBridge_dbo.Hobbies_ID]
ALTER TABLE [dbo].[HobbyBridge] DROP CONSTRAINT [FK_dbo.HobbyBridge_dbo.Profile_ID]
ALTER TABLE [dbo].[Posts] DROP CONSTRAINT [FK_dbo.Posts_dbo.Profile_ID]
ALTER TABLE [DBO].[Images] DROP Constraint [FK_dbo.Images_dbo.Profile_ID]
ALTER TABLE [dbo].[Profile] DROP CONSTRAINT [FK_dbo.Profile_dbo.AspNetUsers_ID]
ALTER TABLE [dbo].[FollowList] DROP CONSTRAINT [FK_dbo.FollowList_User_dbo.Profile_ID]
ALTER TABLE [dbo].[FollowList] DROP CONSTRAINT [FK_dbo.FollowList_Follow_dbo.Profile_ID]
ALTER TABLE [dbo].[PostLike] DROP CONSTRAINT [FK_dbo.PostLike_dbo.Profile_ID]
ALTER TABLE [dbo].[PostLike] DROP CONSTRAINT [FK_dbo.PostLike_dbo.Post_ID]
ALTER TABLE [dbo].[PostComment] DROP CONSTRAINT [FK_dbo.PostComment_dbo.Profile_ID]
ALTER TABLE [dbo].[PostComment] DROP CONSTRAINT [FK_dbo.PostComment_dbo.Post_ID]



DROP TABLE [dbo].[Hobbies]
DROP TABLE [dbo].[Events]
DROP TABLE [dbo].[Posts]
DROP TABLE [dbo].[HobbyBridge]
DROP TABLE [dbo].[Profile]
DROP TABLE [dbo].[FollowList]
DROP TABLE [dbo].[PostLike]
DROP TABLE [dbo].[PostComment]

/** UPLOADING PHOTO STUFF BELOW **/
DROP TABLE [dbo].[Images]
DROP PROCEDURE spUploadImage 
DROP PROCEDURE spGetImageById

