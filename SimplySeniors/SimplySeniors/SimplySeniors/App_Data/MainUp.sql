CREATE TABLE [dbo].[Profile]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[FIRSTNAME] NVARCHAR (50) NOT NULL,
	[LASTNAME] NVARCHAR (50) NOT NULL,
	[BIRTHDAY] DATE NOT NULL,
	[LOCATION] NVARCHAR (128) NOT NULL,
	[VETSTATUS] BIT,
	[OCCUPATION] NVARCHAR (128) NOT NULL,
	[FAMILY] NVARCHAR (128), /*Probably needs to make a new table if we want to add feature*/ 
	[BIO] NVARCHAR (2048)
	CONSTRAINT [PK_dbo.Profile] PRIMARY KEY CLUSTERED ([ID] ASC)
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


/****** SEED DATA ******/

INSERT INTO [dbo].[Profile] (FIRSTNAME, LASTNAME, BIRTHDAY, LOCATION, VETSTATUS, OCCUPATION, FAMILY, BIO) VALUES
	('Chris', 'Columbus', '1451-09-01', 'Bahamas', 0, 'Explorer', 'Chris Jr.' ,'I discovered india guys i swear'),
	('Ferdinand', 'Magellan', '1480-02-03', 'Chile', 0, 'Explorer','Ferdinand Jr.', 'I will go around the world guys srsly'),
	('Juan', 'de Fuca', '1536-02-11', 'Vancouver Island', 0, 'Explorer', 'Juan Jr.', 'I found a really rainy place' ),
	('Leif', 'Eriksson', '0970-11-15', 'Vinland', 1, 'Viking turned Explorer','Leif Liefsson', 'I found Canada, pretty cool eh?' ),
	('Marco', 'Polo', '1254-01-08', 'Peking', 0, 'Explorer turned pool game', 'MARCO! POLO!', 'Mongolia rough yo'),
	('Sacagawea', 'Shoshone', '1788-05-01', 'Astoria', 0, 'Actual Explorer', 'Sacagawea but on a coin', 'I led dudes accross the United States')

INSERT INTO [dbo].[Profile] (FIRSTNAME, LASTNAME, BIRTHDAY, LOCATION, VETSTATUS, OCCUPATION, FAMILY, BIO) VALUES
	('Bill', 'Gates', '1962-02-01', 'Seattle', 0, 'Inventer', 'Melinda Gates' ,'I am allergic to apples'),
	('Steve', 'Jobs', '1964-10-03', 'Seattle', 0, 'Inventer','Eve Jobs', 'I only use doors, no windows'),
	('Elon', 'Musk', '1971-06-28', 'Canada', 0, 'Visionary', 'Talulah Riley', 'I like sending cars to space and buiding weird machines' ),
	('Mark', 'Zuckerberg', '1984-05-14', 'New York', 1, 'Tech Kid','Priscilla Chan', 'I always have to explain how the internet works to politicians' ),
	('Soros', 'George', '1930-08-12', 'Hungary', 0, 'Investor', 'Tamiko Bolton', 'I give money to places to make way more money back'),
	('Buffett', 'Warren', '1930-08-30', 'Nebraska', 0, 'American Business Magnate', 'Astrid Menks', 'If you fail today then learn and push forward for tomorrow')

INSERT INTO [dbo].[Hobbies] (NAME, DESCRIPTION) VALUES
	('Golf', 'A boring sport that old people and Tiger Woods play'),
	('Fishing', 'A slow activity that old people and young boomers do'),
	('Bingo', 'An activity that both the young and the old enjoy')

INSERT INTO [dbo].[HobbyBridge] (ProfileID, HobbiesID) VALUES
	(6, 1),
	(6, 2),
	(6, 3),
	(1, 1),
	(1, 2),
	(1, 3)