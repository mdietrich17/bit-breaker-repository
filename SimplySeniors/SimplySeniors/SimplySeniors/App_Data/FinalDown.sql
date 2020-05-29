
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
GO
DROP TABLE [dbo].[Hobbies]
DROP TABLE [dbo].[Events]
DROP TABLE [dbo].[Posts]
DROP TABLE [dbo].[HobbyBridge]
DROP TABLE [dbo].[Profile]
DROP TABLE [dbo].[FollowList]
DROP TABLE [dbo].[PostLike]
DROP TABLE [dbo].[PostComment]
DROP TABLE [dbo].[Images]
DROP PROCEDURE spUploadImage 
DROP PROCEDURE spGetImageById
GO
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [PK_dbo.AspNetUserLogins]
ALTER TABLE	[dbo].[AspNetRoles] DROP CONSTRAINT [PK_dbo.AspNetRoles]
ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
ALTER TABLE [dbo].[AspNetUsers] DROP CONSTRAINT [PK_dbo.AspNetUsers]
ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [PK_dbo.AspNetUserClaims]
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [PK_dbo.AspNetUserRoles]
GO
DROP TABLE [dbo].[AspNetRoles]
DROP TABLE [dbo].[AspNetUsers]
DROP TABLE [dbo].[AspNetUserClaims]
DROP TABLE [dbo].[AspNetUserLogins]
DROP TABLE [dbo].[AspNetUserRoles]
GO


