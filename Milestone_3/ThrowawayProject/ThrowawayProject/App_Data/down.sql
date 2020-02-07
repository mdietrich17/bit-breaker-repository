﻿ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
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