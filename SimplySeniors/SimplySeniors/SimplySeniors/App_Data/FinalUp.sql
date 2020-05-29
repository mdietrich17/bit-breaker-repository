-- #######################################
-- #             Identity Tables         #
-- #######################################

-- ############# AspNetRoles #############
CREATE TABLE dbo.AspNetRoles
(
    [Id]   NVARCHAR (128) NOT NULL,
    [Name] NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
    ON dbo.AspNetRoles([Name] ASC);

-- ############# AspNetUsers #############
CREATE TABLE dbo.AspNetUsers
(
    [Id]                   NVARCHAR (128) NOT NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON dbo.AspNetUsers([UserName] ASC);

-- ############# AspNetUserClaims #############
CREATE TABLE dbo.AspNetUserClaims
(
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (128) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES dbo.AspNetUsers ([Id]) ON DELETE CASCADE
);
GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]([UserId] ASC);

-- ############# AspNetUserLogins #############
CREATE TABLE dbo.AspNetUserLogins
(
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [ProviderKey]   NVARCHAR (128) NOT NULL,
    [UserId]        NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC, [UserId] ASC),
    CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES dbo.AspNetUsers ([Id]) ON DELETE CASCADE
);
GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON dbo.AspNetUserLogins([UserId] ASC);

-- ############# AspNetUserRoles #############
CREATE TABLE dbo.AspNetUserRoles
(
    [UserId] NVARCHAR (128) NOT NULL,
    [RoleId] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES dbo.AspNetRoles ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES dbo.AspNetUsers ([Id]) ON DELETE CASCADE
);
GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON dbo.AspNetUserRoles([UserId] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_RoleId] ON dbo.AspNetUserRoles([RoleId] ASC);


/* BELOW IS THE UPSCRIPTS FOR OUR TABLES.*/

CREATE TABLE [dbo].[Profile]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[USERID] NVARCHAR (128) NOT NULL,  /* Fk refrences must be done with the same data type, default ASPNet ID uses nvarchar rather than INT */
	[FIRSTNAME] NVARCHAR (50) NOT NULL,
	[LASTNAME] NVARCHAR (50) NOT NULL,
	[BIRTHDAY] DATE NOT NULL,
	[CITY] NVARCHAR (128),
	[STATE] NVARCHAR (128),
	[VETSTATUS] BIT,
	[PROFILECREATED] BIT DEFAULT 0, 
	[OCCUPATION] NVARCHAR (128),
	[FAMILY] NVARCHAR (128), /*Probably needs to make a new table if we want to add feature*/ 
	[BIO] NVARCHAR (2048)
	CONSTRAINT [PK_dbo.Profile] PRIMARY KEY CLUSTERED ([ID] ASC)
	CONSTRAINT [FK_dbo.Profile_dbo.AspNetUsers_ID] FOREIGN KEY ([USERID]) REFERENCES dbo.AspNetUsers ([Id]) 
	/**
	FOR FUTURE USE PROBABLY
	CONSTRAINT [FK_dbo.Profiles_dbo.Friends_FriendsID] FOREIGN KEY ([FriendsID]) REFERENCES dbo.Friends ([ID])
	CONSTRAINT [FK_dbo.Profiles_dbo.Groups_GroupID] FOREIGN KEY ([GroupID]) REFERENCES dbo.Groups ([ID])
	**/
);

CREATE TABLE [dbo].[Images] /*DB is to store images uploaded to Simply Seniors Website*/
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[NAME] NVARCHAR (30) NOT NULL ,
	[SIZE] INT NOT NULL,
	[ImageData] VARBINARY(max) NOT NULL,
	[ProfileID] INT NOT NULL
	CONSTRAINT [PK_dbo.Images] PRIMARY KEY CLUSTERED ([ID] ASC)
	CONSTRAINT [FK_dbo.Images_dbo.Profile_ID] FOREIGN KEY ([ProfileID]) REFERENCES [dbo].[Profile] ([ID])
);

CREATE TABLE [dbo].[Hobbies]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[NAME] NVARCHAR (30) NOT NULL,
	[DESCRIPTION] TEXT NOT NULL
	CONSTRAINT [PK_dbo.Hobbies] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[HobbyBridge]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[ProfileID] INT,
	[HobbiesID] INT,
	CONSTRAINT [PK_dbo.HobbyBridge] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.HobbyBridge_dbo.Profile_ID] FOREIGN KEY ([ProfileID]) REFERENCES [dbo].[Profile] ([ID]),
	CONSTRAINT [FK_dbo.HobbyBridge_dbo.Hobbies_ID] FOREIGN KEY ([HobbiesID]) REFERENCES [dbo].[Hobbies] ([ID])
);

CREATE TABLE [dbo].[Events]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[NAME] NVARCHAR (128) NOT NULL,
	[DESCRIPTION] NVARCHAR (2048) NOT NULL,
	[COUNTRY] NVARCHAR (128) NOT NULL,
	[STATE] NVARCHAR (128) NOT NULL,
	[CITY] NVARCHAR (128) NOT NULL,
	[STREETADDRESS] NVARCHAR (128) NOT NULL,
	[ZIPCODE] NVARCHAR (10) NOT NULL,
	[STARTDATE] DATE NOT NULL,
	[STARTTIME] DATETIME NOT NULL,
	[ENDDATE] DATE NOT NULL,
	[ENDTIME] DATETIME NOT NULL,
	/** uncomment below line to add connection to profile db once connection set up
	[PERSONID] INT NOT NULL, 
	**/
	CONSTRAINT [PK_dbo.Events] PRIMARY KEY CLUSTERED ([ID] ASC)
	/** uncomment below line to set up connection between owner and event once connection is set up
	CONSTRAINT[FK_dbo.Profile] FOREIGN KEY (PERSONID) REFERENCES Profile(ID)
	**/
);

CREATE TABLE [dbo].[Posts]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[Title] NVARCHAR(64) NOT NULL,
	[Body] NVARCHAR(256),
	[ProfileID] INT NOT NULL,
	[Likes] INT NOT NULL,
	[PostDate] DateTime NOT NULL,
	CONSTRAINT [PK_dbo.Posts] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Posts_dbo.Profile_ID] FOREIGN KEY ([ProfileID]) REFERENCES [dbo].[Profile] ([ID])
	
);

CREATE TABLE [dbo].[PostLike]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[ProfileID] INT NOT NULL,
	[Liked] BIT NOT NULL,
	[PostID] INT NOT NULL
	CONSTRAINT [PK_dbo.PostLike] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.PostLike_dbo.Profile_ID] FOREIGN KEY ([ProfileID]) REFERENCES [dbo].[Profile] ([ID]),
	CONSTRAINT [FK_dbo.PostLike_dbo.Post_ID] FOREIGN KEY ([PostID]) REFERENCES [dbo].[Posts] ([ID])
);

CREATE TABLE [dbo].[PostComment]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[Text] NVARCHAR (256),
	[CommentDate] DATETIME NOT NULL,
	[ProfileID] INT NOT NULL,
	[PostID] INT NOT NULL,
	CONSTRAINT [PK_dbo.PostComment] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.PostComment_dbo.Profile_ID] FOREIGN KEY ([ProfileID]) REFERENCES [dbo].[Profile] ([ID]),
	CONSTRAINT [FK_dbo.PostComment_dbo.Post_ID] FOREIGN KEY ([PostID]) REFERENCES [dbo].[Profile] ([ID])
);

CREATE TABLE [dbo].[FollowList]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[UserID] INT NOT NULL,
	[FollowedUserID] INT NOT NULL,
	[TimeFollowed] DATETIME NOT NULL,
	Constraint [PK_dbo.FollowList] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.FollowList_User_dbo.Profile_ID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Profile] ([ID]),
	CONSTRAINT [FK_dbo.FollowList_Follow_dbo.Profile_ID] FOREIGN KEY ([FollowedUserID]) REFERENCES [dbo].[Profile] ([ID])
);

/*
CREATE TABLE [dbo].[PostBridge]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[PostID] INT NOT NULL,
	[ProfileID] INT NOT NULL,
	CONSTRAINT [PK_dbo.PostBridge] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.PostBridge_dbo.Posts_ID] FOREIGN KEY ([PostID]) REFERENCES [dbo].[Posts] ([ID]),
	CONSTRAINT [FK_dbo.PostBridge_dbo.Profile_ID] FOREIGN KEY ([ProfileID]) REFERENCES [dbo].[Profile] ([ID])
);
*/



/****** SEED DATA ******/
DELETE FROM [DBO].[AspNetUsers] Where AspNetUsers.Id = 'AAA-123' /* remove one seed data while maintaining other user information */
INSERT INTO [DBO].[AspNetUsers] (Id, Email, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled,LockoutEnabled,AccessFailedCount,UserName) VALUES
('AAA-123', 'throwaway@gmail.com', 0, 0, 0, 0, 0, 'Dennis')

INSERT INTO [dbo].[Profile] (FIRSTNAME, LASTNAME, BIRTHDAY, CITY, STATE, VETSTATUS, OCCUPATION, FAMILY, BIO, USERID) VALUES
	('Chris', 'Columbus', '1451-09-01', 'Columbus', 'Ohio', 0, 'Explorer', 'Chris Jr.' ,'I discovered india guys i swear','AAA-123'),
	('Ferdinand', 'Magellan', '1480-02-03', 'Portland', 'Oregon', 0, 'Explorer','Ferdinand Jr.', 'I will go around the world guys srsly', 'AAA-123'),
	('Juan', 'de Fuca', '1536-02-11', 'Austin', 'Texas', 0, 'Explorer', 'Juan Jr.', 'I found a really rainy place' , 'AAA-123' ),
	('Leif', 'Eriksson', '0970-11-15', 'Salem', 'Oregon', 1, 'Viking turned Explorer','Leif Liefsson', 'I found Canada, pretty cool eh?', 'AAA-123' ),
	('Marco', 'Polo', '1254-01-08', 'Monmouth', 'Oregon', 0, 'Explorer turned pool game', 'MARCO! POLO!', 'Mongolia rough yo', 'AAA-123'),
	('Sacagawea', 'Shoshone', '1788-05-01', 'Seattle', 'Washington', 0, 'Actual Explorer', 'Sacagawea but on a coin', 'I led dudes accross the United States', 'AAA-123');

INSERT INTO [dbo].[Profile] (FIRSTNAME, LASTNAME, BIRTHDAY, CITY, STATE, VETSTATUS, OCCUPATION, FAMILY, BIO, USERID) VALUES
	('Bill', 'Gates', '1962-02-01', 'Seattle', 'Washington', 0, 'Inventer', 'Melinda Gates' ,'I am allergic to apples','AAA-123'),
	('Steve', 'Jobs', '1964-10-03', 'Seattle', 'Washington', 0, 'Inventer','Eve Jobs', 'I only use doors, no windows','AAA-123'),
	('Elon', 'Musk', '1971-06-28', 'Bend', 'Oregon', 0, 'Visionary', 'Talulah Riley', 'I like sending cars to space and buiding weird machines','AAA-123' ),
	('Mark', 'Zuckerberg', '1984-05-14', 'New York', 'New York', 1, 'Tech Kid','Priscilla Chan', 'I always have to explain how the internet works to politicians','AAA-123' ),
	('Soros', 'George', '1930-08-12', 'Chicago', 'Illinois', 0, 'Investor', 'Tamiko Bolton', 'I give money to places to make way more money back','AAA-123'),
	('Buffett', 'Warren', '1930-08-30', 'Tampa', 'Florida', 0, 'American Business Magnate', 'Astrid Menks', 'If you fail today then learn and push forward for tomorrow','AAA-123');

INSERT INTO [dbo].[Hobbies] (NAME, DESCRIPTION) VALUES
	('Golf', 'A boring sport that old people and Tiger Woods play'),
	('Fishing', 'A slow activity that old people and young boomers do'),
	('Bingo', 'An activity that both the young and the old enjoy'),
	('Hunting', 'Age old boomer activity to rid the world of deer'),
	('Cartography', 'Age old activity to show boomers places they havent destroyed'),
	('Pillaging', 'Acient activity now labeled, "Nestle Corporation"');

--INSERT INTO [dbo].[Images] (NAME, SIZE, IMAGEDATA, PROFILEID) VALUES
--('Columbus.jpg', '13579',(SELECT CONVERT(varbinary(max), '0xFFD8FFDB0043000D090A0B0A080D0B0A0B0E0E0D0F13201513121213271C1E17202E2931302E292D2C333A4A3E333646372C2D405741464C4E525352323E5A615A50604A51524FFFDB0043010E0E0E131113261515264F352D354F4F4F4F4F4F4F4F4F4F4F4F4F4F4F4F4F4F4F4F4F4F4F4F4F4F4F4F4F4F4F4F4F4F4F4F4F4F', 1),
--('Magellan.jpg', '199935', '0xFFD8FFE000104A46494600010101004800480000FFE2EE304943435F50524F46494C450001010000EE20000000000420000073706163524742204C61622007D70007001900000005002561637370000000000000000000000000000000000000000000000000000000000000F6D6000100000000D32D0000000034562ABF994C', '2'),
--('Fuca.png', '83169', '0x89504E470D0A1A0A0000000D49484452000000FA000001170806000000844159D5000000097048597300000B1300000B1301009A9C180000000774494D4507DC0806081B0B8CC421430000000774455874417574686F7200A9AECC480000000C744558744465736372697074696F6E00130921230000000A74455874436F7079', '3'), 
--('Erikson.jpg', '45733', '0xFFD8FFE000104A46494600010101004800480000FFDB0043000604040405040605050609060506090B080606080B0C0A0A0B0A0A0C100C0C0C0C0C0C100C0E0F100F0E0C1313141413131C1B1B1B1C20202020202020202020FFDB0043010707070D0C0D181010181A1511151A20202020202020202020202020202020202020', '4'),
--('Polo.jpg', '64848', '0xFFD8FFE000104A46494600010101006000600000FFDB0043000403030303020403030304040405060A06060505060C0809070A0E0C0F0E0E0C0D0D0F1116130F1015110D0D131A131517181919190F121B1D1B181D16181918FFDB0043010404040605060B06060B18100D101818181818181818181818181818181818181818', '5'),
--('Sacagawea.jpg', '56060', '0xFFD8FFE000104A46494600010100000100010000FFE202A04943435F50524F46494C45000101000002906C636D73043000006D6E74725247422058595A2007E20001001500020017001B616373704150504C0000000000000000000000000000000000000000000000000000F6D6000100000000D32D6C636D73000000000000', '6'),
--('Gates.jpg', '23065', '0xFFD8FFE000104A46494600010100000100010000FFE202A04943435F50524F46494C45000101000002906C636D73043000006D6E74725247422058595A2007E200040018000D002C0018616373704150504C0000000000000000000000000000000000000000000000000000F6D6000100000000D32D6C636D73000000000000', '7'),
--('Jobs.jpg', '181270', '0xFFD8FFE000104A46494600010101012C012C0000FFDB004300030202020202030202020303030304060404040404080606050609080A0A090809090A0C0F0C0A0B0E0B09090D110D0E0F101011100A0C12131210130F101010FFDB00430103030304030408040408100B090B1010101010101010101010101010101010101010', '8'), 
--('Musk.jpg', '151791', '0xFFD8FFE000104A46494600010101009600960000FFDB0043000302020302020303030304030304050805050404050A070706080C0A0C0C0B0A0B0B0D0E12100D0E110E0B0B1016101113141515150C0F171816141812141514FFDB00430103040405040509050509140D0B0D1414141414141414141414141414141414141414', '9'), 
--('Zuckerberg.png', '100059', '0x89504E470D0A1A0A0000000D49484452000000EE000001150806000000E7CCD94C000000097048597300000B1300000B1301009A9C180000200049444154789CBCBD5797244976E7F7333317A145EAACAC2CDDD56ABA47ED623118000360012CF0B83CE4E157E1E33CF1811F839F609F78C85DEEE2900B1C128B91E8996959D5', '10'),
--('Soros.jpg', '213391', '0xFFD8FFE000104A46494600010100000100010000FFE1003645786966000049492A0008000000010098820200110000001A00000000000000414650206F72206C6963656E736F727300000000FFED005C50686F746F73686F7020332E30003842494D04040000000000241C015A00031B25471C0200000200021C027400104146', '11' ), 
--('Buffet.jpg', '12919', '0xFFD8FFE000104A46494600010100000100010000FFDB0043000604040405040605050609060506090B080606080B0C0A0A0B0A0A0C100C0C0C0C0C0C100C0E0F100F0E0C1313141413131C1B1B1B1C1F1F1F1F1F1F1F1F1F1FFFDB0043010707070D0C0D181010181A1511151A1F1F1F1F1F1F1F1F1F1F1F1F1F1F1F1F1F1F1F', '12' ); 

INSERT INTO [dbo].[HobbyBridge] (ProfileID, HobbiesID) VALUES
	(6, 2),
	(6, 4),
	(6, 5),
	(1, 1),
	(1, 2),
	(1, 3),
	(2, 3),
	(4, 6),
	(5, 6);

INSERT INTO [dbo].[Events] (NAME, DESCRIPTION, STARTDATE, STARTTIME, ENDDATE, ENDTIME, COUNTRY, STATE, CITY, STREETADDRESS, ZIPCODE)	VALUES
('Ghirardelli Wedding', 'A beautiful wedding open for the public, everyone is invited!', '03/09/2021', '05:00 PM', '03/09/2021', '09:00 PM', 'United States', 'Oregon', 'Monmouth', '345 Monmouth Ave N', '97361'),
('Spy Retirement Banquet', 'Spies only. No other information provided because the spies should already know the info for this event.', '04/12/2020', '06:30 PM', '04/12/2020', '11:00 PM', 'United States', 'Oregon', 'Salem', '200 Commercial St SE', '97301'),
('Birthday for Myrtle', 'Join Myrtle in her 72nd birthday celebration! Please email Myrtle directly to RSVP to this event.', '05/20/2020', '03:00 PM', '05/20/2020', '07:00 PM', 'United States', 'Washington', 'Seattle', '400 Broad St', '98109'),
('Tai Chi', 'Come experience Tai Chi with professor Brad Gerbs and experience relaxation while also getting some exercise in!', '07/19/2020', '05:00 PM', '07/19/2020', '06:30 PM', 'United States', 'Utah', 'Park City', '1345 Lowell Ave', '84060'),
('Knitting Camp', 'Come join us in the Beginners Knitting Class 2020 and make something to be proud of!', '04/15/2020', '06:00 PM', '04/22/2020', '06:00 PM', 'United States', 'Colorado', 'Denver', '4600 Humboldt St', '80216'),
('Bachelorette Party', 'Party with the gals, byob', '06/05/2020', '10:00 PM', '06/06/2020', '05:00 AM', 'United States', 'Oregon', 'Portland', '1825 SW Broadway', '97201');

INSERT INTO [dbo].[Posts] (Title, Body, ProfileID, Likes, PostDate) VALUES 
('Felt cute might delete later idk', 'Nothing', 1, 0, '1800-05-01'),
('Something something politics', 'politics politics politics...controversial statement', 2, 0,  '1801-05-01'),
('Coronavirus scary', 'But not as scary as how refreshing sprite actually is(NOT SPONSORED)', 3, 0, '1802-05-01'),
('Got smallpox again lmao', 'Please donate to my gofundme', 4, 0, '1803-05-01'),
('Feeling seasick','please someone give me an orange my teeth are falling out', 5, 0, '1804-05-01'),
('FORTNITE GAMEPLAY (EPISODE 2006)','MAKE SURE TO LIKE, COMMENT, AND SUBSCRIBE FOR MORE 1337 wins', 6, 0, '1805-05-01');

INSERT INTO [dbo].FollowList (UserID, FollowedUserID, TimeFollowed) VALUES
(1, 2, '1788-05-01'),
(1, 3, '1788-05-01'),
(1, 4, '1788-05-01'),
(1, 5, '1788-05-01'),
(1, 6, '1788-05-01');


/*
INSERT INTO [dbo].[PostBridge] (PostID, ProfileID) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6)
*/

Go
CREATE PROC spUploadImage 
@Name NVARCHAR(255), 
@Size INT, 
@ProfileId INT, 
@ImageData VARBINARY(max), 
@NewID INT output 
as
Begin
	INSERT into Images
	values(@Name, @Size, @ImageData,@ProfileId)
	Select @NewId = SCOPE_IDENTITY()    /** Returns the index of the location of the stored image within the Images table **/
End
GO
/** This code creates a procedure within our db to use SQL query to retireve the binary image data. **/
CREATE PROC spGetImageById
@Id INT
as
Begin 
	SELECT ImageData FROM Images WHERE Id = @Id
End
Go
