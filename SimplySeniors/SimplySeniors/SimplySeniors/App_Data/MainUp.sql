CREATE TABLE [dbo].[Profile]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[USERID] NVARCHAR (128) NOT NULL,  /* Fk refrences must be done with the same data type, default ASPNet ID uses nvarchar rather than INT */
	[FIRSTNAME] NVARCHAR (50) NOT NULL,
	[LASTNAME] NVARCHAR (50) NOT NULL,
	[BIRTHDAY] DATE NOT NULL,
	[LOCATION] NVARCHAR (128),
	[VETSTATUS] BIT,
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
	[LOCATION] NVARCHAR (128) NOT NULL,
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
	CONSTRAINT [PK_dbo.Posts] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Posts_dbo.Profile_ID] FOREIGN KEY ([ProfileID]) REFERENCES [dbo].[Profile] ([ID])
	
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

INSERT INTO [dbo].[Profile] (FIRSTNAME, LASTNAME, BIRTHDAY, LOCATION, VETSTATUS, OCCUPATION, FAMILY, BIO) VALUES
	('Chris', 'Columbus', '1451-09-01', 'Bahamas', 0, 'Explorer', 'Chris Jr.' ,'I discovered india guys i swear'),
	('Ferdinand', 'Magellan', '1480-02-03', 'Chile', 0, 'Explorer','Ferdinand Jr.', 'I will go around the world guys srsly'),
	('Juan', 'de Fuca', '1536-02-11', 'Vancouver Island', 0, 'Explorer', 'Juan Jr.', 'I found a really rainy place' ),
	('Leif', 'Eriksson', '0970-11-15', 'Vinland', 1, 'Viking turned Explorer','Leif Liefsson', 'I found Canada, pretty cool eh?' ),
	('Marco', 'Polo', '1254-01-08', 'Peking', 0, 'Explorer turned pool game', 'MARCO! POLO!', 'Mongolia rough yo'),
	('Sacagawea', 'Shoshone', '1788-05-01', 'Astoria', 0, 'Actual Explorer', 'Sacagawea but on a coin', 'I led dudes accross the United States');

INSERT INTO [dbo].[Profile] (FIRSTNAME, LASTNAME, BIRTHDAY, LOCATION, VETSTATUS, OCCUPATION, FAMILY, BIO) VALUES
	('Bill', 'Gates', '1962-02-01', 'Seattle', 0, 'Inventer', 'Melinda Gates' ,'I am allergic to apples'),
	('Steve', 'Jobs', '1964-10-03', 'Seattle', 0, 'Inventer','Eve Jobs', 'I only use doors, no windows'),
	('Elon', 'Musk', '1971-06-28', 'Canada', 0, 'Visionary', 'Talulah Riley', 'I like sending cars to space and buiding weird machines' ),
	('Mark', 'Zuckerberg', '1984-05-14', 'New York', 1, 'Tech Kid','Priscilla Chan', 'I always have to explain how the internet works to politicians' ),
	('Soros', 'George', '1930-08-12', 'Hungary', 0, 'Investor', 'Tamiko Bolton', 'I give money to places to make way more money back'),
	('Buffett', 'Warren', '1930-08-30', 'Nebraska', 0, 'American Business Magnate', 'Astrid Menks', 'If you fail today then learn and push forward for tomorrow');

INSERT INTO [dbo].[Hobbies] (NAME, DESCRIPTION) VALUES
	('Golf', 'A boring sport that old people and Tiger Woods play'),
	('Fishing', 'A slow activity that old people and young boomers do'),
	('Bingo', 'An activity that both the young and the old enjoy'),
	('Hunting', 'Age old boomer activity to rid the world of deer'),
	('Cartography', 'Age old activity to show boomers places they havent destroyed'),
	('Pillaging', 'Acient activity now labeled, "Nestle Corporation"');

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

INSERT INTO [dbo].[Events] (NAME, DESCRIPTION, STARTDATE, STARTTIME, ENDDATE, ENDTIME, LOCATION)	VALUES
('Ghirardelli Wedding', 'A beautiful wedding open for the public, everyone is invited!', '03/09/2021', '05:00 PM', '03/09/2021', '09:00 PM', 'State Street Event Center'),
('Spy Retirement Banquet', 'Spies only. No other information provided because the spies should already know the info for this event.', '04/12/2020', '06:30 PM', '04/12/2020', '11:00 PM', 'United Artists Headquarters'),
('Bachelorette Party', 'Party with the gals, byob', '06/05/2020', '10:00 PM', '06/06/2020', '05:00 AM', 'The Amado');

INSERT INTO [dbo].[Posts] (Title, Body, ProfileID) VALUES 
('Felt cute might delete later idk', 'Nothing', 1),
('Something something politics', 'politics politics politics...controversial statement', 2),
('Coronavirus scary', 'But not as scary as how refreshing sprite actually is(NOT SPONSORED)', 3),
('Got smallpox again lmao', 'Please donate to my gofundme', 4),
('Feeling seasick','please someone give me an orange my teeth are falling out', 5),
('FORTNITE GAMEPLAY (EPISODE 2006)','MAKE SURE TO LIKE, COMMENT, AND SUBSCRIBE FOR MORE 1337 wins', 6);


/*
INSERT INTO [dbo].[PostBridge] (PostID, ProfileID) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6)
*/

